using System;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form2 : Form
    {
        public Form2(string name, string country, string gender, string maritalStatus, string hobbies)
        {
            InitializeComponent();

            // Set the values to the labels
            labelName.Text = $"Customer Name: {name}";
            labelCountry.Text = $"Country: {country}";
            labelGender.Text = $"Gender: {gender}";
            labelMaritalStatus.Text = $"Marital Status: {maritalStatus}";
            labelHobbies.Text = $"Hobbies: {hobbies}";
        }
    }
}
