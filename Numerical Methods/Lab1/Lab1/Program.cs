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
    struct StartValue
    {
        public double x0, y0;
        public StartValue(double x0, double y0)
        {
            this.x0 = x0;
            this.y0 = y0;
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
        static double x0, realResult = 0.60710164810312263123, a = -1, b = 1;
        public static double f(double value)
        {
            return 3 * value - Cos(value) - 1;
        }
        public static double f1(double value)
        {
            return 3 + Sin(value);
        }
        public static double f2(double value)
        {
            return Cos(value);
        }
        public static double HordMethod(double epsilon, Range functionRange, out int steps)
        {
            //f2 = cos(x)>0 xє[1, 1] тому чи буде f(x0)*f2 додатнім залежить від f(x0)
            a = functionRange.less;
            b = functionRange.more;
            steps = 0;
            double x0temp;
            if (f2(a) * f(a) > 0)
            {
                x0 = b;
                do
                {
                    x0temp = x0;
                    x0 = a - (x0 - a) * (f(a) / (f(x0) - f(a)));
                    steps++;
                    if (Abs(x0 - x0temp) <= epsilon)
                    {
                        break;
                    }

                } while (true);
            }
            else if (f2(b) * f(b) > 0)
            {
                x0 = a;
                do
                {
                    x0temp = x0;
                    x0 = x0 - ((b - x0) * (f(x0) / (f(b) - f(x0))));
                    steps++;
                    if (Abs(x0 - x0temp) <= epsilon)
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
        public static double NyutonMethod(double epsilon, Range functionRange, out int steps)
        {
            steps = 0;
            a = functionRange.less;
            b = functionRange.more;
            double x0temp;
            if (f2(a) * f(a) > 0)
            {
                x0 = a;
            }
            else if (f2(b) * f(b) > 0)
            {
                x0 = b;
            }
            else
            {
                return 0;
            }
            do
            {
                x0temp = x0;
                x0 = x0 - (f(x0) / f1(x0));
                steps++;
                if (Abs(x0 - x0temp) <= epsilon)
                {
                    break;
                }
            } while (true);
            return x0;
        }
        public static Range CombineMethod(double epsilon, Range functionRange, out int steps)
        {
            steps = 0;
            a = functionRange.less;
            b = functionRange.more;
            double lesstemp, moretemp, temp;
            double less, more;
            if (f2(a) * f(a) > 0)
            {
                less = a; more = b;
                do
                {
                    moretemp = more;
                    lesstemp = less;
                    more = more - (more - less) * (f(less) / (f(more) - f(less)));
                    less = less - (f(less) / f1(less));
                    steps++;
                    if (Abs(more - moretemp) <= epsilon && Abs(less - lesstemp) <= epsilon)
                    {
                        break;
                    }
                } while (true);
            }
            else if (f2(b) * f(b) > 0)
            {
                less = a; more = b;
                do
                {
                    moretemp = more;
                    lesstemp = less;
                    temp = more;
                    more = more - (f(more) / f1(more));
                    less = less - (temp - less) * (f(less) / (f(temp) - f(less)));
                    steps++;
                    if (Abs(more - moretemp) <= epsilon && Abs(less - lesstemp) <= epsilon)
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
        static double x0 = -1, y0 = -1, realX = -0.945011, realY = -1.09739;
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
        public static SystemAnswer IterationMethod(double epsilon, StartValue functionStartValue, out int steps)
        {
            x0 = functionStartValue.x0; y0 = functionStartValue.y0;
            steps = 0;
            double tempx0, tempy0;
            do
            {
                tempx0 = x0;
                tempy0 = y0;
                x0 = gx(y0);
                y0 = fy(tempx0);
                steps++;
                if (Abs(x0 - tempx0) <= epsilon && Abs(y0 - tempy0) <= epsilon)
                {
                    break;
                }
            } while (true);
            return new SystemAnswer(x0, y0);
        }
        public static SystemAnswer NyutonMethod(double epsilon, StartValue functionStartValue, out int steps)
        {
            x0 = functionStartValue.x0; y0 = functionStartValue.y0;
            steps = 0;
            double tempx, tempy;
            do
            {
                if (Abs(x0 - realX) > epsilon || Abs(y0 - realY) > epsilon)
                {
                    tempx = x0;
                    tempy = y0;
                    x0 = tempx + (deltaXn(tempx, tempy) / deltaN(tempx, tempy));
                    y0 = tempy + (deltaYn(tempx, tempy) / deltaN(tempx, tempy));
                    steps++;
                    if (Abs(x0 - tempx) <= epsilon && Abs(y0 - tempy) <= epsilon)
                    {
                        break;
                    }
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
            int steps;
            Range funcRange = new Range(-1, 1);
            StartValue funcStartValue = new StartValue(-1, -1);
            Console.WriteLine("If you want to put your own epsilon enter 'yes', else epsilon will be 0,0001");
            if (Console.ReadLine() == "yes")
            {
                Console.WriteLine("Please, enter epsilon (with ',' and max epsilon = 1E-15)");
                epsilon = Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine("If you want to use your own range for unlinear equation enter 'yes', else range will be [-1, 1]");
            if (Console.ReadLine() == "yes")
            {
                Console.WriteLine("Please, enter your range: first less, than more");
                funcRange.less = Convert.ToDouble(Console.ReadLine());
                funcRange.more = Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine($"Calculating for unlinear function '3x - cosx - 1 = 0', where real result is x0 = 0.607101648103123 with e = {epsilon}");
            Console.WriteLine($"For Hord Method: x0 =  {UnlinearEquation.HordMethod(epsilon, funcRange, out steps)} with {steps} steps");
            Console.WriteLine($"For Nyuton Method: x0 =  {UnlinearEquation.NyutonMethod(epsilon, funcRange, out steps)} with {steps} steps");
            Console.WriteLine($"For Combine Method: x01 = {UnlinearEquation.CombineMethod(epsilon, funcRange, out steps).less} and x02 = {UnlinearEquation.CombineMethod(epsilon, funcRange, out steps).more} with {steps} steps");
            Console.WriteLine("\nIf you want to use your own start values enter 'yes', else start values will be -1 and -1");
            if (Console.ReadLine() == "yes")
            {
                Console.WriteLine("Please, enter your start values: first x0, than y0");
                funcStartValue.x0 = Convert.ToDouble(Console.ReadLine());
                funcStartValue.y0 = Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine($"\nCalculating for system F = cos(x+0.5) - y = 0 and G = siny -2x - 1 = 0, where real result is x0 = -0.945011 y0 = -1.09839 with e = {epsilon}");
            Console.WriteLine($"For Iteration Method: x0 = {EquationSystem.IterationMethod(epsilon, funcStartValue, out steps).x} and y0 = {EquationSystem.IterationMethod(epsilon, funcStartValue, out steps).y} with {steps} steps");
            Console.WriteLine($"For Nuyton Method: x0 = {EquationSystem.NyutonMethod(epsilon, funcStartValue, out steps).x} and y0 = {EquationSystem.NyutonMethod(epsilon, funcStartValue, out steps).y} with {steps} steps");
            Console.ReadLine();
        }
    }
}
