using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Lab1;
using static System.Math;

namespace GraphicalInterface
{
    public partial class mainForm : Form
    {
        StatisticAnaliser analiser;
        double[] data;
        Random appRandomiser = new Random();

        public mainForm()
        {
            InitializeComponent();

        }

        private void generateTextButton_Click(object sender, EventArgs e)
        {
            int count, min, max;
            count = Convert.ToInt32(countTextBox.Text);
            min = Convert.ToInt32(minTextBox.Text);
            max = Convert.ToInt32(maxTextBox.Text);

            data = new double[count];
            Functions.FullArrayWithRandom(data, min, max, appRandomiser);

            showDataInChart();
        }

        private void showDataInChart()
        {
            dataChart.Series[0] = new System.Windows.Forms.DataVisualization.Charting.Series("Value");
            dataChart.Series[0].Points.DataBindXY(null, data);

        }

        private void analyseTextButton_Click(object sender, EventArgs e)
        {
            #region Type Check
            if (discreteRadioButton.Checked)
            {
                analiser = new StatisticAnaliser(data, StatisticVariableType.Discrete);
            }
            else if (uninterruptedRadioButton.Checked)
            {
                analiser = new StatisticAnaliser(data, StatisticVariableType.Uninterrupted);
            }
            else
            {
                outputTextBox.Text = "To analyze sample, check sample type!";
                return;
            }
            #endregion
            outputTextBox.Clear();

            double x2Temp;
            StringBuilder outputStringBuilder = new StringBuilder();


            if (analiser.type == StatisticVariableType.Discrete)
            {
                #region Poligon
                dataChart2.Series[0] = new System.Windows.Forms.DataVisualization.Charting.Series("Frequency Distribution");
                dataChart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                List<double> frequencyList = new List<double>();
                List<double> valueList = new List<double>();
                foreach (KeyValuePair<double, double> item in analiser.frequencyDistribution)
                {
                    frequencyList.Add(item.Value);
                    valueList.Add(item.Key);
                }
                dataChart2.Series[0].Points.DataBindXY(valueList.ToArray(), frequencyList.ToArray());
                #endregion

                #region Diagram
                dataChart.Series[0] = new System.Windows.Forms.DataVisualization.Charting.Series("Frequency Distribution");
                dataChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                dataChart.ChartAreas[0].AxisX.Interval = Round(analiser.numValues.swing / analiser.statisticalDistribution.Count, 2);
                frequencyList.Clear();
                valueList.Clear();
                foreach (KeyValuePair<double, int> item in analiser.statisticalDistribution)
                {
                    frequencyList.Add(item.Value);
                    valueList.Add(item.Key);
                }
                dataChart.Series[0].Points.DataBindXY(valueList.ToArray(), frequencyList.ToArray());
                #endregion
            }
            else
            {
                #region Polygon
                dataChart.Series[0] = new System.Windows.Forms.DataVisualization.Charting.Series("Frequency Distribution");
                dataChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                dataChart.ChartAreas[0].AxisX.Interval = Round(analiser.numValues.swing / 10, 2);
                List<double> rangeList = new List<double>();
                rangeList.Add(0);
                List<double> frequencyList = new List<double>();
                frequencyList.Add(0);
                foreach (KeyValuePair<Range, int> item in analiser.uninterruptedStatisticalDistribution)
                {
                    frequencyList.Add(item.Value);
                    rangeList.Add(Functions.MedValue(item.Key));
                }
                dataChart.Series[0].Points.DataBindXY(rangeList.ToArray(), frequencyList.ToArray());
                #endregion

                #region Gistogram
                dataChart2.Series[0] = new System.Windows.Forms.DataVisualization.Charting.Series("Frequency Distribution");
                dataChart2.ChartAreas[0].AxisX.Crossing = 0;
                dataChart2.ChartAreas[0].AxisX.Interval = Round(analiser.numValues.swing / 20, 2);
                frequencyList.Clear();
                rangeList.Clear();
                foreach (KeyValuePair<Range, double> item in analiser.uninterruptedFrequencyDistribution)
                {
                    frequencyList.Add(item.Value);
                    rangeList.Add(Functions.MedValue(item.Key));
                }
                dataChart2.Series[0].Points.DataBindXY(rangeList.ToArray(), frequencyList.ToArray()); 
                #endregion
            }



            if (analiser.type == StatisticVariableType.Discrete)
            {
                outputStringBuilder.AppendLine("Variation row: \n");
                foreach (double item in analiser.variationRow)
                {
                    outputStringBuilder.AppendFormat($"{item} ");
                }
                outputStringBuilder.AppendLine(); 
            }

            if (analiser.type == StatisticVariableType.Discrete)
            {
                outputStringBuilder.AppendLine("Statistical distribution: \n");
                foreach (KeyValuePair<double, int> item in analiser.statisticalDistribution)
                {
                    outputStringBuilder.AppendFormat($"Value: {item.Key}, count: {item.Value}");
                    outputStringBuilder.AppendLine();
                }
                outputStringBuilder.AppendLine();
                outputStringBuilder.AppendLine("Empirical function:");

                #region Empirical func

                outputStringBuilder.AppendLine("F(x) =");
                outputStringBuilder.AppendLine("{");
                outputStringBuilder.AppendFormat($"{analiser.empFunc.slots[0].value}, x<={analiser.empFunc.slots[0].range.end}");
                outputStringBuilder.AppendLine();
                for (int i = 1; i < analiser.empFunc.slots.Length - 1; i++)
                {
                    outputStringBuilder.AppendFormat($"{analiser.empFunc.slots[i].value}, {analiser.empFunc.slots[i].range.begin}<x<={analiser.empFunc.slots[i].range.end}");
                    outputStringBuilder.AppendLine();
                }
                outputStringBuilder.AppendFormat($"{analiser.empFunc.slots[analiser.empFunc.slots.Length - 1].value}, x>{analiser.empFunc.slots[analiser.empFunc.slots.Length - 1].range.begin}");
                outputStringBuilder.AppendLine();
                outputStringBuilder.AppendLine("}");

                #endregion

                outputStringBuilder.AppendLine("Numerical values:");

                outputStringBuilder.AppendLine("Mode, Mo:");
                outputStringBuilder.AppendLine(analiser.numValues.mode.ToString());
                outputStringBuilder.AppendLine("Mediane, Me:");
                outputStringBuilder.AppendLine(analiser.numValues.mediane.ToString());

                addNumValues(outputStringBuilder);

                outputStringBuilder.AppendLine("\nCheck by Pirson for normal distribution: \n");

                outputStringBuilder.AppendLine($"D.F = {analiser.statisticalDistribution.Count - 3}");
                x2Temp = PirsonChecker.Check(analiser);
                outputStringBuilder.AppendLine($"X2 = {x2Temp}");
                if (levelOfsignificanceTextBox.Text != "")
                {
                    outputStringBuilder.AppendLine($"The correctness of hypothesis: {PirsonChecker.IfTrue(x2Temp, Convert.ToDouble(levelOfsignificanceTextBox.Text), analiser.statisticalDistribution.Count)}");
                }
                else
                {
                    outputTextBox.Text = "Enter level of significance";
                }
            }
            else
            {
                outputStringBuilder.AppendLine("Statistical distribution: \n");
                foreach (KeyValuePair<Range, int> item in analiser.uninterruptedStatisticalDistribution)
                {
                    outputStringBuilder.AppendLine(string.Format($"Range: x є [{item.Key.begin}, {item.Key.end}), count: {item.Value}"));
                }
                outputStringBuilder.AppendLine();

                outputStringBuilder.AppendLine(analiser.BuildEmpiricalUninterrupted());

                outputStringBuilder.AppendLine("Numerical values:");

                outputStringBuilder.AppendLine("Mode, Mo:");
                outputStringBuilder.AppendLine(string.Format($"[{analiser.unintNumValues.mode.begin}, {analiser.unintNumValues.mode.end})"));
                outputStringBuilder.AppendLine("Mediane, Me:");
                outputStringBuilder.AppendLine(string.Format($"[{analiser.unintNumValues.mediane.begin}, {analiser.unintNumValues.mediane.end})"));

                addNumValues(outputStringBuilder);

                outputStringBuilder.AppendLine("\nCheck by Pirson for normal distribution: \n");
                outputStringBuilder.AppendLine($"D.F = {analiser.uninterruptedStatisticalDistribution.Count - 3}");
                x2Temp = PirsonChecker.Check(analiser);
                outputStringBuilder.AppendLine($"X2 = {x2Temp}");
                if (levelOfsignificanceTextBox.Text != "")
                {
                    outputStringBuilder.AppendLine($"The correctness of hypothesis: {PirsonChecker.IfTrue(x2Temp, Convert.ToDouble(levelOfsignificanceTextBox.Text), analiser.uninterruptedStatisticalDistribution.Count)}");
                }
                else
                {
                    outputTextBox.Text = "Enter level of significance";
                }
            }

            outputTextBox.Text = outputStringBuilder.ToString();

        }
        private void addNumValues(StringBuilder outputStringBuilder)
        {
            outputStringBuilder.AppendLine("Medium value:");
            outputStringBuilder.AppendLine(analiser.numValues.medium.ToString());
            outputStringBuilder.AppendLine("Deviation, Dv:");
            outputStringBuilder.AppendLine(analiser.numValues.deviation.ToString());
            outputStringBuilder.AppendLine("Variance, s2:");
            outputStringBuilder.AppendLine(analiser.numValues.variance.ToString());
            outputStringBuilder.AppendLine("Standart, s:");
            outputStringBuilder.AppendLine(analiser.numValues.standart.ToString());
            outputStringBuilder.AppendLine("Variation, u:");
            outputStringBuilder.AppendLine(analiser.numValues.variation.ToString());
            outputStringBuilder.AppendLine("Swing, r:");
            outputStringBuilder.AppendLine(analiser.numValues.swing.ToString());
            //outputStringBuilder.AppendLine("Dispersion, Db:");
            //outputStringBuilder.AppendLine(analiser.numValues.dispersion.ToString());
            outputStringBuilder.AppendLine("Assimetrion coef, Ab:");
            outputStringBuilder.AppendLine(analiser.numValues.assimetricCoef.ToString());
            outputStringBuilder.AppendLine("Medium kvadr, Qb:");
            outputStringBuilder.AppendLine(analiser.numValues.mediumKvadr.ToString());
            //outputStringBuilder.AppendLine("Fixed dispersion, s2:");
            //outputStringBuilder.AppendLine(analiser.numValues.fixedDispersion.ToString());
            //outputStringBuilder.AppendLine("Fixed medium kvadr, s:");
            //outputStringBuilder.AppendLine(analiser.numValues.fixedMediumKvadr.ToString());
            //outputStringBuilder.AppendLine("Variation coef, V:");
            //outputStringBuilder.AppendLine(analiser.numValues.variationCoef.ToString());
            //outputStringBuilder.AppendLine("Cvantil, Q:");
            //outputStringBuilder.AppendLine(analiser.numValues.cvantil.ToString());
            outputStringBuilder.AppendLine("Ecscess, Eb:");
            outputStringBuilder.AppendLine(analiser.numValues.ecscess.ToString());
           
        }

