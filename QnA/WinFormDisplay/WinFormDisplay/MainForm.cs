namespace WinFormDisplay
{
    public partial class MainForm : Form
    {
        private List<Label>[] _labels;

        public MainForm()
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