using AspireApp.Core.Entities;
using AspireApp.Core.Interfaces;
using AspireApp.WebAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspireApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _service = userService;
            _mapper = mapper;
        }


        // GET: api/user/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {

            var user = await _service.GetAsync(id);
            if (user == null) NotFound();

            // Map User entity to UserDto
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);

        }

        // POST api/user
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto userDto)
        {
            // Map UserDto to User entity
            var user = _mapper.Map<User>(userDto);

            // Add the user
            await _service.AddAsync(user);

            // Return created response
            return CreatedAtAction(nameof(Get), new { id = user.Id }, userDto);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] UserDto userDto)
        {
            // Ensure the IDs match
            var user = _mapper.Map<User>(userDto);
            user.Id = id;

            await _service.UpdateAsync(user);
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
