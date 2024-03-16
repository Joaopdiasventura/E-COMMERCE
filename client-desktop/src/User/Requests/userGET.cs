using client_desktop.User.Entities;
using client_desktop.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace client_desktop.User.Requests
{
    internal class userGET
    {
        public async Task<object> FindAdress(string cep)
        {
            HttpClient client = new HttpClient();
            string url = $"https://e-commerce-r4j0.onrender.com/adress/findAdress/{cep}";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                string jsonResponse = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Adress data = JsonConvert.DeserializeObject<Adress>(jsonResponse);
                    return data;
                }
                else
                {
                    Msg data = JsonConvert.DeserializeObject<Msg>(jsonResponse);
                    return data;
                }
            }
            catch (Exception ex)
            {
                Msg message = new Msg();
                message.msg = ex.Message;
                return message;
            }
        }

        public async Task<object> Decode(string token)
        {
            HttpClient client = new HttpClient();
            string url = $"https://e-commerce-r4j0.onrender.com/user/decode/{token}";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                string jsonResponse = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    UserEntity data = JsonConvert.DeserializeObject<UserEntity>(jsonResponse);
                    return data;
                }
                else
                {
                    Msg data = JsonConvert.DeserializeObject<Msg>(jsonResponse);
                    return data;
                }
            }
            catch (Exception ex)
            {
                Msg message = new Msg();
                message.msg = ex.Message;
                return message;
            }
        }
    }
}