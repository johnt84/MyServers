<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyServersWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>My Servers Web App</h2>

    <ul>
        <li>View the list of servers using the <a href="Server/ServerList">Server List page</a></li>
        <li>View the list of Forward DNS Entries using the <a href="Networking/ForwardDNS">Forward Dns page</a></li>
        <li>View the list of Reverse DNS Entries using the <a href="Networking/ReverseDNS">Reverse DNS page</a></li>
    </ul>

</asp:Content>
