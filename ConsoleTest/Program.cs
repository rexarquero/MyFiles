using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employgroup.ExternalDataContract.DummyData;
using Employgroup.Plugins.Framework;
using System.Xml;
using System.IO;

namespace ConsoleTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Start................");
            TestLargeStream();
            return;
            //var validator = new TransdevValidator();
            //var transformer = new TransdevTransformer();
            //var xmlString = ReadStringFromFile();

            ////Get xml
            //XmlReader reader = XmlReader.Create(new StringReader(xmlString));

            ////Validate
            //validator.ValidateXmlReaderUsingXsd(reader);
            ////validator.ValidateXmlUsingXsd(xmlString);


            //if (validator.IsValid) {
            //    //Transform
            //    var obj = transformer.XmlReaderToExternalTimesheet(reader);
            //}

        }

        public static void TestLargeStream()
        {
            var testDummy = new TimesheetDummy();
            using (var stream = testDummy.GetDummyStreamLarge())
            {
                stream.Position = 0;
                //XmlReader xml = new XmlReader();
                //BufferedStream bs = new BufferedStream()
                var reader = testDummy.StreamToXmlReader(stream);
                //var validator = new TransdevValidator();
                //validator.ValidateXmlReaderUsingXsd(reader);
                //if (validator.IsValid)
                //{
                //    //Transform
                //    var transformer = new TransdevTransformer();
                //    var obj = transformer.XmlReaderToExternalTimesheets(reader);
                //}

                var transformer = new TransdevTransformer();
                transformer.OnBatchCountReached += new MyEventHandler(OnBatchCountReached);
                var obj = transformer.XmlReaderToExternalTimesheets(reader);

            }
            Console.ReadLine();
        }

        static void OnBatchCountReached(object source, MyEventArgs e)
        {
            var timesheets = e.GetTimesheets();
            //PRocess this timesheet for API
        }

        private static void WriteToOutputFile(string text, bool isXML = true)
        {
            if (isXML)
            {
                System.IO.File.WriteAllText(@"C:\Users\rex\Desktop\ExternalDataContract\ExternalDataContract\trunk\XmlData.txt", text);
            }
            else
            {
                System.IO.File.WriteAllText(@"C:\Users\rex\Desktop\ExternalDataContract\ExternalDataContract\trunk\JsonData.txt", text);
            }

        }

        private static string ReadStringFromFile()
        {
            return System.IO.File.ReadAllText(@"C:\Users\rex\Desktop\ExternalDataContract\ExternalDataContract\trunk\XmlData.txt");

        }
    }
}
