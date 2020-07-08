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
        protected bool actionCompleted;

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

            if (!Page.IsPostBack)
            {
                PopulatePage();

                if (string.IsNullOrEmpty(serverDetails.ServiceID))
                {
                    serviceExists = false;
                    divMain.Visible = false;
                    lbErrorMessage.Text = $"No server exists with the Service ID of {serviceID}";
                    return;
                }
            }

            lbErrorMessage.Text = string.Empty;
            lbInformationMesage.Text = string.Empty;

            serviceExists = true;
            actionCompleted = false;
            divMain.Visible = true;
        }

        protected void btnSuspendServer_Click(object sender, EventArgs e)
        {
            serverService.SuspendServer(serviceID, txtSuspensionReason.Text);

            ActionCompleted("Server suspended successfully");

            PopulatePage();
        }

        protected void btnUnsuspendServer_Click(object sender, EventArgs e)
        {
            serverService.UnsuspendServer(serviceID);

            ActionCompleted("Server unsuspended successfully");

            PopulatePage();
        }

        private void PopulatePage()
        {
            rptServerStatus.DataSource = serverService.GetServerStatus(serviceID);
            rptServerStatus.DataBind();

            serverDetails = serverService.GetServerDetails(serviceID);

            lbYourReference.Text = serverDetails.YourReference;
            lbLocation.Text = serverDetails.Location;
            lbPrimaryIP.Text = serverDetails.PrimaryIP;
            lbIsSuspended.Text = serverDetails.Suspended ? "Yes" : "No";
        }

        private void ActionCompleted(string informationMessage)
        {
            lbInformationMesage.Text = informationMessage;
            actionCompleted = true;
        }
    }
}