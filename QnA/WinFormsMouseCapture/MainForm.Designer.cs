namespace WinFormsMouseCapture
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
            this.colorPickerControl = new WinFormsMouseCapture.ColorPickerControl();
            this.startColorPickButton = new System.Windows.Forms.Button();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // colorPickerControl
            // 
            this.colorPickerControl.BackColor = System.Drawing.Color.LightGray;
            this.colorPickerControl.Location = new System.Drawing.Point(12, 12);
            this.colorPickerControl.Name = "colorPickerControl";
            this.colorPickerControl.Size = new System.Drawing.Size(100, 100);
            this.colorPickerControl.TabIndex = 0;
            this.colorPickerControl.Text = "colorPickerControl1";
            // 
            // startColorPickButton
            // 
            this.startColorPickButton.Location = new System.Drawing.Point(12, 118);
            this.startColorPickButton.Name = "startColorPickButton";
            this.startColorPickButton.Size = new System.Drawing.Size(100, 23);
            this.startColorPickButton.TabIndex = 1;
            this.startColorPickButton.Text = "Start";
            this.startColorPickButton.UseVisualStyleBackColor = true;
            this.startColorPickButton.Click += new System.EventHandler(this.startColorPickButton_Click);
            // 
            // colorPanel
            // 
            this.colorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorPanel.Location = new System.Drawing.Point(118, 12);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(99, 100);
            this.colorPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 156);
            this.Controls.Add(this.colorPanel);
            this.Controls.Add(this.startColorPickButton);
            this.Controls.Add(this.colorPickerControl);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ColorPickerControl colorPickerControl;
        private Button startColorPickButton;
        private Panel colorPanel;
    }
}