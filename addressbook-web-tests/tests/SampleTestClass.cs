using OpenQA.Selenium;

namespace addressbook_web_tests.tests
{
    public class SampleTestClass
    {
        public void SampleFor()
        {
            string[] s = new string[] { "I", "want", "to", "sleep" };

            for (int i = 0; i < s.Length; i++)
            {
                System.Console.Out.Write(s[i] + "\n");
            }
        }

        public void SampleForEach()
        {
            string[] s = new string[] { "I", "want", "to", "sleep" };

            foreach (string element in s)
            {
                System.Console.Out.Write(element + "\n");
            }
        }

        public void SampleWhile()
        {
            IWebDriver driver = null;
            int attempt = 0;

            while (driver.FindElements(By.Id("test")).Count == 0 && attempt < 60)
            {
                System.Threading.Thread.Sleep(1000);
                attempt++;
            }
        }

        public void SampleDoWhile()
        {
            IWebDriver driver = null;
            int attempt = 0;
            do
            {
                System.Threading.Thread.Sleep(1000);
                attempt++;
            }
            while (driver.FindElements(By.Id("test")).Count == 0 && attempt < 60);
        }
    }
}

