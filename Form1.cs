using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MvCamCtrl.NET;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;

using System.Drawing.Imaging;
using LjxaSample.DriverDotNet;
//using HalconDotNet;

namespace haltest2
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            DeviceListAcq();
            Control.CheckForIllegalCrossThreadCalls = false;
            //  DisplayWindowsInitial();
            //  hd.InitHalcon(hwin);
            

            InitListView(listView1);
            InitListView2(listView2);

            hd.DisplayWindowsInitial(pictureBox2.Width, pictureBox2.Height , pictureBox2.Handle);
            hd.Display3DWindowsInitial(pictureBoxTL.Width, pictureBoxTL.Height, pictureBoxTL.Handle, pictureBoxBW.Handle);
            hd.InitHalcon();

            //初始化3D显示窗口
            ljxaWindows3D1.Init();
            //确认保存的文件夹是否存在,没有的话创建
            DateTime StartTime = DateTime.Now;
            image_save_path = Application.StartupPath + "\\" + StartTime.Year + "-" + StartTime.Month + "-" + StartTime.Day + "\\";
            if (!(System.IO.Directory.Exists(image_save_path)))
            {
                System.IO.Directory.CreateDirectory(image_save_path);
            }
            _logBox.AppendText("默认保存路径：" + "\n");
            _logBox.AppendText(image_save_path + "\n");
            //使用计时器定时判断是否接收到图像（避免跨线程调用控件）
            timerwaitimage.Enabled = true;


        }

        #region //2D
        MyCamera.MV_CC_DEVICE_INFO_LIST m_stDeviceList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
        private MyCamera m_MyCamera = new MyCamera();
        bool m_bGrabbing = false;
        Thread m_hReceiveThread = null;
        MyCamera.MV_FRAME_OUT_INFO_EX m_stFrameInfo = new MyCamera.MV_FRAME_OUT_INFO_EX();

        // ch:用于从驱动获取图像的缓存 | en:Buffer for getting image from driver
        UInt32 m_nBufSizeForDriver = 0;
        IntPtr m_BufForDriver;
        private static Object BufForDriverLock = new Object();

        // ch:用于保存图像的缓存 | en:Buffer for saving image
        UInt32 m_nBufSizeForSaveImage = 0;
        IntPtr m_BufForSaveImage;

        #region
        // ch:显示错误信息 | en:Show error message
        private void ShowErrorMsg(string csMessage, int nErrorNum)
        {
            string errorMsg;
            if (nErrorNum == 0)
            {
                errorMsg = csMessage;
            }
            else
            {
                errorMsg = csMessage + ": Error =" + String.Format("{0:X}", nErrorNum);
            }

            switch (nErrorNum)
            {
                case MyCamera.MV_E_HANDLE: errorMsg += " Error or invalid handle "; break;
                case MyCamera.MV_E_SUPPORT: errorMsg += " Not supported function "; break;
                case MyCamera.MV_E_BUFOVER: errorMsg += " Cache is full "; break;
                case MyCamera.MV_E_CALLORDER: errorMsg += " Function calling order error "; break;
                case MyCamera.MV_E_PARAMETER: errorMsg += " Incorrect parameter "; break;
                case MyCamera.MV_E_RESOURCE: errorMsg += " Applying resource failed "; break;
                case MyCamera.MV_E_NODATA: errorMsg += " No data "; break;
                case MyCamera.MV_E_PRECONDITION: errorMsg += " Precondition error, or running environment changed "; break;
                case MyCamera.MV_E_VERSION: errorMsg += " Version mismatches "; break;
                case MyCamera.MV_E_NOENOUGH_BUF: errorMsg += " Insufficient memory "; break;
                case MyCamera.MV_E_UNKNOW: errorMsg += " Unknown error "; break;
                case MyCamera.MV_E_GC_GENERIC: errorMsg += " General error "; break;
                case MyCamera.MV_E_GC_ACCESS: errorMsg += " Node accessing condition error "; break;
                case MyCamera.MV_E_ACCESS_DENIED: errorMsg += " No permission "; break;
                case MyCamera.MV_E_BUSY: errorMsg += " Device is busy, or network disconnected "; break;
                case MyCamera.MV_E_NETER: errorMsg += " Network error "; break;
            }

            MessageBox.Show(errorMsg, "PROMPT");
        }

        private Boolean IsMonoData(MyCamera.MvGvspPixelType enGvspPixelType)
        {
            switch (enGvspPixelType)
            {
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12_Packed:
                    return true;

                default:
                    return false;
            }
        }

        /************************************************************************
         *  @fn     IsColorData()
         *  @brief  判断是否是彩色数据
         *  @param  enGvspPixelType         [IN]           像素格式
         *  @return 成功，返回0；错误，返回-1 
         ************************************************************************/
        private Boolean IsColorData(MyCamera.MvGvspPixelType enGvspPixelType)
        {
            switch (enGvspPixelType)
            {
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_YUYV_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YCBCR411_8_CBYYCRYY:
                    return true;

                default:
                    return false;
            }
        }

        private void bnEnum_Click(object sender, EventArgs e)
        {
            DeviceListAcq();
        }
        //
        private void DeviceListAcq()
        {
            // ch:创建设备列表 | en:Create Device List
            System.GC.Collect();
            cbDeviceList.Items.Clear();
            m_stDeviceList.nDeviceNum = 0;
            int nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref m_stDeviceList);
            if (0 != nRet)
            {
                ShowErrorMsg("Enumerate devices fail!", 0);
                AddLog2D("Enumerate devices fail!", DateTime.Now);
                return;
            }

            // ch:在窗体列表中显示设备名 | en:Display device name in the form list
            for (int i = 0; i < m_stDeviceList.nDeviceNum; i++)
            {
                MyCamera.MV_CC_DEVICE_INFO device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_stDeviceList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
                if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                {
                    MyCamera.MV_GIGE_DEVICE_INFO gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(device.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));

                    if (gigeInfo.chUserDefinedName != "")
                    {
                        cbDeviceList.Items.Add("GEV: " + gigeInfo.chUserDefinedName + " (" + gigeInfo.chSerialNumber + ")");
                    }
                    else
                    {
                        cbDeviceList.Items.Add("GEV: " + gigeInfo.chManufacturerName + " " + gigeInfo.chModelName + " (" + gigeInfo.chSerialNumber + ")");
                    }
                }
                else if (device.nTLayerType == MyCamera.MV_USB_DEVICE)
                {
                    MyCamera.MV_USB3_DEVICE_INFO usbInfo = (MyCamera.MV_USB3_DEVICE_INFO)MyCamera.ByteToStruct(device.SpecialInfo.stUsb3VInfo, typeof(MyCamera.MV_USB3_DEVICE_INFO));
                    if (usbInfo.chUserDefinedName != "")
                    {
                        cbDeviceList.Items.Add("U3V: " + usbInfo.chUserDefinedName + " (" + usbInfo.chSerialNumber + ")");
                    }
                    else
                    {
                        cbDeviceList.Items.Add("U3V: " + usbInfo.chManufacturerName + " " + usbInfo.chModelName + " (" + usbInfo.chSerialNumber + ")");
                    }
                }
            }

            // ch:选择第一项 | en:Select the first item
            if (m_stDeviceList.nDeviceNum != 0)
            {
                cbDeviceList.SelectedIndex = 0;
            }
        }

        private void SetCtrlWhenOpen()
        {
            bnOpen.Enabled = false;

            bnClose.Enabled = true;
            bnStartGrab.Enabled = true;
            bnStartGrab1.Enabled = true;
            bnStopGrab.Enabled = false;
            bnStopGrab1.Enabled = false;

            bnContinuesMode.Enabled = true;
            bnContinuesMode.Checked = true;
            bnTriggerMode.Enabled = true;
            cbSoftTrigger.Enabled = false;
            bnTriggerExec.Enabled = false;

            tbExposure.Enabled = true;
            tbGain.Enabled = true;
            tbFrameRate.Enabled = true;
            bnGetParam.Enabled = true;
            bnSetParam.Enabled = true;
        }

        private void bnOpen_Click(object sender, EventArgs e)
        {
            if (m_stDeviceList.nDeviceNum == 0 || cbDeviceList.SelectedIndex == -1)
            {
                ShowErrorMsg("No device, please select", 0);
                AddLog2D("打开设备\tfalse\t"+"No device, please select", DateTime.Now);
                return;
            }

            // ch:获取选择的设备信息 | en:Get selected device information
            MyCamera.MV_CC_DEVICE_INFO device =
                (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_stDeviceList.pDeviceInfo[cbDeviceList.SelectedIndex],
                                                              typeof(MyCamera.MV_CC_DEVICE_INFO));

            // ch:打开设备 | en:Open device
            if (null == m_MyCamera)
            {
                m_MyCamera = new MyCamera();
                if (null == m_MyCamera)
                {
                    return;
                }
            }

            int nRet = m_MyCamera.MV_CC_CreateDevice_NET(ref device);
            if (MyCamera.MV_OK != nRet)
            {
                return;
            }

            nRet = m_MyCamera.MV_CC_OpenDevice_NET();
            if (MyCamera.MV_OK != nRet)
            {
                m_MyCamera.MV_CC_DestroyDevice_NET();
                ShowErrorMsg("Device open fail!", nRet);
                return;
            }

            // ch:探测网络最佳包大小(只对GigE相机有效) | en:Detection network optimal package size(It only works for the GigE camera)
            if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
            {
                int nPacketSize = m_MyCamera.MV_CC_GetOptimalPacketSize_NET();
                if (nPacketSize > 0)
                {
                    nRet = m_MyCamera.MV_CC_SetIntValue_NET("GevSCPSPacketSize", (uint)nPacketSize);
                    if (nRet != MyCamera.MV_OK)
                    {
                        ShowErrorMsg("Set Packet Size failed!", nRet);
                    }
                }
                else
                {
                    ShowErrorMsg("Get Packet Size failed!", nPacketSize);
                }
            }

            // ch:设置采集连续模式 | en:Set Continues Aquisition Mode
            m_MyCamera.MV_CC_SetEnumValue_NET("AcquisitionMode", (uint)MyCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_CONTINUOUS);
            m_MyCamera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF);

            bnGetParam_Click(null, null);// ch:获取参数 | en:Get parameters

            // ch:控件操作 | en:Control operation
            SetCtrlWhenOpen();
        }

        private void SetCtrlWhenClose()
        {
            bnOpen.Enabled = true;

            bnClose.Enabled = false;
            bnStartGrab.Enabled = false;
            bnStartGrab1.Enabled = false;

            bnStopGrab.Enabled = false;
            bnStopGrab1.Enabled = false;

            bnContinuesMode.Enabled = false;
            bnTriggerMode.Enabled = false;
            cbSoftTrigger.Enabled = false;
            bnTriggerExec.Enabled = false;

            bnSaveBmp.Enabled = false;
            bnSaveJpg.Enabled = false;
            tbExposure.Enabled = false;
            tbGain.Enabled = false;
            tbFrameRate.Enabled = false;
            bnGetParam.Enabled = false;
            bnSetParam.Enabled = false;
        }

        private void bnClose_Click(object sender, EventArgs e)
        {
            // ch:取流标志位清零 | en:Reset flow flag bit
            if (m_bGrabbing == true)
            {
                m_bGrabbing = false;
                m_hReceiveThread.Join();
            }

            if (m_BufForDriver != IntPtr.Zero)
            {
                Marshal.Release(m_BufForDriver);
            }
            if (m_BufForSaveImage != IntPtr.Zero)
            {
                Marshal.Release(m_BufForSaveImage);
            }

            // ch:关闭设备 | en:Close Device
            m_MyCamera.MV_CC_CloseDevice_NET();
            m_MyCamera.MV_CC_DestroyDevice_NET();

            // ch:控件操作 | en:Control Operation
            SetCtrlWhenClose();
        }

        private void bnContinuesMode_CheckedChanged(object sender, EventArgs e)
        {
            if (bnContinuesMode.Checked)
            {
                m_MyCamera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF);
                cbSoftTrigger.Enabled = false;
                bnTriggerExec.Enabled = false;
            }
        }

        private void bnTriggerMode_CheckedChanged(object sender, EventArgs e)
        {
            // ch:打开触发模式 | en:Open Trigger Mode
            if (bnTriggerMode.Checked)
            {
                m_MyCamera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);

                // ch:触发源选择:0 - Line0; | en:Trigger source select:0 - Line0;
                //           1 - Line1;
                //           2 - Line2;
                //           3 - Line3;
                //           4 - Counter;
                //           7 - Software;
                if (cbSoftTrigger.Checked)
                {
                    m_MyCamera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE);
                    if (m_bGrabbing)
                    {
                        bnTriggerExec.Enabled = true;
                    }
                }
                else
                {
                    m_MyCamera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE0);
                }
                cbSoftTrigger.Enabled = true;
            }
        }

        private void SetCtrlWhenStartGrab()
        {
            bnStartGrab.Enabled = false;
            bnStartGrab1.Enabled = false;
            bnStopGrab.Enabled = true;
            bnStopGrab1.Enabled = true;


            if (bnTriggerMode.Checked && cbSoftTrigger.Checked)
            {
                bnTriggerExec.Enabled = true;
            }

            bnSaveBmp.Enabled = true;
            bnSaveJpg.Enabled = true;
        }


        private void bnStartGrab_Click(object sender, EventArgs e)
        {
            // ch:标志位置位true | en:Set position bit true
            m_bGrabbing = true;

            m_hReceiveThread = new Thread(ReceiveThreadProcess);
            m_hReceiveThread.Start();

            m_stFrameInfo.nFrameLen = 0;//取流之前先清除帧长度
            m_stFrameInfo.enPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_Undefined;
            // ch:开始采集 | en:Start Grabbing
            int nRet = m_MyCamera.MV_CC_StartGrabbing_NET();
            if (MyCamera.MV_OK != nRet)
            {
                m_bGrabbing = false;
                m_hReceiveThread.Join();
                ShowErrorMsg("Start Grabbing Fail!", nRet);
                return;
            }

            // ch:控件操作 | en:Control Operation
            SetCtrlWhenStartGrab();
        }

        private void cbSoftTrigger_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSoftTrigger.Checked)
            {
                // ch:触发源设为软触发 | en:Set trigger source as Software
                m_MyCamera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE);
                if (m_bGrabbing)
                {
                    bnTriggerExec.Enabled = true;
                }
            }
            else
            {
                m_MyCamera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE0);
                bnTriggerExec.Enabled = false;
            }
        }

        private void bnTriggerExec_Click(object sender, EventArgs e)
        {
            // ch:触发命令 | en:Trigger command
            int nRet = m_MyCamera.MV_CC_SetCommandValue_NET("TriggerSoftware");
            if (MyCamera.MV_OK != nRet)
            {
                ShowErrorMsg("Trigger Software Fail!", nRet);
            }
        }

        private void SetCtrlWhenStopGrab()
        {
            bnStartGrab.Enabled = true;
            bnStartGrab1.Enabled = true;

            bnStopGrab.Enabled = false;
            bnStopGrab1.Enabled = false;


            bnTriggerExec.Enabled = false;


            bnSaveBmp.Enabled = false;
            bnSaveJpg.Enabled = false;
        }

        private void bnStopGrab_Click(object sender, EventArgs e)
        {
            // ch:标志位设为false | en:Set flag bit false
            m_bGrabbing = false;
            m_hReceiveThread.Join();

            // ch:停止采集 | en:Stop Grabbing
            int nRet = m_MyCamera.MV_CC_StopGrabbing_NET();
            if (nRet != MyCamera.MV_OK)
            {
                ShowErrorMsg("Stop Grabbing Fail!", nRet);
            }

            // ch:控件操作 | en:Control Operation
            SetCtrlWhenStopGrab();
            // 转换为Honject
            // HOperatorSet.GenImage1Extern(out hd.ho_Image, "byte", m_stFrameInfo.nWidth, m_stFrameInfo.nHeight, m_BufForDriver, IntPtr.Zero);
            hd.getImageFromCam(m_stFrameInfo.nWidth, m_stFrameInfo.nHeight , m_BufForDriver);
        }

        private void bnSaveBmp_Click(object sender, EventArgs e)
        {
            if (false == m_bGrabbing)
            {
                ShowErrorMsg("Not Start Grabbing", 0);
                return;
            }

            if (RemoveCustomPixelFormats(m_stFrameInfo.enPixelType))
            {
                ShowErrorMsg("Not Support!", 0);
                return;
            }

            IntPtr pTemp = IntPtr.Zero;
            MyCamera.MvGvspPixelType enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_Undefined;
            if (m_stFrameInfo.enPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8 || m_stFrameInfo.enPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_BGR8_Packed)
            {
                pTemp = m_BufForDriver;
                enDstPixelType = m_stFrameInfo.enPixelType;
            }
            else
            {
                UInt32 nSaveImageNeedSize = 0;
                MyCamera.MV_PIXEL_CONVERT_PARAM stConverPixelParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();

                lock (BufForDriverLock)
                {
                    if (m_stFrameInfo.nFrameLen == 0)
                    {
                        ShowErrorMsg("Save Bmp Fail!", 0);
                        return;
                    }

                    if (IsMonoData(m_stFrameInfo.enPixelType))
                    {
                        enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8;
                        nSaveImageNeedSize = (uint)m_stFrameInfo.nWidth * m_stFrameInfo.nHeight;
                    }
                    else if (IsColorData(m_stFrameInfo.enPixelType))
                    {
                        enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_BGR8_Packed;
                        nSaveImageNeedSize = (uint)m_stFrameInfo.nWidth * m_stFrameInfo.nHeight * 3;
                    }
                    else
                    {
                        ShowErrorMsg("No such pixel type!", 0);
                        return;
                    }

                    if (m_nBufSizeForSaveImage < nSaveImageNeedSize)
                    {
                        if (m_BufForSaveImage != IntPtr.Zero)
                        {
                            Marshal.Release(m_BufForSaveImage);
                        }
                        m_nBufSizeForSaveImage = nSaveImageNeedSize;
                        m_BufForSaveImage = Marshal.AllocHGlobal((Int32)m_nBufSizeForSaveImage);
                    }

                    stConverPixelParam.nWidth = m_stFrameInfo.nWidth;
                    stConverPixelParam.nHeight = m_stFrameInfo.nHeight;
                    stConverPixelParam.pSrcData = m_BufForDriver;
                    stConverPixelParam.nSrcDataLen = m_stFrameInfo.nFrameLen;
                    stConverPixelParam.enSrcPixelType = m_stFrameInfo.enPixelType;
                    stConverPixelParam.enDstPixelType = enDstPixelType;
                    stConverPixelParam.pDstBuffer = m_BufForSaveImage;
                    stConverPixelParam.nDstBufferSize = m_nBufSizeForSaveImage;
                    int nRet = m_MyCamera.MV_CC_ConvertPixelType_NET(ref stConverPixelParam);
                    if (MyCamera.MV_OK != nRet)
                    {
                        ShowErrorMsg("Convert Pixel Type Fail!", nRet);
                        return;
                    }
                    pTemp = m_BufForSaveImage;
                }
            }

            lock (BufForDriverLock)
            {
                if (enDstPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8)
                {
                    //************************Mono8 转 Bitmap*******************************
                    Bitmap bmp = new Bitmap(m_stFrameInfo.nWidth, m_stFrameInfo.nHeight, m_stFrameInfo.nWidth * 1, PixelFormat.Format8bppIndexed, pTemp);

                    ColorPalette cp = bmp.Palette;
                    // init palette
                    for (int i = 0; i < 256; i++)
                    {
                        cp.Entries[i] = Color.FromArgb(i, i, i);
                    }
                    // set palette back
                    bmp.Palette = cp;
                    bmp.Save("image.bmp", ImageFormat.Bmp);
                }
                else
                {
                    //*********************BGR8 转 Bitmap**************************
                    try
                    {
                        Bitmap bmp = new Bitmap(m_stFrameInfo.nWidth, m_stFrameInfo.nHeight, m_stFrameInfo.nWidth * 3, PixelFormat.Format24bppRgb, pTemp);
                        bmp.Save("image.bmp", ImageFormat.Bmp);
                    }
                    catch
                    {
                        ShowErrorMsg("Write File Fail!", 0);
                    }
                }
            }

            ShowErrorMsg("Save Succeed!", 0);
        }

        private void bnSaveJpg_Click(object sender, EventArgs e)
        {
            if (false == m_bGrabbing)
            {
                ShowErrorMsg("Not Start Grabbing", 0);
                return;
            }

            if (RemoveCustomPixelFormats(m_stFrameInfo.enPixelType))
            {
                ShowErrorMsg("Not Support!", 0);
                return;
            }

            UInt32 nSaveImageNeedSize = m_nBufSizeForDriver * 3 + 2048;
            if (m_nBufSizeForSaveImage < nSaveImageNeedSize)
            {
                if (m_BufForSaveImage != IntPtr.Zero)
                {
                    Marshal.Release(m_BufForSaveImage);
                }
                m_nBufSizeForSaveImage = nSaveImageNeedSize;
                m_BufForSaveImage = Marshal.AllocHGlobal((Int32)m_nBufSizeForSaveImage);
            }

            MyCamera.MV_SAVE_IMAGE_PARAM_EX stSaveParam = new MyCamera.MV_SAVE_IMAGE_PARAM_EX();

            lock (BufForDriverLock)
            {
                if (m_stFrameInfo.nFrameLen == 0)
                {
                    ShowErrorMsg("Save Jpeg Fail!", 0);
                    return;
                }
                IntPtr pJpgImage = m_BufForSaveImage;
                stSaveParam.enImageType = MyCamera.MV_SAVE_IAMGE_TYPE.MV_Image_Jpeg;
                stSaveParam.enPixelType = m_stFrameInfo.enPixelType;
                stSaveParam.pData = m_BufForDriver;
                stSaveParam.nDataLen = m_stFrameInfo.nFrameLen;
                stSaveParam.nHeight = m_stFrameInfo.nHeight;
                stSaveParam.nWidth = m_stFrameInfo.nWidth;
                stSaveParam.pImageBuffer = pJpgImage;
                stSaveParam.nBufferSize = m_nBufSizeForSaveImage;
                stSaveParam.nJpgQuality = 80;
                int nRet = m_MyCamera.MV_CC_SaveImageEx_NET(ref stSaveParam);
                if (MyCamera.MV_OK != nRet)
                {
                    ShowErrorMsg("Save Fail!", nRet);
                    return;
                }
            }

            Byte[] bArrSaveImage = new Byte[stSaveParam.nImageLen];
            Marshal.Copy(m_BufForSaveImage, bArrSaveImage, 0, (int)stSaveParam.nImageLen);
            try
            {
                FileStream file = new FileStream("image.jpg", FileMode.Create, FileAccess.Write);
                file.Write(bArrSaveImage, 0, (int)stSaveParam.nImageLen);
                file.Close();
            }
            catch
            {
                ShowErrorMsg("Write File Fail!", 0);
                return;
            }

            ShowErrorMsg("Save Succeed!", 0);
        }

        private void bnGetParam_Click(object sender, EventArgs e)
        {
            MyCamera.MVCC_FLOATVALUE stParam = new MyCamera.MVCC_FLOATVALUE();
            int nRet = m_MyCamera.MV_CC_GetFloatValue_NET("ExposureTime", ref stParam);
            if (MyCamera.MV_OK == nRet)
            {
                tbExposure.Text = stParam.fCurValue.ToString("F1");
            }

            nRet = m_MyCamera.MV_CC_GetFloatValue_NET("Gain", ref stParam);
            if (MyCamera.MV_OK == nRet)
            {
                tbGain.Text = stParam.fCurValue.ToString("F1");
            }

            nRet = m_MyCamera.MV_CC_GetFloatValue_NET("ResultingFrameRate", ref stParam);
            if (MyCamera.MV_OK == nRet)
            {
                tbFrameRate.Text = stParam.fCurValue.ToString("F1");
            }
        }

        private void bnSetParam_Click(object sender, EventArgs e)
        {
            try
            {
                float.Parse(tbExposure.Text);
                float.Parse(tbGain.Text);
                float.Parse(tbFrameRate.Text);
            }
            catch
            {
                ShowErrorMsg("Please enter correct type!", 0);
                return;
            }

            m_MyCamera.MV_CC_SetEnumValue_NET("ExposureAuto", 0);
            int nRet = m_MyCamera.MV_CC_SetFloatValue_NET("ExposureTime", float.Parse(tbExposure.Text));
            if (nRet != MyCamera.MV_OK)
            {
                ShowErrorMsg("Set Exposure Time Fail!", nRet);
            }

            m_MyCamera.MV_CC_SetEnumValue_NET("GainAuto", 0);
            nRet = m_MyCamera.MV_CC_SetFloatValue_NET("Gain", float.Parse(tbGain.Text));
            if (nRet != MyCamera.MV_OK)
            {
                ShowErrorMsg("Set Gain Fail!", nRet);
            }

            nRet = m_MyCamera.MV_CC_SetFloatValue_NET("AcquisitionFrameRate", float.Parse(tbFrameRate.Text));
            if (nRet != MyCamera.MV_OK)
            {
                ShowErrorMsg("Set Frame Rate Fail!", nRet);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bnClose_Click(sender, e);
        }

        // ch:去除自定义的像素格式 | en:Remove custom pixel formats
        private bool RemoveCustomPixelFormats(MyCamera.MvGvspPixelType enPixelFormat)
        {
            Int32 nResult = ((int)enPixelFormat) & (unchecked((Int32)0x80000000));
            if (0x80000000 == nResult)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
        public void ReceiveThreadProcess()
        {
            MyCamera.MVCC_INTVALUE stParam = new MyCamera.MVCC_INTVALUE();
            int nRet = m_MyCamera.MV_CC_GetIntValue_NET("PayloadSize", ref stParam);
            if (MyCamera.MV_OK != nRet)
            {
                ShowErrorMsg("Get PayloadSize failed", nRet);
                return;
            }

            UInt32 nPayloadSize = stParam.nCurValue;
            if (nPayloadSize > m_nBufSizeForDriver)
            {
                if (m_BufForDriver != IntPtr.Zero)
                {
                    Marshal.Release(m_BufForDriver);
                }
                m_nBufSizeForDriver = nPayloadSize;
                m_BufForDriver = Marshal.AllocHGlobal((Int32)m_nBufSizeForDriver);
            }

            if (m_BufForDriver == IntPtr.Zero)
            {
                return;
            }

            MyCamera.MV_FRAME_OUT_INFO_EX stFrameInfo = new MyCamera.MV_FRAME_OUT_INFO_EX();
            MyCamera.MV_DISPLAY_FRAME_INFO stDisplayInfo = new MyCamera.MV_DISPLAY_FRAME_INFO();

            while (m_bGrabbing)
            {
                lock (BufForDriverLock)
                {
                    nRet = m_MyCamera.MV_CC_GetOneFrameTimeout_NET(m_BufForDriver, nPayloadSize, ref stFrameInfo, 1000);
                    if (nRet == MyCamera.MV_OK)
                    {
                        m_stFrameInfo = stFrameInfo;
                    }
                }

                if (nRet == MyCamera.MV_OK)
                {
                    if (RemoveCustomPixelFormats(stFrameInfo.enPixelType))
                    {
                        continue;
                    }
                    stDisplayInfo.hWnd = pictureBox1.Handle;
                    stDisplayInfo.pData = m_BufForDriver;
                    stDisplayInfo.nDataLen = stFrameInfo.nFrameLen;
                    stDisplayInfo.nWidth = stFrameInfo.nWidth;
                    stDisplayInfo.nHeight = stFrameInfo.nHeight;
                    stDisplayInfo.enPixelType = stFrameInfo.enPixelType;
                    m_MyCamera.MV_CC_DisplayOneFrame_NET(ref stDisplayInfo);
                }
                else
                {
                    if (bnTriggerMode.Checked)
                    {
                        Thread.Sleep(5);
                    }
                }
            }
        }
        HDevelopExport hd = new HDevelopExport();
        //HObject ho_image = new HObject();
      //  HWindow hwin = new HWindow();
        string address;
       // HTuple X1, Y1, dG , CirLen; // 测量项距离

        private void button2_Click(object sender, EventArgs e)
        {
            if (bnStartGrab.Enabled)
            {
                this.bnStartGrab_Click(sender, e);
                this.dealImg.Enabled = false;
            }
        }

        private void bnStopGrab1_Click(object sender, EventArgs e)
        {
            if (bnStopGrab.Enabled)
            {
                this.bnStopGrab_Click(sender, e);
                // 将采到的数据转为 hobject
                this.dealImg.Enabled = true;
            }
            else
            {
                MessageBox.Show("停止采图失败");
            }
        }

        private void openImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图片文件| *.bmp;*.tif;*.jpg;*.png| bmp| *.bmp|tif| *.tif";
            if (ofd.ShowDialog() != DialogResult.OK) return;

            address = ofd.FileName;
            hd.readImage(address);
           // hd.readImage(address);
           // hd.readImage(out hd.ho_Image, address);
        }

        //private void DisplayWindowsInitial()
        //{
        //    // ch: 定义显示的起点和宽高 || en: Definition the width and height of the display window
        //    HTuple hWindowRow, hWindowColumn, hWindowWidth, hWindowHeight;

        //    // ch: 设置显示窗口的起点和宽高 || en: Set the width and height of the display window
        //    hWindowRow = 0;
        //    hWindowColumn = 0;
        //    hWindowWidth = pictureBox1.Width;
        //    hWindowHeight = pictureBox1.Height;

        //    try
        //    {
        //        // HTuple hWindowID = hSmartWindowControl1.HalconWindow;
        //        HTuple hWindowID = (HTuple)pictureBox2.Handle;
        //        hwin.OpenWindow(hWindowRow, hWindowColumn, hWindowWidth, hWindowHeight, hWindowID, "visible", "");
        //        //m_Window.OpenWindow(hWindowRow, hWindowColumn, hWindowWidth, hWindowHeight, hWindowID, "visible", "");
        //    }
        //    catch (System.Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //        return;
        //    }
        //}

        //public void HalconDisplay(HTuple hWindow, HObject Hobj, HTuple hHeight, HTuple hWidth)
        //{
        //    // ch: 显示 || display
        //    try
        //    {
        //        HOperatorSet.SetPart(hWindow, 0, 0, hHeight - 1, hWidth - 1);// ch: 使图像显示适应窗口大小 || en: Make the image adapt the window size
        //    }
        //    catch (System.Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //        return;
        //    }
        //    if (hWindow == null)
        //    {
        //        MessageBox.Show("无hWindow");
        //        return;
        //    }
        //    try
        //    {
        //        HOperatorSet.DispObj(Hobj, hWindow);// ch 显示 || en: display
        //    }
        //    catch (System.Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //        return;
        //    }
        //    return;
        //}

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab == tabPage4)
            {
                dealImg.Enabled = true;
            }
            else if(tabControl1.SelectedTab == tabPage3)
            {
                if(bnStopGrab1.Enabled == false)
                {
                    dealImg.Enabled = true;
                }
                else dealImg.Enabled = false;
            }
        }

        bool dealImg2D = false;
        double dealTime = 0.0;
        private void button1_Click(object sender, EventArgs e)
        {
            //hd.action(hd.ho_Image, out hd.X1, out hd.Y1, out hd.dG, out hd.CirLen);
            dealImg2D = false;
            DateTime dt1 = DateTime.Now;
            hd.action();
            DateTime dt2 = DateTime.Now;
            TimeSpan ts = dt2.Subtract(dt1);
            dealTime = ts.TotalSeconds;
            if (hd.IsErrHappen != 0)
            {
                MessageBox.Show(hd.errStr);
                return;
            }
            dealImg2D = true;
            string time =  DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");
            address = time + ".bmp";
            insertLine(listView1, address);
            AddLog2D("处理图片成功\t用时"+dealTime.ToString("f4")+"s", DateTime.Now);
        }

        #region // listView
        private void InitListView(ListView lv)
        {
            //设置列表属性
            lv.GridLines = true;    //显示网格线
            lv.View = View.Details; // 显示详情
            lv.FullRowSelect = true;  // 
            lv.HoverSelection = true;
            // 添加列表头
            ColumnHeader C1 = new ColumnHeader();
            C1.Text = "图片名称";
            C1.Width = 200;
            ColumnHeader C2 = new ColumnHeader();
            C2.Text = "X1";
            C2.Width = 100;
            ColumnHeader C3 = new ColumnHeader();
            C3.Text = "Y1";
            C3.Width = 100;
            ColumnHeader C4 = new ColumnHeader();
            C4.Text = "Dg";
            C4.Width = 100;
            ColumnHeader C5 = new ColumnHeader();
            C5.Text = "CircleRadius";
            C5.Width = 100;

            lv.Columns.Add(C1);
            lv.Columns.Add(C2);
            lv.Columns.Add(C3);
            lv.Columns.Add(C4);
            lv.Columns.Add(C5);

        }
        private void InitListView2(ListView lv)
        {
            //设置列表属性
            lv.GridLines = true;    //显示网格线
            lv.View = View.Details; // 显示详情
            lv.FullRowSelect = true;  // 
            lv.HoverSelection = true;
            // 添加列表头
            ColumnHeader C1 = new ColumnHeader();
            C1.Text = "FAI22Index";
            C1.Width = 100;
            ColumnHeader C2 = new ColumnHeader();
            C2.Text = "平面度flatness";
            C2.Width = 200;
            ColumnHeader C3 = new ColumnHeader();
            C3.Text = "平行度parallam";
            C3.Width = 200;

            lv.Columns.Add(C1);
            lv.Columns.Add(C2);
            lv.Columns.Add(C3);

        }
        public void insertLine(ListView lv, string fileName)
        {
            ListViewItem items = new ListViewItem((string)fileName);
            try
            {
                //items.SubItems.Add(name);
                //string x1 = hd.X1.ToString();
                items.SubItems.Add(hd.X2.ToString("f5"));
                items.SubItems.Add(hd.Y2.ToString("f5"));
                items.SubItems.Add(hd.DG.ToString("f5"));
                items.SubItems.Add(hd.CircleRadius.ToString("f5"));
                lv.Items.Add(items);
            }
            catch
            {
                MessageBox.Show("出现异常", "ERROR");
            }
        }
        public void insertLine2(ListView lv, string fileName)
        {
            ListViewItem items = new ListViewItem((string)fileName);
            try
            {
                //items.SubItems.Add(name);
                //string x1 = hd.X1.ToString();
                items.SubItems.Add(hd.flatness.ToString("f5"));
                items.SubItems.Add(hd.parallam22.ToString("f5"));
                lv.Items.Add(items);
            }
            catch
            {
                MessageBox.Show("出现异常", "ERROR");
            }
        }

        #endregion
        // 相机设置和图像处理切换
        private void tabPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (tabPage.SelectedTab == tabPage2 && bnStartGrab1.Enabled == false)
            {
                dealImg.Enabled = false;
            }
        }
        #endregion

        #region // 3D 相机
        //
        //实例化简化版DLL
        private LJX8000A ljxa = new LJX8000A();
        //用于保存高度/浓淡数据的缓存
        private ushort[] _heightdata = new ushort[] { };
        private ushort[] _luminancedata = new ushort[] { };
        //图像的宽度
        private int imgwidth = 0;
        //标志位，判断是否图像接收ok
        private bool image_received = false;
        private string image_save_path = "";
       

