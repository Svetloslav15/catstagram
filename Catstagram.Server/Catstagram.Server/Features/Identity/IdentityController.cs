namespace Catstagram.Server.Features
{
    using Catstagram.Server.Data.Models;
    using Catstagram.Server.Features.Identity;
    using Catstagram.Server.Models.Identity;
    
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using System.Threading.Tasks;

    public class IdentityController : ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly ApplicationSettings appSettings;
        private readonly IIdentityService identityService;

        public IdentityController(
            UserManager<User> userManager,
            IOptions<ApplicationSettings> appSettings,
            IIdentityService identityService)
        {
            this.userManager = userManager;
            this.identityService = identityService;
            this.appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterUserRequestModel model)
        {
            User user = new User()
            {
                UserName = model.Username,
                Email = model.Email
            };

            IdentityResult result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<object>> Login(LoginUserRequestModel model)
        {
            User user = await this.userManager.FindByNameAsync(model.Username);

            if (user == null)
            {
                return Unauthorized();
            }

            bool passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);

            if (!passwordValid)
            {
                return Unauthorized();
            }

            return new
            {
                Token = this.identityService.GenerateJwtToken(user, this.appSettings.Secret)
            };
        }
    }
}