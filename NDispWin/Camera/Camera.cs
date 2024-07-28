using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Xml;
using System.Reflection;

using Emgu.CV;
using Emgu.CV.Structure;

using SpinnakerNET;
using SpinnakerNET.GenApi;

/* Burn 20190719 15:00 Start App, Live 1 camera. Memory ~73,000k.
 * Stop 20190722 16:30 Memory ~73,000k. No memory increase.
 */

namespace NDispWin
{
    class Camera
    {
    }

    public class ImageEmgu
    {
        // ** Mono
        public Image<Gray, Byte> m_Image = new Image<Gray, byte>(1280, 1024, new Gray(0));
        // ** Color
        //public Image<Bgr, Byte> m_Image = new Image<Bgr, byte>(1280, 1024, new Bgr(0,0,0));
        public ImageEmgu()
        {
            unsafe
            {
                var data = m_Image.Data;
                int stride = m_Image.MIplImage.WidthStep;
                fixed (byte* pData = data)
                {
                    byte* go = pData;
                    for (int j = 0; j < m_Image.MIplImage.Height; j++)
                    {
                        for (int i = 0; i < m_Image.MIplImage.Width; i++)
                        {
                            go[i] = (byte)(i % 255);
                        }
                        go += stride;
                    }
                }
            }
        }

        public void InitColor(int iWidth, int iHeight)
        {
            /*
            // ** Color image
            m_Image = new Image<Bgr, byte>(iWidth, iHeight, new Bgr(0, 0, 0));

            unsafe
            {
                var data = m_Image.Data;
                int stride = m_Image.MIplImage.WidthStep;
                fixed (byte* pData = data)
                {
                    //for (int i = 0; i < 255 * stride; i++)
                    //  *(pData + i) = (byte)(i % stride);
                    byte* go = pData;
                    for (int j = 0; j < m_Image.MIplImage.Height; j++)
                    {
                        for (int i = 0; i < m_Image.MIplImage.Width * 3; i++)
                        {
                            go[i] = (byte)(i % 255);
                            
                            //if (i % 3 == 0)
                              //  go[i] = 255;// B
                            //else
                            //if (i % 3 == 1)
                              //  go[i] = 255;// G
                            //else
                            //if (i % 3 == 2)
                              //  go[i] = 255;// R
                        }
                        go += stride;
                    }
                }
            }
            */
        }
        public void InitMono(int iWidth, int iHeight)
        {
            // ** Mono image
            m_Image = new Image<Gray, byte>(iWidth, iHeight, new Gray(0));
            unsafe
            {
                var data = m_Image.Data;
                int stride = m_Image.MIplImage.WidthStep;
                fixed (byte* pData = data)
                {
                    byte* go = pData;
                    for (int j = 0; j < m_Image.MIplImage.Height; j++)
                    {
                        for (int i = 0; i < m_Image.MIplImage.Width; i++)
                        {
                            go[i] = (byte)(i % 255);
                        }
                        go += stride;
                    }
                }

            }
        }
    }
    public static class SpinnakerCameraSystem//Singleton reference to Spinnaker
    {
        public static ManagedSystem system = null;
        public static IList<IManagedCamera> camList = null;

        public static int CamCount = 0;
        static bool bRunOnce = true;

        public static void Init()
        {
            //if (bRunOnce)
            //{
            //    string Path = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine);

            //    //rename known old emgu paths
            //    string oldEmgu2_4 = "C:\\Emgu\\emgucv-windows-x86 2.4.0.1717";
            //    if (Directory.Exists(oldEmgu2_4))
            //    {
            //        string newEmgu2_4 = "C:\\Emgu\\_emgucv-windows-x86 2.4.0.1717";
            //        Directory.Move(oldEmgu2_4, newEmgu2_4);
            //    }

            //    bool bSet = false;
            //    string s_File = "C:\\Emgu\\emgucv-windows-universal 3.0.0.2157\\bin";
            //    if (!Path.Contains(s_File))
            //    {
            //        Path = Path + ";" + s_File;
            //        bSet = true;
            //    }
            //    s_File = "C:\\Emgu\\emgucv-windows-universal 3.0.0.2157\\bin\\x86";
            //    if (!Path.Contains(s_File))
            //    {
            //        Path = Path + ";" + s_File;
            //        bSet = true;
            //    }

            //    if (bSet) Environment.SetEnvironmentVariable("Path", Path, EnvironmentVariableTarget.Machine);

            //    bRunOnce = false;
            //}

            if (system == null)
            {
                system = new SpinnakerNET.ManagedSystem();
                camList = system.GetCameras();
                CamCount = camList.Count;
            }
        }

        public static void DeInit()
        {
            if (system != null)
            {
                if (camList != null) camList.Clear();
                system.Dispose();
                system = null;
            }
            CamCount = 0;
        }
    }
    public class FlirCamera
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDllDirectory(string lpPathName);   

        IManagedCamera m_Camera = null;

        public int m_iCamWidthMax = 1280;
        public int m_iCamHeightMax = 1024;
        public int m_iCamWidth = 1280;
        public int m_iCamHeight = 1024;
        public bool m_isConnected = false;
        public bool m_isGrabbing = false;
        public double m_dFPS = 0;
        Task taskGrab = null;

