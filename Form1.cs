using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PhoneAndTaxi
{
    public struct AD101DEVICEPARAMETER
    {
        public int nRingOn;
        public int nRingOff;
        public int nHookOn;
        public int nHookOff;
        public int nStopCID;
        public int nNoLine;         // Add this parameter in new AD101(MCU Version is 6.0)
    }
    public partial class Form1 : Form
    {
        [DllImport("AD101Device.dll", EntryPoint = "AD101_GetCallerID", CharSet = CharSet.Ansi)]
        public static extern int AD101_GetCallerID(int nLine, StringBuilder szCallerIDBuffer, StringBuilder szName, StringBuilder szTime);

        // Control led 
        [DllImport("AD101Device.dll", EntryPoint = "AD101_SetLED")]
        public static extern int AD101_SetLED(int nLine, int enumLed);

        [DllImport("AD101Device.dll", EntryPoint = "AD101_GetParameter")]
        public static extern int AD101_GetParameter(int nLine, ref AD101DEVICEPARAMETER tagParameter);


        [DllImport("AD101Device.dll", EntryPoint = "AD101_InitDevice")]
        public static extern int AD101_InitDevice(int hWnd);

        // Get talking time
        [DllImport("AD101Device.dll", EntryPoint = "AD101_GetTalkTime")]
        public static extern int AD101_GetTalkTime(int nLine);


        [DllImport("AD101Device.dll", EntryPoint = "AD101_ReadParameter")]
        public static extern int AD101_ReadParameter(int nLine);

        public const int MCU_BACKCID = 0x09;		// Return Device CallerID
        public const int WM_USBLINEMSG = 1024 + 180;
        public const int MCU_BACKTALK = 0xBB;
        public const int MCU_BACKPARAM = 0x0C;
        public const int MCU_BACKID = 0x07;	// Return Device ID
        //public const int MCU_BACKSTATE = 0x08;	// Return Device State
        //public const int MCU_BACKCPUID = 0x0D;	// Return Device CPU ID
        //public const int MCU_BACKPARAM = 0x0C;	// Return Device Paramter
        //public const int MCU_BACKDEVICE = 0x0B;	// Return Device Back Device ID
        // LED Status 
        enum LEDTYPE
        {
            LED_CLOSE = 1,
            LED_RED,
            LED_GREEN,
            LED_YELLOW,
            LED_REDSLOW,
            LED_GREENSLOW,
            LED_YELLOWSLOW,
            LED_REDQUICK,
            LED_GREENQUICK,
            LED_YELLOWQUICK,
        };


        public Form1()
        {
            InitializeComponent();
        }
        protected override void DefWndProc(ref System.Windows.Forms.Message m)
        {
            try
            {

                //    OnDeviceMsg(m.WParam, m.LParam);
                switch (m.Msg)
                {
                    case WM_USBLINEMSG: //´¦ÀíÏûÏ¢¡¡
                        OnDeviceMsg(m.WParam, m.LParam);
                        break;
                    default:
                        base.DefWndProc(ref m);//µ÷ÓÃ»ùÀàº¯Êý´¦Àí·Ç×Ô¶¨ÒåÏûÏ¢¡£¡¡¡¡¡¡
                        break;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void OnDeviceMsg(IntPtr wParam, IntPtr Lparam)
        {
            try
            {
                int nMsg = new int();
                int nLine = new int();

                nMsg = wParam.ToInt32() % 65536;
                nLine = wParam.ToInt32() / 65536;

                switch (nMsg)
                {
                    ////
                    case MCU_BACKID:
                        {
                            StringBuilder szCPUVersion = new StringBuilder(32);
                    
                            label1.Text = "Enable";

                           //AD101_GetCPUVersion(nLine, szCPUVersion);


                      }
                    break;
                    case MCU_BACKCID:
                        {
                            StringBuilder szCallerID = new StringBuilder(128);
                            StringBuilder szName = new StringBuilder(128);
                            StringBuilder szTime = new StringBuilder(128);

                            int nLen = AD101_GetCallerID(nLine, szCallerID, szName, szTime);
                            string check = "";
                            check = szCallerID.ToString();


                            this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate ()
                            {
                                if (check == null)
                                {
                                    CopiarLinea1.Text = "International Number";

                                }
                                else
                                {
                                    string str = szCallerID.ToString();
                                    string newString = Regex.Replace(str, "[^.0-9]", "");

                                    CopiarLinea1.Text = newString;

                                }

                            });
                        }
                        break;
                    case MCU_BACKTALK:
                        {
                            string strTalk;
                            strTalk = string.Format("{0:D2}", Lparam) + "S";
                            //listView1.Items[nLine].SubItems[7].Text = strTalk;

                        }
                        break;
                    case MCU_BACKPARAM:
                        {
                            AD101DEVICEPARAMETER tagParameter = new AD101DEVICEPARAMETER();

                            AD101_GetParameter(nLine, ref tagParameter);
                        }
                        break;
                    //case MCU_BACKCPUID:
                    //    {
                    //        StringBuilder szCPUID = new StringBuilder(4);

                    //        AD101_GetCPUID(nLine, szCPUID);

                    //        //listView1.Items[nLine].SubItems[8].Text = szCPUID.ToString();

                    //    }
                    //    break;
                    //case MCU_BACKPARAM:
                    //    {
                    //        AD101DEVICEPARAMETER tagParameter = new AD101DEVICEPARAMETER();

                    //        AD101_GetParameter(nLine, ref tagParameter);
                    //    }
                    //    break;
                    //case MCU_BACKDEVICE:
                    //    {
                    //        StringBuilder szCPUVersion = new StringBuilder(32);

                    //        AD101_GetCPUVersion(nLine, szCPUVersion);


                    //    }
                    //    break;
                    default:
                        break;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }



        private void CopiarLinea1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText (CopiarLinea1.Text);
        }

        private void CopiarLinea2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(CopiarLinea2.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (AD101_InitDevice(Handle.ToInt32()) == 0)
                {
                    return;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message + "  " + ex.InnerException.Message); }
            AD101_SetLED(0, 3);
        }
    }
}
