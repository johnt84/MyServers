using MaxMind.MinFraud;
using MaxMind.MinFraud.Request;
using MaxMind.MinFraud.Response;
using System;
using System.Net;

namespace MyServersWebApp.FraudCheck
{
    public partial class FraudCheckTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        protected async void btnFraudCheck_Click(object sender, EventArgs e)
        {
            var transaction = new Transaction(
               device: new MaxMind.MinFraud.Request.Device(
                   ipAddress: System.Net.IPAddress.Parse("185.192.70.22"), //167.86.81.56
                    sessionId: "61987098"//"62366459"
               ),
               userEvent:
               new Event
               (
                   transactionId: "4c2d92ee-499f-4f29-9a20-d39ab98ededb",//"2448b6a0-907e-44a3-a7c8-67fcf76cf4bc",
                   time: new DateTimeOffset(2020, 4, 26, 11, 33, 00, 433, new TimeSpan(0)),  //DateTimeOffset(2020, 5, 8, 14, 36, 40, 350, new TimeSpan(0)),
                   type: EventType.Purchase
               ),
               email:
               new MaxMind.MinFraud.Request.Email(
                   address: "omar@omakisoft.com",
                   domain: "omakisoft.com"
               ),
               billing:
                        new Billing(
                            firstName: "Omar",
                            lastName: "Kandili",
                            address: "Starlight, 2 Clos du Roi",
                            address2: "Ville au Roi",
                            city: "St. Peter Port",
                            region: null,
                            country: "GG",
                            postal: "GY1 1PB",
                            phoneNumber: "+447781122995",
                            phoneCountryCode: null
                        ),
               order:
               new Order(
                   amount: 251.03m,
                   currency: "GBP"
               )
           );

            Score score = null;

            using (var client = new WebServiceClient(92795, "5rIifZg7Dmni8orc"))
            {
                score = await client.ScoreAsync(transaction);
            }

            if(score != null)
            {
                lbRiskScore.Text = score.RiskScore.ToString();
                lbRiskEvaluation.Text = "Retrieved the score";
            }
        }
    }
}