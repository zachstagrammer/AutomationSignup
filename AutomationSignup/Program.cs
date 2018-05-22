using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationSignup
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            var waitTime = 30;


            //Launch google developers webpage

            driver.Url = "https://developers.google.com/";
            Console.WriteLine("Opened Chrome Browser to https://developers.google.com/...");


            // Confirm text description for Google Cloud Next '18

            string googleCloudNextDescr = "Hone your skills on the latest cloud technologies with Google experts at hundreds of breakout sessions and interactive on-demand hands-on labs and bootcamps. You'll have the opportunity to engage with the best minds in cloud technology on how your industry is adapting, innovating, and growing with cloud.";
            string getEventDescrText = driver.FindElement(By.ClassName("devsite-landing-row-item-description-content")).Text;

            try
            {
                if (getEventDescrText.Contains(googleCloudNextDescr))
                {
                    Console.WriteLine("Google Cloud Next '18 event description confirmed...");
                }
                else
                {
                    Console.WriteLine("Could not find description for Google Cloud Next '18.  Closing browser.");
                    driver.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            // Click on the Google Cloud Next '18 event

            driver.FindElement(By.Id("google-cloud-next-18br-july-24-26-san-francisco-usa")).Click();
            Console.WriteLine("Navigated to the Google Cloud Next '18 event page...");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(waitTime);


            // Confirm that the first H3 on the page is "Imagine"

            try
            {
                var h3Tag = driver.FindElement(By.ClassName("title")).Text;
                
                if (h3Tag == "Imagine")
                {
                    Console.WriteLine("Confirmed H3 tag \"Imagine\"...");
                }
                else
                {
                    Console.WriteLine("Could not find H3 tag \"Imagine\".  Closing browser.");
                    driver.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Click "Get updates" button


            try
            {
                var getUpdatesButton = driver.FindElement(By.XPath("//button[contains(text(), 'Get updates')]"));

                getUpdatesButton.Click();
                Console.WriteLine("Clicked on \"Get updates\" button...");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
