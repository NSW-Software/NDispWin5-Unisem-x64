using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System;

namespace NDispWin
{
    public enum EErrCode
    {
        //APP_ERR = 0000,

        //OP_ERR = 0100,
        //#region 
        //EXIT_SAVE_RECIPE = OP_ERR + 5,
        //LOAD_NEW_RECIPE = OP_ERR + 6,
        //EXIT_WHEN_LOT_ACTIVATED = OP_ERR + 7,

        //INIT_SYSTEM = OP_ERR + 50,
        //INIT_GANTRY = OP_ERR + 51,
        //INIT_GANTRY_FAIL = OP_ERR + 52,
        //INIT_CONVEYOR = OP_ERR + 55,
        //INIT_CONVEYOR_FAIL = OP_ERR + 56,
        //INIT_LR_LINE = OP_ERR + 60,
        //INIT_LR_LINE_FAIL = OP_ERR + 61,

        //LOW_AIR_PRESSURE = OP_ERR + 110,

        //FRONT_DOOR_OPEN = OP_ERR + 120,
        //LEFT_ELEV_DOOR_OPEN = OP_ERR + 125,
        //RIGHT_ELEV_DOOR_OPEN = OP_ERR + 126,

        //INPUT_IS_STOPPED = OP_ERR + 150,
        //DISP12MODE_WAIT_PRE_TIMEOUT = OP_ERR + 151,

        //RESET_PERF_INFO = OP_ERR + 200,

        //S320_LOAD_PRODUCT = OP_ERR + 300,
        //S320_UNLOAD_PRODUCT = OP_ERR + 301,
        //S320_NEW_DISPENSE = OP_ERR + 302,

        //LOTINFO_ISEMPTY = OP_ERR + 500,
        //LOT_NOT_ACTIVATED = OP_ERR + 501,
        //#endregion

        //CONFIG_ERROR = 2200,
        //#region
        //ZSENSOR_NOT_CONFIG = CONFIG_ERROR + 0,
        //#endregion

        //MOTOR_ERROR = 2350,
        //#region
        //INVALID_AXIS = MOTOR_ERROR + 0,
        //AXIS_ERR = MOTOR_ERROR + 5,
        //MOTOR_ALARM = MOTOR_ERROR + 6,
        //ABNORMAL_MOTOR_POSITION_ERROR = MOTOR_ERROR + 7,
        //#endregion

        //MOVE_PTP_ABS_ERR = 2400,
        //#region
        //GX_MOVE_PTP_ABS_ERR = MOVE_PTP_ABS_ERR + 0,
        //GY_MOVE_PTP_ABS_ERR = MOVE_PTP_ABS_ERR + 1,
        //GZ_MOVE_PTP_ABS_ERR = MOVE_PTP_ABS_ERR + 2,
        //GX2_MOVE_PTP_ABS_ERR = MOVE_PTP_ABS_ERR + 5,
        //GY2_MOVE_PTP_ABS_ERR = MOVE_PTP_ABS_ERR + 6,
        //GZ2_MOVE_PTP_ABS_ERR = MOVE_PTP_ABS_ERR + 7,
        //RX_MOVE_PTP_ABS_ERR = MOVE_PTP_ABS_ERR + 8,
        //RY_MOVE_PTP_ABS_ERR = MOVE_PTP_ABS_ERR + 9,
        //#endregion

        //MOVE_PTP_REL_ERR = 2420,
        //#region
        //GX_MOVE_PTP_REL_ERR = MOVE_PTP_REL_ERR + 0,
        //GY_MOVE_PTP_REL_ERR = MOVE_PTP_REL_ERR + 1,
        //GZ_MOVE_PTP_REL_ERR = MOVE_PTP_REL_ERR + 2,
        //GX2_MOVE_PTP_REL_ERR = MOVE_PTP_REL_ERR + 5,
        //GY2_MOVE_PTP_REL_ERR = MOVE_PTP_REL_ERR + 6,
        //GZ2_MOVE_PTP_REL_ERR = MOVE_PTP_REL_ERR + 7,
        //RX_MOVE_PTP_REL_ERR = MOVE_PTP_REL_ERR + 8,
        //RY_MOVE_PTP_REL_ERR = MOVE_PTP_REL_ERR + 9,
        //#endregion

        //MOVE_INTERPOLATION_ERR = 2450,
        //#region
        //GANTRY_MOVE_LINE_ABS2_ERR = MOVE_INTERPOLATION_ERR + 0,
        //GANTRY_MOVE_ARC_CENTER_END_ABS_ERR = MOVE_INTERPOLATION_ERR + 5,
        //#endregion

        //GANTRY_MISC_ERR = 2600,
        //#region
        //GANTRY_NOT_READY = GANTRY_MISC_ERR + 0,
        //GX_ALARM_CLEAR_TIMEOUT = GANTRY_MISC_ERR + 10,
        //GY_ALARM_CLEAR_TIMEOUT = GANTRY_MISC_ERR + 11,
        //GZ_ALARM_CLEAR_TIMEOUT = GANTRY_MISC_ERR + 12,
        //GX2_ALARM_CLEAR_TIMEOUT = GANTRY_MISC_ERR + 15,
        //GY2_ALARM_CLEAR_TIMEOUT = GANTRY_MISC_ERR + 16,
        //GZ2_ALARM_CLEAR_TIMEOUT = GANTRY_MISC_ERR + 17,
        //RX_ALARM_CLEAR_TIMEOUT = GANTRY_MISC_ERR + 18,
        //RY_ALARM_CLEAR_TIMEOUT = GANTRY_MISC_ERR + 19,

        //HOME_TIMEOUT = GANTRY_MISC_ERR + 20,
        //SOFTWARE_N_LIMIT = GANTRY_MISC_ERR + 50,


        //SOFTWARE_P_LIMIT = GANTRY_MISC_ERR + 60,

        //GZ_MOVE_TO_HOME_SENSOR_FAIL = GANTRY_MISC_ERR + 70,
        //GZ2_MOVE_TO_HOME_SENSOR_FAIL = GANTRY_MISC_ERR + 71,
        //GZ_FOCUS_POS_NOT_SAFE = GANTRY_MISC_ERR + 72,

        //GX_TARGET_MORE_THAN_STROKE = GANTRY_MISC_ERR + 90,
        //GY_TARGET_MORE_THAN_STROKE = GANTRY_MISC_ERR + 91,
        //GX2Y2_COLLISION_POSSIBLE = GANTRY_MISC_ERR + 92,

        //GXY_ENC_OFFSET = GANTRY_MISC_ERR + 93,
        //#endregion

        //OPERATION_ERR = 2800,
        //#region
        //NEEDLE_ZSENSOR_NOT_ON = OPERATION_ERR + 0,
        //SEARCH_NEEDLE_ZSENSOR_NOT_FOUND = OPERATION_ERR + 1,
        //NEEDLE_ZSENSOR_NOT_OFF = OPERATION_ERR + 2,
        //NEEDLE_ZSENSOR_ABNORMAL = OPERATION_ERR + 3,
        //DOOR_IS_OPEN = OPERATION_ERR + 5,

        //ZTOUCH_ECD_NOT_READY = OPERATION_ERR + 6,
        //ZTOUCH_ECD_DN_COUNT_FAIL = OPERATION_ERR + 7,
        //ZTOUCH_ECD_UP_COUNT_FAIL = OPERATION_ERR + 8,
        //ZTOUCH_ECD_ABNORMAL = OPERATION_ERR + 9,

        //MATERIAL_TIMER_EXPIRED = OPERATION_ERR + 10,
        //FRAME_COUNT_EXCEED_SETTING = OPERATION_ERR + 11,
        //UNIT_COUNT_EXCEED_SETTING = OPERATION_ERR + 12,
        //RUNTIME_EXCEED_SETTING = OPERATION_ERR + 13,
        //MATERIAL_EXPIRY_PREALERT = OPERATION_ERR + 14,
        //MOVE_ZAXIS_TO_POSITION = OPERATION_ERR + 15,

        //MATERIAL1_LEVEL_LOW = OPERATION_ERR + 16,
        //MATERIAL2_LEVEL_LOW = OPERATION_ERR + 17,
        //TEMPCTRL_OUT_OF_RANGE = OPERATION_ERR + 18,
        //TEMPCTRL_NOT_CONNECTED = OPERATION_ERR + 19,

        //SINGLE_HEAD_RUN_CHECK = OPERATION_ERR + 20,
        //TEACH_NEEDLE_REQUIRED = OPERATION_ERR + 21,
        //CHUCK_VAC_NOT_HIGH = OPERATION_ERR + 22,

        //FILL_COUNT_EXCEED_LIMIT = OPERATION_ERR + 30,
        //UNIT_COUNT_EXCEED_LIMIT = OPERATION_ERR + 31,

        //MATERIAL1_UNIT_RUN_EXCEEDED = OPERATION_ERR + 32,
        //MATERIAL2_UNIT_RUN_EXCEEDED = OPERATION_ERR + 33,

        //CALIBRATE_SPEED_TO_TIME_CANCELLED = OPERATION_ERR + 50,
        //CALIBRATE_SPEED_TO_TIME_ERR = OPERATION_ERR + 51,
        //CALIBRATE_SPEED_TO_TIME_INVALID_PARA = OPERATION_ERR + 52,

        //DO_REF_OFFSET_OOS = OPERATION_ERR + 60,
        //DO_REF_ANGLE_OOS = OPERATION_ERR + 61,
        //DO_REF_PT1_PT2_DIST_OOS = OPERATION_ERR + 62,

        //DO_HEIGHT_TOLERANCE_OOS = OPERATION_ERR + 65,

        //CREATE_MAP_OKYIELD_OOS = OPERATION_ERR + 70,

        //DO_VISION_FAIL = OPERATION_ERR + 80,

        //DISP_IS_BUSY = OPERATION_ERR + 90,
        //#endregion

        //PROGRAM_ERR = 2900,
        //#region
        //PROGRAM_SCRIPT_ERR = PROGRAM_ERR + 0,
        //PROGRAM_CANNOT_DELETE_ACTIVE = PROGRAM_ERR + 1,
        //PROGRAM_CONFIRM_DELETE = PROGRAM_ERR + 2,
        //PROGRAM_HEAD_ERROR = PROGRAM_ERR + 3,
        //PROGRAM_DRAW_OFFSET_UPDATE = PROGRAM_ERR + 10,
        //PROGRAM_ACTIVE_PROGRAM_COMMAND_MODIFICATION = PROGRAM_ERR + 11,

        //VOLUME_OFST_PATH_NOT_FOUND = PROGRAM_ERR + 50,
        //VOLUME_OFST_ERROR = PROGRAM_ERR + 51,
        //#endregion

        //    DISPCORE_ERROR = 3000,
        //    #region
        //    MOTION_COMMON_ERROR = DISPCORE_ERROR + 0,
        //    DISPCORE_NOT_INIT = DISPCORE_ERROR + 10,
        //    FRAME_COUNTER_FULL = DISPCORE_ERROR + 20,
        //    #endregion

        //    BOARD_ERROR = 3100,
        //    #region
        //    GANTRY_OPEN_BOARD1_FAIL = BOARD_ERROR + 0,
        //    GANTRY_OPEN_BOARD2_FAIL = BOARD_ERROR + 1,
        //    GANTRY_INIT_BOARD1_FAIL = BOARD_ERROR + 5,
        //    GANTRY_INIT_BOARD2_FAIL = BOARD_ERROR + 6,
        //    GANTRY_BOARD1_NOT_OPENED = BOARD_ERROR + 10,
        //    GANTRY_BOARD2_NOT_OPENED = BOARD_ERROR + 11,
        //    GANTRY_MOTION_EX_ERR = BOARD_ERROR + 50,
        //    GANTRY_IO_EX_ERR = BOARD_ERROR + 51,
        //    #endregion

