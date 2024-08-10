using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace NDispWin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        { 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool AppCreated;

            System.Threading.Mutex AppMutex = new
            System.Threading.Mutex(true, Application.ProductName, out AppCreated);

            #region Auto create app.config file
            string FullFilename = Application.ExecutablePath;
            string True_FullFileName = Application.ExecutablePath;
            if (FullFilename.LastIndexOf(" ") > 0)
            {
                True_FullFileName = FullFilename.Remove(FullFilename.LastIndexOf(" ")) + ".exe";
                if (!File.Exists(FullFilename + ".config"))
                    File.Copy(True_FullFileName + ".config", FullFilename + ".config", true);
            }
            #endregion

            if (!AppCreated)
            {
                Application.Exit();
                Application.ExitThread();
            }
            else
            {
                #region Language
                AppLanguage.Func2.ReadConfig();
                //GDefine.InitLanguage();

                string Dir1 = @"C:\Program Files\NSWAutomation\Language\Component\ChineseS";
                string Dir1Old = @"C:\Program Files\NSWAutomation\Language\Component\CHINESE(Simplify)";
                if (Directory.Exists(Dir1Old))
                {
                    string[] files1 = Directory.GetFiles(Dir1Old);
                    foreach (string f in files1)
                    {
                        string NewFName = Dir1 + @"\" + Path.GetFileName(f);
                        if (!File.Exists(NewFName)) File.Copy(f, NewFName);
                    }
                }

                string Dir2 = @"C:\Program Files\NSWAutomation\Language\Component\ChineseT";
                string Dir2Old = @"C:\Program Files\NSWAutomation\Language\Component\CHINESE(Tranditional)";
                if (Directory.Exists(Dir2Old))
                {
                    string[] files2 = Directory.GetFiles(Dir2Old);
                    foreach (string f in files2)
                    {
                        string NewFName = Dir2 + @"\" + Path.GetFileName(f);
                        if (!File.Exists(NewFName)) File.Copy(f, NewFName);
                    }
                }
                #endregion

                Application.Run(new frm_Main());
                AppMutex.ReleaseMutex();

                AppLanguage.Func2.WriteConfig();
            }
        }
    }
}
