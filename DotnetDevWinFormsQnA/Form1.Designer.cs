namespace DotnetDevWinFormsQnA
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.editedRadioButton1 = new DotnetDevWinFormsQnA.EditedRadioButton();
            this.editedRadioButton2 = new DotnetDevWinFormsQnA.EditedRadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.editedRadioButton1);
            this.flowLayoutPanel1.Controls.Add(this.editedRadioButton2);
            this.flowLayoutPanel1.Controls.Add(this.radioButton1);
            this.flowLayoutPanel1.Controls.Add(this.radioButton2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(70, 87);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(154, 144);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // editedRadioButton1
            // 
            this.editedRadioButton1.AutoSize = true;
            this.editedRadioButton1.Checked = true;
            this.editedRadioButton1.Location = new System.Drawing.Point(3, 3);
            this.editedRadioButton1.Name = "editedRadioButton1";
            this.editedRadioButton1.Size = new System.Drawing.Size(131, 19);
            this.editedRadioButton1.TabIndex = 5;
            this.editedRadioButton1.TabStop = true;
            this.editedRadioButton1.Text = "editedRadioButton1";
            this.editedRadioButton1.UseVisualStyleBackColor = true;
            // 
            // editedRadioButton2
            // 
            this.editedRadioButton2.AutoSize = true;
            this.editedRadioButton2.Location = new System.Drawing.Point(3, 28);
            this.editedRadioButton2.Name = "editedRadioButton2";
            this.editedRadioButton2.Size = new System.Drawing.Size(131, 19);
            this.editedRadioButton2.TabIndex = 6;
            this.editedRadioButton2.Text = "editedRadioButton2";
            this.editedRadioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 53);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(95, 19);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(3, 78);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(95, 19);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private EditedRadioButton editedRadioButton1;
        private EditedRadioButton editedRadioButton2;
    }
}