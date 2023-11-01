using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaWeb.ConnectionStrings
{
    public abstract class DB_Conection
    {
        protected String Conexao;

        public DB_Conection()
        {
            Conexao = "Data Source = DESKTOP-SG2A3Q6\\SQLEXPRESS; User Id=administrador; Password=270921; Database=DB_SistemaDeCadastros; MultipleActiveResultSets=true; Max Pool Size=99999999;";
        }
    }
}