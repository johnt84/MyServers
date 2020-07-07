using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyServersWebApp
{
    public partial class SiteMaster : MasterPage
    {
        protected string webAppName;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            webAppName = "My Servers Web App";
        }
    }
}