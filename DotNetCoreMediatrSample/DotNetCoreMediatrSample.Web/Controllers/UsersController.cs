using DotNetCoreMediatrSample.Domain.Application.Commands;
using DotNetCoreMediatrSample.Domain.Application.Models;
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
        public async Task<UserModel> Get(string id)
        {
            return await _mediator.Send(new GetUserQuery(id));
        }

        [HttpPost]
        public async Task Create([FromBody] CreateUserViewModel user)
        {
            await _mediator.Send(new CreateUserCommand(user.UserName, user.FirstName, user.FamilyName));
        }
    }
}