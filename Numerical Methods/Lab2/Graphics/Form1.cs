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

namespace Graphics
{
    public partial class Form1 : Form
    {
        double precision = 0.00001;
        int numOfPointInGraph = 500;
        double step = 0.004;
        double begin = 1, end = 3;
        Pair[] original;
        Pair[] forward;
        Pair[] backward;
        public Form1()
        {
            InitializeComponent();
            original = new Pair[numOfPointInGraph];
            forward = new Pair[numOfPointInGraph];
            backward = new Pair[numOfPointInGraph];
            buildOriginal();
            buildForward();
            graphicPictureBox.Refresh();
        }
        private Pair convertCoord(Pair value)
        {
            return new Pair((value.x - 1) * 250, 500 * (1 - value.y));
        }

        private void graphicPictureBox_Paint(object sender, PaintEventArgs e)
        {
            Bitmap black = new Bitmap(1, 1);
            black.SetPixel(0, 0, Color.Black);
            Bitmap red = new Bitmap(1, 1);
            red.SetPixel(0, 0, Color.Red);
            Pair location;
            #region Original

            for (int i = 0; i < numOfPointInGraph; i++)
            {
                location = convertCoord(new Pair(original[i].x, original[i].y));
                e.Graphics.DrawImage(black, new PointF((float)location.x, (float)location.y));
            }

            #endregion
            #region Forward

            for (int i = 0; i < numOfPointInGraph; i++)
            {
                location = convertCoord(new Pair(forward[i].x, forward[i].y));
                e.Graphics.DrawImage(red, new PointF((float)location.x, (float)location.y));
            }

            #endregion

        }

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
    }
}
