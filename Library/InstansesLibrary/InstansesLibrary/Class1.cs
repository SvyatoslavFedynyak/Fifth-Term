using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstansesLibrary
{
    public static class Functions
    {
        public static void FullArrayWithRandom(double[] array, int min, int max, Random randomiser)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = randomiser.Next(min, max);
            }
        }
    }

    public class Matrix
    {
        int numOfRows;
        int numOfColls;
        double[,] items;
        public int Rang
        {
            get
            {
                if (numOfColls == numOfRows)
                {
                    return numOfRows;
                }
                else
                {
                    return 0;
                }
            }
        }
        public int Coll
        {
            get { return numOfColls; }
        }
        public int Row
        {
            get { return numOfRows; }
        }
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
            get
            {
                return items[row, col];
            }
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
        public string ToString(int degress)
        {
            StringBuilder sb = new StringBuilder();
            string temp;
            for (int i = 0; i < numOfRows; i++)
            {
                for (int j = 0; j < numOfColls; j++)
                {
                    if (items[i, j] == 0)
                    {
                        sb.Append("0.000 ");
                    }
                    else
                    {
                        sb.AppendFormat("{0:0.###} ", items[i, j]);
                    }

                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public Matrix Copy()
        {
            Matrix result = new Matrix(numOfRows, numOfColls);
            for (int i = 0; i < numOfRows; i++)
            {
                for (int j = 0; j < numOfRows; j++)
                {
                    result[i, j] = this[i, j];
                }
            }
            return result;
        }
    }
    public struct Range
    {
        public double begin, end;
        public Range(double begin, double end)
        {
            this.begin = begin;
            this.end = end;
        }
    }
}
