using client_web.src.services;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using client_desktop.src.Product.Entities;
using client_desktop.Product.Entities;
using client_desktop.User.Entities;

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
        public List<ProductEntity> GetProducts()
        {
            List<ProductEntity> products = new List<ProductEntity>();
            string query = @"
        SELECT p.*
        FROM Product p
        LEFT JOIN Product_Purchase pp ON p.id = pp.fk_product_id
        WHERE pp.fk_product_id IS NULL
        ORDER BY p.name;
    ";

            try
            {
                c.Conect();

                using (MySqlCommand cmd = new MySqlCommand(query, c.con))
                {
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
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erro ao obter os produtos: " + e.Message, "Erro");
            }
            finally
            {
                c.Disconnect();
            }

            return products;
        }

        public string CreatePurchase(List<ProductEntity> products)
        {
            if (products == null || products.Count == 0)
            {
                return "Dados inválidos para criar a compra.";
            }

            float totalValue = 0.0f;
            foreach (var product in products)
            {
                totalValue += product.price;
            }

            if (totalValue > UserStatic.money)
            {
                return "Saldo insuficiente para a compra";
            }

            c.Conect();
            using (var transaction = c.con.BeginTransaction())
            {
                try
                {
                    string purchaseQuery = "INSERT INTO Purchase (value, fk_user_email) VALUES (@value, @fk_user_email)";
                    long purchaseId;

                    using (var purchaseCmd = new MySqlCommand(purchaseQuery, c.con, transaction))
                    {
                        purchaseCmd.Parameters.AddWithValue("@value", totalValue);
                        purchaseCmd.Parameters.AddWithValue("@fk_user_email", UserStatic.email);

                        purchaseCmd.ExecuteNonQuery();
                        purchaseId = purchaseCmd.LastInsertedId;
                    }
                    string productPurchaseQuery = "INSERT INTO Product_Purchase (fk_product_id, fk_purchase_id) VALUES (@fk_product_id, @fk_purchase_id)";

                    using (var productPurchaseCmd = new MySqlCommand(productPurchaseQuery, c.con, transaction))
                    {
                        foreach (var product in products)
                        {
                            productPurchaseCmd.Parameters.Clear();
                            productPurchaseCmd.Parameters.AddWithValue("@fk_product_id", product.id);
                            productPurchaseCmd.Parameters.AddWithValue("@fk_purchase_id", purchaseId);
                            productPurchaseCmd.ExecuteNonQuery();
                        }
                    }
                    string updateBuyerQuery = "UPDATE User SET money = money - @totalValue WHERE email = @buyerEmail";

                    using (var updateBuyerCmd = new MySqlCommand(updateBuyerQuery, c.con, transaction))
                    {
                        updateBuyerCmd.Parameters.AddWithValue("@totalValue", totalValue);
                        updateBuyerCmd.Parameters.AddWithValue("@buyerEmail", UserStatic.email);
                        updateBuyerCmd.ExecuteNonQuery();
                    }
                    string updateSellerQuery = @"
                UPDATE User u
                JOIN Product p ON u.email = p.fk_user_email
                SET u.money = u.money + @productValue
                WHERE p.id IN (SELECT fk_product_id FROM Product_Purchase WHERE fk_purchase_id = @purchaseId)";

                    using (var updateSellerCmd = new MySqlCommand(updateSellerQuery, c.con, transaction))
                    {
                        foreach (var product in products)
                        {
                            updateSellerCmd.Parameters.Clear();
                            updateSellerCmd.Parameters.AddWithValue("@productValue", product.price);
                            updateSellerCmd.Parameters.AddWithValue("@purchaseId", purchaseId);
                            updateSellerCmd.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                    return "Compra realizada com sucesso!";
                }
                catch (MySqlException e)
                {
                    transaction.Rollback();
                    MessageBox.Show("Erro ao criar a compra: " + e.Message, "Erro");
                    return "Erro ao criar a compra.";
                }
                finally
                {
                    c.Disconnect();
                }
            }
        }
    }
}
