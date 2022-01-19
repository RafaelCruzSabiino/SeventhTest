using MySql.Data.MySqlClient;
using SeventhTest.ENTITY.Base;
using System;

namespace SeventhTest.DAO.Base
{
    public class Connection
    {
        #region "Common Variables"

        private static string          _strConnection;
        private static MySqlConnection _objConnection;

        #endregion

        #region "Construct"

        public Connection() 
        {
            _strConnection = new DataConnection().StrConnection();
        }

        #endregion

        #region "Protected Methods"

        protected static void Connect() 
        {
            try
            {
                _objConnection                  = new MySqlConnection();
                _objConnection.ConnectionString = _strConnection;
                _objConnection.Open();
            }
            catch 
            {
                throw new Exception("Erro ao tentar se conectar ao banco!");
            }
        }

        protected static void CloseConnection() 
        {
            _objConnection.Close();
        }

        #endregion
    }
}
