namespace WinFormDisplay
{
    public partial class Form1 : Form
    {
        private List<Label>[] _labels;

        public Form1()
        {
            InitializeComponent();

            _labels = new List<Label>[]
            {
                new() { label1, label2, label3, label4 },
                new() { label5, label6, label7, label8 }
            };
        }
    }
}