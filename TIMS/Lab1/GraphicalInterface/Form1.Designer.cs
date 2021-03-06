﻿namespace GraphicalInterface
{
    partial class mainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.minTextBox = new System.Windows.Forms.TextBox();
            this.maxTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.generateTextButton = new System.Windows.Forms.Button();
            this.analyseTextButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.countTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.discreteRadioButton = new System.Windows.Forms.RadioButton();
            this.uninterruptedRadioButton = new System.Windows.Forms.RadioButton();
            this.outputTextBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.levelOfsignificanceTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.calculateBautton = new System.Windows.Forms.Button();
            this.mainValueTextBox = new System.Windows.Forms.TextBox();
            this.additionalTextBox = new System.Windows.Forms.TextBox();
            this.quantilRadioButton = new System.Windows.Forms.RadioButton();
            this.momentRadioButton = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataChart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataChart2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataChart
            // 
            chartArea1.Name = "ChartArea1";
            this.dataChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.dataChart.Legends.Add(legend1);
            this.dataChart.Location = new System.Drawing.Point(35, 321);
            this.dataChart.Name = "dataChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.dataChart.Series.Add(series1);
            this.dataChart.Size = new System.Drawing.Size(629, 314);
            this.dataChart.TabIndex = 0;
            this.dataChart.Text = "chart1";
            // 
            // minTextBox
            // 
            this.minTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minTextBox.Location = new System.Drawing.Point(35, 97);
            this.minTextBox.Name = "minTextBox";
            this.minTextBox.Size = new System.Drawing.Size(130, 29);
            this.minTextBox.TabIndex = 2;
            // 
            // maxTextBox
            // 
            this.maxTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maxTextBox.Location = new System.Drawing.Point(204, 97);
            this.maxTextBox.Name = "maxTextBox";
            this.maxTextBox.Size = new System.Drawing.Size(130, 29);
            this.maxTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(69, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Min";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(243, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Max";
            // 
            // generateTextButton
            // 
            this.generateTextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generateTextButton.Location = new System.Drawing.Point(35, 239);
            this.generateTextButton.Name = "generateTextButton";
            this.generateTextButton.Size = new System.Drawing.Size(130, 53);
            this.generateTextButton.TabIndex = 6;
            this.generateTextButton.Text = "Generate";
            this.generateTextButton.UseVisualStyleBackColor = true;
            this.generateTextButton.Click += new System.EventHandler(this.generateTextButton_Click);
            // 
            // analyseTextButton
            // 
            this.analyseTextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.analyseTextButton.Location = new System.Drawing.Point(192, 239);
            this.analyseTextButton.Name = "analyseTextButton";
            this.analyseTextButton.Size = new System.Drawing.Size(130, 53);
            this.analyseTextButton.TabIndex = 7;
            this.analyseTextButton.Text = "Analyse";
            this.analyseTextButton.UseVisualStyleBackColor = true;
            this.analyseTextButton.Click += new System.EventHandler(this.analyseTextButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(31, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "Count";
            // 
            // countTextBox
            // 
            this.countTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.countTextBox.Location = new System.Drawing.Point(138, 30);
            this.countTextBox.Name = "countTextBox";
            this.countTextBox.Size = new System.Drawing.Size(151, 29);
            this.countTextBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(575, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "Output";
            // 
            // discreteRadioButton
            // 
            this.discreteRadioButton.AutoSize = true;
            this.discreteRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.discreteRadioButton.Location = new System.Drawing.Point(35, 145);
            this.discreteRadioButton.Name = "discreteRadioButton";
            this.discreteRadioButton.Size = new System.Drawing.Size(96, 28);
            this.discreteRadioButton.TabIndex = 11;
            this.discreteRadioButton.TabStop = true;
            this.discreteRadioButton.Text = "Discrete";
            this.discreteRadioButton.UseVisualStyleBackColor = true;
            // 
            // uninterruptedRadioButton
            // 
            this.uninterruptedRadioButton.AutoSize = true;
            this.uninterruptedRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uninterruptedRadioButton.Location = new System.Drawing.Point(192, 145);
            this.uninterruptedRadioButton.Name = "uninterruptedRadioButton";
            this.uninterruptedRadioButton.Size = new System.Drawing.Size(142, 28);
            this.uninterruptedRadioButton.TabIndex = 12;
            this.uninterruptedRadioButton.TabStop = true;
            this.uninterruptedRadioButton.Text = "Uninterrupted";
            this.uninterruptedRadioButton.UseVisualStyleBackColor = true;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(379, 52);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(466, 252);
            this.outputTextBox.TabIndex = 13;
            this.outputTextBox.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1302, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // readToolStripMenuItem
            // 
            this.readToolStripMenuItem.Name = "readToolStripMenuItem";
            this.readToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.readToolStripMenuItem.Text = "Read";
            this.readToolStripMenuItem.Click += new System.EventHandler(this.readToolStripMenuItem_Click);
            // 
            // levelOfsignificanceTextBox
            // 
            this.levelOfsignificanceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.levelOfsignificanceTextBox.Location = new System.Drawing.Point(222, 188);
            this.levelOfsignificanceTextBox.Name = "levelOfsignificanceTextBox";
            this.levelOfsignificanceTextBox.Size = new System.Drawing.Size(100, 29);
            this.levelOfsignificanceTextBox.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(31, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 24);
            this.label5.TabIndex = 16;
            this.label5.Text = "Level of significance";
            // 
            // calculateBautton
            // 
            this.calculateBautton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calculateBautton.Location = new System.Drawing.Point(924, 230);
            this.calculateBautton.Name = "calculateBautton";
            this.calculateBautton.Size = new System.Drawing.Size(127, 62);
            this.calculateBautton.TabIndex = 17;
            this.calculateBautton.Text = "Calculate";
            this.calculateBautton.UseVisualStyleBackColor = true;
            this.calculateBautton.Click += new System.EventHandler(this.calculateBautton_Click);
            // 
            // mainValueTextBox
            // 
            this.mainValueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainValueTextBox.Location = new System.Drawing.Point(924, 172);
            this.mainValueTextBox.Name = "mainValueTextBox";
            this.mainValueTextBox.Size = new System.Drawing.Size(127, 29);
            this.mainValueTextBox.TabIndex = 18;
            // 
            // additionalTextBox
            // 
            this.additionalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.additionalTextBox.Location = new System.Drawing.Point(1099, 172);
            this.additionalTextBox.Name = "additionalTextBox";
            this.additionalTextBox.Size = new System.Drawing.Size(143, 29);
            this.additionalTextBox.TabIndex = 19;
            // 
            // quantilRadioButton
            // 
            this.quantilRadioButton.AutoSize = true;
            this.quantilRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quantilRadioButton.Location = new System.Drawing.Point(924, 66);
            this.quantilRadioButton.Name = "quantilRadioButton";
            this.quantilRadioButton.Size = new System.Drawing.Size(87, 28);
            this.quantilRadioButton.TabIndex = 20;
            this.quantilRadioButton.TabStop = true;
            this.quantilRadioButton.Text = "Quantil";
            this.quantilRadioButton.UseVisualStyleBackColor = true;
            // 
            // momentRadioButton
            // 
            this.momentRadioButton.AutoSize = true;
            this.momentRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.momentRadioButton.Location = new System.Drawing.Point(1099, 66);
            this.momentRadioButton.Name = "momentRadioButton";
            this.momentRadioButton.Size = new System.Drawing.Size(97, 28);
            this.momentRadioButton.TabIndex = 21;
            this.momentRadioButton.TabStop = true;
            this.momentRadioButton.Text = "Moment";
            this.momentRadioButton.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(921, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 24);
            this.label6.TabIndex = 22;
            this.label6.Text = "Main Value";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(1095, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 24);
            this.label7.TabIndex = 23;
            this.label7.Text = "Additional Value";
            // 
            // dataChart2
            // 
            chartArea2.Name = "ChartArea1";
            this.dataChart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.dataChart2.Legends.Add(legend2);
            this.dataChart2.Location = new System.Drawing.Point(697, 321);
            this.dataChart2.Name = "dataChart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.dataChart2.Series.Add(series2);
            this.dataChart2.Size = new System.Drawing.Size(572, 314);
            this.dataChart2.TabIndex = 24;
            this.dataChart2.Text = "chart1";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 665);
            this.Controls.Add(this.dataChart2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.momentRadioButton);
            this.Controls.Add(this.quantilRadioButton);
            this.Controls.Add(this.additionalTextBox);
            this.Controls.Add(this.mainValueTextBox);
            this.Controls.Add(this.calculateBautton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.levelOfsignificanceTextBox);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.uninterruptedRadioButton);
            this.Controls.Add(this.discreteRadioButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.countTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.analyseTextButton);
            this.Controls.Add(this.generateTextButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maxTextBox);
            this.Controls.Add(this.minTextBox);
            this.Controls.Add(this.dataChart);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainForm";
            this.Text = "Statistic Analyser";
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataChart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart dataChart;
        private System.Windows.Forms.TextBox minTextBox;
        private System.Windows.Forms.TextBox maxTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button generateTextButton;
        private System.Windows.Forms.Button analyseTextButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox countTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton discreteRadioButton;
        private System.Windows.Forms.RadioButton uninterruptedRadioButton;
        private System.Windows.Forms.RichTextBox outputTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readToolStripMenuItem;
        private System.Windows.Forms.TextBox levelOfsignificanceTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button calculateBautton;
        private System.Windows.Forms.TextBox mainValueTextBox;
        private System.Windows.Forms.TextBox additionalTextBox;
        private System.Windows.Forms.RadioButton quantilRadioButton;
        private System.Windows.Forms.RadioButton momentRadioButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataVisualization.Charting.Chart dataChart2;
    }
}

