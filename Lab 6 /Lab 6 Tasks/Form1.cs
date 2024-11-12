using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class MainForm : Form
    {
        private List<string> dataList = new List<string>();

        public MainForm()
        {
            InitializeComponent();
        }

        // Event handler for Add button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtInput.Text))
            {
                dataList.Add(txtInput.Text);
                UpdateListBox();
                txtInput.Clear();
            }
        }

        // Method to update the ListBox
        private void UpdateListBox()
        {
            listBoxData.DataSource = null;  // Reset DataSource
            listBoxData.DataSource = dataList;  // Set DataSource to updated list
        }
    }
}
