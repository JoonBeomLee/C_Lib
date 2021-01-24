using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// add
using System.IO;
using System.Runtime.InteropServices;   // 연결 확인 이벤트
using System.Management; // 디바이스 정보

namespace USB_TRANSFER
{
    // Device Info Sturcture
    [StructLayout(LayoutKind.Sequential)]
    public struct DevBroadcastVolume
    {
        public int Size;
        public int DeviceType;
        public int Reserved;
        public int Mask;
        public Int16 Flags;
    }

    public partial class Form1 : Form
    {
        // add
        private const int WM_DEVICECHANGE = 0x219;
        private const int DBT_DEVICEARRIVAL = 0x8000;
        private const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
        private const int DBT_DEVTYP_VOLUME = 0x00000002;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            switch (m.Msg)
            {
                case WM_DEVICECHANGE:
                    switch ((int)m.WParam)
                    {
                        case DBT_DEVICEARRIVAL:
                            listBox1.Items.Add("New Device Arrived");

                            int devType = Marshal.ReadInt32(m.LParam, 4);
                            if (devType == DBT_DEVTYP_VOLUME)
                            {
                                DevBroadcastVolume vol;
                                vol = (DevBroadcastVolume)
                                    Marshal.PtrToStructure(m.LParam,
                                    typeof(DevBroadcastVolume));
                                listBox1.Items.Add("Mask is " + vol.Mask);
                            }

                            break;

                        case DBT_DEVICEREMOVECOMPLETE:
                            listBox1.Items.Add("Device Removed");
                            break;

                    }
                    break;
            }

        }

        public static void PrintUsbDevices()
        {
            IList<ManagementBaseObject> usbDevices = GetUsbDevices();

            foreach (ManagementBaseObject usbDevice in usbDevices)
            {
                Console.WriteLine("----- DEVICE -----");
                foreach (var property in usbDevice.Properties)
                {
                    Console.WriteLine(string.Format("{0}: {1}", property.Name, property.Value));
                }
                Console.WriteLine("------------------");
            }
        }

        public static IList<ManagementBaseObject> GetUsbDevices()
        {
            IList<string> usbDeviceAddresses = LookUpUsbDeviceAddresses();

            List<ManagementBaseObject> usbDevices = new List<ManagementBaseObject>();

            foreach (string usbDeviceAddress in usbDeviceAddresses)
            {
                // query MI for the PNP device info
                // address must be escaped to be used in the query; luckily, the form we extracted previously is already escaped
                ManagementObjectCollection curMoc = QueryMi("Select * from Win32_PnPEntity where PNPDeviceID = " + usbDeviceAddress);
                foreach (ManagementBaseObject device in curMoc)
                {
                    usbDevices.Add(device);
                }
            }

            return usbDevices;
        }

        public static IList<string> LookUpUsbDeviceAddresses()
        {
            // this query gets the addressing information for connected USB devices
            ManagementObjectCollection usbDeviceAddressInfo = QueryMi(@"Select * from Win32_USBControllerDevice");

            List<string> usbDeviceAddresses = new List<string>();

            foreach(var device in usbDeviceAddressInfo)
            {
                string curPnpAddress = (string)device.GetPropertyValue("Dependent");
                // split out the address portion of the data; note that this includes escaped backslashes and quotes
                curPnpAddress = curPnpAddress.Split(new String[] { "DeviceID=" }, 2, StringSplitOptions.None)[1];

                usbDeviceAddresses.Add(curPnpAddress);
            }

            return usbDeviceAddresses;
        }

        // btn_chkDevice 클릭 이벤트
        private void Btn_chkDevice_Click(object sender, EventArgs e)
        {
            var usbDevices = GetUSBDevices();

            foreach (var usbDevice in usbDevices)
            {
                Console.WriteLine("Device ID: {0}, PNP Device ID: {1}, Description: {2}",
                    usbDevice.DeviceID, usbDevice.PnpDeviceID, usbDevice.Description);
            }
        }
    }
}
