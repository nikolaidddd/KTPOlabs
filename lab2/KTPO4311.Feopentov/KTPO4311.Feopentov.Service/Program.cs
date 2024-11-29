using KTPO4311.Feopentov.Lib.src.LogAn;
using System;


LogAnalyzer logAnalyzer = new LogAnalyzer();

if (logAnalyzer.IsValidLogFileName("someName.ext"))
{
    Console.WriteLine("Файл someName.ext с правильным расширением");
}
else
{
    Console.WriteLine("Файл someName.ext с неправильным расширением");
}

if (logAnalyzer.IsValidLogFileName("someName.txt"))
{
    Console.WriteLine("Файл someName.txt с правильным расширением");
}
else
{
    Console.WriteLine("Файл someName.txt с неправильным расширением");
}
if (logAnalyzer.IsValidLogFileName(""))
{
    Console.WriteLine("Файл someName.txt с правильным расширением");
}
else
{
    Console.WriteLine("Файл someName.txt с неправильным расширением");
}