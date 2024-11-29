﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4311.Feopentov.Lib.src.LogAn
{
    public class LogAnalyzer 
    {
        public LogAnalyzer()
        {

        }
        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                try
                {
                    //Передать внешней службе сообщение об ошибке
                    IWebService serv = WebServiceFactory.Create();
                    serv.LogError("Слишком короткое имя файла:" + fileName);
                }
                catch (Exception e)
                {
                    //Отправить сообщение по электронной почте
                    IEmailService es =EmailServiceFactory.Create();
                    es.SendEmail("someone@somewhere.com", "Невозможно вызвать веб-сервис", e.Message);
                }
            }
        }
        public bool IsValidLogFileName(string fileName)

        {
            IExtensionManager mgr = ExtensionManagerFactory.Create();
            return mgr.IsValid(fileName);
        }
    }
}