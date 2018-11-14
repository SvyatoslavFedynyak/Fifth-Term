using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstansesLibrary;
using static System.Math;
using MathNet;

namespace Lab2
{
    //Лінійна поверхня Кунса по точкам, заданим на кубі
    public static class Functions
    {
        public static double LengthBetwenPoints(Coord first, Coord second)
        {
            return Sqrt(Pow(first.x - second.x, 2) + Pow(first.y - second.y, 2) + Pow(first.z - second.z, 2));
        }
        public static Coord MatrixToCoord(Matrix target)
        {
            Coord res = new Coord();
            if (target.Row == 1 && target.Coll == 3)
            {
                res.x = target[0, 0];
                res.y = target[0, 1];
                res.z = target[0, 2];
            }
            else if (target.Row == 3 && target.Coll == 1)
            {
                res.x = target[0, 0];
                res.y = target[1, 0];
                res.z = target[2, 0];
            }
            else
            {
                throw new Exception();
            }
            return res;
        }
    }
    public class Coord
    {
        public double x, y, z;
        public Coord() { }
        public Coord(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        double X => x;
        double Y => y;
        double Z => z;
        public static double operator *(Coord first, Coord second)
        {
            return first.x * second.x + first.y * second.y + first.z * second.z;
        }
        public static Coord operator +(Coord first, Coord second)
        {
            return new Coord(first.x + second.x, first.y + second.y, first.z + second.z);
        }
        public static Coord operator -(Coord target)
        {
            return new Coord(-target.x, -target.y, -target.z);
        }
        public static Coord operator *(double second, Coord first)
        {
            return new Coord(first.x * second, first.y * second, first.z * second);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"[{x} ");
            sb.AppendFormat($"{y} ");
            sb.AppendFormat($"{z}] ");
            return sb.ToString();
        }
    }
    public struct Cube
    {
        public Coord p000;
        public Coord p001;
        public Coord p010;
        public Coord p011;
        public Coord p100;
        public Coord p101;
        public Coord p110;
        public Coord p111;
        public Cube(Coord p000, Coord p001, Coord p010, Coord p011, Coord p100, Coord p101, Coord p110, Coord p111)
        {
            this.p000 = p000;
            this.p001 = p001;
            this.p010 = p010;
            this.p011 = p011;
            this.p100 = p100;
            this.p101 = p101;
            this.p110 = p110;
            this.p111 = p111;
        }
    }
    public struct EdgePoints
    {
        public Coord p00;
        public Coord p01;
        public Coord p10;
        public Coord p11;
        public EdgePoints(Coord p00, Coord p01, Coord p10, Coord p11)
        {
            this.p00 = p00;
            this.p01 = p01;
            this.p10 = p10;
            this.p11 = p11;
        }
    }
    public struct InputData
    {
        public Coord[] pu0Slaym;
        public Coord[] pu1Slaym;
        public Coord[] p0vSlaym;
        public Coord[] p1vSlaym;
        public InputData(Coord[] pu0Slaym, Coord[] pu1Slaym, Coord[] p0vSlaym, Coord[] p1vSlaym)
        {
            this.pu0Slaym = pu0Slaym;
            this.pu1Slaym = pu1Slaym;
            this.p0vSlaym = p0vSlaym;
            this.p1vSlaym = p1vSlaym;
        }

    }
    public class CoordinateMatrix
    {
        int numOfRows;
        int numOfColls;
        Coord[,] items;
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
        public CoordinateMatrix(Coord[,] arr)
        {
            items = arr;
            numOfColls = arr.GetLength(1);
            numOfRows = arr.GetLength(0);
        }
        public CoordinateMatrix(int numOfRows, int numOfColls)
        {
            items = new Coord[numOfRows, numOfColls];
            this.numOfRows = numOfRows;
            this.numOfColls = numOfColls;
        }
        public Coord this[int row, int col]
        {
            get
            {
                return items[row, col];
            }
            set { items[row, col] = value; }
        }
        public static Matrix operator *(Coord first, CoordinateMatrix second)
        {
            Matrix res = new Matrix(second.numOfRows, second.numOfColls);
            for (int i = 0; i < second.numOfRows; i++)
            {
                for (int j = 0; j < second.numOfColls; j++)
                {
                    res[i, j] = first * second[i, j];
                }
            }
            return res;
        }
        public static Coord GetQ(Matrix first, CoordinateMatrix second, Matrix third)
        {
            CoordinateMatrix res1 = new CoordinateMatrix(1, 3);
            for (int i = 0; i < 3; i++)
            {
                res1[0, i] = first[0, 0] * second[0, i] + first[0, 1] * second[1, i] + first[0, 2] * second[2, i];
            }
            return (third[0, 0] * res1[0, 0] + third[1, 0] * res1[0, 1] + third[2, 0] * res1[0, 2]);
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
        public CoordinateMatrix Copy()
        {
            CoordinateMatrix result = new CoordinateMatrix(numOfRows, numOfColls);
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
    public static class LinearSurfaceBuilder
    {
        static CoordinateMatrix pMatrix = new CoordinateMatrix(3, 3);
        static double u0start, u0end, v0start, v0end, u1start, u1end, v1start, v1end;
        static public CoordinateMatrix Build(int iterations, EdgePoints edgePoints)
        {
            //P(u, 0) = p00 -> p10
            //P(u, 1) = p01 -> p11
            //P(0, v) = p00 -> p01
            //P(1, v) = p10 -> p11

            double u0start, u0end, v0start, v0end, u1start, u1end, v1start, v1end;
            u0start = U(edgePoints.p00);
            u0end = U(edgePoints.p10);
            v0start = V(edgePoints.p00);
            v0end = V(edgePoints.p01);
            u1start = U(edgePoints.p01);
            u1end = U(edgePoints.p11);
            v1start = V(edgePoints.p10);
            v1end = V(edgePoints.p11);


            //double u0step, u1step, v0step, v1step;
            //u0step = (u0end - u0start) / (iterations - 1);
            //u1step = (u1end - u1start) / (iterations - 1);
            //v0step = (v0end - v0start) / (iterations - 1);
            //v1step = (u1end - u1start) / (iterations - 1);
            //double u0 = u0start, u1 = u1start, v0 = v0start, v1 = v1start;

            pMatrix[0, 0] = edgePoints.p00;
            pMatrix[0, 1] = edgePoints.p01;
            pMatrix[1, 0] = edgePoints.p10;
            pMatrix[1, 1] = edgePoints.p11;
            pMatrix[2, 2] = new Coord(0, 0, 0);

            double step = (double)1 / (iterations - 1);
            double u = 0, v = 0;
            CoordinateMatrix res = new CoordinateMatrix(iterations, iterations);
            for (int i = 0; i < iterations; i++)
            {
                for (int j = 0; j < iterations; j++)
                {
                    res[i, j] = Q(u, v, edgePoints);
                    v += step;
                }
                v = 0;
                u += step;
            }
            #region Test
            //Console.WriteLine(Q(0, 0, edgePoints));
            //Console.WriteLine(Q(1, 0, edgePoints));
            //Console.WriteLine(Q(0, 1, edgePoints));
            //Console.WriteLine(Q(1, 1, edgePoints));
            //Console.WriteLine(Q(0.5, 0.5, edgePoints));
            //Console.WriteLine(Q(0.25, 0.25, edgePoints));
            #endregion

            return res;
        }
        static public Coord Q(double u, double v, EdgePoints edgePoints)
        {
            Matrix first = new Matrix(new double[,] { { 1 - u, u, 1 } });
            //pMatrix[0, 2] = P(0, v);
            //pMatrix[1, 2] = P(1, v);
            //pMatrix[2, 0] = P(u, 0);
            //pMatrix[2, 1] = P(u, 1);
            pMatrix[0, 2] = P(0, v, v0start, v0end);
            pMatrix[1, 2] = P(1, v, v1start, v1end);
            pMatrix[2, 0] = P(u, 0, u0start, u0end);
            pMatrix[2, 1] = P(u, 1, u1start, u1end);
            Matrix third = new Matrix(new double[,]
            {
                {1-v },
                {v },
                {1 }
            });
            return CoordinateMatrix.GetQ(first, pMatrix, third);
        }
        static private Coord P(double u, double v, double start, double end)
        {
            //double x, y, z;
            //x = (1 - u) * v;
            //y = (1 - u) * (1 - v);
            //z = (1 - v) * u;
            //return new Coord(x, y, z);

            double x, y, z;
            x = start + ((1 - u) * v) * (end - start);
            y = start + (1 - u) * (1 - v) * (end - start);
            z = start + (1 - v) * u * (end - start);
            return new Coord(x, y, z);

        }
        static private double U(Coord target)
        {
            return 1 - target.x - target.y;
        }
        static private double V(Coord target)
        {
            return 1 - target.y - target.z;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LinearSurfaceBuilder.Build(5, new EdgePoints(new Coord(0, 4, 4), new Coord(0, 0, 4), new Coord(4, 4, 4), new Coord(4, 0, 0))).ToString());
            Console.ReadLine();
        }
    }
}
