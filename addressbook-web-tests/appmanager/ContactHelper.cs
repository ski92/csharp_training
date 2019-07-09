﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool IsContactsExist()
        {
            return IsElementPresent(By.XPath("//img[@alt='Edit']"));

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
            List<ContactData> contact_list = new List<ContactData>();
            List<IWebElement> contacts = new List<IWebElement>();

            manager.Navigator.GoToHomePage();

            ICollection<IWebElement> records = driver.FindElements(By.Name("entry"));

            foreach (IWebElement record in records)
            {
                contacts = record.FindElements((By.TagName("td"))).ToList();
                contact_list.Add(new ContactData(contacts[2].Text, contacts[1].Text));
            }
            return contact_list;
        }
    }
}

