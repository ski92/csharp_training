using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string email_1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email_2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email_3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(firstname, lastname)
            {
                Address = address,
                Email_1 = email_1,
                Email_2 = email_2,
                Email_3 = email_3,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone
            };
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            SelectGroupToRemove(group.Id);
            SelectContact(contact.Id);
            CommitDeleteContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void CommitDeleteContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        private void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        private void SelectGroupToRemove(string id)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByValue(id);
        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public ContactData GetContactInformationFromCard(int index)
        {
            manager.Navigator.GoToHomePage();
            OpenContactCard(index);
            string allData = driver.FindElement(By.Id("content")).Text;
            return new ContactData(allData);
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastname = cells[1].Text;
            string firstname = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstname, lastname)
            {
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones
            };
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

        public ContactHelper ModifyContact(ContactData contact, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(contact.Id);
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

        public ContactHelper Remove(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(contact.Id);
            RemoveContact();
            driver.SwitchTo().Alert().Accept();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification(int i)
        {
            driver.FindElements(By.Name("entry"))[i]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            return this;
        }
        public ContactHelper InitContactModification(string id)
        {
            driver.FindElement(By.XPath("//a[@href='edit.php?id="
               + id + "']")).Click();
            return this;
        }

        public ContactHelper OpenContactCard(int i)
        {
            driver.FindElements(By.Name("entry"))[i]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public bool IsContactsExist()
        {
            return IsElementPresent(By.XPath("//img[@alt='Edit']"));

        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int i)
        {
            driver.FindElement(By.XPath("//tr/td/input[@name='selected[]' and @id='" + i + "']")).Click();
            return this;
        }

        public ContactHelper SelectContact(String id)
        {
            driver.FindElement(By.Id(id)).Click();
            return this;
        }

        public String GetContactId()
        {
            manager.Navigator.GoToHomePage();
            return driver.FindElements(By.XPath("//tr/td/input[@name='selected[]']")).Last().GetAttribute("value");
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
            contactCache = null;
            return this;
        }
        public int GetContactCount()
        {
            return driver.FindElements(By.CssSelector("td")).Count;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactsLists()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();

                List<IWebElement> contacts = new List<IWebElement>();

                ICollection<IWebElement> records = driver.FindElements(By.Name("entry"));

                foreach (IWebElement record in records)
                {
                    contacts = record.FindElements((By.TagName("td"))).ToList();
                    contactCache.Add(new ContactData(contacts[2].Text, contacts[1].Text)
                    {
                        Id = record.FindElement(By.Name("selected[]")).GetAttribute("id")
                    });
                }
            }
            return new List<ContactData>(contactCache);
        }
    }
}


