using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace NDispWin
{
    public partial class frmAppInfo : Form
    {
        public frmAppInfo()
        {
            InitializeComponent();
            GControl.LogForm(this);

            this.Text = "Application Info";
        }

        private void frmAppInfo_Load(object sender, EventArgs e)
        {
            dgvInfo.Rows.Clear();
            dgvInfo.ColumnCount = 3;

            dgvInfo.Columns[0].Name = "Name";
            dgvInfo.Columns[0].Width = 200;
            dgvInfo.Columns[1].Name = "Version";
            dgvInfo.Columns[1].Width = 100;
            dgvInfo.Columns[2].Name = "Creation Time";
            dgvInfo.Columns[2].Width = 250;

            string[] s_files_exe = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.exe", SearchOption.AllDirectories);
            Array.Sort(s_files_exe);
            foreach (string s in s_files_exe)
            {
                FileVersionInfo V = FileVersionInfo.GetVersionInfo(s);
                int cur_Major = V.FileMajorPart;
                int cur_Minor = V.FileMinorPart;
                int cur_Build = V.FileBuildPart;
                int cur_Revision = V.FilePrivatePart;
                FileInfo F = new FileInfo(s);
                string DllVersion = cur_Major.ToString() + "." + cur_Minor.ToString() + "." + cur_Build.ToString() + "." + cur_Revision.ToString();
                dgvInfo.Rows.Add(Path.GetFileName(s), DllVersion, F.LastWriteTime.ToString());
            }

            string[] s_files_dll = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dll", SearchOption.AllDirectories);
            Array.Sort(s_files_dll);
            foreach (string s in s_files_dll)
            {
                if (Path.GetFileNameWithoutExtension(s).Contains(" ")) continue;

                FileVersionInfo V = FileVersionInfo.GetVersionInfo(s);
                int cur_Major = V.FileMajorPart;
                int cur_Minor = V.FileMinorPart;
                int cur_Build = V.FileBuildPart;
                int cur_Revision = V.FilePrivatePart;
                FileInfo F = new FileInfo(s);
                string DllVersion = cur_Major.ToString() + "." + cur_Minor.ToString() + "." + cur_Build.ToString() + "." + cur_Revision.ToString();
                dgvInfo.Rows.Add(Path.GetFileName(s), DllVersion, F.LastWriteTime.ToString());
            }
        }
    }
}
