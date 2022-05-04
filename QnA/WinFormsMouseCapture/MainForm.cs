namespace WinFormsMouseCapture
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            colorPickerControl.CursorColorChanged += ColorPickerControl_CursorColorChanged;
        }

        private void ColorPickerControl_CursorColorChanged(object? sender, EventArgs e)
        {
            colorPanel.BackColor = colorPickerControl.CursorColor;
        }

        private void startColorPickButton_Click(object sender, EventArgs e)
        {
            colorPickerControl.Start();
        }
    }
}