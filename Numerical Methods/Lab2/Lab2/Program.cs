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
    public struct InterpolationValues
    {
        public double dismiss;
        public int calculateItemsNum, deltaStep;
        public InterpolationValues(double dismiss, int calculateItemsNum, int deltaStep)
        {
            this.deltaStep = deltaStep;
            this.dismiss = dismiss;
            this.calculateItemsNum = calculateItemsNum;
        }
    }
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
        static Matrix NyuthonDeltaMatrix = new Matrix(41, 22);
        static Pair[] valuePairs = new Pair[21];
        static int calculateItemsNum;
        static double dismiss;
        static int deltaStep;

        static private double Qm(int m, double q)
        {
            double res = q;

            #region Taras version
            double k = 1, r = 1;
            if (m == 1)
            {
                return res;
            }
            for (int i = 2; i <= m; i++)
            {
                if (i % 2 != 0)
                {
                    res *= (q + r);
                    r++;
                }
                else
                {
                    res *= (q - k);
                    k++;
                }
            }
            return res;
            #endregion

            #region Site Version
            //if (m == 1)
            //{
            //    return res;
            //}
            //for (int i = 1; i < m; i++)
            //{
            //    res *= q - (m - i);
            //}
            //return res;
            #endregion

            #region Old version

            //if (m == 1)
            //{
            //    return res;
            //}
            //for (int i = 1; i < m; i++)
            //{
            //    if ((i+1)%2 == 0)
            //    {
            //        res *= q - (m - i);
            //    }
            //    else
            //    {
            //        res *= q + (m - i);
            //    }

            //}
            return res;

            #endregion


        }//+
        static private double NyutonQm(int m, double q)
        {
            if (m == 0)
            {
                return 1;
            }
            if (m == 1)
            {
                return q;
            }
            double res = q;
            for (int i = 1; i < m; i++)
            {
                res *= (q + (m - i));
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
        static private void FullDeltaMatrix(bool gaus)
        {
            if (gaus)
            {
                for (int i = 0; i < points + 1; i++)
                {
                    deltaMatrix[i * 2, 0] = valuePairs[i].x;
                    deltaMatrix[i * 2, 1] = valuePairs[i].y;
                }
            }
            else
            {
                for (int i = 0; i < points + 1; i++)
                {
                    NyuthonDeltaMatrix[i * 2, 0] = valuePairs[i].x;
                    NyuthonDeltaMatrix[i * 2, 1] = valuePairs[i].y;
                }
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



            if (gaus)
            {
                for (int i = 0; i < points / 2; i++)
                {
                    for (int j = 0; j < points - i; j++)
                    {
                        deltaMatrix[j * 2 + i + 1, i + 2] = Round(deltaMatrix[j * 2 + i + 2, i + 1] - deltaMatrix[j * 2 + i, i + 1], rounder);
                    }
                }
            }
            else
            {
                for (int i = 0; i < points; i++)
                {
                    for (int j = 0; j < points - i; j++)
                    {
                        NyuthonDeltaMatrix[j * 2 + i + 1, i + 2] = Round(NyuthonDeltaMatrix[j * 2 + i + 2, i + 1] - NyuthonDeltaMatrix[j * 2 + i, i + 1], rounder);
                    }
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
        static private double NyutonDeltaY(int num, int step)
        {
            if ((num-1) * 2 < NyuthonDeltaMatrix.Row && step + 1 < NyuthonDeltaMatrix.Coll)
            {
                return NyuthonDeltaMatrix[(num-1) * 2 + step, step + 1];
            }
            else
            {
                throw new Exception("Gerara hira");
            }
        }
        static public double Calculate(double targetPoint, double precision)
        {
            BasePairs();
            FullDeltaMatrix(true);
            calculateItemsNum = 0;
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
            double test = Qm(3, 5);


            #endregion

            for (int i = 1; i <= points / 4; i++)
            {
                temp = result;

                qM = Qm(2 * i - 1, q);
                fact = factorial(2 * i - 1);
                deltaY = DeltaY(-(i - 1), 2 * i - 1);
                result += (qM * deltaY) / fact;

                qM = Qm(2 * i, q);
                deltaY = DeltaY(-i, 2 * i);
                fact = factorial(2 * i);
                result += (qM * deltaY) / fact;
                calculateItemsNum += 2;
                deltaStep = 2 * i;

                if (Abs(result - temp) < precision)
                {
                    break;
                }
            }

            dismiss = f(targetPoint) - result;

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
            BasePairs();
            FullDeltaMatrix(false);

            calculateItemsNum = 0;

            double q = Round((targetPoint - b) / h, rounder);
            double result = NyuthonDeltaMatrix[40, 1];
            double temp;
            double qM, fact, deltaY;

            #region Test

           // Console.WriteLine(NyuthonDeltaMatrix.ToString());
            //Console.WriteLine(NyutonQm(2, 5));
            //Console.WriteLine(NyutonQm(3, 5));
            //Console.WriteLine(NyutonQm(4, 5));
            //Console.WriteLine(Qm(2, 5));
            //Console.WriteLine(NyutonQm(3, 5));
            //Console.WriteLine(Qm(4, 5));
            //Console.WriteLine(Qm(5, 5));

            #endregion

            for (int i = 1; i <= points; i++)
            {
                temp = result;

                qM = NyutonQm(i, q);
                fact = factorial(i);
                deltaY = NyutonDeltaY((int)(points - i + 1), i);

                result += (qM * deltaY) / fact;

                calculateItemsNum++;
                deltaStep = i; 

                if (Abs(result - temp) < precision)
                {
                    break;
                }
            }
            dismiss = f(targetPoint) - result;
            return result;
        }
        static public InterpolationValues returnValues()
        {
            return new InterpolationValues(dismiss, calculateItemsNum, deltaStep);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            double findValue = 2.55;
            Console.WriteLine($"Expected result is {1 / findValue}");
            Console.WriteLine($"Real result is {InterpolationBuilder.CalculateBackward(findValue, 0.001)}");
            InterpolationValues values = InterpolationBuilder.returnValues();
            Console.WriteLine($"Dismiss is: {values.dismiss}, calculate items number is: {values.calculateItemsNum}, delta step is: {values.deltaStep}");

            Console.ReadLine();
        }
    }
}
