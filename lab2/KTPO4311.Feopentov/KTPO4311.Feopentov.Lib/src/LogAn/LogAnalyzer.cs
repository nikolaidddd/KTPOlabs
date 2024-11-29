using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4311.Feopentov.Lib.src.LogAn
{
    public class LogAnalyzer
    {
        public IExtensionManager _iem;
        public LogAnalyzer(IExtensionManager iem)
        {
            _iem = iem; 
        }
        public bool IsValidLogFileName(string fileName)

        {
            IExtensionManager mgr = ExtensionManagerFactory.Create();

            try { _iem.IsValid(fileName); }

            catch (System.Exception e )
            {
                return false;
            }

            return true;

        }
    }
}