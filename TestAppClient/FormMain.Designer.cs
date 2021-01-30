
namespace TestAppClient
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.lbTCPSettings = new System.Windows.Forms.Label();
            this.btSend = new System.Windows.Forms.Button();
            this.nudMessageId = new System.Windows.Forms.NumericUpDown();
            this.lbMessageToServer = new System.Windows.Forms.Label();
            this.lbMessageId = new System.Windows.Forms.Label();
            this.lbMessage = new System.Windows.Forms.Label();
            this.tbMessage = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMessageId)).BeginInit();
            this.SuspendLayout();
            // 
            // nudPort
            // 
            this.nudPort.Location = new System.Drawing.Point(102, 12);
            this.nudPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(81, 23);
            this.nudPort.TabIndex = 5;
            this.nudPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPort.Value = new decimal(new int[] {
            23456,
            0,
            0,
            0});
            // 
            // lbTCPSettings
            // 
            this.lbTCPSettings.AutoSize = true;
            this.lbTCPSettings.Location = new System.Drawing.Point(12, 14);
            this.lbTCPSettings.Name = "lbTCPSettings";
            this.lbTCPSettings.Size = new System.Drawing.Size(55, 15);
            this.lbTCPSettings.TabIndex = 4;
            this.lbTCPSettings.Text = "TCP port:";
            // 
            // btSend
            // 
            this.btSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSend.Location = new System.Drawing.Point(272, 415);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(75, 23);
            this.btSend.TabIndex = 6;
            this.btSend.Text = "Send >>";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // nudMessageId
            // 
            this.nudMessageId.Location = new System.Drawing.Point(12, 84);
            this.nudMessageId.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudMessageId.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.nudMessageId.Name = "nudMessageId";
            this.nudMessageId.Size = new System.Drawing.Size(120, 23);
            this.nudMessageId.TabIndex = 7;
            // 
            // lbMessageToServer
            // 
            this.lbMessageToServer.AutoSize = true;
            this.lbMessageToServer.Location = new System.Drawing.Point(12, 38);
            this.lbMessageToServer.Name = "lbMessageToServer";
            this.lbMessageToServer.Size = new System.Drawing.Size(104, 15);
            this.lbMessageToServer.TabIndex = 8;
            this.lbMessageToServer.Text = "Message to server:";
            // 
            // lbMessageId
            // 
            this.lbMessageId.AutoSize = true;
            this.lbMessageId.Location = new System.Drawing.Point(12, 66);
            this.lbMessageId.Name = "lbMessageId";
            this.lbMessageId.Size = new System.Drawing.Size(70, 15);
            this.lbMessageId.TabIndex = 9;
            this.lbMessageId.Text = "Message ID:";
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Location = new System.Drawing.Point(12, 110);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(56, 15);
            this.lbMessage.TabIndex = 10;
            this.lbMessage.Text = "Message:";
            // 
            // tbMessage
            // 
            this.tbMessage.AcceptsReturn = true;
            this.tbMessage.AcceptsTab = true;
            this.tbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMessage.Location = new System.Drawing.Point(12, 128);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbMessage.Size = new System.Drawing.Size(335, 281);
            this.tbMessage.TabIndex = 11;
            this.tbMessage.WordWrap = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 450);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.lbMessageId);
            this.Controls.Add(this.lbMessageToServer);
            this.Controls.Add(this.nudMessageId);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.nudPort);
            this.Controls.Add(this.lbTCPSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "TCP client test";
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMessageId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.Label lbTCPSettings;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.NumericUpDown nudMessageId;
        private System.Windows.Forms.Label lbMessageToServer;
        private System.Windows.Forms.Label lbMessageId;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.TextBox tbMessage;
    }
}

