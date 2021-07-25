using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace dak_datacrawling
{
    public enum Browser
    {
        Chrome = 0,
        FireFox = 1,
        IE = 2
    }
    public class Base
    {
        public IWebDriver driver;
        public static string LogPath = "";
        public static string logfileName = "trace.log";
        public string baseURL = "";
        public int iTimeout = 300;

        internal IWebElement GetFirstChildByClass(IWebElement parent, string v)
        {
            return parent.FindElement(By.ClassName(v));
        }

        public Base()
        {
            //string browser = int.Parse(System.Configuration.ConfigurationManager.AppSettings["Chrome"]);
            driver = new ChromeDriver();
            LogPath = AppDomain.CurrentDomain.BaseDirectory + "\\LogFiles";
            if (!Directory.Exists(LogPath))
                Directory.CreateDirectory(LogPath);

        }
        public static void WriteLog(string strContent)
        {
            try
            {
                string path = LogPath;
                if (path == "")
                {
                    path = AppDomain.CurrentDomain.BaseDirectory + "\\LogFiles";
                    LogPath = path;
                }
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string filenameLog = path + "\\" + logfileName;

                try
                {
                    FileInfo fi = new FileInfo(filenameLog);
                    if (fi.Length > 10485760)    //10MB
                    {
                        File.Move(filenameLog, path + "\\" + logfileName.Replace(".log", "_" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff") + ".log"));
                    }
                }
                catch { }

                StreamWriter writer = new StreamWriter(filenameLog, true);
                writer.WriteLine(String.Format("- {0}: {2}", DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss"), strContent));
                writer.Close();
                Console.WriteLine(strContent);
            }
            catch { }

        }
        string PathImageDownload = System.Configuration.ConfigurationManager.AppSettings["PathImageDownload"] ?? "./downloaded_images";
        internal void DownloadImage(string url, string name)
        {
            WebClient cl = new WebClient();
            cl.DownloadFile(url, PathImageDownload + "\\" + name);
        }

        internal void MoveToElement(IWebElement element)
        {
           
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
        }
        internal void MoveToElement(By by)
        {

            Actions actions = new Actions(driver);
            actions.MoveToElement(GetIWebElementByby(by));
            actions.Perform();
        }

        public IWebElement GetIWebElementByby(By by)
        {
            return driver.FindElement(by);
        }

        internal IWebElement GetFirstChildByTagName_AcceptNull(IWebElement ele, string v)
        {
            try
            {
                return ele.FindElement(By.TagName(v));
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal bool ContainChildTagName(IWebElement ele, string v)
        {
            try
            {
                return ele.FindElements(By.TagName(v)).Count > 0;

            }
            catch (Exception)
            {

                return false;
            }
        }

        internal void WaitForElementPresent(By by)
        {
            for (int second = 0; ; second++)
            {
                if (second >= 60) throw new NoSuchElementException();
                if (IsElementPresent(by)) return;
                Thread.Sleep(1000);
                WriteLog("Waiting for loading Element ...");
            }
        }
        internal void WaitForElementPresent(string ID)
        {
            for (int second = 0; ; second++)
            {
                if (second >= 60) { WriteLog("Failed on waiting for " + ID); throw new NoSuchElementException(ID); }
                if (IsElementPresent(By.Id(ID))) return;
                Thread.Sleep(1000);
                WriteLog("Waiting for " + ID + " ...");
            }
        }
        internal void InputValueToTextBox(string textboxID, string value)
        {
            WriteLog("Prepare to Input on " + textboxID);
            WaitForElementPresent(textboxID);
            WaitForElementClickable(textboxID);
            driver.FindElement(By.Id(textboxID)).Clear();
            driver.FindElement(By.Id(textboxID)).SendKeys(value);
            WriteLog("Finished input to " + textboxID);
        }

        public void WaitFinishProcessing()
        {
            Thread.Sleep(300);
            // Warning: waitForTextNotPresent may require manual changes          
            for (int second = 0; ; second++)
            {
                if (second >= iTimeout) throw new TimeoutException();
                try
                {
                    if (!Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Processing \\.\\.\\.[\\s\\S]*$")
                        &&
                        !IsElementPresent(By.Id("pPopupLoadingContainer_id"))
                        ) break;
                }
                catch (Exception ex)
                { }
                Thread.Sleep(1000);
                WriteLog("Waiting for finish processing ...");
            }


        }
        public void WaitForAjaxComplete(int maxSeconds = 60)
        {
            bool is_ajax_compete = false;
            for (int i = 1; i <= maxSeconds; i++)
            {
                is_ajax_compete = (bool)((IJavaScriptExecutor)driver).
               ExecuteScript("return window.jQuery != undefined && jQuery.active == 0");
                if (is_ajax_compete)
                {
                    return;
                }
                System.Threading.Thread.Sleep(1000);
            }
            throw new Exception("Timed out after " + maxSeconds + " seconds");
        }
        internal void ClickOn(By by, string name)
        {
            try
            {

                WriteLog("Prepare to click on " + name);
                WaitFinishProcessing();
                WaitForElementPresent(by);
                WaitForElementClickable(by);
                driver.FindElement(by).Click();
                WriteLog("Clicked on " + name);
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message + " - " + ex.StackTrace);
                throw new Exception(name, ex);
            }
        }
        internal void ClickOn(IWebElement ele, string name)
        {
            try
            {

                WriteLog("Prepare to click on " + name);
                WaitFinishProcessing();
          
                WaitForElementClickable(ele);
                ele.Click();
                WriteLog("Clicked on " + name);
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message + " - " + ex.StackTrace);
                throw new Exception(name, ex);
            }
        }
        internal void ClickOn(string ElementID, bool ischeckProcessing = true)
        {

            try
            {
                WriteLog("Prepare to click on " + ElementID);
                if (ischeckProcessing)
                    WaitFinishProcessing();
                WaitForElementPresent(ElementID);
                WaitForElementClickable(ElementID);
                driver.FindElement(By.Id(ElementID)).Click();
                WriteLog("Clicked on " + ElementID);
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message + " - " + ex.StackTrace);
                throw new Exception(ElementID, ex);
            }

        }

        private void WaitForElementClickable(string elementID)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            //  wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id(ElementID)));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(elementID)));
        }
        private void WaitForElementClickable(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            //  wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id(ElementID)));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        private void WaitForElementClickable(IWebElement ele)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            //  wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id(ElementID)));
            wait.Until(ExpectedConditions.ElementToBeClickable(ele));
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                return driver.FindElement(by).Displayed;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        internal IWebElement GetIWebElementByClass(string v)
        {
            WaitForElementPresent(By.ClassName(v));
            return driver.FindElement(By.ClassName(v));
        }
        internal IWebElement GetIWebElementByID(string v)
        {
            WaitForElementPresent(By.Id(v));
            return driver.FindElement(By.Id(v));
        }
    }
}
