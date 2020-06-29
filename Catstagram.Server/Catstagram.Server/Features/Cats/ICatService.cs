namespace Catstagram.Server.Features.Cats
{
    using System.Threading.Tasks;

    public interface ICatService
    {
        public Task<string> Create(string imageUrl, string description, string userId);
    }
}