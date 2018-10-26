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

            dataChart.Series[0] = new System.Windows.Forms.DataVisualization.Charting.Series("Variation Row");
            dataChart.Series[0].Points.DataBindXY(null, analiser.variationRow);

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

                outputStringBuilder.AppendLine($"D.F = {analiser.statisticalDistribution.Count - 1}");
                x2Temp = PirsonChecker.Check(analiser);
                outputStringBuilder.AppendLine($"X2 = {x2Temp}");
                if (levelOfsignificanceTextBox.Text != "")
                {
                    outputStringBuilder.AppendLine($"The correctness of hypothesis: {PirsonChecker.IfTrue(x2Temp, Convert.ToDouble(levelOfsignificanceTextBox.Text), analiser.statisticalDistribution.Count - 1)}");
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
                outputStringBuilder.AppendLine($"D.F = {analiser.uninterruptedStatisticalDistribution.Count - 1}");
                x2Temp = PirsonChecker.Check(analiser);
                outputStringBuilder.AppendLine($"X2 = {x2Temp}");
                if (levelOfsignificanceTextBox.Text != "")
                {
                    outputStringBuilder.AppendLine($"The correctness of hypothesis: {PirsonChecker.IfTrue(x2Temp, Convert.ToDouble(levelOfsignificanceTextBox.Text), analiser.uninterruptedStatisticalDistribution.Count - 1)}"); 
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
            outputStringBuilder.AppendLine("Swing, r:");
            outputStringBuilder.AppendLine(analiser.numValues.swing.ToString());
            outputStringBuilder.AppendLine("Dispersion, Db:");
            outputStringBuilder.AppendLine(analiser.numValues.dispersion.ToString());
            outputStringBuilder.AppendLine("Assimetrion coef, Ab:");
            outputStringBuilder.AppendLine(analiser.numValues.assimetricCoef.ToString());
            outputStringBuilder.AppendLine("Medium kvadr, Qb:");
            outputStringBuilder.AppendLine(analiser.numValues.mediumKvadr.ToString());
            outputStringBuilder.AppendLine("Fixed dispersion, s2:");
            outputStringBuilder.AppendLine(analiser.numValues.fixedDispersion.ToString());
            outputStringBuilder.AppendLine("Fixed medium kvadr, s:");
            outputStringBuilder.AppendLine(analiser.numValues.fixedMediumKvadr.ToString());
            outputStringBuilder.AppendLine("Variation coef, V:");
            outputStringBuilder.AppendLine(analiser.numValues.variationCoef.ToString());
            outputStringBuilder.AppendLine("Cvantil, Q:");
            outputStringBuilder.AppendLine(analiser.numValues.cvantil.ToString());
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
    }
}
