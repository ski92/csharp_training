using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.XPath("//a[contains(text(),'home page')]")).Click();
            return this;
        }
        public ContactHelper Create(ContactData contact)
        {
            GoToAddNewPage();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Modify(int i, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(i);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper RemoveContact(int i)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(i);
            RemoveContact();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int i)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + i + "]/td[8]/a/img")).Click();
            return this;
        }

        public void CreateIfTableIsEmpty(ContactData contact)
        {
            if (!IsElementPresent(By.XPath("//img[@alt='Edit']")))
            {
                Create(contact);
            }
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }


        public ContactHelper SelectContact(int i)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + i + "]")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            return this;
        }

        public ContactHelper GoToAddNewPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public List<ContactData> GetContactNamesLists()
        {
            manager.Navigator.GoToHomePage();

            List<ContactData> firstnames_list = new List<ContactData>();

            manager.Navigator.GoToGroupsPage();

            ICollection<IWebElement> firstnames = driver.FindElements(By.XPath("//tr[@name='entry']/td[2]"));

            foreach (IWebElement firstname in firstnames)
            {
                firstnames_list.Add(new ContactData(firstname.Text));

            }
            return firstnames_list;
        }

        public List<ContactData> GetContactLastnamesLists()
        {
            manager.Navigator.GoToHomePage();

            List<ContactData> lastnames_list = new List<ContactData>();
            manager.Navigator.GoToGroupsPage();

            ICollection<IWebElement> lastnames = driver.FindElements(By.XPath("//tr[@name='entry']/td[3]"));

            foreach (IWebElement lastname in lastnames)
            {
                lastnames_list.Add(new ContactData(lastname.Text));

            }
            return lastnames_list;
        }
    }
}
