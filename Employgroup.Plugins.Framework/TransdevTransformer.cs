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
    public class TransdevTransformer : TransformerBase
    {
        private TransdevValidator _validator;
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
