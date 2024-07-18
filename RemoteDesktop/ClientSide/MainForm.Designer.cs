namespace ClientSide
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            groupBox1 = new GroupBox();
            buttonConnect = new Button();
            textBoxPort = new TextBox();
            textBoxIP = new TextBox();
            label3 = new Label();
            label2 = new Label();
            groupBox2 = new GroupBox();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            buttonTakeScreen = new Button();
            buttonViewScreen = new Button();
            listBox1 = new ListBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(940, 68);
            label1.TabIndex = 0;
            label1.Text = "Client";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonConnect);
            groupBox1.Controls.Add(textBoxPort);
            groupBox1.Controls.Add(textBoxIP);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 71);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(795, 123);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Connect";
            // 
            // buttonConnect
            // 
            buttonConnect.Location = new Point(403, 47);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(152, 47);
            buttonConnect.TabIndex = 4;
            buttonConnect.Text = "Connect";
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += buttonConnect_Click;
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new Point(121, 75);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new Size(258, 31);
            textBoxPort.TabIndex = 3;
            textBoxPort.Text = "8080";
            // 
            // textBoxIP
            // 
            textBoxIP.Location = new Point(121, 33);
            textBoxIP.Name = "textBoxIP";
            textBoxIP.Size = new Size(258, 31);
            textBoxIP.TabIndex = 2;
            textBoxIP.Text = "127.0.0.1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 75);
            label3.Name = "label3";
            label3.Size = new Size(95, 25);
            label3.TabIndex = 1;
            label3.Text = "Enter port:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 36);
            label2.Name = "label2";
            label2.Size = new Size(76, 25);
            label2.TabIndex = 0;
            label2.Text = "Enter IP:";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(pictureBox1);
            groupBox2.Controls.Add(buttonTakeScreen);
            groupBox2.Controls.Add(buttonViewScreen);
            groupBox2.Location = new Point(12, 210);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(916, 351);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Function";
            // 
            // button1
            // 
            button1.Location = new Point(175, 45);
            button1.Name = "button1";
            button1.Size = new Size(428, 34);
            button1.TabIndex = 3;
            button1.Text = "Stop ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(175, 90);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(428, 228);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // buttonTakeScreen
            // 
            buttonTakeScreen.Location = new Point(643, 45);
            buttonTakeScreen.Name = "buttonTakeScreen";
            buttonTakeScreen.Size = new Size(146, 273);
            buttonTakeScreen.TabIndex = 1;
            buttonTakeScreen.Text = "Take a screenshot";
            buttonTakeScreen.UseVisualStyleBackColor = true;
            buttonTakeScreen.Click += buttonTakeScreen_ClickTest;
            // 
            // buttonViewScreen
            // 
            buttonViewScreen.Location = new Point(6, 45);
            buttonViewScreen.Name = "buttonViewScreen";
            buttonViewScreen.Size = new Size(146, 273);
            buttonViewScreen.TabIndex = 0;
            buttonViewScreen.Text = "View Screen";
            buttonViewScreen.UseVisualStyleBackColor = true;
            buttonViewScreen.Click += buttonViewScreen_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(18, 567);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(910, 129);
            listBox1.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(940, 711);
            Controls.Add(listBox1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "Client Side";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Button buttonConnect;
        private TextBox textBoxPort;
        private TextBox textBoxIP;
        private Label label3;
        private Label label2;
        private GroupBox groupBox2;
        private Button buttonViewScreen;
        private Button buttonTakeScreen;
        private PictureBox pictureBox1;
        private Button button1;
        private ListBox listBox1;
    }
}
