using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            comboBox1.SelectedIndex = GetCultureIndex(Thread.CurrentThread.CurrentUICulture.Name);
        }

        private static string GetCultureName(int index) => index switch { 0 => "ko-KR", 1 => "en-US", _ => "ko-KR" };
        private static int GetCultureIndex(string name) => name switch { "ko-KR" => 0, "en-US" => 1, _ => 0 };

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = GetCultureName(comboBox1.SelectedIndex);
            Properties.Settings.Default.Locale = name;
            Properties.Settings.Default.Save();

            var cultureInfo = new CultureInfo(name);

            if (Thread.CurrentThread.CurrentUICulture.Name != cultureInfo.Name)
                Application.Restart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Resource1.QuestionContent, Resource1.QuestionTitle, MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}
