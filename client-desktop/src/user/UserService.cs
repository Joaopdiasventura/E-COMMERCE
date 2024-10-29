using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using client_desktop.Models;
using client_desktop.User.Entities;
using client_web.src.services;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

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

        public string Register(string email, string name, string password)
        {
            UserEntity user = findByEmail(email);
            if (user != null)
            {
                MessageBox.Show("Já existe um usuário com esse email", "Erro:");
                return null;
            }
            string q = "INSERT INTO `User` (`name`, `email`, `password`) VALUES (@name, @email, @password);";
            using (MySqlCommand cmd = new MySqlCommand(q, c.con))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);

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

        public UserEntity Login(string email, string password)
        {
            string q = "SELECT * FROM `User` WHERE `email` = @Email AND `password` = @Password";
            using (MySqlCommand cmd = new MySqlCommand(q, c.con))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                try
                {
                    c.Conect();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UserEntity user = new UserEntity
                            {
                                name = reader.GetString("name"),
                                email = reader.GetString("email"),
                                password = reader.GetString("password"),
                                money = reader.GetFloat("money"),
                                isAdm = reader.GetBoolean("isAdm")
                            };

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
                    MessageBox.Show("Erro ao realizar login", "Erro:" + e.Message.ToString());
                    Console.WriteLine(e.Message);
                    return null;
                }
                finally
                {
                    c.Disconnect();
                }
            }
        }
    }
}
