using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Lab1
{
    public class Matrix
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
                    sb.AppendFormat($"{Math.Round(items[i, j], 2)} ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
    public static class DimetricalProectionBuilder
    {
        /*
            * (cos(Q)  sin(Q)sin(f)  -sin(Q)cos(f)  0)
            * (0         cos(f)          sin(f)     0)
            * (sin(Q)  -cos(Q)sin(f) cos(Q)cos(f)   0)
            * (0            0              0        1)
            */
        //f2 = -10.12
        //q2 = -5.28
        //f3 = 5.58
        //q3 = 10.42
        static DimetricalProectionBuilder()
        {

        }
        static private double GetQ(double f)
        {
            return Asin(Sqrt(Pow(Cos(f), 2) / (1 - Pow(Cos(f), 2))));
        }
        public static Matrix Build(Matrix target, double f)
        {
            double Q = GetQ(f);
            Matrix dimetricalBuildMatrix = new Matrix(new double[,]
                {
                    {Cos(Q), Sin(Q)*Sin(f), 0, 0 },
                    {0, Cos(f), 0, 0 },
                    {Sin(Q), -Cos(Q)*Sin(f), 0, 0 },
                    {0, 0, 0, 1 }
                });
            return target * dimetricalBuildMatrix;
        }

    }
    public class CuttedCube
    {
        public Matrix[] cubeMatrix = new Matrix[8];
        public CuttedCube()
        {
            cubeMatrix[0] = new Matrix(new double[,] { { 3, 6, 0, 1 } });//A1
            cubeMatrix[1] = new Matrix(new double[,] { { 3, 6, 6, 1 } });//A2
            cubeMatrix[2] = new Matrix(new double[,] { { 0, 6, 6, 1 } });//A3
            cubeMatrix[3] = new Matrix(new double[,] { { 0, 6, 0, 1 } });//A4
            cubeMatrix[4] = new Matrix(new double[,] { { 6, 0, 0, 1 } });//A5
            cubeMatrix[5] = new Matrix(new double[,] { { 6, 0, 6, 1 } });//A6
            cubeMatrix[6] = new Matrix(new double[,] { { 0, 0, 6, 1 } });//A7
            cubeMatrix[7] = new Matrix(new double[,] { { 0, 0, 0, 1 } });//A8
            /*
             * LINES
             * 
             */
        }
    }
    class Classes
    {
        static void Main(string[] args)
        {
            CuttedCube shape = new CuttedCube();
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine((DimetricalProectionBuilder.Build(shape.cubeMatrix[i], 2).ToString()));
            }
            Console.ReadLine();
        }
    }
}