        //    WEIGHT_ERR = 3300,
        //    #region
        //    WEIGHT_COMM_EX_ERR = WEIGHT_ERR + 0,
        //    WEIGHT_NO_HEAD_SELECTED = WEIGHT_ERR + 1,//not used since 1.0.46.2
        //    WEIGHT_OPEN_ERR = WEIGHT_ERR + 10,
        //    WEIGHT_NOT_READY = WEIGHT_ERR + 11,
        //    WEIGHT_GETVALUE_ERR = WEIGHT_ERR + 20,
        //    WEIGHT_INVALID_TARGET = WEIGHT_ERR + 30,
        //    WEIGHT_INVALID_TOLERANCE = WEIGHT_ERR + 31,
        //    WEIGHT_CAL_CANCELLED = WEIGHT_ERR + 33,
        //    WEIGHT_INVALID_SPEC = WEIGHT_ERR + 40,
        //    WEIGHT_INVALID_SPEC_LIMIT = WEIGHT_ERR + 41,
        //    WEIGHT_CAL_REQUIRED = WEIGHT_ERR + 50,
        //    WEIGHT_MEAS_REQUIRED = WEIGHT_ERR + 51,
        //    WEIGHT_PROG_HEAD_OP_SINGLE_SELECTED = WEIGHT_ERR + 60,
        //    #endregion

        //    LASER_ERR = 3400,
        //    #region
        //    LASER_COMM_EX_ERR = LASER_ERR + 0,
        //    LASER_OPEN_ERR = LASER_ERR + 10,
        //    LASER_NOT_CONFIG_ERR = LASER_ERR + 15,
        //    LASER_NOT_OPEN_ERR = LASER_ERR + 20,
        //    LASER_OUT_OF_RANGE_ERR = LASER_ERR + 25,
        //    LASER_SEARCH_ERR = LASER_ERR + 26,
        //    LASER_NOT_SUPPORTED = LASER_ERR + 30,
        //    LASER_OUT_OF_REF_HEIGHT_TOL = LASER_ERR + 50,

        //    TEMPSENSOR_OPEN_ERR = LASER_ERR + 60,
        //    TEMPSENSOR_NOT_CONFIG_ERR = LASER_ERR + 63,
        //    TEMPSENSOR_READ_FAIL = LASER_ERR + 64,
        //    TEMPSENSOR_SEARCH_FAIL = LASER_ERR + 65,
        //    #endregion

        DISPCTRL = 3500,
        //    #region
        //    DISPCTRL_COMM_EX_ERR = DISPCTRL + 0,
        //    DISPCTRL_INIT = DISPCTRL + 1,
        //    DISPCTRL_ERR = DISPCTRL + 5,
        //    DISPCTRL1_OPEN_ERR = DISPCTRL + 10,
        //    DISPCTRL2_OPEN_ERR = DISPCTRL + 11,
        //    DISPCTRL1_COMM_ERR = DISPCTRL + 20,
        //    DISPCTRL2_COMM_ERR = DISPCTRL + 21,
        //    DISPCTRL1_NOT_READY = DISPCTRL + 55,
        //    DISPCTRL2_NOT_READY = DISPCTRL + 56,
        //    DISPCTRL1_READY_TIMEOUT = DISPCTRL + 60,
        //    DISPCTRL2_READY_TIMEOUT = DISPCTRL + 61,
        //    DISPCTRL1_RESPONSE_TIMEOUT = DISPCTRL + 75,
        //    DISPCTRL2_RESPONSE_TIMEOUT = DISPCTRL + 76,
        //    DISPCTRL1_COMPLETE_TIMEOUT = DISPCTRL + 77,
        //    DISPCTRL2_COMPLETE_TIMEOUT = DISPCTRL + 78,
        //    DISPCTRL_ROTARY_TIMEOUT = DISPCTRL + 80,
        //    DISPCTRL_THREAD_BUSY = DISPCTRL + 90,
        //    DISPCTRL_THREAD_ERROR = DISPCTRL + 91,
        //    DISPCTRL_THREAD_TIMEOUT = DISPCTRL + 92,
        //    PRESSCTRL_THREAD_BUSY = DISPCTRL + 95,
        //    PRESSCTRL_THREAD_ERROR = DISPCTRL + 96,
        //    PRESSCTRL_THREAD_TIMEOUT = DISPCTRL + 97,
        //    #endregion
        DISPCTRL_TEMPERATURE_OUT_OF_TOLERANCE = DISPCTRL + 98,


    //    LEDCTRL_ERR = 3700,
    //    #region
    //    LEDCTRL_COMM_EX_ERR = LEDCTRL_ERR + 0,
    //    LEDCTRL_UNKNOWN_CTRL_ERR = LEDCTRL_ERR + 1,
    //    LEDCTRL_OPEN_ERR = LEDCTRL_ERR + 10,
    //    LEDCTRL_SETVALUE_ERR = LEDCTRL_ERR + 20,
    //    #endregion

    //    CAMERA_ERR = 3600,
    //    #region 
    //    CAMERA_COMM_EX_ERR = CAMERA_ERR + 0,
    //    CAMERA_INIT_ERR = CAMERA_ERR + 1,
    //    CAMERA1_OPEN_ERR = CAMERA_ERR + 10,
    //    CAMERA2_OPEN_ERR = CAMERA_ERR + 11,
    //    CAMERA3_OPEN_ERR = CAMERA_ERR + 12,
    //    CAMERA_NOT_CONFIG_ERR = CAMERA_ERR + 20,
    //    CAMERA_GRAB_TIMEOUT = CAMERA_ERR + 21,

    //    DISP_RECORDER_DISCONNECTED = CAMERA_ERR + 50,
    //    DISP_RECORDER_COMMAND_ERR = CAMERA_ERR + 51,
    //    DISP_RECORDER_NO_RESPONSE_ERR = CAMERA_ERR + 52,
    //    DISP_RECORDER_WAIT_TIMEOUT = CAMERA_ERR + 53,

    //    TEMPLOGGER_DISCONNECTED = CAMERA_ERR + 60,

    //    NEEDLE_INSP_NOT_IN_RUN_MODE = CAMERA_ERR + 70,
    //    NEEDLE_INSP_IS_BUSY = CAMERA_ERR + 71,
    //    NEEDLE_INSP_RESPONSE_TIMEOUT = CAMERA_ERR + 72,
    //    NEEDLE_INSP_BUSY_TIMEOUT = CAMERA_ERR + 73,
    //    NEEDLE_INSP_FAIL = CAMERA_ERR + 74,
    //    #endregion

    //    OTHER_ERR = 3800,
    //    #region 
    //    CLEAN_TAPE_CTRL_NOT_READY = OTHER_ERR + 10,
    //    CLEAN_TAPE_CTRL_READY_TIMEOUT = OTHER_ERR + 11,
    //    CLEAN_TAPE_CTRL_ALARM = OTHER_ERR + 15,
    //    #endregion

    //FUNC_NOT_SUPPORT = DISPCORE_ERROR + 3997,
    //DISPCORE_EX_ERR = DISPCORE_ERROR + 3998,
    //UNKNOWN_EX_ERR = DISPCORE_ERROR + 3999,

    OP_ERR = 0100,
        INIT_LEFT_ELEV = OP_ERR + 62,
        INIT_RIGHT_ELEV = OP_ERR + 63,
    }

    internal class ErrCode
    {
        public static int EMO_ACTIVATED = 101;
        public static int SYSTEM_NOT_READY = 102;

        const int OP_ERR = 0100;
        #region 
        public const int EXIT_SAVE_RECIPE = OP_ERR + 5;
        public const int LOAD_NEW_RECIPE = OP_ERR + 6;
        public const int EXIT_WHEN_LOT_ACTIVATED = OP_ERR + 7;

        public const int INIT_SYSTEM = OP_ERR + 50;
        public const int INIT_GANTRY = OP_ERR + 51;
        public const int INIT_GANTRY_FAIL = OP_ERR + 52;
        public const int INIT_CONVEYOR = OP_ERR + 55;
        public const int INIT_CONVEYOR_FAIL = OP_ERR + 56;
        public const int INIT_LR_LINE = OP_ERR + 60;
        public const int INIT_LR_LINE_FAIL = OP_ERR + 61;
        //public const int INIT_LEFT_ELEV = OP_ERR + 62;
        //public const int INIT_RIGHT_ELEV = OP_ERR + 63;

        public const int LOW_AIR_PRESSURE = OP_ERR + 110;

        public const int FRONT_DOOR_OPEN = OP_ERR + 120;
        public const int LEFT_ELEV_DOOR_OPEN = OP_ERR + 125;
        public const int RIGHT_ELEV_DOOR_OPEN = OP_ERR + 126;

        public const int INPUT_IS_STOPPED = OP_ERR + 150;
        public const int DISP12MODE_WAIT_PRE_TIMEOUT = OP_ERR + 151;
        public const int IN_MAGAZINE_EMPTY_WORK_COMPLETE = OP_ERR + 155;

        public const int RESET_PERF_INFO = OP_ERR + 200;

        public const int S320_LOAD_PRODUCT = OP_ERR + 300;
        public const int S320_UNLOAD_PRODUCT = OP_ERR + 301;
        public const int S320_NEW_DISPENSE = OP_ERR + 302;

        public const int LOTINFO_ISEMPTY = OP_ERR + 500;
        public const int LOT_NOT_ACTIVATED = OP_ERR + 501;
        #endregion

        const int CONFIG_ERROR = 2200;
        #region
        public const int ZSENSOR_NOT_CONFIG = CONFIG_ERROR + 0;
        #endregion

        const int MOTOR_ERROR = 2350;
        #region
        public const int INVALID_AXIS = MOTOR_ERROR + 0;
        public const int AXIS_ERR = MOTOR_ERROR + 5;
        public const int MOTOR_ALARM = MOTOR_ERROR + 6;
        public const int ABNORMAL_MOTOR_POSITION_ERROR = MOTOR_ERROR + 7;
        #endregion

        public const int MOVE_PTP_ABS_ERR = 2400;
        public const int MOVE_PTP_REL_ERR = 2420;

        const int MOVE_INTERPOLATION_ERR = 2450;
        #region
        public const int GANTRY_MOVE_LINE_ABS2_ERR = MOVE_INTERPOLATION_ERR + 0;
        public const int GANTRY_MOVE_LINE_REL2_ERR = MOVE_INTERPOLATION_ERR + 1;
        public const int GANTRY_MOVE_ARC_CENTER_END_ABS_ERR = MOVE_INTERPOLATION_ERR + 5;
        #endregion

        const int GANTRY_MISC_ERR = 2600;
        #region
        public const int GANTRY_NOT_READY = GANTRY_MISC_ERR + 0;
        public const int HOME_TIMEOUT = GANTRY_MISC_ERR + 20;
        public const int SOFTWARE_N_LIMIT = GANTRY_MISC_ERR + 50;
        public const int SOFTWARE_P_LIMIT = GANTRY_MISC_ERR + 60;
        public const int GZ_MOVE_TO_HOME_SENSOR_FAIL = GANTRY_MISC_ERR + 70;
        public const int GZ2_MOVE_TO_HOME_SENSOR_FAIL = GANTRY_MISC_ERR + 71;
        public const int GZ_FOCUS_POS_NOT_SAFE = GANTRY_MISC_ERR + 72;
        public const int GX_TARGET_MORE_THAN_STROKE = GANTRY_MISC_ERR + 90;
        public const int GY_TARGET_MORE_THAN_STROKE = GANTRY_MISC_ERR + 91;
        public const int GX2Y2_COLLISION_POSSIBLE = GANTRY_MISC_ERR + 92;
        public const int GXY_ENC_OFFSET = GANTRY_MISC_ERR + 93;
        #endregion

        const int OPERATION_ERR = 2800;
        #region
        public const int NEEDLE_ZSENSOR_NOT_ON = OPERATION_ERR + 0;
        public const int SEARCH_NEEDLE_ZSENSOR_NOT_FOUND = OPERATION_ERR + 1;
        public const int NEEDLE_ZSENSOR_NOT_OFF = OPERATION_ERR + 2;
        public const int NEEDLE_ZSENSOR_ABNORMAL = OPERATION_ERR + 3;
        public const int DOOR_IS_OPEN = OPERATION_ERR + 5;

        public const int ZTOUCH_ECD_NOT_READY = OPERATION_ERR + 6;
        public const int ZTOUCH_ECD_DN_COUNT_FAIL = OPERATION_ERR + 7;
        public const int ZTOUCH_ECD_UP_COUNT_FAIL = OPERATION_ERR + 8;
        public const int ZTOUCH_ECD_ABNORMAL = OPERATION_ERR + 9;

