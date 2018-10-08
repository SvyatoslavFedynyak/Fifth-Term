using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// Task1: Афінна система підстановок цезаря
// Task2: Шифр "подвійний квадрат Уітстона"

namespace Lab1
{
    struct ElementPosition
    {
        public int row, col;
        public ElementPosition(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
    enum TablePostion
    { Left, Right }
    class Table
    {
        int size;
        TablePostion position;
        int[,] elements;
        public Table(int size, TablePostion position)
        {
            this.size = size;
            this.position = position;
            elements = new int[size, size];
        }
        public int Size
        {
            get
            {
                return size;
            }
        }
        public int this[int row, int col]
        {
            get
            {
                return elements[row, col];
            }
            set
            {
                elements[row, col] = value;
            }
        }
        public bool Contains(char target)
        {
            int value = (int)target;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (elements[i, j] == value)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void Add(int value)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (elements[i, j] == 0)
                    {
                        elements[i, j] = value;
                        return;
                    }
                }
            }
        }
        public ElementPosition Find(char element)
        {
            int value = (int)element;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (value == elements[i, j])
                    {
                        return new ElementPosition(i, j);
                    }
                }
            }
            return new ElementPosition(0, 0);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    sb.AppendFormat($"{(char)elements[i, j]} ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
    static class Task1Cryptographer
    {
        //a: 97, b: 98, z: 122
        // a є [1, 25]/{13}, {2}
        // b є [0, 25]
        static int m = 26;
        static int ASCIIDelta = 97;
        public static string Crypt(string message, int a, int b)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] != ' ')
                {
                    sb.Append((char)(((a * (message[i] - ASCIIDelta) + b % m) % m) + ASCIIDelta));
                }
                else
                {
                    sb.Append(' ');
                }
            }
            return sb.ToString();

        }
        public static string Decrypt(string code, int a, int b)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < code.Length; i++)
            {
                if (code[i] != ' ')
                {
                    sb.Append((char)(((((m + 1) / a) * (code[i] - ASCIIDelta + m - b)) % m) + ASCIIDelta));
                }
                else
                {
                    sb.Append(' ');
                }
            }
            return sb.ToString();
        }
    }
    static class Task2Cryptographer
    {
        static int tableSize = 5;
        static Table left = new Table(tableSize, TablePostion.Left);
        static Table right = new Table(tableSize, TablePostion.Right);
        static char[] alphabet = new char[]
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'
        };
        private static void FullTable(Table table, char[] word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                table[i / tableSize, i % tableSize] = word[i];
            }
            if (word.Length < table.Size * table.Size)
            {
                for (int i = 0; i < table.Size * table.Size - word.Length || i < alphabet.Length - 1; i++)
                {
                    if (!table.Contains(alphabet[i]))
                    {
                        table.Add(alphabet[i]);
                    }
                }
            }

        }
        public static string Crypt(string message, string cryptWord1, string cryptWord2)
        {
            char[] cryptWord1Char = cryptWord1.Distinct().ToArray();
            char[] cryptWord2Char = cryptWord2.Distinct().ToArray();
            FullTable(left, cryptWord1Char);
            FullTable(right, cryptWord2Char);
            Console.WriteLine(left.ToString());
            Console.WriteLine(right.ToString());
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] == ' ')
                {
                    sb.Append(' ');
                }
                else
                {
                    if (message[i] == 'z')
                    {
                        sb.Append('z');
                    }
                    else
                    {
                        ElementPosition pos = left.Find(message[i]);
                        sb.Append((char)right[pos.col, pos.row]);
                    }
                }
            }
            return sb.ToString();
        }
        public static string Decrypt(string message, string cryptWord1, string cryptWord2)
        {
            char[] cryptWord1Char = cryptWord1.Distinct().ToArray();
            char[] cryptWord2Char = cryptWord2.Distinct().ToArray();
            FullTable(left, cryptWord1Char);
            FullTable(right, cryptWord2Char);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] == ' ')
                {
                    sb.Append(' ');
                }
                else
                {
                    if (message[i] == 'z')
                    {
                        sb.Append('z');
                    }
                    else
                    {
                        ElementPosition pos = right.Find(message[i]);
                        sb.Append((char)left[pos.col, pos.row]);
                    }
                }
            }
            return sb.ToString();
        }
    }
    static class FrequencyDecryptor
    {
        static KeyValuePair<char, int>[] codeArray;
        static char[] sortedAlphabet = new char[]
        {
            'e','t','a','o','i','n','s','h','r','d','l','c','u','m','w','f','g','y','p','v','k','j','x','q','z'
        };
        static Dictionary<char, int> codeLetterFrequecy = new Dictionary<char, int>();
        static void swap(ref KeyValuePair<char, int> first, ref KeyValuePair<char, int> second)
        {
            KeyValuePair<char, int> temp = first;
            first = second;
            second = temp;
        }
        static private void sortCodeArray()
        {
            for (int i = 0; i < codeArray.Length - 1; i++)
            {
                for (int j = 0; j < codeArray.Length - 1 - i; j++)
                {
                    if (codeArray[j].Value > codeArray[j + 1].Value)
                    {
                        swap(ref codeArray[j], ref codeArray[j + 1]);
                    }
                }
            }
        }
        static private void BuildDictionary(string code)
        {
            for (int i = 0; i < code.Length; i++)
            {
                if (codeLetterFrequecy.ContainsKey(code[i]))
                {
                    codeLetterFrequecy[code[i]]++;
                }
                else
                {
                    codeLetterFrequecy.Add(code[i], 1);
                }
            }
            codeLetterFrequecy.Remove(' ');
        }
        static private int IndexOfItem(char item)
        {
            for (int i = 0; i < codeArray.Length; i++)
            {
                if (codeArray[i].Key == item)
                {
                    return i;
                }
            }
            return 0;
        }
        static private void Reverse()
        {
            KeyValuePair<char, int>[] temp = new KeyValuePair<char, int>[codeArray.Length];
            for (int i = 0; i < codeArray.Length; i++)
            {
                temp[i] = codeArray[codeArray.Length - i - 1];
            }
            codeArray = temp;
        }
        static private string ChangeLetter(string code)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < code.Length; i++)
            {
                if (code[i] == ' ')
                {
                    sb.Append(' ');
                }
                else
                {
                    sb.Append(sortedAlphabet[IndexOfItem(code[i])]);
                }
            }
            return sb.ToString();
        }
        static public string Decrypt(string code)
        {
            codeLetterFrequecy.Clear();
            BuildDictionary(code);
            codeArray = codeLetterFrequecy.ToArray();
            sortCodeArray();
            Reverse();
            return ChangeLetter(code);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            string adress = @"F:\Visual Studio Projects\C#\Study\5 term\Information Defence\Lab1\Lab1\CodeText.txt";
            #region Task2Check

            //string message = "svyatoslav", cryptWord1 = "qwertyuiop", cryptWord2 = "asdfghjkl", code;
            //Console.WriteLine("Enter message:");
            //message = Console.ReadLine();
            //Console.WriteLine("Enter first crypt word and second:");
            //cryptWord1 = Console.ReadLine();
            //cryptWord2 = Console.ReadLine();
            //code = Task2Cryptographer.Crypt(message, cryptWord1, cryptWord2);
            //Console.WriteLine($"Result is: {code}");
            //Console.WriteLine($"Exist is: {Task2Cryptographer.Decrypt(code, cryptWord1, cryptWord2)}");
            #endregion
            #region Task1Check
            string message, code;
            int a = 3, b = 5;
            using (StreamReader reader = File.OpenText(adress))
            {
                StringBuilder sb = new StringBuilder();
                string input = null;
                while ((input = reader.ReadLine()) != null)
                {
                    sb.AppendFormat($"{input} ");
                }
                message = sb.ToString();
            }
            //Console.WriteLine("Please enter message:");
            //message = Console.ReadLine();
            message = message.ToLower();
            //Console.WriteLine("Please enter a and b:");
            //a = Convert.ToInt32(Console.ReadLine());
            //b = Convert.ToInt32(Console.ReadLine());
            code = Task1Cryptographer.Crypt(message, a, b);
            Console.WriteLine($"Result is: {code}\n");
            Console.WriteLine($"Exist is: {Task1Cryptographer.Decrypt(code, a, b)}\n");
            Console.WriteLine($"Decrypted message is: {FrequencyDecryptor.Decrypt(code)}");
            #endregion
            Console.ReadLine();
        }
    }
}

