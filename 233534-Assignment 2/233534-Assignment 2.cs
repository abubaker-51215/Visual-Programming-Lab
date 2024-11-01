using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // MessageBox
            Button showMessageBoxButton = new Button() { Text = "Show MessageBox", Location = new System.Drawing.Point(10, 10) };
            showMessageBoxButton.Click += (sender, e) => MessageBox.Show("This is a MessageBox.Which i creates");
            this.Controls.Add(showMessageBoxButton);

            // Label
            Label label = new Label() { Text = "This is a Label", Location = new System.Drawing.Point(10, 50) };
            this.Controls.Add(label);

            // TextBox
            TextBox textBox = new TextBox() { Location = new System.Drawing.Point(10, 80) };
            this.Controls.Add(textBox);

            // RichTextBox
            RichTextBox richTextBox = new RichTextBox() { Location = new System.Drawing.Point(10, 110), Height = 50, Width = 150 };
            richTextBox.Text = "This is a RichTextBox.";
            this.Controls.Add(richTextBox);

            // CheckBox
            CheckBox checkBox = new CheckBox() { Text = "Check Me", Location = new System.Drawing.Point(10, 170) };
            checkBox.CheckedChanged += (sender, e) => MessageBox.Show(checkBox.Checked ? "Checked!" : "Unchecked!");
            this.Controls.Add(checkBox);

            // RadioButton
            RadioButton radioButton = new RadioButton() { Text = "Select Me", Location = new System.Drawing.Point(10, 200) };
            radioButton.CheckedChanged += (sender, e) => MessageBox.Show(radioButton.Checked ? "Radio Selected!" : "Radio Deselected!");
            this.Controls.Add(radioButton);

            // ComboBox
            ComboBox comboBox = new ComboBox() { Location = new System.Drawing.Point(10, 230) };
            comboBox.Items.Add("Option 1");
            comboBox.Items.Add("Option 2");
            comboBox.Items.Add("Option 3");
            comboBox.SelectedIndexChanged += (sender, e) => MessageBox.Show("Selected: " + comboBox.SelectedItem);
            this.Controls.Add(comboBox);

            // NumericUpDown
            NumericUpDown numericUpDown = new NumericUpDown() { Location = new System.Drawing.Point(10, 260) };
            numericUpDown.ValueChanged += (sender, e) => MessageBox.Show("Value: " + numericUpDown.Value);
            this.Controls.Add(numericUpDown);

            // DateTimePicker
            DateTimePicker dateTimePicker = new DateTimePicker() { Location = new System.Drawing.Point(10, 290) };
            dateTimePicker.ValueChanged += (sender, e) => MessageBox.Show("Date: " + dateTimePicker.Value.ToShortDateString());
            this.Controls.Add(dateTimePicker);

            // MonthCalendar
            MonthCalendar monthCalendar = new MonthCalendar() { Location = new System.Drawing.Point(10, 320) };
            monthCalendar.DateSelected += (sender, e) => MessageBox.Show("Selected Date: " + monthCalendar.SelectionStart.ToShortDateString());
            this.Controls.Add(monthCalendar);

            // PictureBox
            PictureBox pictureBox = new PictureBox() { Location = new System.Drawing.Point(250, 10), Width = 100, Height = 100 };
            pictureBox.ImageLocation = "https://via.Ahmad_Ijaz.com/100"; 
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pictureBox);
        }
    }
}
