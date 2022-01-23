using SeventhdGuard.ENTITY.Base;
using System.Text.Json.Serialization;

namespace SeventhdGuard.ENTITY
{
    public class Reciclar : BaseEntity
    {
        #region "Properties"

        [JsonIgnore]
        public string Type     { get; set; }

        [JsonIgnore]
        public int    Finished { get; set; }
        public string Status   { get; set; }

        #endregion
    }
}
