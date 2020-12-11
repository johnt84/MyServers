namespace MyServersWebApp.Model.Payment
{
    public class CardIdentifierInput
    {
        public Carddetails cardDetails { get; set; }

        public class Carddetails
        {
            public string cardholderName { get; set; }
            public string cardNumber { get; set; }
            public string expiryDate { get; set; }
            public string securityCode { get; set; }
        }
    }
}
