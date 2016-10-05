using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SeleniumApp.Tests
{
    [TestClass]
    public class TestEtudiant
    {


        private static IWebDriver _driverChrome;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;


        [ClassInitialize]
        public static void Init(TestContext context)
        {
            _driverChrome = new ChromeDriver();


        }


        [TestMethod]
         public void TestAjoutEtudiant()
        {

            _driverChrome.Navigate().GoToUrl("http://localhost:64446/");

            
            _driverChrome.FindElement(By.LinkText("Nouvel Etudiant")).Click();
            _driverChrome.FindElement(By.Id("Nom")).SendKeys("Jean");
            _driverChrome.FindElement(By.Id("Prenom")).SendKeys("Bernard");
            _driverChrome.FindElement(By.Id("Email")).SendKeys("j.bernard@gmail.com");
            _driverChrome.FindElement(By.XPath("//input[@value='Homme']")).Click();
            IJavaScriptExecutor js = _driverChrome as IJavaScriptExecutor;
           js.ExecuteScript("document.getElementById('DateNais').value='1992-03-02'");

            _driverChrome.FindElement(By.Id("Enregistrer")).Submit();


           Assert.IsTrue(VerifElement("j.bernard@gmail.com"));
        

        }


        [TestMethod]
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;dbq=|DataDirectory|\\data.xlsx;defaultdir=.; driverid=790;maxbuffersize=2048;pagetimeout=5", "Feuil1$", DataAccessMethod.Sequential), DeploymentItem("data.xlsx")]
        public void TestAjoutEtudiantDDT()
        {

            _driverChrome.Navigate().GoToUrl("http://localhost:64446/");


            _driverChrome.FindElement(By.LinkText("Nouvel Etudiant")).Click();
            _driverChrome.FindElement(By.Id("Nom")).SendKeys(TestContext.DataRow["Nom"].ToString());
            _driverChrome.FindElement(By.Id("Prenom")).SendKeys(TestContext.DataRow["Prenom"].ToString());
            _driverChrome.FindElement(By.Id("Email")).SendKeys(TestContext.DataRow["Email"].ToString());
            _driverChrome.FindElement(By.XPath("//input[@value='"+ TestContext.DataRow["Sexe"].ToString() + "']")).Click();

            IJavaScriptExecutor js = _driverChrome as IJavaScriptExecutor;
            js.ExecuteScript("document.getElementById('DateNais').value='" + Convert.ToDateTime(TestContext.DataRow["DateNais"]).ToShortDateString() + "'");

            _driverChrome.FindElement(By.Id("Enregistrer")).Submit();

            Assert.IsTrue(VerifElement(TestContext.DataRow["Email"].ToString()));
        }


       


        public Boolean VerifElement(string valueToFind)
        {
            try
            {
                _driverChrome.FindElement(By.LinkText(valueToFind));
                return true;
            }
            catch (NoSuchElementException e)
            {
                CaptureEcran("echec_ajoutetudiant");
                return false;
            }
        }


        public void CaptureEcran(string fileName)
        {

            Screenshot ss = ((ITakesScreenshot)_driverChrome).GetScreenshot();
            ss.SaveAsFile(fileName+"_"+ DateTime.Now.ToString("yyyy-mm-dd-HHmmss")+".png", ImageFormat.Png);

        }


        [ClassCleanup]
        public static void Cleanup()
        {
            if (_driverChrome != null)
                _driverChrome.Quit();
        }



    }
}
