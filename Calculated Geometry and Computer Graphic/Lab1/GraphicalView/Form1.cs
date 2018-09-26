using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab1;

namespace GraphicalView
{
    public partial class Form1 : Form
    {
        struct Figure
        {
            public Point A1, A2, A3, A4, A5, A6, A7, A8;
            public Figure(Point A1, Point A2, Point A3,
                Point A4, Point A5, Point A6, Point A7, Point A8)
            {
                this.A1 = A1;
                this.A2 = A2;
                this.A3 = A3;
                this.A4 = A4;
                this.A5 = A5;
                this.A6 = A6;
                this.A7 = A7;
                this.A8 = A8;
            }
        }
        Figure proection;
        CuttedCube cube = new CuttedCube();
        Matrix[] proectionMatrix;
        int zoom = 15;
        public Form1()
        {
            InitializeComponent();

            proection = new Figure(new Point(0, 0), new Point(0, 0), new Point(0, 0),
                new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0));
        }

        private void MaketPictureBox_Paint(object sender, PaintEventArgs e)
        {
            //320 x 210
            // middle = 100, 130
            #region CoordinateLines
            e.Graphics.DrawLine(Pens.Black, 20, 210, 100, 130);
            e.Graphics.DrawLine(Pens.Black, 100, 130, 100, 0);
            e.Graphics.DrawLine(Pens.Black, 100, 130, 240, 130);
            #endregion

            #region CuttedCube
            //a = 60
            //a/2=30
            e.Graphics.DrawLine(Pens.Red, 100, 130, 100, 70);//A8A4
            e.Graphics.DrawLine(Pens.Red, 100, 70, 130, 70);//A4A1
            e.Graphics.DrawLine(Pens.Red, 100, 100, 70, 100);//A2A3
            e.Graphics.DrawLine(Pens.Red, 130, 70, 100, 100);//A1A2
            e.Graphics.DrawLine(Pens.Red, 100, 70, 70, 100);//A4A3
            e.Graphics.DrawLine(Pens.Red, 70, 100, 70, 160);//A3A7
            e.Graphics.DrawLine(Pens.Red, 100, 130, 70, 160);//A8A7
            e.Graphics.DrawLine(Pens.Red, 100, 130, 160, 130);//A8A5
            e.Graphics.DrawLine(Pens.Red, 160, 130, 130, 160);//A5A6
            e.Graphics.DrawLine(Pens.Red, 70, 160, 130, 160);//A7A6
            e.Graphics.DrawLine(Pens.Red, 100, 100, 130, 160);//A2A6
            e.Graphics.DrawLine(Pens.Red, 130, 70, 160, 130);//A1A5
            #endregion
        }

        private void ProectionPictureBox_Paint(object sender, PaintEventArgs e)
        {
            //500 x 250
            #region CoordinateLines
            e.Graphics.DrawLine(Pens.Black, 250, 0, 250, 250);
            e.Graphics.DrawLine(Pens.Black, 0, 125, 500, 125);
            #endregion

            #region CubeProection

            e.Graphics.DrawLine(Pens.Red, proection.A1, proection.A2);
            e.Graphics.DrawLine(Pens.Red, proection.A2, proection.A3);
            e.Graphics.DrawLine(Pens.Red, proection.A3, proection.A4);
            e.Graphics.DrawLine(Pens.Red, proection.A4, proection.A1);
            e.Graphics.DrawLine(Pens.Red, proection.A5, proection.A6);
            e.Graphics.DrawLine(Pens.Red, proection.A6, proection.A7);
            e.Graphics.DrawLine(Pens.Red, proection.A7, proection.A8);
            e.Graphics.DrawLine(Pens.Red, proection.A8, proection.A5);
            e.Graphics.DrawLine(Pens.Red, proection.A1, proection.A5);
            e.Graphics.DrawLine(Pens.Red, proection.A2, proection.A6);
            e.Graphics.DrawLine(Pens.Red, proection.A3, proection.A7);
            e.Graphics.DrawLine(Pens.Red, proection.A4, proection.A8);


            #endregion


        }
        private int XCoordinatConvert(double coordinate)
        {
            return 250 + (int)Math.Round(coordinate * zoom);
        }
        private int YCoordinatConvert(double coordinate)
        {
            return 125 + (int)Math.Round(coordinate * zoom);
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            ErrorTextBox.Clear();
            try
            {
                proectionMatrix = new Matrix[8];
                for (int i = 0; i < 8; i++)
                {
                    proectionMatrix[i] = DimetricalProectionBuilder.Build(cube.cubeMatrix[i], Convert.ToDouble(AngleTextBox.Text));
                }
                proection = new Figure(
                    new Point(XCoordinatConvert(proectionMatrix[0][0, 0]), YCoordinatConvert(proectionMatrix[0][0, 1])),
                    new Point(XCoordinatConvert(proectionMatrix[1][0, 0]), YCoordinatConvert(proectionMatrix[1][0, 1])),
                    new Point(XCoordinatConvert(proectionMatrix[2][0, 0]), YCoordinatConvert(proectionMatrix[2][0, 1])),
                    new Point(XCoordinatConvert(proectionMatrix[3][0, 0]), YCoordinatConvert(proectionMatrix[3][0, 1])),
                    new Point(XCoordinatConvert(proectionMatrix[4][0, 0]), YCoordinatConvert(proectionMatrix[4][0, 1])),
                    new Point(XCoordinatConvert(proectionMatrix[5][0, 0]), YCoordinatConvert(proectionMatrix[5][0, 1])),
                    new Point(XCoordinatConvert(proectionMatrix[6][0, 0]), YCoordinatConvert(proectionMatrix[6][0, 1])),
                    new Point(XCoordinatConvert(proectionMatrix[7][0, 0]), YCoordinatConvert(proectionMatrix[7][0, 1]))
                    );
                ProectionPictureBox.Refresh();
            }
            catch (Exception exeption)
            {
                ErrorTextBox.Text = "Wrong angle, can't build proection!";
            }
        }
    }
}
