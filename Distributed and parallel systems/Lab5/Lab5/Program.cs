using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Lab5
{
    class Data
    {
        public Matrix graph;
        public Matrix S;
        public Range range;
        public bool lastRange;
        public Data(Matrix graph, Matrix S, Range range, bool lastRange)
        {
            this.graph = graph;
            this.S = S;
            this.range = range;
            this.lastRange = lastRange;
        }
    }
    struct Range
    {
        public int begin, end;
        public Range(int begin, int end)
        {
            this.begin = begin;
            this.end = end;
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
    public static class FloydAlgorithm
    {
        private static AutoResetEvent waitForLastCalculation = new AutoResetEvent(false);
        private static void CalculateRange(object data)
        {
            Data temp = (Data)data;
            for (int k = temp.range.begin; k <= temp.range.end; k++)
            {
                for (int i = 0; i < temp.graph.Rang; i++)
                {
                    for (int j = 0; j < temp.graph.Rang; j++)
                    {
                        if (temp.graph[i, j] != 0)
                        {
                            if (temp.graph[i, j] > temp.graph[i, k] + temp.graph[k, j])
                            {
                                temp.graph[i, j] = temp.graph[i, k] + temp.graph[k, j];
                                temp.S[i, j] = k;
                            }
                        }
                    }
                }
            }
            if (temp.lastRange)
            {
                waitForLastCalculation.Set();
            }
        }
        public static void Calculate(Matrix graph, out Matrix SMatrix)
        {
            Matrix S = new Matrix(graph.Rang, graph.Rang);
            #region Full S Matrix
            for (int i = 0; i < S.Rang; i++)
            {
                for (int j = 0; j < S.Rang; j++)
                {
                    if (i == j)
                    {
                        S[i, j] = 0;
                    }
                    else
                    {
                        S[i, j] = j + 1;
                    }
                }
            }
            #endregion
            CalculateRange(new Data(graph, S, new Range(0, graph.Rang - 1), false));
            SMatrix = S;
        }
        public static void CalculateAsync(Matrix graph, out Matrix SMatrix, int numOfThreads)
        {
            Matrix S = new Matrix(graph.Rang, graph.Rang);
            #region Full S Matrix
            for (int i = 0; i < S.Rang; i++)
            {
                for (int j = 0; j < S.Rang; j++)
                {
                    if (i == j)
                    {
                        S[i, j] = 0;
                    }
                    else
                    {
                        S[i, j] = j + 1;
                    }
                }
            }
            #endregion
            if (graph.Rang % numOfThreads == 0)
            {
                int RangForThread = graph.Rang / numOfThreads;
                for (int i = 0; i < numOfThreads; i++)
                {
                    new Thread(new ParameterizedThreadStart(CalculateRange)).Start(new Data(graph, S, new Range(i * RangForThread, (i + 1) * RangForThread - 1), i == numOfThreads - 1));
                }
                waitForLastCalculation.WaitOne();
            }
            SMatrix = S;
        }
    }


    class Program
    {
        static void FullMatrix(Matrix graph, int max, int huge)
        {
            Random randomiser = new Random();
            int ifHuge;
            for (int i = 0; i < graph.Rang; i++)
            {
                for (int j = 0; j < graph.Rang; j++)
                {
                    if (i == j )
                    {
                        graph[i, j] = 0;
                    }
                    else
                    {
                        ifHuge = randomiser.Next(0, 1);
                        if (ifHuge == 0)
                        {
                            graph[i, j] = randomiser.Next(1, max);
                        }
                        else
                        {
                            graph[i, j] = huge;
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int numOfThreads;
            int elements;
            Console.WriteLine("Enter number of elements: ");
            elements = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter number of threads: ");
            numOfThreads = Convert.ToInt32(Console.ReadLine());
            Stopwatch timer = new Stopwatch();
            int maxWeigh = 100;
            int hugeNumber = 10*maxWeigh*elements;

            Matrix test1 = new Matrix(elements, elements);
            FullMatrix(test1, maxWeigh, hugeNumber);
            Matrix test2 = test1.Copy();
            Matrix s1 = new Matrix(elements, elements);
            Matrix s2 = new Matrix(elements, elements);
            timer.Start();
            FloydAlgorithm.Calculate(test1, out s1);
            timer.Stop();
            Console.WriteLine($"Time for single thread is: {timer.Elapsed.ToString()}");
            timer.Reset();
            timer.Start();
            FloydAlgorithm.CalculateAsync(test2, out s2, numOfThreads);
            timer.Stop();
            Console.WriteLine($"Time for {numOfThreads} thread is: {timer.Elapsed.ToString()}");
            Console.ReadLine();
        }
    }
}