        public bool m_isTrigMode = false;
        public bool m_isHardware = false;
        public ulong m_grabTimeOut = 500;

        public Emgu.CV.UI.ImageBox imgBoxEmgu;
        public ImageEmgu m_ImageEmgu = new ImageEmgu();
        ManagedImage m_imageMono = new ManagedImage();

        public FlirCamera()
        {
            if (SpinnakerCameraSystem.system == null) SpinnakerCameraSystem.Init();
        }

        public void SetImageData(ImageEmgu pImagerEmgu)
        {
            if (m_Camera == null)
                return;

            unsafe
            {
                var data = pImagerEmgu.m_Image.Data;
                int stride = pImagerEmgu.m_Image.MIplImage.WidthStep;
                fixed (void* pData = data)
                {
                    m_imageMono.ResetImage((uint)pImagerEmgu.m_Image.Width, (uint)pImagerEmgu.m_Image.Height, 0, 0, PixelFormatEnums.Mono8, pData);
                }
            }
        }
        public void Connect(int index)
        {
            //if (SpinnakerCameraSystem.system == null) 
            SpinnakerCameraSystem.DeInit();
            SpinnakerCameraSystem.Init();

            if (index > SpinnakerCameraSystem.camList.Count) throw new Exception("Invalid Camera Index.");

            try
            {
                int iIndex = 0;
                foreach (IManagedCamera managedCamera in SpinnakerCameraSystem.camList)
                {
                    // ** use index without using serial number
                    if (iIndex == index)
                    {
                        m_Camera = managedCamera;
                        m_Camera.Init();

                        m_iCamWidthMax = (int)m_Camera.WidthMax;
                        m_iCamHeightMax = (int)m_Camera.HeightMax;
                        m_iCamWidth = (int)m_Camera.Width;
                        m_iCamHeight = (int)m_Camera.Height;

                        m_isConnected = true;

                        string strPixelFormat = m_Camera.PixelFormat.ToString();

                        INodeMap nodeMap = m_Camera.GetNodeMap();

                        //  acquisition continuous mode
                        m_Camera.AcquisitionMode.Value = AcquisitionModeEnums.Continuous.ToString();

                        //  trigger enabled
                        //m_Camera.TriggerMode.Value = TriggerModeEnums.On.ToString();

                        //  software trigger
                        m_Camera.TriggerSource.Value = TriggerSourceEnums.Software.ToString();

                        //  select hardware trigger line
                        m_Camera.LineSelector.Value = LineSelectorEnums.Line0.ToString();

                        break;
                    }
                    iIndex++;
                }

                if (!m_isConnected) throw new Exception("Camera Connect Fail.");

                m_ImageEmgu.InitMono(this.m_iCamWidth, this.m_iCamHeight);
                SetImageData(m_ImageEmgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Connect Connect Exception Error. " + ex.Message.ToString());
            }
        }
        public void Connect(string ipAddress)
        {
            int iIndex = 0;
            foreach (IManagedCamera managedCamera in SpinnakerCameraSystem.camList)
            {
                Integer iIPAddress = managedCamera.TLDevice.GevDeviceIPAddress;
                string sIPAddress = ((iIPAddress >> 24) & 0xFF) + "." + ((iIPAddress >> 16) & 0xFF) + "." + ((iIPAddress >> 8) & 0xFF) + "." + (iIPAddress & 0xFF);

                if (sIPAddress == ipAddress)
                {
                    Connect(iIndex);
                    break;
                }

                iIndex++;
            }
            if (!m_isConnected) throw new Exception("Camera Not Found.");
        }
        public void DisConnect()
        {
            if (m_Camera == null) return;

            if (m_isGrabbing)
            {
                m_isGrabbing = false;

                if (taskGrab != null && !taskGrab.IsCompleted)
                {
                    Task.WaitAll(taskGrab);
                }
            }

            try
            {
                if (m_Camera.IsStreaming()) m_Camera.EndAcquisition();

                m_Camera.DeInit();
                m_isConnected = false;
            }
            catch (Exception ex)
            {
                Event.DEBUG_INFO.Set($"Camera {MethodBase.GetCurrentMethod().Name}", ex.Message.ToString());
            }
        }
        public bool IsConnected
        {
            get
            {
                if (m_Camera == null) return false;
                return this.m_isConnected;
            }
        }
        public bool IsGrabbing()
        {
            if (m_Camera == null) return false;
            return this.m_isGrabbing;
        }

        public bool NoStopGrab = false;
        public bool TestEx = false;
        private bool GetFrame(ulong timeOut)//ms
        {
            bool bStatus = true;
            try
            {
                if (TestEx)
                {
                    TestEx = false;
                    throw new Exception("Test Exception.");
                }
                using (IManagedImage rawImage = m_Camera.GetNextImage(timeOut))
                {
                    if (rawImage.IsIncomplete)
                    {
                        //Debug.WriteLine("Image incomplete with image status {0}...", rawImage.ImageStatus);
                        //Event.DEBUG_INFO.Set( "Camera Image Incomplete {0}...", rawImage.ImageStatus.ToString());
                        Event.DEBUG_INFO.Set($"Camera {MethodBase.GetCurrentMethod().Name} Image Incomplete...", rawImage.ImageStatus.ToString());
                        bStatus = false;
                    }
                    else
                    if (rawImage.ImageStatus == ImageStatus.IMAGE_NO_ERROR)
                        // Convert image to mono 8
                        using (IManagedImage convertedImage = rawImage.Convert(PixelFormatEnums.Mono8))
                        {
                            unsafe
                            {
                                byte* data = m_imageMono.NativeData;
                                byte* dataSource = convertedImage.NativeData;

                                IntPtr[] source = new IntPtr[m_imageMono.Height];
                                IntPtr[] dest = new IntPtr[m_imageMono.Height];
                                Parallel.For(0, m_imageMono.Height, y =>
                                {
                                    source[y] = (IntPtr)(dataSource + (convertedImage.Stride * y));
                                    dest[y] = (IntPtr)(data + (m_imageMono.Stride * y));
                                });
                                Parallel.For(0, m_imageMono.Height, y =>
                                {
                                    Buffer.MemoryCopy(source[y].ToPointer(), dest[y].ToPointer(), m_imageMono.Width, m_imageMono.Width);
                                });
                            }
                        }
                    else
                    {
                        Thread.Sleep(15);
                        //    Debug.WriteLine($"Error: {rawImage.ImageStatus}");
                        bStatus = false;
                    }
                }
            }
            catch (Exception ex)
            {
                if (!NoStopGrab)
                {
                    m_isGrabbing = false;
                    Event.DEBUG_INFO.Set($"Camera {MethodBase.GetCurrentMethod().Name}", "set IsGrab false");
                }
                Event.DEBUG_INFO.Set($"Camera {MethodBase.GetCurrentMethod().Name}", ex.Message.ToString());
                Thread.Sleep(15);
                bStatus = false;
            }

            return bStatus;
        }
        public bool Snap()
        {
            if (m_Camera == null) return false;
            if (m_isGrabbing) GrabStop();

            try
            {
                if (!m_Camera.IsStreaming()) m_Camera.BeginAcquisition();

                //  **  Set to software trigger source
                m_Camera.TriggerSource.Value = TriggerSourceEnums.Software.ToString();

                if (m_Camera.TriggerMode.Value == TriggerModeEnums.On.ToString())
                    m_Camera.TriggerSoftware.Execute();

                GetFrame(500);

                if (m_Camera.IsStreaming()) m_Camera.EndAcquisition();
            }
            catch (Exception ex)
            {
                string msg = $"Camera Snap Error " + ex.Message.ToString();
                System.Windows.Forms.MessageBox.Show(msg);
                Event.DEBUG_INFO.Set(msg, "");
                return false;
            }

            if (imgBoxEmgu != null) imgBoxEmgu.Invalidate();

            return true;
        }
        private void TaskGrab()
        {
            bool bStatus = false;
            Stopwatch swSnap = new Stopwatch();
            int iCountFPS = 0;

            while (m_isGrabbing)
            {
                if (iCountFPS >= 25)
                {
                    swSnap.Restart();
                    iCountFPS = 0;
                }
                else
                    swSnap.Start();
                iCountFPS++;

                bStatus = GetFrame(m_grabTimeOut);
                
                swSnap.Stop();

                if (iCountFPS >= 25) m_dFPS = (1000.0 / swSnap.ElapsedMilliseconds) * iCountFPS;

                if (bStatus) if (imgBoxEmgu != null) imgBoxEmgu.Invalidate();
            }
        }
        public bool Grab(uint TimeOut)//grab according to TriggerMode
        {
            if (m_Camera == null) return false;
            if (!m_Camera.IsInitialized()) return false;
            if (m_isGrabbing) return true;

            try
            {
                if (!m_Camera.IsStreaming())
                {
                    m_Camera.BeginAcquisition();
                    m_isGrabbing = true;
                }
            }
            catch (Exception ex)
            {
                Event.DEBUG_INFO.Set($"Camera {MethodBase.GetCurrentMethod().Name}", ex.Message.ToString());
                return false;
            }

            m_grabTimeOut = TimeOut;
            taskGrab = new Task(new Action(TaskGrab));
            taskGrab.Start();

            return true;
        }
        public bool Grab()//grab according to TriggerMode
        {
            return Grab(500);
        }
        public void GrabOne(uint TimeOut)//grab 1 frame according to TriggerMode
        {
            if (m_Camera == null) return;
            if (!m_Camera.IsInitialized()) return;
            if (m_isGrabbing) return;

            try
            {
                if (!m_Camera.IsStreaming())
                {
                    m_Camera.BeginAcquisition();
                    m_isGrabbing = true;
                }
            }
            catch (Exception ex)
            {
                Event.DEBUG_INFO.Set($"Camera {MethodBase.GetCurrentMethod().Name}", ex.Message.ToString());
            }

            bool bStatus = GetFrame(TimeOut);
            m_isGrabbing = false;
        }
        public void GrabCont()//continuous grab
        {
            if (m_Camera == null) return;
            if (!m_Camera.IsInitialized()) return;
            if (m_isGrabbing) return;

            try
            {
                m_Camera.TriggerMode.Value = TriggerModeEnums.Off.ToString();
            }
            catch (Exception ex)
            {
                Event.DEBUG_INFO.Set($"Camera {MethodBase.GetCurrentMethod().Name}", ex.Message.ToString());
            }

            m_grabTimeOut = 500;
            Grab();
        }
        public void GrabStop()
        {
            if (m_Camera == null) return;

            m_isGrabbing = false;
            m_isTrigMode = false;

            if (taskGrab != null && taskGrab.Status == TaskStatus.Running)
            {
                Task.WaitAll(taskGrab);
            }

            try
            {
                if (m_Camera.IsStreaming()) m_Camera.EndAcquisition();
            }
            catch (Exception ex)
            {
                Event.DEBUG_INFO.Set($"Camera {MethodBase.GetCurrentMethod().Name}", ex.Message.ToString());
            }
        }
        public bool TriggerMode
        {
            set
            {
                if (m_Camera == null) return;
                if (!m_Camera.IsInitialized()) return;

                try
                {
                    m_Camera.TriggerMode.Value = value ? TriggerModeEnums.On.ToString() : TriggerModeEnums.Off.ToString();
                    m_isTrigMode = value;
                }
                catch (Exception ex)
                {
                    Event.DEBUG_INFO.Set($"Camera {MethodBase.GetCurrentMethod().Name}", ex.Message.ToString());
                }
            }
        }

        public bool TriggerSourceHw
        {
            set
            {
                if (m_Camera == null) return;
                if (!m_Camera.IsInitialized()) return;

                try
                {
                    m_Camera.TriggerSource.Value = TriggerSourceEnums.Line0.ToString();
                    m_isHardware = true;
                }
                catch (Exception ex)
                {
                    Event.DEBUG_INFO.Set($"Camera {MethodBase.GetCurrentMethod().Name}", ex.Message.ToString());
                }
            }
        }

        public bool TriggerSourceSw
        {
            set
            {
                if (m_Camera == null) return;
                if (!m_Camera.IsInitialized()) return;

                try
                {
                    m_Camera.TriggerSource.Value = TriggerSourceEnums.Software.ToString();
                    m_isHardware = false;
                }
                catch (Exception ex)
                {
                    Event.DEBUG_INFO.Set($"Camera {MethodBase.GetCurrentMethod().Name}", ex.Message.ToString());
                }
            }
        }

        public void SoftwareTrigger()
        {
            Grab(5000);
            try
            {
                if (m_Camera.TriggerSoftware.IsWritable) m_Camera.TriggerSoftware.Execute();
            }
            catch (Exception ex)
            {
                Event.DEBUG_INFO.Set($"Camera {MethodBase.GetCurrentMethod().Name}", ex.Message.ToString());
            }
        }

        #region Properties
        public double Exposure//ns
        {
            //get
            //{
            //    try
            //    {
            //        return m_Camera.ExposureTime.Value;
            //    }
            //    catch (Exception ex)
            //    {
            //        Event.DEBUG_INFO.Set($"Camera Exposure", ex.Message.ToString());
            //    }
            //}
            set
            {
                try
                {
                    if (m_Camera.ExposureAuto.IsWritable)
                        m_Camera.ExposureAuto.Value = ExposureAutoEnums.Off.ToString();

                    m_Camera.ExposureMode.Value = ExposureModeEnums.Timed.ToString();
                    double dToSet = value > m_Camera.ExposureTime.Max ? m_Camera.ExposureTime.Max : value;
                    dToSet = dToSet < m_Camera.ExposureTime.Min ? m_Camera.ExposureTime.Min : value;
                    m_Camera.ExposureTime.Value = dToSet;
                }
                catch (Exception ex)
                {
                    Event.DEBUG_INFO.Set($"Camera {MethodBase.GetCurrentMethod().Name}", ex.Message.ToString());
                }
            }
        }
        public bool ExposureAuto
        {
            set
            {
                try
                {
                    if (m_Camera.ExposureAuto.IsWritable)
                        m_Camera.ExposureAuto.Value = value ? ExposureAutoEnums.Continuous.ToString() : ExposureAutoEnums.Off.ToString();
                }
                catch (Exception ex)
                {
                    Event.DEBUG_INFO.Set($"Camera {MethodBase.GetCurrentMethod().Name}", ex.Message.ToString());
                }
            }
            get
            {
                return m_Camera.ExposureAuto.Value == ExposureAutoEnums.Continuous.ToString();
            }
        }

        public double Gain//Gain_dB
        {
            get
            {
                return m_Camera.Gain.Value;
            }
            set
            {
                try
                {
                    m_Camera.GainAuto.Value = GainAutoEnums.Off.ToString();
                    double dToSet = value > m_Camera.Gain.Max ? m_Camera.Gain.Max : value;
                    dToSet = dToSet < m_Camera.Gain.Min ? m_Camera.Gain.Min : dToSet;
                    m_Camera.Gain.Value = dToSet;
                }
                catch (Exception ex)
                {
                    Event.DEBUG_INFO.Set($"Camera {MethodBase.GetCurrentMethod().Name}", ex.Message.ToString());
                }
            }
        }
        public bool GainAuto
        {
            get
            {
                return m_Camera.GainAuto.Value == GainAutoEnums.Continuous.ToString();
            }
            set
            {
                try
                {
                    m_Camera.GainAuto.Value = value ? GainAutoEnums.Continuous.ToString() : GainAutoEnums.Off.ToString();
                }
                catch (Exception ex)
                {
                    Event.DEBUG_INFO.Set($"Camera {MethodBase.GetCurrentMethod().Name}", ex.Message.ToString());
                }
            }
        }
   
        public int ImageWidth
        {
            get
            {
                return (int)m_Camera.Width.Value;
            }
            set
            {
                if (m_Camera == null) return;

                bool bWasStreaming = m_Camera.IsStreaming();
                GrabStop();

                if (value < 0)
                    m_Camera.Width.Value = m_Camera.Width.Max;
                else
                {
                    long lWidth = (long)value;
                    lWidth = lWidth > m_Camera.Width.Max ? m_Camera.Width.Max : lWidth;
                    lWidth = lWidth < m_Camera.Width.Min ? m_Camera.Width.Min : lWidth;
                    lWidth = (int)Math.Ceiling((double)lWidth / m_Camera.Width.Increment) * m_Camera.Width.Increment;
                    m_Camera.Width.Value = lWidth;
                }

                m_ImageEmgu.InitMono(this.ImageWidth, this.ImageHeight);
                if (imgBoxEmgu != null) imgBoxEmgu.Image = m_ImageEmgu.m_Image;
                SetImageData(m_ImageEmgu);

                if (bWasStreaming) Grab();
            }
        }
        public int ImageHeight
        {
            get
            {
                return (int)m_Camera.Height.Value;
            }
            set
            {
                if (m_Camera == null) return;

                bool bWasStreaming = m_Camera.IsStreaming();
                GrabStop();

                if (value < 0)
                    m_Camera.Height.Value = m_Camera.Height.Max;
                else
                {
                    long lHeight = (long)value;
                    lHeight = ImageHeight > m_Camera.Height.Max ? m_Camera.Height.Max : lHeight;
                    lHeight = ImageHeight < m_Camera.Height.Min ? m_Camera.Height.Min : lHeight;
                    lHeight = (int)Math.Ceiling((double)lHeight / m_Camera.Height.Increment) * m_Camera.Height.Increment;
                    m_Camera.Height.Value = lHeight;
                }

                m_ImageEmgu.InitMono(this.ImageWidth, this.ImageHeight);
                if (imgBoxEmgu != null) imgBoxEmgu.Image = m_ImageEmgu.m_Image;
                SetImageData(m_ImageEmgu);

                if (bWasStreaming) Grab();
            }
        }
        public int OffsetX
        {
            get
            {
                return (int)m_Camera.OffsetX.Value;
            }
            set
            {
                if (m_Camera == null) return;

                bool bWasStreaming = m_Camera.IsStreaming();
                GrabStop();

                long lOffsetX = (long)value;
                lOffsetX = lOffsetX > m_Camera.OffsetX.Max ? m_Camera.OffsetX.Max : lOffsetX;
                lOffsetX = lOffsetX < m_Camera.OffsetX.Min ? m_Camera.OffsetX.Min : lOffsetX;
                m_Camera.OffsetX.Value = lOffsetX;

                //m_ImageEmgu.InitMono(this.ImageWidth, this.ImageHeight);
                if (imgBoxEmgu != null) imgBoxEmgu.Image = m_ImageEmgu.m_Image;
                SetImageData(m_ImageEmgu);

                if (bWasStreaming) Grab();
            }
        }
        public int OffsetY
        {
            get
            {
                return (int)m_Camera.OffsetY.Value;
            }
            set
            {
                if (m_Camera == null) return;

                bool bWasStreaming = m_Camera.IsStreaming();
                GrabStop();

                long lOffsetY = (long)value;
                lOffsetY = lOffsetY > m_Camera.OffsetY.Max ? m_Camera.OffsetY.Max : lOffsetY;
                lOffsetY = lOffsetY < m_Camera.OffsetY.Min ? m_Camera.OffsetY.Min : lOffsetY;
                m_Camera.OffsetY.Value = lOffsetY;

                if (imgBoxEmgu != null) imgBoxEmgu.Image = m_ImageEmgu.m_Image;
                SetImageData(m_ImageEmgu);

                if (bWasStreaming) Grab();
            }
        }
        #endregion
    }

