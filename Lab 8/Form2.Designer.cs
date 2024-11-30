namespace WindowsFormsApp5
{
    partial class Form2
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
            this.labelName = new System.Windows.Forms.Label();
            this.labelCountry = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.labelMaritalStatus = new System.Windows.Forms.Label();
            this.labelHobbies = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(30, 30);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(138, 20);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Customer Name:";
            // 
            // labelCountry
            // 
            this.labelCountry.AutoSize = true;
            this.labelCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCountry.Location = new System.Drawing.Point(30, 70);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Size = new System.Drawing.Size(90, 20);
            this.labelCountry.TabIndex = 1;
            this.labelCountry.Text = "Country:";
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGender.Location = new System.Drawing.Point(30, 110);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(84, 20);
            this.labelGender.TabIndex = 2;
            this.labelGender.Text = "Gender:";
            // 
            // labelMaritalStatus
            // 
            this.labelMaritalStatus.AutoSize = true;
            this.labelMaritalStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaritalStatus.Location = new System.Drawing.Point(30, 150);
            this.labelMaritalStatus.Name = "labelMaritalStatus";
            this.labelMaritalStatus.Size = new System.Drawing.Size(132, 20);
            this.labelMaritalStatus.TabIndex = 3;
            this.labelMaritalStatus.Text = "Marital Status:";
            // 
            // labelHobbies
            // 
            this.labelHobbies.AutoSize = true;
            this.labelHobbies.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHobbies.Location = new System.Drawing.Point(30, 190);
            this.labelHobbies.Name = "labelHobbies";
            this.labelHobbies.Size = new System.Drawing.Size(90, 20);
            this.labelHobbies.TabIndex = 4;
            this.labelHobbies.Text = "Hobbies:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.labelHobbies);
            this.Controls.Add(this.labelMaritalStatus);
            this.Controls.Add(this.labelGender);
            this.Controls.Add(this.labelCountry);
            this.Controls.Add(this.labelName);
            this.Name = "Form2";
            this.Text = "Customer Details Preview";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelCountry;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelMaritalStatus;
        private System.Windows.Forms.Label labelHobbies;
    }
}
