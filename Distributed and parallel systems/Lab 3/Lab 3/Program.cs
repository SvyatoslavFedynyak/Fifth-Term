using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Lab_3
{
    enum CalculatedWay
    {
        Up, Down
    }
    class Data
    {
        public Matrix SLAR;
        public double[] SLARAnswer;
        public int firstRow, lastRow;
        public int numOfBasicRow;
        public CalculatedWay way;
        public bool lastCalculation;
        public Data(Matrix SLAR, double[] SLARAnswer, int firstRow, int lastRow, int numOfBasicRow, CalculatedWay way, bool lastCalculation)
        {
            this.SLAR = SLAR;
            this.SLARAnswer = SLARAnswer;
            this.firstRow = firstRow;
            this.lastRow = lastRow;
            this.numOfBasicRow = numOfBasicRow;
            this.way = way;
            this.lastCalculation = lastCalculation;
        }
    }
    public static class GausCalculator
    {
        private static AutoResetEvent waitForLastCalculation = new AutoResetEvent(false);
        public static double[] Calculate(Matrix SLAR, double[] SLARAnswers)
        {
            double[] result = new double[SLARAnswers.Length];
            for (int i = 0; i < SLAR.Rang - 1; i++)
            {
                CalculateLines(new Data(SLAR, SLARAnswers, i + 1, SLAR.Rang - 1, i, CalculatedWay.Down, false));
            }
            for (int i = SLAR.Rang - 1; i > 0; i--)
            {
                CalculateLines(new Data(SLAR, SLARAnswers, 0, i - 1, i, CalculatedWay.Up, false));
            }
            for (int i = 0; i < SLARAnswers.Length; i++)
            {
                result[i] = SLARAnswers[i] / SLAR[i, i];
            }

            return result;
        }
        public static double[] CalculateAsync(Matrix SLAR, double[] SLARAnswers, int numOfThreads)
        {
            double[] result = new double[SLARAnswers.Length];
            int linesForThreaad, additionalLines, currentBasicLine = 0;
            int mainTreads = numOfThreads - 1, firstAddtionalLine = 0;
            int linesToCalculate = SLAR.Rang - 1;
            #region DownWay
            do
            {
                if (linesToCalculate % mainTreads == 0)
                {
                    linesForThreaad = linesToCalculate / mainTreads;
                    for (int i = 0; i < mainTreads; i++)
                    {
                        new Thread(new ParameterizedThreadStart(CalculateLines)).Start(
                            new Data(SLAR, SLARAnswers, currentBasicLine + linesForThreaad * i + 1, currentBasicLine + linesForThreaad * (i + 1), currentBasicLine, CalculatedWay.Down, i == mainTreads - 1));
                    }
                    waitForLastCalculation.WaitOne();
                }
                else
                {
                    if (linesToCalculate > mainTreads)
                    {
                        additionalLines = linesToCalculate % mainTreads;
                        linesForThreaad = (linesToCalculate - additionalLines) / mainTreads;

                        for (int i = 0; i < mainTreads; i++)
                        {
                            new Thread(new ParameterizedThreadStart(CalculateLines)).Start(
                                new Data(SLAR, SLARAnswers, currentBasicLine + linesForThreaad * i + 1, currentBasicLine + linesForThreaad * (i + 1), currentBasicLine, CalculatedWay.Down, false));
                            if (i == mainTreads - 1)
                            {
                                firstAddtionalLine = currentBasicLine + linesForThreaad * (i + 1) + 1;
                            }
                        }
                        new Thread(new ParameterizedThreadStart(CalculateLines)).Start(
                            new Data(SLAR, SLARAnswers, firstAddtionalLine, firstAddtionalLine + additionalLines - 1, currentBasicLine, CalculatedWay.Down, true));
                        waitForLastCalculation.WaitOne();
                    }
                    else
                    {
                        additionalLines = linesToCalculate;
                        new Thread(new ParameterizedThreadStart(CalculateLines)).Start(
                            new Data(SLAR, SLARAnswers, currentBasicLine + 1, currentBasicLine + additionalLines, currentBasicLine, CalculatedWay.Down, true));
                        waitForLastCalculation.WaitOne();
                    }

                }
                linesToCalculate--;
                if (linesToCalculate == 0)
                {
                    break;
                }
                currentBasicLine++;
            } while (true);
            #endregion
            #region UpWay
            linesToCalculate = SLAR.Rang - 1;
            currentBasicLine = SLAR.Rang - 1;
            do
            {
                if (linesToCalculate % mainTreads == 0)
                {
                    linesForThreaad = linesToCalculate / mainTreads;
                    for (int i = 0; i < mainTreads; i++)
                    {
                        new Thread(new ParameterizedThreadStart(CalculateLines)).Start(
                            new Data(SLAR, SLARAnswers, i * linesForThreaad, (i + 1) * linesForThreaad - 1, currentBasicLine, CalculatedWay.Up, i == mainTreads - 1));
                    }
                    waitForLastCalculation.WaitOne();
                }
                else
                {
                    if (linesToCalculate > mainTreads)
                    {
                        additionalLines = linesToCalculate % mainTreads;
                        linesForThreaad = (linesToCalculate - additionalLines) / mainTreads;

                        for (int i = 0; i < mainTreads; i++)
                        {
                            new Thread(new ParameterizedThreadStart(CalculateLines)).Start(
                                new Data(SLAR, SLARAnswers, i * linesForThreaad, (i + 1) * linesForThreaad - 1, currentBasicLine, CalculatedWay.Up, false));
                            if (i == mainTreads - 1)
                            {
                                firstAddtionalLine = linesForThreaad * (i + 1);
                            }
                        }
                        new Thread(new ParameterizedThreadStart(CalculateLines)).Start(new Data(SLAR, SLARAnswers, firstAddtionalLine, firstAddtionalLine + additionalLines - 1, currentBasicLine, CalculatedWay.Up, true));
                        waitForLastCalculation.WaitOne();
                    }
                    else
                    {
                        additionalLines = linesToCalculate;
                        new Thread(new ParameterizedThreadStart(CalculateLines)).Start(
                            new Data(SLAR, SLARAnswers, 0, additionalLines - 1, currentBasicLine, CalculatedWay.Up, true));
                        waitForLastCalculation.WaitOne();
                    }

                }
                linesToCalculate--;
                if (linesToCalculate == 0)
                {
                    break;
                }
                currentBasicLine--;

            } while (true);

            #endregion
            for (int i = 0; i < SLARAnswers.Length; i++)
            {
                result[i] = SLARAnswers[i] / SLAR[i, i];
            }
            return result;
        }
        private static void CalculateLines(object data)
        {
            Data temp = (Data)data;
            int roundDeciamls = 2;
            double coef;
            if (temp.way == CalculatedWay.Down)
            {
                for (int i = temp.firstRow; i <= temp.lastRow; i++)
                {
                    coef = -temp.SLAR[temp.numOfBasicRow, temp.numOfBasicRow] / temp.SLAR[i, temp.numOfBasicRow];
                    for (int j = temp.numOfBasicRow; j < temp.SLAR.Rang; j++)
                    {
                        temp.SLAR[i, j] = Math.Round(temp.SLAR[i, j] * coef + temp.SLAR[temp.numOfBasicRow, j], roundDeciamls);
                    }
                    temp.SLARAnswer[i] = Math.Round(temp.SLARAnswer[i] * coef + temp.SLARAnswer[temp.numOfBasicRow], roundDeciamls);
                }
            }
            else if (temp.way == CalculatedWay.Up)
            {
                for (int i = temp.lastRow; i >= temp.firstRow; i--)
                {
                    coef = -temp.SLAR[temp.numOfBasicRow, temp.numOfBasicRow] / temp.SLAR[i, temp.numOfBasicRow];
                    temp.SLAR[i, temp.numOfBasicRow] = Math.Round(temp.SLAR[i, temp.numOfBasicRow] * coef + temp.SLAR[temp.numOfBasicRow, temp.numOfBasicRow], roundDeciamls);
                    temp.SLARAnswer[i] = Math.Round(temp.SLARAnswer[i] * coef + temp.SLARAnswer[temp.numOfBasicRow], roundDeciamls);
                }
            }
            if (temp.lastCalculation)
            {
                waitForLastCalculation.Set();
            }
        }
    }
    public static class Functions
    {
        static public void FullMatrixWithRandomNumbers(Matrix target, Random randomiser, int min, int max)
        {
            for (int i = 0; i < target.Rang; i++)
            {
                for (int j = 0; j < target.Rang; j++)
                {
                    target[i, j] = randomiser.Next(min, max);
                }
            }
        }
        static public void FullArrayWithRandomNumbers(double[] target, Random randomiser, int min, int max)
        {
            for (int i = 0; i < target.Length; i++)
            {
                target[i] = randomiser.Next(min, max);
            }
        }
        static public string ArrToString(double[] target)
        {
            StringBuilder sb = new StringBuilder();
            foreach (double item in target)
            {
                sb.AppendFormat($"{item} ");
            }
            return sb.ToString();
        }
        static public void GetTime(int sizeOfMatrix, int numOfthreads)
        {
            Random randomiser = new Random();
            Stopwatch timer = new Stopwatch();
            Matrix test = new Matrix(sizeOfMatrix, sizeOfMatrix);
            double[] answers = new double[sizeOfMatrix];
            FullArrayWithRandomNumbers(answers, randomiser, 1, 10);
            FullMatrixWithRandomNumbers(test, randomiser, 0, 10);
            timer.Start();
            GausCalculator.Calculate(test, answers);
            timer.Stop();
            Console.WriteLine($"In 1 thread time for SLAR {sizeOfMatrix}x{sizeOfMatrix} is: {timer.Elapsed.ToString()}");
            timer.Reset();
            FullArrayWithRandomNumbers(answers, randomiser, 1, 10);
            FullMatrixWithRandomNumbers(test, randomiser, 0, 10);
            timer.Start();
            GausCalculator.CalculateAsync(test, answers, numOfthreads);
            timer.Stop();
            Console.WriteLine($"In {numOfthreads} thread time for SLAR {sizeOfMatrix}x{sizeOfMatrix} is: {timer.Elapsed.ToString()}");
            timer.Reset();
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
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter size of matrix:");
            int size = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter number of threads");
            int threads = Convert.ToInt32(Console.ReadLine());
            Functions.GetTime(size, threads);
            Console.ReadLine();
        }
    }
}
