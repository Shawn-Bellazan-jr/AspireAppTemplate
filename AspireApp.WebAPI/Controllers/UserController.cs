using AspireApp.Core.Entities;
using AspireApp.Core.Interfaces;
using AspireApp.WebAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspireApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : GenericController<UserDto, User>
    {
        public UserController(IService<UserDto> userService) : base(userService)
        {
        }

        // You can override or add custom actions here
    }
}
