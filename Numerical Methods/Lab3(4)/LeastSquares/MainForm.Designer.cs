namespace LeastSquares
{
    partial class MainForm
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
            this.scaleTbl = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.xTb = new System.Windows.Forms.TextBox();
            this.epsTb = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.functionResLbl = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.l2AccurancyTb = new System.Windows.Forms.TextBox();
            this.calcBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.newtonMistakeLbl = new System.Windows.Forms.Label();
            this.gaussMistakeLbl = new System.Windows.Forms.Label();
            this.newtonMemberCountLbl = new System.Windows.Forms.Label();
            this.gaussMemberCountLbl = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.newtonResultLbl = new System.Windows.Forms.Label();
            this.gaussResultLbl = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.leastSquaresResultLbl = new System.Windows.Forms.Label();
            this.leastSquaresMemberCountLbl = new System.Windows.Forms.Label();
            this.leastSquaresMistakelbl = new System.Windows.Forms.Label();
            this.l2NewtonMistakeLbl = new System.Windows.Forms.Label();
            this.l2GaussMistakeLbl = new System.Windows.Forms.Label();
            this.l2LeastSquaresMistakeLbl = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.nodeGraph = new FancyControls.Data.glGraph();
            this.newtonGraph = new FancyControls.Data.glGraph();
            this.gaussGraph = new FancyControls.Data.glGraph();
            this.squaresGraph = new FancyControls.Data.glGraph();
            this.scaleTbl.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // scaleTbl
            // 
            this.scaleTbl.ColumnCount = 2;
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTbl.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.scaleTbl.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.scaleTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scaleTbl.Location = new System.Drawing.Point(0, 0);
            this.scaleTbl.Name = "scaleTbl";
            this.scaleTbl.RowCount = 1;
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.scaleTbl.Size = new System.Drawing.Size(1184, 561);
            this.scaleTbl.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.calcBtn, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(592, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(592, 561);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(586, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "f(x) = x * sin(x)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 20);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(592, 20);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "a = 0";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(200, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "b = PI/4";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(397, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "N = 20";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.xTb, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.epsTb, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label13, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.functionResLbl, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label15, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.l2AccurancyTb, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 40);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(592, 120);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(290, 30);
            this.label5.TabIndex = 0;
            this.label5.Text = "x = ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(290, 30);
            this.label6.TabIndex = 1;
            this.label6.Text = "EPS =";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xTb
            // 
            this.xTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xTb.Location = new System.Drawing.Point(299, 3);
            this.xTb.Multiline = true;
            this.xTb.Name = "xTb";
            this.xTb.Size = new System.Drawing.Size(290, 24);
            this.xTb.TabIndex = 2;
            this.xTb.Text = "0,5";
            // 
            // epsTb
            // 
            this.epsTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.epsTb.Location = new System.Drawing.Point(299, 33);
            this.epsTb.Multiline = true;
            this.epsTb.Name = "epsTb";
            this.epsTb.Size = new System.Drawing.Size(290, 24);
            this.epsTb.TabIndex = 3;
            this.epsTb.Text = "1e-5";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(3, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(290, 30);
            this.label13.TabIndex = 4;
            this.label13.Text = "f (x) =";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // functionResLbl
            // 
            this.functionResLbl.AutoSize = true;
            this.functionResLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.functionResLbl.Location = new System.Drawing.Point(299, 90);
            this.functionResLbl.Name = "functionResLbl";
            this.functionResLbl.Size = new System.Drawing.Size(290, 30);
            this.functionResLbl.TabIndex = 5;
            this.functionResLbl.Text = "0";
            this.functionResLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Location = new System.Drawing.Point(3, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(290, 30);
            this.label15.TabIndex = 6;
            this.label15.Text = "L2 Accuracy = ";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l2AccurancyTb
            // 
            this.l2AccurancyTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l2AccurancyTb.Location = new System.Drawing.Point(299, 63);
            this.l2AccurancyTb.Multiline = true;
            this.l2AccurancyTb.Name = "l2AccurancyTb";
            this.l2AccurancyTb.Size = new System.Drawing.Size(290, 24);
            this.l2AccurancyTb.TabIndex = 7;
            this.l2AccurancyTb.Text = "10";
            // 
            // calcBtn
            // 
            this.calcBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.calcBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calcBtn.Location = new System.Drawing.Point(3, 163);
            this.calcBtn.Name = "calcBtn";
            this.calcBtn.Size = new System.Drawing.Size(586, 29);
            this.calcBtn.TabIndex = 3;
            this.calcBtn.Text = "calculate";
            this.calcBtn.UseVisualStyleBackColor = true;
            this.calcBtn.Click += new System.EventHandler(this.calcBtn_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Controls.Add(this.label7, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label8, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label11, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.newtonMistakeLbl, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.gaussMistakeLbl, 2, 3);
            this.tableLayoutPanel4.Controls.Add(this.newtonMemberCountLbl, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.gaussMemberCountLbl, 2, 2);
            this.tableLayoutPanel4.Controls.Add(this.label12, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.newtonResultLbl, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.gaussResultLbl, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.label10, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.label14, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.leastSquaresResultLbl, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.leastSquaresMemberCountLbl, 3, 2);
            this.tableLayoutPanel4.Controls.Add(this.leastSquaresMistakelbl, 3, 3);
            this.tableLayoutPanel4.Controls.Add(this.l2NewtonMistakeLbl, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.l2GaussMistakeLbl, 2, 4);
            this.tableLayoutPanel4.Controls.Add(this.l2LeastSquaresMistakeLbl, 3, 4);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 195);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(592, 366);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(151, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 73);
            this.label7.TabIndex = 0;
            this.label7.Text = "Newton Forward";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(299, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 73);
            this.label8.TabIndex = 1;
            this.label8.Text = "Gauss Forward";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(3, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 73);
            this.label9.TabIndex = 2;
            this.label9.Text = "number of members";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(3, 219);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(142, 73);
            this.label11.TabIndex = 4;
            this.label11.Text = "D = | f (x*)- f* (x*) |";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newtonMistakeLbl
            // 
            this.newtonMistakeLbl.AutoSize = true;
            this.newtonMistakeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newtonMistakeLbl.Location = new System.Drawing.Point(151, 219);
            this.newtonMistakeLbl.Name = "newtonMistakeLbl";
            this.newtonMistakeLbl.Size = new System.Drawing.Size(142, 73);
            this.newtonMistakeLbl.TabIndex = 5;
            this.newtonMistakeLbl.Text = "0";
            this.newtonMistakeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gaussMistakeLbl
            // 
            this.gaussMistakeLbl.AutoSize = true;
            this.gaussMistakeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gaussMistakeLbl.Location = new System.Drawing.Point(299, 219);
            this.gaussMistakeLbl.Name = "gaussMistakeLbl";
            this.gaussMistakeLbl.Size = new System.Drawing.Size(142, 73);
            this.gaussMistakeLbl.TabIndex = 6;
            this.gaussMistakeLbl.Text = "0";
            this.gaussMistakeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newtonMemberCountLbl
            // 
            this.newtonMemberCountLbl.AutoSize = true;
            this.newtonMemberCountLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newtonMemberCountLbl.Location = new System.Drawing.Point(151, 146);
            this.newtonMemberCountLbl.Name = "newtonMemberCountLbl";
            this.newtonMemberCountLbl.Size = new System.Drawing.Size(142, 73);
            this.newtonMemberCountLbl.TabIndex = 7;
            this.newtonMemberCountLbl.Text = "0";
            this.newtonMemberCountLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gaussMemberCountLbl
            // 
            this.gaussMemberCountLbl.AutoSize = true;
            this.gaussMemberCountLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gaussMemberCountLbl.Location = new System.Drawing.Point(299, 146);
            this.gaussMemberCountLbl.Name = "gaussMemberCountLbl";
            this.gaussMemberCountLbl.Size = new System.Drawing.Size(142, 73);
            this.gaussMemberCountLbl.TabIndex = 8;
            this.gaussMemberCountLbl.Text = "0";
            this.gaussMemberCountLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(3, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(142, 73);
            this.label12.TabIndex = 11;
            this.label12.Text = "result";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newtonResultLbl
            // 
            this.newtonResultLbl.AutoSize = true;
            this.newtonResultLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newtonResultLbl.Location = new System.Drawing.Point(151, 73);
            this.newtonResultLbl.Name = "newtonResultLbl";
            this.newtonResultLbl.Size = new System.Drawing.Size(142, 73);
            this.newtonResultLbl.TabIndex = 12;
            this.newtonResultLbl.Text = "0";
            this.newtonResultLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gaussResultLbl
            // 
            this.gaussResultLbl.AutoSize = true;
            this.gaussResultLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gaussResultLbl.Location = new System.Drawing.Point(299, 73);
            this.gaussResultLbl.Name = "gaussResultLbl";
            this.gaussResultLbl.Size = new System.Drawing.Size(142, 73);
            this.gaussResultLbl.TabIndex = 13;
            this.gaussResultLbl.Text = "0";
            this.gaussResultLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(3, 292);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(142, 74);
            this.label10.TabIndex = 14;
            this.label10.Text = "L2 ( [a, b] )";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(447, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(142, 73);
            this.label14.TabIndex = 15;
            this.label14.Text = "Least Squares";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leastSquaresResultLbl
            // 
            this.leastSquaresResultLbl.AutoSize = true;
            this.leastSquaresResultLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leastSquaresResultLbl.Location = new System.Drawing.Point(447, 73);
            this.leastSquaresResultLbl.Name = "leastSquaresResultLbl";
            this.leastSquaresResultLbl.Size = new System.Drawing.Size(142, 73);
            this.leastSquaresResultLbl.TabIndex = 16;
            this.leastSquaresResultLbl.Text = "0";
            this.leastSquaresResultLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leastSquaresMemberCountLbl
            // 
            this.leastSquaresMemberCountLbl.AutoSize = true;
            this.leastSquaresMemberCountLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leastSquaresMemberCountLbl.Location = new System.Drawing.Point(447, 146);
            this.leastSquaresMemberCountLbl.Name = "leastSquaresMemberCountLbl";
            this.leastSquaresMemberCountLbl.Size = new System.Drawing.Size(142, 73);
            this.leastSquaresMemberCountLbl.TabIndex = 17;
            this.leastSquaresMemberCountLbl.Text = "0";
            this.leastSquaresMemberCountLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leastSquaresMistakelbl
            // 
            this.leastSquaresMistakelbl.AutoSize = true;
            this.leastSquaresMistakelbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leastSquaresMistakelbl.Location = new System.Drawing.Point(447, 219);
            this.leastSquaresMistakelbl.Name = "leastSquaresMistakelbl";
            this.leastSquaresMistakelbl.Size = new System.Drawing.Size(142, 73);
            this.leastSquaresMistakelbl.TabIndex = 18;
            this.leastSquaresMistakelbl.Text = "0";
            this.leastSquaresMistakelbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l2NewtonMistakeLbl
            // 
            this.l2NewtonMistakeLbl.AutoSize = true;
            this.l2NewtonMistakeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l2NewtonMistakeLbl.Location = new System.Drawing.Point(151, 292);
            this.l2NewtonMistakeLbl.Name = "l2NewtonMistakeLbl";
            this.l2NewtonMistakeLbl.Size = new System.Drawing.Size(142, 74);
            this.l2NewtonMistakeLbl.TabIndex = 19;
            this.l2NewtonMistakeLbl.Text = "0";
            this.l2NewtonMistakeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l2GaussMistakeLbl
            // 
            this.l2GaussMistakeLbl.AutoSize = true;
            this.l2GaussMistakeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l2GaussMistakeLbl.Location = new System.Drawing.Point(299, 292);
            this.l2GaussMistakeLbl.Name = "l2GaussMistakeLbl";
            this.l2GaussMistakeLbl.Size = new System.Drawing.Size(142, 74);
            this.l2GaussMistakeLbl.TabIndex = 20;
            this.l2GaussMistakeLbl.Text = "0";
            this.l2GaussMistakeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l2LeastSquaresMistakeLbl
            // 
            this.l2LeastSquaresMistakeLbl.AutoSize = true;
            this.l2LeastSquaresMistakeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l2LeastSquaresMistakeLbl.Location = new System.Drawing.Point(447, 292);
            this.l2LeastSquaresMistakeLbl.Name = "l2LeastSquaresMistakeLbl";
            this.l2LeastSquaresMistakeLbl.Size = new System.Drawing.Size(142, 74);
            this.l2LeastSquaresMistakeLbl.TabIndex = 21;
            this.l2LeastSquaresMistakeLbl.Text = "0";
            this.l2LeastSquaresMistakeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.nodeGraph, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.newtonGraph, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.gaussGraph, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.squaresGraph, 1, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(592, 561);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // nodeGraph
            // 
            this.nodeGraph.BackColor = System.Drawing.Color.White;
            this.nodeGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodeGraph.Location = new System.Drawing.Point(3, 3);
            this.nodeGraph.Name = "nodeGraph";
            this.nodeGraph.Size = new System.Drawing.Size(290, 274);
            this.nodeGraph.TabIndex = 0;
            // 
            // newtonGraph
            // 
            this.newtonGraph.BackColor = System.Drawing.Color.White;
            this.newtonGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newtonGraph.Location = new System.Drawing.Point(299, 3);
            this.newtonGraph.Name = "newtonGraph";
            this.newtonGraph.Size = new System.Drawing.Size(290, 274);
            this.newtonGraph.TabIndex = 1;
            // 
            // gaussGraph
            // 
            this.gaussGraph.BackColor = System.Drawing.Color.White;
            this.gaussGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gaussGraph.Location = new System.Drawing.Point(3, 283);
            this.gaussGraph.Name = "gaussGraph";
            this.gaussGraph.Size = new System.Drawing.Size(290, 275);
            this.gaussGraph.TabIndex = 2;
            // 
            // squaresGraph
            // 
            this.squaresGraph.BackColor = System.Drawing.Color.White;
            this.squaresGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.squaresGraph.Location = new System.Drawing.Point(299, 283);
            this.squaresGraph.Name = "squaresGraph";
            this.squaresGraph.Size = new System.Drawing.Size(290, 275);
            this.squaresGraph.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.scaleTbl);
            this.MinimumSize = new System.Drawing.Size(1200, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InterpolationMethods";
            this.scaleTbl.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel scaleTbl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox xTb;
        private System.Windows.Forms.TextBox epsTb;
        private System.Windows.Forms.Button calcBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label newtonMistakeLbl;
        private System.Windows.Forms.Label gaussMistakeLbl;
        private System.Windows.Forms.Label newtonMemberCountLbl;
        private System.Windows.Forms.Label gaussMemberCountLbl;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label newtonResultLbl;
        private System.Windows.Forms.Label gaussResultLbl;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label functionResLbl;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox l2AccurancyTb;
        private System.Windows.Forms.Label leastSquaresResultLbl;
        private System.Windows.Forms.Label leastSquaresMemberCountLbl;
        private System.Windows.Forms.Label leastSquaresMistakelbl;
        private System.Windows.Forms.Label l2NewtonMistakeLbl;
        private System.Windows.Forms.Label l2GaussMistakeLbl;
        private System.Windows.Forms.Label l2LeastSquaresMistakeLbl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private FancyControls.Data.glGraph nodeGraph;
        private FancyControls.Data.glGraph newtonGraph;
        private FancyControls.Data.glGraph gaussGraph;
        private FancyControls.Data.glGraph squaresGraph;
    }
}