private void _button_openDevice_Click(object sender, EventArgs e)
{
    //新建通信设定然后打开设备连接
    CommunicationSetting _comset = new CommunicationSetting(communicationSetting1.IP, 24691, 24692, communicationSetting1.YSize, communicationSetting1.UseExternalBatchStart, communicationSetting1.OutputLiminanceData);
    bool result = ljxa.OpenDevice(0, _comset, _acquireFinish);
    AddLog("OpenDevice：   " + result + "\n", DateTime.Now);
}

private void _button_acquire_start_Click(object sender, EventArgs e)
{
    //打开高速通信并等待数据传回
    bool result = ljxa.AcquireStart(0);
    AddLog("AcquireStart:   " + result + "\n", DateTime.Now);
}
private void _button_acquire_stop_Click(object sender, EventArgs e)
{
    //中断批处理处理，然后处理已获得的数据
    bool result = ljxa.AcquireStop(0);
    AddLog("AcquireStop:   " + result + "\n", DateTime.Now);
}
private void _button_close_device_Click(object sender, EventArgs e)
{
    //关闭设备连接
    bool result = ljxa.CloseDevice(0);
    AddLog("CloseDevice:   " + result + "\n", DateTime.Now);
}
//回调函数，数据接收完成时DLL会调用
private void _acquireFinish(int _ID, int _notify)
{
    image_received = true;
}


