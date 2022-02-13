using Driver;

using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMotorDriver
{
    public class BMotor : IMotorPage
    {
        public int Id { get; }

        public UserControl Page { get; }

        public BMotor(int id)
        {
            this.Id = id;
            this.Page = new BMotorPage();
        }
    }

    public class BMotorDriverFactory : IMotorPageFactory
    {
        public string DriverName => "B Motor Driver";

        public IMotorPage Create(int id) => new BMotor(id);
    }
}
