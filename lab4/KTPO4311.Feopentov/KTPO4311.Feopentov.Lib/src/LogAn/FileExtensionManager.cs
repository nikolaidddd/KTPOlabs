using System;
using System.Configuration;

namespace KTPO4311.Feopentov.Lib.src.LogAn
{
    public class FileExtensionManager : IExtensionManager
    {
        public bool IsValid(string fileName)
        {

            string configExtension = ConfigurationManager.AppSettings["goodExtension"];
            if (fileName.EndsWith(configExtension))
            {
                return true;
            }
            return false;
        }
    }
}