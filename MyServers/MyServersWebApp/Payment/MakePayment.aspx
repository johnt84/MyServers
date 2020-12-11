<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="MakePayment.aspx.cs" Inherits="MyServersWebApp.Payment.MakePayment" %>

<asp:Content ID="PageBodyContent" ContentPlaceHolderID="MainContent" runat="Server"> 
    <asp:Button ID="btnMakePayment" runat="server" Text="Make Payment" OnClick="btnMakePayment_Click" OnClientClick="document.forms[0].target = '_blank';" />
    
    <div>
        Is 3DS Transaction: <label ID="lbIsA3DSTransaction" runat="server"></label><br />
        Transaction Status: <label ID="lbTransactionStatus" runat="server"></label><br />
        Transaction ID: <label ID="lbTransactionID" runat="server"></label><br />
        ACS URL: <label ID="lbACSURL" runat="server"></label><br />
        PA Req: <label ID="lbPaReq" runat="server"></label><br />
        AVS CVC Check Status: <label ID="lbAVSCvcCheckStatus" runat="server"></label><br />
        AVS CVC Check Address Status: <label ID="lbAVSCvcCheckAddressStatus" runat="server"></label><br />
        AVS CVC Check Postal Code Status: <label ID="lbAVSCvcCheckPostalCodeStatus" runat="server"></label><br />
        AVS CVC Check Security Code Status: <label ID="lbAVSCVCCheckSecurityCodeStatus" runat="server"></label><br />
    </div>
</asp:Content>
