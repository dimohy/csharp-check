using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomizingControlSample
{
    public partial class CustomForm : Form
    {
        public override string Text
        {
            get => titleLabel?.Text ?? "";
            set => titleLabel.Text = value;
        }

        public CustomForm()
        {
            InitializeComponent();
        }
    }
}
