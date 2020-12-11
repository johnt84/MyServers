namespace MyServersWebApp.Model.Payment
{
    public class TransactionInput
    {
        public Paymentmethod paymentMethod { get; set; }
        public string transactionType { get; set; }
        public string vendorTxCode { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
        public string customerFirstName { get; set; }
        public string customerLastName { get; set; }
        public Billingaddress billingAddress { get; set; }
        public string entryMethod { get; set; }
        public string apply3DSecure { get; set; }
        public string applyAvsCvcCheck { get; set; }
        public string description { get; set; }
        public string customerEmail { get; set; }
        public string customerPhone { get; set; }
        public Shippingdetails shippingDetails { get; set; }
        public Strongcustomerauthentication strongCustomerAuthentication { get; set; }

        public class Billingaddress
        {
            public string address1 { get; set; }
            public string city { get; set; }
            public string postalCode { get; set; }
            public string country { get; set; }
        }

        public class Shippingdetails
        {
            public string recipientFirstName { get; set; }
            public string recipientLastName { get; set; }
            public string shippingAddress1 { get; set; }
            public string shippingCity { get; set; }
            public string shippingPostalCode { get; set; }
            public string shippingCountry { get; set; }
        }

        public class Strongcustomerauthentication
        {
            public string website { get; set; }
            public string notificationURL { get; set; }
            public string browserIP { get; set; }
            public string browserAcceptHeader { get; set; }
            public bool browserJavascriptEnabled { get; set; }
            public bool browserJavaEnabled { get; set; }
            public string browserLanguage { get; set; }
            public string browserColorDepth { get; set; }
            public string browserScreenHeight { get; set; }
            public string browserScreenWidth { get; set; }
            public string browserTZ { get; set; }
            public string browserUserAgent { get; set; }
            public string challengeWindowSize { get; set; }
            public string requestSCAExemption { get; set; }
            public string transType { get; set; }
            public string threeDSRequestorDecReqInd { get; set; }
            public string acctID { get; set; }
            public string purchaseInstalData { get; set; }
            public Threedsrequestorauthenticationinfo threeDSRequestorAuthenticationInfo { get; set; }
            public Threedsrequestorpriorauthenticationinfo threeDSRequestorPriorAuthenticationInfo { get; set; }
            public Acctinfo acctInfo { get; set; }
            public Merchantriskindicator merchantRiskIndicator { get; set; }
        }

        public class Threedsrequestorauthenticationinfo
        {
            public string threeDSReqAuthData { get; set; }
            public string threeDSReqAuthMethod { get; set; }
            public string threeDSReqAuthTimestamp { get; set; }
        }

        public class Threedsrequestorpriorauthenticationinfo
        {
            public string threeDSReqPriorAuthData { get; set; }
            public string threeDSReqPriorAuthMethod { get; set; }
            public string threeDSReqPriorAuthTimestamp { get; set; }
            public string threeDSReqPriorRef { get; set; }
        }

        public class Acctinfo
        {
            public string chAccAgeInd { get; set; }
            public string chAccChange { get; set; }
            public string chAccChangeInd { get; set; }
            public string chAccDate { get; set; }
            public string chAccPwChange { get; set; }
            public string chAccPwChangeInd { get; set; }
            public string nbPurchaseAccount { get; set; }
            public string provisionAttemptsDay { get; set; }
            public string txnActivityDay { get; set; }
            public string txnActivityYear { get; set; }
            public string paymentAccAge { get; set; }
            public string paymentAccInd { get; set; }
            public string shipAddressUsage { get; set; }
            public string shipAddressUsageInd { get; set; }
            public string shipNameIndicator { get; set; }
            public string suspiciousAccActivity { get; set; }
        }

        public class Merchantriskindicator
        {
            public string deliveryEmailAddress { get; set; }
            public string deliveryTimeframe { get; set; }
            public string giftCardAmount { get; set; }
            public string giftCardCount { get; set; }
            public string giftCardCurr { get; set; }
            public string preOrderDate { get; set; }
            public string preOrderPurchaseInd { get; set; }
            public string reorderItemsInd { get; set; }
            public string shipIndicator { get; set; }
        }
    }
}





