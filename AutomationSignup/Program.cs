using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace AutomationSignup
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();



            try
            {
                //Launch google developers webpage

                driver.Url = "https://developers.google.com/";
                Console.WriteLine("Opened Chrome Browser to https://developers.google.com/...");


                // Confirm text description for Google Cloud Next '18

                string googleCloudNextDescr = "Hone your skills on the latest cloud technologies with Google experts at hundreds of breakout sessions and interactive on-demand hands-on labs and bootcamps. You'll have the opportunity to engage with the best minds in cloud technology on how your industry is adapting, innovating, and growing with cloud.";
                string getEventDescrText = driver.FindElement(By.ClassName("devsite-landing-row-item-description-content")).Text;

                if (getEventDescrText.Contains(googleCloudNextDescr))
                {
                    Console.WriteLine("Google Cloud Next '18 event description confirmed...");
                }
                else
                {
                    Console.WriteLine("Could not find description for Google Cloud Next '18.  Closing browser.");
                    driver.Close();
                }


                // Click on the Google Cloud Next '18 event

                driver.FindElement(By.Id("google-cloud-next-18br-july-24-26-san-francisco-usa")).Click();
                Console.WriteLine("Navigated to the Google Cloud Next '18 event page...");

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);


                // Confirm that the first H3 on the page is "Imagine"

                var h3Tag = driver.FindElement(By.XPath("//h3[text() = 'Imagine']")).Text;

                if (h3Tag == "Imagine")
                {
                    Console.WriteLine("Confirmed H3 tag \"Imagine\"...");
                }
                else
                {
                    Console.WriteLine("Could not find H3 tag \"Imagine\".  Closing browser.");
                    driver.Close();
                }


                // Click "Get updates" button


                var getUpdatesButton = driver.FindElement(By.XPath("//button[contains(text(), 'Get updates')]"));

                getUpdatesButton.Click();
                Console.WriteLine("Clicked on \"Get updates\" button...");


                // Send keys for input fields


                Console.WriteLine("Sending keys...");

                driver.FindElement(By.Id("firstName")).SendKeys("Zach");
                driver.FindElement(By.Id("lastName")).SendKeys("Phillips");
                driver.FindElement(By.Id("email")).SendKeys("myemail@company.com");
                driver.FindElement(By.Id("jobTitle")).SendKeys("Developer");
                driver.FindElement(By.Id("company")).SendKeys("My Company");

                var industry = driver.FindElement(By.Id("industry"));
                var country = driver.FindElement(By.Id("country"));

                var selectIndustry = new SelectElement(industry);
                selectIndustry.SelectByValue("Education");

                var selectCountry = new SelectElement(country);
                selectCountry.SelectByValue("US");

                Console.WriteLine("Automation script for Google Cloud Next '18 event form complete");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
