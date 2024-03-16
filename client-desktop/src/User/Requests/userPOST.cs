using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using client_desktop.Models;
using client_desktop.src.User.Entities;
using client_desktop.User.Dto_s;
using Newtonsoft.Json;

namespace client_desktop.user.Requests
{
    internal class userPOST
    {
        public async Task<object> Register(string email, string name, string password, string adress)
        {
            HttpClient client = new HttpClient();
            var userDto = new createUserDto(email, name, password, adress);
            string url = "https://e-commerce-r4j0.onrender.com/user/register";

            try
            {
                string jsonRequest = JsonConvert.SerializeObject(userDto);
                HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    TokenEntity data = JsonConvert.DeserializeObject<TokenEntity>(jsonResponse);
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
        public async Task<object> Login(string email, string password){
            HttpClient client = new HttpClient();
            var userDto = new loginUserDto(email, password);
            string url = "https://e-commerce-r4j0.onrender.com/user/login";

            try
            {
                string jsonRequest = JsonConvert.SerializeObject(userDto);
                HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    TokenEntity data = JsonConvert.DeserializeObject<TokenEntity>(jsonResponse);
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