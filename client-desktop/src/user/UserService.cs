using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using client_desktop.Models;
using client_desktop.src.User.Entities;
using client_desktop.User.Dto_s;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using client_web.src.services;
using client_desktop.User.Entities;
using System.Windows.Forms;

namespace client_desktop.user.service
{
    internal class UserService
    {
        Conection c = new Conection();

        public UserEntity findByEmail(string email)
        {
            string q = "SELECT * FROM `User` WHERE `email` = @Email";
            using (MySqlCommand cmd = new MySqlCommand(q, c.con))
            {
                cmd.Parameters.AddWithValue("@Email", email);

                try
                {
                    c.Conect();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UserEntity user = new UserEntity();

                            user.name = reader.GetString("name");
                            user.email = reader.GetString("email");
                            user.password = reader.GetString("password");
                            user.adress = reader.GetString("adress");
                            user.money = reader.GetFloat("money");
                            user.isAdm = reader.GetBoolean("isAdm");
                            
                            return user;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
                finally
                {
                    c.Disconnect();
                }
            }
        }


        public string Register(string email, string name, string password, string address)
        {
            UserEntity user = findByEmail(email);
            if (user != null)
            {
                MessageBox.Show("Já existe um usuário com esse email", "Erro:");
                return null;
            }
            string q = "INSERT INTO `User` (`name`, `email`, `password`, `adress`) VALUES (@name, @email, @password, @adress);";
            using (MySqlCommand cmd = new MySqlCommand(q, c.con))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@adress", address);

                try
                {
                    c.Conect();
                    cmd.ExecuteNonQuery();
                    return "Usuário Criado Com Sucesso";
                }
                catch (MySqlException e)
                {
                    MessageBox.Show("ERRO AO CRIAR USUÁRIO");
                    Console.WriteLine(e.Message);
                    return null;
                }
                finally
                {
                    c.Disconnect();
                }
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