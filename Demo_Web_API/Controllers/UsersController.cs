using Demo_Web_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo_Web_API.Models;
using Demo_Web_API.Authorization_Helpers;
using Demo_Web_API.Entities;

namespace Demo_Web_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [Authorize]
        [HttpPost("todos")]
        public IActionResult GetUserTodos(UserDTO user)
        {
            try
            {
                Guid userID = Guid.Parse(user.Id);
                var usersTodos = _userService.GetUserToDos(userID);
                return Ok(usersTodos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [Authorize]
        [HttpPost("add-todo")]
        public IActionResult AddToDo(ToDoDTO toDo)
        {
            try
            {
                var newToDo = _userService.AddToDo(toDo);
                return Ok(newToDo);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [Authorize]
        [HttpPut("todo/update")]
        public IActionResult EditTodo(ToDoDTO toDo)
        {
            try
            {
                var newToDo = _userService.EditTodo(toDo);
                return Ok(newToDo);
            }
            catch (Exception)
            {
                throw;
              //  return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Authorize]
        [HttpDelete("todo/delete")]
        public IActionResult DeleteTodo(ToDoDTO toDo)
        {
            try
            {
                var response = _userService.deleteToDo(toDo);
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
