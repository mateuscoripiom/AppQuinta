namespace AppBanco
{
    internal class UsuarioDAO
    {
        Banco db = new Banco();


        public void Insert(string strNomeUsu, string strCargo, string strDataNasc)
        {
            string strInsert = string.Format("insert into tbUsuario(NomeUsu, Cargo, DataNasc)" +
                                             "values('{0}', '{1}', STR_TO_DATE('{2}', '%d/%m/%Y'));", strNomeUsu, strCargo, strDataNasc);

            db.Open();
            db.ExecuteNowdSql(strInsert);
            db.Close();
        }

        public void Update(string strNomeUsu, string strCargo, string strDataNasc, string strIdUsu)
        {

            db.Open();
            string strUpdate = string.Format("update into tbUsuario(NomeUsu, Cargo, DataNasc)" +
                                             "values('{0}', '{1}', STR_TO_DATE('{2}', '%d/%m/%Y %H:%i:%s')" +
                                             "where IdUsu = {3};", strNomeUsu, strCargo, strDataNasc, strIdUsu);

            db.ExecuteNowdSql(strUpdate);
            db.Close();
        }

        public void Delete(string strIdUsu)
        {
            string strDelete = string.Format("delete from tbUsuario where IdUsu = {0}", strIdUsu);

            db.Open();
            db.ExecuteNowdSql(strDelete);
            db.Close();
        }

        public string SelectDado(string strIdUsu)
        {
            string strDado = "select NomeUsu from tbUsuario where IdUsu = " + strIdUsu + ";");

            db.Open();
            strDado = db.ExecuteScalarSql(strDado);
            db.Close();

            return strDado;
        }
    }
}
