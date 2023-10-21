using LNDP_API.Models;
using LNDP_API.Models.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LNDP_API.Models{
    public class YoutubeVideo : ModelBase, IHasUrl {
        public string Name {get;set;}
        public string Url {get;set;}
    }
}