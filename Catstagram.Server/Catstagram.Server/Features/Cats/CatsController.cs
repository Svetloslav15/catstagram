namespace Catstagram.Server.Features
{
    using Catstagram.Server.Features.Cats;
    using Catstagram.Server.Infrastructure;
    using Catstagram.Server.Models.Cats;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class CatsController : ApiController
    {
        private readonly ICatService catService;

        public CatsController(ICatService catService)
        {
            this.catService = catService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCatRequestModel model)
        {
            string userId = this.User.GetId();

            string id = await this.catService.Create(model.ImageUrl, model.Description, userId);

            return Created(nameof(this.Create), id);
        }
    }
}