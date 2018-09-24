﻿using System;
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
        /*
            * (cos(Q)  sin(Q)sin(f)  -sin(Q)cos(f)  0)
            * (0         cos(f)          sin(f)     0)
            * (sin(Q)  -cos(Q)sin(f) cos(Q)cos(f)   0)
            * (0            0              0        1)
            */
        static double Q = -2.14;
        static double f = -2.44;
        static double[,] DimetricalMatrixarr = new double[,]
        {
                {Cos(Q), Sin(Q)*Sin(f), -Sin(Q)*Cos(f), 0 },
                {0, Cos(f), Sin(f), 0 },
                {Sin(Q), -Cos(Q)*Sin(f), Cos(Q)*Cos(f), 0 },
                {0, 0, 0, 1 }
        };
        static Matrix DimetricalMatrix = new Matrix(DimetricalMatrixarr);
        static DimetricalProectionBuilder()
        {

        }
        public static Matrix Build(Matrix target)
        {
            return target * DimetricalMatrix;
        }

    }
    class CuttedCube
    {
        public Matrix[] cubeMatrix = new Matrix[8];
        public CuttedCube()
        {
            cubeMatrix[0] = new Matrix(new double[,] { { 6, 0, 6, 1 } });
            cubeMatrix[1] = new Matrix(new double[,] { { 6, 0, 0, 1 } });
            cubeMatrix[2] = new Matrix(new double[,] { { 0, 0, 6, 1 } });
            cubeMatrix[3] = new Matrix(new double[,] { { 0, 0, 0, 1 } });
            cubeMatrix[4] = new Matrix(new double[,] { { 0, 6, 0, 1 } });
            cubeMatrix[5] = new Matrix(new double[,] { { 0, 6, 6, 1 } });
            cubeMatrix[6] = new Matrix(new double[,] { { 3, 6, 0, 1 } });
            cubeMatrix[7] = new Matrix(new double[,] { { 3, 6, 6, 1 } });
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CuttedCube shape = new CuttedCube();
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine((DimetricalProectionBuilder.Build(shape.cubeMatrix[i]).ToString())); 
            }
            Console.ReadLine();
        }
    }
}
