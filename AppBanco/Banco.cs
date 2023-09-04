using MySql.Data.MySqlClient;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace AppBanco
{
    internal class Banco
    {
        private readonly MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        private readonly MySqlCommand cmd = new MySqlCommand();
        
        public void Open()
        {
            if(conexao.State == System.Data.ConnectionState.Closed)
                conexao.Open();
        }

        public void Close()
        {
            if(conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();
        }

        public MySqlDataReader ExecuteReadSql(string srtQuery)
        {
            cmd.CommandText = srtQuery;
            cmd.Connection = conexao;
            MySqlDataReader Leitor = cmd.ExecuteReader();
            return Leitor;
        }
        public void ExecuteNowdSql(string srtQuery)
        {
            cmd.CommandText = srtQuery;
            cmd.Connection = conexao;
            cmd.ExecuteNonQuery();
        }

        public string ExecuteScalarSql(string srtQuery)
        {
            cmd.CommandText = srtQuery;
            cmd.Connection = conexao;
            string strRetorno = Convert.ToString(cmd.ExecuteScalar());
            return strRetorno;
        }

    }
}
