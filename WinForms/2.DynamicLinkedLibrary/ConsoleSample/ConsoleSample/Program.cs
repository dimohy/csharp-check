using System;
using System.IO;
using System.Reflection;
using MotorDriver;


var driverPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Driver");
var motorDriverFactory = new MotorFactory(driverPath);

// 총 두개의 모터 드라이버 검색 됨
foreach (var driverName in motorDriverFactory.GetDriverNames())
    Console.WriteLine(driverName);

// 각각의 모터 드라이버에서 모터 생성
var motor1 = motorDriverFactory.Create("A Motor Driver", 1);
var motor2 = motorDriverFactory.Create("B Motor Driver", 2);

// 모터 이동
await motor1.MoveAsync(20);
await motor2.MoveAsync(20);
