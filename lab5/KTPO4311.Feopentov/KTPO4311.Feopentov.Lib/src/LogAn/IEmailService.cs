using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4311.Feopentov.Lib.src.LogAn
{
    public interface IEmailService
    {
        public void SendEmail(string to, string subject, string body);
    }
}
