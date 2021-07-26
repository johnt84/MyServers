<%@ Page Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ServerList.aspx.cs" Inherits="MyServersWebApp.ServerList" %>

<asp:Content ID="PageBodyContent" ContentPlaceHolderID="MainContent" runat="Server">  
    <link rel="stylesheet" type="text/css" href="/Styles/jquery.dataTables.css">

    <div style="width: 1024px; font-size: 14px;" runat="server">
        <h1 style="padding-top: 20px;"><%= Page.Title %></h1>
        <asp:Repeater ID="rptServerList" runat="server" ItemType="MyServersWebApp.Model.ServerInfo">
            <HeaderTemplate>
                <table id="datatableformat" class="table table-hover table-striped table-bordered no-wrap">
                    <thead>
                        <tr class="nowrap">
                            <th style="width: 85px">Service ID</th>
                            <th style="width: 90px">Service Type</th>
                            <th style="width: 65px">Primary IP</th>
                            <th style="width: 170px">Location</th>
                            <th style="width: 95px">Your Reference</th>
                            <th style="width: 60px">Status</th>
                            <th style="width: 80px">Is Suspended</th>
                        </tr>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="nowrap">
                    <td>
                        <a href="/server/server?serviceid=<%# Item.ServiceID %>"><%# Item.ServiceID %></a>
                    </td>
                    <td>
                        <%# Item.ServiceType %>
                    </td>
                    <td>
                        <%# Item.PrimaryIP %>
                    </td>
                    <td>
                        <%# Item.Location %>
                    </td>
                    <td>
                        <%# Item.YourReference %>
                    </td>
                    <td>
                        <%# Item.Status %>
                    </td>
                    <td>
                        <%# Item.Suspended ? "Yes" : "No"  %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
            </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>

    <script type="text/javascript" charset="utf8" src="/Scripts/jquery.dataTables.min.js"></script>
    <script type="text/javascript">
        $("#datatableformat").dataTable({
            "bPaginate": false,
            "ordering": true
        });
    </script>
</asp:Content>