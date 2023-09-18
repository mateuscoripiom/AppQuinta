using MySql.Data.MySqlClient;
using System;

namespace AppBanco
{
    public class Program
    {
        static void Main(string[] args)
        {
           
            UsuarioDAO ObjDao = new UsuarioDAO();
            Usuario objUsuario = new Usuario();

            Console.WriteLine("Informe o ID para identificação: ");
            objUsuario.IdUsu = int.Parse(Console.ReadLine());
            objUsuario.NomeUsu = ObjDao.SelectDado(objUsuario.IdUsu);

            Console.Clear();

            Console.WriteLine("Olá senhor(a) " + objUsuario.NomeUsu);

            Console.WriteLine("\n Vamos inserir um novo registro: ");
            Console.WriteLine("Digite o nome: ");
            objUsuario.NomeUsu = Console.ReadLine();

            Console.WriteLine("Digite o cargo: ");
            objUsuario.Cargo = Console.ReadLine();

            Console.WriteLine("Informe a data de nascimento: ");
            objUsuario.DataNasc = DateTime.Parse(Console.ReadLine());

            
            ObjDao.Insert(objUsuario);

            Console.WriteLine("\n");
            ObjDao.Select();

            Console.WriteLine("Digite o Id do registro a ser apagado: ");
            objUsuario.IdUsu = int.Parse(Console.ReadLine());
            ObjDao.Delete(objUsuario.IdUsu);

            Console.Clear();
            ObjDao.Select();

            Console.WriteLine("\n");
            Console.WriteLine("Vamos atualizar um registro: ");
            Console.WriteLine("\n");
            Console.WriteLine("Digite o nome: ");
            objUsuario.NomeUsu = Console.ReadLine();

            Console.WriteLine("Digite o cargo: ");
            objUsuario.Cargo = Console.ReadLine();

            Console.WriteLine("Informe a data de nascimento: ");
            objUsuario.DataNasc = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Id: ");
            objUsuario.IdUsu = int.Parse(Console.ReadLine());

            ObjDao.Update(objUsuario);
            ObjDao.Select();
            Console.ReadLine();
        }
    }
}
