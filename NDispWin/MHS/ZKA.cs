using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDispWin
{
    class ZKA
    {
    }

    class IODefine
    {
        internal static void LoadDIOAdd(ref NUtils.IniFile IniFile, ref ZEC3002.Ctrl.TDInput Input)
        {
            if (Input.BoardID == 3)
            {
                Input.AxisID = IniFile.ReadInteger("Board" + Input.BoardID.ToString() + "-" + Input.Name, "Axis", Input.AxisID);
                Input.Add = IniFile.ReadInteger("Board" + Input.BoardID.ToString() + "-" + Input.Name, "Add", Input.Add);
            }
            else
            {
                Input.AxisID = IniFile.ReadInteger(Input.Name, "Axis", Input.AxisID);
                Input.Add = IniFile.ReadInteger(Input.Name, "Add", Input.Add);
            }
        }
        internal static void LoadDIOAdd(ref NUtils.IniFile IniFile, ref ZEC3002.Ctrl.TDOutput Output)
        {
            if (Output.BoardID == 3)
            {
                Output.AxisID = IniFile.ReadInteger("Board" + Output.BoardID.ToString() + "-" + Output.Name, "Axis", Output.AxisID);
                Output.Add = IniFile.ReadInteger("Board" + Output.BoardID.ToString() + "-" + Output.Name, "Add", Output.Add);
            }
            else
            {
                Output.AxisID = IniFile.ReadInteger(Output.Name, "Axis", Output.AxisID);
                Output.Add = IniFile.ReadInteger(Output.Name, "Add", Output.Add);
            }
        }
        internal static void SaveDIOAdd(ref NUtils.IniFile IniFile, ZEC3002.Ctrl.TDInput Input)
        {
            if (Input.BoardID == 3)
            {
                IniFile.WriteInteger("Board" + Input.BoardID.ToString() + "-" + Input.Name, "Axis", Input.AxisID);
                IniFile.WriteInteger("Board" + Input.BoardID.ToString() + "-" + Input.Name, "Add", Input.Add);
            }
            else
            {
                IniFile.WriteInteger(Input.Name, "Axis", Input.AxisID);
                IniFile.WriteInteger(Input.Name, "Add", Input.Add);
            }
        }
        internal static void SaveDIOAdd(ref NUtils.IniFile IniFile, ZEC3002.Ctrl.TDOutput Output)
        {
            if (Output.BoardID == 3)
            {
                IniFile.WriteInteger("Board" + Output.BoardID.ToString() + "-" + Output.Name, "Axis", Output.AxisID);
                IniFile.WriteInteger("Board" + Output.BoardID.ToString() + "-" + Output.Name, "Add", Output.Add);
            }
            else
            {
                IniFile.WriteInteger(Output.Name, "Axis", Output.AxisID);
                IniFile.WriteInteger(Output.Name, "Add", Output.Add);
            }
        }

        internal static void LoadMotorPara(ref NUtils.IniFile IniFile, ref ZEC3002.Ctrl.TAxis Axis)
        {
            #region
            Axis.MotorPara.DistPerPulse = IniFile.ReadDouble(Axis.Name, "DistPerPulse", 0.002);
            Axis.MotorPara.InvertDir = IniFile.ReadBool(Axis.Name, "InvertDir", true);
            Axis.MotorPara.MotorAlarm = (ZEC3002.Ctrl.TMotorAlarm)IniFile.ReadInteger(Axis.Name, "MotorAlarmLogic", 1);
            Axis.MotorPara.InvertMtrOn = IniFile.ReadBool(Axis.Name, "InvertMtrOn", false);
            Axis.MotorPara.Home.HomeDir = (ZEC3002.Ctrl.THomeDir)IniFile.ReadInteger(Axis.Name, "HomeDir", 1);
            Axis.MotorPara.SLimit.N = IniFile.ReadInteger(Axis.Name, "SLmtN", -1000);
            Axis.MotorPara.SLimit.P = IniFile.ReadInteger(Axis.Name, "SLmtP", 1000);

            Axis.MotorPara.Home.SlowV = IniFile.ReadDouble(Axis.Name, "HomeSlowV", 1);
            Axis.MotorPara.Home.FastV = IniFile.ReadDouble(Axis.Name, "HomeFastV", 25);
            Axis.MotorPara.Home.TimeOut = IniFile.ReadInteger(Axis.Name, "HomeTimeOut", 30000);

            Axis.MotorPara.Jog.SlowV = IniFile.ReadDouble(Axis.Name, "JogSlowV", 1);
            Axis.MotorPara.Jog.MedV = IniFile.ReadDouble(Axis.Name, "JogMedV", 5);
            Axis.MotorPara.Jog.FastV = IniFile.ReadDouble(Axis.Name, "JogFastV", 15);

            Axis.MotorPara.Accel = IniFile.ReadDouble(Axis.Name, "Accel", 100);
            Axis.MotorPara.StartV = IniFile.ReadDouble(Axis.Name, "StartV", 5);
            Axis.MotorPara.SlowV = IniFile.ReadDouble(Axis.Name, "SlowV", 15);
            Axis.MotorPara.FastV = IniFile.ReadDouble(Axis.Name, "FastV", 30);

            if (Axis.Name == ElevIO.LPAxis.Name)
            {
                Axis.MotorPara.DistPerPulse = IniFile.ReadDouble(Axis.Name, "DistPerPulse", 0.0272);
                Axis.MotorPara.InvertDir = IniFile.ReadBool(Axis.Name, "InvertDir", false);
                Axis.MotorPara.Home.TimeOut = IniFile.ReadInteger(Axis.Name, "HomeTimeOut", 3000);

                Axis.MotorPara.StartV = IniFile.ReadDouble(Axis.Name, "StartV", 5);
                Axis.MotorPara.SlowV = IniFile.ReadDouble(Axis.Name, "SlowV", 25);
                Axis.MotorPara.FastV = IniFile.ReadDouble(Axis.Name, "FastV", 50);
            }
            if (Axis.Name == ElevIO.CWAxis.Name)
            {
                Axis.MotorPara.DistPerPulse = IniFile.ReadDouble(Axis.Name, "DistPerPulse", 0.0008);
                Axis.MotorPara.InvertDir = IniFile.ReadBool(Axis.Name, "InvertDir", false);
                Axis.MotorPara.Home.TimeOut = IniFile.ReadInteger(Axis.Name, "HomeTimeOut", 3000);

                Axis.MotorPara.StartV = IniFile.ReadDouble(Axis.Name, "StartV", 1);
                Axis.MotorPara.SlowV = IniFile.ReadDouble(Axis.Name, "SlowV", 2);
                Axis.MotorPara.FastV = IniFile.ReadDouble(Axis.Name, "FastV", 5);
            }
            #endregion
        }
        internal static void SaveMotorPara(ref NUtils.IniFile IniFile, ZEC3002.Ctrl.TAxis Axis)
        {
            #region
            IniFile.WriteDouble(Axis.Name, "DistPerPulse", Axis.MotorPara.DistPerPulse);
            IniFile.WriteBool(Axis.Name, "InvertDir", Axis.MotorPara.InvertDir);
            IniFile.WriteInteger(Axis.Name, "MotorAlarmLogic", (int)Axis.MotorPara.MotorAlarm);
            IniFile.WriteBool(Axis.Name, "InvertMtrOn", Axis.MotorPara.InvertMtrOn);
            IniFile.WriteInteger(Axis.Name, "HomeDir", (int)Axis.MotorPara.Home.HomeDir);
            IniFile.WriteInteger(Axis.Name, "SLmtN", Axis.MotorPara.SLimit.N);
            IniFile.WriteInteger(Axis.Name, "SLmtP", Axis.MotorPara.SLimit.P);

            IniFile.WriteDouble(Axis.Name, "HomeSlowV", Axis.MotorPara.Home.SlowV);
            IniFile.WriteDouble(Axis.Name, "HomeFastV", Axis.MotorPara.Home.FastV);
            IniFile.WriteInteger(Axis.Name, "HomeTimeOut", Axis.MotorPara.Home.TimeOut);

            IniFile.WriteDouble(Axis.Name, "JogSlowV", Axis.MotorPara.Jog.SlowV);
            IniFile.WriteDouble(Axis.Name, "JogMedV", Axis.MotorPara.Jog.MedV);
            IniFile.WriteDouble(Axis.Name, "JogFastV", Axis.MotorPara.Jog.FastV);

            IniFile.WriteDouble(Axis.Name, "Range", Axis.MotorPara.Range);
            IniFile.WriteDouble(Axis.Name, "Accel", Axis.MotorPara.Accel);
            IniFile.WriteDouble(Axis.Name, "StartV", Axis.MotorPara.StartV);
            IniFile.WriteDouble(Axis.Name, "SlowV", Axis.MotorPara.SlowV);
            IniFile.WriteDouble(Axis.Name, "FastV", Axis.MotorPara.FastV);
            #endregion
        }
    }

    public class ConvIO
    {
        public static byte BoardID = 1;
        public static ZEC3002.Ctrl.TDIOModel DIOModel = ZEC3002.Ctrl.TDIOModel.ZIO3201;
        public static int TL_Control = 0;//default, 1=PWM

        internal static string[] InputLabel = new string[39 + 1]
        {
            "[None]",
            "[Z1IO1-EI1]", "[Z1IO1-EI2]", "[Z1IO1-EI3]", "[Z1IO1-EI4]", "[Z1IO1-EI5]", "[Z1IO1-EI6]", "[Z1IO1-EI7]",
            "[Z1IO2-EI8]", "[Z1IO2-EI9]", "[Z1IO2-EI10]", "[Z1IO2-EI11]", "[Z1IO2-EI12]", "[Z1IO2-EI13]",
            "[Z1IO3-EI14]", "[Z1IO3-EI15]", "[Z1IO3-EI16]", "[Z1IO3-EI17]", "[Z1IO3-EI18]", "[Z1IO3-EI19]",
            "[Z1SA-EI20]", "[Z1SA-EI21]", "[Z1SA-EI22]", "[Z1SA-EI23]", "[Z1SA-EI24]", "[Z1SA-EI25]", "[Z1SA-EI26]", "[Z1SA-EI27]", "[Z1SA-EI28]", "[Z1SA-EI29]",
            "[Z1SB-EI30]", "[Z1SB-EI31]", "[Z1SB-EI32]", "[Z1SB-EI33]", "[Z1SB-EI34]", "[Z1SB-EI35]", "[Z1SB-EI36]", "[Z1SB-EI37]", "[Z1SB-EI38]", "[Z1SB-EI39]"
        };
        internal static string[] OutputLabel = new string[36 + 1]
        {
            "[None]",
            "[Z1IO1-EO1]", "[Z1IO1-EO2]",  "[Z1IO1-EO3]", "[Z1IO1-EO4]", "[Z1IO1-EO5]", "[Z1IO1-EO6]", "[Z1IO1-EO7]", "[Z1IO1-EO8]",
            "[Z1IO2-EO9]",  "[Z1IO2-EO10]", "[Z1IO2-EO11]", "[Z1IO2-EO12]", "[Z1IO2-EO13]", "[Z1IO2-EO14]", "[Z1IO2-EO15]",
            "[Z1IO2-EO16]", "[Z1IO2-EO17]", "[Z1IO2-EO18]", "[Z1IO2-EO19]", "[Z1IO2-E20]", "[Z1IO2-E21]", "[Z1IO2-E22]",
            "[Z1IO3-EO23]", "[Z1IO3-EO24]", "[Z1IO3-EO25]", "[Z1IO3-EO26]", "[Z1IO3-EO27]", "[Z1IO3-EO28]", "[Z1IO3-EO29]",
            "[Z1IO3-EO30]", "[Z1IO3-EO31]", "[Z1IO3-EO32]", "[Z1IO3-EO33]", "[Z1IO3-EO34]", "[Z1IO3-EO35]", "[Z1IO3-EO36]",
        };

        #region Inputs Declarations
        internal static ZEC3002.Ctrl.TDInput Pre_SensPsnt = new ZEC3002.Ctrl.TDInput("Pre_SensPsnt", DIOModel, BoardID, 0, 1, false, false);
        internal static ZEC3002.Ctrl.TDInput Pro_SensPsnt = new ZEC3002.Ctrl.TDInput("Pro_SensPsnt", DIOModel, BoardID, 0, 2, false, false);
        internal static ZEC3002.Ctrl.TDInput DI3 = new ZEC3002.Ctrl.TDInput("Spare", DIOModel, BoardID, 0, 3, false, false);
        internal static ZEC3002.Ctrl.TDInput In_SensPsnt = new ZEC3002.Ctrl.TDInput("In_SensPsnt", DIOModel, BoardID, 0, 4, false, false);
        internal static ZEC3002.Ctrl.TDInput Out_SensPsnt = new ZEC3002.Ctrl.TDInput("Out_SensPsnt", DIOModel, BoardID, 0, 5, false, false);
        internal static ZEC3002.Ctrl.TDInput UL_SmemaInBdReady = new ZEC3002.Ctrl.TDInput("UL_SmemaIn", DIOModel, BoardID, 0, 6, false, false);
        internal static ZEC3002.Ctrl.TDInput DL_SmemaInMcReady = new ZEC3002.Ctrl.TDInput("DL_SmemaIn", DIOModel, BoardID, 0, 7, false, false);
        internal static ZEC3002.Ctrl.TDInput Buf1_SensPsnt = new ZEC3002.Ctrl.TDInput("Buf1_SensPsnt", DIOModel, BoardID, 0, 8, false, false);
        internal static ZEC3002.Ctrl.TDInput DI9 = new ZEC3002.Ctrl.TDInput("Spare", DIOModel, BoardID, 0, 9, false, false);
        internal static ZEC3002.Ctrl.TDInput Buf1_SensStopperUp = new ZEC3002.Ctrl.TDInput("Buf1_SensStopperUp", DIOModel, BoardID, 0, 10, false, false);

        internal static ZEC3002.Ctrl.TDInput DI11 = new ZEC3002.Ctrl.TDInput("Spare", DIOModel, BoardID, 0, 11, false, false);
        internal static ZEC3002.Ctrl.TDInput Buf2_SensPsnt = new ZEC3002.Ctrl.TDInput("Buf2_SensPsnt", DIOModel, BoardID, 0, 12, false, false);
        internal static ZEC3002.Ctrl.TDInput Buf2_SensStopperUp = new ZEC3002.Ctrl.TDInput("Buf2_SensStopperUp", DIOModel, BoardID, 0, 13, false, false);
        internal static ZEC3002.Ctrl.TDInput Btn_Reset = new ZEC3002.Ctrl.TDInput("ButtonReset", DIOModel, BoardID, 0, 14, false, false);
        internal static ZEC3002.Ctrl.TDInput SensMainPressure = new ZEC3002.Ctrl.TDInput("LowPressure"/*mantained for rev comp*/, DIOModel, BoardID, 0, 15, false, false);
        internal static ZEC3002.Ctrl.TDInput Btn_Start = new ZEC3002.Ctrl.TDInput("ButtonStart", DIOModel, BoardID, 0, 16, false, false);
        internal static ZEC3002.Ctrl.TDInput Btn_Stop = new ZEC3002.Ctrl.TDInput("ButtonStop", DIOModel, BoardID, 0, 17, false, false);
        internal static ZEC3002.Ctrl.TDInput SensDoor = new ZEC3002.Ctrl.TDInput("SensDoor", DIOModel, BoardID, 0, 18, false, false);
        internal static ZEC3002.Ctrl.TDInput SensDoorLock = new ZEC3002.Ctrl.TDInput("SensDoorLock", DIOModel, BoardID, 0, 19, false, false);
        internal static ZEC3002.Ctrl.TDInput Pre_SensStopperUp = new ZEC3002.Ctrl.TDInput("Pre_SensStopperUp", DIOModel, BoardID, 0, 20, false, false);

        internal static ZEC3002.Ctrl.TDInput Pro_SensStopperUp = new ZEC3002.Ctrl.TDInput("Pro_SensStopperUp", DIOModel, BoardID, 0, 21, false, false);
        internal static ZEC3002.Ctrl.TDInput DI22 = new ZEC3002.Ctrl.TDInput("Spare", DIOModel, BoardID, 0, 22, false, false);
        internal static ZEC3002.Ctrl.TDInput Pre_SensLifterDn = new ZEC3002.Ctrl.TDInput("Pre_SensLifterDn", DIOModel, BoardID, 0, 23, false, false);
        internal static ZEC3002.Ctrl.TDInput Pre_SensLifterUp = new ZEC3002.Ctrl.TDInput("Pre_SensLifterUp", DIOModel, BoardID, 0, 24, false, false);
        internal static ZEC3002.Ctrl.TDInput Pro_SensLifterDn = new ZEC3002.Ctrl.TDInput("Pro_SensLifterDn", DIOModel, BoardID, 0, 25, false, false);
        internal static ZEC3002.Ctrl.TDInput Pro_SensLifterUp = new ZEC3002.Ctrl.TDInput("Pro_SensLifterUp", DIOModel, BoardID, 0, 26, false, false);
        internal static ZEC3002.Ctrl.TDInput In_SensLFPsnt = new ZEC3002.Ctrl.TDInput("In_SensLFPsnt", DIOModel, BoardID, 0, 0, false, false);
        internal static ZEC3002.Ctrl.TDInput Out_SensLFPsnt = new ZEC3002.Ctrl.TDInput("Out_SensLFPsnt", DIOModel, BoardID, 0, 0, false, false);
        internal static ZEC3002.Ctrl.TDInput Pro_SensPrecisorExt = new ZEC3002.Ctrl.TDInput("Pro_SensPrecisorExt", DIOModel, BoardID, 0, 29, false, false);
        internal static ZEC3002.Ctrl.TDInput Pre_SensPrecisorExt = new ZEC3002.Ctrl.TDInput("Pre_SensPrecisorExt", DIOModel, BoardID, 0, 30, false, false);

        internal static ZEC3002.Ctrl.TDInput Pre_VacSw = new ZEC3002.Ctrl.TDInput("Pre_VacSw", DIOModel, BoardID, 0, 31, false, false);
        internal static ZEC3002.Ctrl.TDInput Out_SensKickerExt = new ZEC3002.Ctrl.TDInput("Out_SensKickerExt", DIOModel, BoardID, 0, 32, false, false);
        internal static ZEC3002.Ctrl.TDInput Out_SensKickerRet = new ZEC3002.Ctrl.TDInput("Out_SensKickerRet", DIOModel, BoardID, 0, 33, false, false);
        internal static ZEC3002.Ctrl.TDInput Pro_HeaterAlarm = new ZEC3002.Ctrl.TDInput("Pro_HeaterAlarm", DIOModel, BoardID, 0, 34, false, false);
        internal static ZEC3002.Ctrl.TDInput Pre_HeaterAlarm = new ZEC3002.Ctrl.TDInput("Pre_HeaterAlarm", DIOModel, BoardID, 0, 35, false, false);
        internal static ZEC3002.Ctrl.TDInput Pro_VacSw2 = new ZEC3002.Ctrl.TDInput("Pro_VacSw2", DIOModel, BoardID, 0, 36, false, false);
        internal static ZEC3002.Ctrl.TDInput DI37 = new ZEC3002.Ctrl.TDInput("Spare", DIOModel, BoardID, 0, 37, false, false);
        internal static ZEC3002.Ctrl.TDInput DI38 = new ZEC3002.Ctrl.TDInput("Spare", DIOModel, BoardID, 0, 38, false, false);
        internal static ZEC3002.Ctrl.TDInput Pro_VacSw = new ZEC3002.Ctrl.TDInput("Pro_VacSw", DIOModel, BoardID, 0, 39, false, false);

        internal static ZEC3002.Ctrl.TDInput Smema2InBdReady = new ZEC3002.Ctrl.TDInput("Smema2InBdReady", DIOModel, BoardID, 0, 7, false, false);//Smema2UplineIn -> Smema2DiBdReady
        internal static ZEC3002.Ctrl.TDInput Smema2InMcReady = new ZEC3002.Ctrl.TDInput("Smema2InMcReady", DIOModel, BoardID, 0, 13, false, false);//Smema2DnlineIn -> Smema2DiMcReady
        #endregion

        #region  Output Declarations
        internal static ZEC3002.Ctrl.TDOutput Conv_MotorEn = new ZEC3002.Ctrl.TDOutput("Conv_MotorEn", DIOModel, BoardID, 0, 1, false, false);
        internal static ZEC3002.Ctrl.TDOutput UL_SmemaOutMcReady = new ZEC3002.Ctrl.TDOutput("UL_SmemaOut", DIOModel, BoardID, 0, 2, false, false);
        internal static ZEC3002.Ctrl.TDOutput DL_SmemaOutBdReady = new ZEC3002.Ctrl.TDOutput("DL_SmemaOut", DIOModel, BoardID, 0, 3, false, false);
        internal static ZEC3002.Ctrl.TDOutput In_SvBlowSuck = new ZEC3002.Ctrl.TDOutput("In_SvBlowSuck", DIOModel, BoardID, 0, 4, false, false);
        internal static ZEC3002.Ctrl.TDOutput DO5 = new ZEC3002.Ctrl.TDOutput("Spare", DIOModel, BoardID, 0, 5, false, false);
        internal static ZEC3002.Ctrl.TDOutput DO6 = new ZEC3002.Ctrl.TDOutput("Spare", DIOModel, BoardID, 0, 6, false, false);
        internal static ZEC3002.Ctrl.TDOutput DO7 = new ZEC3002.Ctrl.TDOutput("Spare", DIOModel, BoardID, 0, 7, false, false);
        internal static ZEC3002.Ctrl.TDOutput DO8 = new ZEC3002.Ctrl.TDOutput("Spare", DIOModel, BoardID, 0, 8, false, false);
        internal static ZEC3002.Ctrl.TDOutput Pro_SvVac2 = new ZEC3002.Ctrl.TDOutput("Pro_SvVac2", DIOModel, BoardID, 0, 9, false, false);
        internal static ZEC3002.Ctrl.TDOutput Pro_SvLifterUp = new ZEC3002.Ctrl.TDOutput("Pro_SvLifterUp", DIOModel, BoardID, 0, 10, false, false);


        internal static ZEC3002.Ctrl.TDOutput DoorLock = new ZEC3002.Ctrl.TDOutput("DoorLock", DIOModel, BoardID, 0, 11, false, false);
        internal static ZEC3002.Ctrl.TDOutput Pre_SvStopperUp = new ZEC3002.Ctrl.TDOutput("Pre_SvStopperUp", DIOModel, BoardID, 0, 12, false, false);
        internal static ZEC3002.Ctrl.TDOutput Pro_SvStopperUp = new ZEC3002.Ctrl.TDOutput("Pro_SvStopperUp", DIOModel, BoardID, 0, 13, false, false);
        internal static ZEC3002.Ctrl.TDOutput VacPump = new ZEC3002.Ctrl.TDOutput("VacPump", DIOModel, BoardID, 0, 14, false, false);
        internal static ZEC3002.Ctrl.TDOutput Pro_SvVac = new ZEC3002.Ctrl.TDOutput("Pro_SvVac", DIOModel, BoardID, 0, 15, false, false);
        internal static ZEC3002.Ctrl.TDOutput Out_SvKickerExt = new ZEC3002.Ctrl.TDOutput("Out_SvKickerExt", DIOModel, BoardID, 0, 16, false, false);
        internal static ZEC3002.Ctrl.TDOutput Pro_SvPrecisorExt = new ZEC3002.Ctrl.TDOutput("Pro_SvPrecisorExt", DIOModel, BoardID, 0, 17, false, false);
        internal static ZEC3002.Ctrl.TDOutput Pre_SvLifterUp = new ZEC3002.Ctrl.TDOutput("Pre_SvLifterUp", DIOModel, BoardID, 0, 18, false, false);
        internal static ZEC3002.Ctrl.TDOutput Pre_SvVac = new ZEC3002.Ctrl.TDOutput("Pre_SvVac", DIOModel, BoardID, 0, 19, false, false);
        internal static ZEC3002.Ctrl.TDOutput Pre_SvPrecisorExt = new ZEC3002.Ctrl.TDOutput("Pre_SvPrecisorExt", DIOModel, BoardID, 0, 20, false, false);

        internal static ZEC3002.Ctrl.TDOutput Buf1_SvStopperUp = new ZEC3002.Ctrl.TDOutput("Buf1_SvStopperUp", DIOModel, BoardID, 0, 21, false, false);
        internal static ZEC3002.Ctrl.TDOutput Buf2_SvStopperUp = new ZEC3002.Ctrl.TDOutput("Buf2_SvStopperUp", DIOModel, BoardID, 0, 22, false, false);
        internal static ZEC3002.Ctrl.TDOutput TL_Red = new ZEC3002.Ctrl.TDOutput("TL_Red", DIOModel, BoardID, 0, 23, false, false);
        internal static ZEC3002.Ctrl.TDOutput TL_Yellow = new ZEC3002.Ctrl.TDOutput("TL_Yellow", DIOModel, BoardID, 0, 24, false, false);
        internal static ZEC3002.Ctrl.TDOutput TL_Green = new ZEC3002.Ctrl.TDOutput("TL_Green", DIOModel, BoardID, 0, 25, false, false);
        internal static ZEC3002.Ctrl.TDOutput TL_Buzzer = new ZEC3002.Ctrl.TDOutput("TL_Buzzer", DIOModel, BoardID, 0, 26, false, false);
        internal static ZEC3002.Ctrl.TDOutput DO27 = new ZEC3002.Ctrl.TDOutput("Spare", DIOModel, BoardID, 0, 27, false, false);
        internal static ZEC3002.Ctrl.TDOutput DO28 = new ZEC3002.Ctrl.TDOutput("Spare", DIOModel, BoardID, 0, 28, false, false);
        internal static ZEC3002.Ctrl.TDOutput DO29 = new ZEC3002.Ctrl.TDOutput("Spare", DIOModel, BoardID, 0, 29, false, false);
        internal static ZEC3002.Ctrl.TDOutput DO30 = new ZEC3002.Ctrl.TDOutput("Spare", DIOModel, BoardID, 0, 30, false, false);

        internal static ZEC3002.Ctrl.TDOutput DO31 = new ZEC3002.Ctrl.TDOutput("Spare", DIOModel, BoardID, 0, 31, false, false);
        internal static ZEC3002.Ctrl.TDOutput DO32 = new ZEC3002.Ctrl.TDOutput("Spare", DIOModel, BoardID, 0, 32, false, false);
        internal static ZEC3002.Ctrl.TDOutput DO33 = new ZEC3002.Ctrl.TDOutput("Spare", DIOModel, BoardID, 0, 33, false, false);
        internal static ZEC3002.Ctrl.TDOutput DO34 = new ZEC3002.Ctrl.TDOutput("Spare", DIOModel, BoardID, 0, 34, false, false);
        internal static ZEC3002.Ctrl.TDOutput DO35 = new ZEC3002.Ctrl.TDOutput("Spare", DIOModel, BoardID, 0, 35, false, false);
        internal static ZEC3002.Ctrl.TDOutput DO36 = new ZEC3002.Ctrl.TDOutput("Spare", DIOModel, BoardID, 0, 36, false, false);

        internal static ZEC3002.Ctrl.TDOutput Smema2OutMcReady = new ZEC3002.Ctrl.TDOutput("Smema2OutMcReady", DIOModel, BoardID, 0, 12, false, false);//Smema2Upline Out -> Smema2DoMcReady
        internal static ZEC3002.Ctrl.TDOutput Smema2OutBdReady = new ZEC3002.Ctrl.TDOutput("Smema2OutBdReady", DIOModel, BoardID, 0, 13, false, false);//Smema2Dnline Out -> Smema2DoBdReady
        #endregion

        public static ZEC3002.Ctrl.TPWMOutput PWM_TL_Red = new ZEC3002.Ctrl.TPWMOutput("TL_Red", DIOModel, BoardID, 3, 1, 0);
        public static ZEC3002.Ctrl.TPWMOutput PWM_TL_Yellow = new ZEC3002.Ctrl.TPWMOutput("TL_Yellow", DIOModel, BoardID, 4, 1, 0);
        public static ZEC3002.Ctrl.TPWMOutput PWM_TL_Green = new ZEC3002.Ctrl.TPWMOutput("TL_Green", DIOModel, BoardID, 1, 1, 0);
        public static ZEC3002.Ctrl.TPWMOutput PWM_TL_Buzzer = new ZEC3002.Ctrl.TPWMOutput("TL_BUzzer", DIOModel, BoardID, 5, 1, 0);

        public static ZEC3002.Ctrl.TDInput NameGetInput(string Name)
        {
            if (Name.Contains("In_SensPsnt")) return ConvIO.In_SensPsnt;
            if (Name.Contains("In_SensLFPsnt")) return ConvIO.In_SensLFPsnt;
            if (Name.Contains("Buf1_SensPsnt")) return ConvIO.Buf1_SensPsnt;
            if (Name.Contains("Buf1_SensStopperUp")) return ConvIO.Buf1_SensStopperUp;
            if (Name.Contains("Buf2_SensPsnt")) return ConvIO.Buf2_SensPsnt;
            if (Name.Contains("Buf2_SensStopperUp")) return ConvIO.Buf2_SensStopperUp;
            if (Name.Contains("Pre_SensPsnt")) return ConvIO.Pre_SensPsnt;
            if (Name.Contains("Pre_SensStopperUp")) return ConvIO.Pre_SensStopperUp;
            if (Name.Contains("Pre_SensStopperUp")) return ConvIO.Pre_SensStopperUp;
            if (Name.Contains("Pre_SensLifterUp")) return ConvIO.Pre_SensLifterUp;
            if (Name.Contains("Pre_SensPrecisorExt")) return ConvIO.Pre_SensPrecisorExt;
            if (Name.Contains("Pre_SensPrecisorExt")) return ConvIO.Pre_SensPrecisorExt;
            if (Name.Contains("Pre_VacSw")) return ConvIO.Pre_VacSw;
            if (Name.Contains("Pro_SensPsnt")) return ConvIO.Pro_SensPsnt;
            if (Name.Contains("Pro_SensStopperUp")) return ConvIO.Pro_SensStopperUp;
            if (Name.Contains("Pro_SensStopperUp")) return ConvIO.Pro_SensStopperUp;
            if (Name.Contains("Pro_SensLifterUp")) return ConvIO.Pro_SensLifterUp;
            if (Name.Contains("Pro_SensPrecisorExt")) return ConvIO.Pro_SensPrecisorExt;
            if (Name.Contains("Pro_SensPrecisorExt")) return ConvIO.Pro_SensPrecisorExt;
            if (Name.EndsWith("Pro_VacSw")) return ConvIO.Pro_VacSw;
            if (Name.EndsWith("Pro_VacSw2")) return ConvIO.Pro_VacSw2;
            if (Name.Contains("Out_SensPsnt")) return ConvIO.Out_SensPsnt;
            if (Name.Contains("Out_SensLFPsnt")) return ConvIO.Out_SensLFPsnt;
            if (Name.Contains("Out_SensKickerExt")) return ConvIO.Out_SensKickerExt;
            if (Name.Contains("Out_SensKickerRet")) return ConvIO.Out_SensKickerRet;
            if (Name.Contains("Pre_HeaterAlm")) return ConvIO.Pre_HeaterAlarm;
            if (Name.Contains("Pro_HeaterAlm")) return ConvIO.Pro_HeaterAlarm;

            if (Name.Contains("MainPressure")) return ConvIO.SensMainPressure;
            if (Name.Contains("SensDoor")) return ConvIO.SensDoor;
            if (Name.Contains("SensDLock")) return ConvIO.SensDoorLock;

            if (Name.Contains("Smema_BdReady")) return ConvIO.UL_SmemaInBdReady;
            if (Name.Contains("Smema_McReady")) return ConvIO.DL_SmemaInMcReady;
            if (Name.Contains("Smema2_BdReady")) return ConvIO.Smema2InBdReady;
            if (Name.Contains("Smema2_McReady")) return ConvIO.Smema2InMcReady;

            return new ZEC3002.Ctrl.TDInput("Invalid", ZEC3002.Ctrl.TDIOModel.ZIO3201, BoardID, 0, 0, false, false);
        }
        public static string NameGetInputInfo(string Name)
        {
            ZEC3002.Ctrl.TDInput Input = NameGetInput(Name);
            return ConvIO.InputLabel[Input.Add] + " " + Input.Name;
        }
        public static ZEC3002.Ctrl.TDOutput NameGetOutput(string Name)
        {
            if (Name.Contains("Conv_MotorOn")) return ConvIO.Conv_MotorEn;
            if (Name.Contains("In_SvBlowSuck")) return ConvIO.In_SvBlowSuck;

            if (Name.Contains("Buf1_SvStopperUp")) return ConvIO.Buf1_SvStopperUp;
            if (Name.Contains("Buf2_SvStopperUp")) return ConvIO.Buf2_SvStopperUp;

            if (Name.Contains("Pre_SvStopperUp")) return ConvIO.Pre_SvStopperUp;
            if (Name.Contains("Pre_SvLifterUp")) return ConvIO.Pre_SvLifterUp;
            if (Name.Contains("Pre_SvPrecisorExt")) return ConvIO.Pre_SvPrecisorExt;
            if (Name.Contains("Pre_SvVac")) return ConvIO.Pre_SvVac;

            if (Name.Contains("Pro_SvStopperUp")) return ConvIO.Pro_SvStopperUp;
            if (Name.Contains("Pro_SvLifterUp")) return ConvIO.Pro_SvLifterUp;
            if (Name.Contains("Pro_SvPrecisorExt")) return ConvIO.Pro_SvPrecisorExt;
            if (Name.EndsWith("Pro_SvVac")) return ConvIO.Pro_SvVac;
            if (Name.EndsWith("Pro_SvVac2")) return ConvIO.Pro_SvVac2;

            if (Name.Contains("Out_SvKickerExt")) return ConvIO.Out_SvKickerExt;

            if (Name.Contains("VacPump")) return ConvIO.VacPump;

            if (Name.Contains("DoorLock")) return ConvIO.DoorLock;

            if (Name.Contains("Smema_McReady")) return ConvIO.UL_SmemaOutMcReady;
            if (Name.Contains("Smema_BdReady")) return ConvIO.DL_SmemaOutBdReady;
            if (Name.Contains("Smema2_McReady")) return ConvIO.Smema2OutMcReady;
            if (Name.Contains("Smema2_BdReady")) return ConvIO.Smema2OutBdReady;

            if (Name.Contains("TL_Red")) return ConvIO.TL_Red;
            if (Name.Contains("TL_Yellow")) return ConvIO.TL_Yellow;
            if (Name.Contains("TL_Green")) return ConvIO.TL_Green;
            if (Name.Contains("TL_Buzzer")) return ConvIO.TL_Buzzer;

            return new ZEC3002.Ctrl.TDOutput("Invalid", ZEC3002.Ctrl.TDIOModel.ZIO3201, BoardID, 0, 0, false, false);
        }
        public static string NameGetOutputInfo(string Name)
        {
            if (TL_Control == 1)
            {
                if (Name.Contains("TL_Red")) return "[PWM" + ConvIO.PWM_TL_Red.Add + "] " + PWM_TL_Red.Name;
                if (Name.Contains("TL_Yellow")) return "[PWM" + ConvIO.PWM_TL_Yellow.Add + "] " + PWM_TL_Yellow.Name;
                if (Name.Contains("TL_Green")) return "[PWM" + ConvIO.PWM_TL_Green.Add + "] " + PWM_TL_Green.Name;
                if (Name.Contains("TL_Buzzer")) return "[PWM" + ConvIO.PWM_TL_Buzzer.Add + "] " + PWM_TL_Buzzer.Name;
            }

            ZEC3002.Ctrl.TDOutput Output = NameGetOutput(Name);
            return ConvIO.OutputLabel[Output.Add] + " " + Output.Name;
        }

        public static void SetA25XDIOAdd()
        {
            TL_Control = 0;

            #region DI
            In_SensPsnt.Add = 4;
            In_SensLFPsnt.Add = 27;
            Buf1_SensPsnt.Add = 8;
            Buf1_SensStopperUp.Add = 10;
            Buf2_SensPsnt.Add = 12;
            Buf2_SensStopperUp.Add = 13;

            Pre_SensPsnt.Add = 1;
            Pre_SensStopperUp.Add = 20;
            Pre_SensLifterDn.Add = 23;
            Pre_SensLifterUp.Add = 24;
            Pre_SensPrecisorExt.Add = 30;
            Pre_VacSw.Add = 31;
            Pre_HeaterAlarm.Add = 35;

            Pro_SensPsnt.Add = 2;
            Pro_SensStopperUp.Add = 21;
            Pro_SensLifterDn.Add = 25;
            Pro_SensLifterUp.Add = 26;
            Pro_SensPrecisorExt.Add = 29;
            Pro_VacSw.Add = 39;
            Pro_VacSw2.Add = 36;
            Pro_HeaterAlarm.Add = 34;

            Out_SensPsnt.Add = 5;
            Out_SensLFPsnt.Add = 28;
            Out_SensKickerExt.Add = 32;
            Out_SensKickerRet.Add = 33;

            UL_SmemaInBdReady.Add = 6;
            DL_SmemaInMcReady.Add = 7;

            SensMainPressure.Add = 15;

            Btn_Reset.Add = 14;
            Btn_Start.Add = 16;
            Btn_Stop.Add = 17;

            SensDoor.Add = 18;
            SensDoorLock.Add = 19;
            #endregion
            #region DO
            Conv_MotorEn.Add = 1;

            UL_SmemaOutMcReady.Add = 2;
            DL_SmemaOutBdReady.Add = 3;

            In_SvBlowSuck.Add = 21;

            Buf1_SvStopperUp.Add = 21;
            Buf2_SvStopperUp.Add = 22;

            Pre_SvStopperUp.Add = 12;
            Pre_SvLifterUp.Add = 18;
            Pre_SvPrecisorExt.Add = 20;
            Pre_SvVac.Add = 19;

            Pro_SvStopperUp.Add = 13;
            Pro_SvLifterUp.Add = 10;
            Pro_SvPrecisorExt.Add = 17;
            Pro_SvVac.Add = 15;
            Pro_SvVac2.Add = 9;

            Out_SvKickerExt.Add = 16;

            DoorLock.Add = 11;
            VacPump.Add = 14;

            TL_Red.Add = 23;
            TL_Yellow.Add = 24;
            TL_Green.Add = 25;
            TL_Buzzer.Add = 26;

            #endregion
        }
        public static void SetA30XDIOAdd()
        {
            TL_Control = 1;

            #region DI
            In_SensPsnt.Add = 20;
            In_SensLFPsnt.Add = 11;
            Buf1_SensPsnt.Add = 22;
            Buf1_SensStopperUp.Add = 21;
            Buf2_SensPsnt.Add = 24;
            Buf2_SensStopperUp.Add = 23;

            Pre_SensPsnt.Add = 25;
            Pre_SensStopperUp.Add = 26;
            Pre_SensLifterDn.Add = 27;
            Pre_SensLifterUp.Add = 28;
            Pre_SensPrecisorExt.Add = 29;
            Pre_VacSw.Add = 14;
            Pre_HeaterAlarm.Add = 17;

            Pro_SensPsnt.Add = 30;
            Pro_SensStopperUp.Add = 31;
            Pro_SensLifterDn.Add = 32;
            Pro_SensLifterUp.Add = 33;
            Pro_SensPrecisorExt.Add = 34;
            Pro_VacSw.Add = 15;
            Pro_VacSw2.Add = 16;
            Pro_HeaterAlarm.Add = 18;

            Out_SensPsnt.Add = 39;
            Out_SensLFPsnt.Add = 12;
            Out_SensKickerExt.Add = 8;
            Out_SensKickerRet.Add = 9;

            UL_SmemaInBdReady.Add = 1;
            DL_SmemaInMcReady.Add = 2;
            Smema2InBdReady.Add = 7;
            Smema2InMcReady.Add = 13;

            SensMainPressure.Add = 10;

            Btn_Reset.Add = 5;
            Btn_Start.Add = 3;
            Btn_Stop.Add = 4;

            SensDoor.Add = 6;//18;
            SensDoorLock.Add = 19;
            #endregion
            #region DO
            Conv_MotorEn.Add = 5;

            UL_SmemaOutMcReady.Add = 1;
            DL_SmemaOutBdReady.Add = 2;
            Smema2OutMcReady.Add = 12;
            Smema2OutBdReady.Add = 13;

            In_SvBlowSuck.Add = 32;

            Buf1_SvStopperUp.Add = 33;
            Buf2_SvStopperUp.Add = 34;

            Pre_SvStopperUp.Add = 26;
            Pre_SvLifterUp.Add = 23;
            Pre_SvPrecisorExt.Add = 29;
            Pre_SvVac.Add = 9;

            Pro_SvStopperUp.Add = 27;
            Pro_SvLifterUp.Add = 24;
            Pro_SvPrecisorExt.Add = 30;
            Pro_SvVac.Add = 10;
            Pro_SvVac2.Add = 11;

            Out_SvKickerExt.Add = 31;

            DoorLock.Add = 3;
            VacPump.Add = 4;

            TL_Red.Add = 23;
            TL_Yellow.Add = 24;
            TL_Green.Add = 25;
            TL_Buzzer.Add = 26;
            #endregion
        }

        internal enum EMHS2McModel { A25X, A30X }
        public static void LoadDIOAdd(string FullFilename)
        {
            NUtils.IniFile IniFile = new NUtils.IniFile(FullFilename);

            BoardID = (byte)IniFile.ReadInteger("ConvIO", "BoardID", 1);
            TL_Control = IniFile.ReadInteger("ConvIO", "TowerLightCtrl", 0);

            #region DI
            IODefine.LoadDIOAdd(ref IniFile, ref In_SensPsnt);
            IODefine.LoadDIOAdd(ref IniFile, ref In_SensLFPsnt);
            if (In_SensLFPsnt.Add == 0 && TL_Control == 1) In_SensLFPsnt.Add = 11;
            IODefine.LoadDIOAdd(ref IniFile, ref Buf1_SensPsnt);
            IODefine.LoadDIOAdd(ref IniFile, ref Buf1_SensStopperUp);
            IODefine.LoadDIOAdd(ref IniFile, ref Buf2_SensPsnt);
            IODefine.LoadDIOAdd(ref IniFile, ref Buf2_SensStopperUp);

            IODefine.LoadDIOAdd(ref IniFile, ref Pre_SensPsnt);
            IODefine.LoadDIOAdd(ref IniFile, ref Pre_SensStopperUp);
            IODefine.LoadDIOAdd(ref IniFile, ref Pre_SensLifterDn);
            IODefine.LoadDIOAdd(ref IniFile, ref Pre_SensLifterUp);
            IODefine.LoadDIOAdd(ref IniFile, ref Pre_SensPrecisorExt);
            IODefine.LoadDIOAdd(ref IniFile, ref Pre_VacSw);
            IODefine.LoadDIOAdd(ref IniFile, ref Pre_HeaterAlarm);

            IODefine.LoadDIOAdd(ref IniFile, ref Pro_SensPsnt);
            IODefine.LoadDIOAdd(ref IniFile, ref Pro_SensStopperUp);
            IODefine.LoadDIOAdd(ref IniFile, ref Pro_SensLifterDn);
            IODefine.LoadDIOAdd(ref IniFile, ref Pro_SensLifterUp);
            IODefine.LoadDIOAdd(ref IniFile, ref Pro_SensPrecisorExt);
            IODefine.LoadDIOAdd(ref IniFile, ref Pro_VacSw);
            IODefine.LoadDIOAdd(ref IniFile, ref Pro_VacSw2);
            IODefine.LoadDIOAdd(ref IniFile, ref Pro_HeaterAlarm);

            IODefine.LoadDIOAdd(ref IniFile, ref Out_SensPsnt);
            IODefine.LoadDIOAdd(ref IniFile, ref Out_SensLFPsnt);
            if (Out_SensLFPsnt.Add == 0 && TL_Control == 1) Out_SensLFPsnt.Add = 12;
            IODefine.LoadDIOAdd(ref IniFile, ref Out_SensKickerExt);
            IODefine.LoadDIOAdd(ref IniFile, ref Out_SensKickerRet);

            IODefine.LoadDIOAdd(ref IniFile, ref UL_SmemaInBdReady);
            IODefine.LoadDIOAdd(ref IniFile, ref DL_SmemaInMcReady);
            IODefine.LoadDIOAdd(ref IniFile, ref Smema2InBdReady);
            IODefine.LoadDIOAdd(ref IniFile, ref Smema2InMcReady);

            IODefine.LoadDIOAdd(ref IniFile, ref SensMainPressure);

            IODefine.LoadDIOAdd(ref IniFile, ref Btn_Reset);
            IODefine.LoadDIOAdd(ref IniFile, ref Btn_Start);
            IODefine.LoadDIOAdd(ref IniFile, ref Btn_Stop);

            IODefine.LoadDIOAdd(ref IniFile, ref SensDoor);
            IODefine.LoadDIOAdd(ref IniFile, ref SensDoorLock);
            #endregion
            #region DO
            IODefine.LoadDIOAdd(ref IniFile, ref Conv_MotorEn);

            IODefine.LoadDIOAdd(ref IniFile, ref UL_SmemaOutMcReady);
            IODefine.LoadDIOAdd(ref IniFile, ref DL_SmemaOutBdReady);
            IODefine.LoadDIOAdd(ref IniFile, ref Smema2OutMcReady);
            IODefine.LoadDIOAdd(ref IniFile, ref Smema2OutBdReady);

            IODefine.LoadDIOAdd(ref IniFile, ref In_SvBlowSuck);

            IODefine.LoadDIOAdd(ref IniFile, ref Buf1_SvStopperUp);
            IODefine.LoadDIOAdd(ref IniFile, ref Buf2_SvStopperUp);

            IODefine.LoadDIOAdd(ref IniFile, ref Pre_SvStopperUp);
            IODefine.LoadDIOAdd(ref IniFile, ref Pre_SvLifterUp);
            IODefine.LoadDIOAdd(ref IniFile, ref Pre_SvPrecisorExt);
            IODefine.LoadDIOAdd(ref IniFile, ref Pre_SvVac);

            IODefine.LoadDIOAdd(ref IniFile, ref Pro_SvStopperUp);
            IODefine.LoadDIOAdd(ref IniFile, ref Pro_SvLifterUp);
            IODefine.LoadDIOAdd(ref IniFile, ref Pro_SvPrecisorExt);
            IODefine.LoadDIOAdd(ref IniFile, ref Pro_SvVac);
            IODefine.LoadDIOAdd(ref IniFile, ref Pro_SvVac2);

            IODefine.LoadDIOAdd(ref IniFile, ref Out_SvKickerExt);

            IODefine.LoadDIOAdd(ref IniFile, ref DoorLock);
            IODefine.LoadDIOAdd(ref IniFile, ref VacPump);

            IODefine.LoadDIOAdd(ref IniFile, ref TL_Red);
            IODefine.LoadDIOAdd(ref IniFile, ref TL_Yellow);
            IODefine.LoadDIOAdd(ref IniFile, ref TL_Green);
            IODefine.LoadDIOAdd(ref IniFile, ref TL_Buzzer);
            #endregion
        }
        public static void SaveDIOAdd(string FullFilename)
        {
            NUtils.IniFile IniFile = new NUtils.IniFile(FullFilename);

            IniFile.WriteInteger("ConvIO", "TowerLightCtrl", TL_Control);

            #region DI
            IODefine.SaveDIOAdd(ref IniFile, In_SensPsnt);
            IODefine.SaveDIOAdd(ref IniFile, In_SensLFPsnt);
            IODefine.SaveDIOAdd(ref IniFile, Buf1_SensPsnt);
            IODefine.SaveDIOAdd(ref IniFile, Buf1_SensStopperUp);
            IODefine.SaveDIOAdd(ref IniFile, Buf2_SensPsnt);
            IODefine.SaveDIOAdd(ref IniFile, Buf2_SensStopperUp);

            IODefine.SaveDIOAdd(ref IniFile, Pre_SensPsnt);
            IODefine.SaveDIOAdd(ref IniFile, Pre_SensStopperUp);
            IODefine.SaveDIOAdd(ref IniFile, Pre_SensLifterDn);
            IODefine.SaveDIOAdd(ref IniFile, Pre_SensLifterUp);
            IODefine.SaveDIOAdd(ref IniFile, Pre_SensPrecisorExt);
            IODefine.SaveDIOAdd(ref IniFile, Pre_VacSw);
            IODefine.SaveDIOAdd(ref IniFile, Pre_HeaterAlarm);

            IODefine.SaveDIOAdd(ref IniFile, Pro_SensPsnt);
            IODefine.SaveDIOAdd(ref IniFile, Pro_SensStopperUp);
            IODefine.SaveDIOAdd(ref IniFile, Pro_SensLifterDn);
            IODefine.SaveDIOAdd(ref IniFile, Pro_SensLifterUp);
            IODefine.SaveDIOAdd(ref IniFile, Pro_SensPrecisorExt);
            IODefine.SaveDIOAdd(ref IniFile, Pro_VacSw);
            IODefine.SaveDIOAdd(ref IniFile, Pro_VacSw2);
            IODefine.SaveDIOAdd(ref IniFile, Pro_HeaterAlarm);

            IODefine.SaveDIOAdd(ref IniFile, Out_SensPsnt);
            IODefine.SaveDIOAdd(ref IniFile, Out_SensLFPsnt);
            IODefine.SaveDIOAdd(ref IniFile, Out_SensKickerExt);
            IODefine.SaveDIOAdd(ref IniFile, Out_SensKickerRet);

            IODefine.SaveDIOAdd(ref IniFile, UL_SmemaInBdReady);
            IODefine.SaveDIOAdd(ref IniFile, DL_SmemaInMcReady);
            IODefine.SaveDIOAdd(ref IniFile, Smema2InBdReady);
            IODefine.SaveDIOAdd(ref IniFile, Smema2InMcReady);

            IODefine.SaveDIOAdd(ref IniFile, SensMainPressure);

            IODefine.SaveDIOAdd(ref IniFile, Btn_Reset);
            IODefine.SaveDIOAdd(ref IniFile, Btn_Start);
            IODefine.SaveDIOAdd(ref IniFile, Btn_Stop);

            IODefine.SaveDIOAdd(ref IniFile, SensDoor);
            IODefine.SaveDIOAdd(ref IniFile, SensDoorLock);
            #endregion
            #region DO
            IODefine.SaveDIOAdd(ref IniFile, Conv_MotorEn);

            IODefine.SaveDIOAdd(ref IniFile, UL_SmemaOutMcReady);
            IODefine.SaveDIOAdd(ref IniFile, DL_SmemaOutBdReady);
            IODefine.SaveDIOAdd(ref IniFile, Smema2OutMcReady);
            IODefine.SaveDIOAdd(ref IniFile, Smema2OutBdReady);

            IODefine.SaveDIOAdd(ref IniFile, In_SvBlowSuck);

            IODefine.SaveDIOAdd(ref IniFile, Buf1_SvStopperUp);
            IODefine.SaveDIOAdd(ref IniFile, Buf2_SvStopperUp);

            IODefine.SaveDIOAdd(ref IniFile, Pre_SvStopperUp);
            IODefine.SaveDIOAdd(ref IniFile, Pre_SvLifterUp);
            IODefine.SaveDIOAdd(ref IniFile, Pre_SvPrecisorExt);
            IODefine.SaveDIOAdd(ref IniFile, Pre_SvVac);

            IODefine.SaveDIOAdd(ref IniFile, Pro_SvStopperUp);
            IODefine.SaveDIOAdd(ref IniFile, Pro_SvLifterUp);
            IODefine.SaveDIOAdd(ref IniFile, Pro_SvPrecisorExt);
            IODefine.SaveDIOAdd(ref IniFile, Pro_SvVac);
            IODefine.SaveDIOAdd(ref IniFile, Pro_SvVac2);

            IODefine.SaveDIOAdd(ref IniFile, Out_SvKickerExt);

            IODefine.SaveDIOAdd(ref IniFile, DoorLock);
            IODefine.SaveDIOAdd(ref IniFile, VacPump);

            IODefine.SaveDIOAdd(ref IniFile, TL_Red);
            IODefine.SaveDIOAdd(ref IniFile, TL_Yellow);
            IODefine.SaveDIOAdd(ref IniFile, TL_Green);
            IODefine.SaveDIOAdd(ref IniFile, TL_Buzzer);
            #endregion
        }
    }

    public class ElevIO
    {
        public static byte BoardID = 2;
        public static ZEC3002.Ctrl.TDIOModel DIOModel = ZEC3002.Ctrl.TDIOModel.ZM324;

        internal static string[,] InputLabel = new string[5, 8]
        {
            {"[None]", "[Z2M0-EI1]", "[Z2M0-EI2]", "[Z2M0-EI3]", "[Z2M0-EI4]", "[Z2M0-EI5]", "[Z2M0-EI6]", "[Z2M0-EI7]"},
            {"[None]", "[Z2SA-EI1]", "[Z2SA-EI2]", "[Z2SA-EI3]", "[Z2SA-EI4]", "[Ax1Alm]", "[]", "[]"},
            {"[None]", "[Z2SA-EI5]", "[Z2SA-EI6]", "[Z2SA-EI7]", "[Z2SA-EI8]", "[Ax2Alm]", "[]", "[]"},
            {"[None]", "[Z2SB-EI1]", "[Z2SB-EI2]", "[Z2SB-EI3]", "[Z2SB-EI4]", "[Ax3Alm]", "[]", "[]"},
            {"[None]", "[Z2SB-EI5]", "[Z2SB-EI6]", "[Z2SB-EI7]", "[Z2SB-EI8]", "[Ax4Alm]", "[]", "[]"},
        };
        internal static string[] OutputLabel = new string[8 + 1]
        {
            "[None]",
            "[Z2M0-EO1]", "[Z2M0-EO2]",  "[Z2M0-EO3]", "[Z2M0-EO4]",
            "[Z2M0-EO5]", "[Z2M0-EO6]", "[Z2M0-EO7]", "[Z2M0-EO8]",
        };

        private static ZEC3002.Ctrl.TMotorPara MPara = new ZEC3002.Ctrl.TMotorPara();
        public static ZEC3002.Ctrl.TAxis LZAxis = new ZEC3002.Ctrl.TAxis("LZAxis", DIOModel, BoardID, 1, MPara, false);
        public static ZEC3002.Ctrl.TAxis CWAxis = new ZEC3002.Ctrl.TAxis("CWAxis", DIOModel, BoardID, 2, MPara, false);
        public static ZEC3002.Ctrl.TAxis RZAxis = new ZEC3002.Ctrl.TAxis("RZAxis", DIOModel, BoardID, 3, MPara, false);
        public static ZEC3002.Ctrl.TAxis LPAxis = new ZEC3002.Ctrl.TAxis("LPAxis", DIOModel, BoardID, 4, MPara, false);

        public static ZEC3002.Ctrl.TDInput SensLZHome = new ZEC3002.Ctrl.TDInput("SensLZHome", DIOModel, BoardID, 1, 1, false, false);
        public static ZEC3002.Ctrl.TDInput Left_SensDoor = new ZEC3002.Ctrl.TDInput("Left_SensDoor", DIOModel, BoardID, 1, 2, false, false);
        public static ZEC3002.Ctrl.TDInput LP_PusherHome = new ZEC3002.Ctrl.TDInput("LP_PusherHome", DIOModel, BoardID, 1, 3, false, false);
        public static ZEC3002.Ctrl.TDInput LP_PusherLmt = new ZEC3002.Ctrl.TDInput("LP_PusherLmt", DIOModel, BoardID, 1, 4, false, false);
        public static ZEC3002.Ctrl.TDInput LZ_MtrAlm = new ZEC3002.Ctrl.TDInput("LZ_MtrAlrm", DIOModel, BoardID, 1, 5, false, false);

        public static ZEC3002.Ctrl.TDInput Left_SensMagPsnt1 = new ZEC3002.Ctrl.TDInput("Left_SensMagPsnt1", DIOModel, BoardID, 2, 1, false, false);
        public static ZEC3002.Ctrl.TDInput Left_SensMagPsnt2 = new ZEC3002.Ctrl.TDInput("Left_SensMagPsnt2", DIOModel, BoardID, 2, 2, false, false);
        public static ZEC3002.Ctrl.TDInput Left_SensMagPsnt3 = new ZEC3002.Ctrl.TDInput("Left_SensMagPsnt3", DIOModel, BoardID, 2, 3, false, false);
        public static ZEC3002.Ctrl.TDInput Left_SensMagPsnt4 = new ZEC3002.Ctrl.TDInput("Left_SensMagPsnt4", DIOModel, BoardID, 2, 4, false, false);
        public static ZEC3002.Ctrl.TDInput CW_MtrAlm = new ZEC3002.Ctrl.TDInput("CW_MtrAlm", DIOModel, BoardID, 2, 5, false, false);

        public static ZEC3002.Ctrl.TDInput SensRZHome = new ZEC3002.Ctrl.TDInput("SensRZHome", DIOModel, BoardID, 3, 1, false, false);
        public static ZEC3002.Ctrl.TDInput Right_SensDoor = new ZEC3002.Ctrl.TDInput("Right_SensDoor", DIOModel, BoardID, 3, 2, false, false);
        //public static ZEC3002.Ctrl.TDInput Right_PusherHome = new ZEC3002.Ctrl.TDInput("Spare", DIOModel, BoardID, 3, 3, false, false);
        //public static ZEC3002.Ctrl.TDInput Right_PusherLmt = new ZEC3002.Ctrl.TDInput("Spare", DIOModel, BoardID, 3, 4, false, false);
        public static ZEC3002.Ctrl.TDInput RZ_MtrAlm = new ZEC3002.Ctrl.TDInput("RZ_MtrAlm", DIOModel, BoardID, 3, 5, false, false);

        public static ZEC3002.Ctrl.TDInput Right_SensMagPsnt1 = new ZEC3002.Ctrl.TDInput("Right_SensMagPsnt1", DIOModel, BoardID, 4, 1, false, false);
        public static ZEC3002.Ctrl.TDInput Right_SensMagPsnt2 = new ZEC3002.Ctrl.TDInput("Right_SensMagPsnt2", DIOModel, BoardID, 4, 2, false, false);
        public static ZEC3002.Ctrl.TDInput Right_SensMagPsnt3 = new ZEC3002.Ctrl.TDInput("Right_SensMagPsnt3", DIOModel, BoardID, 4, 3, false, false);
        public static ZEC3002.Ctrl.TDInput Right_SensMagPsnt4 = new ZEC3002.Ctrl.TDInput("Right_SensMagPsnt4", DIOModel, BoardID, 4, 4, false, false);
        //public static ZEC3002.Ctrl.TDInput Ax4SDI5 = new ZEC3002.Ctrl.TDInput("Spare", DIOModel, BoardID, 4, 5, false, false);

        public static ZEC3002.Ctrl.TDInput LP_PusherJam = new ZEC3002.Ctrl.TDInput("LP_PusherJam", DIOModel, BoardID, 0, 1, false, false);
        //public static ZEC3002.Ctrl.TDInput DI2 = new ZEC3002.Ctrl.TDInput("Spare", DIOModel, BoardID, 0, 2, false, false);
        //public static ZEC3002.Ctrl.TDInput DI3 = new ZEC3002.Ctrl.TDInput("Spare", DIOModel, BoardID, 0, 3, false, false);
        //public static ZEC3002.Ctrl.TDInput DI4 = new ZEC3002.Ctrl.TDInput("Spare", DIOModel, BoardID, 0, 4, false, false);
        //public static ZEC3002.Ctrl.TDInput DI5 = new ZEC3002.Ctrl.TDInput("Spare", DIOModel, BoardID, 0, 5, false, false);
        //public static ZEC3002.Ctrl.TDInput DI6 = new ZEC3002.Ctrl.TDInput("Spare", DIOModel, BoardID, 0, 6, false, false);
        //public static ZEC3002.Ctrl.TDInput DI7 = new ZEC3002.Ctrl.TDInput("Spare", DIOModel, BoardID, 0, 7, false, false);

        public static ZEC3002.Ctrl.TDOutput LP_PusherRun = new ZEC3002.Ctrl.TDOutput("LP_PusherRun", DIOModel, BoardID, 0, 1, false, false);
        public static ZEC3002.Ctrl.TDOutput LP_PusherRev = new ZEC3002.Ctrl.TDOutput("LP_PusherRev", DIOModel, BoardID, 0, 2, false, false);
        //public static ZEC3002.Ctrl.TDOutput DO3 = new ZEC3002.Ctrl.TDOutput("Spare", DIOModel, BoardID, 0, 3, false, false);
        //public static ZEC3002.Ctrl.TDOutput DO4 = new ZEC3002.Ctrl.TDOutput("Spare", DIOModel, BoardID, 0, 4, false, false);
        //public static ZEC3002.Ctrl.TDOutput DO5 = new ZEC3002.Ctrl.TDOutput("Spare", DIOModel, BoardID, 0, 5, false, false);
        //public static ZEC3002.Ctrl.TDOutput DO6 = new ZEC3002.Ctrl.TDOutput("Spare", DIOModel, BoardID, 0, 6, false, false);
        //public static ZEC3002.Ctrl.TDOutput DO7 = new ZEC3002.Ctrl.TDOutput("Spare", DIOModel, BoardID, 0, 7, false, false);
        //public static ZEC3002.Ctrl.TDOutput DO8 = new ZEC3002.Ctrl.TDOutput("Spare", DIOModel, BoardID, 0, 8, false, false);

        public static bool MtrOnOff(ref ZEC3002.Ctrl.TAxis Axis, bool On)
        {
            if (!ZEC3002.Ctrl.BoardOpened(Axis.BoardID)) { return false; }

            if (On)
                return ZEC3002.Ctrl.ZM3xx_MotorOn(ref Axis);
            else
                return ZEC3002.Ctrl.ZM3xx_MotorOff(ref Axis);
        }
        public static bool MtrAlarm(ZEC3002.Ctrl.TAxis Axis)
        {
            ZEC3002.Ctrl.TDInput Alm = new ZEC3002.Ctrl.TDInput(Axis.Name + "_Alarm", DIOModel, BoardID, Axis.AxisID, 5, false, false);
            bool Alarm = ZEC3002.Ctrl.GetDI(ref Alm);

            switch (Axis.MotorPara.MotorAlarm)
            {
                case ZEC3002.Ctrl.TMotorAlarm.NORMALLY_CLOSE:
                    return !Alarm;
                case ZEC3002.Ctrl.TMotorAlarm.NORMALLY_OPEN:
                    return Alarm;
                default://ZEC3002.Ctrl.TMotorAlarm.DISABLE:
                    return false;
            }
        }

        public static ZEC3002.Ctrl.TDInput NameGetInput(string Name)
        {
            if (Name.Contains("SensLZHome")) return ElevIO.SensLZHome;
            if (Name.Contains("Left_SensDoor")) return ElevIO.Left_SensDoor;
            if (Name.Contains("LP_PusherHome")) return ElevIO.LP_PusherHome;
            if (Name.Contains("LP_PusherLmt")) return ElevIO.LP_PusherLmt;
            if (Name.Contains("LZ_MtrAlm")) return ElevIO.LZ_MtrAlm;

            if (Name.Contains("Left_SensMagPsnt1")) return ElevIO.Left_SensMagPsnt1;
            if (Name.Contains("Left_SensMagPsnt2")) return ElevIO.Left_SensMagPsnt2;
            if (Name.Contains("Left_SensMagPsnt3")) return ElevIO.Left_SensMagPsnt3;
            if (Name.Contains("Left_SensMagPsnt4")) return ElevIO.Left_SensMagPsnt4;
            if (Name.Contains("CW_MtrAlm")) return ElevIO.LZ_MtrAlm;

            if (Name.Contains("SensRZHome")) return ElevIO.SensRZHome;
            if (Name.Contains("Right_SensDoor")) return ElevIO.Right_SensDoor;
            if (Name.Contains("RZ_MtrAlm")) return ElevIO.RZ_MtrAlm;

            if (Name.Contains("Right_SensMagPsnt1")) return ElevIO.Right_SensMagPsnt1;
            if (Name.Contains("Right_SensMagPsnt2")) return ElevIO.Right_SensMagPsnt2;
            if (Name.Contains("Right_SensMagPsnt3")) return ElevIO.Right_SensMagPsnt3;
            if (Name.Contains("Right_SensMagPsnt4")) return ElevIO.Right_SensMagPsnt4;

            if (Name.Contains("LP_PusherJam")) return ElevIO.LP_PusherJam;

            return new ZEC3002.Ctrl.TDInput("Invalid", ZEC3002.Ctrl.TDIOModel.ZIO3201, BoardID, 0, 0, false, false);
        }
        public static string NameGetInputInfo(string Name)
        {
            ZEC3002.Ctrl.TDInput Input = NameGetInput(Name);
            return ElevIO.InputLabel[Input.AxisID, Input.Add] + " " + Input.Name;
        }
        public static ZEC3002.Ctrl.TDOutput NameGetOutput(string Name)
        {
            if (Name.Contains("LP_PusherRun")) return ElevIO.LP_PusherRun;
            if (Name.Contains("LP_PusherRev")) return ElevIO.LP_PusherRev;

            return new ZEC3002.Ctrl.TDOutput("Invalid", ZEC3002.Ctrl.TDIOModel.ZIO3201, BoardID, 0, 0, false, false);
        }
        public static string NameGetOutputInfo(string Name)
        {
            if (Name.Contains("MtrOn"))
            {
                if (Name.Contains("LZ_MtrOn")) return "[MtrOn Axis" + ElevIO.LZAxis.AxisID + "] ";
                if (Name.Contains("CW_MtrOn")) return "[MtrOn Axis" + ElevIO.CWAxis.AxisID + "] ";
                if (Name.Contains("RZ_MtrOn")) return "[MtrOn Axis" + ElevIO.RZAxis.AxisID + "] ";
                if (Name.Contains("LP_MtrOn")) return "[MtrOn Axis" + ElevIO.LPAxis.AxisID + "] ";
            }

            ZEC3002.Ctrl.TDOutput Output = NameGetOutput(Name);
            return ElevIO.OutputLabel[Output.Add] + " " + Output.Name;
        }

        public static void LoadDIOAdd(string FullFilename)
        {
            NUtils.IniFile IniFile = new NUtils.IniFile(FullFilename);

            BoardID = (byte)IniFile.ReadInteger("ElevIO", "BoardID", 2);

            #region DI
            IODefine.LoadDIOAdd(ref IniFile, ref SensLZHome);
            IODefine.LoadDIOAdd(ref IniFile, ref Left_SensDoor);
            IODefine.LoadDIOAdd(ref IniFile, ref LP_PusherHome);
            IODefine.LoadDIOAdd(ref IniFile, ref LP_PusherLmt);
            IODefine.LoadDIOAdd(ref IniFile, ref LZ_MtrAlm);

            IODefine.LoadDIOAdd(ref IniFile, ref Left_SensMagPsnt1);
            IODefine.LoadDIOAdd(ref IniFile, ref Left_SensMagPsnt2);
            IODefine.LoadDIOAdd(ref IniFile, ref Left_SensMagPsnt3);
            IODefine.LoadDIOAdd(ref IniFile, ref Left_SensMagPsnt4);
            IODefine.LoadDIOAdd(ref IniFile, ref CW_MtrAlm);

            IODefine.LoadDIOAdd(ref IniFile, ref SensRZHome);
            IODefine.LoadDIOAdd(ref IniFile, ref Right_SensDoor);
            //IODefine.LoadDIOAdd(ref IniFile, ref Right_PusherHome);
            //IODefine.LoadDIOAdd(ref IniFile, ref Right_PusherLmt);
            IODefine.LoadDIOAdd(ref IniFile, ref RZ_MtrAlm);

            IODefine.LoadDIOAdd(ref IniFile, ref Right_SensMagPsnt1);
            IODefine.LoadDIOAdd(ref IniFile, ref Right_SensMagPsnt2);
            IODefine.LoadDIOAdd(ref IniFile, ref Right_SensMagPsnt3);
            IODefine.LoadDIOAdd(ref IniFile, ref Right_SensMagPsnt4);

            IODefine.LoadDIOAdd(ref IniFile, ref LP_PusherJam);
            //IODefine.LoadDIOAdd(ref IniFile, ref  DI2);
            //IODefine.LoadDIOAdd(ref IniFile, ref  DI3);
            //IODefine.LoadDIOAdd(ref IniFile, ref  DI4);
            //IODefine.LoadDIOAdd(ref IniFile, ref  DI5);
            //IODefine.LoadDIOAdd(ref IniFile, ref  DI6);
            //IODefine.LoadDIOAdd(ref IniFile, ref  DI7);
            #endregion
            #region DO
            IODefine.LoadDIOAdd(ref IniFile, ref LP_PusherRun);
            IODefine.LoadDIOAdd(ref IniFile, ref LP_PusherRev);
            //IODefine.LoadDIOAdd(ref IniFile, ref  DO3);
            //IODefine.LoadDIOAdd(ref IniFile, ref  DO4);
            //IODefine.LoadDIOAdd(ref IniFile, ref  DO5);
            //IODefine.LoadDIOAdd(ref IniFile, ref  DO6);
            //IODefine.LoadDIOAdd(ref IniFile, ref  DO7);
            //IODefine.LoadDIOAdd(ref IniFile, ref  DO8);
            #endregion
        }
        public static void SaveDIOAdd(string FullFilename)
        {
            NUtils.IniFile IniFile = new NUtils.IniFile(FullFilename);

            #region DI
            IODefine.SaveDIOAdd(ref IniFile, SensLZHome);
            IODefine.SaveDIOAdd(ref IniFile, Left_SensDoor);
            IODefine.SaveDIOAdd(ref IniFile, LP_PusherHome);
            IODefine.SaveDIOAdd(ref IniFile, LP_PusherLmt);
            IODefine.SaveDIOAdd(ref IniFile, LZ_MtrAlm);

            IODefine.SaveDIOAdd(ref IniFile, Left_SensMagPsnt1);
            IODefine.SaveDIOAdd(ref IniFile, Left_SensMagPsnt2);
            IODefine.SaveDIOAdd(ref IniFile, Left_SensMagPsnt3);
            IODefine.SaveDIOAdd(ref IniFile, Left_SensMagPsnt4);
            IODefine.SaveDIOAdd(ref IniFile, CW_MtrAlm);

            IODefine.SaveDIOAdd(ref IniFile, SensRZHome);
            IODefine.SaveDIOAdd(ref IniFile, Right_SensDoor);
            //IODefine.SaveDIOAdd(ref IniFile, Right_PusherHome);
            //IODefine.SaveDIOAdd(ref IniFile, Right_PusherLmt);
            IODefine.SaveDIOAdd(ref IniFile, RZ_MtrAlm);

            IODefine.SaveDIOAdd(ref IniFile, Right_SensMagPsnt1);
            IODefine.SaveDIOAdd(ref IniFile, Right_SensMagPsnt2);
            IODefine.SaveDIOAdd(ref IniFile, Right_SensMagPsnt3);
            IODefine.SaveDIOAdd(ref IniFile, Right_SensMagPsnt4);

            IODefine.SaveDIOAdd(ref IniFile, LP_PusherJam);
            //IODefine.SaveDIOAdd(ref IniFile,  DI2);
            //IODefine.SaveDIOAdd(ref IniFile,  DI3);
            //IODefine.SaveDIOAdd(ref IniFile,  DI4);
            //IODefine.SaveDIOAdd(ref IniFile,  DI5);
            //IODefine.SaveDIOAdd(ref IniFile,  DI6);
            //IODefine.SaveDIOAdd(ref IniFile,  DI7);
            #endregion
            #region DO
            IODefine.SaveDIOAdd(ref IniFile, LP_PusherRun);
            IODefine.SaveDIOAdd(ref IniFile, LP_PusherRev);
            //IODefine.SaveDIOAdd(ref IniFile,  DO3);
            //IODefine.SaveDIOAdd(ref IniFile,  DO4);
            //IODefine.SaveDIOAdd(ref IniFile,  DO5);
            //IODefine.SaveDIOAdd(ref IniFile,  DO6);
            //IODefine.SaveDIOAdd(ref IniFile,  DO7);
            //IODefine.SaveDIOAdd(ref IniFile,  DO8);
            #endregion
        }

        public static void LoadMotorPara(string FullFilename)
        {
            NUtils.IniFile IniFile = new NUtils.IniFile(FullFilename);

            IODefine.LoadMotorPara(ref IniFile, ref LZAxis);
            IODefine.LoadMotorPara(ref IniFile, ref CWAxis);
            IODefine.LoadMotorPara(ref IniFile, ref RZAxis);
            IODefine.LoadMotorPara(ref IniFile, ref LPAxis);
        }
        public static void SaveMotorPara(string FullFilename)
        {
            NUtils.IniFile IniFile = new NUtils.IniFile(FullFilename);

            IODefine.SaveMotorPara(ref IniFile, LZAxis);
            IODefine.SaveMotorPara(ref IniFile, CWAxis);
            IODefine.SaveMotorPara(ref IniFile, RZAxis);
            IODefine.SaveMotorPara(ref IniFile, LPAxis);
        }
    }

    public class Conv2IO
    {
        public static bool Enabled = false;

        public static byte BoardID = 3;
        public static ZEC3002.Ctrl.TDIOModel DIOModel = ZEC3002.Ctrl.TDIOModel.ZM324;

        private static ZEC3002.Ctrl.TMotorPara MPara = new ZEC3002.Ctrl.TMotorPara();
        public static ZEC3002.Ctrl.TAxis Axis1 = new ZEC3002.Ctrl.TAxis("SpareAxis1", DIOModel, BoardID, 1, MPara, false);
        public static ZEC3002.Ctrl.TAxis Axis2 = new ZEC3002.Ctrl.TAxis("SpareAxis2", DIOModel, BoardID, 2, MPara, false);
        public static ZEC3002.Ctrl.TAxis Axis3 = new ZEC3002.Ctrl.TAxis("SpareAxis3", DIOModel, BoardID, 3, MPara, false);
        public static ZEC3002.Ctrl.TAxis Axis4 = new ZEC3002.Ctrl.TAxis("SpareAxis4", DIOModel, BoardID, 4, MPara, false);

        public static ZEC3002.Ctrl.TDInput Out_SensPsnt = new ZEC3002.Ctrl.TDInput("Out2_SensPsnt", DIOModel, BoardID, 1, 1, false, false);
        public static ZEC3002.Ctrl.TDInput In_SensPsnt = new ZEC3002.Ctrl.TDInput("In2_SensPsnt", DIOModel, BoardID, 1, 2, false, false);
        public static ZEC3002.Ctrl.TDInput Pos_VacSw = new ZEC3002.Ctrl.TDInput("Pos2_Vac", DIOModel, BoardID, 1, 3, false, false);
        //public static ZEC3002.Ctrl.TDInput Spare = new ZEC3002.Ctrl.TDInput("Spare", DIOModel, BoardID, 1, 4, false, false);
        public static ZEC3002.Ctrl.TDInput SensDoor2 = new ZEC3002.Ctrl.TDInput("SensDoor2", DIOModel, BoardID, 2, 1, false, false);
        //public static ZEC3002.Ctrl.TDInput Spare22 = new ZEC3002.Ctrl.TDInput("Spare22", DIOModel, BoardID, 2, 2, false, false);
        public static ZEC3002.Ctrl.TDInput Out_SensKickerExt = new ZEC3002.Ctrl.TDInput("Out2_SensKickerExt", DIOModel, BoardID, 2, 3, false, false);
        public static ZEC3002.Ctrl.TDInput Out_SensKickerRet = new ZEC3002.Ctrl.TDInput("Out2_SensKickerRet", DIOModel, BoardID, 2, 4, false, false);

        public static ZEC3002.Ctrl.TDInput Pos_SensPsnt = new ZEC3002.Ctrl.TDInput("Pos2_SensPsnt", DIOModel, BoardID, 3, 1, false, false);
        public static ZEC3002.Ctrl.TDInput Pos_SensStopperUp = new ZEC3002.Ctrl.TDInput("Pos2_SensStopperUp", DIOModel, BoardID, 3, 2, false, false);
        public static ZEC3002.Ctrl.TDInput Pos_SensLifterDn = new ZEC3002.Ctrl.TDInput("Pos2_SensLifterD", DIOModel, BoardID, 3, 3, false, false);
        public static ZEC3002.Ctrl.TDInput Pos_SensLifterUp = new ZEC3002.Ctrl.TDInput("Pos2_SensLifterUp", DIOModel, BoardID, 3, 4, false, false);
        //public static ZEC3002.Ctrl.TDInput Spare = new ZEC3002.Ctrl.TDInput("Spare", DIOModel, BoardID, 4, 1, false, false);
        //public static ZEC3002.Ctrl.TDInput Spare = new ZEC3002.Ctrl.TDInput("Spare", DIOModel, BoardID, 4, 2, false, false);
        //public static ZEC3002.Ctrl.TDInput Spare = new ZEC3002.Ctrl.TDInput("Spare", DIOModel, BoardID, 4, 3, false, false);
        //public static ZEC3002.Ctrl.TDInput Spare = new ZEC3002.Ctrl.TDInput("Spare", DIOModel, BoardID, 4, 4, false, false);

        public static ZEC3002.Ctrl.TDInput Pos_HeaterAlarm = new ZEC3002.Ctrl.TDInput("Pos2_HeaterAlarm", DIOModel, BoardID, 0, 1, false, false);
        //public static ZEC3002.Ctrl.TDInput Pos2_HeaterAlarm = new ZEC3002.Ctrl.TDInput("Pos2_HeaterAlarm", DIOModel, BoardID, 0, 2, false, false);
        //public static ZEC3002.Ctrl.TDInput DI3 = new ZEC3002.Ctrl.TDInput("Spare", DIOModel, BoardID, 0, 3, false, false);
        //public static ZEC3002.Ctrl.TDInput DI4 = new ZEC3002.Ctrl.TDInput("Spare", DIOModel, BoardID, 0, 4, false, false);
        //public static ZEC3002.Ctrl.TDInput DI5 = new ZEC3002.Ctrl.TDInput("Spare", DIOModel, BoardID, 0, 5, false, false);
        //public static ZEC3002.Ctrl.TDInput DI6 = new ZEC3002.Ctrl.TDInput("Spare", DIOModel, BoardID, 0, 6, false, false);
        //public static ZEC3002.Ctrl.TDInput DI7 = new ZEC3002.Ctrl.TDInput("Spare", DIOModel, BoardID, 0, 7, false, false);

        public static ZEC3002.Ctrl.TDOutput Conv_MotorEn = new ZEC3002.Ctrl.TDOutput("Conv2_MotorEn", DIOModel, BoardID, 0, 1, false, false);
        public static ZEC3002.Ctrl.TDOutput Pos_SvStopperUp = new ZEC3002.Ctrl.TDOutput("Pos2_SvStopperUp", DIOModel, BoardID, 0, 2, false, false);
        //public static ZEC3002.Ctrl.TDOutput DO3 = new ZEC3002.Ctrl.TDOutput("Spare", DIOModel, BoardID, 0, 3, false, false);
        public static ZEC3002.Ctrl.TDOutput Pos_SvLifterUp = new ZEC3002.Ctrl.TDOutput("Pos2_SvLifterUp", DIOModel, BoardID, 0, 4, false, false);
        //public static ZEC3002.Ctrl.TDOutput DO5 = new ZEC3002.Ctrl.TDOutput("Spare", DIOModel, BoardID, 0, 5, false, false);
        public static ZEC3002.Ctrl.TDOutput Pos_SvVac = new ZEC3002.Ctrl.TDOutput("Pos2_SvVac", DIOModel, BoardID, 0, 6, false, false);
        //public static ZEC3002.Ctrl.TDOutput DO7 = new ZEC3002.Ctrl.TDOutput("Spare", DIOModel, BoardID, 0, 7, false, false);
        public static ZEC3002.Ctrl.TDOutput Out_SvKickerExt = new ZEC3002.Ctrl.TDOutput("Out2_SvKickerExt", DIOModel, BoardID, 0, 8, false, false);

        public static ZEC3002.Ctrl.TDInput NameGetInput(string Name)
        {
            if (Name.Contains("In2_SensPsnt")) return Conv2IO.In_SensPsnt;
            if (Name.Contains("Out2_SensPsnt")) return Conv2IO.Out_SensPsnt;

            if (Name.Contains("Pos2_VacSw")) return Conv2IO.Pos_VacSw;
            if (Name.Contains("SensDoor2")) return Conv2IO.SensDoor2;
            if (Name.Contains("Out2_SensKickerExt")) return Conv2IO.Out_SensKickerExt;
            if (Name.Contains("Out2_SensKickerRet")) return Conv2IO.Out_SensKickerRet;
            if (Name.Contains("Pos2_SensPsnt")) return Conv2IO.Pos_SensPsnt;
            if (Name.Contains("Pos2_SensStopperUp")) return Conv2IO.Pos_SensStopperUp;
            if (Name.Contains("Pos2_SensLifterDn")) return Conv2IO.Pos_SensLifterDn;
            if (Name.Contains("Pos2_SensLifterUp")) return Conv2IO.Pos_SensLifterUp;
            if (Name.Contains("Pos2_HeaterAlarm")) return Conv2IO.Pos_HeaterAlarm;

            return new ZEC3002.Ctrl.TDInput("Invalid", ZEC3002.Ctrl.TDIOModel.ZIO3201, BoardID, 0, 0, false, false);
        }
        public static string NameGetInputInfo(string Name)
        {
            ZEC3002.Ctrl.TDInput Input = NameGetInput(Name);
            return ConvIO.InputLabel[Input.Add] + " " + Input.Name;
        }
        public static ZEC3002.Ctrl.TDOutput NameGetOutput(string Name)
        {
            if (Name.Contains("Conv2_MotorEn")) return Conv2IO.Conv_MotorEn;
            if (Name.Contains("Pos2_SvStopperUp")) return Conv2IO.Pos_SvStopperUp;
            if (Name.Contains("Pos2_SvLifterUp")) return Conv2IO.Pos_SvLifterUp;
            if (Name.Contains("Pos2_SvVac")) return Conv2IO.Pos_SvVac;
            if (Name.Contains("Out2_SvKickerExt")) return Conv2IO.Out_SvKickerExt;

            return new ZEC3002.Ctrl.TDOutput("Invalid", ZEC3002.Ctrl.TDIOModel.ZIO3201, BoardID, 0, 0, false, false);
        }
        public static string NameGetOutputInfo(string Name)
        {
            ZEC3002.Ctrl.TDOutput Output = NameGetOutput(Name);
            return ConvIO.OutputLabel[Output.Add] + " " + Output.Name;
        }

        public static void LoadDIOAdd(string FullFilename)
        {
            NUtils.IniFile IniFile = new NUtils.IniFile(FullFilename);

            Enabled = IniFile.ReadBool("Conv2IO", "Enabled", false);

            if (!Enabled) return;

            BoardID = (byte)IniFile.ReadInteger("ElevIO", "BoardID", 3);

            #region 
            IODefine.LoadDIOAdd(ref IniFile, ref In_SensPsnt);
            IODefine.LoadDIOAdd(ref IniFile, ref Out_SensPsnt);
            IODefine.LoadDIOAdd(ref IniFile, ref Pos_VacSw);
            IODefine.LoadDIOAdd(ref IniFile, ref SensDoor2);
            IODefine.LoadDIOAdd(ref IniFile, ref Out_SensKickerExt);
            IODefine.LoadDIOAdd(ref IniFile, ref Out_SensKickerRet);

            IODefine.LoadDIOAdd(ref IniFile, ref Pos_SensPsnt);
            IODefine.LoadDIOAdd(ref IniFile, ref Pos_SensStopperUp);
            IODefine.LoadDIOAdd(ref IniFile, ref Pos_SensLifterDn);
            IODefine.LoadDIOAdd(ref IniFile, ref Pos_SensLifterUp);

            IODefine.LoadDIOAdd(ref IniFile, ref Pos_HeaterAlarm);

            IODefine.LoadDIOAdd(ref IniFile, ref Conv_MotorEn);
            IODefine.LoadDIOAdd(ref IniFile, ref Pos_SvStopperUp);
            IODefine.LoadDIOAdd(ref IniFile, ref Pos_SvLifterUp);
            IODefine.LoadDIOAdd(ref IniFile, ref Pos_SvVac);
            IODefine.LoadDIOAdd(ref IniFile, ref Out_SvKickerExt);
            #endregion
        }
        public static void SaveDIOAdd(string FullFilename)
        {
            NUtils.IniFile IniFile = new NUtils.IniFile(FullFilename);

            IniFile.WriteBool("Conv2IO", "Enabled", Enabled);

            if (!Enabled) return;

            #region 
            IODefine.SaveDIOAdd(ref IniFile, In_SensPsnt);
            IODefine.SaveDIOAdd(ref IniFile, Out_SensPsnt);
            IODefine.SaveDIOAdd(ref IniFile, Pos_VacSw);
            IODefine.SaveDIOAdd(ref IniFile, SensDoor2);
            IODefine.SaveDIOAdd(ref IniFile, Out_SensKickerExt);
            IODefine.SaveDIOAdd(ref IniFile, Out_SensKickerRet);

            IODefine.SaveDIOAdd(ref IniFile, Pos_SensPsnt);
            IODefine.SaveDIOAdd(ref IniFile, Pos_SensStopperUp);
            IODefine.SaveDIOAdd(ref IniFile, Pos_SensLifterDn);
            IODefine.SaveDIOAdd(ref IniFile, Pos_SensLifterUp);

            IODefine.SaveDIOAdd(ref IniFile, Pos_HeaterAlarm);

            IODefine.SaveDIOAdd(ref IniFile, Conv_MotorEn);
            IODefine.SaveDIOAdd(ref IniFile, Pos_SvStopperUp);
            IODefine.SaveDIOAdd(ref IniFile, Pos_SvLifterUp);
            IODefine.SaveDIOAdd(ref IniFile, Pos_SvVac);
            IODefine.SaveDIOAdd(ref IniFile, Out_SvKickerExt);
            #endregion
        }
    }
}
