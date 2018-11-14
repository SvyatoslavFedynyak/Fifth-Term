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

namespace Graphical
{
    public partial class Form1 : Form
    {
        double scale;
        int weigh = 800;
        int heigh = 600;
        bool generated;
        double maxValue;
        EdgePoints edgePoints;
        CoordinateMatrix surfaceMatrix;
        public Form1()
        {
            InitializeComponent();
            generated = false;
        }
        private int convertX(double value)
        {
            double coef = (heigh / maxValue) /4;
            return (int)(weigh / 2 + value * coef);
        }
        private int convertY(double value)
        {
            double coef = (heigh / maxValue)/4;
            return (int)(heigh / 2 - value * coef);
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            FindMaxValue();
            int iterations = Convert.ToInt32(iterationsTextBox.Text);
            edgePoints = new EdgePoints();
            edgePoints.p00 = new Coord(Convert.ToDouble(p00XtextBox.Text), Convert.ToDouble(p00YtextBox.Text), Convert.ToDouble(p00ZtextBox.Text));
            edgePoints.p01 = new Coord(Convert.ToDouble(p01XtextBox.Text), Convert.ToDouble(p01YtextBox.Text), Convert.ToDouble(p01ZtextBox.Text));
            edgePoints.p10 = new Coord(Convert.ToDouble(p10XtextBox.Text), Convert.ToDouble(p10YtextBox.Text), Convert.ToDouble(p10ZtextBox.Text));
            edgePoints.p11 = new Coord(Convert.ToDouble(p11XtextBox.Text), Convert.ToDouble(p11YtextBox.Text), Convert.ToDouble(p11ZtextBox.Text));
            surfaceMatrix = LinearSurfaceBuilder.Build(iterations, edgePoints);
            generated = true;
        }

        private void proectionPictureBox1_Paint(object sender, PaintEventArgs e)
        {
            #region Paint Axes

            e.Graphics.DrawLine(Pens.Black, weigh / 2, 0, weigh / 2, heigh);
            e.Graphics.DrawLine(Pens.Black, 0, heigh / 2, weigh, heigh / 2);

            #endregion

            Bitmap red = new Bitmap(1, 1);
            red.SetPixel(0, 0, Color.Red);
            int x, y;
            if (generated)
            {
                if (oxRadioButton.Checked)
                {
                    //y -> y
                    //z -> x
                    XAxesLabel.Text = "Z";
                    XAxesLabel.Refresh();
                    YAxesLabel.Text = "Y";
                    YAxesLabel.Refresh();
                    for (int i = 0; i < surfaceMatrix.Row; i++)
                    {
                        for (int j = 0; j < surfaceMatrix.Coll; j++)
                        {
                            x = convertX(surfaceMatrix[i, j].z);
                            y = convertY(surfaceMatrix[i, j].y);
                            e.Graphics.DrawImage(red, x, y);
                        }
                    }
                }
                else if (oyRadioButton2.Checked)
                {
                    //z -> y
                    //x -> x
                    YAxesLabel.Text = "Z";
                    YAxesLabel.Refresh();
                    XAxesLabel.Text = "X";
                    XAxesLabel.Refresh();
                    for (int i = 0; i < surfaceMatrix.Row; i++)
                    {
                        for (int j = 0; j < surfaceMatrix.Coll; j++)
                        {
                            x = convertX(surfaceMatrix[i, j].x);
                            y = convertY(surfaceMatrix[i, j].z);
                            e.Graphics.DrawImage(red, x, y);
                        }
                    }
                }
                else
                {
                    //y -> y
                    //x -> x
                    YAxesLabel.Text = "Y";
                    YAxesLabel.Refresh();
                    XAxesLabel.Text = "X";
                    XAxesLabel.Refresh();
                    for (int i = 0; i < surfaceMatrix.Row; i++)
                    {
                        for (int j = 0; j < surfaceMatrix.Coll; j++)
                        {
                            x = convertX(surfaceMatrix[i, j].x);
                            y = convertY(surfaceMatrix[i, j].y);
                            e.Graphics.DrawImage(red, x, y);
                        }
                    }
                }
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            proectionPictureBox1.Refresh();
        }

        private void FindMaxValue()
        {
            double[] values = new double[12];
            values[0] = Convert.ToDouble(p00XtextBox.Text);
            values[1] = Convert.ToDouble(p00YtextBox.Text);
            values[2] = Convert.ToDouble(p00ZtextBox.Text);
            values[3] = Convert.ToDouble(p01XtextBox.Text);
            values[4] = Convert.ToDouble(p01YtextBox.Text);
            values[5] = Convert.ToDouble(p01ZtextBox.Text);
            values[6] = Convert.ToDouble(p10XtextBox.Text);
            values[7] = Convert.ToDouble(p10YtextBox.Text);
            values[8] = Convert.ToDouble(p10ZtextBox.Text);
            values[9] = Convert.ToDouble(p11XtextBox.Text);
            values[10] = Convert.ToDouble(p11YtextBox.Text);
            values[11] = Convert.ToDouble(p11ZtextBox.Text);
            maxValue = values.Max();
        }
    }
}
