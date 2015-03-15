using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Employgroup.ExternalDataContract.Timesheet.Transdev;
using Employgroup.ExternalDataContract.Timesheet.Transdev.Enumerators;
using Newtonsoft.Json;

namespace Employgroup.ExternalDataContract.DummyData
{
    public class TimesheetDummy : IDummy
    {

        private ExternalTimesheet _timesheet;

        public TimesheetDummy()
        {
            Console.WriteLine("Constructor");
        }

        public void Populate()
        {
            //Create dummy entries
            var entries = (from ExternalEntryType type in Enum.GetValues(typeof(ExternalEntryType))
                           select new ExternalTimesheetEntry()
                           {
                               CustomCode = "ACBCD_CODE",
                               EndTime = new DateTime().AddHours(8),
                               EntryType = type,
                               Hours = type == ExternalEntryType.Break ? 1 : 4,
                               IsDone = (int)type % 2 == 0 ? true : false,
                               StartTime = new DateTime()
                           }).ToList();

            //Create dummy entry days
            var entryDays = new List<ExternalTimesheetDay>();
            for (var i = 1; i < 8; i++)
            {
                var entryDay = new ExternalTimesheetDay()
                {
                    Abn = "XX_ABN_SAMPLE",
                    Comments = new List<string>() { "Comment 1", "Comment 2", "Comment 3" },
                    EmployeeCode = "EMP_CODE",
                    EmployeeToken = "EMP_TOKEN",
                    EmployerToken = "EMPPLYR_TKN",
                    PositionName = "POS_NAME",
                    TimesheetDate = new DateTime().AddDays(i),
                    TimesheetEntries = entries
                };
                entryDays.Add(entryDay);
            }

            _timesheet = new ExternalTimesheet() { TimesheetDays = entryDays };
        }


        public Stream GetDummyStreamLarge()
        {
            var timesheets = new List<ExternalTimesheet>();
            Populate();
            //Fill obj with huge data
            for (var i = 0; i < 500; i++) {                
                timesheets.Add(_timesheet);
            }

            var stream = new MemoryStream();
            var stringwriter = new StringWriter();
            //Serialize obj
            var serializer = new XmlSerializer(timesheets.GetType());
            serializer.Serialize(stream, timesheets);            
            return stream;

        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }


        public string GetXMLString(Object obj)
        {
            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(obj.GetType());
            serializer.Serialize(stringwriter, obj);
            return stringwriter.ToString();
        }

        public string GetJsonString(Object obj)
        {
            var stringwriter = new System.IO.StringWriter();
            var serializer = new Newtonsoft.Json.JsonSerializer();
            serializer.Serialize(new JsonTextWriter(stringwriter), _timesheet);
            return stringwriter.ToString();
        }


        public string GetXMLString()
        {
            return GetXMLString(_timesheet);
        }

        public string GetJsonString()
        {
            return GetJsonString(_timesheet);
        }

        public string GetXMLStringFromJson()
        {
            XmlDocument doc = JsonConvert.DeserializeXmlNode(GetJsonString());
            return doc.ToString();
        }

        public ExternalTimesheet XmlToObject(string inputString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ExternalTimesheet));
            StringReader rdr = new StringReader(inputString);
            var obj = (ExternalTimesheet)serializer.Deserialize(rdr);

            return obj;
        }
        
        public XmlReader StreamToXmlReader(Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ExternalTimesheet));
            stream.Position = 0;
            XmlReader reader = XmlReader.Create(stream);
            return reader;
        }
    }
}
