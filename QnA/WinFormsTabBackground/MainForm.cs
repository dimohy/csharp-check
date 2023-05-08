namespace WinFormsTabBackground
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            tabControl2.Appearance = TabAppearance.FlatButtons;
            tabControl2.SizeMode = TabSizeMode.Fixed;
            tabControl2.ItemSize = new Size(0, 1);
        }
    }
}