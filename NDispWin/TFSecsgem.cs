using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDispWin
{
    class TFSecsgem
    {
        public static void EQPToHOST_CEID(TEEvent evt)
        {
            ////FieldInfo[] fieldInfos = typeof(TEEventMgr).GetFields(BindingFlags.Public | BindingFlags.Static);


            ////foreach (var errmsg in fieldInfos)
            ////{
            ////    index = Array.IndexOf(fieldInfos, errmsg);
            ////    if (evt == errmsg.GetValue(null)) break;
            ////}


            //var events = typeof(TEEventMgr).GetFields(BindingFlags.Public | BindingFlags.Static)
            //    .Where(x => x.FieldType == typeof(TEEvent))
            //    .Select(x => (TEEvent)x.GetValue(null)).ToArray();

            //var dd = events.FirstOrDefault(x => x == evt);
            //if (dd is null) return;

            //var index = Array.IndexOf(events, evt);
            //index++;    //+1 to align ceid list(start from 01)

            //string dataout = $"S6F11 EQP={GSystemCfg.Wafer.MachineID.Value:D2} CEID={index:D4} TRANSTIME={TimeNow}";
            //Send(dataout);
        }
    }
}
