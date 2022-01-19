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
            Password = "";
            Base     = "seventh_dguard";
        }

        #endregion

        #region "Public Methods"

        public string StrConnection()
        {
            return string.Format("server={0};database={1};uid={2};pwd={3};port=3306", Server, Base, User, Password);
        }

        #endregion
    }
}
