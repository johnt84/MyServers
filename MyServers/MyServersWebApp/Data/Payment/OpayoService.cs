using MyServersWebApp.Model.Payment;
using Newtonsoft.Json;

namespace MyServersWebApp.Data.Payment
{
    public class OpayoService
    {
        private const string VENDOR_NAMR = "rapidswitch";
        private const string RAPIDSWITCH_SANDBOX_ACCOUNT = "H1GBUY2c36u8JH5U1AZpyx1CyRl0qpMWwUTrvWsdLHv8bR4vxj:X6RC9Fidgx9cvFH5SSy3kjQm5ny7u08I3QGyeFu42O4iUUDvnNszMK0ZVSVG5zyNi";
        private readonly OpayoAPIService opayoAPIService;

        public OpayoService()
        {
            opayoAPIService = new OpayoAPIService();
        }

        public string GenerateAuthorisationHeader()
        {
            return opayoAPIService.GenerateAuthorisationHeader("Basic", RAPIDSWITCH_SANDBOX_ACCOUNT);
        }
        
        public MskResponse GenerateMSK(string authorisationHeader)
        {
            var mskInput = new MskInput()
            {
                vendorName = VENDOR_NAMR,
            };

            string mskInputJson = JsonConvert.SerializeObject(mskInput);

            string mskInputResponseJson = opayoAPIService.PostToAPI(authorisationHeader, "merchant-session-keys", mskInputJson);

            if (string.IsNullOrEmpty(mskInputResponseJson))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<MskResponse>(mskInputResponseJson);
        }

        public CardIdentifier GenerateCardIdentifier(string merchantSessionKey, CardIdentifierInput cardIdenitfierInput)
        {
            string cardIdentifierInputJson = JsonConvert.SerializeObject(cardIdenitfierInput);

            string cardAuthorisationHeader = $"Bearer {merchantSessionKey}";

            string cardIdentifiersResponseJson = opayoAPIService.PostToAPI(cardAuthorisationHeader, "card-identifiers", cardIdentifierInputJson);

            if (string.IsNullOrEmpty(cardIdentifiersResponseJson))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<CardIdentifier>(cardIdentifiersResponseJson);
        }

        public TransactionResult ProcessTransaction(string authorisationHeader, TransactionInput trasanctionInput)
        {
            string transactionInputJson = JsonConvert.SerializeObject(trasanctionInput);

            string transactionResponseJson = opayoAPIService.PostToAPI(authorisationHeader, "transactions", transactionInputJson);

            if (string.IsNullOrEmpty(transactionResponseJson))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<TransactionResult>(transactionResponseJson);
        }
    }
}