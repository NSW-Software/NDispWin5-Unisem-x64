using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDispWin
{
    class TaskOption
    {
        public static bool Ctrl_LoadPara = false;
        public static bool Ctrl_SavePara = false;

        public static void LoadOption()
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();

            string Filename = GDefine.SetupPath + "\\Disp.Option.ini";
            IniFile.Create(Filename);

            Ctrl_LoadPara = IniFile.ReadBool("Controller", "LoadPara", false);
            Ctrl_SavePara = IniFile.ReadBool("Controller", "SavePara", false);
        }
        public static void SaveOption()
        {
            NSW.Net.IniFile IniFile = new NSW.Net.IniFile();

            string Filename = GDefine.SetupPath + "\\Disp.Option.ini";
            IniFile.Create(Filename);

            IniFile.WriteBool("Controller", "LoadPara", Ctrl_LoadPara);
            IniFile.WriteBool("Controller", "SavePara", Ctrl_SavePara);
        }
    }
}
