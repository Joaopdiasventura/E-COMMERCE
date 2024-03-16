using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using client_desktop.Models;
using client_desktop.Product.Entities;
using client_desktop.User.Entities;
using Newtonsoft.Json;

namespace client_desktop.Product.Requests
{
    internal class productGET
    {
        public async Task<object> GetProducts(string cep)
        {
            HttpClient client = new HttpClient();
            string url = $"https://e-commerce-r4j0.onrender.com/adress/findAdress/{cep}";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                string jsonResponse = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    ProductEntity[] data = JsonConvert.DeserializeObject<ProductEntity[]>(jsonResponse);
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
