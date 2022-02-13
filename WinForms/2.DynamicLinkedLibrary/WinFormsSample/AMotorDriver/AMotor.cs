using Driver;

using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMotorDriver
{
    public class AMotor : IMotorPage
    {
        public int Id { get; }

        public UserControl Page { get; }

        public AMotor(int id)
        {
            this.Id = id;
            this.Page = new AMotorPage();
        }
    }

    public class AMotorDriverFactory : IMotorPageFactory
    {
        public string DriverName => "A Motor Driver";

        public IMotorPage Create(int id) => new AMotor(id);
    }
}
