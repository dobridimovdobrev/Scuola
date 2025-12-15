using Microsoft.AspNetCore.Mvc;
using Scuola.Models.Entity;
using Scuola.Services;

namespace Scuola.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudenteController : ControllerBase
    {
        private readonly StudenteService _studenteService;

        public StudenteController(StudenteService studenteService)
        {
            _studenteService = studenteService;
        }

        [HttpGet(Name = "Studenti")]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                var studenti = await _studenteService.GetStudentiAsync();
                return Ok(studenti);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{Id:guid}")]
        public async Task<IActionResult> GetbyId(Guid Id)
        {
            try
            {

                if (Guid.Empty == Id)
                {
                    return BadRequest();
                }

                var studente = await _studenteService.GetStudenteAsync(Id);

                if (studente is null)
                {
                    return BadRequest();
                }
                return Ok(studente);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }











    }
}
