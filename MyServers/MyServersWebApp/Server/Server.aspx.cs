using MyServersWebApp.Data;
using MyServersWebApp.MyServersApiSimulatorService;
using System;
using System.Threading.Tasks;
using System.Web.UI;

namespace MyServersWebApp.Server
{
    public partial class Server : System.Web.UI.Page
    {
        protected string serviceID;
        protected ServerInfo serverDetails;
        private IServerService serverService;
        protected bool isError;
        protected bool actionCompleted;

        protected async void Page_Load(object sender, EventArgs e)
        {
            serviceID = Request.QueryString["serviceid"];

            Page.Title = $"Server Details - {serviceID}";

            if (string.IsNullOrEmpty(serviceID))
            {
                DisplayErrorMessage("Please provide a valid Service ID");
                divMain.Visible = false;
                return;
            }

            serverService = GlobalSettings.Container.GetInstance<IServerService>();

            Page.RegisterAsyncTask(new PageAsyncTask(PopulatePageAsync));

            InitialisePage();
        }

        protected async void btnSuspendServer_Click(object sender, EventArgs e)
        {
            string suspendResult = await serverService.SuspendServerAsync(serviceID, txtSuspensionReason.Text);

            if (!string.IsNullOrEmpty(suspendResult))
            {
                DisplayErrorMessage(suspendResult);
            }
            else
            {
                ActionCompleted("Server suspended successfully");
            }

            await PopulatePageAsync();
        }

        protected async void btnUnsuspendServer_Click(object sender, EventArgs e)
        {
            string unsuspendResult = await serverService.UnsuspendServerAsync(serviceID);

            if(!string.IsNullOrEmpty(unsuspendResult))
            {
                DisplayErrorMessage(unsuspendResult);
            }
            else
            {
                ActionCompleted("Server unsuspended successfully");
            }
        }

        private async Task PopulatePageAsync()
        {
            var serverStatuses = await serverService.GetServerStatusAsync(serviceID);

            if (!Page.IsPostBack)
            {
                if ((serverStatuses?.Count ?? 0) == 0)
                {
                    DisplayErrorMessage($"No server exists with the Service ID of {serviceID}");
                    divMain.Visible = false;
                    return;
                }
            }

            rptServerStatus.DataSource = serverStatuses;
            rptServerStatus.DataBind();

            serverDetails = await serverService.GetServerDetailsAsync(serviceID);

            if (!Page.IsPostBack)
            {
                if (string.IsNullOrEmpty(serverDetails.ServiceID))
                {
                    DisplayErrorMessage($"No server exists with the Service ID of {serviceID}");
                    divMain.Visible = false;
                    return;
                }
            }

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