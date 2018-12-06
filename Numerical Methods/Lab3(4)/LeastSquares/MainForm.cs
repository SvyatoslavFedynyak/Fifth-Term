using FancyControls.Data;
using static System.Math;
using LeastSquares.Models;
using static System.Drawing.Color;
using MathFunc = System.Func<double, double>;

namespace LeastSquares
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        // FIELDS
        readonly double a;
        readonly double b;
        readonly int n;
        double eps;
        readonly MathFunc f;

        readonly InterpolationMethods interpolation;
        readonly LeastSquaresMethod leastSquares;
        readonly CalcMistake mistake;

        // CONSTRUCTORS
        public MainForm()
        {
            InitializeComponent();

            a = 1;
            b = 3;
            n = 20;
            eps = 1e-15;
            f = (x) => 1/x;

            interpolation = new InterpolationMethods(a, b, n, f);
            leastSquares = new LeastSquaresMethod(a, b, n, f);
            mistake = new CalcMistake();

            DrawGraphics();
        }
        // METHODS
        private void DrawGraphics()
        {
            nodeGraph.Clear();
            gaussGraph.Clear();
            newtonGraph.Clear();
            squaresGraph.Clear();            

            nodeGraph.ShowGraphs(new Graph("x*3^x", GraphType.Point)
            {
                LineWidth = 4,
                LineColor = FromArgb(65, 140, 240) // blue-ish 
            }.AddFunction(f, a, b, (b - a) / 20));

            gaussGraph.ShowGraphs(new Graph("Gauss Forward", GraphType.Line)
            {
                LineWidth = 4,
                LineColor = FromArgb(240, 90, 60) // red-ish                
            }.AddFunction((double x) => interpolation.GaussForward(x).Y, a, b));

            newtonGraph.ShowGraphs(new Graph("Newton Forward", GraphType.Line)
            {
                LineWidth = 4,
                LineColor = FromArgb(175, 210, 95) // green-ish
            }.AddFunction((double x) => interpolation.NewtonForward(x).Y, a, b));
            
            squaresGraph.ShowGraphs(new Graph("Least Squares", GraphType.Line)
            {
                LineWidth = 4,
                LineColor = FromArgb(235, 235, 90) // yellow-ish
            }.AddFunction((double x) => leastSquares.LeastSquares(x).Y, a, b));
        }

        private void calcBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                // get values
                double x = double.Parse(xTb.Text);
                if (x < a || x > b)
                {
                    ErrorMessage("x є [a, b]");
                    return;
                }

                eps = double.Parse(epsTb.Text);
                // dont want to f*ck around threads, so yeah... byte
                byte l2Accurancy = byte.Parse(l2AccurancyTb.Text);
                double fRes = f(x);

                // config
                interpolation.Eps = eps;
                leastSquares.Eps = eps;

                // calc
                MethodsResult newtonRes = interpolation.NewtonForward(x);
                MethodsResult gaussRes = interpolation.GaussForward(x);
                MethodsResult leastSquaresRes = leastSquares.LeastSquares(x);

                // res
                functionResLbl.Text = fRes.ToString();
                newtonResultLbl.Text = newtonRes.Y.ToString();
                gaussResultLbl.Text = gaussRes.Y.ToString();
                leastSquaresResultLbl.Text = leastSquaresRes.Y.ToString();

                // members number
                newtonMemberCountLbl.Text = newtonRes.N.ToString();
                gaussMemberCountLbl.Text = gaussRes.N.ToString();
                leastSquaresMemberCountLbl.Text = leastSquaresRes.N.ToString();

                // mistake
                newtonMistakeLbl.Text = mistake.CalcValueMistake(fRes, newtonRes.Y).ToString();
                gaussMistakeLbl.Text = mistake.CalcValueMistake(fRes, gaussRes.Y).ToString(); 
                leastSquaresMistakelbl.Text = mistake.CalcValueMistake(fRes, leastSquaresRes.Y).ToString(); 

                // L2 mistake
                l2NewtonMistakeLbl.Text = mistake.CalcFunctionMistake(a, b, l2Accurancy, f, (double X) => interpolation.NewtonForward(X).Y).ToString();
                l2GaussMistakeLbl.Text = mistake.CalcFunctionMistake(a, b, l2Accurancy, f, (double X) => interpolation.GaussForward(X).Y).ToString();
                l2LeastSquaresMistakeLbl.Text = mistake.CalcFunctionMistake(a, b, l2Accurancy, f, (double X) => leastSquares.LeastSquares(X).Y).ToString();


                DrawGraphics();
            }
            catch (System.Exception ex)
            {
                ErrorMessage(ex.Message);
            }
        }
        private void ErrorMessage(string message, string header = "Error")
        {
            System.Windows.Forms.MessageBox.Show(message, header,
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Error,
                System.Windows.Forms.MessageBoxDefaultButton.Button1);
        }
    }
}
