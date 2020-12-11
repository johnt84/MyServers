using System;

namespace MyServersWebApp.Model.Payment
{
    public class CardIdentifier
    {
        public string cardIdentifier { get; set; }
        public DateTime expiry { get; set; }
        public string cardType { get; set; }
    }
}
