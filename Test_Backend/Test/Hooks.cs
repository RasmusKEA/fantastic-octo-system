using OpenQA.Selenium.Safari;

namespace Test;

using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Reflection;
//Enum for browserType
public enum BrowserType
{
    Chrome,
    Firefox,
    Safari
}


//Fixture for class
[TestFixture]
public class Hooks : Base
{
    private BrowserType _browserType;


    public Hooks(BrowserType browser)
    {
        _browserType = browser;
    }


    [SetUp]
    public void InitializeTest()
    {
        ChooseDriverInstance(_browserType);
    }

    private void ChooseDriverInstance(BrowserType browserType)
    {

        if (browserType == BrowserType.Chrome)
        {
            Driver = new ChromeDriver();
        }else if (browserType == BrowserType.Safari)
        {
            Driver = new SafariDriver();
        }
    }

    [TearDown]
    public void CloseBrowser()
    {
        Driver.Quit();
    }


}
