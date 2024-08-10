using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Threading;

namespace NDispWin
{
    class Task_InputMap
    {
        public class Lumileds_SS_EMap//signalsure emap
        {
            #region Lumileds_Map_Conversion Documentation
            /*
Lumileds Maps
Date: 30/010/2018
DispCore.dll v1.2.89.x
Venue: P1, Signalsure, COB, Vis Map.

Sample of known maps as follows:

Type 1 Signalsure - Unknown Output Source
FileName = 16A24001.txt
Start Time:	15 Nov 2016, 07:13 PM
End Time:	15 Nov 2016, 07:14 PM
WO No:	0001
Lot No:	0001
Part No:	0001
Panel ID:	16A24A001
Operator:	123
<START>
No.	LOC	P/F	Cat	
1	01	PASS	PASS -> start from 1	
1	02	PASS	PASS	
3	03	PASS	PASS	
4	04	FAIL	PVI	
..
180   04	PASS	PASS

Format:	Use No. LOC and P/F
where:
No	Index of the unit.
LOC	Defines the index of the units. 
	Index starts from top right, up to down, serpentine
P/F	Defines Pass Fail. PASS - Dispense; FAIL - Skip Dispense
Feature:	Ext: “.txt”
Detect:	Contain: “<START>”

Type 2 COB - ASM Ring Output File
FileName = M35B50A6U07A_DAM001.txt
Machine ID:	CDW#6
Start Time:	2018-07-10 10:24:07
End Time:	2018-07-10 10:24:23
Product ID:	DFCC24508001
WO NO:	110956565
MES Lot:	PU2876860
Panel ID:	M35B50A6U07A
Operator:	6672
Silicone Part:	324700000823
Silicone Time:	10-Jul-2018_09:11:26
Workholder:	Left
-----Start
No.	Loc P/F
1	1	PASS
2	2	PASS
3	3	PASS

Format:	Use No. LOC and P/F
where:
No	Index of the unit.
LOC	Defines the index of the units. 
	Index starts from top right, up to down, right to left
P/F	Defines Pass Fail. PASS - Dispense; FAIL - Skip Dispense
Feature:	Posfix: “_DAM001.txt”
Ext: “.txt”
Detect:	Contain: “-Start”

Type 3 Vis – Vis Output File
FileName = WFR18A24A036-T390.vis
HRow	Col	Defects	
HLastInspect	18	32	
2	4	IC	
3	4	IC	
10	28	WB	
10	7	IC	
17	13	IC	
18	27	IC	

Format:	Filename feature: 
Decoding Method
where:
Data sequence is Row, Col, DefectCode
DefectCode - Skip Dispense

Feature:	Prefix: “WFR”
Posfix: ”-T390”
Ext: “.vis”
Detect:	Contain: "HLastInspect"

EndOfDoc
*/
            #endregion

            public static NUtils.LogFileW Log = new NUtils.LogFileW(GDefine.DataPath + "\\LmdsEMap\\");

            const int MAX_TYPES = 3;
            public static string[] MapPath = new string[MAX_TYPES] { "", "", "" };
            public static string[] FilenamePrefix = new string[MAX_TYPES] { "", "", "" };
            public static string[] FilenameSuffix = new string[MAX_TYPES] { "", "", "" };
            enum EFileType { None, SS, COB, VIS }

