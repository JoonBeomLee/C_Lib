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

        // selected USB INFO
        public string usbPath;

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

        // SEARCH DEVICE INFO
        static List<USBDeviceInfo> GetUSBDevices()
        {
            List<USBDeviceInfo> devices = new List<USBDeviceInfo>();

            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_PnPEntity where DeviceID Like ""USB%"""))
                collection = searcher.Get();

            foreach (var device in collection)
            {
                devices.Add(new USBDeviceInfo(
                    (string)device.GetPropertyValue("DeviceID"),
                    (string)device.GetPropertyValue("PNPDeviceID"),
                    (string)device.GetPropertyValue("Description")
                ));
            }

            collection.Dispose();
            return devices;
        }

        // btn_chkDevice 클릭 이벤트
        private void btn_connectInfo_Click(object sender, EventArgs e)
        {
            var usbDevices = GetUSBDevices();

            listView1.Items.Clear();

            foreach (var usbDevice in usbDevices)
            {
                // console log
                Console.WriteLine("Device ID: {0}, PNP Device ID: {1}, Description: {2}",
                    usbDevice.DeviceID, usbDevice.PnpDeviceID, usbDevice.Description);

                // listView
                string[] info = new string[] { usbDevice.DeviceID, usbDevice.PnpDeviceID, usbDevice.Description };
                ListViewItem tmpItem = new ListViewItem(info);

                listView1.Items.Add(tmpItem);
             }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // device 정보 하나만 선택 가능
            bool selected = listView1.SelectedItems.Count > 0;

            // 다중 선택 -> 함수 종료
            if (selected == false) return;

            ListViewItem lvi = listView1.SelectedItems[0];

            textBox1.Text = "";

            textBox1.Text += $"Device ID :: {lvi.SubItems[0].Text}\r\n";
            textBox1.Text += $"PNP Device ID :: {lvi.SubItems[1].Text}\r\n";
            textBox1.Text += $"Description :: {lvi.SubItems[2].Text}\r\n";

            usbPath = d
        }

        // file browser 오픈
        private void button1_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog1.FileName;

                //Read the contents of the file into a stream
                var fileStream = openFileDialog1.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
            }

            Console.WriteLine($"File Path : {filePath}\n");
        }
    }

    // DEVICE INFO CLASS
    class USBDeviceInfo
    {
        public USBDeviceInfo(string deviceID, string pnpDeviceID, string description)
        {
            this.DeviceID = deviceID;
            this.PnpDeviceID = pnpDeviceID;
            this.Description = description;
        }
        public string DeviceID { get; private set; }
        public string PnpDeviceID { get; private set; }
        public string Description { get; private set; }
    }
}
