using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab4;
using MathFunc = System.Func<double, double>;

namespace Graphical
{
    public partial class Lab4 : Form
    {
        NumericalIntegrationMethods calculator;
        int numOfPointInGraph = 400;
        double start = 0.25;
        double end = 3.5;
        double step;
        public Lab4()
        {
            InitializeComponent();
            step = (end - start) / numOfPointInGraph;
            graphicPictureBox.Refresh();
            calculator = new NumericalIntegrationMethods(1, 3);
        }


        private void graphicPictureBox_Paint(object sender, PaintEventArgs e)
        {
            int wigth = 550, heigh = 525;
            int lines = 100;
            int point = 120;
            int pointLengh = 10;
            #region CoordianteLines
            e.Graphics.DrawLine(Pens.Black, lines, 0, lines, heigh);
            e.Graphics.DrawLine(Pens.Black, 0, heigh - lines, wigth, heigh - lines);
            for (int i = 1; i <= 3; i++)
            {
                e.Graphics.DrawLine(Pens.Black, lines + i * point, heigh - lines - pointLengh / 2, lines + i * point, heigh - lines + pointLengh / 2);
            }
            e.Graphics.DrawLine(Pens.Black, lines - pointLengh / 2, heigh - lines - point - 20, lines + pointLengh / 2, heigh - lines - point - 20);
            #endregion

            Bitmap btm = new Bitmap(1, 1);
            btm.SetPixel(0, 0, Color.Black);
            //Bitmap blue = new Bitmap(1, 1);
            //blue.SetPixel(0, 0, Color.Blue);
            int x, y;
            for (double i = start; i < end; i += step)
            {
                x = convert(i);
                y = heigh - convert(1 / i);
                e.Graphics.DrawImage(btm, new PointF(x, y));
                if (x >= lines + point && x <= lines + point * 3)
                {
                    e.Graphics.DrawLine(Pens.Blue, x, y, x, heigh - lines);
                }
            }


        }
        private int convert(double value)
        {
            return (int)(value * 133.3 + 100);
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            double eps = Convert.ToDouble(presisionTextBox.Text);
            calculator.EPS = eps;
            calculator.F = new MathFunc((value) =>
             { return 1 / value; });
            StringBuilder sb = new StringBuilder();
            NumericMethodResult res;
            res = calculator.TestMethod(calculator.Rectangle);
            sb.AppendLine(string.Format($"Result for rectangle is {res.S}, with {res.CallAmount} call amount and {res.IterationAmount} iteration amount"));
            res = calculator.TestMethod(calculator.Trapeze);
            sb.AppendLine(string.Format($"Result for trapeze is {res.S}, with {res.CallAmount} call amount and {res.IterationAmount} iteration amount"));
            res = calculator.TestMethod(calculator.Parabola);
            sb.AppendLine(string.Format($"Result for parabola is {res.S}, with {res.CallAmount} call amount and {res.IterationAmount} iteration amount"));
            res = calculator.TestMethod(calculator.GaussFour);
            sb.AppendLine(string.Format($"Result for gauss4 is {res.S}, with {res.CallAmount} call amount and {res.IterationAmount} iteration amount"));
            res = calculator.TestMethod(calculator.GaussFifth);
            sb.AppendLine(string.Format($"Result for gauss5 is {res.S}, with {res.CallAmount} call amount and {res.IterationAmount} iteration amount"));
            outputTextBox.Text = sb.ToString();
        }
    }
}
