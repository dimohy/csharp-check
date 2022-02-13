using Driver;

using System;
using System.Threading.Tasks;

namespace BMorterDriver
{
    public class BMotor : IMotor
    {
        public int Id { get; private set; }

        public BMotor(int id)
        {
            this.Id = id;
        }

        public double Position { get; private set; }

        public async Task MoveAsync(double position)
        {
            var sp = this.Position;
            var ep = position;

            for (var i = sp; i <= ep; i++)
            {
                this.Position = i;
                Console.WriteLine($"{i} 퓨웅~");
                await Task.Delay(10);
            }
        }

        public async Task ResetAsync()
        {
            await Task.Yield();
            Position = 0;
        }
    }

    public class BMotorDriverFactory : IMotorDriverFactory
    {
        public string DriverName => "B Motor Driver";

        public IMotor Create(int id) => new BMotor(id);
    }
}
