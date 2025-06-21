using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TaxiDriver.Domain.Entitys;
using TaxiDriver.Domain.Interfaces.Entities;
using TaxiDriver.Persistence.Repositories;

namespace TaxiDriver.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleRepository _roleRepository;
        public RoleController()
        {
            _roleRepository = new RoleRepository();
        }

        [HttpGet("GetAll")]
        public IActionResult GetRole()
        {
            List<Role> values = new List<Role>();

            values = _roleRepository.GetAll();

            if(values == null || values.Count == 0)
            {
                return NotFound();
            }
            return Ok(values);
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetRoleById(int id)
        {
            Role role = new Role();
            role = _roleRepository.GetById(id);

            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPost]
        public IActionResult PostRole([FromBody] Role role)
        {
            _roleRepository.Add(role);
            return CreatedAtAction(nameof(GetRole), new { id = role.Id }, role);
        }

        [HttpPut]
        public IActionResult PutRole([FromBody] Role role)
        {
            _roleRepository.Update(role);
            return NoContent();
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteRoleById(int id)
        {
            _roleRepository.Delete(id);
            return NoContent();
        }
    }
}
