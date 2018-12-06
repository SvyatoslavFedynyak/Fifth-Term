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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.calcualteButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.epsTextBox = new System.Windows.Forms.TextBox();
            this.accurancyTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.originalRadioButton = new System.Windows.Forms.RadioButton();
            this.newthonRadioButton = new System.Windows.Forms.RadioButton();
            this.gausRadioButton = new System.Windows.Forms.RadioButton();
            this.lqRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).BeginInit();
            this.SuspendLayout();
            // 
            // mainChart
            // 
            chartArea9.Name = "ChartArea1";
            this.mainChart.ChartAreas.Add(chartArea9);
            legend9.Name = "Legend1";
            this.mainChart.Legends.Add(legend9);
            this.mainChart.Location = new System.Drawing.Point(36, 35);
            this.mainChart.Name = "mainChart";
            series9.ChartArea = "ChartArea1";
            series9.Legend = "Legend1";
            series9.Name = "Series1";
            this.mainChart.Series.Add(series9);
            this.mainChart.Size = new System.Drawing.Size(662, 493);
            this.mainChart.TabIndex = 0;
            this.mainChart.Text = "chart1";
            // 
            // calcualteButton
            // 
            this.calcualteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calcualteButton.Location = new System.Drawing.Point(741, 227);
            this.calcualteButton.Name = "calcualteButton";
            this.calcualteButton.Size = new System.Drawing.Size(397, 27);
            this.calcualteButton.TabIndex = 1;
            this.calcualteButton.Text = "Calculate";
            this.calcualteButton.UseVisualStyleBackColor = true;
            this.calcualteButton.Click += new System.EventHandler(this.calcualteButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(737, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "F(x) = 1/x";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(1073, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "N = 20";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(871, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Range: x є [1, 3]";
            // 
            // xTextBox
            // 
            this.xTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.xTextBox.Location = new System.Drawing.Point(859, 89);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(100, 26);
            this.xTextBox.TabIndex = 5;
            this.xTextBox.Text = "1,55";
            // 
            // epsTextBox
            // 
            this.epsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.epsTextBox.Location = new System.Drawing.Point(859, 135);
            this.epsTextBox.Name = "epsTextBox";
            this.epsTextBox.Size = new System.Drawing.Size(100, 26);
            this.epsTextBox.TabIndex = 6;
            this.epsTextBox.Text = "0,0001";
            // 
            // accurancyTextBox
            // 
            this.accurancyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.accurancyTextBox.Location = new System.Drawing.Point(859, 181);
            this.accurancyTextBox.Name = "accurancyTextBox";
            this.accurancyTextBox.Size = new System.Drawing.Size(100, 26);
            this.accurancyTextBox.TabIndex = 7;
            this.accurancyTextBox.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(737, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "X:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(737, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "EPS:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(737, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Accurancy:";
            // 
            // outputTextBox
            // 
            this.outputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outputTextBox.Location = new System.Drawing.Point(741, 279);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(397, 249);
            this.outputTextBox.TabIndex = 12;
            // 
            // originalRadioButton
            // 
            this.originalRadioButton.AutoSize = true;
            this.originalRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.originalRadioButton.Location = new System.Drawing.Point(1014, 89);
            this.originalRadioButton.Name = "originalRadioButton";
            this.originalRadioButton.Size = new System.Drawing.Size(75, 21);
            this.originalRadioButton.TabIndex = 13;
            this.originalRadioButton.TabStop = true;
            this.originalRadioButton.Text = "Original";
            this.originalRadioButton.UseVisualStyleBackColor = true;
            this.originalRadioButton.CheckedChanged += new System.EventHandler(this.originalRadioButton_CheckedChanged);
            // 
            // newthonRadioButton
            // 
            this.newthonRadioButton.AutoSize = true;
            this.newthonRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newthonRadioButton.Location = new System.Drawing.Point(1014, 116);
            this.newthonRadioButton.Name = "newthonRadioButton";
            this.newthonRadioButton.Size = new System.Drawing.Size(81, 21);
            this.newthonRadioButton.TabIndex = 14;
            this.newthonRadioButton.TabStop = true;
            this.newthonRadioButton.Text = "Newthon";
            this.newthonRadioButton.UseVisualStyleBackColor = true;
            this.newthonRadioButton.CheckedChanged += new System.EventHandler(this.newthonRadioButton_CheckedChanged);
            // 
            // gausRadioButton
            // 
            this.gausRadioButton.AutoSize = true;
            this.gausRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gausRadioButton.Location = new System.Drawing.Point(1014, 143);
            this.gausRadioButton.Name = "gausRadioButton";
            this.gausRadioButton.Size = new System.Drawing.Size(60, 21);
            this.gausRadioButton.TabIndex = 15;
            this.gausRadioButton.TabStop = true;
            this.gausRadioButton.Text = "Gaus";
            this.gausRadioButton.UseVisualStyleBackColor = true;
            this.gausRadioButton.CheckedChanged += new System.EventHandler(this.gausRadioButton_CheckedChanged);
            // 
            // lqRadioButton
            // 
            this.lqRadioButton.AutoSize = true;
            this.lqRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lqRadioButton.Location = new System.Drawing.Point(1014, 170);
            this.lqRadioButton.Name = "lqRadioButton";
            this.lqRadioButton.Size = new System.Drawing.Size(111, 21);
            this.lqRadioButton.TabIndex = 16;
            this.lqRadioButton.TabStop = true;
            this.lqRadioButton.Text = "Less squares";
            this.lqRadioButton.UseVisualStyleBackColor = true;
            this.lqRadioButton.CheckedChanged += new System.EventHandler(this.lqRadioButton_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.lqRadioButton);
            this.Controls.Add(this.gausRadioButton);
            this.Controls.Add(this.newthonRadioButton);
            this.Controls.Add(this.originalRadioButton);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.accurancyTextBox);
            this.Controls.Add(this.epsTextBox);
            this.Controls.Add(this.xTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.calcualteButton);
            this.Controls.Add(this.mainChart);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;
        private System.Windows.Forms.Button calcualteButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.TextBox epsTextBox;
        private System.Windows.Forms.TextBox accurancyTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.RadioButton originalRadioButton;
        private System.Windows.Forms.RadioButton newthonRadioButton;
        private System.Windows.Forms.RadioButton gausRadioButton;
        private System.Windows.Forms.RadioButton lqRadioButton;
    }
}

