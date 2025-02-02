﻿using System;
using System.Collections.Generic;

namespace SeventhdGuard.ENTITY.Base
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

        #region "Public Methods"

        public void ExceptionMapper(Exception ex)
        {
            Exception = ex;
            Message   = ex.Message;
            Success   = false;
        }

        #endregion
    }

    public partial class ResultInfo<TEntity> : ResultInfo
    {
        #region "Properties"

        public TEntity              Item  { get; set; }
        public IEnumerable<TEntity> Items { get; set; }

        #endregion
    }
}
