using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection Conexao = new MySqlConnection(@"Server = Localhost; database = dbAppBanco; user = root; password = 12345678");
            Conexao.Open();

            Console.WriteLine("Digite o nome: ");
            string strNomeUsu = Console.ReadLine();

            Console.WriteLine("Digite o cargo: ");
            string strCargo = Console.ReadLine();

            Console.WriteLine("Informe a data de nascimento: ");
            string strDataNasc = Console.ReadLine();

            string strInsert = string.Format("insert into tbUsuario(NomeUsu, Cargo, DataNasc)" +
                                             "values('{0}', '{1}', STR_TO_DATE('{2}', '%d/%m/%Y'));", strNomeUsu, strCargo, strDataNasc);

            string strUpdate = "update tbUsuario set NomeUsu = 'João' where IdUsu = 4;";
            MySqlCommand ObjCommandU = new MySqlCommand(strUpdate, Conexao);
            ObjCommandU.ExecuteNonQuery();

            string strDelete = "delete from tbUsuario where IdUsu = 3;";
            MySqlCommand ObjCommandD = new MySqlCommand(strDelete, Conexao);
            ObjCommandD.ExecuteNonQuery();

            //string strInsert = "insert into tbUsuario(NomeUsu, Cargo, DataNasc) values ('Fulano', 'Aluno', '2023/05/10');";
            MySqlCommand ObjCommandI = new MySqlCommand(strInsert, Conexao);
            ObjCommandI.ExecuteNonQuery();

            string strSelect = "select * from tbUsuario;";
            MySqlCommand ObjCommand = new MySqlCommand(strSelect, Conexao);

            //ObjCommand.CommandText = "select * from tbUsuario;";
            //ObjCommand.CommandType = System.Data.CommandType.Text;
            //ObjCommand.Connection = Conexao;

            MySqlDataReader leitor = ObjCommand.ExecuteReader();

            while (leitor.Read())
            {
                Console.WriteLine("Código = {0} | Nome= {1} | Cargo = {2} | Nascimento = {3}",
                    leitor["IdUsu"], leitor["NomeUsu"], leitor["Cargo"],leitor["DataNasc"]);
            }
            leitor.Close();
            Console.ReadLine(); 

        }
    }
}
