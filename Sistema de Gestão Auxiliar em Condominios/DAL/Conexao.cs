using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sistema_de_Gestão_Auxiliar_em_Condominios.DAL
{
    public class Conexao
    {
        SqlConnection con = new SqlConnection();

        public Conexao() 
        {
            con.ConnectionString = @"Data Source=DESKTOP-DFKVC4V\SQLEXPRESS;Initial Catalog=sgc;Integrated Security=True;";
        }
        public SqlConnection conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        public void desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
