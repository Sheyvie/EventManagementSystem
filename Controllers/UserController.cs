using AutoMapper;
using EventManagement.Models;
using EventManagement.Requests;
using EventManagement.Responses;
using EventManagement.Services.Iservices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;

namespace EventManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        

        public UserController(IUserService service, IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _userService = service;
            _config = configuration;
        }

        [HttpPost]
        public async Task<ActionResult<SuccessResponse>> AddUser(AddUser addUser)
        {
           
            var newUser = _mapper.Map<Users>(addUser);
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(addUser.Password);
            //newUser.Role = "Admin";
            var res = await _userService.RegisterUser(newUser);
            return CreatedAtAction(nameof(AddUser), new SuccessResponse(201, res));
        }
        [HttpPost("Login")]
        public async Task<ActionResult<SuccessResponse>> AddUser(LoginUser logUser)
        {

            //check if user with that email exists

            var existingUser = await _userService.GetUserByEmailAsync(logUser.Email);
            if (existingUser == null)
            {
                return NotFound("Invalid Credential");
            }
            //users exists

            var isPasswordValid = BCrypt.Net.BCrypt.Verify(logUser.Password, existingUser.Password);
            if (!isPasswordValid)
            {
                return NotFound("Invalid Credential");
            }

            // if provided the right credentials
            //return Ok($"Welcome {existingUser.Name}");
            //create Token
            var token = CreateToken(existingUser);

            return Ok(token);


        }
        private string CreateToken(Users user)
        {
           // key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("TokenSecurity:SecretKey")));
            //Signing Credentials
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
           // payload - data

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Names", user.Name));
            claims.Add(new Claim("Sub", user.UserId.ToString()));
            claims.Add(new Claim("Role", user.Role));

            //create Token
            var tokenGenerated = new JwtSecurityToken(
                _config["TokenSecurity:Issuer"],
                _config["TokenSecurity:Audience"],
                signingCredentials: cred,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1)
                );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenGenerated);
            return token;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetAllUsers()
        {
            var response = await _userService.GetAllUsersAsync();
            var users = _mapper.Map<IEnumerable<UserResponse>>(response);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUser(Guid id)
        {
            var response = await _userService.GetUserByIdAsync(id);
            if (response == null)
            {
                return NotFound(new SuccessResponse(404, "User Does Not Exist"));
            }

            var user = _mapper.Map<UserResponse>(response);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SuccessResponse>> UpdateUser(Guid id, AddUser UpdatedUser)
        {
            var response = await _userService.GetUserByIdAsync(id);
            if (response == null)
            {
                return NotFound(new SuccessResponse(404, "User Does Not Exist"));
            }
            //update
            var updated = _mapper.Map(UpdatedUser, response);
            var res = await _userService.UpdateUserAsync(updated);
            return Ok(new SuccessResponse(204, res));
        }

        [HttpPost("Events/register")]
        public async Task<ActionResult<SuccessResponse>> RegisterUserForEvent([FromBody]BuyTicket registration)
        {
            try
            {
                var res = await _userService.BuyTicket(registration);
                return Ok(new SuccessResponse(204, res));
            }
            catch (Exception ex)
            {
                return BadRequest(new SuccessResponse(400, ex.Message));
            }

            

        }
        [Authorize(Policy = "AdminPolicy")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<SuccessResponse>> DeleteUser(Guid id)
        {
            var response = await _userService.GetUserByIdAsync(id);
            if (response == null)
            {
                return NotFound(new SuccessResponse(404, "User Does Not Exist"));
            }
            //delete

            var res = await _userService.DeleteUserAsync(response);
            return Ok(new SuccessResponse(204, res));
        }
    }
}
