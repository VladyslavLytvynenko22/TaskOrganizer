namespace ServerTaskOrganizer
{
    partial class Form1
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
            this.butStarttHost = new System.Windows.Forms.Button();
            this.TextStatus = new System.Windows.Forms.RichTextBox();
            this.butStopHost = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butStarttHost
            // 
            this.butStarttHost.Location = new System.Drawing.Point(200, 12);
            this.butStarttHost.Name = "butStarttHost";
            this.butStarttHost.Size = new System.Drawing.Size(81, 23);
            this.butStarttHost.TabIndex = 0;
            this.butStarttHost.Text = "Start Host";
            this.butStarttHost.UseVisualStyleBackColor = true;
            this.butStarttHost.Click += new System.EventHandler(this.butStartHost_Click);
            // 
            // TextStatus
            // 
            this.TextStatus.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextStatus.Location = new System.Drawing.Point(10, 80);
            this.TextStatus.Name = "TextStatus";
            this.TextStatus.ReadOnly = true;
            this.TextStatus.Size = new System.Drawing.Size(271, 96);
            this.TextStatus.TabIndex = 1;
            this.TextStatus.Text = "";
            // 
            // butStopHost
            // 
            this.butStopHost.Enabled = false;
            this.butStopHost.Location = new System.Drawing.Point(200, 45);
            this.butStopHost.Name = "butStopHost";
            this.butStopHost.Size = new System.Drawing.Size(81, 23);
            this.butStopHost.TabIndex = 2;
            this.butStopHost.Text = "Stop Host";
            this.butStopHost.UseVisualStyleBackColor = true;
            this.butStopHost.Click += new System.EventHandler(this.butStopHost_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(10, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 70);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Your IP and Port";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(172, 45);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 184);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butStopHost);
            this.Controls.Add(this.TextStatus);
            this.Controls.Add(this.butStarttHost);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Host Task Organizer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butStarttHost;
        private System.Windows.Forms.RichTextBox TextStatus;
        private System.Windows.Forms.Button butStopHost;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

