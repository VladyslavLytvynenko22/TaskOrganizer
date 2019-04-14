namespace ServerTaskOrganizer
{
    partial class HostTaskOrganizer
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxStatus = new System.Windows.Forms.RichTextBox();
            this.grBoxIPandPort = new System.Windows.Forms.GroupBox();
            this.butStopHost = new System.Windows.Forms.Button();
            this.butStarttHost = new System.Windows.Forms.Button();
            this.richTeBoxIPandPort = new System.Windows.Forms.RichTextBox();
            this.grBoxConnectDatabaseName = new System.Windows.Forms.GroupBox();
            this.textBoxServerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.texBoxTableName = new System.Windows.Forms.TextBox();
            this.butSaveConnectDatabaseName = new System.Windows.Forms.Button();
            this.teBoxDatabeseName = new System.Windows.Forms.TextBox();
            this.grBoxIPandPort.SuspendLayout();
            this.grBoxConnectDatabaseName.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxStatus.Location = new System.Drawing.Point(10, 220);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(272, 96);
            this.textBoxStatus.TabIndex = 1;
            this.textBoxStatus.Text = "";
            // 
            // grBoxIPandPort
            // 
            this.grBoxIPandPort.Controls.Add(this.butStopHost);
            this.grBoxIPandPort.Controls.Add(this.butStarttHost);
            this.grBoxIPandPort.Controls.Add(this.richTeBoxIPandPort);
            this.grBoxIPandPort.Location = new System.Drawing.Point(10, 4);
            this.grBoxIPandPort.Name = "grBoxIPandPort";
            this.grBoxIPandPort.Size = new System.Drawing.Size(271, 78);
            this.grBoxIPandPort.TabIndex = 5;
            this.grBoxIPandPort.TabStop = false;
            this.grBoxIPandPort.Text = "Your IP and Port";
            // 
            // butStopHost
            // 
            this.butStopHost.Enabled = false;
            this.butStopHost.Location = new System.Drawing.Point(184, 42);
            this.butStopHost.Name = "butStopHost";
            this.butStopHost.Size = new System.Drawing.Size(81, 32);
            this.butStopHost.TabIndex = 10;
            this.butStopHost.Text = "Stop Host";
            this.butStopHost.UseVisualStyleBackColor = true;
            this.butStopHost.Click += new System.EventHandler(this.butStopHost_Click);
            // 
            // butStarttHost
            // 
            this.butStarttHost.Location = new System.Drawing.Point(184, 9);
            this.butStarttHost.Name = "butStarttHost";
            this.butStarttHost.Size = new System.Drawing.Size(81, 32);
            this.butStarttHost.TabIndex = 9;
            this.butStarttHost.Text = "Start Host";
            this.butStarttHost.UseVisualStyleBackColor = true;
            this.butStarttHost.Click += new System.EventHandler(this.butStartHost_Click);
            // 
            // richTeBoxIPandPort
            // 
            this.richTeBoxIPandPort.Location = new System.Drawing.Point(6, 15);
            this.richTeBoxIPandPort.Name = "richTeBoxIPandPort";
            this.richTeBoxIPandPort.ReadOnly = true;
            this.richTeBoxIPandPort.Size = new System.Drawing.Size(172, 57);
            this.richTeBoxIPandPort.TabIndex = 8;
            this.richTeBoxIPandPort.Text = "";
            // 
            // grBoxConnectDatabaseName
            // 
            this.grBoxConnectDatabaseName.Controls.Add(this.textBoxServerName);
            this.grBoxConnectDatabaseName.Controls.Add(this.label3);
            this.grBoxConnectDatabaseName.Controls.Add(this.label2);
            this.grBoxConnectDatabaseName.Controls.Add(this.label1);
            this.grBoxConnectDatabaseName.Controls.Add(this.texBoxTableName);
            this.grBoxConnectDatabaseName.Controls.Add(this.butSaveConnectDatabaseName);
            this.grBoxConnectDatabaseName.Controls.Add(this.teBoxDatabeseName);
            this.grBoxConnectDatabaseName.Location = new System.Drawing.Point(10, 84);
            this.grBoxConnectDatabaseName.Name = "grBoxConnectDatabaseName";
            this.grBoxConnectDatabaseName.Size = new System.Drawing.Size(271, 130);
            this.grBoxConnectDatabaseName.TabIndex = 8;
            this.grBoxConnectDatabaseName.TabStop = false;
            this.grBoxConnectDatabaseName.Text = "Connect database";
            // 
            // textBoxServerName
            // 
            this.textBoxServerName.Location = new System.Drawing.Point(9, 29);
            this.textBoxServerName.Name = "textBoxServerName";
            this.textBoxServerName.Size = new System.Drawing.Size(169, 20);
            this.textBoxServerName.TabIndex = 14;
            this.textBoxServerName.Text = "SQLEXPRESS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Database Table name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Database name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Server name";
            // 
            // texBoxTableName
            // 
            this.texBoxTableName.Location = new System.Drawing.Point(9, 100);
            this.texBoxTableName.Name = "texBoxTableName";
            this.texBoxTableName.Size = new System.Drawing.Size(169, 20);
            this.texBoxTableName.TabIndex = 10;
            this.texBoxTableName.Text = "TableTaskOrganizer";
            // 
            // butSaveConnectDatabaseName
            // 
            this.butSaveConnectDatabaseName.Location = new System.Drawing.Point(184, 29);
            this.butSaveConnectDatabaseName.Name = "butSaveConnectDatabaseName";
            this.butSaveConnectDatabaseName.Size = new System.Drawing.Size(81, 91);
            this.butSaveConnectDatabaseName.TabIndex = 9;
            this.butSaveConnectDatabaseName.Text = "Save";
            this.butSaveConnectDatabaseName.UseVisualStyleBackColor = true;
            this.butSaveConnectDatabaseName.Click += new System.EventHandler(this.butSaveConnectDatabaseName_Click);
            // 
            // teBoxDatabeseName
            // 
            this.teBoxDatabeseName.Location = new System.Drawing.Point(9, 64);
            this.teBoxDatabeseName.Name = "teBoxDatabeseName";
            this.teBoxDatabeseName.Size = new System.Drawing.Size(169, 20);
            this.teBoxDatabeseName.TabIndex = 8;
            this.teBoxDatabeseName.Text = "DbTaskOrganizer";
            // 
            // HostTaskOrganizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 325);
            this.Controls.Add(this.grBoxConnectDatabaseName);
            this.Controls.Add(this.grBoxIPandPort);
            this.Controls.Add(this.textBoxStatus);
            this.Name = "HostTaskOrganizer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Host Task Organizer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HostTaskOrganizer_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grBoxIPandPort.ResumeLayout(false);
            this.grBoxConnectDatabaseName.ResumeLayout(false);
            this.grBoxConnectDatabaseName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grBoxIPandPort;
        private System.Windows.Forms.RichTextBox richTeBoxIPandPort;
        private System.Windows.Forms.RichTextBox textBoxStatus;
        private System.Windows.Forms.GroupBox grBoxConnectDatabaseName;
        private System.Windows.Forms.TextBox teBoxDatabeseName;
        private System.Windows.Forms.Button butStopHost;
        protected System.Windows.Forms.Button butStarttHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox texBoxTableName;
        private System.Windows.Forms.Button butSaveConnectDatabaseName;
        private System.Windows.Forms.TextBox textBoxServerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

