using Sistema_de_Gestão_Auxiliar_em_Condominios.DAL;

namespace Sistema_de_Gestão_Auxiliar_em_Condominios.Modelo
{
    public class Controle
    {
        public bool tem;
        public string mensagem = "";

        // Realiza auditoria na coleta de dados e na entrega
        public bool acessar(String Login, String Senha) 
        {
            LoginDALCommands loginDal = new LoginDALCommands();
            tem = loginDal.verificarLogin(Login, Senha);
            if (!loginDal.mensagem.Equals(""))
            {
                this.mensagem = loginDal.mensagem;
            }
            return tem;
        
        }
    }
}
