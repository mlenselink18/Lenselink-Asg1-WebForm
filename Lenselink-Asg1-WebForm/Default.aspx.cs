using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lenselink_Asg1_WebForm
{
    public partial class Default : System.Web.UI.Page
    {
        public static TextBox selectedInput;

        public static List<Button> InputButtons = new List<Button>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadButtonsToList();
                resetAll();
                selectedInput = TextBoxInput1;
            }
        }

        public void LoadButtonsToList()
        {
            InputButtons.Add(ButtonOne);
            InputButtons.Add(ButtonTwo);
            InputButtons.Add(ButtonThree);
            InputButtons.Add(ButtonFour);
            InputButtons.Add(ButtonFive);
            InputButtons.Add(ButtonSix);
            InputButtons.Add(ButtonSeven);
            InputButtons.Add(ButtonEight);
            InputButtons.Add(ButtonNine);
            InputButtons.Add(ButtonZero);
            InputButtons.Add(ButtonDot);
            InputButtons.Add(ButtonNegative);
        }

        public void toggleEnabled()
        {
            ButtonAdd.Enabled = false;
            ButtonSubtract.Enabled = false;
            ButtonMultiply.Enabled = false;
            ButtonDivide.Enabled = false;
            TextBoxInput2.Enabled = true;
            TextBoxInput1.Enabled = false;
            selectedInput = TextBoxInput2;
        }

        public decimal safeDecimalCast(string input)
        {
            decimal result = 0;

            bool success = decimal.TryParse(input, out result);

            if(success)
            {
                result = decimal.Parse(input);
            }
            else
            {
                LabelError.Text = "Please enter valid numbers";
                LabelError.ForeColor = Color.Red;
                LabelError.Visible = true;
            }

            return result;
        }

        public decimal[] getInputs()
        {
            decimal[] inputs = { safeDecimalCast(TextBoxInput1.Text), safeDecimalCast(TextBoxInput2.Text)};

            if (inputs[0] == 0)
                TextBoxInput1.Text = "0";
            if (inputs[1] == 0)
                TextBoxInput2.Text = "0";

            return inputs;
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            LabelOperator.Text = "+";
            LabelOperator.Visible = true;
            toggleEnabled();
        }

        protected void ButtonSubtract_Click(object sender, EventArgs e)
        {
            LabelOperator.Text = "-";
            LabelOperator.Visible = true;
            toggleEnabled();
        }
        protected void ButtonMultiply_Click(object sender, EventArgs e)
        {
            LabelOperator.Text = "*";
            LabelOperator.Visible = true;
            toggleEnabled();
        }

        protected void ButtonDivide_Click(object sender, EventArgs e)
        {
            LabelOperator.Text = "/";
            LabelOperator.Visible = true;
            toggleEnabled();
        }

        public void ClearError()
        {
            LabelError.Visible = false;
        }

        protected void NumberButton_Click(object sender, EventArgs e)
        {
            string test1 = TextBoxInput1.Text;
            string test2 = TextBoxInput2.Text;
            var button = sender as Button;
            var args = button.Text;
            string newText = "";
            if (selectedInput.ClientID == "TextBoxInput2")
            {
                newText = TextBoxInput2.Text + args.ToString();
                TextBoxInput2.Text = newText;
            }
            else
            {
                newText = test1 + args.ToString();
                TextBoxInput1.Text = newText;
            }
        }

        protected void ButtonSolve_Click(object sender, EventArgs e)
        {
            toggleButtons(false);
            SolveMath();
        }

        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        public void resetAll()
        {
            ClearError();
            toggleButtons(true);
            TextBoxInput1.Text = "";
            TextBoxInput2.Text = "";
            LabelOperator.Visible = false;
            LabelOperator.Text = "";
            TextBoxOutput.Text = "";
            selectedInput = TextBoxInput1;
            ButtonAdd.Enabled = true;
            ButtonSubtract.Enabled = true;
            ButtonMultiply.Enabled = true;
            ButtonDivide.Enabled = true;
            TextBoxInput2.Enabled = false;
            TextBoxInput1.Enabled = true;
        }

        public void SolveMath()
        {
            ClearError();
            var inputs = getInputs();
            var op = LabelOperator.Text;
            string result = "";

            switch (op)
            {
                case ("+"):
                    result = (inputs[0] + inputs[1]).ToString("N4");
                    break;
                case ("-"):
                    result = (inputs[0] - inputs[1]).ToString("N4");
                    break;
                case ("*"):
                    result = (inputs[0] * inputs[1]).ToString("N4");
                    break;
                case ("/"):
                    if (inputs[1] != 0)
                        result = (inputs[0] / inputs[1]).ToString("N4");
                    else
                    {
                        LabelError.Text = "Unable to divide by zero";
                        LabelError.ForeColor = Color.Red;
                        LabelError.Visible = true;
                    }
                    break;
                default:
                    break;
            }
            TextBoxOutput.Text = result;
        }

        public void toggleButtons(bool state)
        {
            foreach(Button item in InputButtons)
            {
                var button = Page.FindControl(item.ClientID) as Button;
                button.Enabled = state;
            }
        }
    }
}