        public const int MATERIAL_TIMER_EXPIRED = OPERATION_ERR + 10;
        public const int FRAME_COUNT_EXCEED_SETTING = OPERATION_ERR + 11;
        public const int UNIT_COUNT_EXCEED_SETTING = OPERATION_ERR + 12;
        public const int RUNTIME_EXCEED_SETTING = OPERATION_ERR + 13;
        public const int MATERIAL_EXPIRY_PREALERT = OPERATION_ERR + 14;
        public const int MOVE_ZAXIS_TO_POSITION = OPERATION_ERR + 15;

        public const int MATERIAL1_LEVEL_LOW = OPERATION_ERR + 16;
        public const int MATERIAL2_LEVEL_LOW = OPERATION_ERR + 17;
        public const int TEMPCTRL_OUT_OF_RANGE = OPERATION_ERR + 18;
        public const int TEMPCTRL_NOT_CONNECTED = OPERATION_ERR + 19;

        public const int SINGLE_HEAD_RUN_CHECK = OPERATION_ERR + 20;
        public const int TEACH_NEEDLE_REQUIRED = OPERATION_ERR + 21;
        public const int CHUCK_VAC_NOT_HIGH = OPERATION_ERR + 22;

        public const int FILL_COUNT_EXCEED_LIMIT = OPERATION_ERR + 30;
        public const int UNIT_COUNT_EXCEED_LIMIT = OPERATION_ERR + 31;

        public const int MATERIAL1_UNIT_RUN_EXCEEDED = OPERATION_ERR + 32;
        public const int MATERIAL2_UNIT_RUN_EXCEEDED = OPERATION_ERR + 33;

        public const int CALIBRATE_SPEED_TO_TIME_CANCELLED = OPERATION_ERR + 50;
        public const int CALIBRATE_SPEED_TO_TIME_ERR = OPERATION_ERR + 51;
        public const int CALIBRATE_SPEED_TO_TIME_INVALID_PARA = OPERATION_ERR + 52;

        public const int DO_REF_OFFSET_OOS = OPERATION_ERR + 60;
        public const int DO_REF_ANGLE_OOS = OPERATION_ERR + 61;
        public const int DO_REF_PT1_PT2_DIST_OOS = OPERATION_ERR + 62;

        public const int DO_HEIGHT_TOLERANCE_OOS = OPERATION_ERR + 65;

        public const int CREATE_MAP_OKYIELD_OOS = OPERATION_ERR + 70;
        public const int CHECK_BOARD_YIELD = OPERATION_ERR + 71;

        public const int DO_VISION_FAIL = OPERATION_ERR + 80;

        public const int DISP_IS_BUSY = OPERATION_ERR + 90;
        #endregion

        const int PROGRAM_ERR = 2900;
        #region
        public const int PROGRAM_SCRIPT_ERR = PROGRAM_ERR + 0;
        public const int PROGRAM_CANNOT_DELETE_ACTIVE = PROGRAM_ERR + 1;
        public const int PROGRAM_CONFIRM_DELETE = PROGRAM_ERR + 2;
        public const int PROGRAM_HEAD_ERROR = PROGRAM_ERR + 3;
        public const int PROGRAM_DRAW_OFFSET_UPDATE = PROGRAM_ERR + 10;
        public const int PROGRAM_ACTIVE_PROGRAM_COMMAND_MODIFICATION = PROGRAM_ERR + 11;
        public const int PROGRAM_VISION_DATA_NOT_READY = PROGRAM_ERR + 12;

        public const int VOLUME_OFST_PATH_NOT_FOUND = PROGRAM_ERR + 50;
        public const int VOLUME_OFST_ERROR = PROGRAM_ERR + 51;
        #endregion

        const int DISPCORE_ERROR = 3000;
        #region
        public const int MOTION_COMMON_ERROR = DISPCORE_ERROR + 0;
        public const int DISPCORE_NOT_INIT = DISPCORE_ERROR + 10;
        public const int FRAME_COUNTER_FULL = DISPCORE_ERROR + 20;
        #endregion

        const int BOARD_ERROR = 3100;
        #region
        public const int GANTRY_OPEN_BOARD1_FAIL = BOARD_ERROR + 0;
        public const int GANTRY_OPEN_BOARD2_FAIL = BOARD_ERROR + 1;
        public const int GANTRY_INIT_BOARD1_FAIL = BOARD_ERROR + 5;
        public const int GANTRY_INIT_BOARD2_FAIL = BOARD_ERROR + 6;
        public const int GANTRY_BOARD1_NOT_OPENED = BOARD_ERROR + 10;
        public const int GANTRY_BOARD2_NOT_OPENED = BOARD_ERROR + 11;
        public const int GANTRY_MOTION_EX_ERR = BOARD_ERROR + 50;
        public const int GANTRY_IO_EX_ERR = BOARD_ERROR + 51;
        #endregion

        const int WEIGHT_ERR = 3300;
        #region
        public const int WEIGHT_COMM_EX_ERR = WEIGHT_ERR + 0;
        public const int WEIGHT_NO_HEAD_SELECTED = WEIGHT_ERR + 1;//not used since 1.0.46.2
        public const int WEIGHT_OPEN_ERR = WEIGHT_ERR + 10;
        public const int WEIGHT_NOT_READY = WEIGHT_ERR + 11;
        public const int WEIGHT_GETVALUE_ERR = WEIGHT_ERR + 20;
        public const int WEIGHT_INVALID_TARGET = WEIGHT_ERR + 30;
        public const int WEIGHT_INVALID_TOLERANCE = WEIGHT_ERR + 31;
        public const int WEIGHT_CAL_CANCELLED = WEIGHT_ERR + 33;
        public const int WEIGHT_INVALID_SPEC = WEIGHT_ERR + 40;
        public const int WEIGHT_INVALID_SPEC_LIMIT = WEIGHT_ERR + 41;
        public const int WEIGHT_CAL_REQUIRED = WEIGHT_ERR + 50;
        public const int WEIGHT_MEAS_REQUIRED = WEIGHT_ERR + 51;
        public const int WEIGHT_PROG_HEAD_OP_SINGLE_SELECTED = WEIGHT_ERR + 60;
        #endregion

        const int LASER_ERR = 3400;
        #region
        public const int LASER_COMM_EX_ERR = LASER_ERR + 0;
        public const int LASER_OPEN_ERR = LASER_ERR + 10;
        public const int LASER_NOT_CONFIG_ERR = LASER_ERR + 15;
        public const int LASER_NOT_OPEN_ERR = LASER_ERR + 20;
        public const int LASER_OUT_OF_RANGE_ERR = LASER_ERR + 25;
        public const int LASER_SEARCH_ERR = LASER_ERR + 26;
        public const int LASER_NOT_SUPPORTED = LASER_ERR + 30;
        public const int LASER_OUT_OF_REF_HEIGHT_TOL = LASER_ERR + 50;
        public const int TEMPSENSOR_OPEN_ERR = LASER_ERR + 60;
        public const int TEMPSENSOR_NOT_CONFIG_ERR = LASER_ERR + 63;
        public const int TEMPSENSOR_READ_FAIL = LASER_ERR + 64;
        public const int TEMPSENSOR_SEARCH_FAIL = LASER_ERR + 65;
        #endregion

        const int DISPCTRL = 3500;
        #region
        public const int DISPCTRL_COMM_EX_ERR = DISPCTRL + 0;
        public const int DISPCTRL_INIT = DISPCTRL + 1;
        public const int DISPCTRL_ERR = DISPCTRL + 5;
        public const int DISPCTRL1_OPEN_ERR = DISPCTRL + 10;
        public const int DISPCTRL2_OPEN_ERR = DISPCTRL + 11;
        public const int DISPCTRL1_COMM_ERR = DISPCTRL + 20;
        public const int DISPCTRL2_COMM_ERR = DISPCTRL + 21;
        public const int DISPCTRL1_NOT_READY = DISPCTRL + 55;
        public const int DISPCTRL2_NOT_READY = DISPCTRL + 56;
        public const int DISPCTRL1_READY_TIMEOUT = DISPCTRL + 60;
        public const int DISPCTRL2_READY_TIMEOUT = DISPCTRL + 61;
        public const int DISPCTRL1_RESPONSE_TIMEOUT = DISPCTRL + 75;
        public const int DISPCTRL2_RESPONSE_TIMEOUT = DISPCTRL + 76;
        public const int DISPCTRL1_COMPLETE_TIMEOUT = DISPCTRL + 77;
        public const int DISPCTRL2_COMPLETE_TIMEOUT = DISPCTRL + 78;
        public const int DISPCTRL_ROTARY_TIMEOUT = DISPCTRL + 80;
        public const int DISPCTRL_THREAD_BUSY = DISPCTRL + 90;
        public const int DISPCTRL_THREAD_ERROR = DISPCTRL + 91;
        public const int DISPCTRL_THREAD_TIMEOUT = DISPCTRL + 92;
        public const int PRESSCTRL_THREAD_BUSY = DISPCTRL + 95;
        public const int PRESSCTRL_THREAD_ERROR = DISPCTRL + 96;
        public const int PRESSCTRL_THREAD_TIMEOUT = DISPCTRL + 97;
        //public const int DISPCTRL_TEMPERATURE_OUT_OF_TOLERANCE = DISPCTRL + 98;
        public const int PRESSCTRL_ERROR = DISPCTRL + 99;
        #endregion


        const int LEDCTRL_ERR = 3700;
        #region
        public const int LEDCTRL_COMM_EX_ERR = LEDCTRL_ERR + 0;
        public const int LEDCTRL_UNKNOWN_CTRL_ERR = LEDCTRL_ERR + 1;
        public const int LEDCTRL_OPEN_ERR = LEDCTRL_ERR + 10;
        public const int LEDCTRL_SETVALUE_ERR = LEDCTRL_ERR + 20;
        #endregion

        const int CAMERA_ERR = 3600;
        #region 
        public const int CAMERA_COMM_EX_ERR = CAMERA_ERR + 0;
        public const int CAMERA_INIT_ERR = CAMERA_ERR + 1;
        public const int CAMERA_DRIVER_NOT_SUPPORT = CAMERA_ERR + 2;
        public const int CAMERA1_OPEN_ERR = CAMERA_ERR + 10;
        public const int CAMERA2_OPEN_ERR = CAMERA_ERR + 11;
        public const int CAMERA3_OPEN_ERR = CAMERA_ERR + 12;
        public const int CAMERA_NOT_CONFIG_ERR = CAMERA_ERR + 20;
        public const int CAMERA_GRAB_TIMEOUT = CAMERA_ERR + 21;
        public const int DISP_RECORDER_DISCONNECTED = CAMERA_ERR + 50;
        public const int DISP_RECORDER_COMMAND_ERR = CAMERA_ERR + 51;
        public const int DISP_RECORDER_NO_RESPONSE_ERR = CAMERA_ERR + 52;
        public const int DISP_RECORDER_WAIT_TIMEOUT = CAMERA_ERR + 53;
        public const int TEMPLOGGER_DISCONNECTED = CAMERA_ERR + 60;
        public const int NEEDLE_INSP_NOT_IN_RUN_MODE = CAMERA_ERR + 70;
        public const int NEEDLE_INSP_IS_BUSY = CAMERA_ERR + 71;
        public const int NEEDLE_INSP_RESPONSE_TIMEOUT = CAMERA_ERR + 72;
        public const int NEEDLE_INSP_BUSY_TIMEOUT = CAMERA_ERR + 73;
        public const int NEEDLE_INSP_FAIL = CAMERA_ERR + 74;
        #endregion

        const int OTHER_ERR = 3800;
        #region 
        public const int CLEAN_TAPE_CTRL_NOT_READY = OTHER_ERR + 10;
        public const int CLEAN_TAPE_CTRL_READY_TIMEOUT = OTHER_ERR + 11;
        public const int CLEAN_TAPE_CTRL_ALARM = OTHER_ERR + 15;
        #endregion

        public const int FUNC_NOT_SUPPORT = 3997;
        public const int DISPCORE_EX_ERR = 3998;
        public const int UNKNOWN_EX_ERR = 3999;

        #region Conveyor
        const int CONV_COMMON_ACCESS = 4000;
        #region 4000
        public const int CONV_INIT_ACCESS = CONV_COMMON_ACCESS + 0;
        public const int CONV_DRY_RUN_ACCESS = CONV_COMMON_ACCESS + 5;
        public const int ALL_INIT_ACCESS = CONV_COMMON_ACCESS + 6;
        #endregion

