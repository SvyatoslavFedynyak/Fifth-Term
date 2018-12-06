using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab2;
using LeastSquares.Models;
using MathFunc = System.Func<double, double>;

namespace Graphics
{
    public partial class Form1 : Form
    {
        bool calculated;
        double precision;
        int numOfPointInGraph;
        double step;
        double begin, end;
        MathFunc f;
        LeastSquaresMethod leastSquares;
        CalcMistake mistake;
        byte l2acc;
        Pair[] original;
        Pair[] forward;
        Pair[] backward;
        Pair[] l2;
        public Form1()
        {
            InitializeComponent();
            calculated = false;
            numOfPointInGraph = 100;
            begin = 1;
            end = 3;
            step = (end - begin) / numOfPointInGraph;
            f = (x) => 1 / x;
            leastSquares = new LeastSquaresMethod(begin, end, 20, f);
            mistake = new CalcMistake();

            original = new Pair[numOfPointInGraph];
            forward = new Pair[numOfPointInGraph];
            backward = new Pair[numOfPointInGraph];
            l2 = new Pair[numOfPointInGraph];
        }
        private Pair convertCoord(Pair value)
        {
            return new Pair((value.x - 1) * 250, 500 * (1 - value.y));
        }

        //private void graphicPictureBox_Paint(object sender, PaintEventArgs e)
        //{
        //    Bitmap black = new Bitmap(1, 1);
        //    black.SetPixel(0, 0, Color.Black);
        //    Bitmap red = new Bitmap(1, 1);
        //    red.SetPixel(0, 0, Color.Red);
        //    Bitmap blue = new Bitmap(1, 1);
        //    blue.SetPixel(0, 0, Color.Blue);
        //    Pair location;
        //    #region Original

        //    if (originalCheckBox.Checked)
        //    {
        //        for (int i = 0; i < numOfPointInGraph; i++)
        //        {
        //            location = convertCoord(new Pair(original[i].x, original[i].y));
        //            e.Graphics.DrawImage(black, new PointF((float)location.x, (float)location.y));
        //        }
        //    }

        //    #endregion
        //    #region Forward

        //    if (gaussCheckBox.Checked)
        //    {
        //        for (int i = 0; i < numOfPointInGraph; i++)
        //        {
        //            location = convertCoord(new Pair(forward[i].x, forward[i].y));
        //            e.Graphics.DrawImage(red, new PointF((float)location.x, (float)location.y));
        //        }
        //    }

        //    #endregion

        //    #region Backward

        //    if (nyuthonCheckBox.Checked)
        //    {
        //        for (int i = 0; i < numOfPointInGraph; i++)
        //        {
        //            location = convertCoord(new Pair(backward[i].x, backward[i].y));
        //            e.Graphics.DrawImage(blue, new PointF((float)location.x, (float)location.y));
        //        }
        //    }

        //    #endregion

        //}

        private void buildOriginal()
        {

            for (int i = 0; i < numOfPointInGraph; i++)
            {
                original[i].x = begin + i * step;
                original[i].y = 1 / original[i].x;
            }
        }
        private void buildForward()
        {
            for (int i = 0; i < numOfPointInGraph; i++)
            {
                forward[i].x = begin + i * step;
                forward[i].y = InterpolationBuilder.Calculate(original[i].x, precision);
            }
        }
        private void buildBackward()
        {
            for (int i = 0; i < numOfPointInGraph; i++)
            {
                backward[i].x = begin + i * step;
                backward[i].y = InterpolationBuilder.CalculateBackward(original[i].x, precision);
            }
        }
        private void buildL2()
        {
            for (int i = 0; i < numOfPointInGraph; i++)
            {
                l2[i].x = begin + i * step;
                l2[i].y = leastSquares.LeastSquares(backward[i].x).Y;
            }
        }

