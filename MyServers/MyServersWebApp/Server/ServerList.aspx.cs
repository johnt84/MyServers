using MyServersWebApp.Data;
using System;
using System.Web.UI;

namespace MyServersWebApp
{
    public partial class ServerList : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Server List";

            var serverService = GlobalSettings.Container.GetInstance<IServerService>();

            rptServerList.DataSource = await serverService.GetAllServerDetails();
            rptServerList.DataBind();
        }
    }
}