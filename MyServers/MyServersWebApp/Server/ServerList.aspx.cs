using MyServersWebApp.Data;
using System;
using System.Web.UI;

namespace MyServersWebApp
{
    public partial class ServerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Server List";

            var serverService = new ServerService();

            rptServerList.DataSource = serverService.GetAllServerDetails();
            rptServerList.DataBind();
        }
    }
}