    public class TReticle2
    {
        public enum EType
        {
            None = 0,
            CenterCross = 1,
            CenterCross3 = 7,
            CenterCross50u = 8,
            CenterCross100u = 9,
            //CenterReticle,
            Line = 2,
            Cross = 3,
            Circle = 4,
            Rectangle = 5,
            Text = 6
        }
        public EType Type;
        public PointF Location;
        public SizeF Size;
        public string Text;
        public Color Color;

        public TReticle2()
        {
            this.Type = EType.None;
            this.Location = new PointF(0, 0);
            this.Size = new SizeF(0, 0);
            this.Text = "";
            this.Color = Color.Yellow;
        }
        public TReticle2(TReticle2 Reticle)
        {
            this.Type = Reticle.Type;
            this.Location = Reticle.Location;
            this.Size = Reticle.Size;
            this.Text = Reticle.Text;
            this.Color = Reticle.Color;
        }
        public TReticle2(EType Type, PointF Location, SizeF Size, Color Color, string Text = "")
        {
            this.Type = Type;
            this.Location = Location;
            this.Size = Size;
            this.Text = Text;
            this.Color = Color;
        }
    }
    public class TReticles
    {
        public const int MAX_RETICLES = 10;
        public TReticle2[] Reticle = new TReticle2[MAX_RETICLES];

