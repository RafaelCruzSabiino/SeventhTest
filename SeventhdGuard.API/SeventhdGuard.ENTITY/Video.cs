using SeventhdGuard.ENTITY.Base;
using System.Text.Json.Serialization;

namespace SeventhdGuard.ENTITY
{
    public class Video : BaseEntity
    {
        #region "Properties"

        [JsonIgnore]
        public string IdServer    { get; set; }
        public string Description { get; set; }
        public int    SizeInBytes { get; set; }

        #endregion
    }
}
