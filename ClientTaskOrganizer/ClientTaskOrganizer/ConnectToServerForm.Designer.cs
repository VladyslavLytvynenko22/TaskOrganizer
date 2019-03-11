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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBxIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBxPort = new System.Windows.Forms.TextBox();
            this.butConnect = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter IP address";
            // 
            // txtBxIP
            // 
            this.txtBxIP.Location = new System.Drawing.Point(12, 29);
            this.txtBxIP.Name = "txtBxIP";
            this.txtBxIP.Size = new System.Drawing.Size(86, 20);
            this.txtBxIP.TabIndex = 1;
            this.txtBxIP.Text = "192.168.0.110";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(98, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = ":";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Enter port";
            // 
            // txtBxPort
            // 
            this.txtBxPort.Location = new System.Drawing.Point(116, 29);
            this.txtBxPort.Name = "txtBxPort";
            this.txtBxPort.Size = new System.Drawing.Size(50, 20);
            this.txtBxPort.TabIndex = 4;
            this.txtBxPort.Text = "26503";
            // 
            // butConnect
            // 
            this.butConnect.Location = new System.Drawing.Point(181, 29);
            this.butConnect.Name = "butConnect";
            this.butConnect.Size = new System.Drawing.Size(56, 20);
            this.butConnect.TabIndex = 5;
            this.butConnect.Text = "Connect";
            this.butConnect.UseVisualStyleBackColor = true;
            this.butConnect.Click += new System.EventHandler(this.butConnect_Click);
            // 
            // butExit
            // 
            this.butExit.Location = new System.Drawing.Point(181, 6);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(56, 20);
            this.butExit.TabIndex = 6;
            this.butExit.Text = "Exit";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // ConnectToServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 68);
            this.ControlBox = false;
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butConnect);
            this.Controls.Add(this.txtBxPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBxIP);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectToServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect To Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button butConnect;
        public System.Windows.Forms.TextBox txtBxIP;
        public System.Windows.Forms.TextBox txtBxPort;
        public System.Windows.Forms.Button butExit;
    }
}