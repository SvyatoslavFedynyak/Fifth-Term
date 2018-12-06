using MathFunc = System.Func<double, double>;

namespace LeastSquares.Models
{
    public abstract class FunctionApproximationBase : NumericalMethodBase
    {
        // FIELDS
        protected readonly int n;
        protected readonly double h;
        protected double[] X;
        protected double[] Y;
        // CONSTRUCTORS
        public FunctionApproximationBase(double a, double b, int N, MathFunc F)
            : base(a, b, F)
        {
            this.n = N;
            this.h = (b - a) / N;
            this.SetsNodes();
        }
        // PROPERTIES
        public double H => h;
        public int N => n;
        // METHODS
        protected FunctionApproximationBase SetsNodes()
        {
            this.X = new double[n];
            this.Y = new double[n];
            for (int i = 0; i < n; ++i)
            {
                X[i] = a + i * h;
                Y[i] = f(X[i]);
            }
            return this;
        }
    }
}