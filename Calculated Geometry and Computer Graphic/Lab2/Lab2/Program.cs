using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstansesLibrary;
using static System.Math;

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
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"{x} ");
            sb.AppendFormat($"{y} ");
            sb.AppendFormat($"{z} ");
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
        static CoordinateMatrix SurfaceMatrix;
        static private CoordinateMatrix Build(int iterations, InputData inData)
        {
            //u => p00->p10
            //v => p01->p11
            //  pMatrix[0, 0] = -inData.p0vSlaym[0];

            return null;
        }
        static public Coord Q(double u, double v)
        {


            return new Coord(1, 1, 1);
        }
        static private Coord Puo(double u, double v)
        {
            return new Coord(1, 1, 1);
        }
        static private Coord Pu1(double u, double v)
        {
            return new Coord(1, 1, 1);
        }
        static private Coord P0v(double u, double v)
        {
            return new Coord(1, 1, 1);
        }
        static private Coord P1v(double u, double v)
        {
            return new Coord(1, 1, 1);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Coord first = new Coord(0.5, 0.5, 1);
            CoordinateMatrix second = new CoordinateMatrix(new Coord[,]
            {
                {-new Coord(0, 0, 3), -new Coord(0, 0, 0), new Coord(0, 1, 1.5) },
                {- new Coord(3, 0, 3), -new Coord(3, 0, 0), new Coord(3, 1, 1.875)},
                {new Coord(1.875, 1, 3), new Coord(1.5, 1, 0), new Coord(0, 0, 0) }
            });
            Matrix third = new Matrix(new double[,]
            {
                {0.5, 0.5, 1 }
                //{0.5 },
                //{1 }
            });
            Matrix res1 = first * second;
            Console.WriteLine(res1);
            Coord res2 = Functions.MatrixToCoord(res1 * third);
            Console.WriteLine(res2);
            Console.ReadLine();
        }
    }
}
