using MathFunc = System.Func<double, double>;

namespace LeastSquares.Models
{
    public abstract class NumericalMethodBase
    {
        // FIELDS
        protected readonly double a;
        protected readonly double b;
        protected double eps;
        protected MathFunc f;

        // CONSTRUCTORS
        public NumericalMethodBase(double a, double b, MathFunc F)
        {
            this.a = a;
            this.b = b;
            this.f = F;
            this.eps = 1e-5;
        }

        // PROPERTIES
        public virtual double A => a;
        public virtual double B => b;
        public virtual MathFunc F
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
        public virtual double Eps
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
    }
}
