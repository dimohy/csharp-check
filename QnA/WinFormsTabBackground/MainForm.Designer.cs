namespace WinFormsTabBackground
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
            tabControl1 = new TabControl();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabControl2 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabControl1.SuspendLayout();
            tabControl2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(611, 113);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(367, 311);
            tabControl1.TabIndex = 1;
            // 
            // tabPage3
            // 
            tabPage3.BackgroundImage = Properties.Resources.watercolor_g7eac62fd3_1920;
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(359, 283);
            tabPage3.TabIndex = 0;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.BackgroundImage = Properties.Resources.watercolor_g7eac62fd3_1920;
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(359, 283);
            tabPage4.TabIndex = 1;
            tabPage4.Text = "tabPage4";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage1);
            tabControl2.Controls.Add(tabPage2);
            tabControl2.Location = new Point(158, 186);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(366, 281);
            tabControl2.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(358, 253);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(192, 72);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.watercolor_g7eac62fd3_1920;
            ClientSize = new Size(1098, 624);
            Controls.Add(tabControl2);
            Controls.Add(tabControl1);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabControl tabControl2;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}