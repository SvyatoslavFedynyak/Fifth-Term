using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab1
{
    class Data
    {
        public Matrix target;
        public Matrix added;
        public Matrix result;
        public int firstRow;
        public int lastRow;
        public bool lastCalculation;
        public Data(Matrix target, Matrix added, Matrix result, int firstRow, int lastRow, bool lastCalculation)
        {
            this.target = target;
            this.added = added;
            this.firstRow = firstRow;
            this.lastRow = lastRow;
            this.lastCalculation = lastCalculation;
            this.result = result;
        }
    }
    public class Matrix
    {
        double[,] items;
        int rang;
        private static AutoResetEvent waitForLastCalculation = new AutoResetEvent(false);
        public Matrix(int rang)
        {
            this.rang = rang;
            items = new double[rang, rang];
        }
        public Matrix(double[,] array)
        {
            if (array.GetLength(0) == array.GetLength(1))
            {
                items = array;
                rang = array.GetLength(0);
            }
            else
            {
                throw new ArgumentException("Not a square matrix");
            }
        }
        public int NumOfColls
        {
            get
            {
                return items.GetLength(0);
            }
        }
        public double this[int row, int coll]
        {
            get
            {
                return items[row, coll];
            }
            set
            {
                items[row, coll] = value;
            }
        }
        private void addRows(object addData)
        {
            Data temp = (Data)addData;
            for (int i = temp.firstRow; i <= temp.lastRow - 1; i++)
            {
                for (int j = 0; j < temp.target.NumOfColls; j++)
                {
                    temp.target[i, j] += temp.added[i, j];
                }
            }
            if (temp.lastCalculation)
            {
                waitForLastCalculation.Set();
            }
        }
        private void multRows(object addData)
        {
            Data temp = (Data)addData;
            double resultElement = 0;
            for (int k = temp.firstRow; k <= temp.lastRow - 1; k++)
            {
                for (int i = 0; i < temp.target.NumOfColls; i++)
                {
                    for (int j = 0; j < temp.target.NumOfColls; j++)
                    {
                        resultElement += temp.target[k, j] * temp.added[j, i];
                    }
                    temp.result[k, i] = resultElement;
                    resultElement = 0;
                }
            }
            if (temp.lastCalculation)
            {
                waitForLastCalculation.Set();
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < rang; i++)
            {
                for (int j = 0; j < rang; j++)
                {
                    sb.AppendFormat($"{items[i, j]} ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
        public void AddParallel(Matrix target, int numOfThreads)
        {
            if (rang % numOfThreads == 0)
            {
                int rowsForThread = rang / numOfThreads;
                Thread[] workThreads = new Thread[numOfThreads];
                Data[] workTreadsData = new Data[numOfThreads];
                for (int i = 0; i < numOfThreads; i++)
                {
                    workTreadsData[i] = new Data(this, target, null, i * rowsForThread, (i + 1) * rowsForThread, i == numOfThreads - 1);
                    workThreads[i] = new Thread(new ParameterizedThreadStart(addRows));
                    workThreads[i].Start(workTreadsData[i]);
                }
                waitForLastCalculation.WaitOne();
            }
            else
            {
                throw new ArgumentException("Wrong number of threads");
            }
        }
        public Matrix MultiplyParallel(Matrix target, int numOfThreads)
        {
            if (rang % numOfThreads == 0)
            {
                Matrix resultMatrix = new Matrix(rang);
                int rowsForThread = rang / numOfThreads;
                Thread[] workThreads = new Thread[numOfThreads];
                Data[] workTreadsData = new Data[numOfThreads];
                for (int i = 0; i < numOfThreads; i++)
                {
                    workTreadsData[i] = new Data(this, target, resultMatrix, i * rowsForThread, (i + 1) * rowsForThread, i == numOfThreads - 1);
                    workThreads[i] = new Thread(new ParameterizedThreadStart(multRows));
                    workThreads[i].Start(workTreadsData[i]);
                }
                waitForLastCalculation.WaitOne();
                return resultMatrix;
            }
            else
            {
                throw new ArgumentException("Wrong number of threads");
            }
        }
        public static bool operator ==(Matrix first, Matrix second)
        {
            if (first.rang == second.rang)
            {
                for (int i = 0; i < first.rang; i++)
                {
                    for (int j = 0; j < first.rang; j++)
                    {
                        if (first.items[i, j] != second.items[i, j])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(Matrix first, Matrix second)
        {
            if (first == second)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    class Program
    {
        static void RandomlyFullArray(double[,] arr, Random randomiser)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = randomiser.Next(0, arr.Length + 1);
                }
            }
        }
        static void Main(string[] args)
        {
            double[,] arr1 = new double[,]
               {
                {4, 7, 3, 8 },
                {9, 1, 4, 7 },
                {5, 0, 3, 8 },
                {3, 1, 7, 5 }
               };
            double[,] arr2 = new double[,]
            {
                {3, 1, 7, 5 },
                {9, 1, 4, 7 },
                {4, 7, 3, 8 },
                {5, 0, 3, 8 }
            };
            double[,] arr3 = new double[,]
            {
                {7, 8, 10, 13},
                {18, 2, 8, 14},
                {9, 7, 6, 16},
                {8, 1, 10, 13}
            };
            Matrix main = new Matrix(arr1);
            Matrix added = new Matrix(arr2);
            Matrix expected = new Matrix(arr3);
            main.AddParallel(added, 2);
            Console.WriteLine(main == expected);
            Console.ReadLine();
        }
    }
}
