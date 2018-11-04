using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using MathNet.Numerics;

namespace Lab2
{
    #region Old
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
    }//old 
    #endregion


    static 

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
