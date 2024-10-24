using AspireApp.Core.Entities;
using AspireApp.Core.Interfaces;
using AspireApp.WebAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspireApp.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : BaseController<UserDto, User>
    {
        public UsersController(IService<UserDto, User> userService) : base(userService)
        {
        }

        [HttpPost]
        public override Task<ActionResult<UserDto>> AddAsync([FromBody] UserDto dto)
        {
            return base.AddAsync(dto);
        }

        // You can override or add custom actions here

    }
}
