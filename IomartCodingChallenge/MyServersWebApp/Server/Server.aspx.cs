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
        protected bool isError;
        protected bool actionCompleted;

        protected void Page_Load(object sender, EventArgs e)
        {
            serviceID = Request.QueryString["serviceid"];

            Page.Title = $"Server Details - {serviceID}";

            if (string.IsNullOrEmpty(serviceID))
            {
                DisplayErrorMessage("Please provide a valid Service ID");
                divMain.Visible = false;
                return;
            }

            serverService = new ServerService();

            if (!Page.IsPostBack)
            {
                PopulatePage();

                if (string.IsNullOrEmpty(serverDetails.ServiceID))
                {
                    DisplayErrorMessage($"No server exists with the Service ID of {serviceID}");
                    divMain.Visible = false;
                    return;
                }
            }

            InitialisePage();
        }

        protected void btnSuspendServer_Click(object sender, EventArgs e)
        {
            string suspendResult = serverService.SuspendServer(serviceID, txtSuspensionReason.Text);

            if (!string.IsNullOrEmpty(suspendResult))
            {
                DisplayErrorMessage(suspendResult);
            }
            else
            {
                ActionCompleted("Server suspended successfully");
            }

            PopulatePage();
        }

        protected void btnUnsuspendServer_Click(object sender, EventArgs e)
        {
            string unsuspendResult = serverService.UnsuspendServer(serviceID);

            if(!string.IsNullOrEmpty(unsuspendResult))
            {
                DisplayErrorMessage(unsuspendResult);
            }
            else
            {
                ActionCompleted("Server unsuspended successfully");
            }

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

        private void InitialisePage()
        {
            lbErrorMessage.Text = string.Empty;
            lbInformationMesage.Text = string.Empty;

            isError = false;
            actionCompleted = false;
            divMain.Visible = true;
        }

        private void ActionCompleted(string informationMessage)
        {
            lbInformationMesage.Text = informationMessage;
            actionCompleted = true;
        }

        private void DisplayErrorMessage(string errorMessage)
        {
            lbErrorMessage.Text = errorMessage;
            isError = true;
        }
    }
}