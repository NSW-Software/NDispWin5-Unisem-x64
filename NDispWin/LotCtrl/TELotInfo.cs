using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;

namespace NDispWin
{
    class TELotInfo
    {
    }


    class LotInfo2
    {
        public enum ECustomer
        {
            None,
            LUMDisp,
            LUMConfocal,
            OsramDisp,
            OsramConfocal,
            NXPDisp,
            OsramEMos,
            Analog,
        }
        public static ECustomer Customer = ECustomer.None;

        public enum ELotStatus { None, Activated, Deactivated };
        public static ELotStatus LotStatus = ELotStatus.None;
        public static bool LotActive
        {
            get
            {
                return (LotStatus == ELotStatus.Activated);
            }
            set
            {
                LotStatus = value ? ELotStatus.Activated : ELotStatus.Deactivated;
            }
        }

        public enum ELotEvent { None, LotStart, LotEnd, LotRestart }
        public static ELotEvent LotEvent = ELotEvent.None;

        public static bool LoadRecipe = false;
        public static string _SProgramRecipe = "";

        //General Lot Info
        public static string LotNumber = "";

        public static string sOperatorID = "";
        public static string sShift = "";
        public static string sStartTime = "";
        public static string sEndTime = "";
        public static string sMachineID = "";
        public static string sCatridgeAID = "";
        public static string sCatridgeBID = "";
        public static string sCatridgeCID = "";
        public static string sCatridgeDID = "";
        public static int MatLife = 0;

        //Options
        public static int CatridgeCount = 2;
        public static bool ComparePastCATCode = false;
        public static string DefaultMachineID = "";
        public static int ClearMaterialChangeAccessLevel = (int)ELevel.Technician;

        internal class Lmds
        {
            public static string sMesProduct = "";
            public static string sCatCode = "";
            public static string sPriorCatCodes = "";
            public static string sMesLot = "";
            public static string sMesLot_Last = "";
            public static string sSapWo = "";
            public static string sMarketTarget = "";
            public static bool VrfyMktTgt = false;//verify market target

            public class TRecipeTable
            {
                public const int MAX_DATA = 500;
                public int Count = 0;
                public string[] MESProductArr = new string[MAX_DATA];
                public bool[] VrfyMktTgtArr = new bool[MAX_DATA];//4 char -> match 3rd char wiht 3rd char of CATCode
                public string[] CATCodeArr = new string[MAX_DATA];//4 char -> to match with 4 char of CATCode
                public string[] RecipeNameArr = new string[MAX_DATA];
                public int[] MaterialLifeArr = new int[MAX_DATA];

                public TRecipeTable()
                {
                    for (int i = 0; i < MAX_DATA; i++)
                    {
                        MESProductArr[i] = "";
                        VrfyMktTgtArr[i] = false;
                        CATCodeArr[i] = "";
                        RecipeNameArr[i] = "";
                        MaterialLifeArr[i] = 0;
                    }
                }

                public void Update(int Index, string MESProduct, string MarketTarget, string CATCode, string RecipeName, int MaterialLife)
                {
                    this.MESProductArr[Index] = MESProduct;
                    this.VrfyMktTgtArr[Index] = MarketTarget != "0";
                    this.CATCodeArr[Index] = CATCode;
                    this.RecipeNameArr[Index] = RecipeName;
                    this.MaterialLifeArr[Index] = MaterialLife;
                }
                public void Add(string MESProduct, string MarketTarget, string CATCode, string RecipeName, int MaterialLife)
                {
                    Update(Count, MESProduct, MarketTarget, CATCode, RecipeName, MaterialLife);
                    Count++;
                }
                public void Delete(int Index)
                {
                    for (int i = Index; i < Count; i++)
                    {
                        if (i == Count - 1)
                        {
                            MESProductArr[i] = "";
                            VrfyMktTgtArr[i] = false;
                            CATCodeArr[i] = "";
                            RecipeNameArr[i] = "";
                            MaterialLifeArr[i] = 0;
                        }
                        else
                        {
                            MESProductArr[i] = MESProductArr[i + 1];
                            VrfyMktTgtArr[i] = VrfyMktTgtArr[i + 1];
                            CATCodeArr[i] = CATCodeArr[i + 1];
                            RecipeNameArr[i] = RecipeNameArr[i + 1];
                            MaterialLifeArr[i] = MaterialLifeArr[i + 1];
                        }
                    }
                    Count--;
                }
            }
            public static TRecipeTable RecipeTable = new TRecipeTable();

