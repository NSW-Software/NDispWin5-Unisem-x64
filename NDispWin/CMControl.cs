using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using Advantech.Motion;

namespace NDispWin
{
    public class CControl2
    {
        /// <summary>
        /// 
        /// </summary>
        public enum EDeviceType { NONE, P1240, PISO, ZKAZM304, ZKAZM302, ZKAZIO3001, P1245, P1265, P1285, ZKAPCIe1245, SE_MCode };

        private static bool[] DevDependChecked = new bool[9] { false, false, false, false, false, false, false, false, false };

        /// <summary>
        /// Device Structure
        /// </summary>
        public struct TDevice
        {
            public EDeviceType Type;//All
            public string IPAddress;//for CAN, ZKA, RS232 ComportNo
            public byte ID;//board ID
            public string Label;
            public string Name;
            public bool Enabled;

            public TDevice(EDeviceType Type, string IPAddress, byte ID, string Label, string Name)
            {
                this.Type = Type;
                this.IPAddress = IPAddress;
                this.ID = ID;
                this.Name = Name;
                this.Label = Label;
                this.Enabled = true;
            }
            public TDevice(EDeviceType Type, byte ID, string Label, string Name)
            {
                this.Type = Type;
                this.IPAddress = "192.168.1.100";
                this.ID = ID;
                this.Name = Name;
                this.Label = Label;
                this.Enabled = true;
            }

            struct FileVer
            {
                public string FileName;
                public int Major;
                public int Minor;
                public int Build;
                public int Private;
                public FileVer(string FileName, int Major, int Minor, int Build, int Private)
                {
                    this.FileName = FileName;
                    this.Major = Major;
                    this.Minor = Minor;
                    this.Build = Build;
                    this.Private = Private;
                }
                public string FileVersion
                {
                    get { return Major.ToString() + "." + Minor.ToString() + "." + Build.ToString() + "." + Private.ToString(); }
                }
                public bool Validate(bool ShowMessage)
                {
                    if (!File.Exists(FileName))
                    {
                        if (ShowMessage)
                        {
                            MessageBox.Show(FileName + " not found.");
                        }
                        return false;
                    }
                    FileVersionInfo fvi_FoundVersion = FileVersionInfo.GetVersionInfo(FileName);
                    string FoundVersion = fvi_FoundVersion.FileVersion;

                    if (fvi_FoundVersion.FileMajorPart > this.Major)
                    {
                        return true;
                    }
                    else
                        if (fvi_FoundVersion.FileMinorPart > this.Minor)
                    {
                        return true;
                    }
                    else
                            if (fvi_FoundVersion.FileBuildPart > this.Build)
                    {
                        return true;
                    }
                    else
                                if (fvi_FoundVersion.FilePrivatePart >= this.Private)
                    {
                        return true;
                    }
                    if (ShowMessage)
                    {
                        MessageBox.Show(FileName + (char)13 + "Build ver " + FileVersion + ", Current ver " + FoundVersion, "File Version Mismatch");
                    }
                    return true;
                }
            }
            public bool CheckDependencies()
            {
                bool OK = true;

                switch (Type)
                {
                    case EDeviceType.P1240:
                        #region
                        {
                            if (!DevDependChecked[(int)Type])
                            {
                                string ads1240dll = "C:\\WINDOWS\\system32\\ads1240.dll";
                                if (!File.Exists(ads1240dll))
                                {
                                    OK = false;
                                    MessageBox.Show(ads1240dll + " not found.");
                                }
                            }
                        }
                        break;
                    #endregion
                    case EDeviceType.PISO:
                        #region
                        {
                            string PISODIOdll = "C:\\WINDOWS\\system32\\pisodio.dll";
                            if (!File.Exists(PISODIOdll))
                            {
                                OK = false;
                                MessageBox.Show(PISODIOdll + " not found.");
                            };
                        }
                        break;
                    #endregion
                    case EDeviceType.P1245:
                    case EDeviceType.P1265:
                        #region
                        {
                            if (!DevDependChecked[(int)Type])
                            {
                                FileVer file_P1265KernelDriver = new FileVer(@"c:\windows\system32\drivers\PCI1265s.sys", 2, 1, 4, 1);
                                if (OK) OK = file_P1265KernelDriver.Validate(true);

                                FileVer file_P1265UserDriver = new FileVer(@"c:\windows\system32\PCI1265.dll", 2, 1, 7, 1);
                                if (OK) OK = file_P1265UserDriver.Validate(true);

                                FileVer file_CommonMotionLibrary = new FileVer(@"c:\windows\system32\ADVMOT.dll", 1, 2, 3, 1);
                                if (OK) OK = file_CommonMotionLibrary.Validate(true);

                                FileVer file_DotNETLibrary = new FileVer(Path.GetDirectoryName(Application.ExecutablePath) + @"\AdvMotAPI.dll", 1, 1, 7, 1);
                                if (OK) OK = file_DotNETLibrary.Validate(true);

                                DevDependChecked[(int)Type] = true;
                            }
                            break;
                        }
                    #endregion
                    case EDeviceType.P1285:
                        #region
                        {
                            if (!DevDependChecked[(int)Type])
                            {
                                FileVer file_P1265KernelDriver = new FileVer(@"c:\windows\system32\drivers\PCI1285s.sys", 1, 2, 2, 1);
                                if (OK) OK = file_P1265KernelDriver.Validate(true);

                                FileVer file_P1265UserDriver = new FileVer(@"c:\windows\system32\PCI1285.dll", 1, 2, 2, 1);
                                if (OK) OK = file_P1265UserDriver.Validate(true);

                                FileVer file_CommonMotionLibrary = new FileVer(@"c:\windows\system32\ADVMOT.dll", 1, 4, 1, 1);
                                if (OK) OK = file_CommonMotionLibrary.Validate(true);

                                FileVer file_DotNETLibrary = new FileVer(Application.ExecutablePath + @"\AdvMotAPI.dll", 1, 2, 1, 1);
                                if (OK) OK = file_DotNETLibrary.Validate(true);

                                DevDependChecked[(int)Type] = true;
                            }
                            break;
                        }
                    #endregion
                    case EDeviceType.ZKAPCIe1245:
                        #region
                        {
                            if (!DevDependChecked[(int)Type])
                            {
                                //FileVer file_P1265KernelDriver = new FileVer(@"c:\windows\system32\drivers\PCI1285s.sys", 1, 2, 2, 1);
                                //if (OK) OK = file_P1265KernelDriver.Validate(true);

                                //FileVer file_P1265UserDriver = new FileVer(@"c:\windows\system32\PCI1285.dll", 1, 2, 2, 1);
                                //if (OK) OK = file_P1265UserDriver.Validate(true);

                                //FileVer file_CommonMotionLibrary = new FileVer(@"c:\windows\system32\ADVMOT.dll", 1, 4, 1, 1);
                                //if (OK) OK = file_CommonMotionLibrary.Validate(true);

                                FileVer file_Win32Library = new FileVer(Application.ExecutablePath + @"\PCIe1245.dll", 1, 0, 0, 0);
                                if (OK) OK = file_Win32Library.Validate(true);

                                DevDependChecked[(int)Type] = true;
                            }
                            break;
                        }
                        #endregion
                }
                return OK;
            }


        }
        /// <summary>
        /// Type of TAxis
        /// </summary>
        public struct TAxis
        {
            public TDevice Device;
            public byte Mask;
            public string Label;
            public string Name;
            public TAxisPara Para;
            public bool Enabled;

            /// <summary>
            /// TAxis Structure by Device, Mask, Label, Name
            /// P1240 Axis = 0x01, 0x02, 0x04, 0x08
            /// P1245 Axis = 0 ~ 3
            /// P1265 Axis = 0 ~ 5
            /// ZKAZM30x Axis = 1 ~ 4,
            /// ZKAPCIe1245 Axis = 0 ~ 3
            /// SE_MCode Axis = 0 ~ 9
            /// </summary>
            /// <param name="Device"></param>
            /// <param name="Mask"></param>
            /// <param name="Label"></param>
            /// <param name="Name"></param>
            public TAxis(TDevice Device, byte Mask, string Label, string Name)
            {
                this.Device = Device;
                this.Mask = Mask;
                this.Label = Label;
                this.Name = Name;
                this.Para = new TAxisPara();
                this.Para.DeviceName = Device.Name;
                this.Para.AxisName = Name;
                this.Enabled = true;
            }
            /// <summary>
            /// TAxis Structure by Device, Mask
            /// P1240 Axis = 0x01, 0x02, 0x04, 0x08
            /// P1245 Axis = 0 ~ 3
            /// P1265 Axis = 0 ~ 5
            /// ZKAZM30x Axis = 1 ~ 4,
            /// ZKAPCIe1245 Axis = 0 ~ 3
            /// SE_MCode Axis = 0 ~ 9
            /// </summary>
            /// <param name="Device"></param>
            /// <param name="Mask"></param>
            /// <param name="Label"></param>
            /// <param name="Name"></param>
            public TAxis(TDevice Device, byte Mask)
            {
                this.Device = Device;
                this.Mask = Mask;
                this.Label = "";
                this.Name = "";
                this.Para = new TAxisPara();
                this.Enabled = true;
            }


        }

        /// <summary>
        /// Type of TInput
        /// </summary>
        public struct TInput
        {
            public TDevice Device;
            public byte Axis_Port;
            public ushort Mask;
            //public ushort Match;
            public string Label;
            public string Name;
            public bool Status;
            public bool Enabled;

            /// <summary>
            /// TInput Structure by Device, Axis_Port, Mask, Label, Name
            /// P1240 Axis = 0x01, 0x02, 0x04, 0x08, Mask 0x[nil, nil, nEmg, nAlarm][nHLmtN, nHLmtP, nSLmtN, nSLmtP][nAlm, nInp, nEXN, nEXP][nIn3~nIn0]
            /// P1245 Axis = 0~3, Mask 0x[nil, nil, nEmg, nil][nHLmtN, nHLmtP, nSLmtN, nSLmtP][nAlm, nInp, nEXN, nEXP][nIn3~nIn0]
            /// P1265 Axis = 0~5, Mask 0x[nil, nil, nEmg, nil][nHLmtN, nHLmtP, nSLmtN, nSLmtP][nAlm, nInp, nEXN, nEXP][nIn3~nIn0]; Port = 6, Mask 0x[DI7~4][DI3~0]
            /// P1285 Axis = 0~7, Mask 0x[nil, nil, nEmg, nil][nHLmtN, nHLmtP, nSLmtN, nSLmtP][nAlm, nInp, nEXN, nEXP][nIn3~nIn0]
            /// PISO Port = 0~3, Mask = 0x[DI7~4][DI3~0]
            /// ZKAZM30x Axis = 1 ~ 4, Mask = MotorIn 0x16, 0x0[In4 ~ In1]
            /// ZKAZM30x Port = 0, Mask = 0 ~ 6
            /// ZKAZI3001 Port = 0, Mask = 0 ~ 31
            /// ZKAPCIe1245 Axis = 0 ~ 3
            /// SE_MCode Axis = 0 ~ 9, Mask = 0x[nil, nil, nil, nil][In12~In9][nil, nil, nil, nil][In4~In1]
            /// </summary>
            /// <param name="Device"></param>
            /// <param name="Axis_Port"></param>
            /// <param name="Mask"></param>
            /// <param name="Label"></param>
            /// <param name="Name"></param>
            public TInput(TDevice Device, byte Axis_Port, ushort Mask, string Label, string Name)
            {
                this.Device = Device;
                this.Axis_Port = Axis_Port;
                this.Mask = Mask;
                //if ((Device.Type == EDeviceType.P1240) && (Mask <= 8))
                //    this.Match = 0x0000;
                //else
                //    this.Match = Mask;
                this.Label = Label;
                this.Name = Name;
                this.Status = false;
                this.Enabled = true;
            }
            /// <summary>
            /// TInput Structure by Device, Axis_Port, Mask
            /// P1240 Axis = 0x01, 0x02, 0x04, 0x08, Mask 0x[nil, nil, nEmg, nAlm][nHLmtN, nHLmtP, nSLmtN, nSLmtP][nAlm, nInp, nEXN, nEXP][nIn3~nIn0]
            /// P1245 Axis = 0~3, Mask 0x[nil, nil, nEmg, nil][nHLmtN, nHLmtP, nSLmtN, nSLmtP][nAlm, nInp, nEXN, nEXP][nIn3~nIn0]
            /// P1265 Axis = 0~5, Mask 0x[nil, nil, nEmg, nil][nHLmtN, nHLmtP, nSLmtN, nSLmtP][nAlm, nInp, nEXN, nEXP][nIn3~nIn0]; Port = 6, Mask 0x[DI7~4][DI3~0]
            /// P1285 Axis = 0~7, Mask 0x[nil, nil, nEmg, nil][nHLmtN, nHLmtP, nSLmtN, nSLmtP][nAlm, nInp, nEXN, nEXP][nIn3~nIn0]
            /// PISO Port = 0~3, Mask 0x[DI7~4][DI3~0]
            /// ZKAZM30x Axis = 1 ~ 4, Mask = MotorIn 0x16, 0x0[In4 ~ In1]
            /// ZKAZM30x Port = 0, Mask = 0 ~ 6
            /// ZKAZI3001 Port = 0, Mask = 0 ~ 31
            /// ZKAPCIe1245 Axis = 0 ~ 3
            /// SE_MCode Axis = 0 ~ 9, Mask = 0x[nil, nil, nil, nil][In12~In9][nil, nil, nil, nil][In4~In1]
            /// </summary>
            /// <param name="Device"></param>
            /// <param name="Axis_Port"></param>
            /// <param name="Mask"></param>
            public TInput(TDevice Device, byte Axis_Port, ushort Mask)
            {
                this.Device = Device;
                this.Axis_Port = Axis_Port;
                this.Mask = Mask;
                //if ((Device.Type == EDeviceType.P1240) && (Mask <= 8))
                //    this.Match = 0x0000;
                //else
                //    this.Match = Mask;
                this.Label = "";
                this.Name = "";
                this.Status = false;
                this.Enabled = true;
            }
        }
        /// <summary>
        /// Type of TOutput
        /// </summary>
        public struct TOutput
        {
            public TDevice Device;
            public byte Axis_Port;
            public UInt32 Mask;
            public string Label;
            public string Name;
            public bool Status;
            public bool Enabled;

            /// <summary>
            /// TOuput Structure by Device, Axis_Port, Mask, Label, Name
            /// P1240 Axis = 0x01, 0x02, 0x04, 0x08, , Mask 0x0[nOut7~nOut4]
            /// P1245 Axis = 0~3, Mask 0x0[nOut7~nOut4]
            /// P1265 Axis = 0~5, Mask 0x0[nOut7~nOut4]; Port=6, Mask 0x[DO7~DO4][DO3~DO0]
            /// P1285 Axis = 0~7, Mask 0x0[nOut7~nOut4]
            /// PISO Port = 0~3, Mask 0x[DO7~DO4][DO3~DO0]
            /// ZKAZM30x Port = 0, Mask = 0x01 ~ 0x80
            /// ZKAZI3001 Port = 0, Mask = 0x01 ~ 0x0400
            /// ZKAPCIe1245 Axis = 0 ~ 3
            /// SE_MCode = n/a
            /// </summary>
            /// <param name="Device"></param>
            /// <param name="Axis_Port"></param>
            /// <param name="Mask"></param>
            /// <param name="Label"></param>
            /// <param name="Name"></param>
            public TOutput(TDevice Device, byte Axis_Port, UInt32 Mask, string Label, string Name)
            {
                this.Device = Device;
                this.Axis_Port = Axis_Port;
                this.Mask = Mask;
                this.Label = Label;
                this.Name = Name;
                this.Status = false;
                this.Enabled = true;
            }
            /// <summary>
            /// TOuput Structure by Device, Axis_Port, Mask
            /// P1240 Axis = 0x01, 0x02, 0x04, 0x08, , Mask 0x0[nOut7~nOut4]
            /// P1245 Axis = 0~3; Mask 0x0[nOut7~nOut4]
            /// P1265 Axis = 0~5, Mask 0x0[nOut7~nOut4]; Port=6, Mask 0x[DO7~DO4][DO3~DO0]
            /// P1285 Axis = 0~5, Mask 0x0[nOut7~nOut4]
            /// PISO Port = 0 ~ 3, Mask = 0x01 ~ 0x80
            /// ZKAZM30x Port = 0, Mask = 0x01 ~ 0x80
            /// ZKAZI3001 Port = 0, Mask = 0x01 ~ 0x0400
            /// ZKAPCIe1245 Axis = 0 ~ 3
            /// SE_MCode = n/a
            /// </summary>
            /// <param name="Device"></param>
            /// <param name="Axis_Port"></param>
            /// <param name="Mask"></param>
            public TOutput(TDevice Device, byte Axis_Port, UInt32 Mask)
            {
                this.Device = Device;
                this.Axis_Port = Axis_Port;
                this.Mask = Mask;
                this.Label = "";
                this.Name = "";
                this.Status = false;
                this.Enabled = true;
            }
        }
        public enum EOutputStatus { Lo, Hi, St };

        public struct TAxisUnit
        {
            public string Name;
            public double Resolution;
        }
        public enum EHomeDir { N, P };
        public struct TAxisHomePara
        {
            public double SlowV, FastV;
            public int Timeout;
            public EHomeDir Dir;
        }
        public struct TAxisJogPara
        {
            public double SlowV, MedV, FastV;
            public double Sel;
        }
        public enum EAxisSwLimitType { Disable, Logical, Real };
        public struct TAxisSwLimit
        {
            public EAxisSwLimitType LimitType;
            public double PosN, PosP;
        }
        public struct TAxisHwLimit
        {
            public bool Invert;
        }
        public struct TAxisPsnt
        {
            public double StartV;
            public double DriveV;
            public double Accel;
            public double Decel;
        }
        public enum EMotorAlarmType { None, NC, NO };
        public class TAxisPara
        {
            public string DeviceName;
            public string AxisName;
            public bool InvertMtrOn;

            //public bool HwInvert;//use hardware to invert output pulse
            public bool InvertPulse;

            public TAxisUnit Unit;
            public uint Multiplier;
            public double Accel, StartV, SlowV, MedV, FastV;
            public TAxisPsnt Psnt;
            public TAxisHomePara Home;
            public TAxisJogPara Jog;
            public TAxisSwLimit SwLimit;
            public TAxisHwLimit HwLimit;
            public EMotorAlarmType MotorAlarmType;
            public EHomeMode HomeMode;

            public TAxisPara()
            {
                DeviceName = "Device";
                AxisName = "Axis";
                InvertMtrOn = false;
                InvertPulse = false;
                Unit = new TAxisUnit { Name = "mm", Resolution = (float)0.001 };
                Multiplier = 1;
                Accel = 1;
                StartV = 1;
                SlowV = 1;
                MedV = 1;
                FastV = 1;
                Psnt = new TAxisPsnt { StartV = 1, DriveV = 1, Accel = 1 };
                Home = new TAxisHomePara { SlowV = 1, FastV = 1, Timeout = 10 };
                Jog = new TAxisJogPara { SlowV = 1, MedV = 1, FastV = 1 };
                SwLimit = new TAxisSwLimit { LimitType = EAxisSwLimitType.Disable, PosN = 0, PosP = 0 };
                HwLimit = new TAxisHwLimit { Invert = false };
                MotorAlarmType = EMotorAlarmType.NO;
                HomeMode = EHomeMode.MODE8_LmtSearch;
        }

