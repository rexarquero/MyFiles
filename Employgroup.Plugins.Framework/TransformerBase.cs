using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace Employgroup.Plugins.Framework
{
    public abstract class TransformerBase
    {
        /// <summary>
        /// Converts xml string to corresponding object type
        /// </summary>
        /// <typeparam name="T">The object type to convert to</typeparam>
        /// <param name="xmlString">The string containing xml data</param>
        /// <returns></returns>
        protected T XmlStringToObject<T>(string xmlString){
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                StringReader rdr = new StringReader(xmlString);
                return (T)serializer.Deserialize(rdr);
            }
            catch (Exception ex)
            {
                //Log error here
                throw new TransformerException(ex.Message, ex.InnerException);
            }         
        }

        /// <summary>
        /// Converts xml reader to corresponding object type
        /// Xmlreader should already be pointed to the element matching the object type
        /// </summary>
        /// <typeparam name="T">The object type to convert to</typeparam>
        /// <param name="reader">The reader containing xml data</param>
        /// <returns></returns>
        protected T XmlReaderToObject<T>(XmlReader reader) {
            try
            {
                Type type = typeof(T);             
                if(reader.Name.Equals(type.Name.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    return (T)XmlDeserializeFromString(reader.ReadOuterXml(), type);
                }
                else
                {
                    throw new TransformerException("Xml node for specified object was not found");
                }
            }
            catch (Exception ex)
            {                
                 //Log error here
                throw new TransformerException(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Convert string to object
        /// </summary>
        /// <param name="objectData">String containing xml data</param>
        /// <param name="type">Type of object to convert string to</param>
        /// <returns>Object</returns>
        private object XmlDeserializeFromString(string objectData, Type type)
        {
            var serializer = new XmlSerializer(type);
            object result;

            using (TextReader reader = new StringReader(objectData))
            {
                result = serializer.Deserialize(reader);
            }

            return result;
        }    
    
    }
}
