
namespace TestAppServer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btStartListener = new System.Windows.Forms.Button();
            this.lbTCPSettings = new System.Windows.Forms.Label();
            this.tbMessages = new System.Windows.Forms.TextBox();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lbLog = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btStartListener
            // 
            this.btStartListener.Location = new System.Drawing.Point(188, 12);
            this.btStartListener.Name = "btStartListener";
            this.btStartListener.Size = new System.Drawing.Size(75, 23);
            this.btStartListener.TabIndex = 0;
            this.btStartListener.Text = "Start listener";
            this.btStartListener.UseVisualStyleBackColor = true;
            this.btStartListener.Click += new System.EventHandler(this.btStartListener_Click);
            // 
            // lbTCPSettings
            // 
            this.lbTCPSettings.AutoSize = true;
            this.lbTCPSettings.Location = new System.Drawing.Point(12, 14);
            this.lbTCPSettings.Name = "lbTCPSettings";
            this.lbTCPSettings.Size = new System.Drawing.Size(55, 15);
            this.lbTCPSettings.TabIndex = 1;
            this.lbTCPSettings.Text = "TCP port:";
            // 
            // tbMessages
            // 
            this.tbMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMessages.Location = new System.Drawing.Point(12, 56);
            this.tbMessages.Multiline = true;
            this.tbMessages.Name = "tbMessages";
            this.tbMessages.ReadOnly = true;
            this.tbMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbMessages.Size = new System.Drawing.Size(397, 382);
            this.tbMessages.TabIndex = 2;
            this.tbMessages.WordWrap = false;
            // 
            // nudPort
            // 
            this.nudPort.Location = new System.Drawing.Point(101, 12);
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
            this.nudPort.TabIndex = 3;
            this.nudPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPort.Value = new decimal(new int[] {
            23456,
            0,
            0,
            0});
            // 
            // lbLog
            // 
            this.lbLog.AutoSize = true;
            this.lbLog.Location = new System.Drawing.Point(12, 38);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(30, 15);
            this.lbLog.TabIndex = 4;
            this.lbLog.Text = "Log:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 450);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.nudPort);
            this.Controls.Add(this.tbMessages);
            this.Controls.Add(this.lbTCPSettings);
            this.Controls.Add(this.btStartListener);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "TCP server test application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btStartListener;
        private System.Windows.Forms.Label lbTCPSettings;
        private System.Windows.Forms.TextBox tbMessages;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label lbLog;
    }
}

