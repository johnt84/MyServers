using MyServersWebApp.Data;
using MyServersWebApp.MyServersApiSimulatorService;
using System;

namespace MyServersWebApp.Server
{
    public partial class Server : System.Web.UI.Page
    {
        protected string serviceID;
        protected ServerInfo serverDetails;
        private ServerService serverService;
        protected bool serviceExists;

        protected void Page_Load(object sender, EventArgs e)
        {
            serviceID = Request.QueryString["serviceid"];

            Page.Title = $"Server Details - {serviceID}";

            if (string.IsNullOrEmpty(serviceID))
            {
                serviceExists = false;
                divMain.Visible = false;
                lbErrorMessage.Text = "Please provide a valid Service ID";
                return;
            }

            serverService = new ServerService();
            serverDetails = serverService.GetServerDetails(serviceID);

            if (string.IsNullOrEmpty(serverDetails.ServiceID))
            {
                serviceExists = false;
                divMain.Visible = false;
                lbErrorMessage.Text = $"No server exists with the Service ID of {serviceID}";
                return;
            }

            lbErrorMessage.Text = string.Empty;

            serviceExists = true;
            divMain.Visible = true;

            PopulatePage();
        }

        private void PopulatePage()
        {
            rptServerStatus.DataSource = serverService.GetServerStatus(serviceID);
            rptServerStatus.DataBind();

            lbYourReference.Text = serverDetails.YourReference;
            lbLocation.Text = serverDetails.Location;
            lbPrimaryIP.Text = serverDetails.PrimaryIP;
        }
    }
}