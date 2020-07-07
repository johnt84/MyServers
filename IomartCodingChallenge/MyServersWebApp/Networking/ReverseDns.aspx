<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReverseDns.aspx.cs" Inherits="MyServersWebApp.Networking.ReverseDns" %>

<asp:Content ID="PageBodyContent" ContentPlaceHolderID="MainContent" runat="Server">  
    <link rel="stylesheet" type="text/css" href="/Styles/jquery.dataTables.css">

    <div style="width: 1024px;" runat="server">
        <h1 style="padding-top: 20px;"><%= Page.Title %></h1>
        <asp:Repeater ID="rptReverseDns" runat="server" ItemType="MyServersWebApp.MyServersApiSimulatorService.ReverseDnsEntry">
            <HeaderTemplate>
                <table id="datatableformat" class="table table-hover table-striped table-bordered no-wrap">
                    <thead>
                        <tr class="nowrap">
                            <th style="width: 95px">IP Address</th>
                            <th style="width: 55px">Host Name</th>
                        </tr>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="nowrap">
                    <td>
                        <%# Item.IPAddress %>
                    </td>
                    <td>
                        <%# Item.HostName %>
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