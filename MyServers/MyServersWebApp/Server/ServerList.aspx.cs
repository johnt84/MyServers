using MyServersWebApp.Data;
using System;
using System.Threading.Tasks;
using System.Web.UI;

namespace MyServersWebApp
{
    public partial class ServerList : System.Web.UI.Page
    {
        private IServerService serverService;

        protected async void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Server List";

            serverService = GlobalSettings.Container.GetInstance<IServerService>();

            Page.RegisterAsyncTask(new PageAsyncTask(PopulatePageAsync));
        }

        private async Task PopulatePageAsync()
        {
            rptServerList.DataSource = await serverService.GetAllServerDetailsAsync();
            rptServerList.DataBind();
        }
    }
}