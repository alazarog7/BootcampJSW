using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserMicroservice.DataTransferObject;
using UserMicroservice.Entities;
using UserMicroservice.Repositoty;

namespace UserMicroservice.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;
        public UserController(IMapper mapper, IUserRepository userRepository, ILogger<UserController> logger)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _logger = logger;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create([FromBody] UserCreation UserCreation)
        {
            _logger.LogInformation("Creating...");
            User user = _mapper.Map<User>(UserCreation);

            _userRepository.CreateUser(user);

            UserResponse userResponse = _mapper.Map<UserResponse>(user);

            return Created(string.Empty, userResponse);
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUserById(int Id)
        {
            await _userRepository.DeleteUser(Id);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetUsersWithFilters([FromQuery] string Nickname = "", [FromQuery] string Name = "")
        {
            _logger.LogInformation("Executing...");
            return Ok(_mapper.Map<List<UserResponse>>(_userRepository.GetAll(Nickname, Name)));
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user is not null)
            {
                return Ok( _mapper.Map<UserResponse>(_userRepository.GetUserById(id)));
            } 
            else
            {
                return NotFound();
            }
        }


        [HttpPost("login")]
        public IActionResult Login(Credentials credentials)
        {
            User user = _mapper.Map<User>(credentials);
            User userAuthenticated = _userRepository.Authenticate(user);
            if (userAuthenticated is not null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MyLargeSecret@Key123456789"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                        
                        claims: new List<Claim>()
                        {
                            new Claim("id", userAuthenticated.Id.ToString()),
                            new Claim("nickname", userAuthenticated.Nickname)
                        },
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: signinCredentials);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { token = tokenString });
            }

            return Unauthorized();
        }

    }
}
