using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Lab1
{
    // нормальний розподіл
    public struct UninterruptedStatisticValues
    {
        public Range mode, mediane;
        public UninterruptedStatisticValues(Range mode, Range mediane)
        {
            this.mode = mode;
            this.mediane = mediane;
        }
    }
    public struct StatisticValues
    {
        public double medium, dispersion, fixedDispersion, mediumKvadr, fixedMediumKvadr, swing, mediane, mode, cvantil, variationCoef, assimetricCoef, ecscess, deviation, variance, standart, variation;
        public StatisticValues(double medium, double dispersion, double fixedDispersion, double mediumKvadr, double fixedMediumKvadr, double swing,
           double mediane, double mode, double cvantil, double variationCoef, double assimetricCoef, double ecscess, double deviation, double variance, double standart, double variation)
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
            this.deviation = deviation;
            this.variance = variance;
            this.standart = standart;
            this.variation = variation;
        }
    }
    public enum StatisticVariableType
    {
        Discrete, Uninterrupted
    }
    public struct Range
    {
        public double begin, end;
        public Range(double begin, double end)
        {
            this.begin = begin;
            this.end = end;
        }
        public override string ToString()
        {
            return string.Format($"{begin} - {end}");
        }
    }
    public struct FunctionSlot
    {
        public double value;
        public Range range;
        public FunctionSlot(double value, Range range)
        {
            this.value = value;
            this.range = range;
        }
    }
    public class EmpiricalFunction
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
    public class StatisticAnaliser
    {
        public StatisticVariableType type;
        public double[] data;

        public double[] variationRow;
        public Dictionary<double, int> statisticalDistribution;
        public EmpiricalFunction empFunc;
        public StatisticValues numValues;
        public Dictionary<double, double> frequencyDistribution;


        public Dictionary<Range, int> uninterruptedStatisticalDistribution;
        public UninterruptedStatisticValues unintNumValues;
        public Dictionary<Range, double> uninterruptedFrequencyDistribution;


        public StatisticAnaliser(double[] data, StatisticVariableType type)
        {
            this.data = data;
            this.type = type;

            variationRow = new double[data.Length];
            empFunc = new EmpiricalFunction();

            statisticalDistribution = new Dictionary<double, int>();
            uninterruptedStatisticalDistribution = new Dictionary<Range, int>();
            frequencyDistribution = new Dictionary<double, double>();
            uninterruptedFrequencyDistribution = new Dictionary<Range, double>();

            BuildWariationRow();
            BuildstatisticalDistribution();
            BuildFrequencyDistribution();

            if (type == StatisticVariableType.Uninterrupted)
            {
                Console.WriteLine(BuildEmpiricalUninterrupted());
            }
            else
            {
                BuildEmpiricalFunction();
            }

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
                double swing = variationRow[variationRow.Length - 1] - variationRow[0];
                double rangeLength = swing / (numOfInterval - 1);
                double remainderRange = swing % (numOfInterval - 1);
                int count = 0, index = 0;
                for (int i = 0; i < numOfInterval - 1; i++)
                {
                    count = 0;
                    do
                    {
                        if (variationRow[index] < (i + 1) * rangeLength)
                        {
                            count++;
                            index++;
                        }
                        else
                        {
                            break;
                        }

                    } while (true);
                    uninterruptedStatisticalDistribution.Add(new Range(i * rangeLength, (i + 1) * rangeLength), count);
                }
                uninterruptedStatisticalDistribution.Add(new Range((numOfInterval - 1) * rangeLength, variationRow[variationRow.Length - 1]), variationRow.Length - 1 - index);
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
            double deviation, variance, standart, variation;
            double temp;
            Range modeUinterrupted, medianeUniterrupted;

            #region Medium
            medium = 0;
            if (type == StatisticVariableType.Discrete)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    medium += data[i];
                }
            }
            else
            {
                foreach (KeyValuePair<Range, int> item in uninterruptedStatisticalDistribution)
                {
                    medium += item.Value * Functions.MedValue(item.Key);
                }
            }
            medium /= data.Length;
            #endregion

            #region Deviation
            deviation = 0;
            if (type == StatisticVariableType.Discrete)
            {
                foreach (KeyValuePair<double, int> item in statisticalDistribution)
                {
                    deviation += item.Value * Pow((item.Key - medium), 2);
                }
            }
            else
            {
                foreach (KeyValuePair<Range, int> item in uninterruptedStatisticalDistribution)
                {
                    deviation += item.Value * Pow((Functions.MedValue(item.Key)), 2);
                }
            }

            #endregion

            #region Variance

            variance = deviation / (data.Length - 1);

            #endregion

            #region Standart

            standart = Sqrt(variance);

            #endregion

            #region Variation

            variation = standart / medium;

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

            mediumKvadr = Sqrt(deviation / variationRow.Length);

            #endregion

            #region FixedMediumKvadr

            fixedMediumKvadr = Sqrt(fixedDispersion);

            #endregion

            #region Swing

            swing = variationRow[variationRow.Length - 1] - variationRow[0];

            #endregion

            #region Mediane
            mediane = 0;
            medianeUniterrupted = new Range(0, 0);
            if (type == StatisticVariableType.Discrete)
            {
                if (variationRow.Length % 2 == 0)
                {
                    mediane = 0.5 * (variationRow[(variationRow.Length + 1) / 2] + variationRow[(variationRow.Length + 1) / 2 + 1]);
                }
                else
                {
                    mediane = variationRow[(variationRow.Length + 1) / 2];
                }
            }
            else
            {
                double findRange = variationRow[variationRow.Length - 1] / 2;
                medianeUniterrupted = new Range(findRange - swing / 11, findRange + swing / 11);
            }

            #endregion

            #region Mode

            mode = 0;
            modeUinterrupted = new Range(0, 0);
            if (type == StatisticVariableType.Discrete)
            {
                temp = statisticalDistribution.Max(kvp => kvp.Value);
                foreach (KeyValuePair<double, int> item in statisticalDistribution)
                {
                    if (item.Value == temp)
                    {
                        mode = item.Key;
                        break;
                    }
                }
            }
            else
            {
                temp = uninterruptedStatisticalDistribution.Max(kvp => kvp.Value);
                foreach (KeyValuePair<Range, int> item in uninterruptedStatisticalDistribution)
                {
                    if (temp == item.Value)
                    {
                        modeUinterrupted = item.Key;
                        break;
                    }
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

            assimetricCoef = Moment(medium, 3) / Pow(Moment(medium, 2), 1.5);

            #endregion

            #region Ecscess

            ecscess = Moment(medium, 4) / Pow(Moment(medium, 2), 2) - 3;

            #endregion

            numValues = new StatisticValues(medium, dispersion, fixedDispersion, mediumKvadr,
                fixedMediumKvadr, swing, mediane, mode, cvantil, variationCoef, assimetricCoef, ecscess, deviation, variance, standart, variation);
            if (type == StatisticVariableType.Uninterrupted)
            {
                unintNumValues = new UninterruptedStatisticValues(modeUinterrupted, medianeUniterrupted);
            }
        }
        public double Moment(double constant, int step)
        {
            double res = 0;
            for (int i = 0; i < variationRow.Length; i++)
            {
                res += Pow((variationRow[i] - constant), step);
            }
            res /= variationRow.Length;
            return res;
        }
        public double Quantil(int value, out bool present)
        {
            if (variationRow.Length % 4 == 0 && value < 4)
            {
                present = true;
                return variationRow[value * variationRow.Length / 4 - 1];
            }
            else
            {
                present = false;
                return 0;
            }
        }
        public string BuildEmpiricalUninterrupted()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("F(x) = \n{\n");
            foreach (KeyValuePair<Range, int> item in uninterruptedStatisticalDistribution)
            {
                sb.AppendFormat($"{Math.Round((item.Key.end - item.Key.begin) / item.Value, 2)}x, x є [{Math.Round(item.Key.begin, 2)}, {Math.Round(item.Key.end, 2)})\n");
            }
            sb.Append("}\n");
            return sb.ToString();
        }
        private void BuildFrequencyDistribution()
        {
            if (type == StatisticVariableType.Discrete)
            {
                foreach (KeyValuePair<double, int> item in statisticalDistribution)
                {
                    frequencyDistribution.Add(item.Key, (double)item.Value / data.Length);
                }
            }
            else
            {
                foreach (KeyValuePair<Range, int> item in uninterruptedStatisticalDistribution)
                {
                    uninterruptedFrequencyDistribution.Add(item.Key, (double)item.Value / data.Length);
                }
            }
        }


    }
    public static class PirsonChecker
    {
        //очікуваний розподіл: нормальний
        static int k = 3;
        private static double theoreticalValue(double value, StatisticAnaliser statistic)
        {
            double h, n = statistic.variationRow.Length; ;
            if (statistic.type == StatisticVariableType.Discrete)
            {
                h = 1;
            }
            else
            {
                h = statistic.variationRow.Length / statistic.uninterruptedStatisticalDistribution.Count;
            }
               
            double Q = statistic.numValues.mediumKvadr;
            double u = statistic.numValues.medium;
            return h * n * (1 / (Q * Sqrt(2 * PI)) * Pow(E, (-Pow(value - u, 2) / (2 * Q * Q))));
        }
        public static double Check(StatisticAnaliser statistic)
        {
            double x2 = 0, expected;
            if (statistic.type == StatisticVariableType.Discrete)
            {
                foreach (KeyValuePair<double, int> item in statistic.statisticalDistribution)
                {
                    expected = theoreticalValue(item.Key, statistic);
                    x2 += Pow(item.Value - expected, 2) / expected;
                }
            }
            else
            {
                double rangeValue = 0;
                foreach (KeyValuePair<Range, int> item in statistic.uninterruptedStatisticalDistribution)
                {
                    rangeValue = Functions.MedValue(item.Key);
                    expected = theoreticalValue(rangeValue, statistic);
                    x2 += Pow(item.Value - expected, 2) / expected;
                }
            }

            return x2;
        }
        public static bool IfTrue(double x2, double levelOf, int count)
        {
            return x2 <= MathNet.Numerics.Distributions.ChiSquared.InvCDF(count - k, 1 - levelOf);
        }
    }

    public static class Functions
    {
        public static void FullArrayWithRandom(double[] array, int min, int max, Random randomiser)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = randomiser.Next(min, max + 1);
            }
        }
        public static double MedValue(Range range)
        {
            return range.end - 0.5 * (range.end - range.begin);
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(MathNet.Numerics.Distributions.ChiSquared.InvCDF(5, 1 - 0.05));
            Console.ReadLine();
        }
    }
}
