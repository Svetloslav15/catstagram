namespace Catstagram.Server.Controllers
{
    using Catstagram.Server.Data;
    using Catstagram.Server.Data.Models;
    using Catstagram.Server.Infrastructure;
    using Catstagram.Server.Models.Cats;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class CatsController : ApiController
    {
        private readonly CatstagramDbContext dbContext;

        public CatsController(CatstagramDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCatRequestModel model)
        {
            string userId = this.User.GetId();

            Cat cat = new Cat
            {
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                UserId = userId
            };

            this.dbContext.Add(cat);
            await this.dbContext.SaveChangesAsync();

            return Created(nameof(this.Create), cat.Id);
        }
    }
}