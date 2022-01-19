using System;

namespace SeventhTest.ENTITY.Base
{
    public class BaseEntity
    {
        #region "Properties"

        public int      Id            { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime DataInsercao  { get; set; }

        #endregion
    }
}
