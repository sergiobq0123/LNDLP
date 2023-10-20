using System.ComponentModel.DataAnnotations;

namespace LNDP_API.Models {
    public class ModelBase {
        [Key]
        public int Id {get ; set ; }
    }
}