namespace PizzaOrderApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxSize = new System.Windows.Forms.ComboBox();
            this.checkBoxCheese = new System.Windows.Forms.CheckBox();
            this.checkBoxPepperoni = new System.Windows.Forms.CheckBox();
            this.checkBoxMushrooms = new System.Windows.Forms.CheckBox();
            this.radioButtonThin = new System.Windows.Forms.RadioButton();
            this.radioButtonThick = new System.Windows.Forms.RadioButton();
            this.buttonPlaceOrder = new System.Windows.Forms.Button();
            this.labelSummary = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxSize
            // 
            this.comboBoxSize.FormattingEnabled = true;
            this.comboBoxSize.Items.AddRange(new object[] {
            "Small\t",
            "Medim",
            "Large"});
            this.comboBoxSize.Location = new System.Drawing.Point(325, 34);
            this.comboBoxSize.Name = "comboBoxSize";
            this.comboBoxSize.Size = new System.Drawing.Size(121, 24);
            this.comboBoxSize.TabIndex = 0;
            this.comboBoxSize.SelectedIndexChanged += new System.EventHandler(this.comboBoxSize_SelectedIndexChanged);
            // 
            // checkBoxCheese
            // 
            this.checkBoxCheese.AutoSize = true;
            this.checkBoxCheese.Location = new System.Drawing.Point(244, 90);
            this.checkBoxCheese.Name = "checkBoxCheese";
            this.checkBoxCheese.Size = new System.Drawing.Size(76, 20);
            this.checkBoxCheese.TabIndex = 1;
            this.checkBoxCheese.Text = "Cheese";
            this.checkBoxCheese.UseVisualStyleBackColor = true;
            // 
            // checkBoxPepperoni
            // 
            this.checkBoxPepperoni.AutoSize = true;
            this.checkBoxPepperoni.Location = new System.Drawing.Point(332, 90);
            this.checkBoxPepperoni.Name = "checkBoxPepperoni";
            this.checkBoxPepperoni.Size = new System.Drawing.Size(92, 20);
            this.checkBoxPepperoni.TabIndex = 2;
            this.checkBoxPepperoni.Text = "Pepperoni\n";
            this.checkBoxPepperoni.UseVisualStyleBackColor = true;
            // 
            // checkBoxMushrooms
            // 
            this.checkBoxMushrooms.AutoSize = true;
            this.checkBoxMushrooms.Location = new System.Drawing.Point(430, 90);
            this.checkBoxMushrooms.Name = "checkBoxMushrooms";
            this.checkBoxMushrooms.Size = new System.Drawing.Size(99, 20);
            this.checkBoxMushrooms.TabIndex = 3;
            this.checkBoxMushrooms.Text = "Mushrooms";
            this.checkBoxMushrooms.UseVisualStyleBackColor = true;
            // 
            // radioButtonThin
            // 
            this.radioButtonThin.AutoSize = true;
            this.radioButtonThin.Location = new System.Drawing.Point(244, 140);
            this.radioButtonThin.Name = "radioButtonThin";
            this.radioButtonThin.Size = new System.Drawing.Size(87, 20);
            this.radioButtonThin.TabIndex = 4;
            this.radioButtonThin.TabStop = true;
            this.radioButtonThin.Text = "Thin Crust";
            this.radioButtonThin.UseVisualStyleBackColor = true;
            // 
            // radioButtonThick
            // 
            this.radioButtonThick.AutoSize = true;
            this.radioButtonThick.Location = new System.Drawing.Point(244, 178);
            this.radioButtonThick.Name = "radioButtonThick";
            this.radioButtonThick.Size = new System.Drawing.Size(94, 20);
            this.radioButtonThick.TabIndex = 5;
            this.radioButtonThick.TabStop = true;
            this.radioButtonThick.Text = "Thick Crust";
            this.radioButtonThick.UseVisualStyleBackColor = true;
            this.radioButtonThick.CheckedChanged += new System.EventHandler(this.radioButtonThick_CheckedChanged);
            // 
            // buttonPlaceOrder
            // 
            this.buttonPlaceOrder.Location = new System.Drawing.Point(332, 251);
            this.buttonPlaceOrder.Name = "buttonPlaceOrder";
            this.buttonPlaceOrder.Size = new System.Drawing.Size(75, 23);
            this.buttonPlaceOrder.TabIndex = 6;
            this.buttonPlaceOrder.Text = "Place Order";
            this.buttonPlaceOrder.UseVisualStyleBackColor = true;
            this.buttonPlaceOrder.Click += new System.EventHandler(this.buttonPlaceOrder_Click);
            // 
            // labelSummary
            // 
            this.labelSummary.AutoSize = true;
            this.labelSummary.Location = new System.Drawing.Point(320, 336);
            this.labelSummary.Name = "labelSummary";
            this.labelSummary.Size = new System.Drawing.Size(0, 16);
            this.labelSummary.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelSummary);
            this.Controls.Add(this.buttonPlaceOrder);
            this.Controls.Add(this.radioButtonThick);
            this.Controls.Add(this.radioButtonThin);
            this.Controls.Add(this.checkBoxMushrooms);
            this.Controls.Add(this.checkBoxPepperoni);
            this.Controls.Add(this.checkBoxCheese);
            this.Controls.Add(this.comboBoxSize);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSize;
        private System.Windows.Forms.CheckBox checkBoxCheese;
        private System.Windows.Forms.CheckBox checkBoxPepperoni;
        private System.Windows.Forms.CheckBox checkBoxMushrooms;
        private System.Windows.Forms.RadioButton radioButtonThin;
        private System.Windows.Forms.RadioButton radioButtonThick;
        private System.Windows.Forms.Button buttonPlaceOrder;
        private System.Windows.Forms.Label labelSummary;
    }
}

