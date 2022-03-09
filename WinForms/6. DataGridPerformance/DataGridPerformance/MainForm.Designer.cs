namespace DataGridPerformance
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.startSimulationButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.intervalNumberic = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.callCountNumeric = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.itemsGridView = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalNumberic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.callCountNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.startSimulationButton);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.intervalNumberic);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.callCountNumeric);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(825, 36);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // startSimulationButton
            // 
            this.startSimulationButton.Location = new System.Drawing.Point(6, 6);
            this.startSimulationButton.Name = "startSimulationButton";
            this.startSimulationButton.Size = new System.Drawing.Size(75, 23);
            this.startSimulationButton.TabIndex = 0;
            this.startSimulationButton.Text = "시작";
            this.startSimulationButton.UseVisualStyleBackColor = true;
            this.startSimulationButton.Click += new System.EventHandler(this.startSimulationButton_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(87, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 23);
            this.label3.TabIndex = 6;
            // 
            // intervalNumberic
            // 
            this.intervalNumberic.Location = new System.Drawing.Point(249, 6);
            this.intervalNumberic.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.intervalNumberic.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.intervalNumberic.Name = "intervalNumberic";
            this.intervalNumberic.Size = new System.Drawing.Size(64, 23);
            this.intervalNumberic.TabIndex = 1;
            this.intervalNumberic.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(319, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "ms 간격";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // callCountNumeric
            // 
            this.callCountNumeric.Location = new System.Drawing.Point(377, 6);
            this.callCountNumeric.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.callCountNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.callCountNumeric.Name = "callCountNumeric";
            this.callCountNumeric.Size = new System.Drawing.Size(64, 23);
            this.callCountNumeric.TabIndex = 3;
            this.callCountNumeric.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(447, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "개 발생";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // itemsGridView
            // 
            this.itemsGridView.AllowUserToAddRows = false;
            this.itemsGridView.AllowUserToDeleteRows = false;
            this.itemsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsGridView.Location = new System.Drawing.Point(0, 36);
            this.itemsGridView.Name = "itemsGridView";
            this.itemsGridView.ReadOnly = true;
            this.itemsGridView.RowHeadersWidth = 16;
            this.itemsGridView.RowTemplate.Height = 25;
            this.itemsGridView.Size = new System.Drawing.Size(825, 392);
            this.itemsGridView.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(825, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 450);
            this.Controls.Add(this.itemsGridView);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "실시간 시세 표시 (시뮬레이션)";
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.intervalNumberic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.callCountNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Button startSimulationButton;
        private NumericUpDown intervalNumberic;
        private DataGridView itemsGridView;
        private StatusStrip statusStrip1;
        private Label label3;
        private Label label1;
        private NumericUpDown callCountNumeric;
        private Label label2;
    }
}