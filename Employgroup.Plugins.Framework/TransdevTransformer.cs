using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employgroup.ExternalDataContract.Timesheet.Transdev;
using System.Xml;
using Employgroup.ExternalDataContract.DummyData;

namespace Employgroup.Plugins.Framework
{
    //First we have to define a delegate that acts as a signature for the
    //function that is ultimately called when the event is triggered.
    //You will notice that the second parameter is of MyEventArgs type.
    //This object will contain information about the triggered event.
    public delegate void MyEventHandler(object source, MyEventArgs e);

    //This is a class which describes the event to the class that recieves it.
    //An EventArgs class must always derive from System.EventArgs.
    public class MyEventArgs : EventArgs
    {
        private string EventInfo;
        private List<ExternalTimesheet> Timesheets;
        public MyEventArgs(string Text, List<ExternalTimesheet> timesheets)
        {
            EventInfo = Text;
            Timesheets = timesheets;
        }
        public string GetInfo()
        {
            return EventInfo;
        }

        public List<ExternalTimesheet> GetTimesheets() {
            return Timesheets;
        }
    }


    public class TransdevTransformer : TransformerBase
    {
        private TransdevValidator _validator;
        public event MyEventHandler OnBatchCountReached;
        public TransdevTransformer()
        {
            _validator = new TransdevValidator();
        }
       
        /// <summary>
        /// Deserializes xmlreader contents to object collection
        /// </summary>
        /// <param name="reader">Xmlreader containg data to deserialize</param>
        /// <returns></returns>
        public List<ExternalTimesheet> XmlReaderToExternalTimesheets(XmlReader reader)
        {
            var returnValue = new List<ExternalTimesheet>();
            reader.ReadToFollowing("ExternalTimesheet");
            do
            {            
                
                var currentElement = reader.ReadOuterXml();
                _validator.ValidateXmlStringUsingXsd(currentElement);
                if (_validator.IsValid)
                {                    
                    returnValue.Add(base.XmlStringToObject<ExternalTimesheet>(currentElement));
                    //TODO: Get batch count from config file
                    if (returnValue.Count == 100) {
                        if (OnBatchCountReached != null) 
                        {                            
                            OnBatchCountReached(this, new MyEventArgs("Sending contents for processing", returnValue));
                            returnValue.Clear();
                        }
                        
                    }

                }
                else 
                { 
                    //Log Error invalid node
                }
            }
            while (reader.ReadToNextSibling("ExternalTimesheet"));         
            reader.Close();
            return returnValue;
        }

        //public ExternalTimesheet XmlReaderToExternalTimesheet(XmlReader reader)
        //{

        //    while (reader.ReadToNextSibling("ExternalTimesheet"))
        //    {

        //    };

        //    var returnValue = base.XmlReaderToObject<ExternalTimesheet>(reader);

        //    reader.Close();

        //    return returnValue;
        //}

    }
}
