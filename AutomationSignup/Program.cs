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
            //Launch google developers webpage

            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://developers.google.com/";
            Console.WriteLine("Opened Chrome Browser to https://developers.google.com/");

            // Confirm text description for Google Cloud Next '18

            string googleCloudNextDescr = "Hone your skills on the latest cloud technologies with Google experts at hundreds of breakout sessions and interactive on-demand hands-on labs and bootcamps. You'll have the opportunity to engage with the best minds in cloud technology on how your industry is adapting, innovating, and growing with cloud.";
            string getEventDescrText = driver.FindElement(By.ClassName("devsite-landing-row-item-description-content")).Text;

            if (getEventDescrText.Contains(googleCloudNextDescr))
            {
                Console.WriteLine("Google Cloud Next '18 event description confirmed");
            }
            else
            {
                Console.WriteLine("Could not find description for Google Cloud Next '18");
            }

            // Click the Google Cloud Next '18 event



            Console.ReadLine();
        }
    }
}
