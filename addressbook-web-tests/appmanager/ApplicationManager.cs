using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;

        public ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:8081/addressbook";
            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

        public void stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigator;
            }
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }

        public ContactHelper Contacts
        {
            get
            {
                return contactHelper;
            }
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
    }
}