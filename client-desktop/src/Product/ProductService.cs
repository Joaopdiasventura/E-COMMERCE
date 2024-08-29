using client_desktop.Models;
using client_web.src.services;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace client_desktop.src.Product
{
    internal class ProductService
    {
        Conection c = new Conection();

        public string CreateProduct(string name, float price, string description, string userEmail)
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
                    c.Conect();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Produto criado com sucesso!", "Sucesso");
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
    }
}
