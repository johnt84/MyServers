using MyServersWebApp.Data;
using System;

namespace MyServersWebApp.Networking
{
    public partial class ForwardDns : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Forward DNS";

            var forwardDnsService = new ForwardDnsService();

            rptForwardDns.DataSource = forwardDnsService.GetForwardDnsDomains();
            rptForwardDns.DataBind();
        }
    }
}