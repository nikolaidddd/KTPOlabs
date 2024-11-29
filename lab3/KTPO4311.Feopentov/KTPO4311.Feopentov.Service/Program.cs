using KTPO4311.Feopentov.Lib.src.LogAn;
using System;


LogAnalyzer logAnalyzer = new LogAnalyzer();

if (logAnalyzer.IsValidLogFileName("someName.gdr"))
{
    Console.WriteLine("Файл someName.gdr с правильным расширением");
}
else
{
    Console.WriteLine("Файл someName.gdr с неправильным расширением");
}

if (logAnalyzer.IsValidLogFileName("someName.dgr"))
{
    Console.WriteLine("Файл someName.dgr с правильным расширением");
}
else
{
    Console.WriteLine("Файл someName.dgr с неправильным расширением");
}