            public static string SetupFile = GDefine.AppPath + @"\\Lmds_LotEntrySetup.csv";
            public static string RecipeTableFile = GDefine.AppPath + @"\\Lmds_RecipeTable.csv";

            public static void SaveSetup()
            {
                string fName = SetupFile;

                if (!Directory.Exists(Path.GetDirectoryName(fName))) Directory.CreateDirectory(Path.GetDirectoryName(fName));

                FileStream F = new FileStream(fName, FileMode.Create, FileAccess.Write, FileShare.Write);
                StreamWriter W = new StreamWriter(F);
                try
                {
                    //  Write common para
                    W.WriteLine("MachineNo" + "," + DefaultMachineID.Trim());
                    W.WriteLine("CatridgeCount" + "," + CatridgeCount);
                    W.WriteLine("CompareCATCode" + "," + ComparePastCATCode);
                    W.WriteLine("ClearMaterialChangeAccessLevel" + "," + ClearMaterialChangeAccessLevel);
                }
                finally
                {
                    W.Close();
                }
            }
            public static void LoadSetup()
            {
                string fName = SetupFile;

                if (!Directory.Exists(Path.GetDirectoryName(fName))) Directory.CreateDirectory(Path.GetDirectoryName(fName));

                if (!File.Exists(fName)) return;

                try
                {
                    FileStream F = new FileStream(fName, FileMode.Open, FileAccess.ReadWrite, FileShare.Write);
                    StreamReader R = new StreamReader(F);

                    string S = R.ReadToEnd();
                    R.Close();

                    string[] Lines = S.Split(new char[] { (char)10 }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string l in Lines)
                    {
                        string[] line = l.Split(',');

                        if (line[0].StartsWith("MachineNo"))
                        {
                            DefaultMachineID = line[1];
                            continue;
                        }
                        if (line[0].StartsWith("CatridgeCount"))
                        {
                            CatridgeCount = Convert.ToInt32(line[1]);
                            continue;
                        }
                        if (line[0].StartsWith("CompareCATCode"))
                        {
                            ComparePastCATCode = Convert.ToBoolean(line[1]);
                            continue;
                        }
                        if (line[0].StartsWith("ClearMaterialChangeAccessLevel"))
                        {
                            ClearMaterialChangeAccessLevel = Convert.ToInt32(line[1]);
                            continue;
                        }
                    }
                }
                catch
                { }
            }

            public static void SaveRecipeTable()
            {
                string fName = RecipeTableFile;

                if (!Directory.Exists(Path.GetDirectoryName(fName))) Directory.CreateDirectory(Path.GetDirectoryName(fName));

                FileStream F = new FileStream(fName, FileMode.Create, FileAccess.Write, FileShare.Write);
                StreamWriter W = new StreamWriter(F);
                try
                {
                    //  Write header
                    W.WriteLine("MES Product" + "," + "Vrfy Mkt Tgt" + "," + "CATCode" + "," + "Recipe Name" + "," + "Material Life" + "," + "CATCode2");

                    for (int i = 0; i < TRecipeTable.MAX_DATA; i++)
                    {
                        if (RecipeTable.MESProductArr[i] == "") break;
                        W.WriteLine(RecipeTable.MESProductArr[i] + "," + (RecipeTable.VrfyMktTgtArr[i] ? "1" : "0") + "," + RecipeTable.CATCodeArr[i] + "," + RecipeTable.RecipeNameArr[i] + "," + RecipeTable.MaterialLifeArr[i]);
                    }
                }
                finally
                {
                    W.Close();
                }
            }
            public static void LoadRecipeTable(string fName)
            {
                RecipeTable = new TRecipeTable();
                if (!Directory.Exists(Path.GetDirectoryName(fName))) Directory.CreateDirectory(Path.GetDirectoryName(fName));

                if (!File.Exists(fName)) return;

                RecipeTable.Count = 0;
                try
                {
                    FileStream F = new FileStream(fName, FileMode.Open, FileAccess.ReadWrite, FileShare.Write);
                    StreamReader R = new StreamReader(F);

                    string S = R.ReadToEnd();
                    R.Close();

                    string[] Lines = S.Split(new char[] { (char)10 }, StringSplitOptions.RemoveEmptyEntries);

                    bool bDataStart = false;
                    int iIndex = 0;
                    foreach (string l in Lines)
                    {
                        string[] line = l.Split(',');

                        if (!bDataStart)
                        {
                            if (line[0].StartsWith("MES Product"))
                            {
                                bDataStart = true;
                                continue;
                            }
                        }
                        else
                        {
                            if (line[0].Length > 0)//contain data
                            {
                                RecipeTable.MESProductArr[iIndex] = line[0];
                                RecipeTable.VrfyMktTgtArr[iIndex] = line[1] != "0";
                                RecipeTable.CATCodeArr[iIndex] = line[2];
                                RecipeTable.RecipeNameArr[iIndex] = line[3];
                                try
                                {
                                    RecipeTable.MaterialLifeArr[iIndex] = Convert.ToInt32(line[4]);
                                }
                                catch { };
                                iIndex++;
                                RecipeTable.Count = iIndex;
                            }
                        }
                    }
                }
                catch
                { }
            }
            public static void LoadRecipeTable()
            {
                LoadRecipeTable(RecipeTableFile);
            }

