using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab1;

namespace ParallelMatrixCalculationsUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Matrix4x4AddParallelTest()
        {
            #region ArraysInitialise
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
            #endregion
            Matrix main = new Matrix(arr1);
            Matrix added = new Matrix(arr2);
            Matrix expected = new Matrix(arr3);
            main.AddParallel(added, 4);
            Assert.IsTrue(main == expected);
        }
        [TestMethod]
        public void Matrix4x4MultParallelTest()
        {
            #region ArraysInitialise
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
                {127, 32, 89, 157},
                {87, 38, 100, 140},
                {67, 26, 68, 113},
                {71, 53, 61, 118}
            };
            #endregion
            Matrix main = new Matrix(arr1);
            Matrix added = new Matrix(arr2);
            Matrix actual = main.MultiplyParallel(added, 4);
            Matrix expected = new Matrix(arr3);
            Assert.IsTrue(actual == expected);
        }
    }
}
