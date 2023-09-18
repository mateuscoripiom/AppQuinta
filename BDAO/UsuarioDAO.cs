using MySql.Data.MySqlClient;
using System;

namespace AppBanco
{
    public class UsuarioDAO
    {
        Banco db = new Banco();
        Usuario ObjUsuario = new Usuario();
        public void Insert(Usuario ObjUsuario)
        {
            string strInsert = string.Format("insert into tbUsuario(NomeUsu, Cargo, DataNasc)" +
                                             "values('{0}', '{1}', STR_TO_DATE('{2}', '%d/%m/%Y  %H:%i:%s'));", ObjUsuario.NomeUsu, ObjUsuario.Cargo, ObjUsuario.DataNasc);

            db.Open();
            db.ExecuteNowdSql(strInsert);
            db.Close();
        }

        public void Update(Usuario ObjUsuario)
        {
            db.Open();

            string strUpdate = string.Format("update tbUsuario set NomeUsu = '{0}', Cargo = '{1}', DataNasc = STR_TO_DATE('{2}', '%d/%m/%Y %H:%i:%s') where IdUsu = {3};",
                                            ObjUsuario.NomeUsu, ObjUsuario.Cargo, ObjUsuario.DataNasc, ObjUsuario.IdUsu);

            db.ExecuteNowdSql(strUpdate);
            db.Close();
        }

        public void Delete(int Id)
        {
            string strDelete = string.Format("delete from tbUsuario where IdUsu = {0}", Id);

            db.Open();
            db.ExecuteNowdSql(strDelete);
            db.Close();
        }

        public string SelectDado(int Id)
        {
            string strDado = ("select NomeUsu from tbUsuario where IdUsu = " + Id + ";");

            db.Open();
            strDado = db.ExecuteScalarSql(strDado);
            db.Close();

            return strDado;
        }

        public MySqlDataReader Select()
        {

            string strSelect = "select * from tbUsuario;";
            db.Open();

            MySqlDataReader leitor = db.ExecuteReadSql(strSelect);
            while (leitor.Read())
            {
                Console.WriteLine("Código = {0} | Nome= {1} | Cargo = {2} | Nascimento = {3}",
                    leitor["IdUsu"], leitor["NomeUsu"], leitor["Cargo"], leitor["DataNasc"]);
            }
            leitor.Close();
            db.Close();

            return leitor;
        }
    }
}
