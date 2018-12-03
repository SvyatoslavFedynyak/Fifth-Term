using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using MathNet.Numerics;
using Classes.Classes;
using System.Numerics;
using System.Collections;
using System.Threading;

namespace Lab2
{
    #region Old
    //static class Functions
    //{
    //    public static int CharToInt(char letter)
    //    {
    //        return (int)letter - 97;
    //    }
    //    public static char IntToChar(int value)
    //    {
    //        return (char)(value + 97);
    //    }
    //}
    //static class HillCryptographer
    //{
    //    static MathNet.Numerics.LinearAlgebra.Matrix<double> cryptMatrix;
    //    private static void FullMatrix(string cryptWord)
    //    {
    //        int rang = (int)Sqrt(cryptWord.Length);
    //        cryptMatrix = new MathNet.Numerics.LinearAlgebra.Matrix<double>();
    //        for (int i = 0; i < cryptWord.Length; i++)
    //        {
    //            cryptMatrix[i / rang, i % rang] = Functions.CharToInt(cryptWord[i]);
    //        }
    //    }
    //    private static string[] Split(string message, int blockLength)
    //    {
    //        string[] result;
    //        int size;
    //        if (message.Length % blockLength != 0)
    //        {
    //            size = message.Length / blockLength + 1;
    //        }
    //        else
    //        {
    //            size = message.Length / blockLength;
    //        }
    //        result = new string[size];
    //        for (int i = 0; i < size; i++)
    //        {
    //            result[i] = message.Substring(i * blockLength, message.Length - i * blockLength > blockLength ? blockLength : message.Length - i * blockLength);
    //        }
    //        return result;
    //    }
    //    public static string Crypt(string message, string cryptWord)
    //    {
    //        FullMatrix(cryptWord);
    //        string[] lines = Split(message, cryptMatrix.Rang);
    //        #region Message to int
    //        int[][] IntMessage = new int[lines.Length][];
    //        for (int i = 0; i < lines.Length; i++)
    //        {
    //            IntMessage[i] = new int[lines[i].Length];
    //        }
    //        for (int i = 0; i < IntMessage.Length; i++)
    //        {
    //            for (int j = 0; j < IntMessage[i].Length; j++)
    //            {
    //                IntMessage[i][j] = Functions.CharToInt(lines[i][j]);
    //            }
    //        }
    //        #endregion
    //        Matrix tempLine;
    //        string[] resultLines = new string[lines.Length];
    //        StringBuilder sb = new StringBuilder();
    //        int[][] resultIntMessage = new int[IntMessage.Length][];
    //        for (int i = 0; i < IntMessage.Length; i++)
    //        {
    //            resultIntMessage[i] = new int[IntMessage[i].Length];
    //        }
    //        for (int i = 0; i < IntMessage.Length; i++)
    //        {
    //            tempLine = new Matrix(IntMessage[i]);
    //            resultIntMessage[i] = (tempLine * cryptMatrix).ToArr();
    //        }
    //        for (int i = 0; i < resultIntMessage.Length; i++)
    //        {
    //            for (int j = 0; j < resultIntMessage[i].Length; j++)
    //            {
    //                sb.Append(Functions.IntToChar(resultIntMessage[i][j]));
    //            }
    //            resultLines[i] = sb.ToString();
    //            sb.Clear();
    //        }

    //        return string.Join(null, resultLines);
    //    }
    //}//old 
    #endregion
    public class BBS
    {
        // FIELDS
        int p;
        int q;
        int n;
        int x;
        int x0;

