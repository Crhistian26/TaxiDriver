using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TaxiDriver.Domain.Entitys;
using TaxiDriver.Domain.Interfaces.Entities;
using TaxiDriver.Domain.Interfaces.Repositorys;
using TaxiDriver.Persistence.Repositories;
using TaxiDriver.Persistance.Exceptions;

namespace TaxiDriver.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository RoleRepository)
        {
            _roleRepository = RoleRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetRole()
        {
            try
            {
                List<Role> values = new List<Role>();

                values = _roleRepository.GetAll();

                if (values == null || values.Count == 0)
                {
                    return NotFound();
                }
                return Ok(values);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetRoleById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Te falto el Id para identificar el Rol");
                }
                Role role = new Role();
                role = _roleRepository.GetById(id);

                return Ok(role);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost("Post")]
        public IActionResult PostRole([FromBody] Role role)
        {
            try
            {
                if (role == null)
                {
                    return BadRequest("Falto el Role a agregar");
                }
                _roleRepository.Add(role);
                return CreatedAtAction(nameof(GetRoleById), new { id = role.Id }, role);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {error = ex.Message});
            }
        }

        [HttpPut("Put")]
        public IActionResult PutRole([FromBody] Role role)
        {
            try 
            { 
                if (role == null)
                {
                    return BadRequest("Falto el Role a modificar");
                }
                _roleRepository.Update(role);
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteRoleById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Se te olvido enviar el ID.");
                }
                _roleRepository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
