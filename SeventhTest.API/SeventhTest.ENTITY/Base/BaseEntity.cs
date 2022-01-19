using System;

namespace SeventhTest.ENTITY.Base
{
    public class BaseEntity
    {
        #region "Properties"

        public string   Id         { get; set; }
        public DateTime DateAlter  { get; set; }
        public DateTime DateInsert { get; set; }

        #endregion
    }
}
