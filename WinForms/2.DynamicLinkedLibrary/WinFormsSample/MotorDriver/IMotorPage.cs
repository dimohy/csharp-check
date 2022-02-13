using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driver
{
    /// <summary>
    /// IMotorPage 인스턴스를 생성하는 팩토리 인터페이스
    /// </summary>
    public interface IMotorPageFactory
    {
        string DriverName { get; }

        IMotorPage Create(int id);
    }

    /// <summary>
    /// MotorDriver 인터페이스
    /// </summary>
    public interface IMotorPage
    {
        int Id { get; }

        UserControl Page { get; }
    }
}
