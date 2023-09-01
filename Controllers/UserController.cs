using AutoMapper;
using EventManagement.Models;
using EventManagement.Requests;
using EventManagement.Responses;
using EventManagement.Services.Iservices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        //const int maxPageSize = 20;

        public UserController(IUserService service, IMapper mapper)
        {
            _mapper = mapper;
            _userService = service;

        }

        [HttpPost]
        public async Task<ActionResult<SuccessResponse>> AddUser(AddUser newUser)
        {

            var user = _mapper.Map<Users>(newUser);
            var res = await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(AddUser), new SuccessResponse(201, res));
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

        //[HttpPut("BuyTicket")]
        //public async Task<ActionResult<SuccessMessage>> buyCourse(BuyTicket buy)
        //{
        //    try
        //    {
        //        var res = await _userService.BuyTicket(buy);
        //        return Ok(new SuccessResponse(204, res));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new SuccessResponse(400, ex.Message));
        //    }

        //}

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
