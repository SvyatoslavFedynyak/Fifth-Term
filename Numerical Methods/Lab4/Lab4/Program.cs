using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathFunc = System.Func<double, double>;
using static System.Math;

namespace Lab4
{
    public delegate double NumericalMethod(double h, ref int iteration);
    public delegate double GaussMethod(ref int iteration);
    public struct NumericMethodResult
    {
        public double S { get; set; }
        public int CallAmount { get; set; }
        public int IterationAmount { get; set; }
    }
    public struct GaussPoly
    {
        public double t { get; set; }
        public double C { get; set; }
    }
    public class NumericalIntegrationMethods
    {
        // FIELDS
        private readonly double a;
        private readonly double b;
        private double eps;
        private MathFunc f;

        private GaussPoly[] Gauss4;
        private GaussPoly[] Gauss5;
        private double bPaDiv2;
        private double bMaDiv2;

        public NumericalIntegrationMethods(double a, double b)
        {
            this.a = a;
            this.b = b;
            this.Gauss4 = new GaussPoly[4]
            {
                new GaussPoly { t = -0.8611363, C = 0.3478548 },
                new GaussPoly { t= -0.339981,   C = 0.6521452 },
                new GaussPoly { t = 0.339981,   C = 0.6521452 },
                new GaussPoly { t = 0.861136,   C = 0.3478548 }
            };

            this.Gauss5 = new GaussPoly[5]
            {
                new GaussPoly { t = -0.9061798,  C = 0.2369269 },
                new GaussPoly { t= -0.5384693,   C = 0.4786287 },
                new GaussPoly { t = 0,           C = 0.5688889 },
                new GaussPoly { t = 0.5384693,   C = 0.4786287 },
                new GaussPoly { t = 0.9061798,   C = 0.2369269 }
            };
            this.bPaDiv2 = (b + a) / 2;
            this.bMaDiv2 = (b - a) / 2;

        }
        public MathFunc F
        {
            get
            {
                return f;
            }
            set
            {
                f = value;
            }
        }
        public double EPS
        {
            get
            {
                return eps;
            }
            set
            {
                eps = value;
            }
        }
        public NumericMethodResult TestMethod(NumericalMethod numericalMethod)
        {
            double h = (b - a);
            int call = 0;
            int iteration = 0;

            double prevS;
            double curS = numericalMethod(h, ref iteration);

            do
            {
                h /= 2;
                prevS = curS;
                curS = numericalMethod(h, ref iteration);

                ++call;
            } while (Abs(curS - prevS) > eps);

            return new NumericMethodResult()
            {
                S = curS,
                CallAmount = call,
                IterationAmount = iteration
            };
        }
        public NumericMethodResult TestMethod(GaussMethod gaussMethod)
        {
            int iteration = 0;
            double curS = gaussMethod(ref iteration);

            return new NumericMethodResult()
            {
                S = curS,
                CallAmount = 1,
                IterationAmount = iteration
            };
        }
        public double Rectangle(double h, ref int iteration)
        {
            double sum = 0;
            iteration = 0;

            for (double x = a; x <= b; x += h)
            {
                sum += f(x);
                ++iteration;
            }
            return h * sum;
        }
        public double Trapeze(double h, ref int iteration)
        {
            double sum = 0;
            iteration = 0;

            for (double x = a + h; x < b; x += h)
            {
                sum += f(x);
                ++iteration;
            }

            return (((f(a) + f(b)) / 2) + sum) * h;
        }
        public double Parabola(double h, ref int iteration)
        {
            double S1 = 0, S2 = 0;
            iteration = 1;

            for (double x = a + h; x < b; x += h)
            {
                S1 += f(x);
                ++iteration;
            }
            for (double x = a + h / 2; x <= b; x += h)
            {
                S2 += f(x);
                ++iteration;
            }

            return (h / 3) * (0.5 * f(a) + S1 + 2 * S2 + 0.5 * f(b));
        }
        public double GaussFour(ref int iteration)
        {
            double sum = 0;
            iteration = 0;

            for (int i = 0; i < Gauss4.Length; ++i)
            {
                sum += Gauss4[i].C * f(bPaDiv2 + bMaDiv2 * Gauss4[i].t);
                ++iteration;
            }

            return bMaDiv2 * sum;
        }
        public double GaussFifth(ref int iteration)
        {
            double sum = 0;
            iteration = 0;

            for (int i = 0; i < Gauss5.Length; ++i)
            {
                sum += Gauss5[i].C * f(bPaDiv2 + bMaDiv2 * Gauss5[i].t);
                ++iteration;
            }

            return bMaDiv2 * sum;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, eps, start_h = 0.01;
            int iter = 0;
            Console.WriteLine("Enter range\nEnter a:");
            a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter b:");
            b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter eps:");
            eps = Convert.ToDouble(Console.ReadLine());
            NumericalIntegrationMethods calculator = new NumericalIntegrationMethods(a, b);
            calculator.EPS = eps;
            calculator.F = new MathFunc((value) =>
           { return 1 / value; });
            Console.WriteLine($"Calculated by rectangle: {calculator.Rectangle(start_h, ref iter)} with {iter}");
            Console.WriteLine($"Calculated by tapeze: {calculator.Trapeze(start_h, ref iter)} with {iter}");
            Console.WriteLine($"Calculated by parabola: {calculator.Parabola(start_h, ref iter)} with {iter}");
            Console.WriteLine($"Calculated by gaus4: {calculator.GaussFour(ref iter)} with {iter}");
            Console.WriteLine($"Calculated by gaus5: {calculator.GaussFifth(ref iter)} with {iter}");
            Console.ReadLine();
        }
    }
}
