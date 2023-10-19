using LNDP_API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LNDP_API.Models{
    public class YoutubeVideo : ModelBase {
        public string Name {get;set;}
        public string Url {get;set;}
    }
}