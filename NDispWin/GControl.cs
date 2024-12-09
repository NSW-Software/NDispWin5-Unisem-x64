using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;

namespace NDispWin
{
    #region IniFile
    public class IIniFile
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string variable, string filepath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filepath);

        private string Filepath;
        private char ArraySeperator = ',';
        private char StringArraySeperator = '@';

        public IIniFile(string filepath)
        {
            try
            {
                Filepath = filepath;
                string folderpath = Path.GetDirectoryName(Filepath);
                if (!Directory.Exists(folderpath)) Directory.CreateDirectory(folderpath);
            }
            catch
            {
            }
        }

        public void Write(string section, string key, string variable)
        {
            WritePrivateProfileString(section, key, variable, Filepath);
        }
        public void Write(string section, string key, string[] variable)
        {
            string value = string.Join(StringArraySeperator.ToString(), variable);
            Write(section, key, value);
        }
        public void Write(string section, string key, bool variable)
        {
            Write(section, key, variable ? "1" : "0");
        }
        public void Write(string section, string key, bool[] variable)
        {
            string value = string.Join(ArraySeperator.ToString(), variable.Select(x => x ? "1" : "0").ToArray());
            Write(section, key, value);
        }
        public void Write(string section, string key, int variable)
        {
            Write(section, key, variable.ToString());
        }
        public void Write(string section, string key, int[] variable)
        {
            string value = string.Join(ArraySeperator.ToString(), variable.Select(p => p.ToString()).ToArray());
            Write(section, key, value);
        }
        public void Write(string section, string key, double variable)
        {
            Write(section, key, variable.ToString());
        }
        public void Write(string section, string key, double[] variable)
        {
            string value = string.Join(ArraySeperator.ToString(), variable.Select(p => p.ToString()).ToArray());
            Write(section, key, value);
        }


        public bool ReadString(string section, string key, ref string value)
        {
            StringBuilder sb = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", sb, 255, Filepath);

            if (i == 0) return false;
            value = sb.ToString();

            return true;
        }
        public bool ReadStringArray(string section, string key, ref string[] value)
        {
            StringBuilder sb = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", sb, 255, Filepath);
            if (i == 0) return false;
            try
            {
                value = sb.ToString().Split(StringArraySeperator);
            }
            catch { return false; }

            return true;
        }
        public bool ReadBool(string section, string key, ref bool value)
        {
            StringBuilder sb = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", sb, 255, Filepath);

            if (i == 0) return false;
            uint v;
            if (!uint.TryParse(sb.ToString(), out v)) return false;
            value = v > 0;
            return true;
        }
        public bool ReadBoolArray(string section, string key, ref bool[] value)
        {
            StringBuilder sb = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", sb, 255, Filepath);
            if (i == 0) return false;
            try
            {
                value = sb.ToString().Split(ArraySeperator).Select(x => x != "0").ToArray();
            }
            catch { return false; }

            return true;
        }
        public bool ReadInt(string section, string key, ref int value)
        {
            StringBuilder sb = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", sb, 255, Filepath);

            if (i == 0) return false;
            if (!int.TryParse(sb.ToString(), out value)) return false;

            return true;
        }
        public bool ReadIntArray(string section, string key, ref int[] value)
        {
            StringBuilder sb = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", sb, 255, Filepath);
            if (i == 0) return false;
            try
            {
                value = Array.ConvertAll(sb.ToString().Split(ArraySeperator), int.Parse);
            }
            catch { return false; }

            return true;
        }
        public bool ReadDouble(string section, string key, ref double value)
        {
            StringBuilder sb = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", sb, 255, Filepath);

            if (i == 0) return false;
            if (!double.TryParse(sb.ToString(), out value)) return false;

            return true;
        }
        public bool ReadDoubleArray(string section, string key, ref double[] value)
        {
            StringBuilder sb = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", sb, 255, Filepath);
            if (i == 0) return false;
            try
            {
                value = Array.ConvertAll(sb.ToString().Split(ArraySeperator), double.Parse);
            }
            catch { return false; }

            return true;
        }
    }
    #endregion

    class GLog
    {
        static ReaderWriterLockSlim Slim = new ReaderWriterLockSlim();
        public static bool WriteLog(string fileName, string content)
        {
            content = content.Replace("\r", "").Replace("\n", "");

            try
            {
                if (Slim.IsWriteLockHeld) Slim.ExitWriteLock();

                Slim.EnterWriteLock();
                var f = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.Write);
                using (StreamWriter w = new StreamWriter(f)) w.WriteLine($"{DateTime.Now:O}\t{content}");
            }
            catch
            {
                return false;
            }
            finally
            {
                Slim.ExitWriteLock();
            }
            return true;
        }

        public static bool WriteProcessLog(string content)
        {
            string lot = LotInfo2.LotNumber;
            string id = DispProg.rt_Read_IDs[0, 0];

            string fName = lot.Length > 0 ? lot + "_" : "";
            fName += id.Length > 0 ? $"{id}" : $"{DateTime.Now:yyyyMMdd}_{Stats.BoardCount}";

            string folder = Log.ProcessLogDir.FullName;
            if (lot.Length > 0)
            {
                folder = Log.ProcessLogDir.FullName + $"{lot}\\";
                Directory.CreateDirectory(folder);
            }
            GLog.WriteLog(folder + fName + ".log", content);

            return true;
        }
    }

    class GControl
    {
        public static IEnumerable<Control> GetChildItems(Control control, params Type[] ctrls)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SkipWhile(x => x is Form)
                .SelectMany(c => GetChildItems(c, ctrls))
                .Concat(controls)
                .Where(c => ctrls.Length is 0 || ctrls.Contains(c.GetType()));
        }
        public static IEnumerable<ToolStripItem> GetToolStripItems(ToolStrip ts)
        {
            var tsitems = ts.Items.Cast<ToolStripItem>();

            return tsitems.SelectMany(x => GetToolStripItems(x)).Concat(tsitems);

            IEnumerable<ToolStripItem> GetToolStripItems(ToolStripItem tsi)
            {
                IEnumerable<ToolStripItem> tsicollection = null;
                switch (tsi)
                {
                    case ToolStripDropDownButton tsddbtn:
                        tsicollection = tsddbtn.DropDownItems.Cast<ToolStripItem>();
                        return tsicollection.SelectMany(t => GetToolStripItems(t)).Concat(tsicollection);

                    case ToolStripMenuItem tsmi:
                        tsicollection = tsmi.DropDownItems.Cast<ToolStripItem>();
                        return tsicollection.SelectMany(t => GetToolStripItems(t)).Concat(tsicollection);

                    default: return new List<ToolStripItem>();
                }
            }
        }

        static Type[] UpdateCtrlTypes = new Type[]
        {
            typeof(Form),
            typeof(UserControl),
            typeof(Label),
            typeof(Button),
            typeof(CheckBox),
            typeof(Panel),
            typeof(ComboBox),
            typeof(GroupBox),
            typeof(ToolStrip),
            typeof(StatusStrip),
            typeof(ListView),
            typeof(TabPage),
            typeof(SplitterPanel),
            typeof(ToolStripButton)
        };
        static void Save(TEDisplay configUI)
        {
            IIniFile iniFile = new IIniFile(GDefine.DataDir.FullName + "Display\\" + configUI.FrmName + ".ini");
            iniFile.Write(configUI.CtrlName, nameof(TEDisplay), new bool[] {
                configUI.NoneDisable,
                configUI.OperDisable,
                configUI.TechDisable,
                configUI.EngrDisable});
        }
        static void Load(TEDisplay configUI)
        {
            IIniFile iniFile = new IIniFile(GDefine.DataDir.FullName + "Display\\" + configUI.FrmName + ".ini");
            bool[] a = new bool[] {
                configUI.NoneDisable,
                configUI.OperDisable,
                configUI.TechDisable,
                configUI.EngrDisable }; 
            var dd = iniFile.ReadBoolArray(configUI.CtrlName, nameof(TEDisplay), ref a);

            configUI.NoneDisable = a[0];
            configUI.OperDisable = a[1];
            configUI.TechDisable = a[2];
            configUI.EngrDisable = a[3];
        }
        public static void UpdateFormControl(Form frm)
        {
            GetChildItems(frm, UpdateCtrlTypes).ToList().ForEach(ctrl =>
            {
                if (ctrl is ToolStrip)
                {
                    GetToolStripItems(ctrl as ToolStrip).ToList().ForEach(tsitem =>
                    {
                        #region

                        var configUIts = new TEDisplay(frm.Name, tsitem.Name);
                        Load(configUIts);

                        switch ((ELevel)NUtils.UserAcc.Active.GroupID)
                        {
                            case ELevel.None:
                                tsitem.Enabled = !configUIts.NoneDisable;
                                break;
                            case ELevel.Operator:
                                tsitem.Enabled = !configUIts.OperDisable;
                                break;
                            case ELevel.Technician:
                                tsitem.Enabled = !configUIts.TechDisable;
                                break;
                            case ELevel.Engineer:
                                tsitem.Enabled = !configUIts.EngrDisable;
                                break;
                            default:
                            case ELevel.Admin:
                                tsitem.Enabled = true;
                                break;
                        }

                        tsitem.MouseDown -= Target_MouseDown;
                        tsitem.MouseDown += Target_MouseDown;
                        #endregion
                    });

                    return; //return to block toolstrip as UI
                }

                #region

                var configUI = new TEDisplay(frm.Name, ctrl.Name);
                Load(configUI);

                frm.Invoke(new Action(() =>
                {
                    switch ((ELevel)NUtils.UserAcc.Active.GroupID)
                    {
                        case ELevel.None:
                            ctrl.Enabled = !configUI.NoneDisable;
                            break;
                        case ELevel.Operator:
                            ctrl.Enabled = !configUI.OperDisable;
                            break;
                        case ELevel.Technician:
                            ctrl.Enabled = !configUI.TechDisable;
                            break;
                        case ELevel.Engineer:
                            ctrl.Enabled = !configUI.EngrDisable;
                            break;
                        default:
                        case ELevel.Admin:
                            ctrl.Enabled = true;
                            break;
                    }
                }));

                ctrl.MouseDown -= Target_MouseDown;
                ctrl.MouseDown += Target_MouseDown;
                #endregion
            });
        }
        static void Target_MouseDown(object sender, MouseEventArgs e)
        {
            if (NUtils.UserAcc.Active.GroupID < (int)ELevel.Admin) return;

            if (e.Button == MouseButtons.Left) return;

            if (Control.ModifierKeys != Keys.Shift) return;

            switch (sender)
            {
                case Control ctrl:
                    {
                        if (ctrl.Name.Contains("Login")) return;

                        TEDisplay configUI = new TEDisplay(ctrl.FindForm().Name, ctrl.Name);
                        Load(configUI);

                        ctrl.Enabled = false;

                        ShowCMS(configUI, ctrl.GetType().Name, $"Text: {ctrl.Text}", (a, b) =>
                        {
                            ctrl.Enabled = true;
                            Save(configUI);
                        });
                    }
                    break;
                case ToolStripItem tsitem:
                    {
                        if (tsitem.Name.Contains("Login")) return;

                        TEDisplay configUI = new TEDisplay(tsitem.Owner.FindForm().Name, tsitem.Name);
                        Load(configUI);

                        tsitem.Enabled = false;

                        ShowCMS(configUI, tsitem.GetType().Name, $"Text: {tsitem.Text}", (a, b) =>
                        {
                            tsitem.Enabled = true;
                            Save(configUI);
                        });
                    }
                    break;
            }
            #region cms
            void ShowCMS(TEDisplay configUI, string type, string text, ToolStripDropDownClosingEventHandler closing_event)
            {
                Size size = new Size(160, 23);
                ContextMenuStrip cms = new ContextMenuStrip();

                ToolStripItem[] tslist = new ToolStripItem[]
                {
                    new ToolStripLabel("Control Access") { ForeColor = Color.Navy, Font = new Font("Tahoma", 9, FontStyle.Bold) },
                    new ToolStripLabel(type) { ForeColor = Color.Navy },
                    new ToolStripLabel(text) { ForeColor = Color.Navy },
                    new ToolStripSeparator(),
                    new ToolStripLabel("Disable Access for") { ForeColor = Color.Navy, Font = new Font("Tahoma", 9, FontStyle.Bold) },
                    new ToolStripButton("None", null, (a, b) => configUI.NoneDisable = (a as ToolStripButton).Checked) { CheckOnClick = true, Checked = configUI.NoneDisable, Size = size },
                    new ToolStripButton("Operator", null, (a, b) => configUI.OperDisable = (a as ToolStripButton).Checked) { CheckOnClick = true, Checked = configUI.OperDisable, Size = size },
                    new ToolStripButton("Technician", null, (a, b) => configUI.TechDisable = (a as ToolStripButton).Checked) { CheckOnClick = true, Checked = configUI.TechDisable, Size = size },
                    new ToolStripButton("Engineer", null, (a, b) => configUI.EngrDisable = (a as ToolStripButton).Checked) { CheckOnClick = true, Checked = configUI.EngrDisable, Size = size },
                    new ToolStripSeparator(),
                    new ToolStripLabel("Preview UI Mode"){ ForeColor = Color.Navy, Font = new Font("Tahoma", 9, FontStyle.Bold) },
                    new ToolStripButton(nameof(ELevel.None), null, (a, b) => PreviewMode(ELevel.None)),
                    new ToolStripButton(nameof(ELevel.Operator), null, (a, b) => PreviewMode(ELevel.Operator)),
                    new ToolStripButton(nameof(ELevel.Technician), null, (a, b) => PreviewMode(ELevel.Technician)),
                    new ToolStripButton(nameof(ELevel.Engineer), null, (a, b) => PreviewMode(ELevel.Engineer)),
                };

                cms.Font = new Font("Tahoma", 9);
                cms.Items.AddRange(tslist);
                cms.Click += (a, b) => cms.AutoClose = false;
                cms.MouseLeave += (a, b) => cms.AutoClose = true;
                cms.Closing += closing_event;
                cms.Show(Cursor.Position);

                void PreviewMode(ELevel elevel)
                {
                    cms.Close();
                    var currentuser = (ELevel)NUtils.UserAcc.Active.GroupID;
                    NUtils.UserAcc.Users.User[NUtils.UserAcc.Active.UserIndex].GroupID = (int)elevel;
                    Application.OpenForms.Cast<Form>().ToList().ForEach(x => UpdateFormControl(x));
                    MessageBox.Show($"Exit {elevel} preview mode");
                    NUtils.UserAcc.Users.User[NUtils.UserAcc.Active.UserIndex].GroupID = (int)currentuser;
                    Application.OpenForms.Cast<Form>().ToList().ForEach(x => UpdateFormControl(x));
                }
            }
            #endregion
        }

        public static void LogForm(Form frm)
        {
            GetChildItems(frm).ToList().ForEach(ctrl =>
            {
                switch (ctrl)
                {
                    case Button btn:
                        {
                            btn.MouseDown += (a, b) => Event.CTRL.Set($"{frm.Name},{btn.Name},Clicked", "");
                        }
                        break;
                    case ComboBox combo:
                        {
                            combo.MouseDown += (a, b) => combo.Tag = combo.Text;
                            combo.SelectionChangeCommitted += (a, b) =>
                            {
                                Event.CTRL.Set($"{frm.Name},{combo.Name},{combo.Tag.ToString()} > {combo.SelectedItem.ToString()}", "");
                            };
                        }
                        break;
                    case Label lbl:
                        {
                            lbl.MouseDown += (a, b) => Event.CTRL.Set($"{frm.Name},{lbl.Name}","");
                        }
                        break;
                    case CheckBox checkBox:
                        {
                            checkBox.Click += (a, b) => Event.CTRL.Set($"{frm.Name},{checkBox.Name},{!checkBox.Checked} > {checkBox.Checked}", "");
                        }
                        break;
                    case ToolStrip toolStrip:
                        {
                            GetToolStripItems(toolStrip).ToList().ForEach(y =>
                            {
                                y.MouseDown += (a, b) => Event.CTRL.Set($"{frm.Name},{y.Name}", "");
                            });
                        }
                        break;
                    case PropertyGrid propertyGrid:
                        {
                            propertyGrid.PropertyValueChanged += (a, b) => Event.CTRL.Set($"{b.ChangedItem.PropertyDescriptor.Name}: {b.OldValue} => {b.ChangedItem.Value}", "");
                        }
                        break;
                }
            });
        }
    }

    public class TEDisplay
    {
        public string FrmName;
        public string CtrlName;

        public bool NoneDisable = false;
        public bool OperDisable = false;
        public bool TechDisable = false;
        public bool EngrDisable = false;

        public TEDisplay(string frmName, string ctrlName)
        {
            FrmName = frmName;
            CtrlName = ctrlName;
        }
    }

    public class MsgBox
    {
        public static void Processing(string msg, Action action, Action cancelaction)
        {
            if (Application.OpenForms.Count is 0)
            {
                new frmProcessing(action, cancelaction, msg).ShowDialog();
            }
            else
            {
                Application.OpenForms[0].Invoke(new Action(() => new frmProcessing(action, cancelaction, msg).ShowDialog()));
            }
        }
        public static void Processing(string msg, Action action)
        {
            Processing(msg, action, null);
        }
    }

    public class StrTools
    {
        public static string GetKK(int value)
        {
            int a = value;
            string sa = a.ToString();
            if (a > 1000000)
            { a = a / 1000000; sa = a.ToString() + " kk"; }
            else
            if (a > 1000)
            { a = a / 1000; sa = a.ToString() + " k"; }

            return sa;
        }
    }
}
