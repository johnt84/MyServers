using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace MyServersWebApp.Data.Payment
{
    public class OpayoAPIService
    {
        public string PostToAPI(string authorisationHeader, string action, string json)
        {
            //Taken from https://www.opayolabs.co.uk/apis/pi
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("Authorization", authorisationHeader);

                var request = new HttpRequestMessage(HttpMethod.Post, $"https://pi-test.sagepay.com/api/v1/{action}");

                request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.SendAsync(request).Result;

                var rawResponse = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    return rawResponse;
                }
                else
                {
                    return $"Error:{rawResponse} status code{response.StatusCode}";
                }
            }
        }

        public string GenerateAuthorisationHeader(string authorisationType, string authorisationText)
        {
            byte[] textAsBytes = Encoding.UTF8.GetBytes(authorisationText);

            return $"{authorisationType} {Convert.ToBase64String(textAsBytes)}";
        }
    }
}