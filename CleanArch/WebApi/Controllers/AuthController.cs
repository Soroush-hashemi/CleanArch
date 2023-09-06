using Application.Command.Users.Create;
using Application.Command.Users.Edit;
using Application.Query.Users.GetByEmail;
using Application.Query.Users.GetById;
using Application.Query.Users.GetList;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.ViewModels.Users;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public AuthController(IMediator mediator, IMapper mapper, IConfiguration configuration)
    {
        _mediator = mediator;
        _mapper = mapper;
        _configuration = configuration;
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

    [HttpPost("Register")]
    public async Task<IActionResult> CreateUser(CreateUserCommand command)
    {
        var result = await _mediator.Send(command);
        var url = Url.Action(nameof(GetUser), "Auth", new { Id = result }, Request.Scheme);
        return Created(url, result);
    }

    [HttpPut]
    public async Task<IActionResult> EditUser(EditUserCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = await _mediator.Send(new GetUserByEmailQuery(email));
        if (user == null)
            return NotFound("کاربری با مشخصات وارد شده یافت نشد");

        if (user.Name != password)
            return NotFound("کاربری با مشخصات وارد شده یافت نشد");

        var claims = new List<Claim>()
            {
                new Claim("email",user.Email),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:SignInKey"]));
        var credential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["JwtConfig:Issuer"],
            audience: _configuration["JwtConfig:Audience"],
            claims: claims,
            expires: DateTime.Now.AddDays(4),
            signingCredentials: credential);

        var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
        return Ok(jwtToken);
    }
}