using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace Employgroup.ExternalDataContract.DummyData
{
    interface IDummy
    {
        void Initialize();
        void Populate();
        string GetXMLString();
        string GetXMLStringFromJson();
        string GetJsonString();
        Stream GetDummyStreamLarge();

        XmlReader StreamToXmlReader(Stream stream);

    }
}