        private void calcualteButton_Click(object sender, EventArgs e)
        {
            precision = Convert.ToDouble(epsTextBox.Text);
            buildOriginal();
            buildForward();
            buildBackward();
            buildL2();
            l2acc = byte.Parse(accurancyTextBox.Text);
            StringBuilder sb = new StringBuilder();
            double x = Convert.ToDouble(xTextBox.Text);
            double fres = 1 / x;
            double l2 = Convert.ToDouble(accurancyTextBox.Text);
            sb.AppendFormat($"Real result is: {fres}\n");
            sb.AppendLine();
            sb.AppendLine("Gaus:");
            sb.AppendFormat($"Result: {InterpolationBuilder.Calculate(x, precision)}, members: {InterpolationBuilder.returnValues().calculateItemsNum}, dismiss: {InterpolationBuilder.returnValues().dismiss}, L2 dismis: {mistake.CalcFunctionMistake(begin, end, l2acc, f, (double X) => InterpolationBuilder.Calculate(X, precision))}");
            sb.AppendLine();
            sb.AppendLine("Newthon:");
            sb.AppendFormat($"Result: {InterpolationBuilder.CalculateBackward(x, precision)}, members: {InterpolationBuilder.returnValues().calculateItemsNum}, dismiss: {InterpolationBuilder.returnValues().dismiss}, L2 dismis: {mistake.CalcFunctionMistake(begin, end, l2acc, f, (double X) => InterpolationBuilder.CalculateBackward(X, precision))}");
            sb.AppendLine();
            sb.AppendLine("Less quadres:");
            MethodsResult leastSquaresRes = leastSquares.LeastSquares(x);
            sb.AppendFormat($"Result: {leastSquaresRes.Y}, members: {leastSquaresRes.N}, dismiss: {mistake.CalcValueMistake(fres, leastSquaresRes.Y).ToString()}, L2 dismis: {mistake.CalcFunctionMistake(begin, end, l2acc, f, (double X) => leastSquares.LeastSquares(X).Y).ToString()}");
            outputTextBox.Text = sb.ToString();
            calculated = true;
        }

        private void newthonRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newthonRadioButton.Checked && calculated)
            {
                int count = backward.Length;
                double[] x = new double[count];
                double[] y = new double[count];
                for (int i = 0; i < count; i++)
                {
                    x[i] = backward[i].x;
                    y[i] = backward[i].y;
                }
                mainChart.Series[0] = new System.Windows.Forms.DataVisualization.Charting.Series("Original");
                mainChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                mainChart.Series[0].Points.DataBindXY(x, y);
            }
        }

        private void gausRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (gausRadioButton.Checked && calculated)
            {
                int count = forward.Length;
                double[] x = new double[count];
                double[] y = new double[count];
                for (int i = 0; i < count; i++)
                {
                    x[i] = forward[i].x;
                    y[i] = forward[i].y;
                }
                mainChart.Series[0] = new System.Windows.Forms.DataVisualization.Charting.Series("Original");
                mainChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                mainChart.Series[0].Points.DataBindXY(x, y);
            }
        }

        private void lqRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (lqRadioButton.Checked && calculated)
            {
                int count = l2.Length;
                double[] x = new double[count];
                double[] y = new double[count];
                for (int i = 0; i < count; i++)
                {
                    x[i] = l2[i].x;
                    y[i] = l2[i].y;
                }
                mainChart.Series[0] = new System.Windows.Forms.DataVisualization.Charting.Series("Original");
                mainChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                mainChart.Series[0].Points.DataBindXY(x, y);
            }
        }

        private void originalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (originalRadioButton.Checked && calculated)
            {
                int count = original.Length;
                double[] x = new double[count];
                double[] y = new double[count];
                for (int i = 0; i < count; i++)
                {
                    x[i] = original[i].x;
                    y[i] = original[i].y;
                }
                mainChart.Series[0] = new System.Windows.Forms.DataVisualization.Charting.Series("Original");
                mainChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                mainChart.Series[0].Points.DataBindXY(x, y);
            }
        }

        
        

    }
}
