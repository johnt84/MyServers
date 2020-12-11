<%@ Page Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FraudCheckTest.aspx.cs" Inherits="MyServersWebApp.FraudCheck.FraudCheckTest" %>

<asp:Content ID="PageBodyContent" ContentPlaceHolderID="MainContent" runat="Server">  
    <asp:Button ID="btnFraudCheck" Text="Run" runat="server" OnClick="btnFraudCheck_Click" />

    <br /><br />
    Risk Score: <asp:Label ID="lbRiskScore" runat="server"></asp:Label><br />
    Risk Evaluation: <asp:Label ID="lbRiskEvaluation" runat="server"></asp:Label>
</asp:Content>
