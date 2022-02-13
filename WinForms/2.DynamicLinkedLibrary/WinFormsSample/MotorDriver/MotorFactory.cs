using Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Loader;

namespace MotorDriver
{
    public class MotorFactory
    {
        private Dictionary<string, IMotorPageFactory> motorFactoryMap;

        public MotorFactory(string driverPath)
        {
            Load(driverPath);
        }

        public IMotorPage Create(string driverName, int id)
        {
            var bResult = motorFactoryMap.TryGetValue(driverName, out var motorFactory);
            if (bResult == true)
                return motorFactory.Create(id);

            return null;
        }

        private void Load(string driverPath)
        {
            motorFactoryMap = new();

            var motorDriverDlls = Directory.GetFiles(driverPath, "*.dll");
            foreach (var motorDriverDll in motorDriverDlls)
            {
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(motorDriverDll);
                var factoryType = assembly.GetTypes().Where(x => typeof(IMotorPageFactory).IsAssignableFrom(x) == true).FirstOrDefault();
                if (factoryType == default)
                    continue;

                var factory = Activator.CreateInstance(factoryType) as IMotorPageFactory;
                motorFactoryMap[factory.DriverName] = factory;
            }
        }

        public IEnumerable<string> GetDriverNames() => motorFactoryMap.Keys;
    }
}
