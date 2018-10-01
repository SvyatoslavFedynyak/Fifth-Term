using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_3;

namespace Lab3ModuleTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void GausCalculateUnitTest()
        {
            Matrix test = new Matrix(new double[,]
                        {
                    { 8, 7, 7, 6, 4},
                    { 4, 5, 6, 9, 9},
                    { 5, 7, 8, 1, 6},
                    { 3, 6, 5, 1, 2},
                    { 6, 2, 3, 7, 6}
                    });
            double[] SLARAnswers = new double[] { 4, 2, 8, 5, 4 };
            double[] expectedResult = new double[]
            {Math.Round(-0.1276, 1), Math.Round(0.2482, 1) ,Math.Round(0.8204, 1) ,Math.Round(0.2459, 1) ,Math.Round(1.826, 1)};
            double[] realResult = new double[5];
            realResult = GausCalculator.Calculate(test, SLARAnswers);
            for (int i = 0; i < realResult.Length; i++)
            {
                realResult[i] = Math.Round(realResult[i], 1);
            }
            CollectionAssert.AreEqual(expectedResult, realResult);
        }
        [TestMethod]
        public void GausAsyncCalculateUnitTest()
        {
            Matrix test = new Matrix(new double[,]
                        {
                    { 8, 7, 7, 6, 4},
                    { 4, 5, 6, 9, 9},
                    { 5, 7, 8, 1, 6},
                    { 3, 6, 5, 1, 2},
                    { 6, 2, 3, 7, 6}
                    });
            double[] SLARAnswers = new double[] { 4, 2, 8, 5, 4 };
            double[] expectedResult = new double[]
            {Math.Round(-0.1276, 1), Math.Round(0.2482, 1) ,Math.Round(0.8204, 1) ,Math.Round(0.2459, 1) ,Math.Round(1.826, 1)};
            double[] realResult = new double[5];
            realResult = GausCalculator.CalculateAsync(test, SLARAnswers, 4);
            for (int i = 0; i < realResult.Length; i++)
            {
                realResult[i] = Math.Round(realResult[i], 1);
            }
            CollectionAssert.AreEqual(expectedResult, realResult);
        }
    }
}
