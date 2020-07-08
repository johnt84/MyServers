<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForwardDns.aspx.cs" Inherits="MyServersWebApp.Networking.ForwardDns" %>

<asp:Content ID="PageBodyContent" ContentPlaceHolderID="MainContent" runat="Server">  
    <link rel="stylesheet" type="text/css" href="/Styles/jquery.dataTables.css">

    <div style="width: 1024px;" runat="server">
        <h1 style="padding-top: 20px;"><%= Page.Title %></h1>
        <asp:Repeater ID="rptForwardDns" runat="server" ItemType="MyServersWebApp.MyServersApiSimulatorService.HostedDomainInfo">
            <HeaderTemplate>
                <table id="datatableformat" class="table table-hover table-striped table-bordered no-wrap">
                    <thead>
                        <tr class="nowrap">
                            <th style="width: 70px">Domain Id</th>
                            <th style="width: 85px">Domain Name</th>
                            <th style="width: 80px">Hosting type</th>
                            <th style="width: 65px">Expiry date</th>
                            <th style="width: 65px">Primary NS</th>
                            <th style="width: 82px">Authority status</th>
                            <th style="width: 95px">Secondary transfer status</th>
                        </tr>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="nowrap">
                    <td>
                        <%# Item.DomainId %>
                    </td>
                    <td>
                        <%# Item.DomainName %>
                    </td>
                    <td>
                        <%# Item.HostingType %>
                    </td>
                    <td>
                        <%# Item.ExpiryDate?.ToString("dd-MMM-yyyy") ?? "" %>
                    </td>
                    <td>
                        <%# Item.PrimaryNS %>
                    </td>
                    <td>
                        <%# Item.AuthorityStatus %>
                    </td>
                    <td>
                        <%# Item.SecondaryTransferStatus %>
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