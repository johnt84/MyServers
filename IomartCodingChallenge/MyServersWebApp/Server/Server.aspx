<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="Server.aspx.cs" Inherits="MyServersWebApp.Server.Server" %>

<asp:Content ID="PageBodyContent" ContentPlaceHolderID="MainContent" runat="Server">  
    <link rel="stylesheet" type="text/css" href="/Styles/jquery.dataTables.css">

    <%
    if(!serviceExists)
    { %>
        <div style="color:red; padding-top: 20px" padding-bottom: 20px">
            <ul>
                <li><asp:Label ID="lbErrorMessage" runat="server"></asp:Label></li>
            </ul>
        </div>
    <% 
    }
    %>

    <div id="divMain" style="width: 1024px; padding-bottom: 20px" runat="server">
        <h1 style="padding-top: 20px"><%= Page.Title %></h1>

        <h3>Monitoring</h3>
        <a href="/server/tests/?serviceid=<%# serviceID %>">Tests</a>
        <a href="/server/alerts/?serviceid=<%# serviceID %>">Alerts</a>

        <h3>Service Status</h3>

        <asp:Repeater ID="rptServerStatus" runat="server" ItemType="MyServersWebApp.MyServersApiSimulatorService.CurrentMonitorStatus">
                <HeaderTemplate>
                    <table id="datatableformat" class="table table-hover table-striped table-bordered no-wrap">
                        <thead>
                            <tr class="nowrap">
                                <th style="width: 95px">Status Code</th>
                                <th style="width: 125px">Test Name</th>
                                <th style="width: 125px">Bandwidth</th>
                                <th style="width: 125px">Test Arg 1</th>
                                <th style="width: 155px">Monitored Ip</th>
                                <th style="width: 95px">Last Updated</th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="nowrap">
                        <td>
                            <%# Item.StatusCode %>
                        </td>
                        <td>
                            <a href="/server/monitorhistory/?serviceid=<%# serviceID %>&testid=<%# Item.TestId %>"><%# Item.TestName %></a>
                        </td>
                        <td>
                            <a href="/server/bandwidth/?serviceid=<%# serviceID %>"><%# serverDetails.BandwidthUrlBase %></a>
                        </td>
                        <td>
                            <%# Item.TestArg1 %>
                        </td>
                        <td>
                            <%# Item.MonitoredIp %>
                        </td>
                        <td>
                            <%# Item.LastUpdated.ToString("dd-MMM-yyy") %>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                </table>
                </FooterTemplate>
            </asp:Repeater>

        <div class="left">
            <h3>Server Description</h3>

            <table>
                <tr>
			        <td>Your Reference:</td>
			        <td><asp:Label ID="lbYourReference" runat="server"></asp:Label></td>
		        </tr>
		        <tr>
			        <td>Location:</td>
			        <td><asp:Label ID="lbLocation" runat="server"></asp:Label></td>
		        </tr>
		        <tr>
			        <td>Primary IP:</td>
			        <td><asp:Label ID="lbPrimaryIP" runat="server"></asp:Label></td>
		        </tr>
	        </table>
        </div>
    </div>

    <a href="/server/serverlist">Back to Server List</a>

    <script type="text/javascript" charset="utf8" src="/Scripts/jquery.dataTables.min.js"></script>
    <script type="text/javascript">
        $("#datatableformat").dataTable({
            "bPaginate": false,
            "ordering": true
        });
    </script>
</asp:Content>