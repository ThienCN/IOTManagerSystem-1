using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using IOTManagerSystem.Model;

namespace IOTManagerSystem.Repository
{
    public class AUTHENTICATIONRepository
    {
        // Add library Newtonsoft.Json
        const string apiKey = "ALgn1iv7kqOwdRQdil18qwpXlbyuf1B6";
        public static bool SendVerifySMS(string phone, string countryCode)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://api.authy.com");

                var postData = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("via","sms"),
                    new KeyValuePair<string, string>("phone_number",phone),
                    new KeyValuePair<string, string>("country_code",countryCode),
                    new KeyValuePair<string, string>("locale","vi"),
                    new KeyValuePair<string, string>("code_length",6 + string.Empty)
                };

                var content = new FormUrlEncodedContent(postData);
                var response = httpClient.PostAsync(string.Format("https://api.authy.com/protected/json/phones/verification/start?api_key={0}", apiKey), content).Result.Content.ReadAsStringAsync().Result;

                if (!string.IsNullOrEmpty(response))
                {
                    try
                    {
                        var result = JsonConvert.DeserializeObject<ResponseModel>(response);
                        //Console.WriteLine(result.message); //If have error
                        return result.success;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public static bool VerifySMSCode(string phone, string countryCode, string verifyCode)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://api.authy.com");
                var response = httpClient.GetStringAsync(string.Format("https://api.authy.com/protected/json/phones/verification/check?api_key={0}&phone_number={1}&country_code={2}&verification_code={3}&locale=vi", apiKey, phone, countryCode, verifyCode)).Result;
                if (!string.IsNullOrEmpty(response))
                {
                    try
                    {
                        var result = JsonConvert.DeserializeObject<ResponseModel>(response);
                        //Console.WriteLine(result.message); //If have error
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }

            return false;
        }
    }
}
