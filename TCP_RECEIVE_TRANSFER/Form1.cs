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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_RECEIVE_TRANSFER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String IP;
        int port;

        TcpListener Server;
        TcpClient Client;

        StreamReader Reader;
        StreamWriter Writer;

        NetworkStream stream;
        Thread ReceiveThread;

        bool Connected;

        private void button1_Click(object sender, EventArgs e)
        {
            IP = "192.168.219.102"; // 접속 할 서버 아이피를 입력
            port = 8080; // 포트

            Client = new TcpClient();
            Client.Connect(IP, port);

            stream = Client.GetStream();

            Connected = true;

            textBox1.Text += "Connected to Server!\r\n";

            Reader = new StreamReader(stream);
            Writer = new StreamWriter(stream);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(new IPEndPoint(IPAddress.Parse(IP), port));

            try
            {
                byte[] bytes = new byte[1024];

                int nBytes = 0;

                FileStream fs = new FileStream(@"D:\test.txt", FileMode.Create, FileAccess.Write);

                textBox1.Text += "File Recieve START \r\n";

                while ((nBytes = socket.Receive(bytes, bytes.Length, 0)) > 0)
                {
                    fs.Write(bytes, 0, nBytes);
                }

                textBox1.Text += "File Recieve End \r\n";

                fs.Flush();
                fs.Close();
            }
            catch (Exception)
            {
                return;
            }

            socket.Close();
        }
    }
}
