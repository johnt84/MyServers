using MyServersWebApp.Data;
using System;

namespace MyServersWebApp.Networking
{
    public partial class ReverseDns : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Reverse DNS";

            var reverseDnsService = GlobalSettings.Container.GetInstance<IReverseDnsService>();

            rptReverseDns.DataSource = await reverseDnsService.GetReverseDnsEntries();
            rptReverseDns.DataBind();
        }
    }
}