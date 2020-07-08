using MyServersWebApp.Data;
using System;

namespace MyServersWebApp.Networking
{
    public partial class ReverseDns : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Reverse DNS";

            var reverseDnsService = new ReverseDnsService();

            rptReverseDns.DataSource = reverseDnsService.GetReverseDnsEntries();
            rptReverseDns.DataBind();
        }
    }
}