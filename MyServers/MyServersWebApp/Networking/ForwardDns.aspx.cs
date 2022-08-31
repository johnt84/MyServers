using MyServersWebApp.Data;
using System;
using System.Threading.Tasks;
using System.Web.UI;

namespace MyServersWebApp.Networking
{
    public partial class ForwardDns : System.Web.UI.Page
    {
        private IForwardDnsService forwardDnsService;

        protected async void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Forward DNS";

            forwardDnsService = GlobalSettings.Container.GetInstance<IForwardDnsService>();

            Page.RegisterAsyncTask(new PageAsyncTask(PopulatePageAsync));
        }

        private async Task PopulatePageAsync()
        {
            rptForwardDns.DataSource = await forwardDnsService.GetForwardDnsDomainsAsync();
            rptForwardDns.DataBind();
        }
    }
}