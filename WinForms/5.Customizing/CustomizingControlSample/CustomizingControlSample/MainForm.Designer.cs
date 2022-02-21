
namespace CustomizingControlSample
{
    partial class MainForm
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
            this.customControl11 = new CustomizingControlSample.CustomControl1();
            this.customControl12 = new CustomizingControlSample.CustomControl1();
            this.customControl13 = new CustomizingControlSample.CustomControl1();
            this.userControl12 = new CustomizingControlSample.UserControl1();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // customControl11
            // 
            this.customControl11.BackColor = System.Drawing.Color.Blue;
            this.customControl11.Location = new System.Drawing.Point(75, 43);
            this.customControl11.Name = "customControl11";
            this.customControl11.Size = new System.Drawing.Size(194, 105);
            this.customControl11.TabIndex = 1;
            this.customControl11.Text = "customControl11";
            // 
            // customControl12
            // 
            this.customControl12.BackColor = System.Drawing.Color.Blue;
            this.customControl12.Location = new System.Drawing.Point(327, 43);
            this.customControl12.Name = "customControl12";
            this.customControl12.Size = new System.Drawing.Size(194, 105);
            this.customControl12.TabIndex = 1;
            this.customControl12.Text = "customControl11";
            // 
            // customControl13
            // 
            this.customControl13.BackColor = System.Drawing.Color.Blue;
            this.customControl13.Location = new System.Drawing.Point(567, 43);
            this.customControl13.Name = "customControl13";
            this.customControl13.Size = new System.Drawing.Size(194, 105);
            this.customControl13.TabIndex = 2;
            this.customControl13.Text = "customControl11";
            // 
            // userControl12
            // 
            this.userControl12.Location = new System.Drawing.Point(117, 154);
            this.userControl12.Name = "userControl12";
            this.userControl12.Size = new System.Drawing.Size(566, 329);
            this.userControl12.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 460);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.customControl13);
            this.Controls.Add(this.customControl12);
            this.Controls.Add(this.customControl11);
            this.Controls.Add(this.userControl12);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private CustomControl1 customControl11;
        private CustomControl1 customControl12;
        private CustomControl1 customControl13;
        private UserControl1 userControl12;
        private System.Windows.Forms.Button button1;
    }
}

