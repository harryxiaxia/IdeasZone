using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using System.Configuration;

namespace VocabularyListTool
{
    class Program
    {
        private const string USERNAME = "harryxiaxia@gmail.com";
        private const string PASSWORD = "775852188120";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var driver = new ChromeDriver();
            var site = new VocabularyDotCom(driver);
            var words = new List<string> { "simile", "perfect", "teacher", "student" };

            site.OpenVocabularyDotCom().Login(USERNAME, PASSWORD).AddWordsToList("Test", words);
            
            Console.ReadKey();

        }
    }
}
