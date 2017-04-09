using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace VocabularyListTool
{
    class VocabularyDotCom
    {
        private IWebDriver driver;

        public VocabularyDotCom(IWebDriver drive)
        {
            this.driver = drive;
        }

        public VocabularyDotCom OpenVocabularyDotCom()
        {
            driver.Url = "https://www.vocabulary.com/";
            return this;
        }

        public VocabularyDotCom Login(string username, string password)
        {
            driver.FindElement(By.ClassName("login")).Click();
            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("username")).SendKeys(username);

            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys(password);

            driver.FindElement(By.ClassName("green")).Click();
            return this;
        }

        public VocabularyDotCom SelectLists()
        {
            driver.FindElement(By.LinkText("LISTS")).Click();
            return this;
        }

        public VocabularyDotCom GoToListsPage()
        {
            driver.Url = "https://www.vocabulary.com/account/lists";
            return this;
        }

        public VocabularyDotCom GoToList(string name)
        {
            GoToListsPage();
            driver.FindElement(By.PartialLinkText(name)).Click();
            return this;
        }

        public VocabularyDotCom GoToListAndEdit(string name)
        {
            GoToList(name);
            driver.FindElement(By.PartialLinkText("Edit")).Click();
            return this;
        }

        public VocabularyDotCom AddWordsToList(string listName, List<string> words)
        {
            GoToList(listName);

            foreach(var word in words)
            {
                driver.FindElement(By.PartialLinkText("Edit")).Click();
                //driver.FindElement(By.ClassName("wordInput")).Clear();
                //driver.FindElement(By.ClassName("wordInput")).SendKeys(word);
                driver.FindElement(By.CssSelector("[placeholder='add a word']")).SendKeys(word);
                driver.FindElement(By.CssSelector("[placeholder='add a word']")).Clear();
                driver.FindElement(By.ClassName("green")).Click();
                Thread.Sleep(1 * 1000);
            }
            return this;
        }

    }
}
