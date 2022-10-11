namespace Calculator
{
    public partial class CalcForm : Form
    {
        double resultValue = 0;
        string operationPerformed = "";
        bool isOperationPerformed = false;

        public CalcForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBoxResult_TextChanged(object sender, EventArgs e)
        {

        }
        private void button_click(object sender, EventArgs e)
        {
            // Removes default "0" or "Error" when something is entered into textBoxResult.
            if ((textBoxResult.Text == "0") | (textBoxResult.Text == "Error") | (isOperationPerformed))
                textBoxResult.Clear();
            
            isOperationPerformed = false;
            Button button = (Button)sender;

            // If "decimal" is clicked, enters period character. If "Ans" is clicked, enters last result if "C" did not clear it.
            // Otherwise, a button's char/string corresponds with what it will enter.
            if (button.Text == "•")
            {
                if (!textBoxResult.Text.Contains('.'))
                    textBoxResult.Text += ".";
            } 
            else if (button.Text == "Ans")
            {
                textBoxResult.Text += resultValue;
            }
            else
            {
                textBoxResult.Text += button.Text;
            }
        }
        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            // Automatically peforms an "equals" click if an operator is clicked before "equals" is clicked.
            if (resultValue != 0)
            {
                equals.PerformClick();
                operationPerformed = button.Text;
                expDisplay.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                // Handle "Error" if operator is clicked while it is in textBoxResult.
                try
                {
                    operationPerformed = button.Text;
                    resultValue = double.Parse(textBoxResult.Text);
                    expDisplay.Text = resultValue + " " + operationPerformed;
                    isOperationPerformed = true;
                }
                catch (Exception)
                {
                    C.PerformClick();
                }
            }
        }

        // Clears entry only
        private void CE_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "0";
        }

        // Clears all
        private void C_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "0";
            expDisplay.Text = "";
            resultValue = 0;
        }

        // Usually clears expDisplay when "equals" is clicked and saves resultValue.
        private void equals_Click(object sender, EventArgs e)
        {
            // "C" click if "Error" if is in textBoxResult when "equals" is clicked.
            if (textBoxResult.Text == "Error")
            {
                C.PerformClick();
            }

            switch (operationPerformed)
            {
                case "+":
                    textBoxResult.Text = (resultValue + double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "-":
                    textBoxResult.Text = (resultValue - double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "×":
                    textBoxResult.Text = (resultValue * double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "÷":
                    textBoxResult.Text = (resultValue / double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "π":
                    textBoxResult.Text = (Math.PI * double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "^":
                    textBoxResult.Text = (Math.Pow(resultValue, double.Parse(textBoxResult.Text)).ToString());
                    break;
                case "×10^":
                    double powerOfTenOP = Math.Pow(10, double.Parse(textBoxResult.Text));
                    textBoxResult.Text = (resultValue * powerOfTenOP).ToString();
                    break;
                case "sin":
                    double sinValue = Math.Sin(double.Parse(textBoxResult.Text));
                    textBoxResult.Text = (resultValue * sinValue).ToString();
                    break;
                case "cos":
                    double cosValue = Math.Cos(double.Parse(textBoxResult.Text));
                    textBoxResult.Text = (resultValue * cosValue).ToString();
                    break;
                case "tan":
                    double tanValue = Math.Tan(double.Parse(textBoxResult.Text));
                    textBoxResult.Text = (resultValue * tanValue).ToString();
                    break;
                default:
                    break;

            }
            
            if (textBoxResult.Text.Contains("∞") || textBoxResult.Text.Contains("NaN"))
            {
                textBoxResult.Text = "Error";
                resultValue = 0;
            }
            else
            {
                resultValue = double.Parse(textBoxResult.Text);
            }
            expDisplay.Text = "";
        }
    }
}
