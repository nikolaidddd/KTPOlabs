using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using KTPO4311.Feopentov.Lib.src.LogAn;
using NUnit.Framework;

namespace KTPO4311.Feopentov.UnitTest.src.LogAn
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidFileName_NameSupportedExtendion_ReturnsTrue()
        {
            FakeExtensionManager fakeManager= new FakeExtensionManager();
            fakeManager.WillBeValid = true;

            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer log = new LogAnalyzer();
            bool result = log.IsValidLogFileName("short.ext");
            Assert.True(result);
        }

        [Test]
        public void IsValidFileName_NameSupportedExtendion_ReturnsFalse()
        {
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = false;

            ExtensionManagerFactory.SetManager(fakeManager);
            LogAnalyzer log = new LogAnalyzer();

            bool result = log.IsValidLogFileName("short.ext");
            Assert.False(result);
        }
        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillThrow = new Exception();
            ExtensionManagerFactory.SetManager(fakeManager);
            LogAnalyzer log = new LogAnalyzer();
            Assert.Throws<Exception>(() => log.IsValidLogFileName(""));
        }

        [Test]

        public void Analyze_TooShortFileName_CallsWebService()
        {
            //Подготовка теста
            FakeWebService mockWebService = new FakeWebService();
            WebServiceFactory.SetWebService(mockWebService);
            LogAnalyzer log = new LogAnalyzer();
            string tooShortFileName = "abc.ext";

            //Воздействие на тестируемый объект
            log.Analyze(tooShortFileName);

            //Проверка ожидаемого результата
            StringAssert.Contains("Слишком короткое имя файла:abc.ext",
                mockWebService.LastError);
        }

        [Test]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            //Подготовка теста
            FakeWebService stubWebService = new FakeWebService();
            WebServiceFactory.SetWebService(stubWebService);
            stubWebService.WillThrow = new Exception("Это подделка");

            FakeEmailService mockEmail = new FakeEmailService();
            EmailServiceFactory.SetEmail(mockEmail);

            LogAnalyzer log = new LogAnalyzer();
            string tooShortFileName = "abc.ext";

            //Воздействие на тестируемый объект
            log.Analyze(tooShortFileName);

            //Проверка ожидаемого реультата
            //...Здесь тест будет ложным, если неверно хотя бы одно утверждение
            //...Поэтому здесь допустимо несколько утверждений
            StringAssert.Contains("someone@somewhere.com", mockEmail.to);
            StringAssert.Contains("Это подделка", mockEmail.body);
            StringAssert.Contains("Невозможно вызвать веб-сервис", mockEmail.subject);

        }
        
        [TearDown]

        public void AfterEachTest()
        {
            ExtensionManagerFactory.SetManager(null);
            WebServiceFactory.SetWebService(null);
            EmailServiceFactory.SetEmail(null);
        }
        
     }
    internal class FakeExtensionManager : IExtensionManager
    {
        public bool WillBeValid = false;

        public Exception WillThrow = null;

        public bool IsValid(string fileName)
        {
            if (WillThrow != null)
            {
                throw WillThrow;
            }
        
            return WillBeValid;

        }
    }

    internal class FakeWebService : IWebService
    {
        public string LastError;
        public Exception WillThrow = null;
        public void LogError(string message)
        {

            if(WillThrow != null)
            {
                throw WillThrow;
            }

            LastError= message;
        }
    }

    internal class FakeEmailService : IEmailService
    {
        ///<summary> Это поле запоминает состояние после вызова метода SendMail
        ///при тестировании взаимодействия утверждения высказывается относительно</summary>
        public string to, subject, body;

        public void SendEmail(string to, string subject, string body)
        {
            this.to = to;
            this.subject = subject;
            this.body = body;
        }
    }
}