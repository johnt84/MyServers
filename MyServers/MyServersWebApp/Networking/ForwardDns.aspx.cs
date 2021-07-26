using MyServersWebApp.Data;
using System;

namespace MyServersWebApp.Networking
{
    public partial class ForwardDns : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Forward DNS";

            var forwardDnsService = GlobalSettings.Container.GetInstance<IForwardDnsService>();

            rptForwardDns.DataSource = await forwardDnsService.GetForwardDnsDomains();
            rptForwardDns.DataBind();
        }
    }
}