            public static void SaveSetup()
            {
                NSW.Net.IniFile IniFile = new NSW.Net.IniFile();

                string Filename = GDefine.SetupPath + "\\LmdsEMap.ini";
                IniFile.Create(Filename);

                string s_Idx = "";  
                for (int i = 0; i < MAX_TYPES; i++)
                {
                    if (i > 0) s_Idx = i.ToString();
                    IniFile.WriteString("Server" + s_Idx, "MapPath", MapPath[i]);
                    IniFile.WriteString("Server" + s_Idx, "FilenamePrefix", FilenamePrefix[i]);
                    IniFile.WriteString("Server" + s_Idx, "FilenameSuffix", FilenameSuffix[i]);
                }
            }
            public static void LoadSetup()
            {
                NSW.Net.IniFile IniFile = new NSW.Net.IniFile();

                string Filename = GDefine.SetupPath + "\\LmdsEMap.ini";
                IniFile.Create(Filename);

                string s_Idx = "";
                for (int i = 0; i < MAX_TYPES; i++)
                {
                    if (i > 0) s_Idx = i.ToString();
                    MapPath[i] = IniFile.ReadString("Server" + s_Idx, "MapPath", "");
                    FilenamePrefix[i] = IniFile.ReadString("Server" + s_Idx, "FilenamePrefix", "");
                    FilenameSuffix[i] = IniFile.ReadString("Server" + s_Idx, "FilenameSuffix", "");
                }
            }
            /// <summary>
            /// Map 0-Fail, 1 - Pass
            /// </summary>
            /// <returns></returns>
            public static bool DecodeMap(string LotNo, string FrameNo, ref int[,] SS_Map_CR, bool singulated = false)
            {
                try
                {
                    #region check map path/lot path/file
                    //  Check for file at all the locations
                    string s_MapPath = "";
                    string s_LotPath = "";
                    string s_FrameFile = "";

                    bool b_MapPathFound = false;
                    bool b_LotPathFound = false;
                    EFileType FileType = EFileType.None;

                    for (int i = 0; i < MAX_TYPES; i++)
                    {
                        if (MapPath[i].Length == 0) continue;

                        s_MapPath = MapPath[i];
                        if (Directory.Exists(s_MapPath))
                        {
                            b_MapPathFound = true;

                            s_LotPath = MapPath[i] + LotNo;
                            if (Directory.Exists(s_LotPath))
                            {
                                b_LotPathFound = true;

                                s_FrameFile = s_LotPath + "\\" + FilenamePrefix[i] + FrameNo + FilenameSuffix[i] + ".txt";
                                if (File.Exists(s_FrameFile))
                                {
                                    FileType = EFileType.SS;
                                    break;
                                }

                                s_FrameFile = s_LotPath + "\\" + FilenamePrefix[i] + FrameNo + FilenameSuffix[i] + ".vis";
                                if (File.Exists(s_FrameFile))
                                {
                                    FileType = EFileType.VIS;
                                    break;
                                }
                            }
                        }
                    }

                    if (singulated)//Singulated mode uses Index 1 path
                    {
                        s_MapPath = MapPath[1];
                        s_LotPath = s_MapPath + LotNo;
                        s_FrameFile = s_LotPath + "\\" + FilenamePrefix[1] + FrameNo + FilenameSuffix[1] + ".txt";
                        FileType = EFileType.COB;
                    }

                    if (!b_MapPathFound)
                    {
                        string s_Msg = "Map Path [" + s_MapPath + "] not found.";
                        Log.WriteByMonthDay(s_Msg);
                        throw new Exception(s_Msg);
                    }
                    if (!b_LotPathFound)
                    {
                        string s_Msg = "Lot Directory [" + s_LotPath + "] not found.";
                        Log.WriteByMonthDay(s_Msg);
                        throw new Exception(s_Msg);
                    }
                    if (FileType == EFileType.None)
                    {
                        s_FrameFile = Path.GetFileNameWithoutExtension(s_FrameFile) + ".*";

                        string s_Msg = "FrameFile [" + s_FrameFile + "] not found.";
                        Log.WriteByMonthDay(s_Msg);
                        throw new Exception(s_Msg);
                    }
                    #endregion

                    Log.WriteByMonthDay("Decoding [" + s_FrameFile + "].");
                    switch (FileType)
                    {
                        case EFileType.COB:
                        case EFileType.SS:
                            {
                                //deccode
                                List<string[]> lf_data = new List<string[]>();
                                char[] delimiters = new char[] { (char)9 };
                                bool b_Data = false;

                                int[] Map = new int[8192];
                                for (int i = 0; i < 8192; i++) Map[i] = 0;

                                using (StreamReader reader = new StreamReader(s_FrameFile))
                                {
                                    while (true)
                                    {
                                        string line = reader.ReadLine();
                                        if (line == null)
                                        {
                                            break;
                                        }
                                        string[] l_Line = line.Split(delimiters);

                                        if (!b_Data)
                                        {
                                            if (l_Line[0].ToUpper().Contains("<START>")) FileType = EFileType.SS;
                                            else if (l_Line[0].ToUpper().Contains("-START")) FileType = EFileType.COB;
                                            //else throw new Exception("File Type Detect Error.");

                                            if (l_Line[0].StartsWith("No"))
                                            {
                                                b_Data = true;
                                                continue;
                                            }
                                        }
                                        #region
                                        if (b_Data)
                                        {
                                            int UnitNo = 0;

                                            if (l_Line[0].Length == 0) continue;

                                            try
                                            {
                                                l_Line[1] = l_Line[1].Trim();//unit no starts from 1
                                                UnitNo = Convert.ToInt32(l_Line[0]);
                                            }
                                            catch { throw new Exception("Convert UnitNo Ex Error."); }


                                            if (l_Line[2].Contains("PASS"))
                                            {
                                                Map[UnitNo - 1] = 1;//map starts from 1, int array start from 0
                                            }
                                        }
                                        #endregion
                                    }
                                }

                                #region convert to cr map
                                SS_Map_CR = new int[1024, 1024];
                                int Col = DispProg.rt_Layouts[0].TColCount;
                                int Row = DispProg.rt_Layouts[0].TRowCount;
                                int idx = 0;
                                for (int c = 0; c < Col; c++)
                                {
                                    for (int r = 0; r < Row; r++)
                                    {
                                        int uc = 0;
                                        int ur = 0;

                                        uc = c;
                                        switch (FileType)
                                        {
                                            case EFileType.COB:
                                                ur = r;
                                                break;
                                            case EFileType.SS:
                                                if (c % 2 == 0)
                                                    ur = r;
                                                else
                                                    ur = Row - 1 - r;
                                                break;
                                        }

                                        SS_Map_CR[uc, ur] = Map[idx];
                                        idx++;
                                    }

                                }
                                #endregion
                            }
                            break;
                        case EFileType.VIS:
                            {
                                SS_Map_CR = new int[1024, 1024];
                                //reset map - set all to OK
                                int Col = DispProg.rt_Layouts[0].TColCount;
                                int Row = DispProg.rt_Layouts[0].TRowCount;
                                for (int c = 0; c < Col; c++)
                                    for (int r = 0; r < Row; r++)
                                        SS_Map_CR[c, r] = 1;

                                //decode
                                List<string[]> lf_data = new List<string[]>();
                                char[] delimiters = new char[] { (char)9 };
                                bool b_Data = false;
                                using (StreamReader reader = new StreamReader(s_FrameFile))
                                {
                                    while (true)
                                    {
                                        string line = reader.ReadLine();
                                        if (line == null)
                                        {
                                            break;
                                        }
                                        string[] l_Line = line.Split(delimiters);

                                        if (!b_Data)
                                        {
                                            if (l_Line[0].StartsWith("HLastInspect"))
                                            {
                                                b_Data = true;
                                                continue;
                                            }
                                        }
                                        #region
                                        if (b_Data)
                                        {
                                            int i_Row = 1;
                                            try
                                            {
                                                l_Line[0] = l_Line[0].Trim();
                                                i_Row = Convert.ToInt32(l_Line[0]);
                                            }
                                            catch { throw new Exception("Convert {" + line + "} to RowNo Ex Error."); }

                                            int i_Col = 1;
                                            try
                                            {
                                                l_Line[1] = l_Line[1].Trim();
                                                i_Col = Convert.ToInt32(l_Line[1]);
                                            }
                                            catch { throw new Exception("Convert {" + line + "} to ColNo Ex Error."); }

                                            SS_Map_CR[i_Col - 1, i_Row - 1] = 0;
                                        }
                                        #endregion
                                    }
                                }
                            }
                            break;
                    }
                    Log.WriteByMonthDay("Decode Success " + FileType.ToString() + " [" + s_FrameFile + "].");
                }
                catch (Exception Ex)
                {
                    Log.WriteByMonthDay("DecodeMap " + Ex.Message.ToString());
                    throw new Exception("DecodeMap " + Ex.Message.ToString());
                }

                return true;
            }
        }

