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
using System.IO.Ports;

namespace USB_TRANSFER
{
    public partial class Form1 : Form
    {
        // SerialPort에 데이터가 들어갈 때
        // DataReceieved EventHandler 에 필요한 중요한개념입니다.
        delegate void SetTextCallback(string Text);

        // port 
        SerialPort myPort = new SerialPort();
        public Form1()
        {
            InitializeComponent();

            // 사용 가능 포트 list -> comboList
            getAvailablePort();

            // eventListner 등록
            this.btn_openPort.Click += btnClick_openPort;
            this.btn_closePort.Click += btnClick_closePort;
            this.btn_send.Click += btnSend_click;
        }

        // 사용 가능 포트 list
        public void getAvailablePort()
        {
            string[] ports = SerialPort.GetPortNames();         //사용가능한 포트를 받아와서
            cmb_portName.Items.AddRange(ports);                    //ComPort 콤보박스에 리스트로 추가
        }

        // open Port click 이벤트
        private void btnClick_openPort(object sender, EventArgs e)
        {
            try
            {
                // port 속성값 없을시 예외처리
                if (cmb_portName.Text == "" || cmb_baudRate.Text == "" || cmb_dataBits.Text == "")
                {
                    txt_log.Text += "포트 속성 입력 필요\r\n";
                }
                //속성값 입력시
                else
                {
                    myPort.PortName = cmb_portName.Text;
                    myPort.BaudRate = Convert.ToInt32(cmb_baudRate.Text);   //콤보박스에 있는 데이터는 문자이기때문에 Int로 형변환
                    myPort.DataBits = 8;                //기본 데이터 비트 지정
                    myPort.StopBits = StopBits.One;     //기본 스탑비트 지정
                    myPort.Parity = Parity.None;        //기본 패리티 비트 지정
                    myPort.Open();                      //선택한 serialPort 오픈

                    btn_send.Enabled = true;                 // send 버튼 Enable
                    txt_send.Enabled = true;
                    btn_openPort.Enabled = false;
                    btn_closePort.Enabled = true;

                    txt_log.Text += $"{myPort.PortName} 연결\r\n";
                }
            }
            catch (UnauthorizedAccessException)      //접근 불가 예외처리
            {
                txt_log.Text += $"{myPort.PortName} 접근 불가\r\n";
            }
        }

        // close Port click 이벤트
        private void btnClick_closePort(object sender, EventArgs e) //Close Port 버튼시 발생하는 이벤트
        {
            myPort.Close();        //사용중인 Port Close

            btn_send.Enabled = false;
            btn_openPort.Enabled = true;
            btn_closePort.Enabled = false;
            txt_send.Enabled = false;
        }

        // send click 이벤트
        private void btnSend_click(object sender, EventArgs e)
        {
            if (myPort.IsOpen)
            {
                try
                {
                    byte[] values = new byte[1024];
                    values = Encoding.UTF8.GetBytes(txt_send.Text);

                    txt_log.Text += $"SEND :: {txt_send.Text} \r\n";
                }
                catch
                {
                    txt_log.Text += "유효한 값이 아닙니다. \r\n";
                    return;
                }

                myPort.Write(txt_send.Text);               // Send 텍스트 상자에 있는값을 serial포트에 저장    

                // clear send box
                txt_send.Text = "";
            }
        }

        // data recieve
        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (myPort.IsOpen)
            {
                string data = myPort.ReadExisting();   //serial포트에 있는 데이터를 불러와서 변수 저장

                if (data != string.Empty)
                {
                    char[] values = data.ToCharArray();
                    int value = Convert.ToInt32(values[0]);
                    DataProcessing(data);
                }
            }
        }

        // 통신 data 전처리
        private void DataProcessing(string Text)
        {
            if (this.txt_log.InvokeRequired)
            {
                SetTextCallback dp = new SetTextCallback(DataProcessing);
                this.Invoke(dp, new object[] { Text }); //콜벡한 대이터를 변환
            }
            else
            {
                this.txt_log.Text += $"\r\n\tRECIEVE :: {Text} \r\n";
            }
        }
    }
}
