using MySql.Data.MySqlClient;
using System;

namespace AppBanco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Banco db = new Banco();
            UsuarioDAO ObjDao = new UsuarioDAO();
            db.Open();

            MySqlConnection Conexao = new MySqlConnection(@"Server = Localhost; database = dbAppBanco; user = root; password = 12345678");
            Conexao.Open();

            Console.WriteLine("Digite o nome: ");
            string strNomeUsu = Console.ReadLine();

            Console.WriteLine("Digite o cargo: ");
            string strCargo = Console.ReadLine();

            Console.WriteLine("Digite o Id: ");
            string strIdUsu = Console.ReadLine();

            Console.WriteLine("Informe a data de nascimento: ");
            string strDataNasc = Console.ReadLine();

            db.Open();
            ObjDao.Insert(strNomeUsu, strCargo, strDataNasc);
            
            string strUpdate = "update tbUsuario set NomeUsu = 'João' where IdUsu = 4;";
            db.ExecuteNowdSql(strUpdate);

            string strDelete = "delete from tbUsuario where IdUsu = 3;";
            db.ExecuteNowdSql(strDelete);
            db.Close();

            db.Open();
            string strSelect = "select * from tbUsuario;";
 


            //ObjCommand.CommandText = "select * from tbUsuario;";
            //ObjCommand.CommandType = System.Data.CommandType.Text;
            //ObjCommand.Connection = Conexao;

            MySqlDataReader leitor = db.ExecuteReadSql(strSelect);
            while (leitor.Read())
            {
                Console.WriteLine("Código = {0} | Nome= {1} | Cargo = {2} | Nascimento = {3}",
                    leitor["IdUsu"], leitor["NomeUsu"], leitor["Cargo"],leitor["DataNasc"]);
            }
            leitor.Close();

            Console.WriteLine("Informe o ID para identificação: ");
            string IdUsu = Console.ReadLine();
            string strSelectId = "select NomeUsu from tbUsuario where IdUsu =" + IdUsu + ";";
            string strDado = db.ExecuteScalarSql(strSelectId);
            Console.WriteLine("Olá senhor(a) " + strDado);


            db.Open();
            Console.ReadLine(); 

        }
    }
}
