using MySql.Data.MySqlClient;

namespace Sistema_de_Gestão_Auxiliar_em_Condominios.DAL
{
    internal class LoginDALCommands
    {

        public bool tem = false;
        public String mensagem = "";
        MySqlCommand cmd = new MySqlCommand();
        Conexao con = new Conexao();
        MySqlDataReader dr;
        public bool verificarLogin(string login, string senha)
        {
            // Valida os dados de login e senha na database
            cmd.CommandText = "select * from usuario where login = @login and senha = @senha";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);
            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    tem = true;
                }
            }
            // Exceção para caso ocorra erro de comunicação com a database
            catch (MySqlException)
            {
                this.mensagem = "Erro com banco de dados";
            }
            return tem;
        }
    }
    
}
