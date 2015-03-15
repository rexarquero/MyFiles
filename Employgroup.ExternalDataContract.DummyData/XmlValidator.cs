using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace Employgroup.ExternalDataContract.DummyData
{
    /// <summary>
    /// Base class for validator
    /// </summary>
    public abstract class XmlValidator 
    {
        //TODO: Move this to config file
        private readonly string SchemaURI = @"C:\Users\rex\Desktop\ExternalDataContract\ExternalDataContract\trunk\Release\ExternalTimesheet.xsd";
        private bool _valid = true;
        private List<ValidationError> _errors;

        /// <summary>
        /// Returns if xml is valid
        /// </summary>
        public bool IsValid { 
            get 
            {
                return _valid; 
            }
            private set 
            {
                _valid = value;
            }
        }
        /// <summary>
        /// Returns list of errors found on xml 
        /// </summary>
        public List<ValidationError> Errors {
            get { return _errors; }
            private set { }
        }

        /// <summary>
        /// Validate xml string based on xsd file
        /// </summary>
        /// <param name="xmlString"></param>
        public virtual void ValidateXmlStringUsingXsd(string xmlString)
        {
            XmlReaderSettings rdrSettings = new XmlReaderSettings();
            rdrSettings.Schemas.Add("", SchemaURI);
            rdrSettings.ValidationType = ValidationType.Schema;
            rdrSettings.ValidationEventHandler += new ValidationEventHandler(SettingsValidationEventHandler);
            XmlReader reader = XmlReader.Create(new StringReader(xmlString), rdrSettings);
            while (reader.Read()){};
        }

        /// <summary>
        /// Validate xml reader based on xsd file
        /// </summary>
        /// <param name="reader"></param>
        public virtual void ValidateXmlReaderUsingXsd(XmlReader reader) {
            XmlReaderSettings rdrSettings = new XmlReaderSettings();
            rdrSettings.Schemas.Add("", SchemaURI);
            rdrSettings.ValidationType = ValidationType.Schema;
            rdrSettings.ValidationEventHandler += new ValidationEventHandler(SettingsValidationEventHandler);    
            while (reader.Read()){};
        }

        /// <summary>
        /// Handler for xml validation errors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsValidationEventHandler(object sender, ValidationEventArgs e)
        {
            if (_errors == null)
                _errors = new List<ValidationError>();

            if (e.Severity == XmlSeverityType.Warning)
            {
                _errors.Add(new ValidationError() { Message = e.Message, Severity = e.Severity });
            }
            else if(e.Severity ==  XmlSeverityType.Error)
            {
                _errors.Add(new ValidationError() { Message = e.Message, Severity = e.Severity });
                IsValid = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //private XmlReaderSettings GetReaderSettings() { 
        
        //}
    }

    public class ValidationError {
        public XmlSeverityType Severity { get; set; }
        public string Message { get; set; }
    }
}
