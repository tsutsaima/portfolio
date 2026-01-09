using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RDotNet;
using System.IO;

namespace RTestApp
{
    public partial class Form1 : Form
    {
        REngine engine;

        public Form1()
        {
            InitializeComponent();
            initEngine();
        }

        private void initEngine()
        {
            try
            {
                REngine.SetEnvironmentVariables(@"C:\Program Files\R\R-4.5.2\bin\x64", @"C:\Program Files\R\R-4.5.2");
                engine = REngine.GetInstance();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            string filename = "plot.png";
            //dataPath.Text = @"C:\Users\mswin\Downloads\archive\mnist_test.csv";
            //operationSelector.SelectedItem = "Relative Frequency";
            if (string.IsNullOrWhiteSpace(dataPath.Text))
            {
                MessageBox.Show("You need to select path to the CSV data", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (operationSelector.SelectedItem == null)
            {
                MessageBox.Show("You have to select an operation", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (engine == null)
            {
                MessageBox.Show("R engine not initialized", "REngine Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] lines = File.ReadAllLines(dataPath.Text);
            double[] numbers;
            try
            {
                numbers = lines.Skip(1).Select(l => double.Parse(l.Split(',')[0])).ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred while parsing ({ex.Message})", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                NumericVector dataVector = engine.CreateNumericVector(numbers);
                engine.SetSymbol("Values", dataVector);
                string func = "";
                bool useOtherGraph = false;
                switch (operationSelector.SelectedItem.ToString())
                {
                    case "Median":
                    case "Mean":
                        func = $"{operationSelector.SelectedItem.ToString().ToLower()}(Values)";
                        break;
                    case "Standard Deviation":
                        func = "sd(Values)";
                        break;
                    case "Variance":
                        func = "var(Values)";
                        useOtherGraph = true;
                        break;
                    case "Relative Frequency":
                        useOtherGraph = true;
                        func = "table(Values)/length(Values)";
                        break;
                    default:
                        MessageBox.Show("Invalid function", "Operation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

                double minVal = numbers.Min();
                double maxVal = numbers.Max();
                double range = maxVal - minVal;

                engine.Evaluate($"png('{filename}', width=800, height=600)");

                engine.Evaluate($"data <- {func}");
                string result = engine.Evaluate("paste(capture.output(print(data)), collapse='\n')").AsCharacter().First();
                engine.Evaluate($"barplot(data, breaks=seq(min(Values), max(Values), length.out=20), xlab='Values', ylab='Relative Frequency', main='Histogram')");
                MessageBox.Show($"Result: {result}", "Calculation Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

                /*
                if (useOtherGraph)
                {
                    engine.Evaluate($"data <- {func}");
                    string result = engine.Evaluate("paste(capture.output(print(data)), collapse='\n')").AsCharacter().First();
                    engine.Evaluate($"barplot(data, breaks=seq(min(Values), max(Values), length.out=20), xlab='Values', ylab='Relative Frequency', main='Histogram')");
                    MessageBox.Show($"Result: {result}", "Calculation Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    engine.Evaluate($"data <- {func}");
                    string result = engine.Evaluate("paste(capture.output(print(data)), collapse='\n')").AsCharacter().First();
                    engine.Evaluate("hist(Values, main='Histogram', breaks=seq(min(Values), max(Values), length.out=20), xlab='Values', ylab='Frequency')");
                    MessageBox.Show($"Result: {result}", "Calculation Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                */
                /*
                if (range <= 10)
                {
                        engine.Evaluate($"data <- {func}");
                        string result = engine.Evaluate("paste(capture.output(print(data)), collapse='\n')").AsCharacter().First();
                        engine.Evaluate($"barplot(data, breaks=seq(min(Values), max(Values), length.out=20), xlab='Values', ylab='Relative Frequency', main='Histogram')");
                        MessageBox.Show($"Result: {result}", "Calculation Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    double step = Math.Ceiling(range / 10);
                    if (useOtherGraph)
                    {
                        engine.Evaluate($"data <- {func}");
                        string result = engine.Evaluate("paste(capture.output(print(data)), collapse='\n')").AsCharacter().First();
                        engine.Evaluate($"barplot(data, breaks=seq(min(Values), max(Values), length.out=20), xlab='Values', ylab='Relative Frequency', main='Histogram')");
                        MessageBox.Show($"Result: {result}", "Calculation Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        engine.Evaluate("hist(Values, main='Histogram', breaks=seq(min(Values), max(Values), length.out=20), xlab='Values', ylab='Frequency')");
                    }
                }

                */
                engine.Evaluate("dev.off()");

                System.Threading.Thread.Sleep(100);
                if (!File.Exists(filename))
                {
                    MessageBox.Show("Plot file was not created", "Plot Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Image img = Image.FromFile(filename);
                ResultForm resultForm = new ResultForm(img);
                resultForm.Show();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during R execution: {ex.Message}", "R Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openFile_Click(object sender, EventArgs e)
        {

        }

        private void dataPath_Enter(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog1.Title = "Select Data File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dataPath.Text = openFileDialog1.FileName;
            }
        }
    }
}