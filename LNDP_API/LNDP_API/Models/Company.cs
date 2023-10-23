using LNDP_API.Models.Interfaces;

namespace LNDP_API.Models
{
    public class Company : ModelBase, IHasPhotoUrl
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public string WebUrl { get; set; }
        public CompanyType? CompanyType { get; set; }
        public int CompanyTypeId { get; set; }
    }
}