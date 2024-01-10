

using System.Reflection.PortableExecutable;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

IWebDriver driver = new ChromeDriver();
driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
driver.Manage().Window.Maximize();

//Entering name, password and click on login
driver.FindElement(By.Id("UserName")).SendKeys("Hari");
Thread.Sleep(1000);

driver.FindElement(By.Id("Password")).SendKeys("123123");
Thread.Sleep(1000);

driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]")).Click();
Thread.Sleep(2000);


//Verify logged in or nor 

IWebElement verificationText = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

if (verificationText.Text == "Hello hari!")
{
    Console.WriteLine("TurnUp Potal Logged in Successfully");
}

else
{
    Console.WriteLine("User not able to login");
}

Thread.Sleep(1000);


//click on administration and select time and materials

driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();
Thread.Sleep(1000);


driver.FindElement(By.LinkText("Time & Materials")).Click();
Thread.Sleep(2000);
Console.WriteLine("User clicked on Time and Materials");


//click on "Create" and send datas and save it

driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a")).Click();
Thread.Sleep(1000);

IWebElement typeCode = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span"));

typeCode.Click();
Thread.Sleep(1000);

IWebElement dropdownbutton = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
dropdownbutton.Click();
Thread.Sleep(1000);

IWebElement codeTextBox = driver.FindElement(By.Id("Code"));
codeTextBox.SendKeys("Koshi Jacob 123");
Thread.Sleep(1000);

IWebElement descriptionTextBox = driver.FindElement(By.Id("Description"));
descriptionTextBox.SendKeys("Automation Demo in Time and Materials");
Thread.Sleep(1000);

IWebElement pricePerUnit = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
pricePerUnit.SendKeys("20");
Thread.Sleep(1000);


IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
saveButton.Submit();
Thread.Sleep(1000);

Console.WriteLine("Time and Materials created and submitted");

          //click on lastpage icon and check the given code


IWebElement selectLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
selectLastPage.Click();

IWebElement savedData = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
if(savedData.Text == "Koshi Jacob 123")
{
    Console.WriteLine("Data saved in Time and Materials");

}
else
{
    Console.WriteLine("Data not saved in Time and Materials"); 
}
Thread.Sleep(1000);

//Edit the given data

IWebElement clickOnEditButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
clickOnEditButton.Click();


IWebElement editCodeType = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
editCodeType.Click();
Thread.Sleep(1000); 

IWebElement selectDropDown= driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
selectDropDown.Click();
Thread.Sleep(1000);

IWebElement editCode = driver.FindElement(By.Id("Code"));
editCode.Clear();
editCode.SendKeys("Koshiya Jacob");
Thread.Sleep(1000); 

IWebElement editDescription = driver.FindElement(By.Id("Description"));
editDescription.Clear();
editDescription.SendKeys("Edited Automation Code");
Thread.Sleep(1000);

IWebElement editPrice = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
//Thread.Sleep(1000);
editPrice.SendKeys("40"); 
Thread.Sleep(1000);

driver.FindElement(By.Id("SaveButton")).Click();
Thread.Sleep(1000);


driver.FindElement(By.LinkText("Go to the last page")).Click();

              //click on Delete button and retrieve the alert message 

IWebElement clickDelete = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
clickDelete.Click();
Thread.Sleep(1000);

/*Boolean alertMessage = false;

try
{
    IAlert alert = driver.SwitchTo().Alert();
    alertMessage = false;
    alert.Dismiss();
    Console.WriteLine("Alert was accepted");
    Thread.Sleep(1000);

}
catch (Exception ex)
{
    Console.WriteLine(ex);
}*/

IAlert alert = driver.SwitchTo().Alert();

string alertBox = alert.Text;
Console.WriteLine("Alert box text" + alertBox);
alert.Accept();


                   //Logout


IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
helloHari.Click();
Thread.Sleep(2000);


IWebElement dropDownField = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/ul/li[2]/a"));
dropDownField.Click();


string url = driver.Url;
Console.WriteLine(url);

driver.Close();



