using KTPO4311.Feopentov.Lib.src.LogAn;
using NSubstitute;
using NUnit.Framework;
using System;

namespace KTPO4311.Feopentov.UnitTest.src.LogAn
{
    class LogAnalyzerNSubstituteTests
    {
        [Test]
        public void IsValidFileName_NameSupportedExtendion_ReturnsTrue()
        {
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();

            fakeExtensionManager.IsValid("filename.txt").Returns(true);

            ExtensionManagerFactory.SetManager(fakeExtensionManager);

            LogAnalyzer log = new LogAnalyzer();
            bool result = log.IsValidLogFileName("filename.txt");
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidFileName_NoneSupportedExtendion_ReturnsFalse()
        {
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();

            fakeExtensionManager.IsValid("filename.txt").Returns(true);

            ExtensionManagerFactory.SetManager(fakeExtensionManager);

            LogAnalyzer log = new LogAnalyzer();
            bool result = log.IsValidLogFileName("short.ext");
            Assert.IsFalse(result);
        }
        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();


            ExtensionManagerFactory.SetManager(fakeExtensionManager);

            LogAnalyzer log = new LogAnalyzer();

            Assert.IsFalse(log.IsValidLogFileName("anything.txt"));
        }


        [Test]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            //Подготовка теста
            IWebService mockWebService = Substitute.For<IWebService>();
            WebServiceFactory.SetWebService(mockWebService);
            LogAnalyzer log = new LogAnalyzer();
            string tooShortFileName = "abc.ext";

            //Воздействие на тестируемый объект
            log.Analyze(tooShortFileName);

            //Проверка, что поддельный объект сохранил параметры вызова
            mockWebService.Received().LogError("Слишком короткое имя файла:abc.ext");
        }

        [Test]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            //Подготовка теста
            IWebService mockWebService = Substitute.For<IWebService>();
            WebServiceFactory.SetWebService(mockWebService);
            mockWebService.When(x => x.LogError(Arg.Any<string>()))
                .Do(context => { throw new Exception("Это подделка"); });

            IEmailService mockEmail = Substitute.For<IEmailService>();
            EmailServiceFactory.SetEmail(mockEmail);

            LogAnalyzer log = new LogAnalyzer();
            string tooShortFileName = "abc.ext";

            //Воздействие на тестируемый объект
            log.Analyze(tooShortFileName);

            //Проверка ожидаемого реультата
            //...Здесь тест будет ложным, если неверно хотя бы одно утверждение
            //...Поэтому здесь допустимо несколько утверждений
            mockEmail.Received().SendEmail("someone@somewhere.com", "Невозможно вызвать веб-сервис", "Это подделка");

        }
    }
}
