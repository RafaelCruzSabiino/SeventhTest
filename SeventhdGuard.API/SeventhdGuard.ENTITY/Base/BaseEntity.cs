using System;
using System.Text.Json.Serialization;

namespace SeventhdGuard.ENTITY.Base
{
    public class BaseEntity
    {
        #region "Properties"

        public string   Id         { get; set; }

        [JsonIgnore]
        public DateTime DateAlter  { get; set; }

        [JsonIgnore]
        public DateTime DateInsert { get; set; }

        #endregion

        #region "Construct"

        public BaseEntity() 
        {
            DateAlter  = DateTime.Now;
            DateInsert = DateTime.Now;
        }

        #endregion
    }
}
