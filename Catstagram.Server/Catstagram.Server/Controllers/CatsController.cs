namespace Catstagram.Server.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class CatsController : ApiController
    {
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create()
        {

        }
    }
}