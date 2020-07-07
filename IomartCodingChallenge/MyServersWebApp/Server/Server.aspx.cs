using MyServersWebApp.Data;
using MyServersWebApp.MyServersApiSimulatorService;
using System;

namespace MyServersWebApp.Server
{
    public partial class Server : System.Web.UI.Page
    {
        protected string serviceID;
        protected ServerInfo serverDetails;

        protected void Page_Load(object sender, EventArgs e)
        {
            serviceID = Request.QueryString["serviceid"];

            Page.Title = $"Server Details - {serviceID}";

            if (string.IsNullOrEmpty(serviceID))
            {
                divMain.Visible = false;
                return;
            }

            divMain.Visible = true;

            PopulatePage();
        }

        private void PopulatePage()
        {
            var serverService = new ServerService();

            rptServerStatus.DataSource = serverService.GetServerStatus(serviceID);
            rptServerStatus.DataBind();

            serverDetails = serverService.GetServerDetails(serviceID);

            lbYourReference.Text = serverDetails.YourReference;
            lbLocation.Text = serverDetails.Location;
            lbPrimaryIP.Text = serverDetails.PrimaryIP;
        }
    }
}