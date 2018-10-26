using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstansesLibrary;
using static System.Math;

namespace Lab2
{
    struct Pair
    {
        public double x, y;
        public Pair(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
    static class InterpolationBuilder
    {
        // 1/x
        // a = 1, b = 3, n = 20
        static int rounder = 3;
        static double a = 1, b = 3, points = 20;
        static private double f(double value)
        {
            return 1 / value;
        }
        static private double factorial(int val)
        {
            int result = 1;
            for (int i = 1; i <= val; i++)
            {
                result *= i;
            }
            return result;
        }
        static private void BaseMatrix(Matrix matrix)
        {
            double step = (b - a) / points;

            for (double i = a,  j = 0; i <= b; i+=step, j++)
            {
                i = Round(i, 1);
                matrix[(int)j, 0] =i;
                matrix[(int)j, 1] = Round(f(i), rounder);             
            }

            return;

        }
        static private void SomethingWithMatrix(Matrix matrix)
        {
            for (int j = 1; j < matrix.Rang - 1; j++)
            {
                for (int i = 0; i < matrix.Rang -1 -j; i++)
                {
                    matrix[i, j + 1] = matrix[i + 1, j] - matrix[i, j];
                }
            }
        }
        static public double Calculate(double targetPoint, double precision)
        {
            Matrix matrix = new Matrix(21, 21);
            BaseMatrix(matrix);
            SomethingWithMatrix(matrix);



            Console.WriteLine(matrix.ToString());
            return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            InterpolationBuilder.Calculate(0 ,0);
            Console.ReadLine();
        }
    }
}
