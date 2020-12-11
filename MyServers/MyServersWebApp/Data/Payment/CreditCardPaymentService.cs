using MyServersWebApp.Model.Payment;
using static MyServersWebApp.Model.Payment.TransactionInput;

namespace MyServersWebApp.Data.Payment
{
    public class CreditCardPaymentService
    {
        private readonly OpayoService opayoService;

        public CreditCardPaymentService()
        {
            opayoService = new OpayoService();
        }

        public TransactionResult ProcessPayment(CreditCardPaymentInput creditCardPaymentInput)
        {
            string authorisationHeader = opayoService.GenerateAuthorisationHeader();

            var mskResponse = opayoService.GenerateMSK(authorisationHeader);

            var cardIdentifierInput = new CardIdentifierInput()
            {
                cardDetails = new CardIdentifierInput.Carddetails()
                {
                    cardholderName = creditCardPaymentInput.CardholderName,
                    cardNumber = creditCardPaymentInput.CardNumber,
                    expiryDate = creditCardPaymentInput.ExpiryDate,
                    securityCode = creditCardPaymentInput.SecurityCode,
                },
            };

            var cardIdentifier = opayoService.GenerateCardIdentifier(mskResponse.merchantSessionKey, cardIdentifierInput);

            var transactionInput = new TransactionInput()
            {
                paymentMethod = new Paymentmethod()
                {
                    card = new Card()
                    {
                        merchantSessionKey = mskResponse.merchantSessionKey,
                        cardIdentifier = cardIdentifier.cardIdentifier,
                    }
                },
                transactionType = "Payment",
                vendorTxCode = creditCardPaymentInput.VendorTxCode,
                amount = creditCardPaymentInput.Amount,
                currency = "GBP",
                customerFirstName = creditCardPaymentInput.CustomerFirstName,
                customerLastName = creditCardPaymentInput.CustomerLastName,
                billingAddress = new Billingaddress()
                {
                    address1 = creditCardPaymentInput.BillingAddress1,
                    city = creditCardPaymentInput.BillingCity,
                    postalCode = creditCardPaymentInput.BillingPostalCode,
                    country = creditCardPaymentInput.BillingCountry,
                },
                entryMethod = "Ecommerce",
                apply3DSecure = "Force",//"UseMSPSetting",
                applyAvsCvcCheck = "UseMSPSetting",
                description = creditCardPaymentInput.TransactionDescription,
                customerEmail = creditCardPaymentInput.CustomerEmail,
                customerPhone = creditCardPaymentInput.CustomerPhone,
                shippingDetails = new Shippingdetails()
                {
                    recipientFirstName = creditCardPaymentInput.ShippingRecipientFirstName,
                    recipientLastName = creditCardPaymentInput.ShippingRecipientLastName,
                    shippingAddress1 = creditCardPaymentInput.ShippingAddress1,
                    shippingCity = creditCardPaymentInput.ShippingCity,
                    shippingPostalCode = creditCardPaymentInput.ShippingPostalCode,
                    shippingCountry = creditCardPaymentInput.ShippingCountry,
                },
            };

            return opayoService.ProcessTransaction(authorisationHeader, transactionInput);
        }
    }
}