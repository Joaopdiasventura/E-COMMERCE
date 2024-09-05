using client_web.src.services;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using client_desktop.src.Product.Entities;
using client_desktop.Product.Entities;

namespace client_desktop.src.Product
{
    internal class ProductService
    {
        Conection c = new Conection();

        public string CreateProduct(string name, float price, string description, string userEmail, int qnt)
        {
            string q = "INSERT INTO Product (name, price, description, fk_user_email) VALUES (@name, @price, @description, @fk_user_email)";
            using (MySqlCommand cmd = new MySqlCommand(q, c.con))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@fk_user_email", userEmail);

                try
                {
                    Console.WriteLine(cmd.Parameters.ToString());
                    c.Conect();
                    for (int i = 0; i < qnt; i++)
                    {
                        cmd.ExecuteNonQuery();
                    }
                    return "Produto criado com sucesso!";
                }
                catch (MySqlException e)
                {
                    MessageBox.Show("Erro ao criar o produto: " + e.Message, "Erro");
                    return "Erro ao criar o produto.";
                }
                finally
                {
                    c.Disconnect();
                }
            }
        }
        public List<ProductEntity> GetTop10Products()
        {
            List<ProductEntity> products = new List<ProductEntity>();
            string q = "SELECT * FROM Product ORDER BY name";

            using (MySqlCommand cmd = new MySqlCommand(q, c.con))
            {
                try
                {
                    c.Conect();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductEntity product = new ProductEntity
                            {
                                id = reader.GetInt32("id"),
                                name = reader.GetString("name"),
                                price = reader.GetFloat("price"),
                                description = reader.GetString("description")
                            };
                            products.Add(product);
                        }
                    }
                }
                catch (MySqlException e)
                {
                    MessageBox.Show("Erro ao obter os produtos: " + e.Message, "Erro");
                }
                finally
                {
                    c.Disconnect();
                }
            }

            return products;
        }
    }
}
