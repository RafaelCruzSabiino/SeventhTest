using System;
using System.Collections.Generic;

namespace SeventhTest.ENTITY.Base
{
    public partial class ResultInfo
    {
        #region "Properties"

        public int       Id           { get; set; }
        public int       RowsAffected { get; set; }
        public bool      Success      { get; set; }
        public string    Message      { get; set; }
        public Exception Exception    { get; set; }

        public ResultInfo() 
        {
            Id           = 0;
            RowsAffected = 0;
            Success      = true;
            Message      = "Executado Com Sucesso!";
        }

        #endregion
    }

    public partial class ResultInfo<TEntity> : ResultInfo 
    {
        #region "Properties"

        public TEntity        Item  { get; set; }
        public IList<TEntity> Items { get; set; }

        #endregion
    }
}
