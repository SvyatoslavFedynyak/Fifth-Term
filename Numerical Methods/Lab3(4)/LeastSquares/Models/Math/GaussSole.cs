using static System.Math;

namespace LeastSquares.Models
{
    class GaussSole
    {
        // FIELDS
        private double[,] aMatrix;
        private double[,] workAMatrix; 

        private double[] bVector;
        private double[] workBVector;

        private double[] xVector;

        private double eps; // accurancy order for real numbers
        private int size;            

        // CONSTRUCTORS
        public GaussSole(double[,] aMatrix, double[] bVector)
            : this(aMatrix, bVector, 0.0001)  {   }

        public GaussSole(double[,] aMatrix, double[] bVector, double eps)
        {
            if (aMatrix == null) throw new System.ArgumentNullException("A matrix is null.");
            if (bVector == null) throw new System.ArgumentNullException("B vector is null.");

            int bSize = bVector.Length;
            int aSize = aMatrix.Length;

            if (aSize != bSize * bSize)
            {
                throw new System.ArgumentException(@"The amount of rows and cols in A matrix should be equal to amount of cols in B Vector");
            }

            this.aMatrix = aMatrix; 
            this.workAMatrix = (double[,])aMatrix.Clone(); 

            this.bVector = bVector; 
            this.workBVector = (double[])bVector.Clone(); 

            this.xVector = new double[bSize];

            this.size = bSize;
            this.eps = eps;
        }
        // METHODS        
        public double[] Run()
        {
            int[] index = InitIndex();
            GaussForwardStroke(index);
            GaussBackwardStroke(index);
            return xVector;
        }
        // PRIVATE METHODS
        // initialize an array of row's indices
        private int[] InitIndex()
        {
            int[] index = new int[size];
            for (int i = 0; i < index.Length; ++i)
            {
                index[i] = i;
            }
            return index;
        }

        // finding a main element in matrix
        private double FindR(int row, int[] index)
        {
            int max_index = row;
            double max = workAMatrix[row, index[max_index]];
            double max_abs = Abs(max);
            
            // if (row < size - 1)
            for (int cur_index = row + 1; cur_index < size; ++cur_index)
            {
                double cur = workAMatrix[row, index[cur_index]];
                double cur_abs = Abs(cur);
                if (cur_abs > max_abs)
                {
                    max_index = cur_index;
                    max = cur;
                    max_abs = cur_abs;
                }
            }

            if (max_abs < eps)
            {
                if (Abs(workBVector[row]) > eps)   throw new System.ArithmeticException("The system of equations is incompatible.");
                else                               throw new System.ArithmeticException("The system of equations has many solutions.");
            }

            // swaping row's indices
            int temp = index[row];
            index[row] = index[max_index];
            index[max_index] = temp;

            return max;
        }

        
        private void GaussForwardStroke(int[] index)
        {
            // moving on each row from top to bottom
            for (int i = 0; i < size; ++i)
            {
                // 1) select main element
                double r = FindR(i, index);
                
                // 2) changing current A matrix row
                for (int j = 0; j < size; ++j)
                {
                    workAMatrix[i, j] /= r;
                }
                
                // 3) changing element at index I in B vector
                workBVector[i] /= r;

                // 4) subtract the current row from all the rows below
                for (int k = i + 1; k < size; ++k)
                {
                    double p = workAMatrix[k, index[i]];
                    for (int j = i; j < size; ++j)
                    {
                        workAMatrix[k, index[j]] -= workAMatrix[i, index[j]] * p;
                    }
                    workBVector[k] -= workBVector[i] * p;
                    workAMatrix[k, index[i]] = 0D;
                }
            }
        }
        
        private void GaussBackwardStroke(int[] index)
        {
            // moving on each row from bottom to top
            for (int i = size - 1; i >= 0; --i)
            {
                // 1) initialize start value of x
                double x_i = workBVector[i];

                // 3) updating x
                for (int j = i + 1; j < size; ++j)
                {
                    x_i -= xVector[index[j]] * workAMatrix[i, index[j]];
                }
                xVector[index[i]] = x_i;
            }
        }
    }
}
