using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Lab1
{
    // нормальний розподіл
    struct StatisticValues
    {
        public double medium, dispersion, fixedDispersion, mediumKvadr, fixedMediumKvadr, swing, mediane, mode, cvantil, variationCoef, assimetricCoef, ecscess;
        public StatisticValues(double medium, double dispersion, double fixedDispersion, double mediumKvadr, double fixedMediumKvadr, double swing,
           double mediane, double mode, double cvantil, double variationCoef, double assimetricCoef, double ecscess)
        {
            this.medium = medium;
            this.mediane = mediane;
            this.fixedDispersion = fixedDispersion;
            this.ecscess = ecscess;
            this.dispersion = dispersion;
            this.cvantil = cvantil;
            this.assimetricCoef = assimetricCoef;
            this.fixedMediumKvadr = fixedMediumKvadr;
            this.mode = mode;
            this.swing = swing;
            this.variationCoef = variationCoef;
            this.mediumKvadr = mediumKvadr;
        }
    }
    enum StatisticVariableType
    {
        Discrete, Uninterrupted
    }
    struct Range
    {
        public double begin, end;
        public Range(double begin, double end)
        {
            this.begin = begin;
            this.end = end;
        }
    }
    struct FunctionSlot
    {
        public double value;
        public Range range;
        public FunctionSlot(double value, Range range)
        {
            this.value = value;
            this.range = range;
        }
    }
    class EmpiricalFunction
    {
        public FunctionSlot[] slots;
        public EmpiricalFunction() { }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("F(x) = \n{\n");
            sb.AppendFormat($"{slots[0].value}, x<={slots[0].range.end}\n");
            for (int i = 1; i < slots.Length - 1; i++)
            {
                sb.AppendFormat($"{slots[i].value}, {slots[i].range.begin}<x<={slots[i].range.end}\n");
            }
            sb.AppendFormat($"{slots[slots.Length - 1].value}, x>{slots[slots.Length - 1].range.begin}\n");
            sb.Append("}");
            return sb.ToString();
        }
    }
    class StatisticAnaliser
    {
        StatisticVariableType type;
        double[] data;

        double[] variationRow;
        Dictionary<double, int> statisticalDistribution;
        EmpiricalFunction empFunc;
        StatisticValues numValues;

        Dictionary<Range, int> uninterruptedStatisticalDistribution;


        public StatisticAnaliser(double[] data, StatisticVariableType type)
        {
            this.data = data;
            this.type = type;

            variationRow = new double[data.Length];
            statisticalDistribution = new Dictionary<double, int>();
            empFunc = new EmpiricalFunction();

            BuildWariationRow();
            BuildstatisticalDistribution();
            BuildEmpiricalFunction();
            CalculateNumericValues();

        }
        private void BuildstatisticalDistribution()
        {
            #region Discrete
            if (type == StatisticVariableType.Discrete)
            {
                for (int i = 0; i < variationRow.Length; i++)
                {
                    if (statisticalDistribution.ContainsKey(variationRow[i]))
                    {
                        statisticalDistribution[variationRow[i]]++;
                    }
                    else
                    {
                        statisticalDistribution.Add(variationRow[i], 1);
                    }
                }
            }
            #endregion

            #region Uninterrupted
            else
            {
                int numOfInterval = 11;
                int rangeLength = variationRow.Length / (numOfInterval - 1);
                int remainderRange = variationRow.Length % (numOfInterval - 1);
                int rowIndexer = 0, rangeBegin, count;

                for (int i = 0; i < numOfInterval - 1; i++)
                {
                    count = 0;
                    rangeBegin = rowIndexer;
                    do
                    {
                        if (variationRow[rowIndexer] >= variationRow[i * rangeLength] && variationRow[rowIndexer] < variationRow[(i + 1) * rangeLength - 1]) 
                        {
                            count++;
                        }
                        else
                        {
                            break;
                        }
                        rowIndexer++;
                    } while (true);
                    uninterruptedStatisticalDistribution.Add(new Range(variationRow[rangeBegin], variationRow[rowIndexer]), count);
                    rowIndexer++;
                }
            }

            #endregion
        }
        private void BuildWariationRow()
        {
            Array.Copy(data, variationRow, data.Length);
            Array.Sort(variationRow);
        }
        private void BuildEmpiricalFunction()
        {
            double[] uniqueData = variationRow.Distinct().ToArray();
            double value = 0;
            empFunc.slots = new FunctionSlot[statisticalDistribution.Count + 1];
            empFunc.slots[0] = new FunctionSlot(value, new Range(-1, uniqueData[0]));
            for (int i = 1; i < statisticalDistribution.Count; i++)
            {
                value = value + (double)statisticalDistribution[uniqueData[i - 1]] / data.Length;
                empFunc.slots[i] = new FunctionSlot(value, new Range(uniqueData[i - 1], uniqueData[i]));
            }
            value = value + (double)statisticalDistribution[uniqueData[statisticalDistribution.Count - 1]] / data.Length;
            empFunc.slots[statisticalDistribution.Count] = new FunctionSlot(value, new Range(uniqueData[statisticalDistribution.Count - 1], -2));

        }
        private void CalculateNumericValues()
        {
            double medium, dispersion, fixedDispersion, mediumKvadr, fixedMediumKvadr,
                swing, mediane, mode, cvantil, variationCoef, assimetricCoef, ecscess;
            double temp;

            #region Medium
            medium = 0;
            for (int i = 0; i < data.Length; i++)
            {
                medium += data[i];
            }
            medium /= data.Length;
            #endregion

            #region Dispersion

            dispersion = 0;
            for (int i = 0; i < data.Length; i++)
            {
                dispersion += data[i] * data[i];
            }
            dispersion = dispersion / data.Length - medium * medium;
            #endregion

            #region FixedDispersion

            fixedDispersion = dispersion * data.Length / (data.Length - 1);

            #endregion

            #region MediumKvadr

            mediumKvadr = Sqrt(dispersion);

            #endregion

            #region FixedMediumKvadr

            fixedMediumKvadr = Sqrt(fixedDispersion);

            #endregion

            #region Swing

            swing = variationRow[variationRow.Length - 1] - variationRow[0];

            #endregion

            #region Mediane

            if (variationRow.Length % 2 == 0)
            {
                mediane = 0.5 * (variationRow[variationRow.Length / 2] + variationRow[variationRow.Length / 2 + 1]);
            }
            else
            {
                mediane = variationRow[(variationRow.Length + 1) / 2];
            }

            #endregion

            #region Mode

            mode = 0;
            temp = statisticalDistribution.Max(kvp => kvp.Value);
            foreach (KeyValuePair<double, int> item in statisticalDistribution)
            {
                if (item.Value == temp)
                {
                    mode = item.Key;
                    break;
                }
            }

            #endregion

            #region Cvantil

            cvantil = 0.5 * (variationRow[3 * variationRow.Length / 4] - variationRow[variationRow.Length / 4]);

            #endregion

            #region VariationCoef

            variationCoef = fixedMediumKvadr / medium * 100;

            #endregion

            #region AssimetrionCoef

            temp = 0;
            for (int i = 0; i < variationRow.Length; i++)
            {
                temp += Pow((variationRow[i] - medium), 3);
            }
            temp /= variationRow.Length;
            assimetricCoef = temp / Pow(fixedDispersion, 3);

            #endregion

            #region Ecscess

            temp = 0;
            for (int i = 0; i < variationRow.Length; i++)
            {
                temp += Pow((variationRow[i] - medium), 4);
            }
            temp /= variationRow.Length;
            ecscess = temp / Pow(fixedDispersion, 4);

            #endregion

            numValues = new StatisticValues(medium, dispersion, fixedDispersion, mediumKvadr,
                fixedMediumKvadr, swing, mediane, mode, cvantil, variationCoef, assimetricCoef, ecscess);
        }



        public bool CheckByPirson(double levelOfSignificance)
        {
            return false;
        }




    }


    class Program
    {
        static void FullArrayWithRandom(double[] array, int min, int max, Random randomiser)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = randomiser.Next(min, max);
            }
        }
        static void Main(string[] args)
        {
            double[] array = new double[100];
            Random randomiser = new Random();
            FullArrayWithRandom(array, 1, 10, randomiser);
            StatisticAnaliser analiser = new StatisticAnaliser(array, StatisticVariableType.Discrete);

            Console.ReadLine();
        }
    }
}
