namespace CommanderAardvark
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabI2c = new System.Windows.Forms.TabPage();
            this.pnlI2cCommand = new System.Windows.Forms.Panel();
            this.txtI2cData = new System.Windows.Forms.TextBox();
            this.txtI2cAddr = new System.Windows.Forms.TextBox();
            this.txtI2cDevice = new System.Windows.Forms.TextBox();
            this.btnI2cRead = new System.Windows.Forms.Button();
            this.btnI2cWrite = new System.Windows.Forms.Button();
            this.tabSpi = new System.Windows.Forms.TabPage();
            this.tabMain.SuspendLayout();
            this.tabI2c.SuspendLayout();
            this.pnlI2cCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabI2c);
            this.tabMain.Controls.Add(this.tabSpi);
            this.tabMain.Location = new System.Drawing.Point(13, 13);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(651, 380);
            this.tabMain.TabIndex = 0;
            // 
            // tabI2c
            // 
            this.tabI2c.Controls.Add(this.pnlI2cCommand);
            this.tabI2c.Location = new System.Drawing.Point(4, 22);
            this.tabI2c.Name = "tabI2c";
            this.tabI2c.Padding = new System.Windows.Forms.Padding(3);
            this.tabI2c.Size = new System.Drawing.Size(643, 354);
            this.tabI2c.TabIndex = 0;
            this.tabI2c.Text = "I2C";
            this.tabI2c.UseVisualStyleBackColor = true;
            // 
            // pnlI2cCommand
            // 
            this.pnlI2cCommand.Controls.Add(this.txtI2cData);
            this.pnlI2cCommand.Controls.Add(this.txtI2cAddr);
            this.pnlI2cCommand.Controls.Add(this.txtI2cDevice);
            this.pnlI2cCommand.Controls.Add(this.btnI2cRead);
            this.pnlI2cCommand.Controls.Add(this.btnI2cWrite);
            this.pnlI2cCommand.Location = new System.Drawing.Point(20, 30);
            this.pnlI2cCommand.Name = "pnlI2cCommand";
            this.pnlI2cCommand.Size = new System.Drawing.Size(268, 32);
            this.pnlI2cCommand.TabIndex = 1;
            // 
            // txtI2cData
            // 
            this.txtI2cData.Location = new System.Drawing.Point(67, 3);
            this.txtI2cData.Name = "txtI2cData";
            this.txtI2cData.Size = new System.Drawing.Size(128, 20);
            this.txtI2cData.TabIndex = 1;
            this.txtI2cData.Text = "04";
            // 
            // txtI2cAddr
            // 
            this.txtI2cAddr.Location = new System.Drawing.Point(35, 3);
            this.txtI2cAddr.Name = "txtI2cAddr";
            this.txtI2cAddr.Size = new System.Drawing.Size(26, 20);
            this.txtI2cAddr.TabIndex = 1;
            this.txtI2cAddr.Text = "00";
            // 
            // txtI2cDevice
            // 
            this.txtI2cDevice.Location = new System.Drawing.Point(3, 3);
            this.txtI2cDevice.Name = "txtI2cDevice";
            this.txtI2cDevice.Size = new System.Drawing.Size(26, 20);
            this.txtI2cDevice.TabIndex = 1;
            this.txtI2cDevice.Text = "A6";
            // 
            // btnI2cRead
            // 
            this.btnI2cRead.Location = new System.Drawing.Point(232, 1);
            this.btnI2cRead.Name = "btnI2cRead";
            this.btnI2cRead.Size = new System.Drawing.Size(25, 23);
            this.btnI2cRead.TabIndex = 0;
            this.btnI2cRead.Text = "R";
            this.btnI2cRead.UseVisualStyleBackColor = true;
            this.btnI2cRead.Click += new System.EventHandler(this.btnI2cRead_Click);
            // 
            // btnI2cWrite
            // 
            this.btnI2cWrite.Location = new System.Drawing.Point(201, 1);
            this.btnI2cWrite.Name = "btnI2cWrite";
            this.btnI2cWrite.Size = new System.Drawing.Size(25, 23);
            this.btnI2cWrite.TabIndex = 0;
            this.btnI2cWrite.Text = "W";
            this.btnI2cWrite.UseVisualStyleBackColor = true;
            this.btnI2cWrite.Click += new System.EventHandler(this.btnI2cWrite_Click);
            // 
            // tabSpi
            // 
            this.tabSpi.Location = new System.Drawing.Point(4, 22);
            this.tabSpi.Name = "tabSpi";
            this.tabSpi.Padding = new System.Windows.Forms.Padding(3);
            this.tabSpi.Size = new System.Drawing.Size(643, 354);
            this.tabSpi.TabIndex = 1;
            this.tabSpi.Text = "SPI";
            this.tabSpi.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 405);
            this.Controls.Add(this.tabMain);
            this.Name = "frmMain";
            this.Text = "Aardvark Commander";
            this.tabMain.ResumeLayout(false);
            this.tabI2c.ResumeLayout(false);
            this.pnlI2cCommand.ResumeLayout(false);
            this.pnlI2cCommand.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabI2c;
        private System.Windows.Forms.TabPage tabSpi;
        private System.Windows.Forms.Panel pnlI2cCommand;
        private System.Windows.Forms.TextBox txtI2cDevice;
        private System.Windows.Forms.Button btnI2cWrite;
        private System.Windows.Forms.TextBox txtI2cAddr;
        private System.Windows.Forms.TextBox txtI2cData;
        private System.Windows.Forms.Button btnI2cRead;
    }
}

