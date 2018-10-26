using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Lab2
{
    static class Functions
    {
        public static int CharToInt(char letter)
        {
            return (int)letter - 97;
        }
        public static char IntToChar(int value)
        {
            return (char)(value + 97);
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
        public Matrix(int[] arr)
        {
            items = new double[1, arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                items[0, i] = arr[i];
            }
            numOfColls = arr.Length;
            numOfRows = 1;
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
            int mod = 25;
            Matrix result = new Matrix(resultMatrixRows, resultMatrixColls);
            double resultElement = 0;
            for (int i = 0; i < resultMatrixRows; i++)
            {
                for (int j = 0; j < resultMatrixColls; j++)
                {
                    for (int k = 0; k < resultMatrixColls; k++)
                    {
                        resultElement += (first[i, k] * second[k, j]) % mod;
                    }
                    result[i, j] = resultElement % mod;
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
        public int[] ToArr()
        {
            int[] result = new int[numOfColls];
            for (int i = 0; i < numOfColls; i++)
            {
                result[i] = (int)items[0, i];
            }
            return result;
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
    static class HillCryptographer
    {
        static MathNet.Numerics.LinearAlgebra.Matrix<double> cryptMatrix;
        private static void FullMatrix(string cryptWord)
        {
            int rang = (int)Sqrt(cryptWord.Length);
            cryptMatrix = new MathNet.Numerics.LinearAlgebra.Matrix<double>();
            for (int i = 0; i < cryptWord.Length; i++)
            {
                cryptMatrix[i / rang, i % rang] = Functions.CharToInt(cryptWord[i]);
            }
        }
        private static string[] Split(string message, int blockLength)
        {
            string[] result;
            int size;
            if (message.Length % blockLength != 0)
            {
                size = message.Length / blockLength + 1;
            }
            else
            {
                size = message.Length / blockLength;
            }
            result = new string[size];
            for (int i = 0; i < size; i++)
            {
                result[i] = message.Substring(i * blockLength, message.Length - i * blockLength > blockLength ? blockLength : message.Length - i * blockLength);
            }
            return result;
        }
        public static string Crypt(string message, string cryptWord)
        {
            FullMatrix(cryptWord);
            string[] lines = Split(message, cryptMatrix.Rang);
            #region Message to int
            int[][] IntMessage = new int[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                IntMessage[i] = new int[lines[i].Length];
            }
            for (int i = 0; i < IntMessage.Length; i++)
            {
                for (int j = 0; j < IntMessage[i].Length; j++)
                {
                    IntMessage[i][j] = Functions.CharToInt(lines[i][j]);
                }
            }
            #endregion
            Matrix tempLine;
            string[] resultLines = new string[lines.Length];
            StringBuilder sb = new StringBuilder();
            int[][] resultIntMessage = new int[IntMessage.Length][];
            for (int i = 0; i < IntMessage.Length; i++)
            {
                resultIntMessage[i] = new int[IntMessage[i].Length];
            }
            for (int i = 0; i < IntMessage.Length; i++)
            {
                tempLine = new Matrix(IntMessage[i]);
                resultIntMessage[i] = (tempLine * cryptMatrix).ToArr();
            }
            for (int i = 0; i < resultIntMessage.Length; i++)
            {
                for (int j = 0; j < resultIntMessage[i].Length; j++)
                {
                    sb.Append(Functions.IntToChar(resultIntMessage[i][j]));
                }
                resultLines[i] = sb.ToString();
                sb.Clear();
            }

            return string.Join(null, resultLines);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string message = "qwertyuiopasdfghjklzxcvbnm", code, cryptWord = "qwertyuio";
            //Console.WriteLine("Enter message");
            //message = Console.ReadLine();
            //Console.WriteLine("Enter crypt word");
            //cryptWord = Console.ReadLine();
            code = HillCryptographer.Crypt(message, cryptWord);
            Console.WriteLine(code);
            Console.ReadLine();
        }
    }
}
