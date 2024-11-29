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
    {/*
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
        */
        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = false;

            fakeManager.WillThrow = new Exception();
            
            LogAnalyzer log = new LogAnalyzer(fakeManager);

            bool result = log.IsValidLogFileName("short.txt");

            Assert.False(result);
        }

        [TearDown]

        public void AfterEachTest()
        {
            ExtensionManagerFactory.SetManager(null);
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
}