        const int CONV_CONTROL_ERROR = 4100;
        #region 4100
        public const int CONV_OPEN_BOARD_FAIL = CONV_CONTROL_ERROR + 0;
        public const int CONV_VALUE_OUT_OF_RANGE = CONV_CONTROL_ERROR + 1;
        //public const int CONV_PRO_NOT_READY = CONV_CONTROL_ERROR + 2;
        public const int CONV_NOT_READY = CONV_CONTROL_ERROR + 3;
        public const int CONV_BELT_RUN_ERROR = CONV_CONTROL_ERROR + 10;
        //public const int CONV_BELT_RToL_RUN_ERROR = CONV_CONTROL_ERROR + 11;
        //public const int CONV_PRE_STOPPER_UP_TIMEOUT = CONV_CONTROL_ERROR + 12;
        //public const int CONV_PRE_STOPPER_DN_TIMEOUT = CONV_CONTROL_ERROR + 13;
        //public const int CONV_PRO_STOPPER_UP_TIMEOUT = CONV_CONTROL_ERROR + 14;
        //public const int CONV_PRO_STOPPER_DN_TIMEOUT = CONV_CONTROL_ERROR + 15;
        //public const int CONV_PRO_LIFTER_UP_TIMEOUT = CONV_CONTROL_ERROR + 16;
        //public const int CONV_PRO_LIFTER_DN_TIMEOUT = CONV_CONTROL_ERROR + 17;
        //public const int CONV_PRO_PRECISOR_EXT_TIMEOUT = CONV_CONTROL_ERROR + 18;
        //public const int CONV_PRO_PRECISOR_RET_TIMEOUT = CONV_CONTROL_ERROR + 19;
        //public const int CONV_POS_KICKER_EXT_TIMEOUT = CONV_CONTROL_ERROR + 20;
        //public const int CONV_POS_KICKER_RET_TIMEOUT = CONV_CONTROL_ERROR + 21;
        //public const int CONV_PRO_VACUUM1_ON_TIMEOUT = CONV_CONTROL_ERROR + 22;
        //public const int CONV_PRO_VACUUM1_OFF_TIMEOUT = CONV_CONTROL_ERROR + 23;
        //public const int CONV_PRE_LIFTER_UP_TIMEOUT = CONV_CONTROL_ERROR + 24;
        //public const int CONV_PRE_LIFTER_DN_TIMEOUT = CONV_CONTROL_ERROR + 25;
        //public const int CONV_POS_STOPPER_UP_TIMEOUT = CONV_CONTROL_ERROR + 26;
        //public const int CONV_POS_STOPPER_DN_TIMEOUT = CONV_CONTROL_ERROR + 27;
        //public const int CONV_POS_LIFTER_UP_TIMEOUT = CONV_CONTROL_ERROR + 28;
        //public const int CONV_POS_LIFTER_DN_TIMEOUT = CONV_CONTROL_ERROR + 29;
        //public const int CONV_PRO_VACUUM2_ON_TIMEOUT = CONV_CONTROL_ERROR + 30;
        //public const int CONV_PRO_VACUUM2_OFF_TIMEOUT = CONV_CONTROL_ERROR + 31;
        //public const int CONV_PRE_PRECISOR_EXT_TIMEOUT = CONV_CONTROL_ERROR + 32;
        //public const int CONV_PRE_PRECISOR_RET_TIMEOUT = CONV_CONTROL_ERROR + 33;
        //public const int CONV_PRE_VACUUM_ON_TIMEOUT = CONV_CONTROL_ERROR + 33;
        //public const int CONV_PRE_VACUUM_OFF_TIMEOUT = CONV_CONTROL_ERROR + 34;
        //public const int CONV_PREPRO_STOPPER_UP_TIMEOUT = CONV_CONTROL_ERROR + 35;
        //public const int CONV_PREPRO_STOPPER_DN_TIMEOUT = CONV_CONTROL_ERROR + 36;
        //public const int CONV_PREPRO_PRECISOR_EXT_TIMEOUT = CONV_CONTROL_ERROR + 37;
        //public const int CONV_PREPRO_PRECISOR_RET_TIMEOUT = CONV_CONTROL_ERROR c;
        //public const int CONV_PREPRO_LIFTER_UP_TIMEOUT = CONV_CONTROL_ERROR + 41;
        //public const int CONV_PREPRO_LIFTER_DOWN_TIMEOUT = CONV_CONTROL_ERROR + 42;
        public const int CONV_STOPPER_UP_TIMEOUT = CONV_CONTROL_ERROR + 50;
        public const int CONV_STOPPER_DN_TIMEOUT = CONV_CONTROL_ERROR + 51;
        public const int CONV_LIFTER_UP_TIMEOUT = CONV_CONTROL_ERROR + 52;
        public const int CONV_LIFTER_DN_TIMEOUT = CONV_CONTROL_ERROR + 53;
        public const int CONV_PRECISOR_EXT_TIMEOUT = CONV_CONTROL_ERROR + 54;
        public const int CONV_PRECISOR_RET_TIMEOUT = CONV_CONTROL_ERROR + 55;
        public const int CONV_KICKER_EXT_TIMEOUT = CONV_CONTROL_ERROR + 56;
        public const int CONV_KICKER_RET_TIMEOUT = CONV_CONTROL_ERROR + 57;
        public const int CONV_VACUUM_ON_TIMEOUT = CONV_CONTROL_ERROR + 58;
        public const int CONV_VACUUM_OFF_TIMEOUT = CONV_CONTROL_ERROR + 59;
        public const int CONV_VACUUM2_ON_TIMEOUT = CONV_CONTROL_ERROR + 60;
        public const int CONV_VACUUM2_OFF_TIMEOUT = CONV_CONTROL_ERROR + 61;
        public const int CONV_VACUUM_LOW = CONV_CONTROL_ERROR + 62;
        #endregion

        const int CONV_PROCESS_ERROR = 4200;
        #region
        public const int CONV_IN_SENSOR_PSNT = CONV_PROCESS_ERROR + 0;
        public const int CONV_IN_CLEAR_SENSOR_PSNT = CONV_PROCESS_ERROR + 1;
        //public const int CONV_PRE_IN_SENSOR_UNPRESENT = CONV_PROCESS_ERROR + 1;
        //public const int CONV_PRE_SENSOR_PRESENT = CONV_PROCESS_ERROR + 2;
        //public const int CONV_PRE_SENSOR_UNPRESENT = CONV_PROCESS_ERROR + 3;
        //public const int CONV_PRO_SENSOR_PRESENT = CONV_PROCESS_ERROR + 4;
        //public const int CONV_PRO_SENSOR_UNPRESENT = CONV_PROCESS_ERROR + 5;
        //public const int CONV_POS_SENSOR_PRESENT = CONV_PROCESS_ERROR + 6;
        //public const int CONV_POS_SENSOR_UNPRESENT = CONV_PROCESS_ERROR + 7;
        public const int CONV_OUT_SENSOR_PSNT = CONV_PROCESS_ERROR + 8;
        public const int CONV_OUT_CLEAR_SENSOR_PSNT = CONV_PROCESS_ERROR + 9;
        //public const int CONV_POS_IN_SENSOR_UNPRESENT = CONV_PROCESS_ERROR + 9;
        //public const int CONV_SETUP_UNLOAD_ERR = CONV_PROCESS_ERROR + 10;
        //public const int CONV_REJECTED_PRODUCT = CONV_PROCESS_ERROR + 11;
        public const int CONV_MANUAL_UNLOAD = CONV_PROCESS_ERROR + 12;
        //public const int CONV_PRO1_SENSOR_PRESENT = CONV_PROCESS_ERROR + 13;
        //public const int CONV_PRO1_SENSOR_UNPRESENT = CONV_PROCESS_ERROR + 14;
        public const int CONV_SENSOR_PART_PSNT = CONV_PROCESS_ERROR + 15;
        public const int CONV_SENSOR_PART_MISSING = CONV_PROCESS_ERROR + 16;
        //public const int CONV_LOAD_TIMEOUT = CONV_PROCESS_ERROR + 30;
        //public const int CONV_PRE_LOAD_TIMEOUT = CONV_PROCESS_ERROR + 30;
        //public const int CONV_PRO_LOAD_TIMEOUT = CONV_PROCESS_ERROR + 31;
        //public const int CONV_PRO_UNLOAD_TIMEOUT = CONV_PROCESS_ERROR + 32;
        //public const int CONV_POS_UNLOAD_TIMEOUT = CONV_PROCESS_ERROR + 33;
        //public const int CONV_RETURN_MODE_TIMEOUT = CONV_PROCESS_ERROR + 34;
        //public const int CONV_POS_SEND_OUT_TIMEOUT = CONV_PROCESS_ERROR + 35;
        public const int CONV_UNLOAD_TIMEOUT = CONV_PROCESS_ERROR + 35;
        public const int CONV_MOVE_TIMEOUT = CONV_PROCESS_ERROR + 36;
        public const int CONV_REVERSE_UNLOAD_TIMEOUT = CONV_PROCESS_ERROR + 37;
        //public const int CONV_PARALLEL_LOAD_TO_PRO_TIMEOUT = CONV_PROCESS_ERROR + 40;
        //public const int CONV_PARALLEL_LOAD_TO_POS_TIMEOUT = CONV_PROCESS_ERROR + 41;
        //public const int CONV_PARALLEL_LOAD_ABNORMAL_OP = CONV_PROCESS_ERROR + 42;
        public const int CONV_HEATER_OUT_OF_RANGE = CONV_PROCESS_ERROR + 50;
        public const int CONV_REMOVE_PART_FROM_CONVEYOR = CONV_PROCESS_ERROR + 51;
        public const int CONV_OUT_MAG_LEVEL_MISMATCH = CONV_PROCESS_ERROR + 52;
        public const int CONV_UNLOAD_TO_MISMATCH_LEVEL = CONV_PROCESS_ERROR + 53;
        #endregion

        //const int CONV_HEATER_ERROR = 4300;
        //public const int CONV_HEATER_PRO_NO_IN_RANGE = CONV_HEATER_ERROR + 0;
        //public const int CONV_HEATER_PRE_NO_IN_RANGE = CONV_HEATER_ERROR + 1;
        //public const int CONV_HEATER_POS_NO_IN_RANGE = CONV_HEATER_ERROR + 1;
        //public const int CONV_HEATER_PREPRO_NO_IN_RANGE = CONV_HEATER_ERROR + 3;

        const int CONV_PROCESS_NOTIFICATION = 4400;
        //public const int CONV_REMOVE_PRE_REJECT = CONV_PROCESS_NOTIFICATION + 0;
        //public const int CONV_REMOVE_POS_REJECT = CONV_PROCESS_NOTIFICATION + 1;

        const int CONV_SMEMA_ERROR = 4500;
        public const int CONV_SMEMA_LEFT_BOARD_IN_TIMEOUT = CONV_SMEMA_ERROR + 0;
        public const int CONV_SMEMA_RIGHT_IN_TIMEOUT = CONV_SMEMA_ERROR + 1;
        public const int CONV_SMEMA_RIGHT_REVERSE_WAIT_BOARD_TIMEOUT = CONV_SMEMA_ERROR + 2;

        public const int CONV_SMEMA_LEFT_BOARD_OUT_TIMEOUT = CONV_SMEMA_ERROR + 10;


        public const int CONV_EX_ERR = 4998;
        //public const int CONV_UNKNOWN_EX_ERR = 4999;
        #endregion

        const int ELEV_COMMON_ACCESS = 5000;
        #region Elevator
        public const int ELEV_ALL_INIT_ACCESS = ELEV_COMMON_ACCESS + 0;
        public const int ELEV_LEFT_INIT_ACCESS = ELEV_COMMON_ACCESS + 1;
        public const int ELEV_RIGHT_INIT_ACCESS = ELEV_COMMON_ACCESS + 2;
        public const int ELEV_DRY_RUN_ACCESS = ELEV_COMMON_ACCESS + 3;
        //public const int ELEV_NON_CONFIG_ACCESS = ELEV_COMMON_ACCESS + 4;
        public const int ELEV_LEFT_PUSHER_INIT_ACCESS = ELEV_COMMON_ACCESS + 5;

