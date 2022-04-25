using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML_RW
{
    class xml_rw
    {
        string file_path;
        XmlTextWriter xml_writer;
        string root_element;
      //  xml_value_pair xml_pair;

        public xml_rw(string filepath,string rootElement)
        {
            xml_writer = new XmlTextWriter(filepath, null);
            root_element = rootElement;
           // xml_pair = vp;
        }

        public void write_xml (xml_value_pair vp)
        {
            try
            {
                xml_writer.WriteStartDocument();
                xml_writer.WriteStartElement(root_element, "");

                xml_writer.WriteStartElement(vp.element_name, "");
                xml_writer.WriteString(vp.element_value);
                xml_writer.WriteEndElement();

                xml_writer.WriteEndElement();
                xml_writer.WriteEndDocument();
                xml_writer.Close();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

       public struct xml_value_pair
        {
            public string element_name;
            public string element_value;
        }
    }
}
