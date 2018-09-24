namespace Lab_4
{
    partial class ThreadWindow
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
            this.ResumeButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.NumbersTestBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ResumeButton
            // 
            this.ResumeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResumeButton.Location = new System.Drawing.Point(78, 153);
            this.ResumeButton.Name = "ResumeButton";
            this.ResumeButton.Size = new System.Drawing.Size(185, 70);
            this.ResumeButton.TabIndex = 0;
            this.ResumeButton.Text = "Resume";
            this.ResumeButton.UseVisualStyleBackColor = true;
            this.ResumeButton.Click += new System.EventHandler(this.ResumeButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StopButton.Location = new System.Drawing.Point(342, 153);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(185, 70);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // NumbersTestBox
            // 
            this.NumbersTestBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumbersTestBox.Location = new System.Drawing.Point(145, 61);
            this.NumbersTestBox.Name = "NumbersTestBox";
            this.NumbersTestBox.Size = new System.Drawing.Size(325, 38);
            this.NumbersTestBox.TabIndex = 2;
            // 
            // ThreadWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 263);
            this.Controls.Add(this.NumbersTestBox);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.ResumeButton);
            this.Name = "ThreadWindow";
            this.Text = "ThreadWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThreadWindow_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ThreadWindow_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ResumeButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.TextBox NumbersTestBox;
    }
}