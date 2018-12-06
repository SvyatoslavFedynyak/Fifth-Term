using static System.Math;
using MathFunc = System.Func<double, double>;


namespace LeastSquares.Models
{
    public class LeastSquaresMethod : FunctionApproximationBase
    {
        // CONSTRUCTORS
        public LeastSquaresMethod(double a, double b, int n, MathFunc F)
             : base(a, b, n, F) { }
        // METHODS
        public MethodsResult LeastSquares(double x)
        {
            double reach = 0;
            double result = PolynomialValue(x: x, m: 1);
            int i = 2;

            do
            {
                reach = result;
                try
                {
                    result = PolynomialValue(x: x, m: i);
                }
                catch (System.ArithmeticException)
                {
                    break;
                }

                ++i;

            } while (i < n && System.Math.Abs(reach - result) > eps);

            return new MethodsResult { Y = reach, N = i };
        }
        // PRIVATE METHODS
        public double PolynomialValue(double x, int m)
        {
            double[] a = GetA(m);
            double res = a[0];
            double xPow = x;

            for (int i = 1; i < m; ++i)
            {
                res += a[i] * xPow;
                xPow *= x;// phi func { 1, x^1, x^2, x^3 ... }
            }
            return res;
        }
        private double[] GetA(int m)
        {
            double[,] aMatrix = new double[m, m];
            double[] bVector = new double[m];

            // set A matrix and B vector
            for (int j = 0; j < m; ++j)
            {
                for (int k = 0; k < m; ++k)
                {
                    aMatrix[j, k] = GetPhiPhi(k, j);
                }

                bVector[j] = GetFPhi(j);
            }
            // calc SOLE with Gauss Method
           return new GaussSole(aMatrix, bVector, eps).Run();            
        }
        private double GetPhi(int index, double x)
        {
            return Pow(x, index);
        }
        private double GetPhiPhi(int k, int j)
        {
            double sum = 0;
            for (int i = 0; i < n; ++i)
            {
                sum += GetPhi(index: k, x: X[i]) * GetPhi(index: j, x: X[i]);
            }
            return sum;
        }
        private double GetFPhi(int j)
        {
            double sum = 0;
            for (int i = 0; i < n; ++i)
            {
                sum += Y[i] * GetPhi(index: j, x: X[i]);
            }
            return sum;
        }

    }
}
