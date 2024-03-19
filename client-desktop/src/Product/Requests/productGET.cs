using System;
using System.Net.Http;
using System.Threading.Tasks;
using client_desktop.Models;
using client_desktop.Product.Entities;
using Newtonsoft.Json;

namespace client_desktop.Product.Requests
{
    public class productGET
    {
        public async Task<object> GetProducts()
        {
            HttpClient client = new HttpClient();
            string url = $"https://e-commerce-r4j0.onrender.com/product";
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
        public async Task<object> GetProduct(int id)
        {
            HttpClient client = new HttpClient();
            string url = $"https://e-commerce-r4j0.onrender.com/product/id/{id}";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                string jsonResponse = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    ProductEntity data = JsonConvert.DeserializeObject<ProductEntity>(jsonResponse);
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