            public static bool ValidateMESProduct(string MESProduct, string CatridgeAID)
            //  20191123KN check both MESProduct and CatCode
            {
                sCatCode = "";
                _SProgramRecipe = "";
                bool b_MESFound = false;
                for (int i = 0; i < RecipeTable.Count; i++)
                {
                    if (MESProduct == RecipeTable.MESProductArr[i])
                    {
                        if (RecipeTable.CATCodeArr[i] == string.Empty || CatridgeAID.StartsWith(RecipeTable.CATCodeArr[i]))
                        {
                            b_MESFound = true;
                            _SProgramRecipe = RecipeTable.RecipeNameArr[i];
                            MatLife = RecipeTable.MaterialLifeArr[i];
                            sCatCode = RecipeTable.CATCodeArr[i];
                            VrfyMktTgt = RecipeTable.VrfyMktTgtArr[i];
                            break;
                        }
                    }
                }

                if (!b_MESFound)
                {
                    DialogResult dr = MessageBox.Show("MES Product not found in Recipe Table. Continue without auto load Recipe?", "", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.No) return false;
                    return true;
                }

                return true;
            }
            public static bool ValidateCATCode(string CatCode, string CatrigdeID)
            {
                if (CatCode.Length == 0) return true;//  disable CatCode checking
                return CatrigdeID.StartsWith(CatCode);
            }
            public static bool ValidateMarketTarget(string CatCode, string MarketTarget)
            {
                if (CatCode.Length < 4) return false;//  invalid CatCode
                if (MarketTarget.Length < 4) return false;//  invalid MarketTarget

                return (CatCode[2] == MarketTarget[2]);
            }
        }

        internal class Osram
        {
            public static string ElevenSeries = "";//aka Material Nr
            public static string DAStartNumber = "";
        }

        public class Analog
        {
            public static string DeviceName = "";
            public static string LotNo = "";
            public static string BuildSheetNo = "";
            public static string ProcessBarcode = "";
            public static string SubstratePartNo = "";
            public static string MaterialPartNo = "";
            public static string MaterialLotNo = "";
            public static string MaterialExpiryDate = "";
            public static string OperatorID = "";
            public static string Shift = "";
            public static string MachineNo = "";

            public static RecipeItem LoadedRecipeItem = new RecipeItem();

            public static string DefaultMachineNo = "NSW";
            public static bool ManualExpiryEntry = true;
            public static int DefaultMaterialLife = 8;//hrs

            public class RecipeItem
            {
                public string BuildSheetNo = "";
                public string ProcessBarcode = "";
                public string MaterialPartNo = "";

                public string Recipe = "";
                public string HandlerRecipe = "";

                public string Pump = "";
                public string NeedleType = "";
                public string SupportBlock = "";
                public string Prompt1 = "";
                public string Prompt2 = "";
                public string Remark1 = "";
                public string Remark2 = "";

                public RecipeItem(RecipeItem recipeItem)
                {
                    this.BuildSheetNo = recipeItem.BuildSheetNo;
                    this.ProcessBarcode = recipeItem.ProcessBarcode;
                    this.MaterialPartNo = recipeItem.MaterialPartNo;
                    this.Recipe = recipeItem.Recipe;
                    this.HandlerRecipe = recipeItem.HandlerRecipe;
                    this.Pump = recipeItem.Pump;
                    this.NeedleType = recipeItem.NeedleType;
                    this.SupportBlock = recipeItem.SupportBlock;
                    this.Prompt1 = recipeItem.Prompt1;
                    this.Prompt2 = recipeItem.Prompt2;
                    this.Remark1 = recipeItem.Remark1;
                    this.Remark2 = recipeItem.Remark2;
                }

