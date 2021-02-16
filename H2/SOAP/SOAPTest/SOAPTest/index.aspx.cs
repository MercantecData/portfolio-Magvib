using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SOAPTest.ServiceReference1;

namespace SOAPTest
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            WebService1SoapClient wsc = new WebService1SoapClient();
            TextBox1.Text = wsc.HelloTest();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            WebService1SoapClient wsc = new WebService1SoapClient();
            TextBox1.Text = wsc.HelloWorld();
        }
    }
}