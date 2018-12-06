using static System.Math;
using MathFunc = System.Func<double, double>;

namespace LeastSquares.Models
{
    public class CalcMistake
    {
        public double CalcValueMistake(double v1, double v2)
        {
            return Abs(v1 - v2);
        }
        public double CalcFunctionMistake(double a, double b, byte n, MathFunc f1, MathFunc f2)
        {
            NumericalIntegrationMethods integral = new NumericalIntegrationMethods(a, b, (double x) => Pow(f1(x) - f2(x), 2));
            return Sqrt(integral.GaussFifth(h: (b - a)/n));
        }
    }
}