        public bool ReadInifile(string FileName, string SectionName)
            {
                NUtils.IniFile Inifile = new NUtils.IniFile(FileName);

                try
                {
                    InvertMtrOn = Inifile.ReadBool(SectionName, "InvertMtrOn", false);
                    InvertPulse = Inifile.ReadBool(SectionName, "InvertPulse", false);
                    Unit.Name = Inifile.ReadString(SectionName, "UnitName", "mm");
                    Unit.Resolution = Inifile.ReadDouble(SectionName, "UnitResolution", 0.001);
                    Multiplier = (uint)Inifile.ReadInteger(SectionName, "Multiplier", 1);
                    Accel = Inifile.ReadDouble(SectionName, "Accel", 1);
                    StartV = Inifile.ReadDouble(SectionName, "StartV", 1);
                    SlowV = Inifile.ReadDouble(SectionName, "SlowV", 1);
                    MedV = Inifile.ReadDouble(SectionName, "MedV", 1);
                    FastV = Inifile.ReadDouble(SectionName, "FastV", 1);
                    Home.SlowV = Inifile.ReadDouble(SectionName, "HomeSlowV", 1);
                    Home.FastV = Inifile.ReadDouble(SectionName, "HomeFastV", 1);
                    Home.Timeout = Inifile.ReadInteger(SectionName, "HomeTimeout", 10);
                    Home.Dir = (EHomeDir)Inifile.ReadInteger(SectionName, "HomeDir", 0);
                    Jog.SlowV = Inifile.ReadDouble(SectionName, "JogSlowV", 1);
                    Jog.MedV = Inifile.ReadDouble(SectionName, "JogMedV", 1);
                    Jog.FastV = Inifile.ReadDouble(SectionName, "JogFastV", 1);
                    SwLimit.LimitType = (EAxisSwLimitType)Inifile.ReadInteger(SectionName, "SwLimitType", 0);
                    SwLimit.PosN = Inifile.ReadDouble(SectionName, "SwLimitPosN", 1);
                    SwLimit.PosP = Inifile.ReadDouble(SectionName, "SwLimitPosP", 1);
                    HwLimit.Invert = Inifile.ReadBool(SectionName, "HwLimitInvert", false);
                    MotorAlarmType = (EMotorAlarmType)Inifile.ReadInteger(SectionName, "MotorAlarmType", (int)EMotorAlarmType.NO);
                    if (AxisName == "GX" || AxisName == "GY")
                        HomeMode = (EHomeMode)Inifile.ReadInteger(SectionName, "HomeMode", (int)EHomeMode.MODE8_LmtSearch);
                    else
                        HomeMode = (EHomeMode)Inifile.ReadInteger(SectionName, "HomeMode", (int)EHomeMode.MODE7_AbsSearch);
                }
                catch { throw; };

                return true;
            }
            public bool WriteInifile(string FileName, string SectionName)
            {
                NUtils.IniFile Inifile = new NUtils.IniFile(FileName);

                try
                {
                    Inifile.WriteString(SectionName, "AxisName", AxisName);
                    Inifile.WriteBool(SectionName, "InvertMtrOn", InvertMtrOn);
                    Inifile.WriteBool(SectionName, "InvertPulse", InvertPulse);
                    Inifile.WriteString(SectionName, "UnitName", Unit.Name);
                    Inifile.WriteDouble(SectionName, "UnitResolution", Unit.Resolution);
                    Inifile.WriteInteger(SectionName, "Multiplier", (int)Multiplier);
                    Inifile.WriteDouble(SectionName, "Accel", Accel);
                    Inifile.WriteDouble(SectionName, "StartV", StartV);
                    Inifile.WriteDouble(SectionName, "SlowV", SlowV);
                    Inifile.WriteDouble(SectionName, "MedV", MedV);
                    Inifile.WriteDouble(SectionName, "FastV", FastV);
                    Inifile.WriteDouble(SectionName, "HomeSlowV", Home.SlowV);
                    Inifile.WriteDouble(SectionName, "HomeFastV", Home.FastV);
                    Inifile.WriteInteger(SectionName, "HomeTimeout", (int)Home.Timeout);
                    Inifile.WriteInteger(SectionName, "HomeDir", (int)Home.Dir);
                    Inifile.WriteDouble(SectionName, "JogSlowV", Jog.SlowV);
                    Inifile.WriteDouble(SectionName, "JogMedV", Jog.MedV);
                    Inifile.WriteDouble(SectionName, "JogFastV", Jog.FastV);
                    Inifile.WriteInteger(SectionName, "SwLimitType", (int)SwLimit.LimitType);
                    Inifile.WriteDouble(SectionName, "SwLimitPosN", SwLimit.PosN);
                    Inifile.WriteDouble(SectionName, "SwLimitPosP", SwLimit.PosP);
                    Inifile.WriteBool(SectionName, "HwLimitInvert", HwLimit.Invert);
                    Inifile.WriteInteger(SectionName, "MotorAlarmType", (int)MotorAlarmType);
                    Inifile.WriteInteger(SectionName, "HomeMode", (int)HomeMode);
                }
                catch { throw; }

                return true;
            }
            public bool LoadLocal()
            {
                string path = Path.GetDirectoryName(Application.ExecutablePath);
                string file = Path.GetFileNameWithoutExtension(Assembly.GetAssembly(typeof(CControl2)).CodeBase);

                return ReadInifile(path + "\\" + file + ".ini", DeviceName + "_" + AxisName);
            }
            public bool SaveLocal()
            {
                string path = Path.GetDirectoryName(Application.ExecutablePath);
                string file = Path.GetFileNameWithoutExtension(
                                     Assembly.GetAssembly(typeof(CControl2)).CodeBase);

                return WriteInifile(path + "\\" + file + ".ini", DeviceName + "_" + AxisName);
            }

            //public bool InvertPulse
            //{
            //    //get { return HwInvert ? false : invertPulse; }
            //    get { return invertPulse; }
            //    set { this.invertPulse = value; }
            //}
        }

        public bool Offline = false;

        bool[] Opened = new bool[4];

        const int MAX_DEVICE = 4;
        const int MAX_AXIS = 8;

        uint DevCount = 0;
        DEV_LIST[] AvailDevs = new DEV_LIST[Motion.MAX_DEVICES];
        IntPtr[] p_DeviceHandle = new IntPtr[MAX_DEVICE] { IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero };
        IntPtr[,] p_AxisHandle = new IntPtr[MAX_DEVICE, MAX_AXIS];
        IntPtr[,] p_GroupHandle = new IntPtr[MAX_DEVICE, 4];

        uint[] AxesPerDev = new uint[MAX_DEVICE];

        double[,] UPP = new double[MAX_DEVICE, MAX_AXIS];

        double[,] StartV = new double[MAX_DEVICE, MAX_AXIS];
        double[,] DriveV = new double[MAX_DEVICE, MAX_AXIS];
        double[,] Accel = new double[MAX_DEVICE, MAX_AXIS];
        double[,] Decel = new double[MAX_DEVICE, MAX_AXIS];
        double[,] Jerk = new double[MAX_DEVICE, MAX_AXIS];

        public CControl2()
        {
            for (int i = 0; i < MAX_DEVICE; i++)
                for (int j = 0; j < MAX_AXIS; j++)
                {
                    UPP[i, j] = 1;
                    StartV[i, j] = 0;
                    DriveV[i, j] = 0;
                    Accel[i, j] = 0;
                    Decel[i, j] = 0;
                }
        }

        #region Common
        public string GetErrorMessage1(uint ErrCode)
        {
            StringBuilder ErrMsg = new StringBuilder(100);

            try
            {
                Motion.mAcm_GetErrorMessage((uint)ErrCode, ErrMsg, 100);
            }
            catch { throw; }

            return "0x" + ErrCode.ToString("X") + " " + ErrMsg.ToString();
        }
        public void DeviceAvailable(ref uint DeviceCount)
        {
            if (Offline) return;

            DeviceCount = 0;
            int Res;
            Res = Motion.mAcm_GetAvailableDevs(AvailDevs, Motion.MAX_DEVICES, ref DeviceCount);
            if (Res != (int)ErrorCode.SUCCESS)
            {
                throw new Exception(GetErrorMessage1((uint)Res));
            }
        }
        #endregion

        #region Device
        public bool OpenDevice(byte DeviceNo)
        {
            if (Offline) return true;

            try
            {
                DeviceAvailable(ref DevCount);

                uint Res = Motion.mAcm_DevOpen(AvailDevs[DeviceNo].DeviceNum, ref p_DeviceHandle[DeviceNo]);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }

                uint buffLen = 4;
                Res = Motion.mAcm_GetProperty(p_DeviceHandle[DeviceNo], (uint)PropertyID.FT_DevAxesCount, ref AxesPerDev[DeviceNo], ref buffLen);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }

                for (ushort i = 0; i < AxesPerDev[DeviceNo]; i++)
                {
                    Res = Motion.mAcm_AxOpen(p_DeviceHandle[DeviceNo], i, ref p_AxisHandle[DeviceNo, i]);
                    if (Res != (int)ErrorCode.SUCCESS)
                    {
                        throw new Exception(GetErrorMessage1(Res));
                    }
                }

                Reset(DeviceNo);

