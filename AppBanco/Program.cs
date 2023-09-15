using MySql.Data.MySqlClient;
using System;

namespace AppBanco
{
    class Program
    {
        static void Main(string[] args)
        {
           
            UsuarioDAO ObjDao = new UsuarioDAO();

            Console.WriteLine("Informe o ID para identificação: ");
            string IdUsu = Console.ReadLine();
            string strDado = ObjDao.SelectDado(IdUsu);
            Console.WriteLine("Olá senhor(a) " + strDado);

            Console.WriteLine("Digite o nome: ");
            string strNomeUsu = Console.ReadLine();

            Console.WriteLine("Digite o cargo: ");
            string strCargo = Console.ReadLine();

            Console.WriteLine("Informe a data de nascimento: ");
            string strDataNasc = Console.ReadLine();

            
            ObjDao.Insert(strNomeUsu, strCargo, strDataNasc);

            ObjDao.Select();

            Console.ReadLine();

        }
    }
}
