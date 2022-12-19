using NUnit.Framework;
using OpenQA.Selenium;

namespace Test;

[TestFixture]
[Parallelizable]
public class Parameterized : Hooks
{
    public Parameterized() : base(BrowserType.Chrome)
    {

    }

    [Test]
    public void ChromeTestLogin()
    {
        Driver.Navigate().GoToUrl("https://react-frontend-fs.ey.r.appspot.com/login");
        Driver.FindElement(By.Name("username")).SendKeys("bruger");
        Driver.FindElement(By.Name("password")).SendKeys("bruger");
        System.Threading.Thread.Sleep(2000);
        Driver.FindElement(By.Name("password")).SendKeys(Keys.Enter);
        System.Threading.Thread.Sleep(2000);
        Assert.That(Driver.PageSource.Contains("Log out"), Is.EqualTo(true),
            "The text Log out does not exist");
    }

    [Test]
    public void ChromeTestPost()
    {
        //Log in
        Driver.Navigate().GoToUrl("https://react-frontend-fs.ey.r.appspot.com/login");
        Driver.FindElement(By.Name("username")).SendKeys("admin");
        Driver.FindElement(By.Name("password")).SendKeys("admin");
        System.Threading.Thread.Sleep(2000);
        Driver.FindElement(By.Name("password")).SendKeys(Keys.Enter);
        System.Threading.Thread.Sleep(2000);
        
        //Post review
        Driver.Navigate().GoToUrl("https://react-frontend-fs.ey.r.appspot.com/review/new");
        Driver.FindElement(By.Name("title")).SendKeys("Test title");
        Driver.FindElement(By.Name("review")).SendKeys("Test review text");
        Driver.FindElement(By.Name("rating")).SendKeys("1");
        Driver.FindElement(By.Name("ratingReasoning")).SendKeys("Rating reasoning");
        Driver.FindElement(By.Name("platform")).SendKeys("PC");
        Driver.FindElement(By.Name("image")).SendKeys("image");
        System.Threading.Thread.Sleep(2000);
        Driver.FindElement(By.ClassName("create-review-btn")).Click();
        System.Threading.Thread.Sleep(1000);
        Driver.SwitchTo().Alert().Accept();
        System.Threading.Thread.Sleep(2000);
        Assert.That(Driver.PageSource.Contains("Test title"), Is.EqualTo(true),
            "The text Test tile does not exist");
    }

    [TestFixture]
    [Parallelizable]
    public class ParameterizedSafari : Hooks
    {
        public ParameterizedSafari() : base(BrowserType.Safari)
        {

        }

        [Test]
        public void SafariTestLogin()
        {
            Driver.Navigate().GoToUrl("https://react-frontend-fs.ey.r.appspot.com/login");
            Driver.FindElement(By.Name("username")).SendKeys("bruger");
            Driver.FindElement(By.Name("password")).SendKeys("bruger");
            System.Threading.Thread.Sleep(2000);
            Driver.FindElement(By.Name("password")).SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(2000);
            Assert.That(Driver.PageSource.Contains("Log out"), Is.EqualTo(true),
                "The text Log out does not exist");
        }

        [Test]
        public void SafariTestPost()
        {
            //Log in
            Driver.Navigate().GoToUrl("https://react-frontend-fs.ey.r.appspot.com/login");
            Driver.FindElement(By.Name("username")).SendKeys("admin");
            Driver.FindElement(By.Name("password")).SendKeys("admin");
            System.Threading.Thread.Sleep(2000);
            Driver.FindElement(By.Name("password")).SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(2000);

            //Post review
            Driver.Navigate().GoToUrl("https://react-frontend-fs.ey.r.appspot.com/review/new");
            Driver.FindElement(By.Name("title")).SendKeys("Safari Test Title");
            Driver.FindElement(By.Name("review")).SendKeys("Test review text");
            Driver.FindElement(By.Name("rating")).SendKeys("1");
            Driver.FindElement(By.Name("ratingReasoning")).SendKeys("Rating reasoning");
            Driver.FindElement(By.Name("platform")).SendKeys("PC");
            Driver.FindElement(By.Name("image")).SendKeys("image");
            System.Threading.Thread.Sleep(2000);
            Driver.FindElement(By.ClassName("create-review-btn")).Click();
            System.Threading.Thread.Sleep(1000);
            Driver.SwitchTo().Alert().Accept();
            System.Threading.Thread.Sleep(2000);
            Assert.That(Driver.PageSource.Contains("Safari Test Title"), Is.EqualTo(true),
                "The text Test tile does not exist");
        }
    }
}