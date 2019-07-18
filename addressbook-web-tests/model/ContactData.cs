using System;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private String allPhones;
        private String allEmails;
        private String allData;
        public ContactData(string firstname)
        {
            Firstname = firstname;
        }

        public ContactData
            (string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public string Email_1 { get; set; }
        public string Email_2 { get; set; }
        public string Email_3 { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (ClenupPhone(HomePhone) + ClenupPhone(MobilePhone) + ClenupPhone(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (ClenupEmail(Email_1) + ClenupEmail(Email_2) + ClenupEmail(Email_3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string AllData
        {
            get
            {
                if (allData != null)
                {
                    return allData;
                }
                else
                {
                    string s1 = "";
                    string s2 = "";
                    string s3 = "";
                    string s4 = "";
                    if (Lastname != "")
                    {
                        s1 = " ";
                    }
                    if (Address != "")
                    {
                        s2 = "\r\n";
                    }
                    if (AllPhones != "")
                    {
                        s3 = "\r\n\r\n";
                    }
                    if (HomePhone != "")
                    {
                        HomePhone = "H: " + $"{HomePhone}";
                    }
                    if (MobilePhone != "" && HomePhone != "")
                    {
                        MobilePhone = "\r\nM: " + $"{MobilePhone}";
                    }
                    if ((WorkPhone != "" && MobilePhone != "")
                        || (WorkPhone != "" && HomePhone != ""))
                    {
                        WorkPhone = "\r\nW: " + $"{WorkPhone}";
                    }
                    if (AllEmails != "")
                    {
                        s4 = "\r\n\r\n";
                    }
                    if (Email_2 != "" && Email_1 != "")
                    {
                        Email_2 = "\r\n" + $"{Email_2}";
                    }
                    if ((Email_3 != "" && Email_2 != "")
                        || (Email_3 != "" && Email_1 != ""))
                    {
                        Email_3 = "\r\n" + $"{Email_3}";
                    }
                    return Firstname + s1 + Lastname + s2 + Address + s3
                       + HomePhone + MobilePhone + WorkPhone + s4 + Email_1 + Email_2 + Email_3;
                }
            }
            set
            {
                allData = value;
            }
        }
        private string ClenupPhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        private string ClenupEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email.Replace(" ", "") + "\r\n";
        }

        public string Id { get; set; }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname
                && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode();
        }

        public override string ToString()
        {
            return "firstname = " + Firstname + ", " + "lastname = " + Lastname;
        }

        public int CompareTo(ContactData other)
        {
            int result;
            if (Object.ReferenceEquals(other, null))
            {
                result = 1;
            }
            result = Lastname.CompareTo(other.Lastname);
            if (result == 0)
            {
                result = Firstname.CompareTo(other.Firstname);
            }
            return result;
        }
    }
}