        public class TD_COB//TianDian COB DB Map
        {
            //SubstrateID CXM-9-AA30-337N16-1267
            //SerialNo 337N161267-01, 337N161267-02 

            //20200514 New SubstrateID Query failure
            //SubstrateID ZZZL024300-AK2042950-Z029-0286
            //SerialNo ?? Z0290286-01, Z0290286-02

            public static string ConnString = "Data Source = 172.31.3.8; Initial Catalog = APPDB.MDF; User ID = umopto; Password = user1725;";
            public static int MapDB_Query(string SubstrateID, ref int[] Map_IsDimPass, ref int[] Map_IsDispensed)//return data count
            {
                int i_DataCount = 0;
                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection())
                {
                    conn.ConnectionString = ConnString;
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception Ex)
                    {
                        throw new Exception("TD_MapDB_Conn Error. " + Ex.Message.ToString());
                    }
                    System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(
                        "SELECT [SubstrateID], [SerialNo], [IsDimTestPassed], [IsDispensed] " +
                        "FROM dbo.Unit " +
                        "WHERE (SubstrateID = '" + SubstrateID + "') ", conn);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception Ex)
                    {
                        throw new Exception("TD_MapDB_Query Error. " + Ex.Message.ToString());
                    }

                    Map_IsDimPass = new int[1024];
                    Map_IsDispensed = new int[1024];
                    for (int i = 0; i < 1024; i++)
                    {
                        Map_IsDimPass[i] = 0;
                        Map_IsDispensed[i] = 0;
                    }

