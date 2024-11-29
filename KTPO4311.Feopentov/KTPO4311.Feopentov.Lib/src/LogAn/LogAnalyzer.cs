using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4311.Feopentov.Lib.src.LogAn
{
    public class LogAnalyzer
    {
        public bool WasLastFileNameValid { get; set; }
        public bool IsValidLogFileName(string fileName)
        {
            WasLastFileNameValid = false;

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Имя файла должно быть задано");
            }

            if (!fileName.EndsWith(".SLF", StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }

            WasLastFileNameValid = true;

            return true;
        }
        public bool IsValidLogFileName_GoodExtensionUppercase_ReturnsTrue(string fileName)
        {
            if (fileName.EndsWith(".SLF"))
            {
                return false;
            }
            return true;
        }
        public bool IsValidLogFileName_GoodExtensionLowercase_ReturnsTrue(string fileName)
        {
            if (fileName.EndsWith(".slf", StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }
            return true;
        }
    }
}