                public RecipeItem()
                {

                }

                public override string ToString()
                {
                    if (BuildSheetNo != "")
                        return BuildSheetNo + ", " + ProcessBarcode + ", " + MaterialPartNo + ", " + Recipe + ", " + HandlerRecipe;
                    else
                        return "(Empty)";
                }
            }

            public static class RecipeTable
            {
                public const int MAX_DATA = 500;
                public static BindingList<RecipeItem> RecipeItem = new BindingList<RecipeItem>(Enumerable.Range(0, MAX_DATA).Select(x => new RecipeItem()).ToList());
                public static int Count = 0;

                public static string SetupFile = GDefine.LotPath + @"\\Analog_LotEntrySetup.csv";
                public static string RecipeTableFile = GDefine.LotPath + @"\\Analog_RecipeTable.csv";

                public static void Delete(int index)
                {
                    if (index < 0) return;

                    for (int i = index; i < MAX_DATA - 1; i++)
                    {
                        RecipeItem[i] = new RecipeItem(RecipeItem[i + 1]);
                    }
                    RecipeItem[MAX_DATA - 1] = new RecipeItem();
                }
                public static void MoveUp(int index)
                {
                    if (index <= 0) return;

                    RecipeItem recipeItem = new RecipeItem(RecipeItem[index - 1]);
                    RecipeItem[index - 1] = new RecipeItem(RecipeItem[index]);
                    RecipeItem[index] = new RecipeItem(recipeItem);
                }
                public static void MoveDn(int index)
                {
                    if (index < 0) return;
                    if (index == MAX_DATA) return;
                    if (RecipeItem[index + 1].BuildSheetNo == "") return;

                    RecipeItem recipeItem = new RecipeItem(RecipeItem[index + 1]);
                    RecipeItem[index + 1] = new RecipeItem(RecipeItem[index]);
                    RecipeItem[index] = new RecipeItem(recipeItem);
                }

                public static void SaveSetup()
                {
                    string fName = SetupFile;

                    if (!Directory.Exists(Path.GetDirectoryName(fName))) Directory.CreateDirectory(Path.GetDirectoryName(fName));

                    FileStream F = new FileStream(fName, FileMode.Create, FileAccess.Write, FileShare.Write);
                    StreamWriter W = new StreamWriter(F);
                    try
                    {
                        //  Write common para
                        W.WriteLine("MachineNo" + "," + DefaultMachineNo.Trim());
                        W.WriteLine("ManualExpiryEntry" + "," + (ManualExpiryEntry ? "1" : "0"));
                        W.WriteLine("MaterialLife" + "," + $"{DefaultMaterialLife}");
                    }
                    finally
                    {
                        W.Close();
                    }
                }
                public static void LoadSetup()
                {
                    string fName = SetupFile;

                    if (!Directory.Exists(Path.GetDirectoryName(fName))) Directory.CreateDirectory(Path.GetDirectoryName(fName));

                    if (!File.Exists(fName)) return;

                    try
                    {
                        FileStream F = new FileStream(fName, FileMode.Open, FileAccess.ReadWrite, FileShare.Write);
                        StreamReader R = new StreamReader(F);

                        string S = R.ReadToEnd();
                        R.Close();

                        string[] Lines = S.Split(new char[] { (char)10 }, StringSplitOptions.RemoveEmptyEntries);

                        ManualExpiryEntry = true;
                        DefaultMaterialLife = 8;
                        foreach (string l in Lines)
                        {
                            string[] line = l.Split(',');

                            if (line[0].StartsWith("MachineNo"))
                            {
                                DefaultMachineNo = line[1];
                                continue;
                            }

                            if (line[0].StartsWith("ManualExpiryEntry"))
                            {
                                ManualExpiryEntry = (line[1].Trim() == "1");
                                continue;
                            }

                            if (line[0].StartsWith("MaterialLife"))
                            {
                                try
                                {
                                    DefaultMaterialLife = Convert.ToInt32(line[1].Trim());
                                }
                                catch { }
                                continue;
                            }
                        }
                    }
                    catch
                    { }
                }

