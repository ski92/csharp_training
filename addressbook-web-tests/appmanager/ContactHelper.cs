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
            InitContactModification(i + 2);
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
            driver.FindElement(By.XPath("//tr[" + (i + 2) + "]/td/input[@name='selected[]'] ")).Click();
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
        public List<ContactData> GetContactsLists()
        {
            manager.Navigator.GoToHomePage();
            List<ContactData> names_list = new List<ContactData>();

            ICollection<IWebElement> lastnames = driver.FindElements(By.XPath("//tr[@name='entry']/td[2]"));

            string[] lastnames_list = new string[lastnames.Count];
            int index = 0;

            foreach (IWebElement lastname in lastnames)
            {
                lastnames_list[index] = lastname.Text;
                index++;
            }

            ICollection<IWebElement> firstnames = driver.FindElements(By.XPath("//tr[@name='entry']/td[3]"));

            for (int i = 0; i < lastnames_list.Length; i++)

                foreach (IWebElement firstname in firstnames)
                {
                    names_list.Add(new ContactData(firstname.Text, lastnames_list[i]));
                }
            return names_list;
        }
    }
}
