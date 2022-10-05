using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDataBinding
{
    public class MainViewModel
    {
        public MainModel[] Models { get; } = new MainModel[]
        {
            new() { Name = "Model1" },
            new() { Name = "Model2" },
            new() { Name = "Model3" },
            new() { Name = "Model4" },
            new() { Name = "Model5" },
            new() { Name = "Model6" },
        };
    }
}