        const int ELEV_CONTROL_ERROR = 5100;
        #region
        public const int ELEV_OPEN_BOARD_FAIL = ELEV_CONTROL_ERROR + 0;
        //public const int ELEV_VALUE_OUT_OF_RANGE = ELEV_CONTROL_ERROR + 1;
        //public const int ELEV_LEFT_CONT_SEND_FAIL = ELEV_CONTROL_ERROR + 2;
        public const int ELEV_PUSHER_CONT_SEND_FAIL = ELEV_CONTROL_ERROR + 5;
        //public const int ELEV_LEFT_PUSHER_EXT_TIME_OUT = ELEV_CONTROL_ERROR + 10;
        //public const int ELEV_LEFT_PUSHER_RET_TIME_OUT = ELEV_CONTROL_ERROR + 11;
        //public const int ELEV_RIGHT_PUSHER_EXT_TIME_OUT = ELEV_CONTROL_ERROR + 12;
        //public const int ELEV_RIGHT_PUSHER_RET_TIME_OUT = ELEV_CONTROL_ERROR + 13;
        //public const int ELEV_LEFT_PUSHER_SENS_HOME_ERROR = ELEV_CONTROL_ERROR + 20;
        //public const int ELEV_LEFT_PUSHER_SENS_LIMIT_ERROR = ELEV_CONTROL_ERROR + 22;
        public const int ELEV_PUSHER_EXT_TIME_OUT = ELEV_CONTROL_ERROR + 30;
        public const int ELEV_PUSHER_RET_TIME_OUT = ELEV_CONTROL_ERROR + 31;
        public const int ELEV_PUSHER_SENS_HOME_ERROR = ELEV_CONTROL_ERROR + 32;
        public const int ELEV_PUSHER_SENS_LIMIT_ERROR = ELEV_CONTROL_ERROR + 33;
        public const int ELEV_PUSHER_NOT_HOME_ERROR = ELEV_CONTROL_ERROR + 34;
        public const int ELEV_PUSHER_JAM = ELEV_CONTROL_ERROR + 35;
        public const int ELEV_PUSHER_HOME_FUNCTIONAL_ERROR = ELEV_CONTROL_ERROR + 36;
        public const int ELEV_PUSHER_ABNORMAL_STATE = ELEV_CONTROL_ERROR + 37;
        #endregion

        const int ELEV_MOTION_ERROR = 5200;
        #region
        public const int ELEV_MOVE_RELATIVE_ERR = ELEV_MOTION_ERROR + 0;
        public const int ELEV_SET_MOTION_PARAM_ERR = ELEV_MOTION_ERROR + 1;
        public const int ELEV_AXIS_WAIT_ERR = ELEV_MOTION_ERROR + 2;
        public const int ELEV_AXIS_JOG_FAIL = ELEV_MOTION_ERROR + 3;
        public const int ELEV_FORCE_STOP_FAIL = ELEV_MOTION_ERROR + 4;
        public const int ELEV_MOVE_CONST_ERR = ELEV_MOTION_ERROR + 5;

        //public const int ELEV_LZ_MOTOR_ALARM = ELEV_MOTION_ERROR + 10;
        //public const int ELEV_LZ_SEARCH_HOME_TIME_OUT = ELEV_MOTION_ERROR + 11;
        //public const int ELEV_LZ_CLEAR_HOME_TIME_OUT = ELEV_MOTION_ERROR + 12;
        //public const int ELEV_LZ_MOVE_POS_ERROR = ELEV_MOTION_ERROR + 13;

        //public const int ELEV_LY_MOTOR_ALARM = ELEV_MOTION_ERROR + 16;
        //public const int ELEV_LY_SEARCH_HOME_TIME_OUT = ELEV_MOTION_ERROR + 17;
        //public const int ELEV_LY_CLEAR_HOME_TIME_OUT = ELEV_MOTION_ERROR + 18;
        //public const int ELEV_LY_MOVE_POS_ERROR = ELEV_MOTION_ERROR + 19;

        //public const int ELEV_RZ_MOTOR_ALARM = ELEV_MOTION_ERROR + 20;
        //public const int ELEV_RZ_SEARCH_HOME_TIME_OUT = ELEV_MOTION_ERROR + 21;
        //public const int ELEV_RZ_CLEAR_HOME_TIME_OUT = ELEV_MOTION_ERROR + 22;
        //public const int ELEV_RZ_MOVE_POS_ERROR = ELEV_MOTION_ERROR + 23;

        //public const int ELEV_RY_MOTOR_ALARM = ELEV_MOTION_ERROR + 26;
        //public const int ELEV_RY_SEARCH_HOME_TIME_OUT = ELEV_MOTION_ERROR + 27;
        //public const int ELEV_RY_CLEAR_HOME_TIME_OUT = ELEV_MOTION_ERROR + 28;
        //public const int ELEV_RY_MOVE_POS_ERROR = ELEV_MOTION_ERROR + 29;

        public const int ELEV_MOTOR_ALARM = ELEV_MOTION_ERROR + 30;
        public const int ELEV_HOME_TIME_OUT = ELEV_MOTION_ERROR + 31;
        public const int ELEV_MOVE_POS_ERROR = ELEV_MOTION_ERROR + 33;
        public const int ELEV_MOVE_MAG_ERROR = ELEV_PROCESS_ERROR + 34;
        public const int ELEV_MAG_MISSING = ELEV_MOTION_ERROR + 40;

        //public const int ELEV_LEFT_MOVE_MAGZ = ELEV_PROCESS_ERROR + 50;
        //public const int ELEV_RIGHT_MOVE_MAGZ = ELEV_PROCESS_ERROR + 70;
        #endregion

        const int ELEV_PROCESS_ERROR = 5300;
        //public const int ELEV_LEFT_DOOR_OPEN = ELEV_PROCESS_ERROR + 10;
        //public const int ELEV_RIGHT_DOOR_OPEN = ELEV_PROCESS_ERROR + 20;
        public const int ELEV_EX_ERR = 5998;
        //public const int ELEV_UNKNOWN_EX_ERR = 5999;
        #endregion