                Opened[DeviceNo] = true;
                return true;
            }
            catch { throw; }
        }

        public void CloseDevice(byte DeviceNo)
        {
            if (Offline) return;

            Reset(DeviceNo);

            uint Res = 0;
            for (uint i = 0; i < AxesPerDev[DeviceNo]; i++)
            {
                try
                {
                    Res = Motion.mAcm_AxClose(ref p_AxisHandle[DeviceNo, i]);
                    if (Res != (int)ErrorCode.SUCCESS)
                    {
                        throw new Exception(GetErrorMessage1(Res));
                    }
                }
                catch { };
            }

            for (int i = 0; i < 3; i++)
            {
                try
                {
                    Res = Motion.mAcm_GpClose(ref p_GroupHandle[DeviceNo, i]);
                    if (Res != (int)ErrorCode.SUCCESS)
                    {
                        //Mutex.ReleaseMutex();
                        throw new Exception(GetErrorMessage1(Res));
                    }
                    p_GroupHandle[DeviceNo, i] = IntPtr.Zero;
                }
                catch { };
            }

            Res = Motion.mAcm_DevClose(ref p_DeviceHandle[DeviceNo]);
            Opened[DeviceNo] = false;
        }
        public void CloseDevice(TDevice Device)
        {
            try
            {
                CloseDevice(Device.ID);
            }
            catch { throw; }
        }

        public bool DeviceOpened(byte DeviceNo)
        {
            return Opened[DeviceNo];
        }
        public bool DeviceOpened(TDevice Device)
        {
            return Opened[Device.ID];
        }

        public void Reset(byte DeviceNo)
        {
            if (Offline) return;

            try
            {
                uint BlendTime = 10;
                uint BufLen = 8;

                Motion.mAcm_SetProperty(p_DeviceHandle[DeviceNo], (uint)PropertyID.CFG_GpBldTime, ref BlendTime, BufLen);
            }
            catch { throw; }

            try
            {
                uint BufLen = 8;
                uint SFEnable = 1;
                Motion.mAcm_SetProperty(p_DeviceHandle[DeviceNo], (uint)PropertyID.CFG_GpSFEnable, ref SFEnable, BufLen);

                uint EmgLogic = (uint)Advantech.Motion.EmgLogic.EMG_ACT_HIGH;
                Motion.mAcm_SetProperty(p_DeviceHandle[DeviceNo], (uint)PropertyID.CFG_DevEmgLogic, ref EmgLogic, 4);


            //uint EmgLogics = 1;//Logic Act High
            //Motion.mAcm_SetProperty(p_DeviceHandle[DeviceNo], (uint)PropertyID.CFG_DevEmgLogic, ref EmgLogics, 4);
            }
            catch { throw; }

            uint Data = 1;
            for (int i = 0; i < AxesPerDev[DeviceNo]; i++)
            {
                try
                {
                    Data = (uint)GenDoEnable.GEN_DO_EN;
                    Motion.mAcm_SetProperty(p_AxisHandle[DeviceNo, i], (uint)PropertyID.CFG_AxGenDoEnable, ref Data, 8);

                    Data = (uint)AlarmEnable.ALM_EN;
                    Motion.mAcm_SetProperty(p_AxisHandle[DeviceNo, i], (uint)PropertyID.CFG_AxAlmEnable, ref Data, 8);

                    Data = (uint)AlarmLogic.ALM_ACT_HIGH;
                    Motion.mAcm_SetProperty(p_AxisHandle[DeviceNo, i], (uint)PropertyID.CFG_AxAlmLogic, ref Data, 8);

                    Data = (uint)InPositionEnable.INP_DIS;//INP_EN
                    Motion.mAcm_SetProperty(p_AxisHandle[DeviceNo, i], (uint)PropertyID.CFG_AxInpEnable, ref Data, 8);

                    Data = (uint)InPositionLogic.NOT_SUPPORT;
                    Motion.mAcm_SetProperty(p_AxisHandle[DeviceNo, i], (uint)PropertyID.CFG_AxInpLogic, ref Data, 8);

                    Data = (uint)LatchEnable.NOT_SUPPORT;
                    Motion.mAcm_SetProperty(p_AxisHandle[DeviceNo, i], (uint)PropertyID.CFG_AxLatchEnable, ref Data, 4);

                    Data = (uint)LatchLogic.LATCH_ACT_LOW;
                    Motion.mAcm_SetProperty(p_AxisHandle[DeviceNo, i], (uint)PropertyID.CFG_AxLatchLogic, ref Data, 4);

                    Motion.mAcm_AxResetError(p_AxisHandle[DeviceNo, i]);

                    Data = (uint)PulseOutReverse.REVERSE_DISABLE;
                    Motion.mAcm_SetProperty(p_AxisHandle[DeviceNo, i], (uint)PropertyID.CFG_AxPulseOutReverse, ref Data, 8);
                }
                catch { throw; }
            }
        }
        public int AxisCount(byte DeviceNo)
        {
            return (int)AxesPerDev[DeviceNo];
        }

        //public void LoadConfig(string FullFilename)
        //{
        //    //string FName = Application.ExecutablePath;
        //    //FName = Path.GetDirectoryName(FName);
        //    //FName = FName + "\\CControl.ini";
        //    NSW.Net.IniFile Inifile = new NSW.Net.IniFile();

        //    Inifile.Create(FullFilename);
        //    PathDelay = Inifile.ReadInteger("P1245", "PathDelay", 2);
        //}
        //public void SaveConfig(string FullFilename)
        //{
        //    //string FName = Application.ExecutablePath;
        //    //FName = Path.GetDirectoryName(FName);
        //    //FName = FName + "\\CControl.ini";
        //    NSW.Net.IniFile Inifile = new NSW.Net.IniFile();

        //    Inifile.Create(FullFilename);
        //    Inifile.WriteInteger("P1245", "PathDelay", PathDelay);
        //}

        public bool LoadConfigFile(byte DeviceNo, string fullFileName)
        {
            //Set all configurations for the device according to the loaded file
            uint res = Motion.mAcm_DevLoadConfig(p_DeviceHandle[DeviceNo], fullFileName);
            if (res != (uint)ErrorCode.SUCCESS)
            {
                string strTemp = "Load Config Failed With Error Code: [0x" + Convert.ToString(res, 16) + "]";
                MessageBox.Show(strTemp);
                return false;
            }
            return true;
        }

        private uint MaxGroup(TDevice Device)
        {
            switch (Device.Type)
            {
                default:
                case EDeviceType.P1245:
                    return 2;
                case EDeviceType.P1265:
                    return 3;
                case EDeviceType.P1285:
                    return 4;
            }
        }
        private uint MaxAxisInGroup(TDevice Device)
        {
            switch (Device.Type)
            {
                default:
                case EDeviceType.P1245:
                    return 4;
                case EDeviceType.P1265:
                    return 6;
                case EDeviceType.P1285:
                    return 8;
            }
        }
        #endregion

        //default
        //EMO logic act high
        //MtrAlm disabled
        //MtrAlm logic act low
        //InPos disabled
        //SwLmt disabled
        //SwLmt react force stop
        //HWLmt disabled
        //HWLmt logic act high
        //HWLmt react force stop

        #region Configuration
        public int PathDelay = 0;

        //public void EmgLogicActHigh(TDevice Device, bool LogicHigh)//default ActHigh
        //{
        //    uint EmgLogic = 1;//Logic Act High
        //    if (!LogicHigh) EmgLogic = 0;
        //    Motion.mAcm_SetProperty(p_DeviceHandle[Device.ID], (uint)PropertyID.CFG_DevEmgLogic, ref EmgLogic, 4);
        //}

        //public void MotorAlarmEnabled(TAxis Axis, out bool Enable)
        //{
        //    uint Data = 0;
        //    uint Length = 0;
        //    Motion.mAcm_GetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxAlmEnable, ref Data, ref Length);

        //    Enable = (Data == (uint)AlarmEnable.ALM_EN);
        //}
        //public void MotorAlarmLogicActHigh(TAxis Axis, bool LogicHigh)
        //{
        //    uint Data = (uint)AlarmLogic.ALM_ACT_HIGH;
        //    if (!LogicHigh) Data = (uint)AlarmLogic.ALM_ACT_LOW;
        //    Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxAlmLogic, ref Data, 4);
        //}
        public void MotorAlarmEnable(TAxis Axis, bool Enable)
        {
            uint Data = (uint)AlarmEnable.ALM_EN;
            if (!Enable) Data = (uint)AlarmEnable.ALM_DIS;
            try
            {
                uint Res = Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxAlmEnable, ref Data, 4);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    //Mutex.ReleaseMutex();
                    throw new Exception(GetErrorMessage1(Res));
                }
            }
            catch { throw; }
        }

        public void SoftwareLimitEnable(TAxis Axis, bool Enable)//default Disabled
        {
            try
            {
                uint Data = (uint)SwLmtEnable.SLMT_EN;
                if (!Enable) Data = (uint)SwLmtEnable.SLMT_DIS;
                Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxSwPelEnable, ref Data, 4);
                Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxSwMelEnable, ref Data, 4);
            }
            catch { throw; }
        }
        public void SoftwareLimitReactForceStop(TAxis Axis, bool ForceStop)//default ForceStop
        {
            uint Data = (uint)SwLmtReact.SLMT_IMMED_STOP;
            if (!ForceStop) Data = (uint)SwLmtReact.SLMT_DEC_TO_STOP;
            Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxSwPelReact, ref Data, 4);
            Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxSwMelReact, ref Data, 4);
        }

        public void HardwareLimitEnable(TAxis Axis, bool Enable)//default Disabled
        {
            try
            {
                uint Data = (uint)HLmtEnable.HLMT_EN;
                if (!Enable) Data = (uint)HLmtEnable.HLMT_DIS;
                Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxElEnable, ref Data, 4);
            }
            catch { throw; }
        }
        public void HardwareLimitLogicActHigh(TAxis Axis, bool LogicHigh)//default ActHigh
        {
            uint Data = (uint)HLmtLogic.HLMT_ACT_HIGH;
            if (!LogicHigh) Data = (uint)HLmtLogic.HLMT_ACT_LOW;
            Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxElLogic, ref Data, 4);
        }
        public void HardwareLimitReactForceStop(TAxis Axis, bool ForceStop)//default ForceStop
        {
            uint Data = (uint)HLmtReact.HLMT_IMMED_STOP;
            if (!ForceStop) Data = (uint)HLmtReact.HLMT_DEC_TO_STOP;
            Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxElReact, ref Data, 4);
        }

        public void CfgLatchEnable(TAxis Axis, bool Enable)//default disabled
        {
            try
            {
                uint Data = (uint)LatchEnable.LATCH_EN;
                if (!Enable) Data = (uint)LatchEnable.LATCH_DIS;
                Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxLatchEnable, ref Data, 4);
            }
            catch { throw; }
        }
        public void CfgLatchLogic(TAxis Axis, bool HighAct)//default LowAct
        {
            try
            {
                uint Data = (uint)LatchLogic.LATCH_ACT_HIGH;
                if (!HighAct) Data = (uint)LatchLogic.LATCH_ACT_LOW;
                Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxLatchLogic, ref Data, 4);
            }
            catch { throw; }
        }

        public void CfgCmpEnable(TAxis Axis, bool Enable)//default disabled
        {
            try
            {
                //uint Data = (uint)GenDoEnable.GEN_DO_DIS;
                ////if (!Enable) Data = (uint)GenDoEnable.GEN_DO_EN;
                //Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxGenDoEnable, ref Data, 4);


                uint Data = (uint)CmpEnable.CMP_EN;
                if (!Enable) Data = (uint)CmpEnable.CMP_DIS;
                Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxCmpEnable, ref Data, 4);
            }
            catch { throw; }
        }
        public void CfgCmpLogic(TAxis Axis, bool HighAct)//default LowAct
        {
            try
            {
                uint Data = (uint)CmpPulseLogic.CP_ACT_HIGH;
                if (!HighAct) Data = (uint)CmpPulseLogic.CP_ACT_LOW;
                Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxCmpPulseLogic, ref Data, 4);
            }
            catch { throw; }
        }
        /// <summary>
        /// Set Compare Pulse Width
        /// </summary>
        /// <param name="Axis"></param>
        /// <param name="HighAct">Width (5~1000 us)</param>
        public void CfgCmpSetPulseWidth(TAxis Axis, int Value)//default 5us
        {
            try
            {
                List<int> list = new List<int> { 5, 10, 20, 50, 100, 200, 500, 1000 };
                int Closest = list.OrderBy(item => Math.Abs(Value - item)).First();

                uint Data = 100;
                //switch (Closest)
                //{
                //    case 5:
                //    default:
                //        Data = 0; break;
                //    case 10:
                //        Data = 1; break;
                //    case 20:
                //        Data = 2; break;
                //    case 50:
                //        Data = 3; break;
                //    case 100:
                //        Data = 4; break;
                //    case 200:
                //        Data = 5; break;
                //    case 500:
                //        Data = 6; break;
                //    case 1000:
                //        Data = 7; break;
                //}
                Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxCmpPulseWidth, ref Data, 4);
            }
            catch { throw; }
        }
        public enum ECmpSource { Command, Actual }
        public void CfgCmpSource(TAxis Axis, ECmpSource Source)
        {
            try
            {
                uint Data = (uint)Source;
                Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxCmpSrc, ref Data, 4);
            }
            catch
            {
                throw;
            }
        }
        public enum ECmpMethod { EqualOrMore, EqualOrLess }
        public void CfgCmpMethod(TAxis Axis, ECmpMethod Method)
        {
            try
            {
                uint Data = (uint)Method;
                Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxCmpMethod, ref Data, 4);
            }
            catch
            {
                throw;
            }
        }
        public enum ECmpPulseMode { Pulse, Toggle }
        public void CfgCmpPulseMode(TAxis Axis, ECmpPulseMode Mode)
        {
            try
            {
                uint Data = (uint)Mode;
                Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxCmpPulseMode, ref Data, 4);
            }
            catch
            {
                throw;
            }
        }

        #endregion

        Mutex Mutex = new Mutex();

        #region Para
        public void SetUPP(TAxis Axis, double Value)
        {
            try
            {

                UPP[Axis.Device.ID, Axis.Mask] = Value;

                //uint PPU = (uint)(1 / Value);
                uint PPU = 1000000;
                uint PPUDenom = (uint)(Value * 1000000);

                uint BufLen = 4;
                uint Res = Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxPPU, ref PPU, BufLen);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }

                //uint demominatorPPU = 1;
                Res = Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxPPUDenominator, ref PPUDenom, BufLen);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }
            }
            catch { throw; }
        }
        public void SetInvertPulse(TAxis Axis, bool Invert)
        {
            try
            {
                uint Data = Invert?(uint)PulseOutReverse.REVERSE_ENABLE : (uint)PulseOutReverse.REVERSE_DISABLE;
                Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxPulseOutReverse, ref Data, 4);
            }
            catch { throw; }
        }
        #endregion

        #region Motion Para
        public void GetSpeedMinMax(TAxis Axis, ref double Min, ref double Max)
        {
            try
            {
                uint BufLen = 8;
                double MaxSpeed = 0;
                uint Res = Motion.mAcm_GetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.FT_AxMaxVel, ref MaxSpeed, ref BufLen);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }

                Min = 1 * UPP[Axis.Device.ID, Axis.Mask];
                Max = MaxSpeed * UPP[Axis.Device.ID, Axis.Mask];
            }
            catch { throw; }
        }
        public void GetAccelMinMax(TAxis Axis, ref double Min, ref double Max)
        {
            try
            {
                uint BufLen = 8;
                double MaxAcc = 0;
                uint Res = Motion.mAcm_GetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.FT_AxMaxAcc, ref MaxAcc, ref BufLen);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }

                Min = 1 * UPP[Axis.Device.ID, Axis.Mask];
                Max = MaxAcc * UPP[Axis.Device.ID, Axis.Mask];
            }
            catch { throw; }
        }
        public void GetDecelMinMax(TAxis Axis, ref double Min, ref double Max)
        {
            try
            {
                uint BufLen = 8;
                double MaxDec = 0;
                uint Res = Motion.mAcm_GetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.FT_AxMaxDec, ref MaxDec, ref BufLen);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }

                Min = 1 * UPP[Axis.Device.ID, Axis.Mask];
                Max = MaxDec * UPP[Axis.Device.ID, Axis.Mask];
            }
            catch { throw; }
        }
        public void GetJerkMinMax(TAxis Axis, ref double Min, ref double Max)
        {
            try
            {
                uint BufLen = 0;
                double MaxJerk = 0;
                uint Res = Motion.mAcm_GetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.FT_AxMaxJerk, ref MaxJerk, ref BufLen);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }

                Min = 0;
                Max = MaxJerk;
            }
            catch { throw; }
        }

        public void SetStartV(TAxis Axis, double Value)
        {
            try
            {
                uint BufLen = 8;
                uint Res = Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.PAR_AxVelLow, ref Value, BufLen);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }
                StartV[Axis.Device.ID, Axis.Mask] = Value;
                Axis.Para.Psnt.StartV = Value;
            }
            catch { throw; }
        }
        public void SetStartV(TAxis Axis, TAxis Axis2, double Value)
        {
            uint Res = 0;
            try
            {
                #region Set Group
                for (int i = 0; i < MaxGroup(Axis.Device); i++)
                {
                    if (p_GroupHandle[Axis.Device.ID, i] == (IntPtr)0) continue;

                    uint AxisInGroup = 0;
                    uint BufLen = 4;
                    Res = Motion.mAcm_GetProperty(p_GroupHandle[Axis.Device.ID, i], (uint)PropertyID.CFG_GpAxesInGroup, ref AxisInGroup, ref BufLen);
                    if (Res != (int)ErrorCode.SUCCESS)
                    {
                        throw new Exception(GetErrorMessage1(Res));
                    }

                    uint AxisMask = 0x001;
                    AxisMask = AxisMask << Axis.Mask;

                    if ((AxisInGroup & AxisMask) == AxisMask)
                    {
                        Res = Motion.mAcm_SetProperty(p_GroupHandle[Axis.Device.ID, i], (uint)PropertyID.PAR_GpVelLow, ref Value, 8);
                        if (Res != (int)ErrorCode.SUCCESS)
                        {
                            throw new Exception(GetErrorMessage1(Res));
                        }
                    }
                }
                #endregion
            }
            catch { throw; }
        }

        public void SetDriveV(TAxis Axis, double Value)//StartV is suppressed
        {
            try
            {
                if (Value < StartV[Axis.Device.ID, Axis.Mask]) SetStartV(Axis, Value);

                uint BufLen = 8;
                uint Res = Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.PAR_AxVelHigh, ref Value, BufLen);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }
                DriveV[Axis.Device.ID, Axis.Mask] = Value;
                Axis.Para.Psnt.DriveV = Value;

            }
            catch { throw; }
        }
        public void SetDriveV(TAxis Axis, TAxis Axis2, double Value)
        {
            uint Res = 0;
            try
            {
                #region Set Group
                for (int i = 0; i < MaxGroup(Axis.Device); i++)
                {
                    if (p_GroupHandle[Axis.Device.ID, i] == (IntPtr)0) continue;

                    uint AxisInGroup = 0;
                    uint BufLen = 4;
                    Res = Motion.mAcm_GetProperty(p_GroupHandle[Axis.Device.ID, i], (uint)PropertyID.CFG_GpAxesInGroup, ref AxisInGroup, ref BufLen);
                    if (Res != (int)ErrorCode.SUCCESS)
                    {
                        throw new Exception(GetErrorMessage1(Res));
                    }

                    uint AxisMask = 0x001;
                    AxisMask = AxisMask << Axis.Mask;

                    if ((AxisInGroup & AxisMask) == AxisMask)
                    {
                        Res = Motion.mAcm_SetProperty(p_GroupHandle[Axis.Device.ID, i], (uint)PropertyID.PAR_GpVelHigh, ref Value, 8);
                        if (Res != (int)ErrorCode.SUCCESS)
                        {
                            throw new Exception(GetErrorMessage1(Res));
                        }
                    }
                }
                #endregion
            }
            catch { throw; }
        }

        public void SetAccel(TAxis Axis, double Value)
        {
            uint Res = 0;
            try
            {
                uint BufLen = 8;
                Res = Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.PAR_AxAcc, ref Value, BufLen);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }
                Accel[Axis.Device.ID, Axis.Mask] = Value;
                Axis.Para.Psnt.Accel = Value;

                SetDecel(Axis, Value);
            }
            catch { throw; }
        }
        public void SetAccel(TAxis Axis, TAxis Axis2, double Value)
        {
            uint Res = 0;
            try
            {
                for (int i = 0; i < MaxGroup(Axis.Device); i++)
                {
                    if (p_GroupHandle[Axis.Device.ID, i] == (IntPtr)0) continue;

                    uint AxisInGroup = 0;
                    uint BufLen = 4;
                    Res = Motion.mAcm_GetProperty(p_GroupHandle[Axis.Device.ID, i], (uint)PropertyID.CFG_GpAxesInGroup, ref AxisInGroup, ref BufLen);
                    if (Res != (int)ErrorCode.SUCCESS)
                    {
                        throw new Exception(GetErrorMessage1(Res));
                    }

                    uint AxisMask = 0x001;
                    AxisMask = AxisMask << Axis.Mask;

                    if ((AxisInGroup & AxisMask) == AxisMask)
                    {
                        Res = Motion.mAcm_SetProperty(p_GroupHandle[Axis.Device.ID, i], (uint)PropertyID.PAR_GpAcc, ref Value, 8);
                        if (Res != (int)ErrorCode.SUCCESS)
                        {
                            throw new Exception(GetErrorMessage1(Res));
                        }
                    }
                }

                SetDecel(Axis, Axis2, Value);
            }
            catch { throw; }
        }
        public void SetAccel(TAxis[] Axis, double Value)
        {
            uint Res = 0;
            try
            {
                if (Axis.Count() == 0)
                {
                }
                else
                if (Axis.Count() == 1)
                {
                    uint BufLen = 8;
                    Res = Motion.mAcm_SetProperty(p_AxisHandle[Axis[0].Device.ID, Axis[0].Mask], (uint)PropertyID.PAR_AxAcc, ref Value, BufLen);
                    if (Res != (int)ErrorCode.SUCCESS)
                    {
                        throw new Exception(GetErrorMessage1(Res));
                    }
                    Accel[Axis[0].Device.ID, Axis[0].Mask] = Value;
                    Axis[0].Para.Psnt.Accel = Value;

                    SetDecel(Axis[0], Value);
                }
                else
                {
                    for (int i = 0; i < MaxGroup(Axis[0].Device); i++)
                    {
                        if (p_GroupHandle[Axis[0].Device.ID, i] == (IntPtr)0) continue;

                        uint AxisInGroup = 0;
                        uint BufLen = 4;
                        Res = Motion.mAcm_GetProperty(p_GroupHandle[Axis[0].Device.ID, i], (uint)PropertyID.CFG_GpAxesInGroup, ref AxisInGroup, ref BufLen);
                        if (Res != (int)ErrorCode.SUCCESS)
                        {
                            throw new Exception(GetErrorMessage1(Res));
                        }

                        uint AxisMask = 0x001;
                        AxisMask = AxisMask << Axis[0].Mask;

                        if ((AxisInGroup & AxisMask) == AxisMask)
                        {
                            Res = Motion.mAcm_SetProperty(p_GroupHandle[Axis[0].Device.ID, i], (uint)PropertyID.PAR_GpAcc, ref Value, 8);
                            if (Res != (int)ErrorCode.SUCCESS)
                            {
                                throw new Exception(GetErrorMessage1(Res));
                            }
                            break;
                        }
                    }

                    SetDecel(Axis, Value);
                }
            }
            catch { throw; }
        }

        public void SetDecel(TAxis Axis, double Value)
        {
            try
            {
                uint BufLen = 8;
                uint Res = Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.PAR_AxDec, ref Value, BufLen);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }
                Decel[Axis.Device.ID, Axis.Mask] = Value;
                Axis.Para.Psnt.Decel = Value;
            }
            catch { throw; }
        }
        public void SetDecel(TAxis Axis, TAxis Axis2, double Value)
        {
            uint Res = 0;
            try
            {
                #region Set Group
                for (int i = 0; i < MaxGroup(Axis.Device); i++)
                {
                    if (p_GroupHandle[Axis.Device.ID, i] == (IntPtr)0) continue;

                    uint AxisInGroup = 0;
                    uint BufLen = 4;
                    Res = Motion.mAcm_GetProperty(p_GroupHandle[Axis.Device.ID, i], (uint)PropertyID.CFG_GpAxesInGroup, ref AxisInGroup, ref BufLen);
                    if (Res != (int)ErrorCode.SUCCESS)
                    {
                        throw new Exception(GetErrorMessage1(Res));
                    }

                    uint AxisMask = 0x001;
                    AxisMask = AxisMask << Axis.Mask;

                    if ((AxisInGroup & AxisMask) == AxisMask)
                    {
                        Res = Motion.mAcm_SetProperty(p_GroupHandle[Axis.Device.ID, i], (uint)PropertyID.PAR_GpDec, ref Value, 8);
                        if (Res != (int)ErrorCode.SUCCESS)
                        {
                            throw new Exception(GetErrorMessage1(Res));
                        }
                    }
                }
                #endregion
            }
            catch { throw; }
        }
        public void SetDecel(TAxis[] Axis, double Value)
        {
            uint Res = 0;
            try
            {
                if (Axis.Count() == 0)
                {
                }
                else
                    if (Axis.Count() == 1)
                {
                    uint BufLen = 8;
                    Res = Motion.mAcm_SetProperty(p_AxisHandle[Axis[0].Device.ID, Axis[0].Mask], (uint)PropertyID.PAR_AxDec, ref Value, BufLen);
                    if (Res != (int)ErrorCode.SUCCESS)
                    {
                        throw new Exception(GetErrorMessage1(Res));
                    }
                    Decel[Axis[0].Device.ID, Axis[0].Mask] = Value;
                    Axis[0].Para.Psnt.Decel = Value;
                }
                else
                {
                    for (int i = 0; i < MaxGroup(Axis[0].Device); i++)
                    {
                        if (p_GroupHandle[Axis[0].Device.ID, i] == (IntPtr)0) continue;

                        uint AxisInGroup = 0;
                        uint BufLen = 4;
                        Res = Motion.mAcm_GetProperty(p_GroupHandle[Axis[0].Device.ID, i], (uint)PropertyID.CFG_GpAxesInGroup, ref AxisInGroup, ref BufLen);
                        if (Res != (int)ErrorCode.SUCCESS)
                        {
                            throw new Exception(GetErrorMessage1(Res));
                        }

                        uint AxisMask = 0x001;
                        AxisMask = AxisMask << Axis[0].Mask;

                        if ((AxisInGroup & AxisMask) == AxisMask)
                        {
                            Res = Motion.mAcm_SetProperty(p_GroupHandle[Axis[0].Device.ID, i], (uint)PropertyID.PAR_GpDec, ref Value, 8);
                            if (Res != (int)ErrorCode.SUCCESS)
                            {
                                throw new Exception(GetErrorMessage1(Res));
                            }
                            break;
                        }
                    }
                }
            }
            catch { throw; }
        }

        public void SetJerk(TAxis Axis, double Value)
        {
            try
            {
                uint BufLen = 8;
                uint Res = Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.PAR_AxJerk, ref Value, BufLen);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }
                Jerk[Axis.Device.ID, Axis.Mask] = Value;
            }
            catch { throw; }
        }
        public void SetJerk(TAxis Axis, TAxis Axis2, double Value)
        {
            uint Res = 0;
            try
            {
                for (int i = 0; i < MaxGroup(Axis.Device); i++)
                {
                    if (p_GroupHandle[Axis.Device.ID, i] == (IntPtr)0) continue;

                    uint AxisInGroup = 0;
                    uint BufLen = 4;
                    Res = Motion.mAcm_GetProperty(p_GroupHandle[Axis.Device.ID, i], (uint)PropertyID.CFG_GpAxesInGroup, ref AxisInGroup, ref BufLen);
                    if (Res != (int)ErrorCode.SUCCESS)
                    {
                        throw new Exception(GetErrorMessage1(Res));
                    }

                    uint AxisMask = 0x001;
                    AxisMask = AxisMask << Axis.Mask;

                    if ((AxisInGroup & AxisMask) == AxisMask)
                    {
                        Res = Motion.mAcm_SetProperty(p_GroupHandle[Axis.Device.ID, i], (uint)PropertyID.PAR_GpJerk, ref Value, 8);
                        if (Res != (int)ErrorCode.SUCCESS)
                        {
                            throw new Exception(GetErrorMessage1(Res));
                        }
                    }
                }
            }
            catch { throw; }
        }

        private void SetSLmt(TAxis Axis, bool Positive, double Value)
        {
            try
            {
                int PValue = (int)(Value / UPP[Axis.Device.ID, Axis.Mask]);

                uint BufLen = 4;
                uint Res = 0;
                if (Positive)
                {
                    //if (!InvertPulse[Axis.Device.ID, Axis.Mask])
                    //{
                    //    Res = Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxSwPelValue, ref PValue, BufLen);
                    //}
                    //else
                    //{
                    //    PValue = -PValue;
                    //    Res = Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxSwMelValue, ref PValue, BufLen);
                    //}
                    Res = Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxSwPelValue, ref PValue, BufLen);
                }
                else
                {
                    //if (!InvertPulse[Axis.Device.ID, Axis.Mask])
                    //{
                    //    Res = Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxSwMelValue, ref PValue, BufLen);
                    //}
                    //else
                    //{
                    //    PValue = -PValue;
                    //    Res = Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxSwPelValue, ref PValue, BufLen);
                    //}
                    Res = Motion.mAcm_SetProperty(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)PropertyID.CFG_AxSwMelValue, ref PValue, BufLen);
                }
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception("SetSLMT " + GetErrorMessage1(Res));
                }
            }
            catch { throw; }
        }
        public void SetSLmtP(TAxis Axis, double Value)
        {
            try
            {
                SetSLmt(Axis, true, Value);//InvertPulse[Axis.Device.ID, Axis.Mask], Value);
            }
            catch { throw; }
        }
        public void SetSLmtN(TAxis Axis, double Value)
        {
            try
            {
                SetSLmt(Axis, false, Value);//InvertPulse[Axis.Device.ID, Axis.Mask], Value);
            }
            catch { throw; }
        }
        #endregion

        public enum EHomeMode
        {
            MODE1_Abs = 0,
            MODE2_Lmt = 1,
            MODE3_Ref = 2,
            MODE4_Abs_Ref = 3,
            MODE5_Abs_NegRef = 4,
            MODE6_Lmt_Ref = 5,
            MODE7_AbsSearch = 6,
            MODE8_LmtSearch = 7,
            MODE9_AbsSearch_Ref = 8,
            MODE10_AbsSearch_NegRef = 9,
            MODE11_LmtSearch_Ref = 10,
            MODE12_AbsSearchReFind = 11,
            MODE13_LmtSearchReFind = 12,
            MODE14_AbsSearchReFind_Ref = 13,
            MODE15_AbsSearchReFind_NegRef = 14,
            MODE16_LmtSearchReFind_Ref = 15,
        }

        public void HomeCrossDistance(TAxis axis, double value)
        {
            try
            {
                uint Res = Motion.mAcm_SetF64Property(p_AxisHandle[axis.Device.ID, axis.Mask], (uint)PropertyID.PAR_AxHomeCrossDistance, value);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception("HomeCrossDistance " + GetErrorMessage1(Res));
                }
            }
            catch { throw; }
        }

        public void Home(TAxis axis, EHomeMode mode, EHomeDir dir)
        {
            try
            {
                uint uDir = 0;//invert due to different convention
                if (dir == EHomeDir.N) uDir = 1;

                uint Res = Motion.mAcm_AxHome(p_AxisHandle[axis.Device.ID, axis.Mask], (uint)mode, uDir);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception("Home " + GetErrorMessage1(Res));
                }
            }
            catch { throw; }
        }

        #region Motion
        private AxisState AxisState(TAxis Axis)
        {
            Mutex.WaitOne();
            try
            {
                UInt16 State = 0;
                uint Res = Motion.mAcm_AxGetState(p_AxisHandle[Axis.Device.ID, Axis.Mask], ref State);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }
                return (Advantech.Motion.AxisState)State;
            }
            catch
            {
                throw;
            }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }
        public bool AxisReady(TAxis Axis)
        {
            try
            {
                Advantech.Motion.AxisState State = AxisState(Axis);
                return (State == Advantech.Motion.AxisState.STA_AX_READY);
            }
            catch { throw; };
        }
        public bool AxisBusy(TAxis Axis)
        {
            try
            {
                Advantech.Motion.AxisState State = AxisState(Axis);
                switch (State)
                {
                    case Advantech.Motion.AxisState.STA_AX_DISABLE:
                    case Advantech.Motion.AxisState.STA_AX_READY:
                    case Advantech.Motion.AxisState.STA_AX_ERROR_STOP:
                        return false;
                    case Advantech.Motion.AxisState.STA_AX_BUSY:
                    case Advantech.Motion.AxisState.STA_AX_CONTI_MOT:
                    case Advantech.Motion.AxisState.STA_AX_EXT_JOG:
                    case Advantech.Motion.AxisState.STA_AX_EXT_MPG:
                    case Advantech.Motion.AxisState.STA_AX_HOMING:
                    case Advantech.Motion.AxisState.STA_AX_PAUSE:
                    case Advantech.Motion.AxisState.STA_AX_PTP_MOT:
                    case Advantech.Motion.AxisState.STA_AX_STOPPING:
                    case Advantech.Motion.AxisState.STA_AX_SYNC_MOT:
                    default:
                        return true;
                }
            }
            catch { throw; };
        }
        public bool AxisError(TAxis Axis)
        {
            try
            {
                Advantech.Motion.AxisState State = AxisState(Axis);
                return (State == Advantech.Motion.AxisState.STA_AX_ERROR_STOP);
            }
            catch { throw; };
        }
        public void ClearAxisError(TAxis Axis)
        {
            uint Res = 0;
            try
            {
                int MaxGroup = 2;
                if (Axis.Device.Type == EDeviceType.P1265) MaxGroup = 3;
                if (Axis.Device.Type == EDeviceType.P1285) MaxGroup = 4;

                for (int i = 0; i < MaxGroup; i++)
                {
                    if (p_GroupHandle[Axis.Device.ID, i] == (IntPtr)0) continue;

                    uint Data = 0;
                    uint BufLen = 4;
                    Res = Motion.mAcm_GetProperty(p_GroupHandle[Axis.Device.ID, i], (uint)PropertyID.CFG_GpAxesInGroup, ref Data, ref BufLen);
                    if (Res != (int)ErrorCode.SUCCESS)
                    {
                        throw new Exception(GetErrorMessage1(Res));
                    }

                    uint AxisMask = 0;
                    if (Axis.Mask == 1) AxisMask = 0x0001;
                    if (Axis.Mask == 2) AxisMask = 0x0002;
                    if (Axis.Mask == 3) AxisMask = 0x0004;
                    if (Axis.Mask == 4) AxisMask = 0x0008;
                    if (Axis.Mask == 5) AxisMask = 0x0010;
                    if (Axis.Mask == 6) AxisMask = 0x0020;

                    if ((Data & AxisMask) == AxisMask)
                    {
                        Res = Motion.mAcm_GpResetError(p_GroupHandle[Axis.Device.ID, i]);
                        if (Res != (int)ErrorCode.SUCCESS)
                        {
                            throw new Exception(GetErrorMessage1(Res));
                        }
                    }
                }

                Res = Motion.mAcm_AxResetError(p_AxisHandle[Axis.Device.ID, Axis.Mask]);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }
            }
            catch
            {
                throw;
            }
        }

        private GroupState GroupState(TAxis MasterAxis)
        {
            Mutex.WaitOne();
            try
            {
                UInt16 State = 0;
                for (int i = 0; i < MaxGroup(MasterAxis.Device); i++)
                {

                    if (p_GroupHandle[MasterAxis.Device.ID, i] != (IntPtr)0)
                    {
                        UInt32 AxesInGroup = 0;
                        uint BufLen = 4;
                        uint Res = 0;
                        Res = Motion.mAcm_GetProperty(p_GroupHandle[MasterAxis.Device.ID, i], (uint)PropertyID.CFG_GpAxesInGroup, ref AxesInGroup, ref BufLen);
                        if (Res != (int)ErrorCode.SUCCESS)
                        {
                            throw new Exception(GetErrorMessage1(Res));
                        }

                        uint Mask = 0x0001;
                        Mask = Mask << MasterAxis.Mask;

                        if ((AxesInGroup & Mask) == Mask)
                        {
                            Res = Motion.mAcm_GpGetState(p_GroupHandle[MasterAxis.Device.ID, i], ref State);
                            if (Res != (int)ErrorCode.SUCCESS)
                            {
                                throw new Exception(GetErrorMessage1(Res));
                            }
                            break;
                        }
                    }
                }
                return (Advantech.Motion.GroupState)State;
            }
            catch
            {
                throw;
            }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }
        public bool AxisBusy(TAxis Axis, TAxis Axis2)
        {
            try
            {
                Advantech.Motion.GroupState State = GroupState(Axis);
                switch (State)
                {
                    case Advantech.Motion.GroupState.STA_GP_AX_MOTION:
                    case Advantech.Motion.GroupState.STA_GP_BUSY:
                    case Advantech.Motion.GroupState.STA_Gp_Motion:
                    case Advantech.Motion.GroupState.STA_GP_Pathing:
                    case Advantech.Motion.GroupState.STA_GP_PAUSE:
                    case Advantech.Motion.GroupState.STA_Gp_Stopping:
                        return true;
                    case Advantech.Motion.GroupState.STA_Gp_ErrorStop:
                    case Advantech.Motion.GroupState.STA_Gp_Disable:
                    case Advantech.Motion.GroupState.STA_Gp_Ready:
                    default:
                        return false;
                }
            }
            catch { throw; };
        }

        private void Stop(TAxis Axis, bool Emg)
        {
            uint Res = 0;
            try
            {
                UInt16 State = 0;
                Res = Motion.mAcm_AxGetState(p_AxisHandle[Axis.Device.ID, Axis.Mask], ref State);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }

                if (State == (uint)Advantech.Motion.AxisState.STA_AX_SYNC_MOT)
                {
                    int MaxGroup = 2;
                    if (Axis.Device.Type == EDeviceType.P1265) MaxGroup = 3;
                    if (Axis.Device.Type == EDeviceType.P1285) MaxGroup = 4;

                    for (int i = 0; i < MaxGroup; i++)
                    {
                        if (p_GroupHandle[Axis.Device.ID, i] == (IntPtr)0) continue;

                        uint Data = 0;
                        uint BufLen = 4;
                        Res = Motion.mAcm_GetProperty(p_GroupHandle[Axis.Device.ID, i], (uint)PropertyID.CFG_GpAxesInGroup, ref Data, ref BufLen);
                        if (Res != (int)ErrorCode.SUCCESS)
                        {
                            throw new Exception(GetErrorMessage1(Res));
                        }

                        uint AxisMask = 0;
                        if (Axis.Mask == 1) AxisMask = 0x0001;
                        if (Axis.Mask == 2) AxisMask = 0x0002;
                        if (Axis.Mask == 3) AxisMask = 0x0004;
                        if (Axis.Mask == 4) AxisMask = 0x0008;
                        if (Axis.Mask == 5) AxisMask = 0x0010;
                        if (Axis.Mask == 6) AxisMask = 0x0020;

                        if ((Data & AxisMask) == AxisMask)
                        {
                            if (Emg)
                                Res = Motion.mAcm_GpStopEmg(p_GroupHandle[Axis.Device.ID, i]);
                            else
                                Res = Motion.mAcm_GpStopDec(p_GroupHandle[Axis.Device.ID, i]);

                            if (Res != (int)ErrorCode.SUCCESS)
                            {
                                throw new Exception(GetErrorMessage1(Res));
                            }
                            break;
                        }
                    }
                }
                else
                {
                    if (Emg)
                        Res = Motion.mAcm_AxStopEmg(p_AxisHandle[Axis.Device.ID, Axis.Mask]);
                    else
                        Res = Motion.mAcm_AxStopDec(p_AxisHandle[Axis.Device.ID, Axis.Mask]);
                    if (Res != (int)ErrorCode.SUCCESS)
                    {
                        throw new Exception(GetErrorMessage1(Res));
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public void DecelStop(TAxis Axis)
        {
            try
            {
                Stop(Axis, false);
            }
            catch
            { throw; }
        }
        public void ForceStop(TAxis Axis)
        {
            try
            {
                Stop(Axis, true);
            }
            catch
            { throw; }
        }

        private void Jop(TAxis Axis, bool Positive)
        {
            if (AxisBusy(Axis)) new Exception("Axis Busy.");

            Mutex.WaitOne();
            try
            {
                //ushort Dir = 0;//0: positive, 1: negative

                //if (Positive & InvertPulse[Axis.Device.ID, Axis.Mask])
                //{
                //    Dir = 1;
                //}
                //if (Positive & !InvertPulse[Axis.Device.ID, Axis.Mask])
                //{
                //    Dir = 0;
                //}
                //if (!Positive & InvertPulse[Axis.Device.ID, Axis.Mask])
                //{
                //    Dir = 0;
                //}
                //if (!Positive & !InvertPulse[Axis.Device.ID, Axis.Mask])
                //{
                //    Dir = 1;
                //}

                ushort Dir = (ushort)(Positive ? 0 : 1);

                uint Res = Motion.mAcm_AxMoveVel(p_AxisHandle[Axis.Device.ID, Axis.Mask], Dir);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }
        public void JogP(TAxis Axis)
        {
            try
            {
                Jop(Axis, true);
            }
            catch { throw; }
        }
        public void JogN(TAxis Axis)
        {
            try
            {
                Jop(Axis, false);
            }
            catch { throw; }
        }

        enum EMoveType { Rel, Abs };
        private void MovePtp(TAxis Axis, EMoveType MoveType, double Value)
        {
            if (AxisBusy(Axis)) new Exception("Axis Busy.");

            Mutex.WaitOne();
            try
            {
                uint Res = 0;

                if (MoveType == EMoveType.Abs)
                {
                    Res = Motion.mAcm_AxMoveAbs(p_AxisHandle[Axis.Device.ID, Axis.Mask], Value);
                }
                else
                {
                    Res = Motion.mAcm_AxMoveRel(p_AxisHandle[Axis.Device.ID, Axis.Mask], Value);
                }
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }
                Thread.Sleep(PathDelay);
            }
            catch
            {
                throw;
            }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }
        public void MovePtpRel(TAxis Axis, double Value)
        {
            try
            {
                MovePtp(Axis, EMoveType.Rel, Value);
            }
            catch { throw; }
        }
        public void MovePtpAbs(TAxis Axis, double Value)
        {
            try
            {
                MovePtp(Axis, EMoveType.Abs, Value);
            }
            catch { throw; }
        }

        private void MoveLine(TAxis Axis1, TAxis Axis2, EMoveType MoveType, double Value1, double Value2)
        {
            if (AxisBusy(Axis1) || AxisBusy(Axis2)) new Exception("Axis Busy.");

            Mutex.WaitOne();
            try
            {
                int MaxGroup = 2;
                if (Axis1.Device.Type == EDeviceType.P1265) MaxGroup = 3;
                if (Axis1.Device.Type == EDeviceType.P1285) MaxGroup = 4;

                uint Res = 0;
                //close all unused groups
                for (int i = 0; i < MaxGroup; i++)
                {
                    #region
                    UInt16 GpState = 0;
                    //int Retried = 0;
                    if (p_GroupHandle[Axis1.Device.ID, i] != (IntPtr)0)
                    {
                        Res = Motion.mAcm_GpGetState(p_GroupHandle[Axis1.Device.ID, i], ref GpState);
                        if (Res != (int)ErrorCode.SUCCESS)
                        {
                            throw new Exception(GetErrorMessage1(Res));
                        }

                        switch (GpState)
                        {
                            case (UInt16)Advantech.Motion.GroupState.STA_Gp_Disable:
                            case (UInt16)Advantech.Motion.GroupState.STA_Gp_Ready:
                                Res = Motion.mAcm_GpClose(ref p_GroupHandle[Axis1.Device.ID, i]);
                                if (Res != (int)ErrorCode.SUCCESS)
                                {
                                    throw new Exception(GetErrorMessage1(Res));
                                }
                                p_GroupHandle[Axis1.Device.ID, i] = (IntPtr)0;
                                break;
                            default:
                                uint AxisBit = 0;
                                uint DataLen = 4;
                                Res = Motion.mAcm_GetProperty(p_GroupHandle[Axis1.Device.ID, i], (uint)PropertyID.CFG_GpAxesInGroup, ref AxisBit, ref DataLen);
                                if (Res != (int)ErrorCode.SUCCESS)
                                {
                                    throw new Exception(GetErrorMessage1(Res));
                                }
                                if (((AxisBit & Axis1.Mask) == Axis1.Mask) && ((AxisBit & Axis2.Mask) == Axis2.Mask))
                                {
                                    throw new Exception("Axis is busy");
                                }
                                break;
                        }
                    }
                    #endregion
                }

                //add to group
                for (int i = 0; i < MaxGroup + 1; i++)
                {
                    if (i == MaxGroup)
                    {
                        throw new Exception("No avail group.");
                    }

                    if (p_GroupHandle[Axis1.Device.ID, i] != (IntPtr)0)
                    {
                        continue;
                    }

                    #region Add Axis1 and Axis2
                    Res = Motion.mAcm_GpAddAxis(ref p_GroupHandle[Axis1.Device.ID, i], p_AxisHandle[Axis1.Device.ID, Axis1.Mask]);
                    if (Res != (int)ErrorCode.SUCCESS)
                    {
                        throw new Exception(GetErrorMessage1(Res));
                    }

                    Res = Motion.mAcm_GpAddAxis(ref p_GroupHandle[Axis2.Device.ID, i], p_AxisHandle[Axis2.Device.ID, Axis2.Mask]);
                    if (Res != (int)ErrorCode.SUCCESS)
                    {
                        throw new Exception(GetErrorMessage1(Res));
                    }
                    #endregion

                    double[] PosArray = new double[2] { Value1, Value2 };
                    uint Elements = 2;

                    if (MoveType == EMoveType.Abs)
                    {
                        #region MoveAbs
                        Res = Motion.mAcm_GpMoveLinearAbs(p_GroupHandle[Axis1.Device.ID, i], PosArray, ref Elements);
                        #endregion
                    }
                    else
                    {
                        #region MoveRel
                        Res = Motion.mAcm_GpMoveLinearRel(p_GroupHandle[Axis1.Device.ID, i], PosArray, ref Elements);
                        #endregion
                    }
                    if (Res != (int)ErrorCode.SUCCESS)
                    {
                        throw new Exception(GetErrorMessage1(Res));
                    }
                    break;
                }
                Thread.Sleep(PathDelay);
            }
            catch
            {
                throw;
            }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }
        public void MoveLineRel(TAxis Axis1, TAxis Axis2, double Value1, double Value2)
        {
            try
            {
                MoveLine(Axis1, Axis2, EMoveType.Rel, Value1, Value2);
            }
            catch { throw; }
        }
        public void MoveLineAbs(TAxis Axis1, TAxis Axis2, double Value1, double Value2)
        {
            try
            {
                MoveLine(Axis1, Axis2, EMoveType.Abs, Value1, Value2);
            }
            catch { throw; }
        }

        public enum ECircDir { CW, CCW };
        public enum ECircType { CenterEnd, ThruEnd, CenterAngle }
        private void MoveArc(TAxis Axis1, TAxis Axis2, ECircType CircType, EMoveType MoveType, ECircDir Dir, double RefPt1, double RefPt2, double EndPt1, double EndPt2, ushort Angle_Deg)
        {
            if (AxisBusy(Axis1) || AxisBusy(Axis2)) new Exception("Axis Busy.");

            Mutex.WaitOne();

            try
            {
                int MaxGroup = 2;
                if (Axis1.Device.Type == EDeviceType.P1265) MaxGroup = 3;
                if (Axis1.Device.Type == EDeviceType.P1285) MaxGroup = 4;

                uint Res = 0;

                //close all unused groups
                for (int i = 0; i < MaxGroup; i++)
                {
                    #region
                    UInt16 GpState = 0;
                    if (p_GroupHandle[Axis1.Device.ID, i] != (IntPtr)0)
                    {
                        Res = Motion.mAcm_GpGetState(p_GroupHandle[Axis1.Device.ID, i], ref GpState);
                        if (Res != (int)ErrorCode.SUCCESS)
                        {
                            throw new Exception(GetErrorMessage1(Res));
                        }

                        switch (GpState)
                        {
                            case (UInt16)(UInt16)Advantech.Motion.GroupState.STA_Gp_Disable:
                            case (UInt16)(UInt16)Advantech.Motion.GroupState.STA_Gp_Ready:
                                Res = Motion.mAcm_GpClose(ref p_GroupHandle[Axis1.Device.ID, i]);
                                if (Res != (int)ErrorCode.SUCCESS)
                                {
                                    throw new Exception(GetErrorMessage1(Res));
                                }
                                p_GroupHandle[Axis1.Device.ID, i] = (IntPtr)0;
                                break;
                            default:
                                uint AxisBit = 0;
                                uint DataLen = 4;
                                Res = Motion.mAcm_GetProperty(p_GroupHandle[Axis1.Device.ID, i], (uint)PropertyID.CFG_GpAxesInGroup, ref AxisBit, ref DataLen);
                                if (Res != (int)ErrorCode.SUCCESS)
                                {
                                    throw new Exception(GetErrorMessage1(Res));
                                }
                                if (((AxisBit & Axis1.Mask) == Axis1.Mask) && ((AxisBit & Axis2.Mask) == Axis2.Mask))
                                {
                                    throw new Exception("Axis is busy");
                                }
                                break;
                        }
                    }
                    #endregion
                }

                //add to group
                for (int i = 0; i < MaxGroup + 1; i++)
                {
                    if (i == MaxGroup)
                    {
                        throw new Exception("No avail group.");
                    }

                    if (p_GroupHandle[Axis1.Device.ID, i] != (IntPtr)0)
                    {
                        continue;
                    }

                    #region Add Axis1 and Axis2
                    Res = Motion.mAcm_GpAddAxis(ref p_GroupHandle[Axis1.Device.ID, i], p_AxisHandle[Axis1.Device.ID, Axis1.Mask]);
                    if (Res != (int)ErrorCode.SUCCESS)
                    {
                        throw new Exception(GetErrorMessage1(Res));
                    }

                    Res = Motion.mAcm_GpAddAxis(ref p_GroupHandle[Axis2.Device.ID, i], p_AxisHandle[Axis2.Device.ID, Axis2.Mask]);
                    if (Res != (int)ErrorCode.SUCCESS)
                    {
                        throw new Exception(GetErrorMessage1(Res));
                    }
                    #endregion

                    double[] CenterArray = new double[2] { RefPt1, RefPt2 };
                    double[] ThruArray = new double[2] { RefPt1, RefPt2 };
                    double[] EndArray = new double[2] { EndPt1, EndPt2 };
                    uint AxisNum = 2;

                    if (CircType == ECircType.CenterEnd)
                    {
                        if (MoveType == EMoveType.Abs)
                            Res = Motion.mAcm_GpMoveCircularAbs(p_GroupHandle[Axis1.Device.ID, i], CenterArray, EndArray, ref AxisNum, (short)Dir);
                        else
                            Res = Motion.mAcm_GpMoveCircularRel(p_GroupHandle[Axis1.Device.ID, i], CenterArray, EndArray, ref AxisNum, (short)Dir);
                    }
                    if (CircType == ECircType.ThruEnd)
                    {
                        if (MoveType == EMoveType.Abs)
                            Res = Motion.mAcm_GpMoveCircularAbs_3P(p_GroupHandle[Axis1.Device.ID, i], ThruArray, EndArray, ref AxisNum, (short)Dir);
                        else
                            Res = Motion.mAcm_GpMoveCircularRel_3P(p_GroupHandle[Axis1.Device.ID, i], ThruArray, EndArray, ref AxisNum, (short)Dir);
                    }
                    if (CircType == ECircType.CenterAngle)
                    {
                        if (MoveType == EMoveType.Abs)
                            Res = Motion.mAcm_GpMoveCircularAbs_Angle(p_GroupHandle[Axis1.Device.ID, i], CenterArray, Angle_Deg, ref AxisNum, (short)Dir);
                        else
                            Res = Motion.mAcm_GpMoveCircularRel_Angle(p_GroupHandle[Axis1.Device.ID, i], CenterArray, Angle_Deg, ref AxisNum, (short)Dir);
                    }

                    if (Res != (int)ErrorCode.SUCCESS)
                    {
                        throw new Exception(GetErrorMessage1(Res));
                    }
                    break;
                }
                Thread.Sleep(PathDelay);
            }
            catch
            {
                throw;
            }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }
        public void MoveArcCenterEndRel(TAxis Axis1, TAxis Axis2, ECircDir Dir, double CenterPt1, double CenterPt2, double EndPt1, double EndPt2)
        {
            try
            {
                MoveArc(Axis1, Axis2, ECircType.CenterEnd, EMoveType.Rel, Dir, CenterPt1, CenterPt2, EndPt1, EndPt2, 0);
            }
            catch { throw; }
        }
        public void MoveArcCenterEndAbs(TAxis Axis1, TAxis Axis2, ECircDir Dir, double CenterPt1, double CenterPt2, double EndPt1, double EndPt2)
        {
            try
            {
                MoveArc(Axis1, Axis2, ECircType.CenterEnd, EMoveType.Abs, Dir, CenterPt1, CenterPt2, EndPt1, EndPt2, 0);
            }
            catch { throw; }
        }
        public void MoveArcThruEndRel(TAxis Axis1, TAxis Axis2, ECircDir Dir, double ThruPt1, double ThruPt2, double EndPt1, double EndPt2)
        {
            try
            {
                MoveArc(Axis1, Axis2, ECircType.ThruEnd, EMoveType.Rel, Dir, ThruPt1, ThruPt2, EndPt1, EndPt2, 0);
            }
            catch { throw; }
        }
        public void MoveArcThruEndAbs(TAxis Axis1, TAxis Axis2, ECircDir Dir, double ThruPt1, double ThruPt2, double EndPt1, double EndPt2)
        {
            try
            {
                MoveArc(Axis1, Axis2, ECircType.ThruEnd, EMoveType.Abs, Dir, ThruPt1, ThruPt2, EndPt1, EndPt2, 0);
            }
            catch { throw; }
        }
        public void MoveArcCenterAngleRel(TAxis Axis1, TAxis Axis2, ECircDir Dir, double CenterPt1, double CenterPt2, ushort Angle_Deg)
        {
            try
            {
                MoveArc(Axis1, Axis2, ECircType.CenterAngle, EMoveType.Rel, Dir, CenterPt1, CenterPt2, 0, 0, Angle_Deg);
            }
            catch { throw; }
        }
        public void MoveArcCenterAngleAbs(TAxis Axis1, TAxis Axis2, ECircDir Dir, double CenterPt1, double CenterPt2, ushort Angle_Deg)
        {
            try
            {
                MoveArc(Axis1, Axis2, ECircType.CenterAngle, EMoveType.Abs, Dir, CenterPt1, CenterPt2, 0, 0, Angle_Deg);
            }
            catch { throw; }
        }
        #endregion

        private GroupState GroupState(TAxis[] Axis)
        {
            Mutex.WaitOne();
            try
            {
                UInt16 State = 0;
                for (int i = 0; i < MaxGroup(Axis[0].Device); i++)
                {

                    if (p_GroupHandle[Axis[0].Device.ID, i] != (IntPtr)0)
                    {
                        UInt32 AxesInGroup = 0;
                        uint BufLen = 4;
                        uint Res = 0;
                        Res = Motion.mAcm_GetProperty(p_GroupHandle[Axis[0].Device.ID, i], (uint)PropertyID.CFG_GpAxesInGroup, ref AxesInGroup, ref BufLen);
                        if (Res != (int)ErrorCode.SUCCESS)
                        {
                            throw new Exception(GetErrorMessage1(Res));
                        }

                        uint Mask = 0x0001;
                        Mask = Mask << Axis[0].Mask;

                        if ((AxesInGroup & Mask) == Mask)
                        {
                            Res = Motion.mAcm_GpGetState(p_GroupHandle[Axis[0].Device.ID, i], ref State);
                            if (Res != (int)ErrorCode.SUCCESS)
                            {
                                throw new Exception(GetErrorMessage1(Res));
                            }
                            break;
                        }
                    }
                }
                return (Advantech.Motion.GroupState)State;
            }
            catch
            {
                throw;
            }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }
        public bool AxisBusy(TAxis[] Axis)
        {
            try
            {
                if (Axis.Count() == 0)
                {
                    throw new Exception("AxisBusy, Invalid Axis");
                }
                else
                    if (Axis.Count() == 1)
                {
                    Advantech.Motion.AxisState State = AxisState(Axis[0]);
                    switch (State)
                    {
                        case Advantech.Motion.AxisState.STA_AX_DISABLE:
                        case Advantech.Motion.AxisState.STA_AX_READY:
                        case Advantech.Motion.AxisState.STA_AX_ERROR_STOP:
                            return false;
                        case Advantech.Motion.AxisState.STA_AX_BUSY:
                        case Advantech.Motion.AxisState.STA_AX_CONTI_MOT:
                        case Advantech.Motion.AxisState.STA_AX_EXT_JOG:
                        case Advantech.Motion.AxisState.STA_AX_EXT_MPG:
                        case Advantech.Motion.AxisState.STA_AX_HOMING:
                        case Advantech.Motion.AxisState.STA_AX_PAUSE:
                        case Advantech.Motion.AxisState.STA_AX_PTP_MOT:
                        case Advantech.Motion.AxisState.STA_AX_STOPPING:
                        case Advantech.Motion.AxisState.STA_AX_SYNC_MOT:
                        default:
                            return true;
                    }
                }
                else
                {
                    Advantech.Motion.GroupState State = GroupState(Axis[0]);
                    switch (State)
                    {
                        case Advantech.Motion.GroupState.STA_GP_AX_MOTION:
                        case Advantech.Motion.GroupState.STA_GP_BUSY:
                        case Advantech.Motion.GroupState.STA_Gp_Motion:
                        case Advantech.Motion.GroupState.STA_GP_Pathing:
                        case Advantech.Motion.GroupState.STA_GP_PAUSE:
                        case Advantech.Motion.GroupState.STA_Gp_Stopping:
                            return true;
                        case Advantech.Motion.GroupState.STA_Gp_ErrorStop:
                        case Advantech.Motion.GroupState.STA_Gp_Disable:
                        case Advantech.Motion.GroupState.STA_Gp_Ready:
                        default:
                            return false;
                    }
                }
            }
            catch { throw; };
        }

        private void MoveDirect(TAxis[] Axis, EMoveType MoveType, double[] EndPt)
        {
            if (Axis.Count() == 0)
            {
                throw new Exception("MoveDirect, Invalid Axis");
            }
            else
                if (Axis.Count() == 1)
            {
                throw new Exception("MoveDirect, Single Axis");
            }
            else
                    if (Axis.Count() >= 8)
            {
                throw new Exception("MoveDirect, Axis Count Exceed");
            }

            Mutex.WaitOne();
            try
            {
                IntPtr GrpHnd = CreateGroup(Axis);
                uint NumAxis = (uint)Axis.Count();
                uint Res = 0;
                if (MoveType == EMoveType.Abs)
                    Res = Motion.mAcm_GpMoveDirectAbs(GrpHnd, EndPt, ref NumAxis);
                else
                    Res = Motion.mAcm_GpMoveDirectRel(GrpHnd, EndPt, ref NumAxis);

                if (Res != (int)ErrorCode.SUCCESS) throw new Exception("MoveDirect, " + GetErrorMessage1(Res));
            }
            catch
            {
                throw;
            }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }
        public void MoveDirectAbs(TAxis[] Axis, double[] EndPt)
        {
            try
            {
                MoveDirect(Axis, EMoveType.Abs, EndPt);
            }
            catch { throw; }
        }
        public void MoveDirectRel(TAxis[] Axis, double[] EndPt)
        {
            try
            {
                MoveDirect(Axis, EMoveType.Rel, EndPt);
            }
            catch { throw; }
        }

        private void MoveLine(TAxis[] Axis, EMoveType MoveType, double[] EndPt)
        {
            if (Axis.Count() == 0)
            {
                throw new Exception("MoveDirect, Invalid Axis");
            }
            else
                if (Axis.Count() == 1)
            {
                throw new Exception("MoveDirect, Single Axis");
            }
            else
                    if (Axis.Count() >= 8)
            {
                throw new Exception("MoveDirect, Axis Count Exceed");
            }

            Mutex.WaitOne();
            try
            {
                IntPtr GrpHnd = CreateGroup(Axis);

                //#region Invert Axis Pt
                //for (int i = 0; i < Axis.Count(); i++)
                //{
                //    if (Axis[i].Para.InvertPulse)
                //    {
                //        EndPt[i] = -EndPt[i];
                //    }
                //}
                //#endregion

                uint NumAxis = (uint)Axis.Count();
                uint Res = 0;
                if (MoveType == EMoveType.Abs)
                    Res = Motion.mAcm_GpMoveLinearAbs(GrpHnd, EndPt, ref NumAxis);
                else
                    Res = Motion.mAcm_GpMoveLinearRel(GrpHnd, EndPt, ref NumAxis);

                if (Res != (int)ErrorCode.SUCCESS) throw new Exception("MoveLine, " + GetErrorMessage1(Res));
            }
            catch
            {
                throw;
            }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }
        public void MoveLineAbs(TAxis[] Axis, double[] EndPt)
        {
            try
            {
                MoveLine(Axis, EMoveType.Abs, EndPt);
            }
            catch { throw; }
        }
        public void MoveLineRel(TAxis[] Axis, double[] EndPt)
        {
            try
            {
                MoveLine(Axis, EMoveType.Rel, EndPt);
            }
            catch { throw; }
        }

        #region Motion Path - Old
        public enum EMoveCmd
        {
            EndPath = 0,
            Abs2DLine = 1,
            Rel2DLine = 2,
            Abs2DArcCW = 3,
            Abs2DArcCCW = 4,
            Rel2DArcCW = 5,
            Rel2DArcCCW = 6,
            DoControl = (int)Advantech.Motion.PathCmd.DOControl,
            Delay = 29,
        }
        public void PathAdd(TAxis Axis1, TAxis Axis2, EMoveCmd MoveCmd, bool Blend, double StartV, double DriveV_Delay, double EndPt1, double EndPt2, double Center1, double Center2)
        {
            uint Res = 0;

            //Bit       24~31   16~23       8~15    0~7
            //Assign    Resv    DO0~7       Resv    DO0~7
            //                  0: Disable          0: Close
            //                  1: Enable           1: Open

            double[] DoControlBit = new double[2] { 0x00800000, 0x00800000 };
            if (MoveCmd == EMoveCmd.DoControl)
            {
                if (EndPt1 > 0)
                    DoControlBit = new double[2] { 0x00800080, 0x00800080 };
            }

            double[] CenterArr = new double[2] { Center1, Center2 };
            double[] EndPtArr = new double[2] { EndPt1, EndPt2 };
            uint AxisNum = 2;

            Mutex.WaitOne();
            try
            {
                #region Create Group
                bool b_AxisInGroup = false;
                int i_GroupIndex = 0;

                //check group handle and add to existing group handle
                for (int i = 0; i < MaxGroup(Axis1.Device); i++)
                {
                    #region
                    if (p_GroupHandle[Axis1.Device.ID, i] != (IntPtr)0)
                    {
                        UInt32 AxesInGroup = 0;
                        uint BufLen = 4;
                        Res = Motion.mAcm_GetProperty(p_GroupHandle[Axis1.Device.ID, i], (uint)PropertyID.CFG_GpAxesInGroup, ref AxesInGroup, ref BufLen);
                        if (Res != (int)ErrorCode.SUCCESS)
                        {
                            throw new Exception(GetErrorMessage1(Res));
                        }

                        //check Axis1(primary axis) in group
                        uint Mask1 = 0x0001;
                        Mask1 = Mask1 << Axis1.Mask;
                        if ((AxesInGroup & Mask1) != Mask1) continue;

                        if (MoveCmd == 0)
                        {
                            Res = Motion.mAcm_GpAddPath(p_GroupHandle[Axis1.Device.ID, i], (ushort)MoveCmd, 0, DriveV_Delay, StartV, EndPtArr, CenterArr, ref AxisNum);
                            if (Res != (int)ErrorCode.SUCCESS)
                            {
                                throw new Exception(GetErrorMessage1(Res));
                            }
                            return;
                        }

                        //check Axis2 in group, add if none
                        uint Mask2 = 0x0001;
                        Mask2 = Mask2 << Axis2.Mask;
                        if ((AxesInGroup & Mask2) != Mask2)
                        {
                            Res = Motion.mAcm_GpAddAxis(ref p_GroupHandle[Axis2.Device.ID, i], p_AxisHandle[Axis2.Device.ID, Axis2.Mask]);
                            if (Res != (int)ErrorCode.SUCCESS)
                            {
                                throw new Exception(GetErrorMessage1(Res));
                            }
                        }

                        AxesInGroup = AxesInGroup & (Mask1 ^ 0xFFFF);
                        AxesInGroup = AxesInGroup & (Mask2 ^ 0xFFFF);

                        #region Remove redundant axis
                        if (AxesInGroup > 0)
                        {
                            for (int j = 0; j < MAX_AXIS; j++)
                            {
                                uint M = 0x0001;
                                M = M << j;
                                if ((AxesInGroup & (0x0001 << j)) == (0x0001 << j))
                                {
                                    Res = Motion.mAcm_GpRemAxis(p_GroupHandle[Axis2.Device.ID, i], p_AxisHandle[Axis2.Device.ID, (int)Math.Pow(2, i)]);
                                    if (Res != (int)ErrorCode.SUCCESS)
                                    {
                                        throw new Exception(GetErrorMessage1(Res));
                                    }
                                }
                            }
                        }
                        #endregion
                        b_AxisInGroup = true;
                        i_GroupIndex = i;
                        break;
                    }
                    #endregion
                }

                if (!b_AxisInGroup)
                {
                    //create new group handle
                    for (int i = 0; i < MaxGroup(Axis1.Device); i++)
                    {
                        if (p_GroupHandle[Axis1.Device.ID, i] == (IntPtr)0)
                        {
                            Res = Motion.mAcm_GpAddAxis(ref p_GroupHandle[Axis1.Device.ID, i], p_AxisHandle[Axis1.Device.ID, Axis1.Mask]);
                            if (Res != (int)ErrorCode.SUCCESS)
                            {
                                throw new Exception(GetErrorMessage1(Res));
                            }

                            Res = Motion.mAcm_GpAddAxis(ref p_GroupHandle[Axis2.Device.ID, i], p_AxisHandle[Axis2.Device.ID, Axis2.Mask]);
                            if (Res != (int)ErrorCode.SUCCESS)
                            {
                                throw new Exception(GetErrorMessage1(Res));
                            }

                            i_GroupIndex = i;
                            break;
                        }
                    }
                }
                #endregion

                #region Add Paths
                double Jerk = 0;//jerk not supported for blending path.
                Res = Motion.mAcm_SetProperty(p_GroupHandle[Axis1.Device.ID, i_GroupIndex], (uint)PropertyID.PAR_GpJerk, ref Jerk, 8);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }

                uint GpSFEnable = (UInt32)Advantech.Motion.SFEnable.SF_DIS;//disable SF, individual path have different speed.
                Res = Motion.mAcm_SetProperty(p_GroupHandle[Axis1.Device.ID, i_GroupIndex], (uint)PropertyID.CFG_GpSFEnable, ref GpSFEnable, 4);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }

                bool CW = true;
                switch (MoveCmd)//handle invert axis
                {
                    case EMoveCmd.Abs2DArcCW:
                        CW = true;
                        break;
                    case EMoveCmd.Abs2DArcCCW:
                        CW = false;
                        break;
                    case EMoveCmd.Rel2DArcCW:
                        CW = true;
                        break;
                    case EMoveCmd.Rel2DArcCCW:
                        CW = false;
                        break;
                }

                switch (MoveCmd)//handle invert axis
                {
                    case EMoveCmd.Abs2DArcCW:
                        if (!CW) MoveCmd = EMoveCmd.Abs2DArcCCW;
                        break;
                    case EMoveCmd.Abs2DArcCCW:
                        if (CW) MoveCmd = EMoveCmd.Abs2DArcCW;
                        break;
                    case EMoveCmd.Rel2DArcCW:
                        if (!CW) MoveCmd = EMoveCmd.Rel2DArcCCW;
                        break;
                    case EMoveCmd.Rel2DArcCCW:
                        if (CW) MoveCmd = EMoveCmd.Rel2DArcCW;
                        break;
                }

                ushort Blending = 0;
                if (Blend) Blending = 1;
                switch (MoveCmd)
                {
                    case EMoveCmd.EndPath:
                        Res = Motion.mAcm_GpAddPath(p_GroupHandle[Axis1.Device.ID, i_GroupIndex], (ushort)MoveCmd, (ushort)Blending, 0, 0, null, null, ref AxisNum);
                        break;
                    case EMoveCmd.DoControl:
                        Res = Motion.mAcm_GpAddPath(p_GroupHandle[Axis1.Device.ID, i_GroupIndex], (ushort)MoveCmd, 0, 0, 0, DoControlBit, null, ref AxisNum);
                        break;
                    default:
                        Res = Motion.mAcm_GpAddPath(p_GroupHandle[Axis1.Device.ID, i_GroupIndex], (ushort)MoveCmd, (ushort)Blending, DriveV_Delay, StartV, EndPtArr, CenterArr, ref AxisNum);
                        break;
                }
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }
                #endregion
            }
            catch
            {
                throw;
            }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }

        //public void PathAddLineAbs(TAxis Axis1, TAxis Axis2, double StartV, double DriveV, double Pt1, double Pt2)
        //{
        //    try
        //    {
        //        //if (InvertPulse[Axis1.Device.ID, Axis1.Mask]) Pt1 = -Pt1;
        //        //if (InvertPulse[Axis2.Device.ID, Axis2.Mask]) Pt2 = -Pt2;

        //        PathAdd(Axis1, Axis2, EMoveCmd.Abs2DLine, false, StartV, DriveV, Pt1, Pt2, 0, 0);
        //    }
        //    catch { throw; }
        //}
        //public void PathAddLineRel(TAxis Axis1, TAxis Axis2, double StartV, double DriveV, double Pt1, double Pt2)
        //{
        //    try
        //    {
        //        //if (InvertPulse[Axis1.Device.ID, Axis1.Mask]) Pt1 = -Pt1;
        //        //if (InvertPulse[Axis2.Device.ID, Axis2.Mask]) Pt2 = -Pt2;

        //        PathAdd(Axis1, Axis2, EMoveCmd.Rel2DLine, false, StartV, DriveV, Pt1, Pt2, 0, 0);
        //    }
        //    catch { throw; }
        //}
        //public void PathAddCircleAbs(TAxis Axis1, TAxis Axis2, double StartV, double DriveV, ECircDir Dir, double Center1, double Center2, double Pt1, double Pt2)
        //{
        //    try
        //    {
        //        //if (InvertPulse[Axis1.Device.ID, Axis1.Mask])
        //        //{
        //        //    Center1 = -Center1;
        //        //    Pt1 = -Pt1;
        //        //}
        //        //if (InvertPulse[Axis2.Device.ID, Axis2.Mask])
        //        //{
        //        //    Center2 = -Center2;
        //        //    Pt2 = -Pt2;
        //        //}

        //        if (Dir == ECircDir.CW)
        //            PathAdd(Axis1, Axis2, EMoveCmd.Abs2DArcCW, false, StartV, DriveV, Pt1, Pt2, Center1, Center2);
        //        else
        //            PathAdd(Axis1, Axis2, EMoveCmd.Abs2DArcCCW, false, StartV, DriveV, Pt1, Pt2, Center1, Center2);
        //    }
        //    catch { throw; }
        //}
        //public void PathAddCircleRel(TAxis Axis1, TAxis Axis2, double StartV, double DriveV, ECircDir Dir, double Center1, double Center2, double Pt1, double Pt2)
        //{
        //    try
        //    {
        //        //if (InvertPulse[Axis1.Device.ID, Axis1.Mask])
        //        //{
        //        //    Center1 = -Center1;
        //        //    Pt1 = -Pt1;
        //        //}
        //        //if (InvertPulse[Axis2.Device.ID, Axis2.Mask])
        //        //{
        //        //    Center2 = -Center2;
        //        //    Pt2 = -Pt2;
        //        //}

        //        if (Dir == ECircDir.CW)
        //            PathAdd(Axis1, Axis2, EMoveCmd.Rel2DArcCW, false, StartV, DriveV, Pt1, Pt2, Center1, Center2);
        //        else
        //            PathAdd(Axis1, Axis2, EMoveCmd.Rel2DArcCCW, false, StartV, DriveV, Pt1, Pt2, Center1, Center2);
        //    }
        //    catch { throw; }
        //}
        public void PathEnd(TAxis MasterAxis)
        {
            try
            {
                PathAdd(MasterAxis, MasterAxis, EMoveCmd.EndPath, false, 0, 0, 0, 0, 0, 0);
            }
            catch { throw; }
        }

        public void PathMove(TAxis MasterAxis)
        {
            Mutex.WaitOne();
            try
            {
                for (int i = 0; i < MaxGroup(MasterAxis.Device) + 1; i++)
                {
                    if (i == MaxGroup(MasterAxis.Device))
                    {
                        throw new Exception("No Path Created.");
                    }

                    if (p_GroupHandle[MasterAxis.Device.ID, i] != (IntPtr)0)
                    {
                        UInt32 AxesInGroup = 0;
                        uint BufLen = 4;
                        uint Res = 0;
                        Res = Motion.mAcm_GetProperty(p_GroupHandle[MasterAxis.Device.ID, i], (uint)PropertyID.CFG_GpAxesInGroup, ref AxesInGroup, ref BufLen);
                        if (Res != (int)ErrorCode.SUCCESS)
                        {
                            throw new Exception(GetErrorMessage1(Res));
                        }

                        uint Mask = 0x0001;
                        Mask = Mask << MasterAxis.Mask;

                        if ((AxesInGroup & Mask) == Mask)
                        {
                            Res = Motion.mAcm_GpMovePath(p_GroupHandle[MasterAxis.Device.ID, i], IntPtr.Zero);
                            if (Res != (int)ErrorCode.SUCCESS)
                            {
                                throw new Exception(GetErrorMessage1(Res));
                            }
                            break;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }
        public void PathFree(TAxis MasterAxis)
        {
            Mutex.WaitOne();
            try
            {
                for (int i = 0; i < MaxGroup(MasterAxis.Device) + 1; i++)
                {
                    if (i == MaxGroup(MasterAxis.Device))
                    {
                        throw new Exception("No avail group.");
                    }

                    if (p_GroupHandle[MasterAxis.Device.ID, i] == (IntPtr)0) continue;

                    UInt32 AxesInGroup = 0;
                    uint BufLen = 4;
                    uint Res = 0;
                    Res = Motion.mAcm_GetProperty(p_GroupHandle[MasterAxis.Device.ID, i], (uint)PropertyID.CFG_GpAxesInGroup, ref AxesInGroup, ref BufLen);
                    if (Res != (int)ErrorCode.SUCCESS)
                    {
                        throw new Exception(GetErrorMessage1(Res));
                    }

                    uint Mask = 0x0001;
                    Mask = Mask << MasterAxis.Mask;

                    if ((AxesInGroup & Mask) == Mask)
                    {
                        Res = Motion.mAcm_GpResetPath(ref p_GroupHandle[MasterAxis.Device.ID, i]);
                        if (Res != (int)ErrorCode.SUCCESS)
                        {
                            throw new Exception(GetErrorMessage1(Res));
                        }
                        break;
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }
        public void PathInfo(TAxis MasterAxis, ref uint IndexNo, ref uint CurCmd, ref uint Remain)
        {
            Mutex.WaitOne();
            try
            {
                for (int i = 0; i < MaxGroup(MasterAxis.Device) + 1; i++)
                {
                    if (i == MaxGroup(MasterAxis.Device))
                    {
                        throw new Exception("No Path Created.");
                    }

                    if (p_GroupHandle[MasterAxis.Device.ID, i] == (IntPtr)0) continue;

                    UInt32 AxesInGroup = 0;
                    uint BufLen = 4;
                    uint Res = 0;
                    Res = Motion.mAcm_GetProperty(p_GroupHandle[MasterAxis.Device.ID, i], (uint)PropertyID.CFG_GpAxesInGroup, ref AxesInGroup, ref BufLen);
                    if (Res != (int)ErrorCode.SUCCESS)
                    {
                        throw new Exception(GetErrorMessage1(Res));
                    }

                    uint Mask = 0x0001;
                    Mask = Mask << MasterAxis.Mask;

                    if ((AxesInGroup & Mask) == Mask)
                    {
                        uint FreeCnt = new uint();
                        Res = Motion.mAcm_GpGetPathStatus(p_GroupHandle[MasterAxis.Device.ID, i], ref IndexNo, ref CurCmd, ref Remain, ref FreeCnt);
                        if (Res != (int)ErrorCode.SUCCESS)
                        {
                            throw new Exception(GetErrorMessage1(Res));
                        }
                        break;
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }

        public void PathBlendTime(TAxis MasterAxis, uint BlendTime)
        {
            uint Res = 0;

            Mutex.WaitOne();
            try
            {
                for (int i = 0; i < MaxGroup(MasterAxis.Device) + 1; i++)
                {
                    if (i == MaxGroup(MasterAxis.Device))
                    {
                        throw new Exception("No Group Created.");
                    }

                    if (p_GroupHandle[MasterAxis.Device.ID, i] == (IntPtr)0) continue;

                    UInt32 AxesInGroup = 0;
                    uint BufLen = 4;
                    Res = Motion.mAcm_GetProperty(p_GroupHandle[MasterAxis.Device.ID, i], (uint)PropertyID.CFG_GpAxesInGroup, ref AxesInGroup, ref BufLen);
                    if (Res != (int)ErrorCode.SUCCESS)
                    {
                        throw new Exception(GetErrorMessage1(Res));
                    }

                    uint Mask = 0x0001;
                    Mask = Mask << MasterAxis.Mask;

                    if ((AxesInGroup & Mask) == Mask)
                    {
                        Res = Motion.mAcm_SetProperty(p_GroupHandle[MasterAxis.Device.ID, i], (uint)PropertyID.CFG_GpBldTime, ref BlendTime, 4);
                        if (Res != (int)ErrorCode.SUCCESS)
                        {
                            throw new Exception(GetErrorMessage1(Res));
                        }
                        break;
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }
        #endregion

        #region Motion Path
        public enum EPath_MoveCmd
        {
            //EndPath = 0,
            Abs2DLine = 1,
            Rel2DLine = 2,
            //Rel2DLine = 
            Abs2DArcCW = 3,
            Abs2DArcCCW = 4,
            Rel2DArcCW = 5,
            Rel2DArcCCW = 6,
            Abs3DLine = 7,
            Rel3DLine = 8,
            AbsMultiLine = 9,
            RelMultiLine = 10,
            Abs2DDirect = 11,
            Rel2DDirect = 12,
            Abs3DDirect = 13,
            Rel3DDirect = 14,
            Abs4DDirect = 15,
            Rel4DDirect = 16,
            Abs5DDirect = 17,
            Rel5DDirect = 18,
            Abs6DDirect = 19,
            Rel6DDirect = 20,
            Abs3DArcCW = 21,
            Rel3DArcCW = 22,
            Abs3DArcCCW = 23,
            Rel3DArcCCW = 24,
            Abs3DHelixCW = 25,
            Rel3DHelixCW = 26,
            Abs3DHelixCCW = 27,
            Rel3DHelixCCW = 28,
            GPDELAY = 29,
            Abs4DHelixCW = 30,
            Rel4DHelixCW = 31,
            Abs4DHelixCCW = 32,
            Rel4DHelixCCW = 33,
            Abs5DHelixCW = 34,
            Rel5DHelixCW = 35,
            Abs5DHelixCCW = 36,
            Rel5DHelixCCW = 37,
            Abs6DHelixCW = 38,
            Rel6DHelixCW = 39,
            Abs6DHelixCCW = 40,
            Rel6DHelixCCW = 41,
            Abs7DHelixCW = 42,
            Rel7DHelixCW = 43,
            Abs7DHelixCCW = 44,
            Rel7DHelixCCW = 45,
            Abs8DHelixCW = 46,
            Rel8DHelixCW = 47,
            Abs8DHelixCCW = 48,
            Rel8DHelixCCW = 49,
            Abs2DArcCWAngle = 50,
            Rel2DArcCWAngle = 51,
            Abs2DArcCCWAngle = 52,
            Rel2DArcCCWAngle = 53,
            Abs3DArcCWAngle = 54,
            Rel3DArcCWAngle = 55,
            Abs3DArcCCWAngle = 56,
            Rel3DArcCCWAngle = 57,
            Abs3DHelixCWAngle = 58,
            Rel3DHelixCWAngle = 59,
            Abs3DHelixCCWAngle = 60,
            Rel3DHelixCCWAngle = 61,
            Abs4DHelixCWAngle = 62,
            Rel4DHelixCWAngle = 63,
            Abs4DHelixCCWAngle = 64,
            Rel4DHelixCCWAngle = 65,
            Abs5DHelixCWAngle = 66,
            Rel5DHelixCWAngle = 67,
            Abs5DHelixCCWAngle = 68,
            Rel5DHelixCCWAngle = 69,
            Abs6DHelixCWAngle = 70,
            Rel6DHelixCWAngle = 71,
            Abs6DHelixCCWAngle = 72,
            Rel6DHelixCCWAngle = 73,
            Abs7DHelixCWAngle = 74,
            Rel7DHelixCWAngle = 75,
            Abs7DHelixCCWAngle = 76,
            Rel7DHelixCCWAngle = 77,
            Abs8DHelixCWAngle = 78,
            Rel8DHelixCWAngle = 79,
            Abs8DHelixCCWAngle = 80,
            Rel8DHelixCCWAngle = 81,
            Abs7DDirect = 82,
            Rel7DDirect = 83,
            Abs8DDirect = 84,
            Rel8DDirect = 85,
            Abs2DArcCW_3P = 86,
            Rel2DArcCW_3P = 87,
            Abs2DArcCCW_3P = 88,
            Rel2DArcCCW_3P = 89,
            //DOControl = 90,
            Abs1DDirect = 91,
            Rel1DDirect = 92,
        }
        private IntPtr CreateGroup(TAxis[] Axis)
        {
            uint Res = 0;

            if (Axis == null) throw new Exception("Create Group, Null Axis");

            if (Axis.Count() > MaxAxisInGroup(Axis[0].Device)) throw new Exception("Create Group, Exceed Group Max Axis");

            try
            {
                //Mutex.WaitOne();

                bool b_AxisInGroup = false;
                int i_GroupIndex = 0;

                #region Check Primary Axis in the groups.
                for (int i = 0; i < MaxGroup(Axis[0].Device); i++)
                {
                    #region
                    if (p_GroupHandle[Axis[0].Device.ID, i] != (IntPtr)0)
                    {
                        UInt32 AxesInGroup = 0;
                        uint BufLen = 4;
                        Res = Motion.mAcm_GetProperty(p_GroupHandle[Axis[0].Device.ID, i], (uint)PropertyID.CFG_GpAxesInGroup, ref AxesInGroup, ref BufLen);
                        if (Res != (int)ErrorCode.SUCCESS)
                        {
                            throw new Exception("Create Group, " + GetErrorMessage1(Res));
                        }

                        #region Check primary axis is in group
                        UInt32 AxesAddToGroup = 0;//Axis need to be added to group
                        uint Mask1 = 0x0001;
                        Mask1 = Mask1 << Axis[0].Mask;
                        if ((AxesInGroup & Mask1) != Mask1) continue;
                        AxesAddToGroup = Mask1;
                        #endregion
                        //if (MoveCmd == 0)
                        //{
                        //    Res = Motion.mAcm_GpAddPath(p_GroupHandle[Axis1.Device.ID, i], (ushort)MoveCmd, 0, DriveV_Delay, StartV, EndPtArr, CenterArr, ref AxisNum);
                        //    if (Res != (int)ErrorCode.SUCCESS)
                        //    {
                        //        throw new Exception(GetErrorMessage(Res));
                        //    }
                        //    Mutex.ReleaseMutex();
                        //    return;
                        //}

                        #region Check sub axis in group, add if none
                        for (int j = 1; j < Axis.Count(); j++)
                        {
                            uint MaskN = 0x0001;
                            MaskN = MaskN << Axis[j].Mask;
                            if ((AxesInGroup & MaskN) != MaskN)
                            {
                                Res = Motion.mAcm_GpAddAxis(ref p_GroupHandle[Axis[0].Device.ID, i], p_AxisHandle[Axis[0].Device.ID, Axis[j].Mask]);
                                if (Res != (int)ErrorCode.SUCCESS)
                                {
                                    throw new Exception("Create Group, " + GetErrorMessage1(Res));
                                }
                            }
                            AxesAddToGroup = AxesAddToGroup | MaskN;
                        }

                        UInt32 AxesRedundantInGroup = AxesInGroup & (AxesAddToGroup ^ 0xFFFF);
                        #endregion
                        //AxesInGroup = AxesInGroup & (Mask1 ^ 0xFFFF);
                        //AxesInGroup = AxesInGroup & (Mask2 ^ 0xFFFF);

                        #region Remove redundant axis
                        if (AxesRedundantInGroup > 0)
                        {
                            for (int j = 0; j < MAX_AXIS; j++)
                            {
                                uint M = 0x0001;
                                M = M << j;
                                if ((AxesRedundantInGroup & (0x0001 << j)) == (0x0001 << j))
                                {
                                    Res = Motion.mAcm_GpRemAxis(p_GroupHandle[Axis[0].Device.ID, i], p_AxisHandle[Axis[0].Device.ID, (int)Math.Pow(2, j)]);
                                    if (Res != (int)ErrorCode.SUCCESS)
                                    {
                                        throw new Exception(GetErrorMessage1(Res));
                                    }
                                }
                            }
                        }
                        #endregion
                        b_AxisInGroup = true;
                        i_GroupIndex = i;
                        b_AxisInGroup = true;
                        break;
                    }
                    #endregion
                }
                #endregion

                if (!b_AxisInGroup)
                {
                    #region Create new group handle
                    for (int i = 0; i < MaxGroup(Axis[0].Device); i++)
                    {
                        if (p_GroupHandle[Axis[0].Device.ID, i] == (IntPtr)0)
                        {
                            for (int j = 0; j < Axis.Count(); j++)
                            {
                                Res = Motion.mAcm_GpAddAxis(ref p_GroupHandle[Axis[0].Device.ID, i], p_AxisHandle[Axis[0].Device.ID, Axis[j].Mask]);
                                if (Res != (int)ErrorCode.SUCCESS)
                                {
                                    throw new Exception(GetErrorMessage1(Res));
                                }
                            }
                            //Res = Motion.mAcm_GpAddAxis(ref p_GroupHandle[Axis2.Device.ID, i], p_AxisHandle[Axis2.Device.ID, Axis2.Mask]);
                            //if (Res != (int)ErrorCode.SUCCESS)
                            //{
                            //    throw new Exception(GetErrorMessage(Res));
                            //}

                            i_GroupIndex = i;
                            break;
                            //return p_GroupHandle[Axis[0].Device.ID, i];
                        }
                    }
                    #endregion
                }

                //return p_GroupHandle[Axis[0].Device.ID, i_GroupIndexi];

                //Mutex.ReleaseMutex();
                return p_GroupHandle[Axis[0].Device.ID, i_GroupIndex];
                //return (IntPtr)0;
            }
            catch
            {
                //Mutex.ReleaseMutex();
                throw;
            }
        }
        public void PathBlendTime(TAxis[] Axis, uint BlendTime)
        {
            Mutex.WaitOne();
            try
            {
                IntPtr GrpHnd = CreateGroup(Axis);
                uint Res = 0;
                Res = Motion.mAcm_SetProperty(GrpHnd, (uint)PropertyID.CFG_GpBldTime, ref BlendTime, 4);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }

        public void PathAddCmd(TAxis[] Axis, EPath_MoveCmd MoveCmd, bool Blend, double FH_Delay, double FL, double[] EndPt, double[] CenterPt)
        {
            uint Res = 0;
            try
            {
                IntPtr GrpHnd = CreateGroup(Axis);

                //#region Invert Axis Pt
                //bool InvertArcDir = false;
                //for (int i = 0; i < Axis.Count(); i++)
                //{
                //    if (Axis[i].Para.InvertPulse)
                //    {
                //        if (EndPt != null) EndPt[i] = -EndPt[i];
                //        if (CenterPt != null) CenterPt[i] = -CenterPt[i];

                //        InvertArcDir = !InvertArcDir;
                //    }
                //}

                //if (InvertArcDir)
                //{
                //    switch (MoveCmd)
                //    {
                //        case EPath_MoveCmd.Abs2DArcCW:
                //            MoveCmd = EPath_MoveCmd.Abs2DArcCCW;
                //            break;
                //        case EPath_MoveCmd.Abs2DArcCCW:
                //            MoveCmd = EPath_MoveCmd.Abs2DArcCW;
                //            break;
                //        case EPath_MoveCmd.Rel2DArcCW:
                //            MoveCmd = EPath_MoveCmd.Rel2DArcCCW;
                //            break;
                //        case EPath_MoveCmd.Rel2DArcCCW:
                //            MoveCmd = EPath_MoveCmd.Rel2DArcCW;
                //            break;
                //    }
                //}
                //#endregion

                ushort Blending = 0;
                if (Blend) Blending = 1;
                uint AxisNum = (uint)Axis.Count();

                if (EndPt != null)
                {
                    if (EndPt.ToList().Select(x => Math.Abs(x)).Sum() == 0)
                    {
                        return;
                    }
                }

                Res = Motion.mAcm_GpAddPath(GrpHnd, (ushort)MoveCmd, (ushort)Blending, FH_Delay, FL, EndPt, CenterPt, ref AxisNum);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception("PathAddCmd, " + GetErrorMessage1(Res));
                }
            }
            catch
            {
                throw;
            }
        }
        public void PathAddDO(TAxis[] Axis, TOutput[] Output, bool On)
        {
            //Bit       24~31   16~23       8~15    0~7
            //Assign    Resv    DO0~7       Resv    DO0~7
            //                  0: Disable          0: Close
            //                  1: Enable           1: Open
            //double[] DoControlBit = new double[2] { 0x00800000, 0x00800000 };
            //if (MoveCmd == EMoveCmd.DoControl)
            //{
            //    if (EndPt1 > 0)
            //        DoControlBit = new double[2] { 0x00800080, 0x00800080 };
            //}

            uint Res = 0;
            try
            {
                IntPtr GrpHnd = CreateGroup(Axis);

                uint[] DOBit = new uint[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                uint[] DOEnableBit = new uint[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                #region Check Output Axis in group
                for (int i = 0; i < Output.Count(); i++)
                {
                    for (int j = 0; j < Axis.Count(); j++)
                    {
                        if (Output[i].Axis_Port == Axis[j].Mask)
                        {
                            DOBit[j] = DOBit[j] | Output[i].Mask;
                            DOEnableBit[j] = DOBit[j];
                        }
                    }
                }
                #endregion
                #region Set DO Bit
                for (int j = 0; j < 8; j++)
                {
                    DOBit[j] = DOBit[j] << 20;
                    if (On)
                    {
                        DOEnableBit[j] = DOEnableBit[j] << 4;
                        DOBit[j] = DOBit[j] | DOEnableBit[j];
                    }
                }
                #endregion
                double[] d_DOBit = new double[8] { DOBit[0], DOBit[1], DOBit[2], DOBit[3], DOBit[4], DOBit[5], DOBit[6], DOBit[7] };

                uint AxisNum = (uint)Axis.Count();
                Res = Motion.mAcm_GpAddPath(GrpHnd, (ushort)Advantech.Motion.PathCmd.DOControl, 0, 0, 0, d_DOBit, null, ref AxisNum);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception("Path Add DO, " + GetErrorMessage1(Res));
                }
            }
            catch
            {
                throw;
            }
        }
        public void PathAddDO(TAxis[] Axis, TOutput[] Output, bool[] On)
        {
            //Bit       24~31   16~23       8~15    0~7
            //Assign    Resv    DO0~7       Resv    DO0~7
            //                  0: Disable          0: Close
            //                  1: Enable           1: Open
            //double[] DoControlBit = new double[2] { 0x00800000, 0x00800000 };
            //if (MoveCmd == EMoveCmd.DoControl)
            //{
            //    if (EndPt1 > 0)
            //        DoControlBit = new double[2] { 0x00800080, 0x00800080 };
            //}

            uint Res = 0;
            try
            {
                if (Output.Count() != On.Count()) throw new Exception("Output and On Array count do not match.");

                IntPtr GrpHnd = CreateGroup(Axis);

                uint[] DOBitSelect = new uint[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                uint[] DOBitOn = new uint[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                #region Check Output Axis in group
                for (int i = 0; i < Output.Count(); i++)
                {
                    for (int j = 0; j < Axis.Count(); j++)
                    {
                        if (Output[i].Axis_Port == Axis[j].Mask)
                        {
                            DOBitSelect[j] = DOBitSelect[j] | Output[i].Mask;
                            if (On[i])
                                DOBitOn[j] = DOBitSelect[j];
                        }
                    }
                }
                #endregion
                #region Set DO Bit
                for (int j = 0; j < 8; j++)
                {
                    DOBitSelect[j] = DOBitSelect[j] << 20;
                    DOBitOn[j] = DOBitOn[j] << 4;
                    DOBitSelect[j] = DOBitSelect[j] | DOBitOn[j];
                }
                #endregion
                double[] d_DOBit = new double[8] { DOBitSelect[0], DOBitSelect[1], DOBitSelect[2], DOBitSelect[3], DOBitSelect[4], DOBitSelect[5], DOBitSelect[6], DOBitSelect[7] };

                uint AxisNum = (uint)Axis.Count();
                Res = Motion.mAcm_GpAddPath(GrpHnd, (ushort)Advantech.Motion.PathCmd.DOControl, 0, 0, 0, d_DOBit, null, ref AxisNum);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception("Path Add DO, " + GetErrorMessage1(Res));
                }
            }
            catch
            {
                throw;
            }
        }
        public void PathEnd(TAxis[] Axis)
        {
            Mutex.WaitOne();
            try
            {
                IntPtr GpHnd = CreateGroup(Axis);
                uint AxisNum = (uint)Axis.Count();
                uint Res = 0;
                Res = Motion.mAcm_GpAddPath(GpHnd, (ushort)Advantech.Motion.PathCmd.EndPath, 0, 0, 0, null, null, ref AxisNum);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception("Path End, " + GetErrorMessage1(Res));
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }

        public void PathMove(TAxis[] Axis)
        {
            Mutex.WaitOne();
            try
            {
                IntPtr GrpHnd = CreateGroup(Axis);
                uint Res = 0;
                Res = Motion.mAcm_GpMovePath(GrpHnd, IntPtr.Zero);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception("PathMove, " + GetErrorMessage1(Res));
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }
        public void PathFree(TAxis[] Axis)
        {
            Mutex.WaitOne();
            try
            {
                IntPtr GrpHnd = CreateGroup(Axis);
                uint Res = 0;

                Res = Motion.mAcm_GpResetPath(ref GrpHnd);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception("Path Free, " + GetErrorMessage1(Res));
                }

                //Jerk not supported for blending path.
                double Jerk = 0;
                Res = Motion.mAcm_SetProperty(GrpHnd, (uint)PropertyID.PAR_GpJerk, ref Jerk, 8);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception("PathAddCmd, " + GetErrorMessage1(Res));
                }

                //disable SF, individual path have different speed.
                uint GpSFEnable = (UInt32)Advantech.Motion.SFEnable.SF_DIS;
                Res = Motion.mAcm_SetProperty(GrpHnd, (uint)PropertyID.CFG_GpSFEnable, ref GpSFEnable, 4);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception("PathAddCmd, " + GetErrorMessage1(Res));
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }
        public void PathInfo(TAxis[] Axis, ref uint IndexNo, ref uint CurCmd, ref uint Remain)
        {
            Mutex.WaitOne();
            try
            {
                IntPtr GrpHnd = CreateGroup(Axis);

                uint FreeCnt = new uint();
                uint Res = 0;
                Res = Motion.mAcm_GpGetPathStatus(GrpHnd, ref IndexNo, ref CurCmd, ref Remain, ref FreeCnt);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception("PathInfo, " + GetErrorMessage1(Res));
                }
            }
            catch
            {
                throw;

            }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }
        #endregion

        #region Position/Counter
        public void GetLCntr(TAxis Axis, ref double Value)
        {
            Mutex.WaitOne();
            try
            {
                uint Res = Motion.mAcm_AxGetCmdPosition(p_AxisHandle[Axis.Device.ID, Axis.Mask], ref Value);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }
            }
            catch { throw; }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }
        public void SetLCntr(TAxis Axis, double Value)
        {
            Mutex.WaitOne();
            try
            {
                uint Res = Motion.mAcm_AxSetCmdPosition(p_AxisHandle[Axis.Device.ID, Axis.Mask], Value);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }
            }
            catch { throw; }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }
        public void GetRCntr(TAxis Axis, ref double Value)
        {
            Mutex.WaitOne();
            try
            {
                uint Res = Motion.mAcm_AxGetActualPosition(p_AxisHandle[Axis.Device.ID, Axis.Mask], ref Value);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    //Mutex.ReleaseMutex();
                    throw new Exception(GetErrorMessage1(Res));
                }
            }
            catch { throw; }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }
        public void SetRCntr(TAxis Axis, double Value)
        {
            Mutex.WaitOne();
            try
            {
                uint Res = Motion.mAcm_AxSetActualPosition(p_AxisHandle[Axis.Device.ID, Axis.Mask], Value);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }
            }
            catch { throw; }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }

        public enum ELatchPosType { Command, Actual }
        public void LatchGetCntr(TAxis Axis, ELatchPosType Pos, ref double Value)
        {
            Mutex.WaitOne();
            try
            {
                uint Res = Motion.mAcm_AxGetLatchData(p_AxisHandle[Axis.Device.ID, Axis.Mask], (uint)Pos, ref Value);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }

        public void LatchTrig(TAxis Axis)
        {
            Mutex.WaitOne();
            try
            {
                uint Res = Motion.mAcm_AxTriggerLatch(p_AxisHandle[Axis.Device.ID, Axis.Mask]);
                if (Res != (int)ErrorCode.SUCCESS) throw new Exception(GetErrorMessage1(Res));
            }
            catch
            {
                throw;
            }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }
        public void LatchReset(TAxis Axis)
        {
            Mutex.WaitOne();
            try
            {
                uint Res = Motion.mAcm_AxResetLatch(p_AxisHandle[Axis.Device.ID, Axis.Mask]);
                if (Res != (int)ErrorCode.SUCCESS) throw new Exception(GetErrorMessage1(Res));
            }
            catch
            {
                throw;
            }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }
        public bool LatchDataAvail(TAxis Axis)
        {
            Mutex.WaitOne();
            try
            {
                byte Flag = 0;
                uint Res = Motion.mAcm_AxGetLatchFlag(p_AxisHandle[Axis.Device.ID, Axis.Mask], ref Flag);
                if (Res != (int)ErrorCode.SUCCESS) throw new Exception(GetErrorMessage1(Res));

                return (Flag == 1);
            }
            catch
            {
                throw;
            }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }

        public void CmpSetData(TAxis Axis, double Value)//default 5us
        {
            Mutex.WaitOne();
            try
            {
                uint Res = Motion.mAcm_AxSetCmpData(p_AxisHandle[Axis.Device.ID, Axis.Mask], Value);
                if (Res != (int)ErrorCode.SUCCESS)
                {
                    throw new Exception(GetErrorMessage1(Res));
                }
            }
            catch { throw; }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }


        #endregion

        #region IO
        public void UpdateInput(ref TInput Input)
        {
            if (Input.Device.Type == EDeviceType.NONE) return;

            Mutex.WaitOne();
            try
            {
                uint Res = 0;
                if (Input.Device.Type == EDeviceType.P1265 && Input.Axis_Port == 6)
                {
                    #region
                    byte BitData = 0;
                    UInt16 Ch = (UInt16)Input.Mask;
                    if (Ch == 0x01) Ch = 0;
                    if (Ch == 0x02) Ch = 1;
                    if (Ch == 0x04) Ch = 2;
                    if (Ch == 0x08) Ch = 3;
                    if (Ch == 0x10) Ch = 4;
                    if (Ch == 0x20) Ch = 5;
                    if (Ch == 0x40) Ch = 6;
                    if (Ch == 0x40) Ch = 7;

                    Res = Motion.mAcm_DaqDiGetBit(p_AxisHandle[Input.Device.ID, Input.Axis_Port], Ch, ref BitData);
                    if (Res != (int)ErrorCode.SUCCESS)
                    {
                        throw new Exception(GetErrorMessage1(Res));
                    }

                    if (BitData == 1) Input.Status = true; else Input.Status = false;
                    return;
                    #endregion
                }

                if (Input.Axis_Port >= 0 && Input.Axis_Port <= 7)
                {
                    uint Mask = (uint)Input.Mask;

                    if (Mask == 0x00000002 || Mask == 0x00000004 || Mask == 0x00000010 || Mask == 0x00000020)
                    {
                        #region
                        ushort Ch = 0;
                        byte BitData = 0;
                        switch (Mask)
                        {                                  //P1240 Signal   P1245 Signal 
                            case 0x00000002: Ch = 0; break;//In1            In1/LTC
                            case 0x00000004: Ch = 1; break;//In2            In2/RDY
                            case 0x00000010: Ch = 2; break;//ExP            In4/JOG+
                            case 0x00000020: Ch = 3; break;//ExN            In5/JOG-
                        }

                        Res = Motion.mAcm_AxDiGetBit(p_AxisHandle[Input.Device.ID, Input.Axis_Port], Ch, ref BitData);
                        if (Res != (int)ErrorCode.SUCCESS)
                        {
                            throw new Exception(GetErrorMessage1(Res));
                        }
                        if (BitData == 1) Input.Status = true; else Input.Status = false;
                        #endregion
                    }
                    else
                    {
                        #region
                        uint Data = 0;
                        switch (Mask)
                        {                                             //P1240 Signal    P1245 Signal
                            case 0x00000080: Mask = 0x00000002; break;//                1:  Alm
                            case 0x00000400: Mask = 0x00000004; break;//                2:  HLmtP
                            case 0x00000800: Mask = 0x00000008; break;//                3:  HLmtN

                            case 0x00000008: Mask = 0x00000010; break;//                4: In3/ORG
                            case 0x00002000: Mask = 0x00000040; break;//                6: Emg

                            case 0x00000001: Mask = 0x00000200; break;//In0             9: In0/EZ
                            case 0x00000040: Mask = 0x00002000; break;//                13: Inp

                            case 0x00000100: Mask = 0x00010000; break;//                17: SLmtP
                            case 0x00000200: Mask = 0x00020000; break;//                18: SLmtN
                            default: return;
                        }

                        Res = Motion.mAcm_AxGetMotionIO(p_AxisHandle[Input.Device.ID, Input.Axis_Port], ref Data);
                        if (Res != (int)ErrorCode.SUCCESS)
                        {
                            throw new Exception(GetErrorMessage1(Res));
                        }
                        if ((Data & Mask) == Mask) Input.Status = true; else Input.Status = false;
                        #endregion
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }
        private void UpdateOutput(ref TOutput Output, bool Status)
        {
            if (Output.Device.Type == EDeviceType.NONE) return;

            Mutex.WaitOne();
            try
            {
                uint Res = 0;
                byte BitData;
                if (Status) BitData = 1; else BitData = 0;

                if (Output.Device.Type == EDeviceType.P1265 && Output.Axis_Port == 6)
                {
                    #region
                    UInt16 Ch = (UInt16)Output.Mask;
                    if (Ch == 0x01) Ch = 0;
                    if (Ch == 0x02) Ch = 1;
                    if (Ch == 0x04) Ch = 2;
                    if (Ch == 0x08) Ch = 3;
                    if (Ch == 0x10) Ch = 4;
                    if (Ch == 0x20) Ch = 5;
                    if (Ch == 0x40) Ch = 6;
                    if (Ch == 0x40) Ch = 7;

                    Res = Motion.mAcm_DaqDoSetBit(p_AxisHandle[Output.Device.ID, Output.Axis_Port], Ch, BitData);
                    if (Res != (int)ErrorCode.SUCCESS)
                    {
                        throw new Exception(GetErrorMessage1(Res));
                    }
                    #endregion
                    Output.Status = Status;
                    return;
                }

                if (Output.Axis_Port >= 0 && Output.Axis_Port <= 7)
                {
                    #region
                    UInt16 Ch = (UInt16)Output.Mask;
                    switch (Ch)
                    {
                        case 0x01: Ch = 4; break;
                        case 0x02: Ch = 5; break;
                        case 0x04: Ch = 6; break;
                        case 0x08: Ch = 7; break;
                        default:
                            {
                                return;
                            }
                    }

                    Res = Motion.mAcm_AxDoSetBit(p_AxisHandle[Output.Device.ID, Output.Axis_Port], Ch, BitData);
                    if (Res != (int)ErrorCode.SUCCESS)
                    {
                        throw new Exception(GetErrorMessage1(Res));
                    }
                    #endregion
                    Output.Status = Status;
                    return;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }
        public void UpdateOutputHi(ref TOutput Output)
        {
            try
            {
                UpdateOutput(ref Output, true);
            }
            catch { throw; };
        }
        public void UpdateOutputLo(ref TOutput Output)
        {
            try
            {
                UpdateOutput(ref Output, false);
            }
            catch { throw; };
        }
        #endregion

        public void UpdateAxisPara(TAxis Axis)
        {
            if (Axis.Device.Type == EDeviceType.NONE) return;

            try
            {
                SetInvertPulse(Axis, Axis.Para.InvertPulse);
                SetUPP(Axis, Axis.Para.Unit.Resolution);

                SetAccel(Axis, (uint)Axis.Para.Accel);
                SetDecel(Axis, (uint)Axis.Para.Accel);
                SetStartV(Axis, (uint)Axis.Para.StartV);
                SetDriveV(Axis, (uint)Axis.Para.SlowV);

                switch (Axis.Para.SwLimit.LimitType)
                {
                    case EAxisSwLimitType.Disable:
                        SoftwareLimitEnable(Axis, false); break;
                    case EAxisSwLimitType.Logical:
                    case EAxisSwLimitType.Real:
                        SoftwareLimitEnable(Axis, true); break;
                }
                SetSLmtN(Axis, Axis.Para.SwLimit.PosN);
                SetSLmtP(Axis, Axis.Para.SwLimit.PosP);
            }
            catch { throw; }
        }
    }

    class CommonControl
    {
        public static CControl2 P1245 = new CControl2();

        public static void OpenBoard(CControl2.TDevice Device)
        {
            string ExMsg = Device.Name + " OpenBoard";
            try
            {
                switch (Device.Type)
                {
                    default:
                        throw new Exception("Device " + Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    if (!P1240.OpenBoard(Device.ID)) goto _OpenFail;
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        if (!P1245.OpenDevice(Device.ID)) goto _OpenFail;
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
            return;
        _OpenFail:
            throw new Exception("Fail");
        }

        public static void ResetBoard(CControl2.TDevice Device)
        {
            string ExMsg = Device.Name + " ResetBoard";
            try
            {
                switch (Device.Type)
                {
                    default:
                        throw new Exception("Device " + Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    P1240.ResetBoard(Device.ID);
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        P1245.Reset(Device.ID);
                        //P1245.EmgLogicActHigh(Device, true);
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }

        public static void CloseBoard(CControl2.TDevice Device)
        {
            switch (Device.Type)
            {
                default:
                    throw new Exception("Device " + Device.Type.ToString() + " Not Supported.");
                //case CControl2.EDeviceType.P1240:
                //    try
                //    {
                //        P1240.CloseBoard(Device.ID);
                //    }
                //    catch
                //    {
                //    }
                //    break;
                case CControl2.EDeviceType.P1245:
                case CControl2.EDeviceType.P1285:
                    try
                    {
                        P1245.CloseDevice(Device.ID);
                    }
                    catch
                    {
                    }
                    break;
            }
        }

        public static void CheckBoardOpened(CControl2.TDevice Device)
        {
            string ExMsg = Device.Name + " BoardOpened";
            switch (Device.Type)
            {
                default:
                    throw new Exception("Device " + Device.Type.ToString() + " Not Supported.");
                //case CControl2.EDeviceType.P1240:
                //    if (!P1240.BoardOpened(Device)) goto _Error;
                //    break;
                case CControl2.EDeviceType.P1245:
                case CControl2.EDeviceType.P1285:
                    if (!P1245.DeviceOpened(Device)) goto _Error;
                    break;
            }
            return;
            _Error:
            throw new Exception(ExMsg);
        }

        public static void UpdateAxis(CControl2.TAxis Axis)
        {
            string ExMsg = "UpdateAxis";

            try
            {
                switch (Axis.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Axis.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                        //ExMsg = "P1240 " + ExMsg;
                        //P1240.UpdateAxisPara(Axis);
                        //break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        ExMsg = "P1245 " + ExMsg;
                        P1245.UpdateAxisPara(Axis);
                        EnableSLimit(Axis);
                        //P1245.MotorAlarmEnable(Axis, true);
                        //P1245.MotorAlarmLogicActHigh(Axis, true);
                        P1245.CfgCmpEnable(TaskGantry.GXAxis, false);
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }

        //public static void MotorAlarmEnable(CControl2.TAxis Axis, bool Enable)
        //{
        //    string ExMsg = Axis.Name + " MotorEnable";

        //    try
        //    {
        //        switch (Axis.Device.Type)
        //        {
        //            default:
        //                throw new Exception("Device " + Axis.Device.Type.ToString() + " Not Supported.");
        //            //case CControl2.EDeviceType.P1240:
        //            //    break;
        //            case CControl2.EDeviceType.P1245:
        //            case CControl2.EDeviceType.P1285:
        //                P1245.MotorAlarmEnable(Axis, Enable);
        //                break;
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
        //        throw new Exception(ExMsg);
        //    }
        //}
        //public static void MotorAlarmLogicActHigh(CControl2.TAxis Axis, bool High)
        //{
        //    string ExMsg = Axis.Name + " MotorAlarmLogicActHigh";

        //    try
        //    {
        //        switch (Axis.Device.Type)
        //        {
        //            default:
        //                throw new Exception("Device " + Axis.Device.Type.ToString() + " Not Supported.");
        //            //case CControl2.EDeviceType.P1240:
        //            //    break;
        //            case CControl2.EDeviceType.P1245:
        //            case CControl2.EDeviceType.P1285:
        //                P1245.MotorAlarmLogicActHigh(Axis, High);
        //                break;
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
        //        throw new Exception(ExMsg);
        //    }
        //}

        public static void GetMotorSpeedRange(CControl2.TAxis Axis, ref double Min, ref double Max)
        {
            string ExMsg = Axis.Name + " GetMotorSpeedRange";

            try
            {
                switch (Axis.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Axis.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    P1240.GetDriveSpeedMinMax(Axis, ref Min, ref Max);
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        P1245.GetSpeedMinMax(Axis, ref Min, ref Max);
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }
        public static void GetMotorAccelRange(CControl2.TAxis Axis, ref double Min, ref double Max)
        {
            string ExMsg = Axis.Name + " GetMotorAccelRange";

            try
            {
                switch (Axis.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Axis.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    P1240.GetAccelDecelMinMax(Axis, ref Min, ref Max);
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        P1245.GetAccelMinMax(Axis, ref Min, ref Max);
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }     

        public static void SetMotionParam(CControl2.TAxis Axis, double StartV, double DriveV, double Accel)
        {
            string ExMsg = "SetMotionParam";

            double d_StartV = StartV;
            double d_DriveV = DriveV;

            if (d_StartV > d_DriveV) d_StartV = d_DriveV;

            try
            {
                switch (Axis.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Axis.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    P1240.SetStartV(Axis, d_StartV);
                    //    P1240.SetDriveV(Axis, d_DriveV);
                    //    P1240.SetAccel(Axis, Accel);
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        P1245.SetStartV(Axis, d_StartV);
                        P1245.SetDriveV(Axis, d_DriveV);
                        P1245.SetAccel(Axis, Accel);
                        break;

                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }

        public static void DecelOn(CControl2.TAxis Axis)
        {
            string ExMsg = Axis.Name + " DecelOn";
            try
            {
                switch (Axis.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Axis.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    P1240.SetDecelOn(Axis);
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }
        public static void DecelOff(CControl2.TAxis Axis)
        {
            string ExMsg = Axis.Name + " DecelOff";
            try
            {
                switch (Axis.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Axis.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    P1240.SetDecelOff(Axis);
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }

        public static void SetRPos(CControl2.TAxis Axis, double ualue)
        {
            string ExMsg = "SetRPos";
            try
            {
                switch (Axis.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Axis.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    P1240.SetRCntr(Axis, ualue);
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        P1245.SetRCntr(Axis, ualue);
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }
        public static void SetLPos(CControl2.TAxis Axis, double ualue)
        {
            string ExMsg = "SetLPos";
            try
            {
                switch (Axis.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Axis.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    P1240.SetLCntr(Axis, ualue);
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        P1245.SetLCntr(Axis, ualue);
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }
        public static void GetRPos(CControl2.TAxis Axis, ref double ualue)
        {
            string ExMsg = "GetRPos";
            try
            {
                switch (Axis.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Axis.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    P1240.GetRCntr(Axis, ref ualue);
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        P1245.GetRCntr(Axis, ref ualue);
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }
        public static void GetLPos(CControl2.TAxis Axis, ref double ualue)
        {
            string ExMsg = "GetLPos";
            try
            {
                switch (Axis.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Axis.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    P1240.GetLCntr(Axis, ref ualue);
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        if (P1245.DeviceOpened(Axis.Device))
                        P1245.GetLCntr(Axis, ref ualue);
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }

        public static void EnableSLimit(CControl2.TAxis Axis)
        {
            string ExMsg = Axis.Name + " EnableSLimit";
            try
            {
                switch (Axis.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Axis.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    P1240.EnableLogicalSwLimit(Axis, true);
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        P1245.SoftwareLimitEnable(Axis, true);
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }
        public static void DisableSLimit(CControl2.TAxis Axis)
        {
            string ExMsg = Axis.Name + " DisableSLimit";
            try
            {
                switch (Axis.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Axis.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    P1240.EnableLogicalSwLimit(Axis, false);
                    //    P1240.EnableRealSwLimit(Axis, false);
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        P1245.SoftwareLimitEnable(Axis, false);
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }
        public static void SetSLimit(CControl2.TAxis Axis)
        {
            string ExMsg = Axis.Name + " SetSLimit";
            try
            {
                switch (Axis.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Axis.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    P1240.SetComp(Axis, Axis.Para.SwLimit.PosN, Axis.Para.SwLimit.PosP);
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        P1245.SetSLmtN(Axis, Axis.Para.SwLimit.PosN);
                        P1245.SetSLmtP(Axis, Axis.Para.SwLimit.PosP);
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }

        public static void AxisError(CControl2.TAxis Axis, ref bool Error)
        {
            string ExMsg = "AxisError";
            try
            {
                switch (Axis.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Axis.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    Error = P1240.AxisError(Axis);
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        Error = P1245.AxisError(Axis);
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }
        public static void ClearAxisError(CControl2.TAxis Axis)
        {
            string ExMsg = "ClearAxisError";
            try
            {
                switch (Axis.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Axis.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    P1240.ClearAxisError(Axis);
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        P1245.ClearAxisError(Axis);
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }

        public static void MovePtpRel1(CControl2.TAxis Axis, double ualue)
        {
            string ExMsg = Axis.Name + " MovePtpRel1";
            try
            {
                switch (Axis.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Axis.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    P1240.MovePtpRel(Axis, ualue);
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        P1245.MovePtpRel(Axis, ualue);
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }
        public static void MovePtpAbs1(CControl2.TAxis Axis, double ualue)
        {
            string ExMsg = Axis.Name + " MovePtpAbs1";
            try
            {
                switch (Axis.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Axis.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    P1240.MovePtpAbs(Axis, ualue);
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        P1245.MovePtpAbs(Axis, ualue);
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }
        public static void MoveLineAbs2(CControl2.TAxis Axis1, CControl2.TAxis Axis2, double ualue1, double ualue2)
        {
            string ExMsg = Axis1.Name + Axis2.Name + " MoveLineAbs2";
            try
            {
                switch (Axis1.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Axis1.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    CControl2.TAxis Axis = new CControl2.TAxis();
                    //    Axis = Axis1;
                    //    Axis.Mask = (byte)((int)Axis.Mask + (int)Axis2.Mask);
                    //    P1240.MoveLineAbs(Axis, ualue1, ualue2);
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        P1245.MoveLineAbs(Axis1, Axis2, ualue1, ualue2);
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }
        public static void MoveLineRel2(CControl2.TAxis Axis1, CControl2.TAxis Axis2, double ualue1, double ualue2)
        {
            string ExMsg = Axis1.Name + Axis2.Name + " MoveLineRel2";
            try
            {
                switch (Axis1.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Axis1.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    CControl2.TAxis Axis = new CControl2.TAxis();
                    //    Axis = Axis1;
                    //    Axis.Mask = (byte)((int)Axis.Mask + (int)Axis2.Mask);
                    //    P1240.MoveLineRel(Axis, ualue1, ualue2);
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        P1245.MoveLineRel(Axis1, Axis2, ualue1, ualue2);
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }
        public static void MoveArcCenterEndAbs(CControl2.TAxis Axis1, CControl2.TAxis Axis2, bool CW, double Center1, double Center2, double EndPt1, double EndPt2)
        {
            string ExMsg = Axis1.Name + Axis2.Name + " MoveArcCenterEnd";
            try
            {
                switch (Axis1.Device.Type)
                {
                    default:
                        throw new Exception("Device "+ Axis1.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    CControl2.TAxis Axis = new CControl2.TAxis();
                    //    Axis = Axis1;
                    //    Axis.Mask = (byte)((int)Axis.Mask + (int)Axis2.Mask);
                    //    P1240.TCircDir Dir = P1240.TCircDir.CW;
                    //    if (!CW) Dir = P1240.TCircDir.CCW;
                    //    P1240.MoveArcCenterEndAbs(Axis, Dir, Center1, Center2, EndPt1, EndPt2);
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        double StartPt1 = 0;
                        GetLPos(Axis1, ref StartPt1);
                        double StartPt2 = 0;
                        GetLPos(Axis2, ref StartPt2);

                        CControl2.ECircDir Dir2 = CControl2.ECircDir.CW;
                        if (!CW) Dir2 = CControl2.ECircDir.CCW;

                        if (StartPt1 == EndPt1 && StartPt2 == EndPt2)
                        {
                            //P1245.MoveArcCenterEndAbs(Axis1, Axis2, Dir2, Center1, Center2, EndPt1, EndPt2);
                            //P1245.MoveArcCenterAngleAbs(Axis1, Axis2, Dir2, Center1, Center2, 360);

                            double r_CX = Center1 - StartPt1;
                            double r_CY = Center2 - StartPt2;
                            P1245.MoveArcCenterAngleRel(Axis1, Axis2, Dir2, r_CX, r_CY, 360);
                        }
                        else
                        {
                            double ThruPt1 = 0;
                            double ThruPt2 = 0;
                            GDefine.CircStartCenterGetThruPoint(StartPt1, StartPt2, Center1, Center2, EndPt1, EndPt2, ref ThruPt1, ref ThruPt2, Convert.ToDouble(CW));
                            //P1245.MoveArcThruEndAbs(Axis1, Axis2, Dir2, ThruPt1, ThruPt2, EndPt1, EndPt2);

                            double r_TX = ThruPt1 - StartPt1;
                            double r_TY = ThruPt2 - StartPt2;
                            double r_EX = EndPt1 - StartPt1;
                            double r_EY = EndPt2 - StartPt2;
                            P1245.MoveArcThruEndRel(Axis1, Axis2, Dir2, r_TX, r_TY, r_EX, r_EY);
                        }
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }

        public static void AxisBusy(CControl2.TAxis Axis, ref bool Busy)
        {
            string ExMsg = "AxisBusy";
            try
            {
                switch (Axis.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Axis.Device.Type.ToString() + " Not Supported.");

                    //case CControl2.EDeviceType.P1240:
                    //    Busy = P1240.AxisBusy(Axis);
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        Busy = P1245.AxisBusy(Axis);
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }
        public static void AxesBusy(CControl2.TAxis Axis1, CControl2.TAxis Axis2, ref bool Busy)
        {
            string ExMsg = "AxesBusy";

            //bool Busy1 = false;
            //bool Busy2 = false;
            try
            {
                switch (Axis1.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Axis1.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    Busy1 = P1240.AxisBusy(Axis1);
                    //    Busy2 = P1240.AxisBusy(Axis2);
                    //    Busy = Busy1 && Busy2;
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        Busy = P1245.AxisBusy(Axis1, Axis2);
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }
        public static void AxisWait(CControl2.TAxis Axis, int Timeout)
        {
            string ExMsg = Axis.Name + " AxisWait";
            try
            {
                switch (Axis.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Axis.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    P1240.AxisWait(Axis);
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        while (P1245.AxisBusy(Axis))
                        {
                            Thread.Sleep(0);
                        }
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }

        public static void JogP(CControl2.TAxis Axis)
        {
            string ExMsg = Axis.Name + " JogP";
            try
            {
                switch (Axis.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Axis.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    P1240.JogP(Axis);
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        P1245.JogP(Axis);
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }
        public static void JogN(CControl2.TAxis Axis)
        {
            string ExMsg = Axis.Name + " JogN";
            try
            {
                switch (Axis.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Axis.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    P1240.JogN(Axis);
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        P1245.JogN(Axis);
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }
        public static void ForceStop(CControl2.TAxis Axis)
        {
            string ExMsg = Axis + " ForceStop";
            try
            {
                switch (Axis.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Axis.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    P1240.ForceStop(Axis);
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        P1245.ForceStop(Axis);
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }
        public static void DecelStop(CControl2.TAxis Axis)
        {
            string ExMsg = "DecelStop";
            try
            {
                switch (Axis.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Axis.Device.Type.ToString() + " Not Supported.");
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        P1245.DecelStop(Axis);
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }

        public static void RefreshDI(ref CControl2.TInput Input)
        {
            string ExMsg = "RefreshDI";
            try
            {
                switch (Input.Device.Type)
                {
                    default:
                        //throw new Exception("Device " + Input.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    P1240.UpdateInput(ref Input);
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        if (P1245.DeviceOpened(Input.Device))
                            P1245.UpdateInput(ref Input);
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
            //finally { mutexDI.ReleaseMutex(); }
        }
        public static bool GetDI(ref CControl2.TInput Input)
        {
            return Input.Status;
        }

        public static void SetDO(ref CControl2.TOutput Output, CControl2.EOutputStatus Status)
        {
            string ExMsg = "SetDO";
            try
            {
                switch (Output.Device.Type)
                {
                    default:
                        throw new Exception("Device " + Output.Device.Type.ToString() + " Not Supported.");
                    //case CControl2.EDeviceType.P1240:
                    //    if (Status == CControl2.EOutputStatus.Hi)
                    //    {
                    //        P1240.UpdateOutputHi(ref Output);
                    //    }
                    //    if (Status == CControl2.EOutputStatus.Lo)
                    //    {
                    //        P1240.UpdateOutputLo(ref Output);
                    //    }
                    //    break;
                    case CControl2.EDeviceType.P1245:
                    case CControl2.EDeviceType.P1285:
                        if (Status == CControl2.EOutputStatus.Hi)
                        {
                            P1245.UpdateOutputHi(ref Output);
                        }
                        if (Status == CControl2.EOutputStatus.Lo)
                        {
                            P1245.UpdateOutputLo(ref Output);
                        }
                        break;
                }
            }
            catch (Exception Ex)
            {
                ExMsg = ExMsg + (char)13 + Ex.Message.ToString();
                throw new Exception(ExMsg);
            }
        }
    }
}
