using SeventhTest.ENTITY.Base;

namespace SeventhTest.ENTITY
{
    public class Servidor : BaseEntity
    {
        #region "Properties"

        public string Nome     { get; set; }
        public string Endereco { get; set; }
        public int    Porta    { get; set; }

        #endregion
    }
}
