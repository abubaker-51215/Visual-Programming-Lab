namespace WindowsFormsApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.ListBox listBoxData;
        private System.Windows.Forms.Button btnAdd;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtInput = new System.Windows.Forms.TextBox();
            this.listBoxData = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // txtInput
            this.txtInput.Location = new System.Drawing.Point(12, 12);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(200, 20);
            this.txtInput.TabIndex = 0;

            // listBoxData
            this.listBoxData.FormattingEnabled = true;
            this.listBoxData.Location = new System.Drawing.Point(12, 38);
            this.listBoxData.Name = "listBoxData";
            this.listBoxData.Size = new System.Drawing.Size(200, 95);
            this.listBoxData.TabIndex = 1;

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(218, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // MainForm
            this.ClientSize = new System.Drawing.Size(304, 161);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.listBoxData);
            this.Controls.Add(this.txtInput);
            this.Name = "MainForm";
            this.Text = "List Manager";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
