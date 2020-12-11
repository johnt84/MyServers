namespace MyServersWebApp.Model.Payment
{
    public class TransactionResult
    {
        public string statusCode { get; set; }
        public string statusDetail { get; set; }
        public string transactionId { get; set; }
        public string transactionType { get; set; }
        public int retrievalReference { get; set; }
        public string bankResponseCode { get; set; }
        public string bankAuthorisationCode { get; set; }
        public Paymentmethod paymentMethod { get; set; }
        public Amount amount { get; set; }
        public string currency { get; set; }
        public Firecipient fiRecipient { get; set; }
        public string status { get; set; }
        public Avscvccheck avsCvcCheck { get; set; }
        public _3Dsecure _3DSecure { get; set; }
        public string acsTransId { get; set; }
        public string dsTranId { get; set; }
        public string acsUrl { get; set; }
        public string paReq { get; set; }
    }

    public class Paymentmethod
    {
        public Card card { get; set; }
    }

    public class Card
    {
        public string merchantSessionKey { get; set; }
        public string cardType { get; set; }
        public string lastFourDigits { get; set; }
        public string expiryDate { get; set; }
        public string cardIdentifier { get; set; }
        public bool reusable { get; set; }
        public bool save { get; set; }
    }

    public class Amount
    {
        public int totalAmount { get; set; }
        public int saleAmount { get; set; }
        public int surchargeAmount { get; set; }
    }

    public class Firecipient
    {
    }

    public class Avscvccheck
    {
        public string status { get; set; }
        public string address { get; set; }
        public string postalCode { get; set; }
        public string securityCode { get; set; }
    }

    public class _3Dsecure
    {
        public string status { get; set; }
    }
}
