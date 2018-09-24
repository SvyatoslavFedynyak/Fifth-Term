namespace Lab_4
{
    partial class MainWindow
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
            this.AddWindowButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NumberOfWindowsTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AddWindowButton
            // 
            this.AddWindowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddWindowButton.Location = new System.Drawing.Point(46, 36);
            this.AddWindowButton.Name = "AddWindowButton";
            this.AddWindowButton.Size = new System.Drawing.Size(386, 62);
            this.AddWindowButton.TabIndex = 0;
            this.AddWindowButton.Text = "Add new window";
            this.AddWindowButton.UseVisualStyleBackColor = true;
            this.AddWindowButton.Click += new System.EventHandler(this.AddWindowButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(41, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current number of windows";
            // 
            // NumberOfWindowsTextBox
            // 
            this.NumberOfWindowsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumberOfWindowsTextBox.Location = new System.Drawing.Point(362, 126);
            this.NumberOfWindowsTextBox.Name = "NumberOfWindowsTextBox";
            this.NumberOfWindowsTextBox.Size = new System.Drawing.Size(70, 38);
            this.NumberOfWindowsTextBox.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 196);
            this.Controls.Add(this.NumberOfWindowsTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddWindowButton);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddWindowButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NumberOfWindowsTextBox;
    }
}

