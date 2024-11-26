using System;
using System.Windows.Forms;

namespace Practice_233534
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Collect data from Form1 controls
            string customerName = textBox1.Text;
            string country = comboBox1.SelectedItem?.ToString() ?? "Not Specified";
            string gender = radioButton1.Checked ? "Male" : radioButton2.Checked ? "Female" : "Not Specified";
            string hobbies = "";
            if (checkBox1.Checked) hobbies += "Reading ";
            if (checkBox2.Checked) hobbies += "Painting ";
            if (string.IsNullOrWhiteSpace(hobbies)) hobbies = "None";

            // Collect marital status
            string maritalStatus = radioButton3.Checked ? "Single" : radioButton4.Checked ? "Married" : "Not Specified";

            // Create an instance of Form2 and pass the data
            Form2 previewForm = new Form2(customerName, country, gender, hobbies, maritalStatus);
            previewForm.Show(); // Display the Form2
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load countries into the combo box (as an example)
            comboBox1.Items.AddRange(new string[] { "USA", "Canada", "UK", "Australia" });
        }
    }
}