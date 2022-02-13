using MotorDriver;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsSample
{
    public partial class Form1 : Form
    {
        private MotorFactory factory;

        public Form1()
        {
            InitializeComponent();

            var driverPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Driver");
            factory = new MotorFactory(driverPath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var driverNames = factory.GetDriverNames();

            var motor1Page = factory.Create(driverNames.First(), 1);
            var motor2Page = factory.Create(driverNames.Last(), 2);

            motor1Page.Page.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(motor1Page.Page);
            motor2Page.Page.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(motor2Page.Page);
        }
    }
}
