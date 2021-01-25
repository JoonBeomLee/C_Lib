using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_SEND_TRANSFER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string ip;
        int port;

        public TcpListener Server; // 소켓 서버
        public TcpClient Client; // 클라이언트

        public StreamReader Reader;
        public StreamWriter Writer;

        public string sendFilePath = "";

        NetworkStream stream; // 네트워크 스트림 연결

        bool Connected;

        private void button1_Click(object sender, EventArgs e)
        {
            //ip = textBox1.Text;
            //port = textBox2.Text;
            ip = "192.168.219.102";
            port = 8080;

            if(ip == "" || port == 0)
            {
                textBox4.Text += "Please Input Ip or Port \r\n";
                return;
            }


            IPEndPoint ipAddress = new IPEndPoint(IPAddress.Parse(ip), port);

            Server = new TcpListener(ipAddress);

            Server.Start(); // 서버 시작
            Client = Server.AcceptTcpClient(); // 클라이언트 연결 수락

            Connected = true;

            textBox4.Text += "Connect Success \r\n";
            textBox4.Text += $"TCP INFO : {Server} \r\n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select Send File";
            fileDialog.FileName = "";

            DialogResult dialogResult = fileDialog.ShowDialog();

            if(dialogResult == DialogResult.OK)
            {
                sendFilePath = fileDialog.FileName;
            }
            else
            {
                sendFilePath = "";
            }

            textBox3.Text = sendFilePath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] bytes = new byte[1024];
                int nBytes = 0;

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(new IPEndPoint(IPAddress.Parse(ip), port));

                FileStream fs = new FileStream(sendFilePath, FileMode.Open, FileAccess.Read);

                textBox4.Text += $"{sendFilePath} File Upload START \r\n";

                while((nBytes = fs.Read(bytes, 0, bytes.Length)) > 0)
                {
                    textBox4.Text += $"{nBytes}\r\n";
                    socket.Send(bytes, nBytes, 0);
                }

                fs.Close();
                socket.Close();

                textBox4.Text += "File Upload End \r\n";

            }
            catch(Exception)
            {
                textBox4.Text += "Error \r\n";
                return;
            }

        }
    }
}
