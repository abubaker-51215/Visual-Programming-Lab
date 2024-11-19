using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaOrderApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonThick_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonPlaceOrder_Click(object sender, EventArgs e)
        {
            // Get selected pizza size
            string size = comboBoxSize.SelectedItem?.ToString() ?? "No size selected";

            // Get selected toppings
            List<string> toppings = new List<string>();
            if (checkBoxCheese.Checked) toppings.Add("Cheese");
            if (checkBoxPepperoni.Checked) toppings.Add("Pepperoni");
            if (checkBoxMushrooms.Checked) toppings.Add("Mushrooms");

            // Get crust type
            string crustType = radioButtonThin.Checked ? "Thin Crust" :
                               radioButtonThick.Checked ? "Thick Crust" : "No crust selected";

            // Prepare order summary
            string toppingsSummary = toppings.Count > 0 ? string.Join(", ", toppings) : "No toppings";
            string orderSummary = $"Size: {size}\nToppings: {toppingsSummary}\nCrust: {crustType}";

            // Display order summary in label
            labelSummary.Text = "Your Order:\n" + orderSummary;
        }

    }
}
