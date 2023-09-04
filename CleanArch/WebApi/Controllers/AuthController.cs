using Application.Command.Users.Create;
using Application.Command.Users.Edit;
using Application.Query.Users.GetById;
using Application.Query.Users.GetList;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels.Users;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public AuthController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{Id}")] 
        public async Task<UserViewModel> GetUser(long Id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(Id));
            return _mapper.Map<UserViewModel>(user).AddLinks();
        }

        [HttpGet]
        public async Task<List<UserViewModel>> GetUsers()
        {
            var users = await _mediator.Send(new GetUserListQuery());
            return _mapper.Map<List<UserViewModel>>(users).AddLinks();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            var url = Url.Action(nameof(GetUser), "User", new { Id = result }, Request.Scheme);
            return Created(url, result);
        }

        [HttpPut]
        public async Task<IActionResult> EditUser(EditUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}