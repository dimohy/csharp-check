namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void IdTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void passwordsTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}