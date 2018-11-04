using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace Classes
{
    namespace Classes
    {
        public class Alphabet
        {
            public static Func<string, string> TextAdapter;
            // FIELDS
            SortedSet<char> letter;
            // PROPERTIES
            public int Lenght => letter.Count;
            public char[] Letters => Enumerable.ToArray(letter);
            // CONSTRUCTORS
            public Alphabet(string letter)
            {
                this.letter = new SortedSet<char>();
                this.AddLetters(letter);
            }
            static Alphabet()
            {
                TextAdapter = (s) => System.Text.RegularExpressions.Regex.Replace(s.ToLower(), @"\s+", " ");
            }
            // METHODS
            public void AddLetters(string letters)
            {
                foreach (char l in TextAdapter(letters))
                {
                    this.letter.Add(l);
                }
            }
        }
        public class Matrix
        {
            // FIELDS
            Matrix<float> matrix;
            MatrixBuilder<float> builder;
            int row;
            int col;

            // CONSTRUCTOR
            public Matrix(int row, int col, IEnumerable<int> enumerable)
            {
                this.row = row;
                this.col = col;
                builder = Matrix<float>.Build;
                this.matrix = builder.DenseOfColumnMajor(row, col, enumerable.Select(i => (float)i));
            }
            public Matrix(int row, int col)
            {
                this.row = row;
                this.col = col;
                builder = Matrix<float>.Build;
                this.matrix = builder.Dense(row, col, 0);
            }
            // PROPERTIRS
            public int RowCount => row;
            public int ColCount => col;
            // INDEXIERS
            public float this[int i, int j]
            {
                get
                {
                    return matrix[i, j];
                }
                set
                {
                    matrix[i, j] = value;
                }
            }
            // METHODS
            public float Determinant()
            {
                return matrix.Determinant();
            }
            public Matrix Adjugate()
            {
                Matrix adjugate = new Matrix(row, col);

                if (row == 1 || col == 1) return adjugate;
                for (int i = 0; i < row; ++i)
                {
                    for (int j = 0; j < col; ++j)
                    {
                        int val = System.Convert.ToInt32(Minor(j, i).Determinant());
                        if ((i + j) % 2 != 0) val = -val;
                        adjugate[i, j] = val;
                    }
                }

                return adjugate;
            }
            public Matrix InverseByModule(int module)
            {
                int reverseDeterminant = Algorithms.ReverseByModule((System.Convert.ToInt32(this.Determinant())), module);
                Matrix a = this.Adjugate();
                a.matrix = a.matrix.Modulus(module).Multiply(reverseDeterminant).Modulus(module);
                return a;
            }
            public Matrix<float> Minor(int i, int j)
            {
                return matrix.RemoveRow(i).RemoveColumn(j);
            }
            // OPERATORS
            public static Matrix operator *(Matrix m, float r)
            {
                Matrix res = new Matrix(m.RowCount, m.ColCount);
                res.matrix = res.matrix.Multiply(r);
                return res;
            }
            public static Vector operator *(Matrix l, Vector r)
            {
                return new Vector()
                {
                    InnerVector = l.matrix.LeftMultiply(r.InnerVector)
                };
            }
        }
        public static class Algorithms
        {
            public static int GCD(int n, int m)
            {
                return (int)MathNet.Numerics.Euclid.GreatestCommonDivisor(n, m);
            }
            public static int ReverseByModule(int n, int m)
            {
                long x, y;
                MathNet.Numerics.Euclid.ExtendedGreatestCommonDivisor(n, m, out x, out y);
                return System.Convert.ToInt32(x);
            }
        }
        public class Vector
        {
            public MathNet.Numerics.LinearAlgebra.Vector<float> InnerVector { get; set; }
            public int Size => InnerVector.Count;
            public Vector(System.Collections.Generic.IEnumerable<int> enumerable)
            {
                InnerVector =
                    MathNet.Numerics.LinearAlgebra.Vector<float>.Build.DenseOfEnumerable(
                        System.Linq.Enumerable.Select(enumerable, (i => (float)i))
                        );
            }
            public Vector()
            {
                InnerVector = null;
            }
            public System.Collections.Generic.IEnumerable<int> Enumerator()
            {
                return System.Linq.Enumerable.Select(InnerVector.Enumerate(), f => (int)f);
            }
        }
    }
}
