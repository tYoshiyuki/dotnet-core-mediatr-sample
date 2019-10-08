using DotNetCoreMediatrSample.Domain.Application.Commands;
using DotNetCoreMediatrSample.Domain.Application.Queries;
using DotNetCoreMediatrSample.Web.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotNetCoreMediatrSample.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> Get(string id)
        {
            var user = await _mediator.Send(new GetUserQuery(id));
            if (user == null) return BadRequest("データが存在しません");

            return new UserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.Name.FirstName,
                FamilyName = user.Name.FamilyName
            };
        }

        [HttpPost]
        public async Task<ActionResult<UserViewModel>> Create([FromBody] CreateUserViewModel user)
        {
            var created = await _mediator.Send(new CreateUserCommand(user.UserName, user.FirstName, user.FamilyName));
            return new UserViewModel
            {
                Id = created.Id,
                UserName = created.UserName,
                FirstName = created.Name.FirstName,
                FamilyName = created.Name.FamilyName
            };
        }
    }
}