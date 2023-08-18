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
            Console.WriteLine("Teste");
            Console.ReadLine();
        }
    }
}
