using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Management;
using System.Collections;

namespace NDispWin
{
    class External_Intf
    {
    }

    public class TAIO
    {
        Automation.BDaq.ErrorCode ErrCode = Automation.BDaq.ErrorCode.Success;
        Automation.BDaq.InstantAiCtrl m_AiCtrl = new Automation.BDaq.InstantAiCtrl();
        Automation.BDaq.InstantAoCtrl m_AoCtrl = new Automation.BDaq.InstantAoCtrl();

        public TAIO()
        {
            if (SysConfig.FPressAdjType != SysConfig.EFPressAdjType.USB4704) return;

            try
            {
                Connect();
            }
            catch
            {
                MessageBox.Show("AIO Connect failed!", "AIO");
                return;
            }

            if (!m_AiCtrl.Initialized)
            {
                MessageBox.Show("AIO device open failed!", "AIO");
            }
        }

        public void Connect()
        {
            string deviceDescription = "USB-4704,BID#0";
            m_AiCtrl.SelectedDevice = new Automation.BDaq.DeviceInformation(deviceDescription);
            m_AoCtrl.SelectedDevice = new Automation.BDaq.DeviceInformation(deviceDescription);

            if (!m_AiCtrl.Initialized)
            {
                throw new Exception("AIO Connection Error. Device not found.");
            }
        }
        public void Disconnect()
        {
            m_AiCtrl.Dispose();
            m_AoCtrl.Dispose();
        }

        double[] dataAiScaled = new double[2];
        double[] dataAoScaled = new double[2];

        private void Read()
        {
            if (!m_AiCtrl.Initialized)
            {
                try
                {
                    Connect();
                }
                catch
                {
                    return;
                }
            }
            ErrCode = m_AiCtrl.Read(0, 2, dataAiScaled);

            if (ErrCode != Automation.BDaq.ErrorCode.Success) Disconnect();
        }
        private void Write()
        {
            if (!m_AiCtrl.Initialized)
            {
                try
                {
                    Connect();
                }
                catch
                {
                    return;
                }
            }
            ErrCode = m_AoCtrl.Write(0, 2, dataAoScaled);

            if (ErrCode != Automation.BDaq.ErrorCode.Success) Disconnect();
        }

        public void Read(out double[] Value)
        {
            Read();

            Value = new double[] { dataAiScaled[0], dataAiScaled[1] };
        }
        public void Write(double[] Value)
        {
            dataAoScaled[0] = Value[0];
            dataAoScaled[1] = Value[1];

            Write();
        }
    }

    public class TFPress_RS232
    {
        public SerialPort Port = new SerialPort("COM1", 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
        public string PortName = "COM0";
        public TFPress_RS232()
        {
            try
            {
                //Port = new SerialPort("COM1", 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
            }
            catch { };
        }
        public bool IsOpen
        {
            get
            {
                return (Port.IsOpen);
            }
        }
        public bool Open()
        {
            try
            {
                Port.Close();
            }
            catch { };

            Port.Handshake = Handshake.None;

            if (PortName == "COM0") return false;

            try
            {
                Port.PortName = PortName;
                Port.Open();
            }
            catch// (Exception Ex)
            {
                throw;
            }
            return true;
        }
        public bool Open(string PortName)
        {
            this.PortName = PortName;
            return Open();
        }
        public void Close()
        {
            try
            {
                Port.Close();
            }
            catch { };
        }
        System.Threading.Mutex mtx = new System.Threading.Mutex();
        public void WriteLine(String data)
        {
            if (!Port.IsOpen)
            {
                try
                {
                    if (!Open()) return;
                }
                catch
                {
                    return;
                }
            }

            mtx.WaitOne();
            try
            {
                Port.WriteTimeout = 1000;
                Port.Write(data + (char)13 + (char)10);
            }
            catch { throw; }
            finally
            {
                mtx.ReleaseMutex();
            }
        }
        public void ReadLine(ref String data)
        {
            if (!Port.IsOpen)
            {
                try
                {
                    if (!Open()) return;
                }
                catch
                {
                    return;
                }
            }

            mtx.WaitOne();
            try
            {
                Port.DtrEnable = true;
                Port.ReadTimeout = 1000;
                data = Port.ReadLine();
                string d = Port.ReadExisting();
            }
            catch { throw; }
            finally
            {
                mtx.ReleaseMutex();
            }
        }
    }

    class HardDrive
    {
        public string Model { get; set; }
        public string InterfaceType { get; set; }
        public string SerialNo { get; set; }
    }
    static class HDDFunction
    {
        static ArrayList hdCollection = new ArrayList();

        private static void GetAllDiskDrives()
        {
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                HardDrive hd = new HardDrive();
                hd.Model = wmi_HD["Model"].ToString();
                hd.InterfaceType = wmi_HD["InterfaceType"].ToString();
                hd.SerialNo = wmi_HD.GetPropertyValue("SerialNumber").ToString();
                hdCollection.Add(hd);
            }

            searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");

            int i = 0;
            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                // get the hard drive from collection
                // using index
                HardDrive hd = (HardDrive)hdCollection[i];

                // get the hardware serial no.
                if (wmi_HD["SerialNumber"] == null)
                    hd.SerialNo = "None";
                else
                    hd.SerialNo = wmi_HD["SerialNumber"].ToString();

                ++i;
            }
        }

        public static string HDD_SerialNo()
        {
            //GetAllDiskDrives();
            //return ((HardDrive)hdCollection[0]).SerialNo;

            ManagementClass mangnmt = new ManagementClass("Win32_LogicalDisk");
            ManagementObjectCollection mcol = mangnmt.GetInstances();
            string SerialNo = "";
            foreach (ManagementObject strt in mcol)
            {
                if (Convert.ToString(strt["Name"]).Contains("C"))
                    SerialNo = Convert.ToString(strt["VolumeSerialNumber"]);
            }
            return SerialNo;
        }
    }
}
