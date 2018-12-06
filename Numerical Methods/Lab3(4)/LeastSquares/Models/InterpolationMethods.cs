using MathFunc = System.Func<double, double>;

namespace LeastSquares.Models
{
    public class InterpolationMethods : FunctionApproximationBase
    {
        // FIELDS
        private double[][] deltaY;// order, y index
        // CONSTRUCTORS
        public InterpolationMethods(double a, double b, int N, MathFunc F)
            : base(a, b, N, F)
        {
            this.CalcFiniteDifference();
        }
        
        private InterpolationMethods CalcFiniteDifference()
        {
            // for one Method is better to calculate
            // each row separately, not the matrix at once
            this.deltaY = new double[n][];

            // first deltas is just Y
            deltaY[0] = (double[])Y.Clone();

            // calc next delta, start from 1
            for (int i = 1; i < n; ++i)
            {
                // next orders is one less than previous
                deltaY[i] = new double[n - i];
                for (int j = 0; j < n - i; ++j)
                {
                    // next order depends on previous
                    deltaY[i][j] = deltaY[i - 1][j + 1] - deltaY[i - 1][j];
                }
            }
            return this;
        }
        // PROPERTIES
        public override MathFunc F
        {
            get
            {
                return base.F;
            }
            set
            {
                base.F = value;

                CalcFiniteDifference();
            }
        }
        // METHODS
        public MethodsResult NewtonForward(double x)
        {
            double result = Y[0];
            double reach = double.PositiveInfinity;

            double t = (x - X[0]) / h;
            double accumulateT = 1;
            double nFact = 1;// also could be in array

            int i = 1;
            while (i < n && System.Math.Abs(reach - result) > eps)
            {
                accumulateT *= t - i + 1;
                nFact *= i;

                reach = result;
                result += accumulateT / nFact * deltaY[i][0];

                ++i;
            }

            return new MethodsResult { Y = result, N = i };
        }
        public MethodsResult GaussForward(double x)
        {
            int c = N / 2 - 1;

            double result = Y[c];
            double reach = double.PositiveInfinity;
            double t = (x - X[c]) / h;
            double accumulateT = 1;
            double nFact = 1;// also could be in array

            int i = 1;
            while (i < n && System.Math.Abs(reach - result) > eps)
            {
                int num = i / 2;
                if (i % 2 == 0)
                {
                    num = -num;
                    --c;
                }

                accumulateT *= t + num;
                nFact *= i;

                reach = result;
                result += accumulateT / nFact * deltaY[i][c];

                ++i;
            }

            return new MethodsResult { Y = result, N = i };
        }
    }
}