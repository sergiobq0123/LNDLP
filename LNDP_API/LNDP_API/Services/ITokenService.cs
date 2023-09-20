using LNDP_API.Models;

namespace LNDP_API.Services{
    public interface ITokenService{
        string CreateToken(User user);
        string ObtenerTipoDeUsuarioDesdeToken(string token);
        int ObtenerIdArtistaDesdeToken(string token);
    }
}