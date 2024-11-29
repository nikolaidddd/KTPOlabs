using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4311.Feopentov.Lib.src.LogAn
{
    public static class EmailServiceFactory
    {
        private static IEmailService customEmail = null;
        ///<summary>Создание объектов</summary>
        public static IEmailService Create()
        {
            if (customEmail != null)
            {
                return customEmail;
            }
            return new EmailService();
        }
        ///<summary>Метод позволяет контролировать, 
        ///что возвращает фабрика</summary>
        public static void SetEmail(IEmailService str)
        {
            customEmail = str;
        }
    }
}
