namespace Catstagram.Server.Features.Cats
{
    using Catstagram.Server.Data;
    using Catstagram.Server.Data.Models;
    using System.Threading.Tasks;

    public class CatService : ICatService
    {
        private readonly CatstagramDbContext dbContext;

        public CatService(CatstagramDbContext dbContext) => this.dbContext = dbContext;

        public async Task<string> Create(string imageUrl, string description, string userId)
        {
            Cat cat = new Cat
            {
                Description = description,
                ImageUrl = imageUrl,
                UserId = userId
            };

            this.dbContext.Add(cat);
            await this.dbContext.SaveChangesAsync();

            return cat.Id;
        }
    }
}