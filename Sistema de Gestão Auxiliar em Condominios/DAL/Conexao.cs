using MySql.Data.MySqlClient;

namespace Sistema_de_Gestão_Auxiliar_em_Condominios.DAL
{
    public class Conexao
    {
        MySqlConnection con = new MySqlConnection();

        // String para abrir a conexão com o banco de dados
        public Conexao()
        {
            con.ConnectionString = "server = localhost; port = 3306; database = sgc; uid = root; password = 1234"; // String para abrir conexão com o banco de dados MySQL
            // String para abir a conexão com o banco de dados do MsSQL --> con.ConnectionString = @"Data Source=DESKTOP-DFKVC4V\SQLEXPRESS;Initial Catalog=sgc;Integrated Security=True;";
        }

        // Verifica se o banco de dados está fechado, se sim ele abre uma conexão com a database
        public MySqlConnection conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        // Verifica se o banco de dados está aberto, se sim ele fecha a conexão com a database
        public void desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
