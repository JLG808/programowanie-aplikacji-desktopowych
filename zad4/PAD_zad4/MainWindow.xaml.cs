using System;
using System.Windows;
using System.Windows.Controls;

namespace Kalkulator
{
    public partial class MainWindow : Window
    {
        private double leftOperand = 0;
        private double rightOperand = 0;
        private string currentOperation = "";

        private bool waitingForNewNumber = false;
        private bool operationJustExecuted = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (Display.Text == "0" || waitingForNewNumber)
            {
                Display.Text = btn.Content.ToString();
                waitingForNewNumber = false;
            }
            else
            {
                Display.Text += btn.Content.ToString();
            }
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            leftOperand = double.Parse(Display.Text);
            currentOperation = btn.Content.ToString();

            waitingForNewNumber = true;
            operationJustExecuted = false;
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (!operationJustExecuted)
            {
                rightOperand = double.Parse(Display.Text);
            }

            double result = ExecuteOperation(
                leftOperand,
                rightOperand,
                currentOperation);

            Display.Text = result.ToString();

            leftOperand = result;

            operationJustExecuted = true;
            waitingForNewNumber = true;
        }

        private double ExecuteOperation(
            double left,
            double right,
            string op)
        {
            switch (op)
            {
                case "+": return left + right;
                case "-": return left - right;
                case "*": return left * right;
                case "/": return right != 0 ? left / right : 0;
                case "^": return Math.Pow(left, right);
                default: return left;
            }
        }

        private void Power_Click(object sender, RoutedEventArgs e)
        {
            leftOperand = double.Parse(Display.Text);
            currentOperation = "^";

            waitingForNewNumber = true;
            operationJustExecuted = false;
        }

        private void Percent_Click(object sender, RoutedEventArgs e)
        {
            double value = double.Parse(Display.Text);

            value /= 100.0;

            Display.Text = value.ToString();

            waitingForNewNumber = true;
        }

        private void Sqrt_Click(object sender, RoutedEventArgs e)
        {
            double value;

            if (!operationJustExecuted)
                value = double.Parse(Display.Text);
            else
                value = rightOperand;

            rightOperand = value;

            double result = Math.Sqrt(value);

            Display.Text = result.ToString();

            leftOperand = result;
            operationJustExecuted = true;
            waitingForNewNumber = true;
        }

        private void Inverse_Click(object sender, RoutedEventArgs e)
        {
            double value;

            if (!operationJustExecuted)
                value = double.Parse(Display.Text);
            else
                value = rightOperand;

            rightOperand = value;

            double result = 1.0 / value;

            Display.Text = result.ToString();

            leftOperand = result;
            operationJustExecuted = true;
            waitingForNewNumber = true;
        }

        private void Square_Click(object sender, RoutedEventArgs e)
        {
            double value;

            if (!operationJustExecuted)
                value = double.Parse(Display.Text);
            else
                value = rightOperand;

            rightOperand = value;

            double result = value * value;

            Display.Text = result.ToString();

            leftOperand = result;
            operationJustExecuted = true;
            waitingForNewNumber = true;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";

            leftOperand = 0;
            rightOperand = 0;
            currentOperation = "";

            waitingForNewNumber = false;
            operationJustExecuted = false;
        }
    }
}