using Catstagram.Server.Data.Models;

namespace Catstagram.Server.Features.Identity
{
    public interface IIdentityService
    {
        string GenerateJwtToken(User user, string secret);
    }
}