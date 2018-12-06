using MathFunc = System.Func<double, double>;
using NumericalMethod = System.Func<double, double>;
using static System.Math;

namespace LeastSquares.Models
{
    class NumericalIntegrationMethods : NumericalMethodBase
    {
        // FIELDS
        private GaussPoly[] Gauss4;
        private GaussPoly[] Gauss5;
        // CONSTRUCTORS
        public NumericalIntegrationMethods(double a, double b, MathFunc F)
            : base(a, b, F)
        {
            this.Gauss4 = new GaussPoly[4]
            {
                new GaussPoly { t = -0.861136,  C = 0.3478548 },
                new GaussPoly { t = -0.339981,  C = 0.6521452 },
                new GaussPoly { t = 0.339981,   C = 0.6521452 },
                new GaussPoly { t = 0.861136,   C = 0.3478548 }
            };

            this.Gauss5 = new GaussPoly[5]
            {
                new GaussPoly { t = -0.9061798,  C = 0.2369269 },
                new GaussPoly { t = -0.5384693,  C = 0.4786287 },
                new GaussPoly { t = 0,           C = 0.5688889 },
                new GaussPoly { t = 0.5384693,   C = 0.4786287 },
                new GaussPoly { t = 0.9061798,   C = 0.2369269 }
            };

        }
        // METHODS
        public double RunMethod(NumericalMethod numericalMethod)
        {
            double h = (b - a);

            double prevS;
            double curS = numericalMethod(h);

            do
            {
                h /= 2;
                prevS = curS;
                curS = numericalMethod(h);
            } while (Abs(curS - prevS) > eps);

            return curS;
        }
        // different methods to work with
        public double Rectangle(double h)
        {
            double sum = 0;

            for (double x = a; x <= b; x += h)
            {
                sum += f(x);
            }
            return h * sum;
        }
        public double Trapeze(double h)
        {
            double sum = 0;

            for (double x = a + h; x < b; x += h)
            {
                sum += f(x);
            }

            return (((f(a) + f(b)) / 2) + sum) * h;
        }
        public double Parabola(double h)
        {
            double S1 = 0, S2 = 0;

            for (double x = a + h; x < b; x += h)
            {
                S1 += f(x);
            }
            for (double x = a + h / 2; x <= b; x += h)
            {
                S2 += f(x);
            }

            return (h / 3) * (0.5 * f(a) + S1 + 2 * S2 + 0.5 * f(b));
        }
        public double GaussFour(double h)
        {
            double sum = 0;

            for (double x = a; x < b; x += h)
            {
                double bPaDiv2 = (x + h + x) / 2; // (b + a)/2
                double bMaDiv2 = h / 2; // (b - a)/2
                double curS = 0;
                for (int i = 0; i < Gauss4.Length; ++i)
                {
                    curS += Gauss4[i].C * f(bPaDiv2 + bMaDiv2 * Gauss4[i].t);
                }
                curS *= bMaDiv2;
                sum += curS;
            }

            return sum;
        }
        public double GaussFifth(double h)
        {
            double sum = 0;

            for (double x = a; x < b; x += h)
            {
                double bPaDiv2 = (x + h + x) / 2; // (b + a)/2
                double bMaDiv2 = h / 2; // (b - a)/2

                double curS = 0;
                for (int i = 0; i < Gauss5.Length; ++i)
                {
                    curS += Gauss5[i].C * f(bPaDiv2 + bMaDiv2 * Gauss5[i].t);
                }
                curS *= bMaDiv2;

                sum += curS;
            }

            return sum;
        }
    }
}
