namespace MyServersWebApp.Model.Payment
{
    public class CreditCardPaymentInput
    {
        public string VendorTxCode { get; set; }
        public string CardholderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string SecurityCode { get; set; }
        public int Amount { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string BillingAddress1 { get; set; }
        public string BillingCity { get; set; }
        public string BillingPostalCode { get; set; }
        public string BillingCountry { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string TransactionDescription { get; set; }
        public string ShippingRecipientFirstName { get; set; }
        public string ShippingRecipientLastName { get; set; }
        public string ShippingAddress1 { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingPostalCode { get; set; }
        public string ShippingCountry { get; set; }
    }
}