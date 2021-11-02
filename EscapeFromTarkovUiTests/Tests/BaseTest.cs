using EscapeFromTarkovUiTests.Common;
using EscapeFromTarkovUiTests.PageObjects.ExternalPages;
using EscapeFromTarkovUiTests.PageObjects.HomePage;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace EscapeFromTarkovUiTests.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver driver { get; set; }
        public static IConfiguration TestConfiguration { get; } = new ConfigurationBuilder().AddJsonFile("testrunsettings.json").Build();
        protected static Home Home { get; set; }
        protected static ExternalPages ExternalPages { get; set; }

        [SetUp]
        public void StartDriver()
        {
            DriverInitialization driverInitialization = new DriverInitialization();
            driver = driverInitialization.InitializeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(GlobalRunSettings.StartUrl);
            Home = new Home(driver);
            ExternalPages = new ExternalPages(driver);
        }

        [OneTimeSetUp]
        public static void InitializeAssembly()
        {
            InitializeRunSettings();
        }

        private static void InitializeRunSettings()
        {
            GlobalRunSettings.StartUrl = TestConfiguration["Settings:StartUrl"];
            GlobalRunSettings.BrowserName = (BrowserName)Enum.Parse(typeof(BrowserName), TestConfiguration["Settings:BrowserName"]);
            GlobalRunSettings.TimeoutSeconds = int.Parse(TestConfiguration["Settings:TimeoutSeconds"]);
        }

        [TearDown]
        public void QuitDriver()
        {
            driver?.Quit();
        }
    }
}
