using MyServersWebApp.Data;
using System;
using System.Threading.Tasks;
using System.Web.UI;

namespace MyServersWebApp.Networking
{
    public partial class ReverseDns : System.Web.UI.Page
    {
        private IReverseDnsService reverseDnsService;

        protected async void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Reverse DNS";

            reverseDnsService = GlobalSettings.Container.GetInstance<IReverseDnsService>();

            Page.RegisterAsyncTask(new PageAsyncTask(PopulatePageAsync));
        }

        private async Task PopulatePageAsync()
        {
            rptReverseDns.DataSource = await reverseDnsService.GetReverseDnsEntriesAsync();
            rptReverseDns.DataBind();
        }
    }
}