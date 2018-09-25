namespace GraphicalView
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
            this.MaketPictureBox = new System.Windows.Forms.PictureBox();
            this.ProectionPictureBox = new System.Windows.Forms.PictureBox();
            this.AngleTextBox = new System.Windows.Forms.TextBox();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MaketPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProectionPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MaketPictureBox
            // 
            this.MaketPictureBox.Location = new System.Drawing.Point(31, 27);
            this.MaketPictureBox.Name = "MaketPictureBox";
            this.MaketPictureBox.Size = new System.Drawing.Size(320, 211);
            this.MaketPictureBox.TabIndex = 0;
            this.MaketPictureBox.TabStop = false;
            // 
            // ProectionPictureBox
            // 
            this.ProectionPictureBox.Location = new System.Drawing.Point(22, 285);
            this.ProectionPictureBox.Name = "ProectionPictureBox";
            this.ProectionPictureBox.Size = new System.Drawing.Size(500, 250);
            this.ProectionPictureBox.TabIndex = 1;
            this.ProectionPictureBox.TabStop = false;
            // 
            // AngleTextBox
            // 
            this.AngleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AngleTextBox.Location = new System.Drawing.Point(375, 100);
            this.AngleTextBox.Name = "AngleTextBox";
            this.AngleTextBox.Size = new System.Drawing.Size(125, 38);
            this.AngleTextBox.TabIndex = 2;
            // 
            // GenerateButton
            // 
            this.GenerateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GenerateButton.Location = new System.Drawing.Point(375, 168);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(125, 48);
            this.GenerateButton.TabIndex = 3;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(403, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Angle";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 560);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.AngleTextBox);
            this.Controls.Add(this.ProectionPictureBox);
            this.Controls.Add(this.MaketPictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.MaketPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProectionPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MaketPictureBox;
        private System.Windows.Forms.PictureBox ProectionPictureBox;
        private System.Windows.Forms.TextBox AngleTextBox;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.Label label1;
    }
}

