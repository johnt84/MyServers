using MyServersWebApp.Data.Payment;
using MyServersWebApp.Model.Payment;
using System;
using System.Web.UI.HtmlControls;

namespace MyServersWebApp.Payment
{
    public partial class MakePayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnMakePayment_Click(object sender, EventArgs e)
        {
            var creditCardPaymentService = new CreditCardPaymentService();

            var creditCardPaymentInput = new CreditCardPaymentInput()
            {
                VendorTxCode = Guid.NewGuid().ToString(),
                CardholderName = "Card Holder",
                CardNumber = "4929000000006", //"4929000000006" : "4929000005559"
                ExpiryDate = "1120",
                SecurityCode = "123",
                Amount = 2000,
                CustomerFirstName = "Sam",
                CustomerLastName = "Jones",
                BillingAddress1 = "88 St. John Street",
                BillingCity = "London",
                BillingPostalCode = "412",
                BillingCountry = "GB",
                CustomerEmail = "test.emaili@domain.com",
                CustomerPhone = "0845 111 4455",
                TransactionDescription = "Testing",
                ShippingRecipientFirstName = "Sam",
                ShippingRecipientLastName = "Jones",
                ShippingAddress1 = "407 St John Street",
                ShippingCity = "London",
                ShippingPostalCode = "EC1V 4AB",
                ShippingCountry = "GB",
            };

            var transactionResult = creditCardPaymentService.ProcessPayment(creditCardPaymentInput);

            bool isA3DSTransaction = transactionResult.status == "3DAuth";

            lbIsA3DSTransaction.InnerText = isA3DSTransaction ? "Yes" : "No";
            lbTransactionStatus.InnerText = transactionResult.status;

            if (isA3DSTransaction)
            {
                lbTransactionID.InnerText = transactionResult.transactionId;
                lbACSURL.InnerText = transactionResult.acsUrl;
                lbPaReq.InnerText = transactionResult.paReq;
            }
            else
            {
                lbAVSCvcCheckStatus.InnerText = transactionResult.avsCvcCheck.status;
                lbAVSCvcCheckAddressStatus.InnerText = transactionResult.avsCvcCheck.address;
                lbAVSCvcCheckPostalCodeStatus.InnerText = transactionResult.avsCvcCheck.postalCode;
                lbAVSCVCCheckSecurityCodeStatus.InnerText = transactionResult.avsCvcCheck.securityCode;
            }

            ShowAppropriateFields(isA3DSTransaction);

            if (isA3DSTransaction)
            {
                string acsUrl = transactionResult.acsUrl.Replace("pareq", transactionResult.paReq);
                Response.Redirect(transactionResult.acsUrl.Replace("pareq", transactionResult.paReq));
                //var iframe = new HtmlGenericControl("iframe");
                //iframe.Attributes["src"] = Page.ResolveClientUrl("~/Payment/ValidatePayment.aspx") +
                //    $"?PaReq={transactionResult.paReq}&ACSURL={acsUrl}";
                //iframe.Attributes["class"] = "Card3DSecure";
                //ph3DSecure.Controls.Add(iframe);
            }
        }

        private void ShowAppropriateFields(bool isA3DSTransaction)
        {
            lbTransactionID.Visible = isA3DSTransaction;
            lbACSURL.Visible = isA3DSTransaction;
            lbPaReq.Visible = isA3DSTransaction;
            lbAVSCvcCheckStatus.Visible = !isA3DSTransaction;
            lbAVSCvcCheckAddressStatus.Visible = !isA3DSTransaction;
            lbAVSCvcCheckPostalCodeStatus.Visible = !isA3DSTransaction;
            lbAVSCVCCheckSecurityCodeStatus.Visible = !isA3DSTransaction;
        }
    }
}