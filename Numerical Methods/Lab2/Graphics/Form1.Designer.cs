namespace Graphics
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
            this.graphicPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.gaussCheckBox = new System.Windows.Forms.CheckBox();
            this.nyuthonCheckBox = new System.Windows.Forms.CheckBox();
            this.originalCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.graphicPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // graphicPictureBox
            // 
            this.graphicPictureBox.Location = new System.Drawing.Point(50, 30);
            this.graphicPictureBox.Name = "graphicPictureBox";
            this.graphicPictureBox.Size = new System.Drawing.Size(500, 500);
            this.graphicPictureBox.TabIndex = 0;
            this.graphicPictureBox.TabStop = false;
            this.graphicPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.graphicPictureBox_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(20, 506);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(20, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(46, 543);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(530, 543);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(280, 543);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 24);
            this.label6.TabIndex = 6;
            this.label6.Text = "2";
            // 
            // refreshButton
            // 
            this.refreshButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.refreshButton.Location = new System.Drawing.Point(578, 461);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(133, 69);
            this.refreshButton.TabIndex = 7;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // gaussCheckBox
            // 
            this.gaussCheckBox.AutoSize = true;
            this.gaussCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gaussCheckBox.Location = new System.Drawing.Point(578, 255);
            this.gaussCheckBox.Name = "gaussCheckBox";
            this.gaussCheckBox.Size = new System.Drawing.Size(82, 28);
            this.gaussCheckBox.TabIndex = 8;
            this.gaussCheckBox.Text = "Gauss";
            this.gaussCheckBox.UseVisualStyleBackColor = true;
            // 
            // nyuthonCheckBox
            // 
            this.nyuthonCheckBox.AutoSize = true;
            this.nyuthonCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nyuthonCheckBox.Location = new System.Drawing.Point(578, 134);
            this.nyuthonCheckBox.Name = "nyuthonCheckBox";
            this.nyuthonCheckBox.Size = new System.Drawing.Size(100, 28);
            this.nyuthonCheckBox.TabIndex = 9;
            this.nyuthonCheckBox.Text = "Nyuthon";
            this.nyuthonCheckBox.UseVisualStyleBackColor = true;
            // 
            // originalCheckBox
            // 
            this.originalCheckBox.AutoSize = true;
            this.originalCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.originalCheckBox.Location = new System.Drawing.Point(578, 391);
            this.originalCheckBox.Name = "originalCheckBox";
            this.originalCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.originalCheckBox.Size = new System.Drawing.Size(94, 28);
            this.originalCheckBox.TabIndex = 10;
            this.originalCheckBox.Text = "Original";
            this.originalCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 576);
            this.Controls.Add(this.originalCheckBox);
            this.Controls.Add(this.nyuthonCheckBox);
            this.Controls.Add(this.gaussCheckBox);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.graphicPictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.graphicPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox graphicPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.CheckBox gaussCheckBox;
        private System.Windows.Forms.CheckBox nyuthonCheckBox;
        private System.Windows.Forms.CheckBox originalCheckBox;
    }
}