        public TReticles()
        {
            for (int i = 0; i < MAX_RETICLES; i++)
            {
                Reticle[i] = new TReticle2();
            }
        }

        public TReticles(TReticles reticles)
        {
            for (int i = 0; i < MAX_RETICLES; i++)
            {
                this.Reticle[i] = new TReticle2(reticles.Reticle[i]);
            }
        }

        public void Clear()
        {
            for (int i = 0; i < MAX_RETICLES; i++)
            {
                Reticle[i].Type = TReticle2.EType.None;
            }
        }
    }
    public static class Reticle
    {
        const int Max_Reticle = 4;
        public static TReticles[] Reticles = new TReticles[Max_Reticle] { new TReticles(), new TReticles(), new TReticles(), new TReticles() };
        public static void SaveCamReticles(string FullFilename)
        {
            if (Path.GetExtension(FullFilename).Length == 0) FullFilename = FullFilename + ".ini";

            List<string> Lines = new List<string>();

            for (int i = 0; i < Max_Reticle; i++)
            {
                for (int j = 0; j < TReticles.MAX_RETICLES; j++)
                {
                    string Line = "Group," + i.ToString() + (char)9 + "No," + j.ToString() + (char)9;
                    Line = Line + "Type," + ((int)Reticles[i].Reticle[j].Type).ToString() + (char)9 +
                    "Location," + Reticles[i].Reticle[j].Location.X.ToString() + "," + Reticles[i].Reticle[j].Location.Y.ToString() + (char)9 +
                    "Size," + Reticles[i].Reticle[j].Size.Width.ToString() + "," + Reticles[i].Reticle[j].Size.Height.ToString() + (char)9 +
                    "Text," + Reticles[i].Reticle[j].Text + (char)9 +
                    "Color," + Reticles[i].Reticle[j].Color.ToArgb().ToString();
                    Lines.Add(Line);
                }
            }
            System.IO.File.WriteAllLines(FullFilename, Lines);
        }
        public static void LoadCamReticles(string FullFilename)
        {
            for (int i = 0; i < Max_Reticle; i++)
            {
                for (int j = 0; j < TReticles.MAX_RETICLES; j++)
                {
                    Reticles[i].Reticle[j] = new TReticle2();
                }
            }

            if (!File.Exists(FullFilename)) return;

            string[] Lines = System.IO.File.ReadAllLines(FullFilename);
            for (int x = 0; x < Lines.Length; x++)
            {
                int iGroup = 0;
                int iNo = 0;
                string[] L = Lines[x].Split((char)9);

                TReticle2 reticle = new TReticle2();
                for (int i = 0; i < L.Count(); i++)
                {
                    if (L[i].StartsWith("Group"))
                    {
                        string[] l = L[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            iGroup = Convert.ToInt32(l[1]);
                        }
                        catch { }
                    }
                    if (L[i].StartsWith("No"))
                    {
                        string[] l = L[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            iNo = Convert.ToInt32(l[1]);
                        }
                        catch { }
                    }
                    if (L[i].StartsWith("Type"))
                    {
                        string[] l = L[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            int t = Convert.ToInt32(l[1]);
                            reticle.Type = (TReticle2.EType)t;
                        }
                        catch { }
                    }
                    if (L[i].StartsWith("Location"))
                    {
                        string[] l = L[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            reticle.Location.X = (float)Convert.ToDouble(l[1]);
                            reticle.Location.Y = (float)Convert.ToDouble(l[2]);
                        }
                        catch { }
                    }
                    if (L[i].StartsWith("Size"))
                    {
                        string[] l = L[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            reticle.Size.Width = (float)Convert.ToDouble(l[1]);
                            reticle.Size.Height = (float)Convert.ToDouble(l[2]);
                        }
                        catch { }
                    }
                    if (L[i].StartsWith("Para"))
                    {
                        string[] l = L[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                        try
                        {
                            //reticle.Para.Clear();
                            //for (int p = 1; p < l.Count(); p++)
                            //{
                            //    reticle.Para.Add((float)Convert.ToDouble(l[p]));
                            //}
                        }
                        catch { };
                    }
                    if (L[i].StartsWith("Text"))
                    {
                        string[] l = L[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        if (l.Count() > 1) reticle.Text = l[1];
                    }
                    if (L[i].StartsWith("Color"))
                    {
                        string[] l = L[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            int c = Convert.ToInt32(l[1]);
                            reticle.Color = Color.FromArgb(c);
                        }
                        catch { }
                    }
                }

                Reticles[iGroup].Reticle[iNo] = reticle;
            }
        }
        public static void saveCamReticlesXML(string fileName, string root, string chapter)
        {
            NUtils.XmlFile xmlFile = new NUtils.XmlFile(fileName, root);

            xmlFile.Open();

            try
            {
                for (int i = 0; i < Max_Reticle; i++)
                {
                    int[] intType = new int[TReticles.MAX_RETICLES];
                    double[] dX = new double[TReticles.MAX_RETICLES];
                    double[] dY = new double[TReticles.MAX_RETICLES];
                    double[] dW = new double[TReticles.MAX_RETICLES];
                    double[] dH = new double[TReticles.MAX_RETICLES];
                    string[] Text = new string[TReticles.MAX_RETICLES];
                    int[] Color = new int[TReticles.MAX_RETICLES];
                    for (int j = 0; j < TReticles.MAX_RETICLES; j++)
                    {
                        intType[j] = (int)Reticles[i].Reticle[j].Type;

                        dX[j] = Reticles[i].Reticle[j].Location.X;
                        dY[j] = Reticles[i].Reticle[j].Location.Y;
                        dW[j] = Reticles[i].Reticle[j].Size.Width;
                        dH[j] = Reticles[i].Reticle[j].Size.Height;

                        Text[j] = Reticles[i].Reticle[j].Text;
                        Color[j] = Reticles[i].Reticle[j].Color.ToArgb();
                    }
                    xmlFile.SetValue(chapter, "Camera" + i.ToString(), "Reticle", "Type", intType);

                    xmlFile.SetValue(chapter, "Camera" + i.ToString(), "Reticle", "X", dX);
                    xmlFile.SetValue(chapter, "Camera" + i.ToString(), "Reticle", "Y", dY);
                    xmlFile.SetValue(chapter, "Camera" + i.ToString(), "Reticle", "W", dW);
                    xmlFile.SetValue(chapter, "Camera" + i.ToString(), "Reticle", "H", dH);

                    xmlFile.SetValue(chapter, "Camera" + i.ToString(), "Reticle", "Text", Text);
                    xmlFile.SetValue(chapter, "Camera" + i.ToString(), "Reticle", "Color", Color);
                }
            }
            finally
            {
                xmlFile.Save();
            }
        }
        public static void loadCamReticlesXML(string fileName, string root, string chapter)
        {
            NUtils.XmlFile xmlFile = new NUtils.XmlFile(fileName, root);

            xmlFile.Open();

            try
            {
                for (int i = 0; i < Max_Reticle; i++)
                {
                    int[] intType = new int[TReticles.MAX_RETICLES];
                    intType = xmlFile.GetValue(chapter, "Camera" + i.ToString(), "Reticle", "Type", intType);
                    double[] dX = new double[TReticles.MAX_RETICLES];
                    dX = xmlFile.GetValue(chapter, "Camera" + i.ToString(), "Reticle", "X", dX);
                    double[] dY = new double[TReticles.MAX_RETICLES];
                    dY = xmlFile.GetValue(chapter, "Camera" + i.ToString(), "Reticle", "Y", dY);
                    double[] dW = new double[TReticles.MAX_RETICLES];
                    dW = xmlFile.GetValue(chapter, "Camera" + i.ToString(), "Reticle", "W", dW);
                    double[] dH = new double[TReticles.MAX_RETICLES];
                    dH = xmlFile.GetValue(chapter, "Camera" + i.ToString(), "Reticle", "H", dH);
                    string[] Text = new string[TReticles.MAX_RETICLES];
                    Text = xmlFile.GetValue(chapter, "Camera" + i.ToString(), "Reticle", "Text", Text);
                    int[] Color = new int[TReticles.MAX_RETICLES];
                    Color = xmlFile.GetValue(chapter, "Camera" + i.ToString(), "Reticle", "Color", Color);

                    TReticle2 reticle = new TReticle2();
                    for (int j = 0; j < TReticles.MAX_RETICLES; j++)
                    {
                        Reticles[i].Reticle[j].Type = (TReticle2.EType)intType[j];

                        Reticles[i].Reticle[j].Location.Y = (float)dY[j];
                        Reticles[i].Reticle[j].Location.X = (float)dX[j];
                        Reticles[i].Reticle[j].Size.Width = (float)dW[j];
                        Reticles[i].Reticle[j].Size.Height = (float)dH[j];

                        Reticles[i].Reticle[j].Text = Text[j];
                        Reticles[i].Reticle[j].Color = System.Drawing.Color.FromArgb(Color[j]);
                    }
                }
            }
            finally
            {
            }
        }
        public static void saveCamReticlesXML(XmlWriter writer)
        {
            writer.WriteStartElement("chapter");
            writer.WriteAttributeString("name", "Vision");

            for (int i = 0; i < Max_Reticle; i++)
            {
                int[] intType = new int[TReticles.MAX_RETICLES];
                double[] dX = new double[TReticles.MAX_RETICLES];
                double[] dY = new double[TReticles.MAX_RETICLES];
                double[] dW = new double[TReticles.MAX_RETICLES];
                double[] dH = new double[TReticles.MAX_RETICLES];
                string[] Text = new string[TReticles.MAX_RETICLES];
                int[] Color = new int[TReticles.MAX_RETICLES];
                for (int j = 0; j < TReticles.MAX_RETICLES; j++)
                {
                    intType[j] = (int)Reticles[i].Reticle[j].Type;

                    dX[j] = Reticles[i].Reticle[j].Location.X;
                    dY[j] = Reticles[i].Reticle[j].Location.Y;
                    dW[j] = Reticles[i].Reticle[j].Size.Width;
                    dH[j] = Reticles[i].Reticle[j].Size.Height;

                    Text[j] = Reticles[i].Reticle[j].Text;
                    Color[j] = Reticles[i].Reticle[j].Color.ToArgb();
                }

                writer.WriteStartElement("section");//section
                writer.WriteAttributeString("name", "Camera" + i.ToString());

                writer.WriteStartElement("entry");//entry
                writer.WriteAttributeString("name", "Reticle");

                DispProg.WriteSubEntry(writer, "Type", intType);
                DispProg.WriteSubEntry(writer, "X", dX);
                DispProg.WriteSubEntry(writer, "Y", dY);
                DispProg.WriteSubEntry(writer, "W", dW);
                DispProg.WriteSubEntry(writer, "H", dH);
                DispProg.WriteSubEntry(writer, "Text", Text);
                DispProg.WriteSubEntry(writer, "Color", Color);

                writer.WriteEndElement();//end entry

                writer.WriteEndElement();//end section
            }

            writer.WriteEndElement();//end chapter
        }
        public static void loadCamReticlesXML(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "chapter" && reader.MoveToContent() == XmlNodeType.EndElement) break;

                #region section
                if (reader.Name == "section")
                {
                        string secAttVal = reader["name"];

                        switch (secAttVal)
                        {
                            case "Camera0":
                            case "Camera1":
                            case "Camera2":
                            case "Camera3":
                                {
                                    int iNo = int.Parse(secAttVal.Remove(0, 6));

                                    while (reader.Read())
                                    {
                                        if (reader.Name == "section" && reader.MoveToContent() == XmlNodeType.EndElement) break;

                                        if (reader.Name == "entry" && reader["name"] == "Reticle")
                                        {
                                            while (reader.Read())
                                            {
                                                if (reader.Name == "entry" && reader.MoveToContent() == XmlNodeType.EndElement) break;

                                                if (reader.Name == "subentry")
                                                {
                                                    string attName = reader["name"];

                                                    switch (attName)
                                                    {
                                                        case "Type":
                                                            int[] intType = new int[TReticles.MAX_RETICLES];
                                                            intType = DispProg.ReadSubEntry(reader, intType);
                                                            for (int j = 0; j < TReticles.MAX_RETICLES; j++)
                                                                Reticles[iNo].Reticle[j].Type = (TReticle2.EType)intType[j];
                                                            break;
                                                        case "X":
                                                            double[] dX = new double[TReticles.MAX_RETICLES];
                                                            dX = DispProg.ReadSubEntry(reader, dX);
                                                            for (int j = 0; j < TReticles.MAX_RETICLES; j++)
                                                                Reticles[iNo].Reticle[j].Location.X = (float)dX[j];
                                                            break;
                                                        case "Y":
                                                            double[] dY = new double[TReticles.MAX_RETICLES];
                                                            dY = DispProg.ReadSubEntry(reader, dY);
                                                            for (int j = 0; j < TReticles.MAX_RETICLES; j++)
                                                                Reticles[iNo].Reticle[j].Location.Y = (float)dY[j];
                                                            break;
                                                        case "W":
                                                            double[] dW = new double[TReticles.MAX_RETICLES];
                                                            dW = DispProg.ReadSubEntry(reader, dW);
                                                            for (int j = 0; j < TReticles.MAX_RETICLES; j++)
                                                                Reticles[iNo].Reticle[j].Size.Width = (float)dW[j];
                                                            break;
                                                        case "H":
                                                            double[] dH = new double[TReticles.MAX_RETICLES];
                                                            dH = DispProg.ReadSubEntry(reader, dH);
                                                            for (int j = 0; j < TReticles.MAX_RETICLES; j++)
                                                                Reticles[iNo].Reticle[j].Size.Height = (float)dH[j];
                                                            break;
                                                        case "Text":
                                                            string[] Text = new string[TReticles.MAX_RETICLES];
                                                            Text = DispProg.ReadSubEntry(reader, Text);
                                                            for (int j = 0; j < TReticles.MAX_RETICLES; j++)
                                                                Reticles[iNo].Reticle[j].Text = Text[j];
                                                            break;
                                                        case "Color":
                                                            int[] Color = new int[TReticles.MAX_RETICLES];
                                                            Color = DispProg.ReadSubEntry(reader, Color);
                                                            for (int j = 0; j < TReticles.MAX_RETICLES; j++)
                                                                Reticles[iNo].Reticle[j].Color = System.Drawing.Color.FromArgb(Color[j]);
                                                            break;
                                                    }
                                                }

                                            }

                                        }
                                    }
                                }
                                break;
                        }
                }
                #endregion
            }            
        }
    }
}