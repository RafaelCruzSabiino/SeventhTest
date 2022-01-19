using SeventhTest.ENTITY.Base;

namespace SeventhTest.ENTITY
{
    public class Servidor : BaseEntity
    {
        #region "Properties"

        public string Name { get; set; }
        public string Ip   { get; set; }
        public int    Port { get; set; }

        #endregion
    }
}
