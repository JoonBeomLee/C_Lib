
namespace USB_TRANSFER
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_closePort = new System.Windows.Forms.Button();
            this.btn_openPort = new System.Windows.Forms.Button();
            this.cmb_parityBits = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_stopBits = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_dataBits = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_baudRate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_portName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.txt_send = new System.Windows.Forms.TextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_closePort);
            this.groupBox1.Controls.Add(this.btn_openPort);
            this.groupBox1.Controls.Add(this.cmb_parityBits);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmb_stopBits);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmb_dataBits);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmb_baudRate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmb_portName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 295);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Property";
            // 
            // btn_closePort
            // 
            this.btn_closePort.Location = new System.Drawing.Point(104, 233);
            this.btn_closePort.Name = "btn_closePort";
            this.btn_closePort.Size = new System.Drawing.Size(75, 23);
            this.btn_closePort.TabIndex = 12;
            this.btn_closePort.Text = "Close Port";
            this.btn_closePort.UseVisualStyleBackColor = true;
            // 
            // btn_openPort
            // 
            this.btn_openPort.Location = new System.Drawing.Point(23, 233);
            this.btn_openPort.Name = "btn_openPort";
            this.btn_openPort.Size = new System.Drawing.Size(75, 23);
            this.btn_openPort.TabIndex = 11;
            this.btn_openPort.Text = "Open Port";
            this.btn_openPort.UseVisualStyleBackColor = true;
            // 
            // cmb_parityBits
            // 
            this.cmb_parityBits.FormattingEnabled = true;
            this.cmb_parityBits.Location = new System.Drawing.Point(76, 183);
            this.cmb_parityBits.Name = "cmb_parityBits";
            this.cmb_parityBits.Size = new System.Drawing.Size(121, 20);
            this.cmb_parityBits.TabIndex = 10;
            this.cmb_parityBits.Text = "None";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "Parity Bits";
            // 
            // cmb_stopBits
            // 
            this.cmb_stopBits.FormattingEnabled = true;
            this.cmb_stopBits.Location = new System.Drawing.Point(76, 147);
            this.cmb_stopBits.Name = "cmb_stopBits";
            this.cmb_stopBits.Size = new System.Drawing.Size(121, 20);
            this.cmb_stopBits.TabIndex = 8;
            this.cmb_stopBits.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Stop Bits";
            // 
            // cmb_dataBits
            // 
            this.cmb_dataBits.FormattingEnabled = true;
            this.cmb_dataBits.Location = new System.Drawing.Point(76, 111);
            this.cmb_dataBits.Name = "cmb_dataBits";
            this.cmb_dataBits.Size = new System.Drawing.Size(121, 20);
            this.cmb_dataBits.TabIndex = 6;
            this.cmb_dataBits.Text = "8";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data Bits";
            // 
            // cmb_baudRate
            // 
            this.cmb_baudRate.FormattingEnabled = true;
            this.cmb_baudRate.Location = new System.Drawing.Point(76, 76);
            this.cmb_baudRate.Name = "cmb_baudRate";
            this.cmb_baudRate.Size = new System.Drawing.Size(121, 20);
            this.cmb_baudRate.TabIndex = 4;
            this.cmb_baudRate.Text = "9600";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Baud Rate";
            // 
            // cmb_portName
            // 
            this.cmb_portName.FormattingEnabled = true;
            this.cmb_portName.Location = new System.Drawing.Point(76, 40);
            this.cmb_portName.Name = "cmb_portName";
            this.cmb_portName.Size = new System.Drawing.Size(121, 20);
            this.cmb_portName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_log);
            this.groupBox2.Controls.Add(this.txt_send);
            this.groupBox2.Controls.Add(this.btn_send);
            this.groupBox2.Location = new System.Drawing.Point(221, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 295);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Terminal";
            // 
            // txt_log
            // 
            this.txt_log.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_log.Location = new System.Drawing.Point(6, 147);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.Size = new System.Drawing.Size(242, 142);
            this.txt_log.TabIndex = 15;
            // 
            // txt_send
            // 
            this.txt_send.Location = new System.Drawing.Point(6, 20);
            this.txt_send.Multiline = true;
            this.txt_send.Name = "txt_send";
            this.txt_send.Size = new System.Drawing.Size(242, 92);
            this.txt_send.TabIndex = 14;
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(173, 118);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 13;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 335);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_closePort;
        private System.Windows.Forms.Button btn_openPort;
        private System.Windows.Forms.ComboBox cmb_parityBits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_stopBits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_dataBits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_baudRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_portName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox txt_send;
        private System.Windows.Forms.TextBox txt_log;
    }
}
    