        private void readToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<double> tempList = new List<double>();
            double temp;
            string[] combination = new string[2];
            string fileName = @"..\..\StatisticData.txt";
            using (StreamReader sr = File.OpenText(fileName))
            {
                string input = null;
                while ((input = sr.ReadLine()) != null)
                {
                    combination = input.Split(' ');
                    temp = Convert.ToInt32(combination[0]);
                    for (int i = 0; i < Convert.ToInt32(combination[1]); i++)
                    {
                        tempList.Add(temp);
                    }

                }
            }
            data = tempList.ToArray();
            showDataInChart();
        }

        private void calculateBautton_Click(object sender, EventArgs e)
        {
            if (momentRadioButton.Checked)
            {
                outputTextBox.Text = analiser.Moment(Convert.ToDouble(mainValueTextBox.Text), Convert.ToInt32(additionalTextBox.Text)).ToString();
            }
            else if(quantilRadioButton.Checked)
            {
                bool pres;
                double res = analiser.Quantil(Convert.ToInt32(mainValueTextBox.Text), out pres);
                if (pres)
                {
                    outputTextBox.Text = string.Format($"{mainValueTextBox.Text} Quantil = {res}");
                }
                else
                {
                    outputTextBox.Text = "There aren't quantil like that";
                }
            }
        }
    }
}