//以上数据获取部分已结束，以下部分是显示+保存相关的内容

            //在logBox中添加带时间戳的记录
            private void AddLog(string _text, DateTime _time)
            {
                string timestr = _time.Year + "-" + _time.Month + "-" + _time.Day + " " + _time.Hour + ":" + _time.Minute + ":" + _time.Second + ":" + _time.Millisecond + "\t";
                _logBox.AppendText(timestr + _text + "\n");
            }
            private void AddLog2D(string _text, DateTime _time)
            {
                string timestr = _time.Year + "-" + _time.Month + "-" + _time.Day + " " + _time.Hour + ":" + _time.Minute + ":" + _time.Second + ":" + _time.Millisecond + "\t";
                logBox.AppendText(timestr + _text + "\n");
            }

        #endregion 

        #region   // 3D 图片处理
        private void init3Dwindow()
        {
            hd.Display3DWindowsInitial(pictureBoxTL.Width,pictureBoxTL.Height,pictureBoxTL.Handle,pictureBoxBW.Handle);
        }
        private void openTLimg_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图片文件| *.bmp;*.tif;*.jpg;*.png| bmp| *.bmp|tif| *.tif";
            if (ofd.ShowDialog() != DialogResult.OK) return;
            address = ofd.FileName;
            hd.read3DImageTL(address);
        }
        private void openBWimg_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图片文件| *.bmp;*.tif;*.jpg;*.png| bmp| *.bmp|tif| *.tif";
            if (ofd.ShowDialog() != DialogResult.OK) return;
            address = ofd.FileName;
            hd.read3DImageBW(address);
        }
        int FAI22Index = 0;
        bool dealImg3D = false; // 处理图片成功判断
        private void deal3DImg_Click(object sender, EventArgs e)
        {
            dealImg3D = false;

            DateTime dt1 = DateTime.Now;

            hd.action3D22();

            DateTime dt2 = DateTime.Now;
            TimeSpan ts = dt2.Subtract(dt1);
            dealTime = ts.TotalSeconds;

            if (hd.IsErrHappen != 0)
            {
                MessageBox.Show(hd.errStr);
                return;
            }
            dealImg3D = true;
            FAI22Index++;
            insertLine2(listView2, FAI22Index.ToString());
            AddLog("处理图片成功\t用时"+dealTime.ToString("f4")+"s", DateTime.Now);
        }



        #endregion

        string foldPath;
        private void seleFolder_Click(object sender, EventArgs e)
        {
            //foldPath = "";
            allTime = 0;
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                foldPath = dialog.SelectedPath;
                // 遍历文件夹
                DirectoryInfo theFolder = new DirectoryInfo(foldPath);
              //  FileInfo[] theFileInfo = theFolder.GetFiles("*.*", SearchOption.TopDirectoryOnly);
                FileInfo[] theFileInfo = theFolder.GetFiles();
                int deleNum = 0;
                for (int i = 0; i < theFileInfo.Length; i++)
                {
                    FileInfo file = theFileInfo[i];
                    if(file.Extension != ".tif" && file.Extension != ".bmp")
                    {
                        deleNum++;
                        continue;
                    }
                    DateTime dt1 = DateTime.Now;
                    string fileName = foldPath+"\\"+file.Name;
                    dealImg2D = false;
                    hd.readImage(fileName);
                    hd.action();
                    DateTime dt2 = DateTime.Now;
                    TimeSpan ts = dt2.Subtract(dt1);
                    dealTime = ts.TotalSeconds;
                    if (hd.IsErrHappen != 0)
                    {
                        MessageBox.Show(hd.errStr);
                        AddLog2D("处理第" + (i+1) + "张图片\t" + dealImg2D, DateTime.Now);
                        return;
                    }
                    dealImg2D = true;
                    insertLine(listView1, file.Name);
                    AddLog2D("处理第"+ (i+1) + "张图片\t"+dealImg2D+"\t用时"+dealTime+"s", DateTime.Now);
                    allTime = allTime + dealTime;
                }
                AddLog2D("处理共" + (theFileInfo.Length- deleNum) + "张图片成功\t共用时" + allTime.ToString("f4") + "s" + "\n", DateTime.Now);


                //foreach(FileInfo NextFile in theFileInfo)
                //{
                //    if (NextFile.Name.EndsWith(".tif")||NextFile.Name.EndsWith(".bmp"))
                //    {
                //        ListViewItem item = new ListViewItem(NextFile.Name);
                //        this.listView1.Items.Add(item);
                //    }
                //}
            }

        }
        double allTime = 0;
        private void seleFolder3D_Click(object sender, EventArgs e)
        {
            allTime = 0;
            FolderBrowserDialog dialogTL = new FolderBrowserDialog();
            dialogTL.Description = "请选择TL(正面图片)文件路径";
            FolderBrowserDialog dialogBW = new FolderBrowserDialog();
            dialogBW.Description = "请选择BW(反面图片)文件路径";
            if (dialogTL.ShowDialog() == DialogResult.OK && dialogBW.ShowDialog() == DialogResult.OK)
            {
                string imgTLpath = dialogTL.SelectedPath;
                string imgBWpath = dialogBW.SelectedPath;
                DirectoryInfo theTLFolder = new DirectoryInfo(imgTLpath);
                //  FileInfo[] theFileInfo = theFolder.GetFiles("*.*", SearchOption.TopDirectoryOnly);
                FileInfo[] imgTLInfo = theTLFolder.GetFiles("*.tif");
                DirectoryInfo theBWFolder = new DirectoryInfo(imgBWpath);
                FileInfo[] imgBWInfo = theBWFolder.GetFiles("*.tif");
                int minLen = imgTLInfo.Length;
                if (imgTLInfo.Length > imgBWInfo.Length) minLen = imgBWInfo.Length;
                if(minLen == 0)
                {
                    MessageBox.Show("图片选择路径错误");
                }
                for (int i = 0; i < minLen; i++)
                {
                    string TLaddress = imgTLpath + "\\" + imgTLInfo[i].Name;
                    string BWaddress = imgBWpath + "\\" + imgBWInfo[i].Name;

                    hd.read3DImageTL(TLaddress);
                    hd.read3DImageBW(BWaddress);

                    this.deal3DImg_Click(sender, e);
                    allTime = allTime + dealTime;
                    AddLog("处理第"+(i+1)+"张3D图片\t"+ dealImg3D + "\t用时"+dealTime.ToString("f4") + "s", DateTime.Now);
                }
                AddLog("处理"+ minLen +"张图片成功\t共用时"+ allTime.ToString("f4")+"s" + "\n", DateTime.Now);

            }

        }

        #region //  ListView 操作
        private void clearListView_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
        }
        private void deleLine(ListView lv)
        {
            int items = lv.SelectedItems.Count;
            if (items > 0)
            {
                for (int i = 0; i < items; i++)
                {
                    lv.SelectedItems[0].Remove();
                }
            }
        }
        private void deleLVitem_Click(object sender, EventArgs e)
        {
            deleLine(listView1);
        }

        private void clearLV2_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
        }

        private void deleLV2select_Click(object sender, EventArgs e)
        {
            deleLine(listView2);
        }
        #endregion

        #region // 数据写入文件
        private void writeFile1(string fileName, ListView lv)
        {
            StreamWriter sw = new StreamWriter(fileName, false);
            try
            {
                int len = 0;
                string line = "";
                string temp = "";
                for (int i = 0; i < lv.Columns.Count; i++)
                {
                    temp = lv.Columns[i].Text;
                    len = 30 - Encoding.Default.GetByteCount(temp) + temp.Length; //考虑中英文的情况
                    temp = temp.PadRight(len, ' ');
                    line += temp;
                }
                sw.WriteLine(line);
                line = "";
                for (int i = 0; i < lv.Items.Count; i++)
                {
                    for (int j = 0; j < lv.Items[i].SubItems.Count; j++)
                    {
                        temp = lv.Items[i].SubItems[j].Text;
                        len = 30 - Encoding.Default.GetByteCount(temp) + temp.Length;
                        temp = temp.PadRight(len, ' ');
                        line += temp;
                    }
                    sw.WriteLine(line);
                    line = "";
                }
                sw.Flush();
            }
            finally
            {
                if (sw != null) sw.Close();
            }
        }
        private void writeFile_Click(object sender, EventArgs e)
        {
            writeFile1("2dData.txt", listView1);
        }

        private void writeFile3D_Click(object sender, EventArgs e)
        {
            writeFile1("3dData.txt", listView2);
        }
        #endregion

        private void timerwaitimage_Tick(object sender, EventArgs e)
        {

        }
    }
}