                public static void SaveRecipeTable()
                {
                    string fName = RecipeTableFile;

                    if (!Directory.Exists(Path.GetDirectoryName(fName))) Directory.CreateDirectory(Path.GetDirectoryName(fName));

                    FileStream F = new FileStream(fName, FileMode.Create, FileAccess.Write, FileShare.Write);
                    StreamWriter W = new StreamWriter(F);
                    try
                    {
                        //  Write header
                        W.WriteLine("MES Product" + "," + "Vrfy Mkt Tgt" + "," + "CATCode" + "," + "Recipe Name" + "," + "Material Life" + "," + "CATCode2");

                        W.WriteLine("BuildSheetNo," +
                            "ProcessBarcode," +
                            "MaterialPartNo," +
                            "Recipe," +
                            "HandlerRecipe," +
                            "Pump," +
                            "NeedleType," +
                            "SupportBlock," +
                            "Prompt1," +
                            "Prompt2," +
                            "Remark1," +
                            "Remark2");

                        for (int i = 0; i < MAX_DATA; i++)
                        {
                            if (RecipeItem[i].BuildSheetNo == "") break;
                            W.WriteLine(RecipeItem[i].BuildSheetNo + "," +
                                RecipeItem[i].ProcessBarcode + "," +
                                RecipeItem[i].MaterialPartNo + "," +
                                RecipeItem[i].Recipe + "," +
                                RecipeItem[i].HandlerRecipe + "," +
                                RecipeItem[i].Pump + "," +
                                RecipeItem[i].NeedleType + "," +
                                RecipeItem[i].SupportBlock + "," +
                                RecipeItem[i].Prompt1.Replace("\n", " ").Replace("\r", " ") + "," +
                                RecipeItem[i].Prompt2.Replace("\n", " ").Replace("\r", " ") + "," +
                                RecipeItem[i].Remark1.Replace("\n", " ").Replace("\r", " ") + "," +
                                RecipeItem[i].Remark2.Replace("\n", " ").Replace("\r", " "));
                            Count++;
                        }
                    }
                    finally
                    {
                        W.Close();
                    }
                }
                public static void LoadRecipeTable(string fName)
                {
                    if (!Directory.Exists(Path.GetDirectoryName(fName))) Directory.CreateDirectory(Path.GetDirectoryName(fName));

                    if (!File.Exists(fName)) return;

                    Count = 0;

                    FileStream F = new FileStream(fName, FileMode.Open, FileAccess.ReadWrite, FileShare.Write);
                    StreamReader R = new StreamReader(F);
                    try
                    {

                        string S = R.ReadToEnd();
                        R.Close();

                        string[] Lines = S.Split(new char[] { (char)10 }, StringSplitOptions.RemoveEmptyEntries);

                        bool bDataStart = false;
                        int Count = 0;
                        foreach (string l in Lines)
                        {
                            string[] line = l.Split(',');

                            if (!bDataStart)
                            {
                                if (line[0].StartsWith("BuildSheetNo"))
                                {
                                    bDataStart = true;
                                    continue;
                                }
                            }
                            else
                            {
                                if (line[0].Length > 0)//contain data
                                {
                                    RecipeItem[Count].BuildSheetNo = line[0];
                                    RecipeItem[Count].ProcessBarcode = line[1];
                                    RecipeItem[Count].MaterialPartNo = line[2];
                                    RecipeItem[Count].Recipe = line[3];
                                    RecipeItem[Count].HandlerRecipe = line[4];
                                    RecipeItem[Count].Pump = line[5];
                                    RecipeItem[Count].NeedleType = line[6];
                                    RecipeItem[Count].SupportBlock = line[7];
                                    RecipeItem[Count].Prompt1 = line[8];
                                    RecipeItem[Count].Prompt2 = line[9];
                                    RecipeItem[Count].Remark1 = line[10];
                                    RecipeItem[Count].Remark2 = line[11];
                                    Count++;
                                }
                            }
                        }
                    }
                    catch
                    { }
                    finally
                    {
                        R.Close();
                    }
                }
                public static void LoadRecipeTable()
                {
                    LoadRecipeTable(RecipeTableFile);
                }