        public ErrCode()
        {
            MsgInfo.TMsgInfoList MsgList = new MsgInfo.TMsgInfoList();
            MsgList.Add(EMO_ACTIVATED, "EMO Activated.", "Clear Machine EMO.");
            MsgList.Add(SYSTEM_NOT_READY, "System Not Ready.", "Initialize System.@Check Module Status.");

            MsgList.Add(ErrCode.EXIT_SAVE_RECIPE, "Close NDisp3Win?", "Ensure all Parameters are saved.");
            MsgList.Add(ErrCode.LOAD_NEW_RECIPE, "Load New Recipe.", "Initialization required.");
            MsgList.Add(ErrCode.EXIT_WHEN_LOT_ACTIVATED, "Lot Is Activated!", "Please End Lot Before Close NDisp3Win");

            MsgList.Add(ErrCode.INIT_SYSTEM, "Initialize System?", "");
            MsgList.Add(ErrCode.INIT_GANTRY, "Initialize Gantry?", "");
            MsgList.Add(ErrCode.INIT_GANTRY_FAIL, "Init Gantry Failed.", "Check Parameter and Settings.");
            MsgList.Add(ErrCode.INIT_CONVEYOR, "Initialize Conveyor?", "");
            MsgList.Add(ErrCode.INIT_CONVEYOR_FAIL, "Init Conveyor Failed.", "Check Parameter and Settings.");
            MsgList.Add(ErrCode.INIT_LR_LINE, "Initialize LR Line?", "");
            MsgList.Add(ErrCode.INIT_LR_LINE_FAIL, "Init LR Line Failed.", "Check Parameter and Settings.");

            MsgList.Add(ErrCode.LOW_AIR_PRESSURE, "Low Air Pressure.", "Check Incoming Air Supply.");
            MsgList.Add(ErrCode.FRONT_DOOR_OPEN, "Front Door Open.", "Check Front Door is closed.");
            MsgList.Add(ErrCode.LEFT_ELEV_DOOR_OPEN, "Left Elevator Door Open.", "Check Elevator Door is closed.");
            MsgList.Add(ErrCode.RIGHT_ELEV_DOOR_OPEN, "Right Elevator Door Open.", "Check Elevator Door is closed.");

            MsgList.Add(ErrCode.INPUT_IS_STOPPED, "Input is Stopped.@1. OK - Enable Input and Start Run.@2. STOP - Stop Run.@3. CANCEL - Start Run.", "");
            MsgList.Add(ErrCode.DISP12MODE_WAIT_PRE_TIMEOUT, "Wait Pre TimeOut. Continue Pro only?", "");
            MsgList.Add(ErrCode.IN_MAGAZINE_EMPTY_WORK_COMPLETE, "Input Magazine is Empty. Work is complete.", "Load New Magazine.");

            MsgList.Add(ErrCode.RESET_PERF_INFO, "Reset Performance Information?", "");
            MsgList.Add(ErrCode.S320_LOAD_PRODUCT, "Load Product to Table", "");
            MsgList.Add(ErrCode.S320_UNLOAD_PRODUCT, "Unload Product from Table", "");
            MsgList.Add(ErrCode.S320_NEW_DISPENSE, "Clear current dsipense status and start new dispense?", "");

            MsgList.Add(ErrCode.LOTINFO_ISEMPTY, "Lot Info Is Empty, Please Fill All Information in All Textbox.", "");
            MsgList.Add(ErrCode.LOT_NOT_ACTIVATED, "Please Start Lot Before Auto Run", "");


            #region
            MsgList.Add(ErrCode.ZSENSOR_NOT_CONFIG, "ZSensor is not configured.", "Check ZSensor configuration.");

            MsgList.Add(ErrCode.INVALID_AXIS, "Gantry Invalid Axis.", "1. Check Axis Status. @2. Check Axis Name.");
            MsgList.Add(ErrCode.AXIS_ERR, "Gantry Axis Error.", "1. Check Axis Status. @2. Check Limit Sensor.");
            MsgList.Add(ErrCode.MOTOR_ALARM, "Gantry Axis Motor Alarm.", "1. Check Axis Status. @2. Check Motor and Driver.");
            MsgList.Add(ErrCode.ABNORMAL_MOTOR_POSITION_ERROR, "Abnormal Axis Error.", "Check Motor Position.");

            MsgList.Add(ErrCode.MOVE_PTP_ABS_ERR, "Gantry Move Ptp Abs Error.", "1. Check Axis Status.@2. Check Motor and Driver.");
            MsgList.Add(ErrCode.MOVE_PTP_REL_ERR, "Gantry Move Ptp Rel Error.", "1. Check Axis Status.@2. Check Motor and Driver.");

            MsgList.Add(ErrCode.GANTRY_MOVE_LINE_ABS2_ERR, "Gantry Move Line Abs2 Error.", "1. Check Gantry Status.@2. Check Motor and Driver.");
            MsgList.Add(ErrCode.GANTRY_MOVE_ARC_CENTER_END_ABS_ERR, "Gantry Move Arc Center Abs Error.", "1. Check Gantry Status.@2. Check Motor and Driver.");

            MsgList.Add(ErrCode.GANTRY_NOT_READY, "Gantry Not Ready.", "1. Check Gantry Status.@2. Initialize Gantry.");
            MsgList.Add(ErrCode.HOME_TIMEOUT, "Gantry Axis Home TimeOut.", "1. Check Axis Status.@2. Check Home Sensor.@3. Check Motor and Driver.");
            MsgList.Add(ErrCode.SOFTWARE_N_LIMIT, "Gantry Axis Software N Limit.", "Check Limit Setting.");
            MsgList.Add(ErrCode.SOFTWARE_P_LIMIT, "Gantry Axis Software P Limit.", "Check Limit Setting.");

            MsgList.Add(ErrCode.GX_TARGET_MORE_THAN_STROKE, "GX Target More Than Stroke.", "1. Check program.@2. Check soft limit setting.");
            MsgList.Add(ErrCode.GY_TARGET_MORE_THAN_STROKE, "GY Target More Than Stroke.", "1. Check program.@2. Check soft limit setting.");
            MsgList.Add(ErrCode.GX2Y2_COLLISION_POSSIBLE, "GX2Y2 Possible Collision.", "1. Check program.@2. Check soft limit setting.");
            //MsgList.Add(ErrCode.GXY_ENC_OFFSET, "GXY Encoder Offset.", "1. Check Motor Driver and Wiring.@2. Check Motion Card to driver connection.");

            //MsgList.Add(ErrCode.GZ_MOVE_TO_HOME_SENSOR_FAIL, "GZ Move to Home Sensor Fail.", "1. Check Axis Home Sensor.@2. Check Axis Assembly.@3. Check Motor and Driver.");
            //MsgList.Add(ErrCode.GZ2_MOVE_TO_HOME_SENSOR_FAIL, "GZ Move to Home Sensor Fail.", "1. Check Axis Home Sensor.@2. Check Axis Assembly.@3. Check Motor and Driver.");
            //MsgList.Add(ErrCode.GZ_FOCUS_POS_NOT_SAFE, "GZ Focus Position Not Safe.", "1. GZ Home Sensor must On at Focus Position.@2. Check Focus Position.@3. Check GZ Home Sensor.");

            MsgList.Add(ErrCode.NEEDLE_ZSENSOR_NOT_ON, "Needle ZSensor not On.", "Check ZSensor.");
            MsgList.Add(ErrCode.SEARCH_NEEDLE_ZSENSOR_NOT_FOUND, "Search Needle ZSensor not Found.@OK - Define Z Pos.@Retry - Retry Search Needle ZSensor.@Cancel - Cancel Search Needle.", "");
            MsgList.Add(ErrCode.NEEDLE_ZSENSOR_NOT_OFF, "Needle ZSensor not OFF.", "Check ZSensor.");
            MsgList.Add(ErrCode.NEEDLE_ZSENSOR_ABNORMAL, "Needle ZSensor Abnormal Operation.", "1. Clean ZSensor.@2. Check ZSensor.@3. Check Z Axis.");
            MsgList.Add(ErrCode.DOOR_IS_OPEN, "Door Is Open. Operation not safe.", "1. Close Door.@2. Check Door Sensor.");

            MsgList.Add(ErrCode.ZTOUCH_ECD_NOT_READY, "Z Touch Encoder not Ready.", "Check Stage Top Plate is installed.");
            MsgList.Add(ErrCode.ZTOUCH_ECD_DN_COUNT_FAIL, "Z Touch Encoder Dn Count Fail.", "1. Check Z Touch Sensor.@2. Maintain Z Touch Sensor.@3. Check Z Axis.");
            MsgList.Add(ErrCode.ZTOUCH_ECD_UP_COUNT_FAIL, "Z Touch Encoder Up Count Fail.", "1. Check Z Touch Sensor.@2. Maintain Z Touch Sensor.@3. Check Z Axis.");
            MsgList.Add(ErrCode.ZTOUCH_ECD_ABNORMAL, "Z Touch Encoder Abnormal.", "1.Clean Touch Plate.@2.Check Z Touch Sensor.");

            MsgList.Add(ErrCode.MATERIAL_TIMER_EXPIRED, "Material Timer Expired.@OK - Continue.@Stop - Stop Operation.", "");
            MsgList.Add(ErrCode.FRAME_COUNT_EXCEED_SETTING, "Frame Count Exceed Setting.@OK - Continue.@Stop - Stop Operation.", "1. Check Material.@2. Reset Frame Count.");
            MsgList.Add(ErrCode.UNIT_COUNT_EXCEED_SETTING, "Unit Count Exceed Setting.@OK - Continue.@Stop - Stop Operation.", "1. Check Material.@2. Reset Unit Count.");
            MsgList.Add(ErrCode.RUNTIME_EXCEED_SETTING, "Runtime Exceed Setting.@OK - Continue.@Stop - Stop Operation.", "1. Check Material.@2. Reset Runtime.");
            MsgList.Add(ErrCode.MATERIAL_EXPIRY_PREALERT, "Material Pre-expiry Alert.", "");
            MsgList.Add(ErrCode.MOVE_ZAXIS_TO_POSITION, "Move Z To Position?", "");

            MsgList.Add(ErrCode.MATERIAL1_LEVEL_LOW, "Material1 Level Low.@OK - Continue.@Stop - Stop Operation.", "Change or Refill Material.");
            MsgList.Add(ErrCode.MATERIAL2_LEVEL_LOW, "Material2 Level Low.@OK - Continue.@Stop - Stop Operation.", "Change or Refill Material.");
            MsgList.Add(ErrCode.TEMPCTRL_OUT_OF_RANGE, "Temperature Control Out Of Range.", "Check temperature controls.");

            MsgList.Add(ErrCode.SINGLE_HEAD_RUN_CHECK, "Single Head Run. Ensure Head B is removed.", "");
            MsgList.Add(ErrCode.TEACH_NEEDLE_REQUIRED, "Please perform Teach Needle.", "");
            MsgList.Add(ErrCode.CHUCK_VAC_NOT_HIGH, "Chuck Vacuum Not Detected.@OK - Continue without vacuum.@Stop - Stop.", "1. Check part is properly located.@2. Check Chuck Vacuum switch setting.");

            MsgList.Add(ErrCode.FILL_COUNT_EXCEED_LIMIT, "Fill Count Exceed Limit.@OK - Continue.@Stop - Stop Operation.", "Replace Rotary Rod.");
            MsgList.Add(ErrCode.UNIT_COUNT_EXCEED_LIMIT, "Unit Count Exceed Limit.@OK - Continue.@Stop - Stop Operation.", "Replace Pump Consumables.");

            MsgList.Add(ErrCode.MATERIAL1_UNIT_RUN_EXCEEDED, "Material 1 Unit Run Exceeded Limit.@OK - Continue Dispense.@Stop - Stop Operation.", "Replace Material.");
            MsgList.Add(ErrCode.MATERIAL2_UNIT_RUN_EXCEEDED, "Material 2 Unit Run Exceeded Limit.@OK - Continue Dispense.@Stop - Stop Operation.", "Replace Material.");


            MsgList.Add(ErrCode.CALIBRATE_SPEED_TO_TIME_CANCELLED, "Calibrate Speed To Time Cancelled.", "");
            MsgList.Add(ErrCode.CALIBRATE_SPEED_TO_TIME_ERR, "Calibrate Speed To Time Error.", "1. Check parameter.@2. Check ExMessage for details.");
            MsgList.Add(ErrCode.CALIBRATE_SPEED_TO_TIME_INVALID_PARA, "Calibrate Speed To Time Invalid Para.", "1. Check parameter.@2. Check ExMessage for details.");

            MsgList.Add(ErrCode.DO_REF_OFFSET_OOS, "DO_REF Offset Out Off Spec.@OK - Accept.@Stop - Stop.", "");
            MsgList.Add(ErrCode.DO_REF_ANGLE_OOS, "DO_REF Angle Out Off Spec.@OK - Accept.@Stop - Stop.", "");
            MsgList.Add(ErrCode.DO_REF_PT1_PT2_DIST_OOS, "DO_REF Pt1 and Pt2 Distance Out Off Spec.@OK - Accept.@Stop - Stop.", "");

            MsgList.Add(ErrCode.DO_HEIGHT_TOLERANCE_OOS, "DO_HEIGHT Error Tolerance Out Off Spec.@Stop - Stop.@Retry - Retry DO_HEIGHT.@Cancel - Reject Board.", "1. Check Product.@2. Check Error Tol Value.");

            MsgList.Add(ErrCode.CREATE_MAP_OKYIELD_OOS, "CREATE_MAP OK Yield is Out Off Spec.@OK - Accept.@Stop - Stop.@Retry - Retry.@Cancel - Reject Board.", "");

            MsgList.Add(ErrCode.DO_VISION_FAIL, "DO_VISION Fail.@OK - Manual.@Stop - Stop.@Retry - Retry DO_VISION.@Cancel - Reject Board.", "");

            MsgList.Add(ErrCode.PROGRAM_SCRIPT_ERR, "Progam Script Error.", "1. Check Script parameter.@2. Check ExMessage for details.");
            MsgList.Add(ErrCode.PROGRAM_CANNOT_DELETE_ACTIVE, "Cannot delete active Progam.", "Ensure program to delete is not active.");
            MsgList.Add(ErrCode.PROGRAM_CONFIRM_DELETE, "Confirm to delete selected program?. Deleted program cannot be be undone.", "");
            MsgList.Add(ErrCode.PROGRAM_HEAD_ERROR, "Program Script Head Assign Error.", "Check Script Head parameter.");
            MsgList.Add(ErrCode.PROGRAM_DRAW_OFFSET_UPDATE, "Program Script Update Draw Offset?@OK - Update Offset.@Cancel - Do not Update.", "");
            MsgList.Add(ErrCode.PROGRAM_ACTIVE_PROGRAM_COMMAND_MODIFICATION, "Program Script is Active. Cancel program to edit script.", "");

            MsgList.Add(ErrCode.VOLUME_OFST_PATH_NOT_FOUND, "Volume Offset Path Not Found.", "Check program Volume Offset Path. @OK - Continue without Volume Offset. @Stop - Stop.");
            MsgList.Add(ErrCode.VOLUME_OFST_ERROR, "Volume Offset Error.", "Check program Volume Offset Setting");

            MsgList.Add(ErrCode.DISPCORE_NOT_INIT, "DispCore not Init.", "Pls contact NSW representative.");
            MsgList.Add(ErrCode.FRAME_COUNTER_FULL, "Frame Counter Reach Total Frame Count", "Machine Stop");

            MsgList.Add(ErrCode.GANTRY_OPEN_BOARD1_FAIL, "Gantry Open Board1 Error.", "1. Check motion board is installed.@2. Check motion board drivers are installed.");
            MsgList.Add(ErrCode.GANTRY_OPEN_BOARD2_FAIL, "Gantry Open Board2 Error.", "1. Check motion board is installed.@2. Check motion board drivers are installed.");
            MsgList.Add(ErrCode.GANTRY_INIT_BOARD1_FAIL, "Gantry Init Board1 Error.", "1. Check motion board is installed.@2. Check motion board drivers are installed.");
            MsgList.Add(ErrCode.GANTRY_INIT_BOARD2_FAIL, "Gantry Init Board2 Error.", "1. Check motion board is installed.@2. Check motion board drivers are installed.");
            MsgList.Add(ErrCode.GANTRY_BOARD1_NOT_OPENED, "Gantry Board1 Not Opened.", "1. Check motion board is installed.@2. Check motion board drivers are installed.");
            MsgList.Add(ErrCode.GANTRY_BOARD2_NOT_OPENED, "Gantry Board2 Not Opened.", "1. Check motion board is installed.@2. Check motion board drivers are installed.");
            MsgList.Add(ErrCode.GANTRY_MOTION_EX_ERR, "Gantry Motion Exception Error.", "1. Check Motor Address.@2.Check ExMessage and feedback to NSW Automation.");
            MsgList.Add(ErrCode.GANTRY_IO_EX_ERR, "Gantry IO Exception Error.", "1. Check IO Address.@2.Check ExMessage and feedback to NSW Automation.");


            MsgList.Add(ErrCode.WEIGHT_COMM_EX_ERR, "Weight Comm Exception Error.", "Check ExMessage and feedback to NSW Automation.");
            MsgList.Add(ErrCode.WEIGHT_NO_HEAD_SELECTED, "Weight No Head is Selected.", "Select Head to Measure or Calibrate.");
            MsgList.Add(ErrCode.WEIGHT_OPEN_ERR, "Weight Open Error.", "1. Check Weight connection.@2. Check System Config.@3 Check Weight settings.");
            MsgList.Add(ErrCode.WEIGHT_GETVALUE_ERR, "Weight Get Value Error.", "Check Weight connection.");
            MsgList.Add(ErrCode.WEIGHT_INVALID_TARGET, "Invalid Weight Target.", "Check Weight Target value is correct.");
            MsgList.Add(ErrCode.WEIGHT_INVALID_TOLERANCE, "Invalid Weight Tolerance.", "Check Weight Tolerance value is correct.");
            MsgList.Add(ErrCode.WEIGHT_CAL_CANCELLED, "Weight Calibration Cancelled.", "Check Weight Tolerance value is correct.");
            MsgList.Add(ErrCode.WEIGHT_INVALID_SPEC, "Invalid Weight Spec.", "Check Weight Target spec is correct.");
            MsgList.Add(ErrCode.WEIGHT_INVALID_SPEC_LIMIT, "Invalid Weight Spec Limit.", "Check Weight Spec Limit value is correct.");
            MsgList.Add(ErrCode.WEIGHT_CAL_REQUIRED, "Weight Calibration is not executed.", "Execute Weight Calibration.");
            MsgList.Add(ErrCode.WEIGHT_MEAS_REQUIRED, "Weight Measure is not executed.", "Execute Weight Measure.");
            MsgList.Add(ErrCode.WEIGHT_PROG_HEAD_OP_SINGLE_SELECTED, "Program Head Operation Single selected.", "Pump2 execution prohibited.");

            MsgList.Add(ErrCode.LASER_COMM_EX_ERR, "Laser Comm Exception Error.", "Check ExMessage and feedback to NSW Automation.");
            MsgList.Add(ErrCode.LASER_OPEN_ERR, "Laser Open Error.", "1. Check Laser is connection.@2. Check Laser communication settings.");
            MsgList.Add(ErrCode.LASER_NOT_CONFIG_ERR, "Laser Is Not Configured.", "1. Check Laser config.@2. Check Laser settings.");
            MsgList.Add(ErrCode.LASER_NOT_OPEN_ERR, "Laser Not Open Error.", "1. Check Laser connection.@2. Check Laser communication.@3.Check Laser settings.");
            MsgList.Add(ErrCode.LASER_OUT_OF_RANGE_ERR, "Laser Out Of Range.", "1. Check Laser is within sensing range.");
            MsgList.Add(ErrCode.LASER_NOT_SUPPORTED, "Laser Not Supported.", "Laser type is not supported.");
            MsgList.Add(ErrCode.LASER_OUT_OF_REF_HEIGHT_TOL, "Out of Ref Height Tol.", "");

            MsgList.Add(ErrCode.DISPCTRL_COMM_EX_ERR, "Disp Controller Comm Exception Error.", "Check ExMessage and feedback to NSW Automation.");
            MsgList.Add(ErrCode.DISPCTRL_INIT, "Disp Controller Init?.@OK - Init Disp Controller.@Cancel - Do not Init Disp Controller.", "");
            MsgList.Add(ErrCode.DISPCTRL_ERR, "Disp Controller Error.", "1. Check Dispense Controller for Error Details.@2. Clear Dispenser Controller Errors.");
            MsgList.Add(ErrCode.DISPCTRL1_OPEN_ERR, "Disp Controller 1 Open Error.", "1. Check Controller connection.@2. Check Controller settings.");
            MsgList.Add(ErrCode.DISPCTRL2_OPEN_ERR, "Disp Controller 2 Open Error.", "1. Check Controller connection.@2. Check Controller settings.");
            MsgList.Add(ErrCode.DISPCTRL1_COMM_ERR, "Disp Controller 1 Comm Error.", "1. Check Controller connection.@2. Check Controller settings.@3. Check Disp Controller communcation cables.");
            MsgList.Add(ErrCode.DISPCTRL2_COMM_ERR, "Disp Controller 2 Comm Error.", "1. Check Controller connection.@2. Check Controller settings.@3. Check Disp Controller communcation cables.");
            MsgList.Add(ErrCode.DISPCTRL1_NOT_READY, "Disp Controller 1 Not Ready.", "1. Check Controller Condition.@2. Check Controller IO Cables.@3. Check Controller IO settings.");
            MsgList.Add(ErrCode.DISPCTRL2_NOT_READY, "Disp Controller 2 Not Ready.", "1. Check Controller Condition.@2. Check Controller IO Cables.@3. Check Controller IO settings.");
            MsgList.Add(ErrCode.DISPCTRL1_READY_TIMEOUT, "Disp Controller 1 Ready TimeOut.", "1. Check Controller Condition.@2. Check Disp Ready TimeOut value.@3. Check Controller IO Cables.");
            MsgList.Add(ErrCode.DISPCTRL2_READY_TIMEOUT, "Disp Controller 2 Ready TimeOut.", "1. Check Controller Condition.@2. Check Disp Ready TimeOut value.@3.  Check Controller IO Cables.");
            MsgList.Add(ErrCode.DISPCTRL1_RESPONSE_TIMEOUT, "Disp Controller 1 Response TimeOut.", "1. Check Controller Condition.@2. Check Disp Response TimeOut value.@3.  Check Controller IO Cables.");
            MsgList.Add(ErrCode.DISPCTRL2_RESPONSE_TIMEOUT, "Disp Controller 2 Response TimeOut.", "1. Check Controller Condition.@2. Check Disp Response TimeOut value.@3. Check Controller IO Cables.");
            MsgList.Add(ErrCode.DISPCTRL1_COMPLETE_TIMEOUT, "Disp Controller 1 Complete TimeOut.", "1. Check Controller Condition.@2. Check Disp Response TimeOut value.@3.  Check Controller IO Cables.");
            MsgList.Add(ErrCode.DISPCTRL2_COMPLETE_TIMEOUT, "Disp Controller 2 Complete TimeOut.", "1. Check Controller Condition.@2. Check Disp Response TimeOut value.@3. Check Controller IO Cables.");

            MsgList.Add(ErrCode.DISPCTRL_ROTARY_TIMEOUT, "Disp Controller Rotary TimeOut.", "1. Check Pump Rotary. @2. Check Dispense Controller.");

            MsgList.Add(ErrCode.DISPCTRL_THREAD_BUSY, "Disp Controller Thread is Busy.", "1. Check ExMessage.@2. Check Disp Controller.");
            MsgList.Add(ErrCode.DISPCTRL_THREAD_ERROR, "Disp Controller Thread Error.", "1. Check ExMessage.@2. Check Disp Controller.");
            MsgList.Add(ErrCode.DISPCTRL_THREAD_TIMEOUT, "Disp Controller Thread TimeOut.", "1. Check ExMessage.@2. Check Disp Controller.");

            MsgList.Add(ErrCode.PRESSCTRL_THREAD_BUSY, "Pressure Controller Thread is Busy.", "1. Check ExMessage.@2. Check Pressure Controller.");
            MsgList.Add(ErrCode.PRESSCTRL_THREAD_ERROR, "Pressure Controller Thread Error.", "1. Check ExMessage.@2. Check Pressure Controller.");
            MsgList.Add(ErrCode.PRESSCTRL_THREAD_TIMEOUT, "Pressure Controller Thread TimeOut.", "1. Check ExMessage.@2. Check Pressure Controller.");

            MsgList.Add(ErrCode.CAMERA_COMM_EX_ERR, "Camera Comm Exception Error.", "Check ExMessage and feedback to NSW Automation.");
            MsgList.Add(ErrCode.CAMERA_INIT_ERR, "Camera Init Error.", "Check Vision Drivers.");
            MsgList.Add(ErrCode.CAMERA_DRIVER_NOT_SUPPORT, "Camera Driver Support Error.", "Camera Driver is not Supported.");
        MsgList.Add(ErrCode.CAMERA1_OPEN_ERR, "Camera1 Open Error.", "1. Check Camera connection.@2. Check Camera Drivers.");
            MsgList.Add(ErrCode.CAMERA2_OPEN_ERR, "Camera2 Open Error.", "1. Check Camera connection.@2. Check Camera Drivers.");
            MsgList.Add(ErrCode.CAMERA3_OPEN_ERR, "Camera3 Open Error.", "1. Check Camera connection.@2. Check Camera Drivers.");
            MsgList.Add(ErrCode.CAMERA_NOT_CONFIG_ERR, "Camera Not Configured.", "1. Check System Config.@2. Check Camera configuration.");
            MsgList.Add(ErrCode.CAMERA_GRAB_TIMEOUT, "Camera Grab TimeOut.", "1. Check Camera settings.@2. Check Camera configuration.");

            MsgList.Add(ErrCode.LEDCTRL_COMM_EX_ERR, "Led Controller Comm Exception Error.", "Check ExMessage and feedback to NSW Automation.");
            MsgList.Add(ErrCode.LEDCTRL_UNKNOWN_CTRL_ERR, "Led Controller Not Recognized.", "Check ExMessage and feedback to NSW Automation.");
            MsgList.Add(ErrCode.LEDCTRL_OPEN_ERR, "Led Controller Open Error.", "1. Check Controller connection.@2. Check System Config.@3 Check Controller settings.");
            MsgList.Add(ErrCode.LEDCTRL_SETVALUE_ERR, "Led Controller Set Value Error.", "Check Controller connection.");

            MsgList.Add(ErrCode.FUNC_NOT_SUPPORT, "Function Not Supported.", "Check features or consult NSW Automation.");
            MsgList.Add(ErrCode.DISPCORE_EX_ERR, "Exception Error.", "Check ExMessage for details.");
            MsgList.Add(ErrCode.UNKNOWN_EX_ERR, "Unknown Exception Error.", "Check ExMessage and feedback to NSW Automation.");

            #endregion

            #region Conv
            #region 4000
            MsgList.Add(CONV_INIT_ACCESS, "Conveyor Init Confirmation.", "Are You Sure To Init Conveyor?");
            MsgList.Add(CONV_DRY_RUN_ACCESS, "Conveyor Dry Run Confirmation.", "Are You Sure to Dry Run The Conveyor?");
            MsgList.Add(ALL_INIT_ACCESS, "Conveyor Init ALL Confirmation.", "Are You Sure To Init Conveyor?");
            //MsgList.Add(DOOR_IS_OPEN, "Door Is Open. Operation not safe.", "1. Close Door.@2. Check Door Sensor.");
            #endregion

            #region 4100
            MsgList.Add(CONV_OPEN_BOARD_FAIL, "Conveyor Open Board Error.", "1. Check ZKA Network Port are connected.");
            MsgList.Add(CONV_VALUE_OUT_OF_RANGE, "Conveyor Value Out Of Range Error.", "Invalid Value or Value Out Of Range.");
            MsgList.Add(CONV_NOT_READY, "Conveyor Not Ready.", "1. Check conveyor status.@2. Initialize conveyor.");
            MsgList.Add(CONV_BELT_RUN_ERROR, "Conveyor Belt Run Error.", "1. Check parameter of conveyor motor.@2. Check wiring from motor to ZKA connection.");
            MsgList.Add(CONV_STOPPER_UP_TIMEOUT, "Conveyor Stopper Up Error.", "1. Check Stopper cylinder air and sensor.@2. Check Stopper cylinder delay.");
            MsgList.Add(CONV_STOPPER_DN_TIMEOUT, "Conveyor Stopper Down Error.", "1. Check Stopper cylinder air and sensor.@2. Check Stopper cylinder delay.");
            MsgList.Add(CONV_LIFTER_UP_TIMEOUT, "Conveyor Lifter Up Error.", "1. Check Lifter cylinder air and sensor.@2. Check Lifter cylinder delay.");
            MsgList.Add(CONV_LIFTER_DN_TIMEOUT, "Conveyor Lifter Down Error.", "1. Check Lifter cylinder air and sensor.@2. Check Lifter cylinder delay.");
            MsgList.Add(CONV_PRECISOR_EXT_TIMEOUT, "Conveyor Precisor Extend Error.", "1. Check Precisor air and sensor.@2. Check Precisor cylinder delay.");
            MsgList.Add(CONV_PRECISOR_RET_TIMEOUT, "Conveyor Precisor Retract Error.", "1. Check Precisor air and sensor.@2. Check Precisor cylinder delay.");
            MsgList.Add(CONV_KICKER_EXT_TIMEOUT, "Conveyor Kicker Extend Error.", "1. Check Kicker air and sensor.@2. Check Kicker cylinder delay.");
            MsgList.Add(CONV_KICKER_RET_TIMEOUT, "Conveyor Kicker Retract Error.", "1. Check Kicker air and sensor.@2. Check Kicker cylinder delay.");
            MsgList.Add(CONV_VACUUM_ON_TIMEOUT, "Conveyor Vacuum 1 On Error.", "1. Check Vacuum1 lines and supply.@2. Check Vacuum1 Switch presure value.");
            MsgList.Add(CONV_VACUUM_OFF_TIMEOUT, "Conveyor Vacuum 1 Off Error.", "1. Check Vacuum1 lines and supply.@2. Check Vacuum1 Switch presure value.");
            MsgList.Add(CONV_VACUUM2_ON_TIMEOUT, "Conveyor Vacuum 2 On Error.", "1. Check Vacuum2 lines and supply.@2. Check Vacuum2 Switch presure value.");
            MsgList.Add(CONV_VACUUM2_OFF_TIMEOUT, "Conveyor Vacuum 2 Off Error.", "1. Check Vacuum2 lines and supply.@2. Check Vacuum2 Switch presure value.");
            MsgList.Add(CONV_VACUUM_LOW, "Conveyor Vacuum Low.", "1. Check Vacuum lines and supply.@2. Check Vacuum Switch presure value.");
            #endregion

            #region 4200
            MsgList.Add(CONV_IN_SENSOR_PSNT, "Conveyor In Sensor Present Error.", "1. Remove part at In Station. @2. Check InPsnt Sensor.");
            MsgList.Add(CONV_IN_CLEAR_SENSOR_PSNT, "Conveyor In Clear Sensor Present Error.", "1. Remove part at between Left Elevator and Conveyor. @2. Check In Clear Sensor.");
            MsgList.Add(CONV_OUT_SENSOR_PSNT, "Conveyor Out Sensor Present Error.", "1. Remove part at Out Station. @2. Check OutPsnt Sensor.");
            MsgList.Add(CONV_OUT_CLEAR_SENSOR_PSNT, "Conveyor Out Clear Sensor Present Error.", "1. Remove part at between Conveyor and Out Elevator. @2. Check Out Clear Sensor.");
            MsgList.Add(CONV_MANUAL_UNLOAD, "Conveyor Manual Unload Product.", "Unload Product at Out Station.");
            MsgList.Add(CONV_SENSOR_PART_PSNT, "Part Present at Conveyor.", "Clear Part at Conveyor.");
            MsgList.Add(CONV_SENSOR_PART_MISSING, "Part Missing at Conveyor.", "Place Part at Conveyor.");
            MsgList.Add(CONV_UNLOAD_TIMEOUT, "Conveyor Unload Time Out.", "Check Part jam at Out Station.");
            MsgList.Add(CONV_MOVE_TIMEOUT, "Conveyor Move Time Out.", "Check Part jam at Conveyor.");
            MsgList.Add(CONV_REVERSE_UNLOAD_TIMEOUT, "Conveyor Reverse Unload Time Out.", "Check Part jam at In Station.");
            MsgList.Add(CONV_HEATER_OUT_OF_RANGE, "Conveyor Heater Out of Range Error.", "1. Wait Heater Process Warm Up.@2. Check Heater Controller and Thermocouple.");
            MsgList.Add(CONV_REMOVE_PART_FROM_CONVEYOR, "Conveyor Unknown Status.", "Remove Part from Conveyor and Init Conveyor.");
            MsgList.Add(CONV_OUT_MAG_LEVEL_MISMATCH, "Unload Frame. Output Mag Level Mismatch.", "Stop or Continue Unload to Mismatch Level.");
            MsgList.Add(CONV_UNLOAD_TO_MISMATCH_LEVEL, "Unload Frame to Mismatch Level.", "Confirm Unload to Mismatch Level.");
            #endregion

            MsgList.Add(CONV_SMEMA_LEFT_BOARD_IN_TIMEOUT, "Left(UpLine) Smema Load Time Out.", "Check Product at Conveyor.");
            MsgList.Add(CONV_SMEMA_RIGHT_IN_TIMEOUT, "Right Smema Unload Time Out.", "Check Product at Conveyor.");

            MsgList.Add(CONV_SMEMA_RIGHT_REVERSE_WAIT_BOARD_TIMEOUT, "Right(DownLine) Smema Wait Board Time Out.", "Check Product at Conveyor.");

            MsgList.Add(CONV_SMEMA_LEFT_BOARD_OUT_TIMEOUT, "Left Smema2 Board Sendout Time Out.", "Check Product at Conveyor.");

            MsgList.Add(CONV_EX_ERR, "Conveyor Exception Error.", "Check ExMessage for details.");
            #endregion

            #region Elev
            MsgList.Add(ELEV_ALL_INIT_ACCESS, "Elevator All Init Confirmation.", "Are You Sure To Init All Elevator?");
            MsgList.Add(ELEV_LEFT_INIT_ACCESS, "Elevator Left Init Confirmation.", "Are You Sure To Init Left Elevator?");
            MsgList.Add(ELEV_RIGHT_INIT_ACCESS, "Elevator Right Init Confirmation.", "Are You Sure To Init Right Elevator?");
            MsgList.Add(ELEV_DRY_RUN_ACCESS, "Elevator Dry Run Confirmation.", "Are You Sure to Dry Run The Elevator?");
            //MsgList.Add(ELEV_NON_CONFIG_ACCESS, "Elevator Non Config Access Error.", " NON CONFIGURED ELEVATOR PAGE!");
            MsgList.Add(ELEV_LEFT_PUSHER_INIT_ACCESS, "Elevator Left Pusher Init Confirmation.", "Are You Sure To Init Left Pusher Elevator?");

            #region 5100
            MsgList.Add(ELEV_OPEN_BOARD_FAIL, "Elevator Open Board Error.", "1. Check ZKA Network Port are connected.");
            MsgList.Add(ELEV_PUSHER_CONT_SEND_FAIL, "Elevator Pusher Continuous Send Product Fail.", "Retry - Continue Send.@Stop - Disable Input.");
            MsgList.Add(ELEV_PUSHER_EXT_TIME_OUT, "Elevator Pusher Ext Time Out.", "1. Check Pusher Status.@2. Check LZ Pusher Sensors.");
            MsgList.Add(ELEV_PUSHER_RET_TIME_OUT, "Elevator Pusher Ret Time Out.", "1. Check Pusher Status.@2. Check LZ Pusher Sensors.");
            MsgList.Add(ELEV_PUSHER_SENS_HOME_ERROR, "Elevator Pusher Home Sensor Error.", "Check Pusher Home Sensor Condition.");
            MsgList.Add(ELEV_PUSHER_SENS_LIMIT_ERROR, "Elevator Pusher Limit Sensor Error.", "Check Pusher Limit Sensor Condition.");
            MsgList.Add(ELEV_PUSHER_NOT_HOME_ERROR, "Elevator Pusher Home Error.", "1. Check Pusher is Home. 2. Check Pusher Home Sensor.");
            MsgList.Add(ELEV_PUSHER_JAM, "Elevator Pusher Jam.", "Check Part Jam at Pusher.");
            MsgList.Add(ELEV_PUSHER_HOME_FUNCTIONAL_ERROR, "Elevator Home Functional Error.", "Check Pusher Home Sensor Condition.");
            MsgList.Add(ELEV_PUSHER_ABNORMAL_STATE, "Elevator Pusher Abnormal State.", "1. Check Pusher Home Sensor faulty.@2. Check Pusher Limit Sensor faulty.");
            #endregion

            #region 5200
            MsgList.Add(ELEV_MOVE_RELATIVE_ERR, "Elevator Motion Move Relative Error.", "1. Check ZKA Network Connection Status.@2. Check Motor Status.");
            MsgList.Add(ELEV_SET_MOTION_PARAM_ERR, "Elevator Set Motion Parameter Error.", "1. Check ZKA Network Connection Status.");
            MsgList.Add(ELEV_AXIS_WAIT_ERR, "Elevator Axis Wait Error.", "1. Check ZKA Network Connection Status.@2. Check Motor Status");
            MsgList.Add(ELEV_AXIS_JOG_FAIL, "Elevator Jog Direction Fail.", "1. Check ZKA Network Connection Status.@2. Check Motor Status");
            MsgList.Add(ELEV_FORCE_STOP_FAIL, "Elevator Force Stop Fail.", "1. Check ZKA Network Connection Status.@2. Check Motor Status.");
            MsgList.Add(ELEV_MOVE_CONST_ERR, "Elevator Motion Move Constant Error.", "1. Check ZKA Network Connection Status.@2. Check Motor Status.");
            //MsgList.Add(ELEV_LZ_SEARCH_HOME_TIME_OUT, "Elevator LZ Search Home Time Out.", "1. Check LZ Axis Status.@2. Check LZ Home Sensor.@3. Check LZ Motor.");
            //MsgList.Add(ELEV_LZ_CLEAR_HOME_TIME_OUT, "Elevator LZ Clear Home Time Out.", "1. Check LZ Axis Status.@2. Check LZ Home Sensor.@3. Check LZ Motor.");
            //MsgList.Add(ELEV_LZ_MOVE_POS_ERROR, "Elevator LZ Motor Move Position Error.", "1. Check LZ Axis Status.@2. Check LZ Motor.@3. Check ZKA Network Connection Status.");
            //MsgList.Add(ELEV_LY_SEARCH_HOME_TIME_OUT, "Elevator LY Search Home Time Out.", "1. Check LY Axis Status.@2. Check LY Home Sensor.@3. Check LY Motor.");
            //MsgList.Add(ELEV_LY_CLEAR_HOME_TIME_OUT, "Elevator LY Clear Home Time Out.", "1. Check LY Axis Status.@2. Check LY Home Sensor.@3. Check LY Motor.");
            //MsgList.Add(ELEV_LY_MOVE_POS_ERROR, "Elevator LY Motor Move Position Error.", "1. Check LY Axis Status.@2. Check LY Motor.@3. Check ZKA Network Connection Status.");
            //MsgList.Add(ELEV_RZ_SEARCH_HOME_TIME_OUT, "Elevator RZ Search Home Time Out.", "1. Check RZ Axis Status.@2. Check RZ Home Sensor.@3. Check RZ Motor.");
            //MsgList.Add(ELEV_RZ_CLEAR_HOME_TIME_OUT, "Elevator RZ Clear Home Time Out.", "1. Check RZ Axis Status.@2. Check RZ Home Sensor.@3. Check RZ Motor.");
            //MsgList.Add(ELEV_RZ_MOVE_POS_ERROR, "Elevator RZ Motor Move Position Error.", "1. Check RZ Axis Status.@2. Check RZ Motor.@3. Check ZKA Network Connection Status.");
            //MsgList.Add(ELEV_RY_MOTOR_ALARM, "Elevator RY Motor Alarm Error.", "1. Check RY Axis Motor Status.@2. Check Right Motor.");
            //MsgList.Add(ELEV_RY_SEARCH_HOME_TIME_OUT, "Elevator RY Search Home Time Out.", "1. Check RY Axis Status.@2. Check RY Home Sensor.@3. Check RY Motor.");
            //MsgList.Add(ELEV_RY_CLEAR_HOME_TIME_OUT, "Elevator RY Clear Home Time Out.", "1. Check RY Axis Status.@2. Check RY Home Sensor.@3. Check RY Motor.");
            //MsgList.Add(ELEV_RY_MOVE_POS_ERROR, "Elevator RY Motor Move Position Error.", "1. Check RY Axis Status.@2. Check RY Motor.@3. Check ZKA Network Connection Status.");
            MsgList.Add(ELEV_MOTOR_ALARM, "Motor Alarm Error.", "1. Check Axis Status.@2. Check Motor.@3. Check ZKA Network Connection Status.");
            MsgList.Add(ELEV_HOME_TIME_OUT, "Elevator Search Home Time Out.", "1. Check Axis Status.@2. Check Home Sensor.@3. Check Motor.");
            MsgList.Add(ELEV_MOVE_POS_ERROR, "Elevator Motor Move Position Error.", "1. Check Axis Status.@2. Check Motor.@3. Check ZKA Network Connection Status.");
            MsgList.Add(ELEV_MAG_MISSING, "Elevator Magazine is Missing.", "1. Check Magazine Present.@2. Check Magazine Sensor.");
            //MsgList.Add(ELEV_LEFT_MOVE_MAGZ, "Elevator Left Move Magzine Error.", "1. Check Motor Status.@2. Check ZKA Network Connection Status.");
            //MsgList.Add(ELEV_RIGHT_MOVE_MAGZ, "Elevator Right Move Magzine Error.", "1. Check Motor Status.@2. Check ZKA Network Connection Status.");
            #endregion

            #region 5300
            //MsgList.Add(ELEV_LEFT_DOOR_OPEN, "Elevator Left Door Open.", "Close Door.");
            //MsgList.Add(ELEV_RIGHT_DOOR_OPEN, "Elevator Right Door Open.", "Close Door.");
            #endregion

            MsgList.Add(ELEV_EX_ERR, "Elevator Exception Error.", "Check ExMessage for details.");
            //MsgList.Add(ELEV_UNKNOWN_EX_ERR, "Elevator Unknown Exception Error.", "Check ExMessage and feedback to NSW Automation.");
            #endregion

            MsgInfo.Register(MsgList);

            MsgInfo.Save();
        }
    }
}
