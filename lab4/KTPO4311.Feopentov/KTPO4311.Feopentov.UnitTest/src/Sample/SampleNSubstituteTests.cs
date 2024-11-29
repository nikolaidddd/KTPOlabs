using KTPO4311.Feopentov.Lib.src.LogAn;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4311.Feopentov.UnitTest.src.Sample
{
    class SampleNSubstituteTests
    {
        [Test]
        public void Returns_ParticularArg_Works()
        {
            //Создать поддельный объект
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();

            //Настроить объект, чтобы метод возвращал true для заданного значения входного параметра
            fakeExtensionManager.IsValid("validfile.ext").Returns(true);

            //Воздействие на тестируемый объект
            bool result = fakeExtensionManager.IsValid("validfile.ext");

            //Проверка ожидаемого результата
            Assert.IsTrue(result);
        }
        [Test]
        public void Returns_ArgAny_Works()
        {
            //Создать поддельный оюъект
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();

            //Настроить объект, чтобы метод возвращал true независимо от параметров
            fakeExtensionManager.IsValid(Arg.Any<string>()).Returns(true);

            //Воздействие на тестируемый объект
            bool result = fakeExtensionManager.IsValid("anyfile.ext");

            //Проверка ожидаемого результата
            Assert.True(result);
        }

        [Test]
        public void Returns_ArgAny_Throws()
        {
            //Создать поддельный объект
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();

            //Настроить объект, чтобы методв ызвал исключение, независимо от входных аргументов
            fakeExtensionManager.When(x => x.IsValid(Arg.Any<string>()))
                .Do(context => { throw new Exception("fake exception"); });

            //Проверка, что было вызвано исключение
            Assert.Throws<Exception>(() => fakeExtensionManager.IsValid("anything"));
        }

        [Test]
        public void Received_ParticularArg_Saves()
        {
            //Создать поддельный объект
            IWebService mockWebService = Substitute.For<IWebService>();

            //Воздействие на поддельный объект
            mockWebService.LogError("Поддельное сообщение");

            //Проверка, что поддельный объект сохранил параметры вызова
            mockWebService.Received().LogError("Поддельное сообщение");
        }
    }
}
