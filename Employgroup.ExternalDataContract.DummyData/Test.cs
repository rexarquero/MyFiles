using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employgroup.ExternalDataContract.DummyData
{
    class Test
    {
        public static void Main(string[] args)
        {
            var test = new TimesheetDummy();
            test.Populate();

            

            Console.WriteLine("Start................");

            var validator = new TransdevValidator();
            validator.ValidateXmlStringUsingXsd(ReadStringFromFile());


            //Console.WriteLine(test.GetJsonString());
            //Console.WriteLine(test.GetXMLString());
            //WriteToOutputFile(test.GetXMLStringFromJson());
            //WriteToOutputFile(test.GetJsonString(), false);
            


            //Test xml to object
            //var str = ReadStringFromFile();
           // Console.WriteLine(str);
            //var obj = test.XmlToObject(str);


            Console.ReadLine();
        }

        private static void WriteToOutputFile(string text, bool isXML = true)
        {
            if (isXML)
            {
                System.IO.File.WriteAllText(@"D:\Dev\ePayroll\ExternalDataContract\trunk\XmlData.txt", text);
            }
            else
            {
                System.IO.File.WriteAllText(@"D:\Dev\ePayroll\ExternalDataContract\trunk\JsonData.txt", text);
            }
            
        }

        private static string ReadStringFromFile()
        {
            return System.IO.File.ReadAllText(@"D:\Dev\ePayroll\ExternalDataContract\trunk\XmlData.txt");

        }
    }
}
