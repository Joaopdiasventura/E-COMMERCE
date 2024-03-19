using client_desktop.Models;
using client_desktop.src.Product.Entities;
using client_desktop.src.User.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace client_desktop.Product.Requests
{
    internal class productPOST
    {
        public async Task<object> CreateProduct()
        {
            HttpClient client = new HttpClient();
            string url = $"https://e-commerce-r4j0.onrender.com/purchase";
            try
            {
                ShoppingCart Request = new ShoppingCart();
                string jsonRequest = JsonConvert.SerializeObject(Request);
                HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return null;
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
