using Application.Interfaces;
using Application.Models;
using Application.Services;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TPI_Laboratorio3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            try
            {
                return Ok(_userService.GetUsers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById([FromRoute] int id)
        {
            try
            {
                return Ok(_userService.GetUserById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("name/{name}")]
        public ActionResult<User> GetUserByName([FromRoute] string name)
        {
            try
            {
                return Ok(_userService.GetUserByName(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("type/{type}")]
        public ActionResult<User> GetUserByType([FromRoute] UserType type)
        {
            try
            {
                return Ok(_userService.GetUserByType(type));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public void UpdateUser([FromBody] User user)
        {
            _userService.UpdateUser(user);
        }

        [HttpDelete("/{id}")]
        public void DeleteUser([FromRoute] int id)
        {
            _userService.DeleteUser(id);
        }

        [HttpPut("/{id}")]
        public void ActiveUser([FromRoute] int id)
        {
            _userService.ActiveUser(id);
        }

        [HttpPost]
        public User CreateUser([FromBody] User user)
        {
            return _userService.CreateUser(user);
        }
    }
}