                    using (System.Data.SqlClient.SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i_DataCount++;
                            //reader[0] Subs ID, reader[1] SerialNo, reader[2] IsDim, reader[3] IsDisp 
                            string sSerialNo = reader[1].ToString();
                            //337N161267-01
                            string sUnitNo = sSerialNo.Remove(0, sSerialNo.IndexOf("-") + 1);
                            //01

                            int iUnitNo = 0;
                            try
                            {
                                iUnitNo = Convert.ToInt32(sUnitNo);
                            }
                            catch (Exception Ex)
                            {
                                Log.AddToLog(reader[0] + "," + reader[1] + "," + reader[2] + "," + reader[3]);
                                throw new Exception("TD_MapDB_Data Error. " + Ex.Message.ToString());
                            }

                            int iUnitIdx = iUnitNo - 1;
                            Map_IsDimPass[iUnitIdx] = Convert.ToInt32(reader[2]);
                            Map_IsDispensed[iUnitIdx] = Convert.ToInt32(reader[3]);
                        }
                    }
                }
                return i_DataCount;
            }
            public static bool MapDB_UpdateSubstrate(string SubstrateID, bool Disp)
            {
                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection())
                {
                    conn.ConnectionString = ConnString;
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception Ex)
                    {
                        throw new Exception("TD_MapDB_Conn Error. " + Ex.Message.ToString());
                    }

                    string sDisp = Disp ? "1" : "0";

                    System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(
                        "UPDATE dbo.Unit " +
                        "SET IsDispensed = '" + sDisp + "' " +
                        "WHERE SubstrateID = '" + SubstrateID + "' AND IsDimTestPassed = '1'", conn);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception Ex)
                    {
                        throw new Exception("TD_MapDB_Update Error. " + Ex.Message.ToString());
                    }
                }
                return true;
            }
            public static bool MapDB_UpdateSerialNo(string SubstrateID, int Index, bool Disp)
            {
                if (SubstrateID.Length <= 0) return false;

                //SubstrateID CXM-9-AA30-337N16-1267
                //SerialNo 337N161267-01, 337N161267-02 

                string sSerialID = SubstrateID;
                //while (sSerialID.IndexOf("-") > 0)
                while (sSerialID.Split('-').Length - 1 > 1)
                {
                    sSerialID = sSerialID.Remove(0, sSerialID.IndexOf("-") + 1);
                }
                sSerialID = sSerialID.Remove(sSerialID.IndexOf("-"), 1);

                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection())
                {
                    conn.ConnectionString = ConnString;
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception Ex)
                    {
                        throw new Exception("TD_MapDB_Conn Error. " + Ex.Message.ToString());
                    }

                    string sDisp = Disp ? "1" : "0";

                    System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(
                        "UPDATE dbo.Unit " +
                        "SET IsDispensed = '" + sDisp + "' " +
                        "WHERE SubstrateID = '" + SubstrateID + "' AND " +
                        "SerialNo = '" + sSerialID + "-" + (Index + 1).ToString("00") + "' AND IsDimTestPassed = '1'", conn);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception Ex)
                    {
                        throw new Exception("TD_MapDB_Update Error. " + Ex.Message.ToString());
                    }
                }
                return true;
            }

            public static bool MapDB_QueryIsOK = false;
        }

        public class OsramEMos
        {
            //public static bool Enabled = true;

            public static NUtils.LogFileW Log = new NUtils.LogFileW(GDefine.DataPath + "\\OsramEMos");

            public static string ProcessName = "NSWA302";
            public static string APAName = "A302";
            public static string MapRequestPath = Directory.CreateDirectory("c:\\OsramEMos\\MapRequestPath\\").FullName;
            public static string ETVUpdatePath = Directory.CreateDirectory("c:\\OsramEMos\\ETVUpdatePath\\").FullName;
            
            public static int TimeOut_s = 15;
            public static bool Rework = false;


            //public static DirectoryInfo LocalPath2 => Directory.CreateDirectory("c:\\OsramEMos\\").FullName;
            //public static DirectoryInfo LocalPath2Unsent => Directory.CreateDirectory(LocalPath2.FullName + "Unsent\\");
            //public static DirectoryInfo LocalPath2Temp => Directory.CreateDirectory(LocalPath2.FullName + "Temp\\");

            //public static string LocalPath = LocalPath2.FullName;//"c:\\OsramEMos\\";
            //public static string LocalPathUnsent = LocalPath2Unsent.FullName;//LocalPath + "Unsent\\";
            //public static string LocalPathTemp = LocalPath2Temp.FullName;//LocalPath + "Temp\\";

            public static string LocalPath => Directory.CreateDirectory("c:\\OsramEMos\\").FullName;
            public static string LocalPathUnsent => Directory.CreateDirectory(LocalPath + "Unsent\\").FullName;// LocalPath2Unsent.FullName;//LocalPath + "Unsent\\";
            public static string LocalPathTemp => Directory.CreateDirectory(LocalPath + "Temp\\").FullName;

            public static void SaveSetup()
            {
                NUtils.IniFile IniFile = new NUtils.IniFile(GDefine.SetupPath + "\\OsramEMos.ini");

                //IniFile.WriteBool("OsramEMos", "Enabled", Enabled);
                IniFile.WriteString("OsramEMos", "ProcessName", ProcessName);
                IniFile.WriteString("OsramEMos", "APAName", APAName);
                IniFile.WriteString("OsramEMos", "MapRequestPath", MapRequestPath);
                IniFile.WriteString("OsramEMos", "ETVUpdatePath", ETVUpdatePath);
                IniFile.WriteInteger("OsramEMos", "TimeOut", TimeOut_s);
            }
            public static void LoadSetup()
            {
                NUtils.IniFile IniFile = new NUtils.IniFile(GDefine.SetupPath + "\\OsramEMos.ini");

                //Enabled = IniFile.ReadBool("OsramEMos", "Enabled", false);
                ProcessName = IniFile.ReadString("OsramEMos", "ProcessName", "NSWA302");
                APAName = IniFile.ReadString("OsramEMos", "APAName", "A302");
                MapRequestPath = IniFile.ReadString("OsramEMos", "MapRequestPath", "c:\\OsramEMos\\MapRequestPath\\");
                ETVUpdatePath = IniFile.ReadString("OsramEMos", "ETVUpdatePath", "c:\\OsramEMos\\ETVUpdatePath\\");
                TimeOut_s = IniFile.ReadInteger("OsramEMos", "TimeOut", 15);
            }

            public static void SendMapRequest(string MapID, string LotID, string OpID, string MatNo, bool Rework)
            {
                //if (!Enabled) return;

                try
                {
                    if (!Directory.Exists(MapRequestPath)) throw new Exception("MapRequestPath not found.");

                    string[] Files = Directory.GetFiles(MapRequestPath, "*.*");
                    //Copy MapFile to local and clear folder
                    foreach (string s in Files)
                    {
                        if (!Path.HasExtension(s))
                        {
                            string DestFile = LocalPathTemp + Path.GetFileName(s);
                            int i = 0;
                            if (File.Exists(DestFile))
                            {
                                i++;
                                while (File.Exists(DestFile + "_" + i.ToString())) i++;
                                File.Move(DestFile, DestFile + "_" + i.ToString());
                            }
                            File.Move(s, DestFile);
                        }
                        else
                            File.Delete(s);
                    }

                    Log.WriteByMonthDay("MapRequest [" + MapID + "].");

                    string FFilename = MapRequestPath + MapID + ".ad";
                    string FMapFilename = MapRequestPath + MapID;

                    //Write AD file
                    NUtils.IniFile Inifile = new NUtils.IniFile(FFilename);
                    Inifile.WriteString("PROZESS", "NAME", ProcessName);//PROZESS spelling is on purpose
                    Inifile.WriteString("PROZESS", "LOT", LotID);
                    Inifile.WriteString("PROZESS", "APA", APAName);
                    Inifile.WriteString("PROZESS", "OPERATOR", OpID);
                    Inifile.WriteString("PROZESS", "MATERIALNUMBER", MatNo);
                    if (Rework) Inifile.WriteString("PROZESS", "SPECIAL", "REWORK");

                    Stopwatch sw = Stopwatch.StartNew();
                    while (true)
                    {
                        if (File.Exists(FMapFilename)) break;
                        Thread.Sleep(5);
                        if (sw.Elapsed.TotalSeconds >= TimeOut_s) break;
                    }

                    if (sw.Elapsed.TotalSeconds >= TimeOut_s)
                    {
                        Log.WriteByMonthDay("MapRequestPath TimeOut.");
                        throw new Exception("MapRequestPath TimeOut.");
                    }
                }
                catch (Exception Ex)
                {
                    Log.WriteByMonthDay("MapRequest " + Ex.Message.ToString());
                    throw new Exception("MapRequest " + Ex.Message.ToString());
                }
            }
            public static void SendMapRequest(string MapID, string LotID, string OpID, string MatNo)
            {
                SendMapRequest(MapID, LotID, OpID, MatNo, Rework);
            }

            public static void GenErrorFile(string MapID)
            {
                try
                {
                    if (!Directory.Exists(MapRequestPath)) Directory.CreateDirectory(MapRequestPath);
                }
                catch { };

                try
                {
                    string FFilename = MapRequestPath + MapID;

                    using (StreamWriter writer = new StreamWriter(FFilename))
                    {
                        writer.WriteLine("ERROR");
                        writer.WriteLine("[PROZESS]");
                        writer.WriteLine("NAME=A302");
                        writer.WriteLine("STATUS=ERROR");
                        writer.WriteLine("ERROR=This error was generated for debugging purpose.");
                    }
                }
                catch (Exception Ex)
                {
                }
            }
            public static void DecodeMap(string MapID, ref int[,] Map, ref Size Size)
            {
                //if (!Enabled) return;

                try
                {
                    if (!Directory.Exists(LocalPathTemp)) Directory.CreateDirectory(LocalPathTemp);
                }
                catch { };

                /*Map format
                ROW 2
                COLS 12
                COMPRE 1
                BEGIN
                111111000010
                111110111111
                */

                Log.WriteByMonthDay("DecodeMap Start [" + MapID + "].");

                string Filename = MapRequestPath + MapID;
                string LocalFilename = LocalPathTemp + MapID;
                if (File.Exists(Filename))
                {
                    int i = 0;
                    if (File.Exists(LocalFilename))
                    {
                        i++;
                        while (File.Exists(LocalFilename + "_" + i.ToString())) i++;
                        File.Move(LocalFilename, LocalFilename + "_" + i.ToString());
                    }
                    Log.WriteByMonthDay("DecodeMap move to local [" + MapID + "].");
                    File.Move(Filename, LocalFilename);
                    Log.WriteByMonthDay("DecodeMap move complete [" + MapID + "].");
                }

                Log.WriteByMonthDay("DecodeMap deleting [" + MapID + "].");
                string[] Files = Directory.GetFiles(MapRequestPath, "*.*");
                foreach (string s in Files)
                {
                    Log.WriteByMonthDay("DecodeMap deleting [" + s + "].");
                    File.Delete(s);
                }

                try
                {
                    List<string[]> lf_data = new List<string[]>();
                    string[] delimiters = new string[] { " " };
                    bool b_StartOfMap = false;
                    int i_MapRow = 0; int i_MapCol = 0;//Map RC
                    int i_Row = 0;
                    using (StreamReader reader = new StreamReader(LocalFilename))
                    {
                        while (true)
                        {
                            string line = reader.ReadLine();
                            if (line == null)
                            {
                                break;
                            }
                            string[] l_Line = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                            if (!b_StartOfMap)
                            {
                                if (l_Line[0].StartsWith("ERROR="))
                                {
                                    string ErrText = line;
                                    throw new Exception(ErrText);
                                }
                                if (l_Line[0].StartsWith("ROW"))
                                {
                                    try { i_MapRow = Convert.ToInt32(l_Line[1]); }
                                    catch (Exception Ex) { throw new Exception("Convert Row Value " + Ex.Message.ToString()); }
                                }
                                if (l_Line[0].StartsWith("COL"))
                                {
                                    try { i_MapCol = Convert.ToInt32(l_Line[1]); }
                                    catch (Exception Ex) { throw new Exception("Convert Col Value " + Ex.Message.ToString()); }

                                    if (Map == null) Map = new int[i_MapCol, i_MapRow];
                                    Size = new Size(i_MapCol, i_MapRow);
                                }
                                if (l_Line[0].StartsWith("BEGIN"))
                                {
                                    b_StartOfMap = true;
                                    continue;
                                }
                            }
                            #region
                            if (b_StartOfMap)//Map Content
                            {
                                string Line = l_Line[0];

                                try
                                {
                                    if (i_Row < i_MapRow)
                                    {

                                        for (int c = 0; c < i_MapCol; c++)
                                        {
                                            Map[i_MapCol - 1 - c, i_Row] = (Line[c].ToString() == "1" ? 1 : 0);
                                            //Map[c, i_Row] = (Line[c].ToString() == "1" ? 1 : 0);
                                        }
                                        i_Row++;
                                    }
                                }
                                catch { throw new Exception("Decode Error."); }
                            }
                            #endregion
                        }
                    }
                    Log.WriteByMonthDay("DecodeMap Success.");
                }
                catch (Exception Ex)
                {
                    Log.WriteByMonthDay("DecodeMap " + Ex.Message.ToString());
                    throw new Exception("DecodeMap " + Ex.Message.ToString());
                }
            }
            static void WriteETVFileToLocal(string MapID, int[,] Map, Size Size)// string MapID, List<bool> DispOK)
            {
                //if (!Enabled) return;

                try
                {
                    if (!Directory.Exists(LocalPathUnsent)) Directory.CreateDirectory(LocalPathUnsent);
                }
                catch { };

                try
                {
                    if (MapID.Length == 0) return;

                    string FFilename = LocalPathUnsent + MapID + ".dc";

                    Log.WriteByMonthDay("WriteETVFileToLocal [" + MapID + "].");

                    using (StreamWriter writer = new StreamWriter(FFilename))
                    {
                        for (int c = 0; c < Size.Width; c++)
                            for (int r = 0; r < Size.Height; r++)
                            {
                                if (Map[Size.Width - 1 - c, r] > 0) writer.WriteLine((c + 1).ToString() + "," + (r + 1).ToString() + ":" + ProcessName + ";" + "0;1");
                                //if (Map[c, r] > 0) writer.WriteLine((c + 1).ToString() + "," + (r + 1).ToString() + ":" + ProcessName + ";" + "0;1");
                            }
                        writer.WriteLine("END OF PROCESS");
                    }
                    Log.WriteByMonthDay("WriteETVFileToLocal Success.");
                }
                catch (Exception Ex)
                {
                    Log.WriteByMonthDay("WriteETVFileToLocal " + Ex.Message.ToString());
                    throw new Exception("WriteETVFileToLocal " + Ex.Message.ToString());
                }
            }
            static bool b_WaitPurge = false;
            public static void PurgeETVFiles()
            {
                if (!Directory.Exists(LocalPathUnsent)) return;

                string[] Files = Directory.GetFiles(LocalPathUnsent, "*.dc");
                if (Files.Count() > 0 && !b_WaitPurge)
                {
                    Log.WriteByMonthDay("ETVFile Pending " + Files.Count().ToString() + " file(s).");
                    b_WaitPurge = true;
                }

                if (!Directory.Exists(ETVUpdatePath)) return;

                try
                {
                    foreach (string s in Files)
                    {
                        string DestFile = ETVUpdatePath + Path.GetFileName(s);
                        if (File.Exists(DestFile))
                        {
                            File.Delete(DestFile);
                            Log.WriteByMonthDay("PurgeETVFile [" + Path.GetFileNameWithoutExtension(s) + "] file exist. Delete file.");
                        }
                        File.Move(s, DestFile);
                        Log.WriteByMonthDay("PurgeETVFile [" + Path.GetFileNameWithoutExtension(s) + "].");

                        b_WaitPurge = false;
                    }
                }
                catch (Exception Ex)
                {
                    Log.WriteByMonthDay("PurgeETVFile " + Ex.Message.ToString());
                    throw new Exception("PurgeETVFile " + Ex.Message.ToString());
                }
            }
            public static void WriteETVFile(string MapID, int[,] Map, Size Size)
            {
                WriteETVFileToLocal(MapID, Map, Size);
                PurgeETVFiles();
            }
        }
    }
}