                public static bool LookupRecipe(string buildSheetNo, string processBarcode, string materialPartNo)
                {
                    foreach (RecipeItem rItem in RecipeItem)
                    {
                        if (rItem.BuildSheetNo == "") return false;

                        if (rItem.BuildSheetNo == buildSheetNo && rItem.ProcessBarcode == processBarcode && rItem.MaterialPartNo == materialPartNo)
                        {
                            LoadedRecipeItem = new RecipeItem(rItem);
                            return true;
                        }
                    }
                    return false;
                }
            }

            public static void LogStart()
            {

                string S = $"{DeviceName.Trim()},{LotNo.Trim()},{BuildSheetNo.Trim()},{ProcessBarcode.Trim()},{SubstratePartNo.Trim()}," +
                    $"{MaterialPartNo.Trim()},{MaterialLotNo.Trim()},{MaterialExpiryDate.Trim()},{OperatorID.Trim()},{Shift.Trim()},{MachineNo.Trim()}," +
                    $"{LoadedRecipeItem.Recipe.Trim()},{LoadedRecipeItem.HandlerRecipe.Trim()},{LoadedRecipeItem.Pump.Trim()}," +
                    $"{LoadedRecipeItem.NeedleType.Trim()},{LoadedRecipeItem.SupportBlock.Trim()},{LoadedRecipeItem.Prompt1.Trim()}," +
                    $"{LoadedRecipeItem.Prompt2.Trim()},{LoadedRecipeItem.Remark1.Trim()}," +
                    $"{LoadedRecipeItem.Remark2.Trim()}";

                Log.LotEntry.WriteByMonthDay("Start Lot, " + S);
            }
            public static void LogEnd()
            {
                string S = $"{DeviceName},{LotNo},{BuildSheetNo},{ProcessBarcode},{SubstratePartNo}";
                Log.LotEntry.WriteByMonthDay("End Lot, " + S);
            }
        }

        //public static void WriteRegStat()
        //{
        //    NSW.Net.RegistryUtils Reg = new NSW.Net.RegistryUtils();

        //    Reg.WriteKey("NSWAUTOMATION_LotInfo", "Lot Status", LotStatus.ToString());

        //    Reg.WriteKey("NSWAUTOMATION_LotInfo", "Lot Number", LotNumber);

        //    Reg.WriteKey("NSWAUTOMATION_LotInfo", "Operator ID", sOperatorID);
        //    Reg.WriteKey("NSWAUTOMATION_LotInfo", "Shift", sShift);
        //    Reg.WriteKey("NSWAUTOMATION_LotInfo", "Start Time", sStartTime);
        //    Reg.WriteKey("NSWAUTOMATION_LotInfo", "End Time", sEndTime);
        //    Reg.WriteKey("NSWAUTOMATION_LotInfo", "Machine ID", sMachineID);
        //    Reg.WriteKey("NSWAUTOMATION_LotInfo", "CatridgeAID", sCatridgeAID);
        //    Reg.WriteKey("NSWAUTOMATION_LotInfo", "CatridgeBID", sCatridgeBID);
        //    Reg.WriteKey("NSWAUTOMATION_LotInfo", "CatridgeCID", sCatridgeCID);
        //    Reg.WriteKey("NSWAUTOMATION_LotInfo", "CatridgeDID", sCatridgeDID);

        //    switch (Customer)
        //    {
        //        case ECustomer.LUMDisp:
        //        case ECustomer.LUMConfocal:
        //            Reg.WriteKey("NSWAUTOMATION_LotInfo", "MES Product", Lmds.sMesProduct);
        //            Reg.WriteKey("NSWAUTOMATION_LotInfo", "CAT Code", Lmds.sCatCode);
        //            Reg.WriteKey("NSWAUTOMATION_LotInfo", "MES Lot", Lmds.sMesLot);
        //            Reg.WriteKey("NSWAUTOMATION_LotInfo", "MES Lot" + "_Last", Lmds.sMesLot_Last);
        //            Reg.WriteKey("NSWAUTOMATION_LotInfo", "SAP WO", Lmds.sSapWo);
        //            Reg.WriteKey("NSWAUTOMATION_LotInfo", "Market Target", Lmds.sMarketTarget);
        //            break;
        //        case ECustomer.OsramEMos:
        //            Reg.WriteKey("NSWAUTOMATION_LotInfo", "11Series", Osram.ElevenSeries);
        //            Reg.WriteKey("NSWAUTOMATION_LotInfo", "DA Start Number", Osram.DAStartNumber);
        //            break;
        //    }
        //}
    }
}
