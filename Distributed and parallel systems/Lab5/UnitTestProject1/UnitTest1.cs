using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab5;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalculateTest()
        {
            int hugeNumber = 1000;
            Matrix test = new Matrix(new double[,]
            {
            {0, 3, 10, hugeNumber, hugeNumber},
            {3, 0, hugeNumber,5, hugeNumber },
            {10, hugeNumber, 0, 6, 15 },
            { hugeNumber, 5, 6, 0, 4},
            { hugeNumber, hugeNumber, hugeNumber, 4, 0}
            });
            Matrix s = new Matrix(5, 5);
            FloydAlgorithm.Calculate(test, out s);
            Matrix expectedResult = new Matrix(new double[,]
            {
                {0, 3, 10, 8, 12 },
                {3, 0, 11, 5, 9 },
                {10, 11, 0, 6, 10 },
                {8, 5, 6, 0, 4 },
                {12, 9, 10, 4 ,0 }
            });
            for (int i = 0; i < test.Rang; i++)
            {
                for (int j = 0; j < test.Rang; j++)
                {
                    Assert.AreEqual(expectedResult[i, j], test[i, j]);
                }
            }
        }

        [TestMethod]
        public void CalculateAsyncTest()
        {
            int hugeNumber = 1000;
            Matrix test = new Matrix(new double[,]
            {
            {0, 3, 10, hugeNumber, hugeNumber},
            {3, 0, hugeNumber,5, hugeNumber },
            {10, hugeNumber, 0, 6, 15 },
            { hugeNumber, 5, 6, 0, 4},
            { hugeNumber, hugeNumber, hugeNumber, 4, 0}
            });
            Matrix s = new Matrix(5, 5);
            FloydAlgorithm.CalculateAsync(test, out s, 5);
            Matrix expectedResult = new Matrix(new double[,]
            {
                {0, 3, 10, 8, 12 },
                {3, 0, 11, 5, 9 },
                {10, 11, 0, 6, 10 },
                {8, 5, 6, 0, 4 },
                {12, 9, 10, 4 ,0 }
            });
            for (int i = 0; i < test.Rang; i++)
            {
                for (int j = 0; j < test.Rang; j++)
                {
                    Assert.AreEqual(expectedResult[i, j], test[i, j]);
                }
            }
        }
    }
}
