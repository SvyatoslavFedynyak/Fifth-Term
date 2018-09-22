using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Lab1
{
    class Matrix
    {
        int numOfRows;
        int numOfColls;
        double[,] items;
        public Matrix(double[,] arr)
        {
            items = arr;
            numOfColls = arr.GetLength(1);
            numOfRows = arr.GetLength(0);
        }
        public Matrix(int numOfRows, int numOfColls)
        {
            items = new double[numOfRows, numOfColls];
            this.numOfRows = numOfRows;
            this.numOfColls = numOfColls;
        }
        public double this[int row, int col]
        {
            get { return items[row, col]; }
            set { items[row, col] = value; }
        }
        public static Matrix operator *(Matrix first, Matrix second)
        {
            int resultMatrixColls, resultMatrixRows;
            #region Result Matrix Size Check
            if (first.numOfColls >= second.numOfColls)
            {
                resultMatrixColls = second.numOfColls;
            }
            else
            {
                resultMatrixColls = first.numOfColls;
            }
            if (first.numOfRows >= second.numOfRows)
            {
                resultMatrixRows = second.numOfRows;
            }
            else
            {
                resultMatrixRows = first.numOfRows;
            }
            #endregion
            Matrix result = new Matrix(resultMatrixRows, resultMatrixColls);
            double resultElement = 0;
            for (int i = 0; i < resultMatrixRows; i++)
            {
                for (int j = 0; j < resultMatrixColls; j++)
                {
                    for (int k = 0; k < second.numOfRows; k++)
                    {
                        resultElement += first[i, k] * second[k, j];
                    }
                    result[i, j] = resultElement;
                    resultElement = 0;
                }
            }
            return result;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numOfRows; i++)
            {
                for (int j = 0; j < numOfColls; j++)
                {
                    sb.AppendFormat($"{items[i, j]} ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
    static class DimetricalProectionBuilder
    {
        static DimetricalProectionBuilder()
        {

        }
        public static Matrix Build(Matrix transportMatrix, Matrix target)
        {
            return target * transportMatrix;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            double[,] arr1 = new double[,]
            {
                 {4, 6},
                {7, 8 }
            };
            double[,] arr2 = new double[,]
            {
                 {3, 8, 2},
                {5, 2, 8}
            };
            Matrix main = new Matrix(arr1);
            Console.WriteLine(main.ToString());
            Matrix second = new Matrix(arr2);
            Console.WriteLine(second.ToString());
            Matrix res = main * second;
            Console.WriteLine(res.ToString());
            Console.ReadLine();
        }
    }
}
