using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace NDispWin
{
    class TEEvent
    {
        public int Code = 0;
        public string Name = "";

        public TEEvent(int code, string name)
        {
            Code = code;
            Name = name;
        }
        public void Set(string paraName, string paraValue)
        {
            Event.LastEvent = this;

            if (!GDefineN.EnableEventDebugLog && Code == Event.DEBUG_INFO.Code) return;
            Log.AddToEventLog(this.Code, this.Name, paraName + " " + paraValue) ;
            GDefine.sgc2.SendEvent(this.Code + "," + this.Name + "," + paraName + "," + paraValue);
        }
        public void Set()
        {
            Event.LastEvent = this;

            if (!GDefineN.EnableEventDebugLog && Code == Event.DEBUG_INFO.Code) return;
            Log.AddToEventLog(this.Code, this.Name);
            GDefine.sgc2.SendEvent(this.Code + "," + this.Name);
        }

        public static List<string> CEID_List()
        {
            var ceIDlist = typeof(Event).GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(x => x.FieldType == typeof(TEEvent))
                .Select(x => (TEEvent)x.GetValue(null)).ToArray();

            List<string> list = new List<string>();
            foreach (var para in ceIDlist)
            {
                list.Add($"{para.Code:d4},{para.Name}");
            }

            return list;
        }
        public static List<string> ALID_List()
        {
            var alIDlist = typeof(ErrCode).GetFields(BindingFlags.Public | BindingFlags.Static).ToArray();

            List<string> list = new List<string>();
            foreach (var para in alIDlist)
            {
                list.Add($"{para.GetValue(para):d4},{para.Name}");
            }

            return list;
        }
    }

    class Event
    {
        internal static TEEvent LastEvent = new TEEvent(0, "");

        const int APP_EVENT = 1000;

        const int APP_EVENT_OP = APP_EVENT + 0;
        public static TEEvent APP_START = new TEEvent(APP_EVENT_OP + 0, "App StartUp.");
        public static TEEvent APP_CLOSE = new TEEvent(APP_EVENT_OP + 1, "App Close.");
        public static TEEvent ERROR = new TEEvent(APP_EVENT_OP + 2, "Error.");
        public static TEEvent CTRL = new TEEvent(APP_EVENT_OP + 3, "Control.");//log control
        public static TEEvent APP_INFO = new TEEvent(APP_EVENT_OP + 4, "App Info.");
        public static TEEvent DEBUG_INFO = new TEEvent(APP_EVENT_OP + 6, "Debug Info.");

        public static TEEvent OP_START_RUN = new TEEvent(APP_EVENT_OP + 10, "Auto Start Run.");
        public static TEEvent OP_STOP_RUN = new TEEvent(APP_EVENT_OP + 11, "Auto Stop Run.");
        public static TEEvent OP_INIT_SYSTEM = new TEEvent(APP_EVENT_OP + 19, "App Init System.");
        public static TEEvent OP_INIT_GANTRY_START = new TEEvent(APP_EVENT_OP + 20, "App Init Gantry Start.");
        public static TEEvent OP_INIT_GANTRY_COMPLETE = new TEEvent(APP_EVENT_OP + 21, "App Init Gantry Complete.");
        public static TEEvent OP_INIT_CONV_START = new TEEvent(APP_EVENT_OP + 22, "App Init Conveyor Start.");
        public static TEEvent OP_INIT_CONV_COMPLETE = new TEEvent(APP_EVENT_OP + 23, "App Init Conveyor Complete.");
        public static TEEvent OP_INIT_LR_LINE_START = new TEEvent(APP_EVENT_OP + 24, "App Init LR Line Start.");
        public static TEEvent OP_INIT_LR_LINE_COMPLETE = new TEEvent(APP_EVENT_OP + 25, "App Init LR Line Complete.");
        public static TEEvent OP_INIT_LEFT_LINE_START = new TEEvent(APP_EVENT_OP + 26, "App Init Left Line Start.");
        public static TEEvent OP_INIT_LEFT_LINE_COMPLETE = new TEEvent(APP_EVENT_OP + 27, "App Init Left Line Complete.");
        public static TEEvent OP_INIT_RIGHT_LINE_START = new TEEvent(APP_EVENT_OP + 28, "App Init Left Line Start.");
        public static TEEvent OP_INIT_RIGHT_LINE_COMPLETE = new TEEvent(APP_EVENT_OP + 29, "App Init Left Line Complete.");

        const int DISPCORE_EVENT = 2000;
        public static TEEvent TEST_EVENT = new TEEvent(DISPCORE_EVENT, "Test Event.");

        const int DISPCORE_EVENT_DISPTOOLS = 2100;
        #region 
        public static TEEvent DISPTOOLS_TEACH_NEEDLE = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 10, "DispTools Teach Needle.");
        public static TEEvent DISPTOOLS_TEACH_NEEDLE_CANCEL = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 11, "DispTools Teach Needle Cancel.");
        public static TEEvent DISPTOOLS_GOTO_PUMP_MAINT_POS = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 12, "DispTools Goto Pump Maint Pos.");
        public static TEEvent DISPTOOLS_GOTO_MACHINE_MAINT_POS = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 13, "DispTools Goto Machine Maint Pos.");
        public static TEEvent DISPTOOLS_CLEAN = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 15, "DispTools Clean.");
        public static TEEvent DISPTOOLS_PURGE = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 16, "DispTools Purge.");
        public static TEEvent DISPTOOLS_FLUSH = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 17, "DispTools Flush.");
        public static TEEvent DISPTOOLS_CLEANPURGE_CANCEL = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 18, "DispTools Clean Purge Cancel.");
        public static TEEvent DISPTOOLS_WEIGHT_ADJUST = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 20, "DispTools Weight Adjust.");
        public static TEEvent DISPTOOLS_WEIGHT_CALIBRATE = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 21, "DispTools Weight Calibrate.");
        public static TEEvent DISPTOOLS_WEIGHT_MEASURE = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 22, "DispTools Weight Measure.");
        public static TEEvent DISPTOOLS_WEIGHT_CANCEL = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 23, "DispTools Weight Cancel.");
        public static TEEvent DISPTOOLS_ADJ_MATERIAL_TIMER = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 25, "DispTools Adjust Material Timer.");
        public static TEEvent DISPTOOLS_ADJ_MATERIAL_EXP = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 26, "DispTools Adjust Material Expiry.");
        public static TEEvent DISPTOOLS_ADJ_MATERIAL_EXP_CANCEL = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 26, "DispTools Adjust Material Expiry Cancel.");
        public static TEEvent DISPTOOLS_FORCE_SINGLE = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 30, "DispTools Force Single.");
        public static TEEvent DISPTOOLS_PUMP_ADJUST = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 32, "DispTools Pump Adjust.");
        public static TEEvent DISPTOOLS_ORIGIN_ADJUST = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 33, "DispTools Origin Adjust.");
        public static TEEvent DISPTOOLS_ORIGIN = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 34, "DispTools Origin.");
        public static TEEvent DISPTOOLS_PUMP_ACTION_1 = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 40, "DispTools Pump Action 1.");
        public static TEEvent DISPTOOLS_PUMP_ACTION_2 = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 41, "DispTools Pump Action 2.");
        public static TEEvent DISPTOOLS_PUMP_ACTION_3 = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 42, "DispTools Pump Action 3.");
        public static TEEvent DISPTOOLS_PUMP_ACTION_4 = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 43, "DispTools Pump Action 4.");
        public static TEEvent DISPTOOLS_PUMP_ACTION_5 = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 44, "DispTools Pump Action 5.");
        public static TEEvent DISPTOOLS_PUMP_ACTION_CANCEL = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 45, "DispTools Pump Action Cancel.");
        public static TEEvent DISPTOOLS_START_IDLE = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 50, "DispTools Start Idle.");
        public static TEEvent DISPTOOLS_PURGE_STAGE = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 51, "DispTools Purge Stage.");
        public static TEEvent DISPTOOLS_VIEW = new TEEvent(DISPCORE_EVENT_DISPTOOLS + 52, "DispTools View.");
        #endregion

        const int DISPCORE_EVENT_OP = DISPCORE_EVENT + 200;
        public static TEEvent OP_WEIGHT_ADJUST = new TEEvent(DISPCORE_EVENT_OP + 0, "Weight Adjust.");
        public static TEEvent OP_WEIGHT_CALIBRATION = new TEEvent(DISPCORE_EVENT_OP + 1, "Weight Calibration.");
        public static TEEvent OP_WEIGHT_MEASURE = new TEEvent(DISPCORE_EVENT_OP + 2, "Weight Measure.");
        public static TEEvent OP_FLOWRATE1_CALIBRATION = new TEEvent(DISPCORE_EVENT_OP + 3, "Flowrate1 Calibration.");
        public static TEEvent OP_FLOWRATE2_CALIBRATION = new TEEvent(DISPCORE_EVENT_OP + 4, "Flowrate2 Calibration.");
        public static TEEvent OP_WEIGHT1_MEASURE = new TEEvent(DISPCORE_EVENT_OP + 5, "Weight1 Measure.");
        public static TEEvent OP_WEIGHT2_MEASURE = new TEEvent(DISPCORE_EVENT_OP + 6, "Weight2 Measure.");
        public static TEEvent OP_IDLE_PURGE_START = new TEEvent(DISPCORE_EVENT_OP + 10, "Start Idle Purge.");
        public static TEEvent OP_IDLE_PURGE_STOP = new TEEvent(DISPCORE_EVENT_OP + 11, "Stop Idle Purge.");
        public static TEEvent OP_MOVE_TO_IDLE = new TEEvent(DISPCORE_EVENT_OP + 12, "Move to Idle.");

        public static TEEvent OP_DISP_LOAD_DEVICE = new TEEvent(DISPCORE_EVENT_OP + 15, "Load Device.");
        public static TEEvent OP_DISP_LOAD_DISP_RECIPE = new TEEvent(DISPCORE_EVENT_OP + 16, "Load Disp Recipe.");
        public static TEEvent OP_DISP_LOAD_MHS_RECIPE = new TEEvent(DISPCORE_EVENT_OP + 17, "Load MHS Recipe.");
        public static TEEvent OP_DISP_AUTO_LOAD_DEVICE_INVALID = new TEEvent(DISPCORE_EVENT_OP + 17, "Auto Load Device is Invalid.");
        public static TEEvent OP_DISP_AUTO_LOAD_DEVICE_NO_FOUND = new TEEvent(DISPCORE_EVENT_OP + 18, "Auto Load Device not Found.");
        public static TEEvent OP_DISP_AUTO_LOAD_SUCCESSFUL = new TEEvent(DISPCORE_EVENT_OP + 19, "Auto Load Device successful.");
        public static TEEvent OP_EXT_VISION_OK = new TEEvent(DISPCORE_EVENT_OP + 30, "Ext Vision Inspection OK.");
        public static TEEvent OP_EXT_VISION_NG = new TEEvent(DISPCORE_EVENT_OP + 31, "Ext Vision Inspection NG.");
        public static TEEvent OP_OPTION_CHANGED = new TEEvent(DISPCORE_EVENT_OP + 40, "Change Option.");

        public static TEEvent OP_LMDS_TESTER_SEQ = new TEEvent(DISPCORE_EVENT_OP + 90, "Lmds Tester Seq.");
        public static TEEvent OP_CHECK_MENISCUS = new TEEvent(DISPCORE_EVENT_OP + 91, "Check Meniscus.");
        public static TEEvent OP_CHECK_MENISCUS_OOS = new TEEvent(DISPCORE_EVENT_OP + 92, "Check Meniscus OOS.");

        public static TEEvent OP_LOT_START = new TEEvent(DISPCORE_EVENT_OP + 95, "Lot Start.");
        public static TEEvent OP_LOT_END = new TEEvent(DISPCORE_EVENT_OP + 96, "Lot End.");

        public static TEEvent CLEAN_NEEDLE = new TEEvent(DISPCORE_EVENT_OP + 100, "Clean Needle.");
        public static TEEvent PURGE_NEEDLE = new TEEvent(DISPCORE_EVENT_OP + 101, "Purge Needle.");
        public static TEEvent FLUSH_NEEDLE = new TEEvent(DISPCORE_EVENT_OP + 101, "Flush Needle.");

        const int DISPCORE_EVENT_PROG = DISPCORE_EVENT + 400;
        public static TEEvent PROG_UNLOCK_Z = new TEEvent(DISPCORE_EVENT_PROG + 0, "Program Mode Unlock Z.");

        const int DISPCORE_EVENT_SETUP = DISPCORE_EVENT + 500;
        public static TEEvent SETUP_BYPASS_TEACH_NEEDLE = new TEEvent(DISPCORE_EVENT_SETUP + 0, "ByPass Teach Needle.");
        public static TEEvent TEACH_NEEDLE_OFST = new TEEvent(DISPCORE_EVENT_SETUP + 1, "Teach Needle Offset.");
        public static TEEvent SETUP_EVENT = new TEEvent(DISPCORE_EVENT_SETUP + 2, "Setup.");
        public static TEEvent SETUP_HEAD1_OFST_UPDATE = new TEEvent(DISPCORE_EVENT_SETUP + 50, "Head1 Offset Update.");
        public static TEEvent SETUP_HEAD2_OFST_UPDATE = new TEEvent(DISPCORE_EVENT_SETUP + 51, "Head2 Offset Update.");
        public static TEEvent SETUP_LASER_OFST_UPDATE = new TEEvent(DISPCORE_EVENT_SETUP + 53, "Laser Offset Update.");
        public static TEEvent SETUP_REFZ_UPDATE = new TEEvent(DISPCORE_EVENT_SETUP + 54, "RefZ Update.");
        public static TEEvent SETUP_TOUCH_POS_UPDATE = new TEEvent(DISPCORE_EVENT_SETUP + 55, "TouchPos Update.");
        public static TEEvent SET_FOCUS0_UPDATE = new TEEvent(DISPCORE_EVENT_SETUP + 60, "Set Focus0.");
        public static TEEvent SET_FOCUS1_UPDATE = new TEEvent(DISPCORE_EVENT_SETUP + 61, "Set Focus1.");
        public static TEEvent SET_FOCUS2_UPDATE = new TEEvent(DISPCORE_EVENT_SETUP + 62, "Set Focus2.");
        public static TEEvent SET_FOCUS3_UPDATE = new TEEvent(DISPCORE_EVENT_SETUP + 63, "Set Focus3.");

        public static TEEvent SETUP_TEMPSENSOR_OFST_UPDATE = new TEEvent(DISPCORE_EVENT_SETUP + 65, "Temp Sensor Offset Update.");
        public static TEEvent SETUP_TEMPSENSOR_VALUE = new TEEvent(DISPCORE_EVENT_SETUP + 65, "Temp Sensor Value.");

        const int DISPCORE_EVENT_CALIBRATION = DISPCORE_EVENT + 600;
        public static TEEvent CAL_DEFZPOS_UPDATE = new TEEvent(DISPCORE_EVENT_CALIBRATION + 0, "Calibrate Def Z Pos Update.");
        public static TEEvent CAL_DEFZPOS_CANCEL = new TEEvent(DISPCORE_EVENT_CALIBRATION + 1, "Calibrate Def Z Pos Cancel.");
        public static TEEvent CAL_LASER_CAL_VALUE_UPDATE = new TEEvent(DISPCORE_EVENT_CALIBRATION + 10, "Calibrate Laser Cal Value Update.");
        public static TEEvent CAL_LASER_CAL_VALUE_CANCEL = new TEEvent(DISPCORE_EVENT_CALIBRATION + 11, "Calibrate Laser Cal Value Cancel.");


        const int DISPCORE_EVENT_PUMP = DISPCORE_EVENT + 700;
        public static TEEvent PUMP1_DISP_VOL_UPDATE = new TEEvent(DISPCORE_EVENT_PUMP + 0, "Pump1 Disp Volume Update.");
        public static TEEvent PUMP2_DISP_VOL_UPDATE = new TEEvent(DISPCORE_EVENT_PUMP + 1, "Pump2 Disp Volume Update.");
        //public static TEEvent PUMP1_DISP_BASE_VOL_UPDATE = new TEEvent(DISPCORE_EVENT_PUMP + 0, "Pump1 Disp Base Volume Update");
        //public static TEEvent PUMP2_DISP_BASE_VOL_UPDATE = new TEEvent(DISPCORE_EVENT_PUMP + 1, "Pump2 Disp Base Volume Update");
        //public static TEEvent PUMP1_DISP_BASE_VOL_ADJ = new TEEvent(DISPCORE_EVENT_PUMP + 2, "Pump1 Disp Volume Adjust");
        //public static TEEvent PUMP2_DISP_BASE_VOL_ADJ = new TEEvent(DISPCORE_EVENT_PUMP + 3, "Pump2 Disp Volume Adjust");

        public static TEEvent PUMP1_BACKSUCK_VOL_UPDATE = new TEEvent(DISPCORE_EVENT_PUMP + 4, "Pump1 Backsuck Volume Update.");
        public static TEEvent PUMP2_BACKSUCK_VOL_UPDATE = new TEEvent(DISPCORE_EVENT_PUMP + 5, "Pump2 Backsuck Volume Update.");
        public static TEEvent PUMP1_DISP_SPEED_UPDATE = new TEEvent(DISPCORE_EVENT_PUMP + 6, "Pump1 Disp Speed Update.");
        public static TEEvent PUMP2_DISP_SPEED_UPDATE = new TEEvent(DISPCORE_EVENT_PUMP + 7, "Pump2 Disp Speed Update.");
        public static TEEvent PUMP1_BACKSUCK_SPEED_UPDATE = new TEEvent(DISPCORE_EVENT_PUMP + 8, "Pump1 Backsuck Speed Update.");
        public static TEEvent PUMP2_BACKSUCK_SPEED_UPDATE = new TEEvent(DISPCORE_EVENT_PUMP + 9, "Pump2 Backsuck Speed Update.");
        public static TEEvent PUMP1_DISP_TIME_UPDATE = new TEEvent(DISPCORE_EVENT_PUMP + 10, "Pump1 Disp Time Update.");
        public static TEEvent PUMP2_DISP_TIME_UPDATE = new TEEvent(DISPCORE_EVENT_PUMP + 11, "Pump2 Disp Time Update.");
        public static TEEvent PUMP1_BACKSUCK_TIME_UPDATE = new TEEvent(DISPCORE_EVENT_PUMP + 12, "Pump1 Backsuck Time Update.");
        public static TEEvent PUMP2_BACKSUCK_TIME_UPDATE = new TEEvent(DISPCORE_EVENT_PUMP + 13, "Pump2 Backsuck Time Update.");

        const int DISPCORE_EVENT_RUN = DISPCORE_EVENT + 800;
        public static TEEvent READ_ID = new TEEvent(DISPCORE_EVENT_RUN + 10, "Read ID.");
        public static TEEvent MANUAL_ID_ENTRY = new TEEvent(DISPCORE_EVENT_RUN + 11, "Manual ID Entry.");
        public static TEEvent INPUT_MAP = new TEEvent(DISPCORE_EVENT_RUN + 20, "Input Map.");
        public static TEEvent INPUT_MAP_QUERY = new TEEvent(DISPCORE_EVENT_RUN + 21, "Input Map Query.");
        public static TEEvent PPSELECT = new TEEvent(DISPCORE_EVENT_RUN + 30, "PPSelect.");
        public static TEEvent PPSEND_H2E = new TEEvent(DISPCORE_EVENT_RUN + 31, "PPSend H2E.");
        public static TEEvent PPSEND_E2H = new TEEvent(DISPCORE_EVENT_RUN + 32, "PPSend E2H.");
        public static TEEvent MAP_REQUEST = new TEEvent(DISPCORE_EVENT_RUN + 35, "Map Request.");
        public static TEEvent MAP_DOWNLOADED = new TEEvent(DISPCORE_EVENT_RUN + 36, "Map Download.");
        public static TEEvent MAP_UPLOADED = new TEEvent(DISPCORE_EVENT_RUN + 37, "Map Upload.");
        public static TEEvent MAP_RECOVER_PROMPT = new TEEvent(DISPCORE_EVENT_RUN + 40, "Map Recover Prompt.");
        public static TEEvent MAP_RECOVER_UPLOADED = new TEEvent(DISPCORE_EVENT_RUN + 41, "Map Recover Uploaded.");
        public static TEEvent MAP_RECOVER_UPLOAD_CANCEL = new TEEvent(DISPCORE_EVENT_RUN + 42, "Map Recover Cancelled.");
        public static TEEvent MAP_RECOVER_DELETED = new TEEvent(DISPCORE_EVENT_RUN + 43, "Map Recover Deleted.");
        public static TEEvent PARAMETER_CHANGED = new TEEvent(DISPCORE_EVENT_RUN + 45, "Parameter Changed.");

        const int DEVICE_EVENT = 1100;
        #region Click Event
        public static TEEvent CAMERA_INFO = new TEEvent(DEVICE_EVENT + 50, "Camera Info.");
        #endregion

        #region MHS_EVENT = 4000
        const int MHS_EVENT = 4000;
        public static TEEvent BOARD_ARRIVED_BUFFER1 = new TEEvent(MHS_EVENT + 100, "Board Arrived Buffer1.");
        public static TEEvent BOARD_ARRIVED_BUFFER2 = new TEEvent(MHS_EVENT + 102, "Board Arrived Buffer2.");
        public static TEEvent BOARD_ARRIVED_PRE_STATION = new TEEvent(MHS_EVENT + 104, "Board Arrived Pre Station.");
        public static TEEvent BOARD_ARRIVED_DISP_STATION = new TEEvent(MHS_EVENT + 106, "Board Arrived Disp Station.");
        public static TEEvent BOARD_ARRIVED_POST_STATION = new TEEvent(MHS_EVENT + 108, "Board Arrived Post Station.");
        public static TEEvent BOARD_ARRIVED_OUT_STATION = new TEEvent(MHS_EVENT + 110, "Board Arrived Out Station.");
        public static TEEvent BOARD_REVERSE_ARRIVED_IN_STATION = new TEEvent(MHS_EVENT + 112, "Board Reverse Arrived In Station.");
        public static TEEvent BOARD_PUSH_IN = new TEEvent(MHS_EVENT + 113, "Board Push In.");
        public static TEEvent BOARD_SEND_OUT = new TEEvent(MHS_EVENT + 114, "Board Send Out.");

        public static TEEvent BOARD_PUSH_ARRIVED_IN_STATION = new TEEvent(MHS_EVENT + 120, "Board Push Arrived In Station.");
        public static TEEvent BOARD_MANUAL_ARRIVED_IN_STATION = new TEEvent(MHS_EVENT + 121, "Board Manual Arrived In Station.");
        public static TEEvent BOARD_SMEMA_ARRIVED_IN_STATION = new TEEvent(MHS_EVENT + 122, "Board SMEMA Arrived In Station.");

        public static TEEvent BOARD_MANUAL_RETURN = new TEEvent(MHS_EVENT + 124, "Manual Return Board to In Station.");
        public static TEEvent BOARD_MANUAL_LOADPRE = new TEEvent(MHS_EVENT + 125, "Manual Load Board to Pre Station.");
        public static TEEvent BOARD_MANUAL_LOADPRO = new TEEvent(MHS_EVENT + 126, "Manual Load Board to Pro Station.");
        public static TEEvent BOARD_MANUAL_UNLOAD = new TEEvent(MHS_EVENT + 127, "Manual UnLoad Board.");

        public static TEEvent BOARD_SEND_OUT_CONV2 = new TEEvent(MHS_EVENT + 130, "Board Send Out Conv2.");
        public static TEEvent BOARD_SENT_OUT_TO_MAGAZINE = new TEEvent(MHS_EVENT + 131, "Board Send Out to Magazine.");
        public static TEEvent BOARD_SEND_OUT_SMEMA = new TEEvent(MHS_EVENT + 132, "Board Send Out SMEMA.");
        public static TEEvent BOARD_REVERSE = new TEEvent(MHS_EVENT + 133, "Board Reverse.");
        public static TEEvent BOARD_REVERSE_SEND_OUT_SMEMA = new TEEvent(MHS_EVENT + 134, "Board Reverse Send Out SMEMA.");

        public static TEEvent STOPPER_UP = new TEEvent(MHS_EVENT + 200, "Stopper Up.");
        public static TEEvent STOPPER_DN = new TEEvent(MHS_EVENT + 201, "Stopper Dn.");
        public static TEEvent SENSOR_DETECT = new TEEvent(MHS_EVENT + 202, "Sensor Detect.");

        public static TEEvent PREHEAT_START = new TEEvent(MHS_EVENT + 500, "Preheat Start.");
        public static TEEvent PREHEAT_END = new TEEvent(MHS_EVENT + 501, "Preheat End.");
        public static TEEvent DISPHEAT_START = new TEEvent(MHS_EVENT + 510, "Dispense Heat Start.");
        public static TEEvent DISPHEAT_END = new TEEvent(MHS_EVENT + 511, "Dispense Heat End.");

        public static TEEvent LEFT_ELEV_RESET = new TEEvent(MHS_EVENT + 550, "Left Elevator Reset.");
        public static TEEvent RIGHT_ELEV_RESET = new TEEvent(MHS_EVENT + 551, "Right Elevator Reset.");
        #endregion
    }

    class TEPara
    {
        public string Name = "";
        public string Value = "";
        public bool Report = false;

        public TEPara(string name, string value, bool report = true)
        {
            Name = name;
            Value = value;
            Report = report;
        }
        public TEPara(string name, double value, bool report = true)
        {
            Name = name;
            Value = $"{value:f3}";
            Report = report;
        }
        public void Set(string value)
        {
            if (!Report) return;
            this.Value = value;
            Event.PARAMETER_CHANGED.Set($"{this.Name}",$"{this.Value}");
        }
    }
    class Para
    {
        public static TEPara[] LineSpeed = Enumerable.Range(0, 16).Select(x => new TEPara($"LineSpeed{x}", 0, true)).ToArray();
        public static TEPara FPress0 = new TEPara("FPress0", 0, true);
        public static TEPara FPress1 = new TEPara("FPress1", 0, true);
        public static TEPara DotWeight = new TEPara("DotWeight", 0, true);
    }
}
