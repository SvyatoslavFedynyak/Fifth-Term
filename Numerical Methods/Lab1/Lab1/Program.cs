using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Lab1
{
    struct Range
    {
        public double less, more;
        public Range(double less, double more)
        {
            this.less = less;
            this.more = more;
        }
    }
    struct SystemAnswer
    {
        public double x, y;
        public SystemAnswer(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
    static class UnlinearEquation
    {
        //3x - cos(x) - 1 = 0
        static double x0, realResult = 0.6071, a = -1, b = 1;
        public static double f(double value)
        {
            return 3 * value - Cos(value) - 1;
        }
        public static double f1(double value)
        {
            return 3 + Sin(value);
        }
        public static double HordMethod(double epsilon)
        {
            //f2 = cos(x)>0 xє[1, 1] тому чи буде f(x0)*f2 додатнім залежить від f(x0)
            if (f(a) > 0)
            {
                x0 = b;
                do
                {
                    if (Abs(x0 - realResult) > epsilon)
                    {
                        x0 = a - (x0 - a) * (f(a) / (f(x0) - f(a)));
                    }
                    else
                    {
                        break;
                    }
                } while (true);
            }
            else if (f(b) > 0)
            {
                x0 = a;
                do
                {
                    if (Abs(x0 - realResult) > epsilon)
                    {
                        x0 = x0 - ((b - x0) * (f(x0) / (f(b) - f(x0))));
                    }
                    else
                    {
                        break;
                    }
                } while (true);
            }
            else
            {
                x0 = 0;
            }
            return x0;
        }
        public static double NyutonMethod(double epsilon)
        {
            if (f(a) > 0)
            {
                x0 = a;
            }
            else if (f(b) > 0)
            {
                x0 = b;
            }
            else
            {
                return 0;
            }
            do
            {
                if (Abs(x0 - realResult) > epsilon)
                {
                    x0 = x0 - (f(x0) / f1(x0));
                }
                else
                {
                    break;
                }
            } while (true);
            return x0;
        }
        public static Range CombineMethod(double epsilon)
        {
            double less, more;
            if (f(a) > 0)
            {
                less = a; more = b;
                do
                {
                    if (Abs(less - realResult) > epsilon || Abs(more - realResult) > epsilon)
                    {
                        more = more - (more - less) * (f(less) / (f(more) - f(less)));
                        less = less - (f(less) / f1(less));
                    }
                    else
                    {
                        break;
                    }
                } while (true);
            }
            else if (f(b) > 0)
            {
                less = a; more = b;
                do
                {
                    if (Abs(less - realResult) > epsilon || Abs(more - realResult) > epsilon)
                    {
                        more = more - (f(more) / f1(more));
                        less = less - (more - less) * (f(less) / (f(more) - f(less)));
                    }
                    else
                    {
                        break;
                    }
                } while (true);
            }
            else
            {
                return new Range(0, 0);
            }
            return new Range(less, more);
        }
    }
    static class EquationSystem
    {
        // F = cos(x+0.5) - y = 2 // y = cos(x+0.5) - 2
        //G = siny - 2x =1 // x = 0.5siny - 0.5
        //F'x = -sin(x+0.5)
        //G'x = - 2
        //F'y = -1
        //G'y = cosy 
        static double x0, y0, a = -2, b = 0, c = -2, d = 0, realX = -0.945011, realY = -1.09739;
        private static double F(double x, double y)
        {
            return Cos(x + 0.5) - y - 2;
        }
        private static double G(double x, double y)
        {
            return Sin(y) - 2 * x - 1;
        }
        private static double fy(double x)
        {
            return Cos(x + 0.5) - 2;
        }
        private static double gx(double y)
        {
            return 0.5 * Sin(y) - 0.5;
        }
        private static double F1x(double x)
        {
            return -Sin(x + 0.5);
        }
        private static double G1y(double y)
        {
            return Cos(y);
        }
        private static double deltaN(double x, double y)
        {
            return (F1x(x) * G1y(y)) - 2;
        }
        private static double deltaXn(double x, double y)
        {
            return -(F(x, y) * G1y(y) - G(x, y) * (-1));
        }
        private static double deltaYn(double x, double y)
        {
            return F(x, y) * (-2) - G(x, y) * F1x(x);
        }
        public static SystemAnswer IterationMethod(double epsilon)
        {
            x0 = -1; y0 = -1;
            double temp;
            do
            {
                if (Abs(x0 - realX) > epsilon || Abs(y0 - realY) > epsilon)
                {
                    temp = x0;
                    x0 = gx(y0);
                    y0 = fy(temp);
                }
                else
                {
                    break;
                }
            } while (true);
            return new SystemAnswer(x0, y0);
        }
        public static SystemAnswer NyutonMethod(double epsilon)
        {
            x0 = -1;
            y0 = -1;
            double tempx, tempy;
            do
            {
                if (Abs(x0 - realX) > epsilon || Abs(y0 - realY) > epsilon)
                {
                    tempx = x0;
                    tempy = y0;
                    x0 = tempx + (deltaXn(tempx, tempy) / deltaN(tempx, tempy));
                    y0 = tempy + (deltaYn(tempx, tempy) / deltaN(tempx, tempy)); 
                }
                else
                {
                    break;
                }
            } while (true);
            return new SystemAnswer(x0, y0);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double epsilon = 0.0001;
            Console.WriteLine("Please, enter epsilon (with ',')");
            epsilon = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Calculating for unlinear function '3x - cosx - 1 = 0', where real result is x0 = 0.607102 with e = {epsilon}");
            Console.WriteLine($"For Hord Method: x0 =  {UnlinearEquation.HordMethod(epsilon)}");
            Console.WriteLine($"For Nyuton Method: x0 =  {UnlinearEquation.NyutonMethod(epsilon)}");
            Console.WriteLine($"For Combine Method: x01 = {UnlinearEquation.CombineMethod(epsilon).less} and x02 = {UnlinearEquation.CombineMethod(epsilon).more}");
            Console.WriteLine($"Calculating for system F = cos(x+0.5) - y = 0 and G = siny -2x - 1 = 0, where real result is x0 = -0.945011 y0 = -1.09839 with e = {epsilon}");
            Console.WriteLine($"For Iteration Method: x0 = {EquationSystem.IterationMethod(epsilon).x} and y0 = {EquationSystem.IterationMethod(epsilon).y}");
            Console.WriteLine($"For Nuyton Method: x0 = {EquationSystem.NyutonMethod(epsilon).x} and y0 = {EquationSystem.NyutonMethod(epsilon).y}");
            Console.ReadLine();
        }
    }
}
