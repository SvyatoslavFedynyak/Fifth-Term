using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstansesLibrary;
using static System.Math;
using System.Windows;

namespace Lab2
{
    public struct Pair
    {
        public double x, y;
        public Pair(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public static class InterpolationBuilder
    {
        // 1/x
        // a = 1, b = 3, n = 20, x0 = 2;
        static int rounder = 15;
        static double a = 1, b = 3, points = 20, h = 0.1, x0 = 2;
        static Matrix deltaMatrix = new Matrix(41, 12);
        static Pair[] valuePairs = new Pair[21];

        static private double Qm(int m, double q)
        {
            double res = 1;
            for (int i = 1; i <= m; i++)
            {
                res *= (q - (m - i));
            }
            return res;
        }//+
        static private double f(double value)
        {
            return 1 / value;
        }//+
        static private double factorial(int val)
        {
            int result = 1;
            for (int i = 1; i <= val; i++)
            {
                result *= i;
            }
            return result;
        }//+
        static private void BasePairs()
        {
            double step = h;

            for (double i = a, j = 0; i <= b; i += step, j++)
            {
                i = Round(i, 1);
                valuePairs[(int)j].x = i;
                valuePairs[(int)j].y = Round(f(i), rounder);
            }

            return;

        }//+
        static private void FullDeltaMatrix()
        {
            for (int i = 0; i < points + 1; i++)
            {
                deltaMatrix[i * 2, 0] = valuePairs[i].x;
                deltaMatrix[i * 2, 1] = valuePairs[i].y;
            }


            #region Test
            //deltaMatrix = new Matrix(13, 5);
            //valuePairs = new Pair[7];
            //valuePairs[0] = new Pair(0.2, 1.552);
            //valuePairs[1] = new Pair(0.25, 1.6719);
            //valuePairs[2] = new Pair(0.3, 1.7831);
            //valuePairs[3] = new Pair(0.35, 1.8847);
            //valuePairs[4] = new Pair(0.4, 1.9759);
            //valuePairs[5] = new Pair(0.45, 2.0563);
            //valuePairs[6] = new Pair(0.5, 2.125);
            //for (int i = 0; i < 7; i++)
            //{
            //    deltaMatrix[i * 2, 0] = valuePairs[i].x;
            //    deltaMatrix[i * 2, 1] = valuePairs[i].y;
            //}
            #endregion



            for (int i = 0; i < points / 2; i++)
            {
                for (int j = 0; j < points - i; j++)
                {
                    deltaMatrix[j * 2 + i + 1, i + 2] = Round(deltaMatrix[j * 2 + i + 2, i + 1] - deltaMatrix[j * 2 + i, i + 1], rounder);
                }
            }

        }//+
        static private double DeltaY(int num, int step)
        {
            if ((int)points + num * 2 < deltaMatrix.Row && step + 1 < deltaMatrix.Coll)
            {
                return deltaMatrix[(int)points + num * 2 + step, step + 1];
            }
            else
            {
                throw new Exception("Gerara hira");
            }
        }//+
        static public double Calculate(double targetPoint, double precision)
        {
            BasePairs();
            FullDeltaMatrix();

            double q = Round((targetPoint - x0) / h, rounder);
            double result = deltaMatrix[20, 1];
            double temp;

            double qM, fact, deltaY;

            #region Test

            //MatrixShower shower = new MatrixShower();
            //shower.ShowMatrix(deltaMatrix);
            //Console.WriteLine(deltaMatrix.ToString(0));
            //Console.WriteLine(DeltaY(0, 1));//-0.024
            //Console.WriteLine(DeltaY(1, 1));//-0.021
            //Console.WriteLine(DeltaY(0, 2));//0.003
            //Console.WriteLine(DeltaY(-1, 1));//-0.026
            //Console.WriteLine(DeltaY(-1, 2));//0.002
            //Console.WriteLine($"2! = {factorial(2)}, 6! = {factorial(6)}");
            //Console.WriteLine(Qm(2, 3));
            //Console.WriteLine(Qm(3, 4));


            #endregion

            for (int i = 1; i <= points / 4; i++)
            {
                temp = result;

                qM = Qm(2 * i - 1, q + i - 1);
                fact = factorial(2 * i - 1);
                deltaY = DeltaY(i - 1, 2 * i - 1);
                result += (qM * deltaY) / fact;

                qM = Qm(2 * i, (q + i - 1));
                deltaY = DeltaY(i, 2 * i);
                fact = factorial(2 * i);
                result += (qM * deltaY) / fact;
                if (Abs(result - temp) < precision)
                {
                    break;
                }
            }



            #region BackWard
            //else
            //{
            //    temp = result;
            //    for (int i = 1; i <= points / 4; i++)
            //    {
            //        result += ((Qm(2 * i - 1, q + i - 1)) * DeltaY(-i, 2 * i - 1)) / factorial(2 * i - 1) + ((Qm(2 * i, (q + i))) * DeltaY(-i, 2 * i)) / factorial(2 * i);
            //        if (Abs(result - temp) < precision)
            //        {
            //            break;
            //        }
            //    }
            //} 
            #endregion
            return result;
        }
        static public double CalculateBackward(double targetPoint, double precision)
        {


            return 10;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Expected result is {1 / 2.55}");
            Console.WriteLine($"Real result is {InterpolationBuilder.Calculate(2.55, 0.001)}");


            Console.ReadLine();
        }
    }
}
