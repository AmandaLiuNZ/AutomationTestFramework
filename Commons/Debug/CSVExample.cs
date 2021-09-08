using Commons.Model;
using LumenWorks.Framework.IO.Csv;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Commons.Debug
{
    class CSVExample
    {
        [TestCaseSource("TestData")]
        public void CSVTestExample (BillingOrder order)
        {
            TestContext.WriteLine(order.FirstName);
        }

        static IEnumerable<TestCaseData> TestData()
        {
            //string filename = "TestData\\Name.csv";
            //string currentDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            //string completePath = currentDir + filename;

            //using (var reader = new CsvReader(new StreamReader(completePath), false)) 

            using (var csv = new CsvReader(new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory)+ "TestData\\Name.csv"), true))
            {
                while (csv.ReadNextRecord())
                {
                    BillingOrder order =
                        new BillingOrder(firstName: csv["firstname"],
                        lastName: csv["lastname"], email: csv["email"]);

                    yield return new TestCaseData(order).SetName("Billing order TC "+ csv["firstname"]);
                }
            }
        }
        
    }
}
