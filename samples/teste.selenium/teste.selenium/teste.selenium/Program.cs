using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using OpenQA.Selenium.Support.UI;


namespace teste.selenium
{
	public class MainClass
	{

		public static void Main(string[] args)
		{
			try
			{
				var DriverLocation = Assembly.GetEntryAssembly().Location.Replace("teste.selenium.exe", "") + "3rdParty";

				Console.WriteLine("Vamos usar o Driver localizado em:" + DriverLocation);

				IWebDriver driver = new ChromeDriver(DriverLocation);
				driver.Navigate().GoToUrl("http://www.google.com/");

				var element = driver.FindElement(By.Name("q"));
				element.SendKeys("Selenium Mono\n");
				element.Submit();

				var myDynamicElement = (new WebDriverWait(driver, new TimeSpan(0, 0, 10)))
						  .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("resultStats")));
				var findElements = driver.FindElements(By.XPath("//*[@id='rso']//h3/a"));

				Console.Out.WriteLine("Resultados Encontrados:");
				Console.Out.WriteLine("===============================");

				foreach (var webElement in findElements)
				{
					Console.Out.WriteLine("Link Encontrado:" + webElement.GetAttribute("href"));
				}
				Console.Out.WriteLine("===============================");

			}
			catch (Exception ex)
			{
				Console.WriteLine(String.Format("{0} - {1} = ", ex.Message, ex.StackTrace));
			}

		}
	}
}
