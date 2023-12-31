using AutoMapper;
using LNDP_API.Dtos;
using LNDP_API.Filters;
using LNDP_API.Models;
using LNDP_API.Repositories;
using LNDP_API.Utils;

namespace LNDP_API.Services
{
    public class SocialNetworkService : GenericService<SocialNetwork>, ISocialNetworkService
    {
        private readonly ISocialNetworkRepository _socialNetworkRepository;
        public SocialNetworkService(ISocialNetworkRepository socialNetworkRepository, IUriService uriService) : base(socialNetworkRepository, null, uriService)
        {
            _socialNetworkRepository = socialNetworkRepository;
        }
    }
}
