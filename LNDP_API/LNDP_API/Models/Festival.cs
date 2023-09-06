using System.ComponentModel.DataAnnotations.Schema;
using LNDP_API.Models;

namespace LNDP_API.Models {
    public class Festival : Event{
        public ICollection<Artist>? Artists {get; set;} 
    }
}