        int s;
        // CONSTRUCTORS
        public BBS(int p, int q, int x)
        {
            if (p % 4 != 3 || q % 4 != 3)
            {
                throw new System.ArgumentException("\"P\" and \"Q\" must be = 3mod4");
            }
            this.p = p;
            this.q = q;
            this.x = x;
            CalcX0();
        }
        private void CalcX0()
        {
            this.n = p * q;

            int gcd = Algorithms.GCD(x, n);
            if (gcd != 1)
            {
                throw new System.ArgumentException(string.Format("Numbers \"X\" and \"N\" must be relatively simple\n X: {0} N: {1} GCD: {2}"
                                                                    , x, n, gcd));
            }
            this.x0 = (x * x) % n;

            this.Reset();
        }
        // PROPERTIES
        public int P
        {
            get
            {
                return p;
            }
            set
            {
                if (value % 4 != 3)
                {
                    throw new System.ArgumentException("\"P\" must be = 3mod4");
                }
                this.p = value;
                CalcX0();
            }
        }
        public int Q
        {
            get
            {
                return Q;
            }
            set
            {
                if (value % 4 != 3)
                {
                    throw new System.ArgumentException("\"Q\" must be = 3mod4");
                }
                this.q = value;
                CalcX0();
            }
        }
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                this.x = value;
                CalcX0();
            }
        }
        // METHODS
        public byte[] GenerateByteArray(int length)
        {
            byte[] byteArr = new byte[length];

            for (int i = 0; i < byteArr.Length; ++i)
            {
                byteArr[i] = this.NextByte();
            }
            return byteArr;
        }
        public byte NextByte()
        {
            byte b = (byte)((s * s) % 2);
            s = (s * s) % n;
            return b;
        }
        public void Reset()
        {
            this.s = x0;
        }
    }
    public interface ICypher
    {
        Alphabet Alphabet { get; set; }
        string Encrypt(string text);
        string Decrypt(string text);
    }
    public class HillCipher : ICypher
    {
        string keyWord;
        Alphabet alphabet;
        List<char> letters;
        int size;
        Matrix matrix;
        Matrix inverseMatrix;
        public HillCipher(Alphabet alphabet, string keyWord)
        {
            this.alphabet = alphabet;
            this.letters = Alphabet.Letters.ToList();
            this.KeyWord = keyWord;
        }
        public void CalculateMatrix()
        {
            System.GC.Collect();
            size = (int)System.Math.Sqrt(keyWord.Length);
            this.matrix = new Matrix(size, size, keyWord.Select(l => letters.BinarySearch(l)));
            int det = System.Convert.ToInt32(matrix.Determinant());
            if (det == 0 || Algorithms.GCD(det, alphabet.Lenght) != 1) throw new System.Exception("Can not build inverse matrix");
            this.inverseMatrix = matrix.InverseByModule(alphabet.Lenght);
        }
        public Alphabet Alphabet
        {
            get
            {
                return alphabet;
            }
            set
            {
                this.alphabet = value;
                this.letters = Alphabet.Letters.ToList();
                CalculateMatrix();
            }
        }
        public string KeyWord
        {
            get
            {
                return keyWord;
            }
            set
            {
                if (!MathNet.Numerics.Euclid.IsPerfectSquare(value.Length))
                {
                    throw new System.ArgumentException("Should be perfect square");
                }
                keyWord = value;
                CalculateMatrix();
            }
        }
        public string Decrypt(string text)
        {
            return F(inverseMatrix, text);
        }

        public string Encrypt(string text)
        {
            text = Alphabet.TextAdapter(text);
            // fill in string for right multiplication
            if (text.Length % size != 0) text += new string(' ', size - text.Length % size);

            return F(matrix, text);
        }
        public string F(Matrix matrix, string text)
        {
            StringBuilder sb = new StringBuilder();
            // calculate
            for (int i = 0; i < text.Length; i += size)
            {
                Vector vRes = matrix * new Vector(text.Skip(i).Take(size).Select(
                    l =>
                    {
                        int index = letters.BinarySearch(l);
                        if (index == -1)
                        {
                            throw new System.IndexOutOfRangeException("Letter is not in alphabet");
                        }
                        else
                        {
                            return index;
                        }
                    }));

                foreach (int letterIndex in vRes.Enumerator())
                {
                    sb.Append(letters[letterIndex % letters.Count]);
                }
            }
            return sb.ToString();
        }
    }
    public class GammaCipher : ICypher
    {
        Alphabet alphabet;
        uint[] key;
        uint[] Y;
        uint[] Z;
        public GammaCipher(Alphabet alphabet, uint[] key)
        {
            this.alphabet = alphabet;
            this.key = key;
        }
        public Alphabet Alphabet
        {
            get
            {
                return alphabet;
            }
            set
            {
                alphabet = value;
            }
        }
        public uint[] Key
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
                for (int i = 0; i < key.Length; ++i)
                {
                    key[i] %= (uint)alphabet.Lenght;
                }
            }
        }
        public string Decrypt(string text)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(text.Length);

            System.Collections.Generic.List<char> letters = new System.Collections.Generic.List<char>(alphabet.Letters);

            for (int i = 0; i < text.Length; ++i)
            {
                int index = letters.BinarySearch(text[i]);
                if (index != -1)
                {
                    sb.Append(letters[(int)((index + (letters.Count - Z[i])) % letters.Count)]);
                }
                else sb.Append(text[i]);
            }
            return sb.ToString();
        }
        public string Encrypt(string text)
        {
            text = Alphabet.TextAdapter(text);
            this.Y = new uint[text.Length + 1];
            this.Z = new uint[text.Length];
            System.Array.Copy(key, Y, key.Length);
            for (int i = key.Length; i < Y.Length; ++i)
            {
                Y[i] = (Y[i - 1] + Y[i - 3]) % (uint)alphabet.Lenght;
            }
            for (int i = 0; i < Z.Length; ++i)
            {
                Z[i] = (Y[i] + Y[i + 1]) % (uint)alphabet.Lenght;
            }

            System.Text.StringBuilder sb = new System.Text.StringBuilder(text.Length);

            System.Collections.Generic.List<char> letters = new System.Collections.Generic.List<char>(alphabet.Letters);

            for (int i = 0; i < text.Length; ++i)
            {
                int index = letters.BinarySearch(text[i]);
                if (index != -1)
                {
                    sb.Append(letters[(int)((index + Z[i]) % letters.Count)]);
                }
                else sb.Append(text[i]);
            }
            return sb.ToString();
        }
    }
    public class BBSCipher : ICypher
    {
        // FIELDS
        Alphabet alphabet;
        BBS bbs;
        // CONSTRUCTORS
        public BBSCipher(Alphabet alphabet, BBS bbs)
        {
            this.alphabet = alphabet;
            this.bbs = bbs;
        }
        // PROPERTIES
        public Alphabet Alphabet
        {
            get
            {
                return alphabet;
            }
            set
            {
                alphabet = value;
            }
        }
        public BBS BBS
        {
            get
            {
                return bbs;
            }
            set
            {
                bbs = value;
            }
        }
        // METHODS
        public string Decrypt(string text)
        {
            byte[] byteText = StringToByte(text);
            bbs.Reset();
            for (int i = 0; i < byteText.Length; ++i)
            {
                byteText[i] ^= bbs.NextByte();
            }

            return ByteToString(byteText);
            //return ByteToString(Xor(StringToByte(text), bbs.GenerateByteArray(text.Length)));
        }

        public string Encrypt(string text)
        {
            string clearString = Alphabet.TextAdapter(text);

            byte[] byteText = StringToByte(clearString);
            bbs.Reset();
            for (int i = 0; i < byteText.Length; ++i)
            {
                byteText[i] ^= bbs.NextByte();
            }

            return ByteToString(byteText);
            // return ByteToString(Xor(StringToByte(clearString), bbs.GenerateByteArray(clearString.Length)));
        }
        public static byte[] Xor(byte[] message, byte[] bbs)
        {
            byte[] result = new byte[message.Length];
            for (int i = 0; i < message.Length; i++)
            {
                result[i] = (byte)(message[i] ^ bbs[i]);
            }
            return result;
        }
        private byte[] StringToByte(string text) => System.Text.Encoding.Default.GetBytes(text);
        private string ByteToString(byte[] bytes) => System.Text.Encoding.Default.GetString(bytes);
    }

    class Side
    {
        // FIELDS
        BigInteger p;
        BigInteger a;
        uint numPower;
        // CONSTRUCTORS
        public Side(BigInteger p, BigInteger a)
        {
            this.p = p;
            this.a = a;
            this.numPower = 0;
        }
        // PROPERTIES
        public uint NumPower
        {
            get
            {
                return numPower;
            }
            set
            {
                numPower = value;
            }
        }

        // METHODS
        public BigInteger CalculateValueForOtherSide()
        {
            return BigInteger.ModPow(a, numPower, p);
        }
        public BigInteger CalculateKey(BigInteger valueFromOtherSide)
        {
            return BigInteger.ModPow(valueFromOtherSide, numPower, p);
        }
    }
    class Algorithm
    {
        public bool IsPrime(long number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            int boundary = (int)Floor(Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
        // Random generator (thread safe)
        private ThreadLocal<Random> sGen = new ThreadLocal<Random>(() => new Random());

        // Random generator (thread safe)
        private Random Gen
        {
            get
            {
                return sGen.Value;
            }
        }
        public bool IsPrime(BigInteger value, int witnesses = 10)
        {
            if (value <= 1) return false;

            if (witnesses <= 0) witnesses = 10;

            BigInteger d = value - 1;
            int s = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                s += 1;
            }

            Byte[] bytes = new Byte[value.ToByteArray().LongLength];
            BigInteger a;

            for (int i = 0; i < witnesses; i++)
            {
                do
                {
                    Gen.NextBytes(bytes);

                    a = new BigInteger(bytes);
                }
                while (a < 2 || a >= value - 2);

                BigInteger x = BigInteger.ModPow(a, d, value);
                if (x == 1 || x == value - 1) continue;

                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, value);

                    if (x == 1) return false;
                    if (x == value - 1) break;
                }

                if (x != value - 1) return false;
            }

            return true;
        }
        public BigInteger FindPrimitiveRoot(BigInteger p)
        {
            for (BigInteger i = 0; i < p; ++i)
            {
                try
                {
                    // check as int, light version
                    if (IsPRoot(checked((int)p), checked((int)i)))
                    {
                        return i;
                    }
                }
                catch (OverflowException)
                {
                    // check as a BigInteger, hard version
                    if (IsPRoot(p, i))
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        // the number A is a primitive root of P 
        // if all n^a % p full fill row from 1 to p-1        
        public bool IsPRoot(BigInteger p, BigInteger a)
        {
            if (a == 0 || a == 1) return false;

            BigInteger last = 1;
            HashSet<BigInteger> set = new HashSet<BigInteger>();
            for (BigInteger i = 0; i < p - 1; ++i)
            {
                last = (last * a) % p;
                if (set.Contains(last))
                {
                    return false;
                }
                set.Add(last);
            }
            return true;
        }
        public bool IsPRoot(int p, int a)
        {
            if (a == 0 || a == 1) return false;

            int last = 1;
            BitArray set = new BitArray(p);
            for (BigInteger i = 0; i < p - 1; ++i)
            {
                last = (last * a) % p;
                if (set.Get(last))
                {
                    return false;
                }
                set.Set(last, true);
            }
            return true;
        }
    }


    class Program
    {
        public static void Swap(ref uint first, ref uint second)
        {
            uint temp;
            temp = first;
            first = second;
            second = temp;
        }
        public static uint[] GetRandomKey(int size, Random randomiser)
        {

            uint[] res = new uint[size];
            for (int i = 0; i < size; i++)
            {
                res[i] = (uint)i;
            }
            for (int i = 0; i < size; i++)
            {
                Swap(ref res[randomiser.Next(0, size)], ref res[randomiser.Next(0, size)]);
            }
            return res;
        }
        public static bool IfSimple(int value)
        {
            for (int i = 2; i < (int)Sqrt(value); i++)
            {
                if (value % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            string alphabet = "qwertyuiopasdfghjklzxcvbnm ", code, message, decode;
            BigInteger p, a;
            Algorithm alg = new Algorithm();
            Random randomiser = new Random();
            Alphabet eng = new Alphabet(alphabet);
            Console.WriteLine("Enter message");
            message = Console.ReadLine();
            do
            {
                p = randomiser.Next(1001, 999999999);
            } while (!alg.IsPrime(p));
            a = alg.FindPrimitiveRoot(p);
            Side side = new Side(p, a);


            //code = bbsChiper.Encrypt(message);
            //Console.WriteLine($"Code is: \n{code}");
            //decode = bbsChiper.Decrypt(code);
            //Console.WriteLine($"Decode is: \n{decode}");
            Console.ReadLine();
        }
    }
}

