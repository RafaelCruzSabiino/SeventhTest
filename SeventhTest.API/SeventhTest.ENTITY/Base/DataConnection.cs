namespace SeventhTest.ENTITY.Base
{
    public class DataConnection
    {
        #region "Properties"

        public string Server   { get; set; }
        public string User     { get; set; }
        public string Password { get; set; }
        public string Base     { get; set; }

        #endregion

        #region "Construct"

        public DataConnection()
        {
            Server   = "localhost";
            User     = "root";
            Password = "rfc@1001";
            Base     = "SEVENTH_DGUARD";
        }

        #endregion

        #region "Public Methods"

        public string StrConnection()
        {
            return string.Format("Server={0};Database={1};Uid={2};Pwd={3};Port=3306", Server, Base, User, Password);
        }

        #endregion
    }
}
