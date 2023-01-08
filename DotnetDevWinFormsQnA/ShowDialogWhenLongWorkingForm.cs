using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotnetDevWinFormsQnA;

public partial class ShowDialogWhenLongWorkingForm : Form
{
    public ShowDialogWhenLongWorkingForm()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var waitForm = new WaitForm();
        new Thread(() =>
        {
            BeginInvoke(() => waitForm.ShowDialog());
            // 오래 걸리는 작업 시뮬레이션
            Thread.Sleep(5000);
            BeginInvoke(() => waitForm.Close());
        }).Start();
    }
}
