using NUnit.Framework;
using System;
using System.Text;

namespace WebAddressbookTests
{
    public class TestBase
    {
        public static bool Perform_Long_Ui_Checks = true;
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();           
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int maxStringLenth)
        {
            int lenth = Convert.ToInt32(rnd.NextDouble() * maxStringLenth);
            StringBuilder builder = new StringBuilder();
            for (int i=0; i< lenth; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }
    }
} 
