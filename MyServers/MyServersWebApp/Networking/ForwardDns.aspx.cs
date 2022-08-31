using MyServersWebApp.Data;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI;

namespace MyServersWebApp.Networking
{
    public partial class ForwardDns : System.Web.UI.Page
    {
        protected IForwardDnsService forwardDnsService;
        protected int timeoutInSeconds = 3;

        protected async void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Forward DNS";

            forwardDnsService = GlobalSettings.Container.GetInstance<IForwardDnsService>();

            //Page.RegisterAsyncTask(new PageAsyncTask(PopulatePageAsync));

            PopulatePage();
        }

        //private async Task PopulatePageAsync()
        //{
        //    var cancellationTokenSource = new CancellationTokenSource();
        //    cancellationTokenSource.CancelAfter(5000);

        //    rptForwardDns.DataSource = await forwardDnsService.GetForwardDnsDomainsAsync();
        //    rptForwardDns.DataBind();
        //}

        protected void PopulatePage()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(timeoutInSeconds * 1000);

            try
            {
                rptForwardDns.DataSource = forwardDnsService.GetForwardDnsDomains(cancellationTokenSource.Token);
                rptForwardDns.DataBind();
            }
            catch (TaskCanceledException tcex)
            {
                lbErrorMessage.Text = $"Could not retrieve the forwards DNS entires as the task took longer than {timeoutInSeconds} seconds";
            }
            catch (OperationCanceledException ocex)
            {
                lbErrorMessage.Text = $"Could not retrieve the forwards DNS entires as the operation took longer than {timeoutInSeconds} seconds";
            }
            finally
            {
                cancellationTokenSource.Dispose();  
            }
        }
    }
}