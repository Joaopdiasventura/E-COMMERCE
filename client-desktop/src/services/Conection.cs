using MySql.Data.MySqlClient;

namespace client_web.src.services
{
    public class Conection
    {
        public MySqlConnection con = new MySqlConnection(@"server=localhost;port=3306;Database=ecommerce;User=root;Pwd=");

        public string Conect()
        {
            try
            {
                con.Open();
                return "Conexão realizada com sucesso";
            }
            catch (MySqlException e)
            {
                return e.ToString();
            }
        }

        public string Disconnect()
        {
            try
            {
                con.Close();
                return "Conexão encerrada com sucesso";
            }
            catch (MySqlException e)
            {
                return e.ToString();
            }
        }

    }

}