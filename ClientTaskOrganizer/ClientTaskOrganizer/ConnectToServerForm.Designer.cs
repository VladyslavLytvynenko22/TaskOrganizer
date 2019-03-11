namespace ClientTaskOrganizer
{
    partial class ConnectToServerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.butConnect = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBxPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBxIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBoxNameDataBases = new System.Windows.Forms.TextBox();
            this.txtBoxNameTableDataBases = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // butConnect
            // 
            this.butConnect.Location = new System.Drawing.Point(12, 173);
            this.butConnect.Name = "butConnect";
            this.butConnect.Size = new System.Drawing.Size(71, 27);
            this.butConnect.TabIndex = 5;
            this.butConnect.Text = "Connect";
            this.butConnect.UseVisualStyleBackColor = true;
            this.butConnect.Click += new System.EventHandler(this.butConnect_Click);
            // 
            // butExit
            // 
            this.butExit.Location = new System.Drawing.Point(103, 173);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(77, 27);
            this.butExit.TabIndex = 6;
            this.butExit.Text = "Exit";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBxPort);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBxIP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 58);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // txtBxPort
            // 
            this.txtBxPort.Location = new System.Drawing.Point(111, 31);
            this.txtBxPort.Name = "txtBxPort";
            this.txtBxPort.Size = new System.Drawing.Size(50, 20);
            this.txtBxPort.TabIndex = 9;
            this.txtBxPort.Text = "1000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Enter port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(93, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = ":";
            // 
            // txtBxIP
            // 
            this.txtBxIP.Location = new System.Drawing.Point(7, 31);
            this.txtBxIP.Name = "txtBxIP";
            this.txtBxIP.Size = new System.Drawing.Size(86, 20);
            this.txtBxIP.TabIndex = 6;
            this.txtBxIP.Text = "192.168.0.110";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter IP address";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBoxNameTableDataBases);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtBoxNameDataBases);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(12, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(168, 100);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Enter name table DataBases";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Enter name DataBases";
            // 
            // txtBoxNameDataBases
            // 
            this.txtBoxNameDataBases.Location = new System.Drawing.Point(7, 32);
            this.txtBoxNameDataBases.Name = "txtBoxNameDataBases";
            this.txtBoxNameDataBases.Size = new System.Drawing.Size(154, 20);
            this.txtBoxNameDataBases.TabIndex = 11;
            this.txtBoxNameDataBases.Text = "SQLEXPRESS";
            // 
            // txtBoxNameTableDataBases
            // 
            this.txtBoxNameTableDataBases.Location = new System.Drawing.Point(7, 72);
            this.txtBoxNameTableDataBases.Name = "txtBoxNameTableDataBases";
            this.txtBoxNameTableDataBases.Size = new System.Drawing.Size(154, 20);
            this.txtBoxNameTableDataBases.TabIndex = 13;
            this.txtBoxNameTableDataBases.Text = "DbOrganizer";
            // 
            // ConnectToServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 209);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butConnect);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectToServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect To Server";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button butConnect;
        public System.Windows.Forms.Button butExit;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txtBxPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtBxIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtBoxNameTableDataBases;
        public System.Windows.Forms.TextBox txtBoxNameDataBases;
    }
}