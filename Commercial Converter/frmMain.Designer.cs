namespace Commercial_Converter
{
    partial class frmMain
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnFilePicker = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.picSnap = new System.Windows.Forms.PictureBox();
            this.picStatusB = new System.Windows.Forms.PictureBox();
            this.picStatus = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picSnap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatusB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Video Files|*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp4;*.mov;*.mkv;*.flv;*.webm;*" +
    ".WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP4;*.MOV;*.MKV;*.FLV;*.WEBM";
            this.openFileDialog1.Multiselect = true;
            // 
            // btnFilePicker
            // 
            this.btnFilePicker.Location = new System.Drawing.Point(13, 13);
            this.btnFilePicker.Name = "btnFilePicker";
            this.btnFilePicker.Size = new System.Drawing.Size(75, 23);
            this.btnFilePicker.TabIndex = 1;
            this.btnFilePicker.Text = "Select Files";
            this.btnFilePicker.UseVisualStyleBackColor = true;
            this.btnFilePicker.Click += new System.EventHandler(this.btnFilePicker_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(13, 226);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(585, 240);
            this.txtLog.TabIndex = 2;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 197);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lstFiles
            // 
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(12, 43);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(586, 147);
            this.lstFiles.TabIndex = 0;
            // 
            // picSnap
            // 
            this.picSnap.Location = new System.Drawing.Point(604, 13);
            this.picSnap.Name = "picSnap";
            this.picSnap.Size = new System.Drawing.Size(100, 50);
            this.picSnap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSnap.TabIndex = 5;
            this.picSnap.TabStop = false;
            // 
            // picStatusB
            // 
            this.picStatusB.BackColor = System.Drawing.Color.Red;
            this.picStatusB.Location = new System.Drawing.Point(580, 196);
            this.picStatusB.Name = "picStatusB";
            this.picStatusB.Size = new System.Drawing.Size(18, 20);
            this.picStatusB.TabIndex = 52;
            this.picStatusB.TabStop = false;
            this.picStatusB.Tag = "0";
            // 
            // picStatus
            // 
            this.picStatus.BackColor = System.Drawing.Color.Red;
            this.picStatus.Location = new System.Drawing.Point(562, 196);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(18, 20);
            this.picStatus.TabIndex = 51;
            this.picStatus.TabStop = false;
            this.picStatus.Tag = "0";
            this.picStatus.Click += new System.EventHandler(this.picStatus_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(95, 197);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 13);
            this.lblStatus.TabIndex = 53;
            this.lblStatus.Text = "label1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 473);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.picStatusB);
            this.Controls.Add(this.picStatus);
            this.Controls.Add(this.picSnap);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnFilePicker);
            this.Controls.Add(this.lstFiles);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picSnap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatusB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnFilePicker;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.PictureBox picSnap;
        private System.Windows.Forms.PictureBox picStatusB;
        private System.Windows.Forms.PictureBox picStatus;
        private System.Windows.Forms.Label lblStatus;
    }
}

