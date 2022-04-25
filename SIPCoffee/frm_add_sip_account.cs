using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using XML_RW;

namespace SIPCoffee
{
    public partial class frm_add_sip_account : Form
    {
        public frm_add_sip_account()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                XML_RW.xml_rw xmlrw = new xml_rw("sip.xml", "sip_settings");

                //create value pair
                xml_rw.xml_value_pair xml_pair = new xml_rw.xml_value_pair();
                xml_pair.element_name = "display_name";
                xml_pair.element_value = txt_display_name.Text;
                xmlrw.write_xml(xml_pair);

                xml_pair = new xml_rw.xml_value_pair();
                xml_pair.element_name = "user_name";
                xml_pair.element_value = txt_username.Text;
                xmlrw.write_xml(xml_pair);

                xml_pair = new xml_rw.xml_value_pair();
                xml_pair.element_name = "register_name";
                xml_pair.element_value = txt_register_name.Text;
                xmlrw.write_xml(xml_pair);

                xml_pair = new xml_rw.xml_value_pair();
                xml_pair.element_name = "sip_password";
                xml_pair.element_value = txt_sip_password.Text;
                xmlrw.write_xml(xml_pair);

                xml_pair = new xml_rw.xml_value_pair();
                xml_pair.element_name = "server_name";
                xml_pair.element_value = txt_sip_server.Text;
                xmlrw.write_xml(xml_pair);

              


            }
            catch(Exception ex)
            {

            }
        }
    }
}
