using Microsoft.AspNetCore.Mvc;
using Scuola.Models.Dto.Request;
using Scuola.Models.Dto.Response;
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

        // lista studenti
        [HttpGet]
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

        // studente by id
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest();
                }

                var studente = await _studenteService.GetStudenteAsync(id);

                if (studente is null)
                {
                    return NotFound();
                }

                return Ok(studente);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // crea studente
        [HttpPost]
        public async Task<IActionResult> Create(CreateStudenteRequest request)
        {
            try
            {
                var result = await _studenteService.CreateStudenteAsync(request);

                if (result is null)
                {
                    return BadRequest();
                }

                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // update studente
        [HttpPut]
        public async Task<IActionResult> Update(UpdateStudenteRequest request)
        {
            try
            {
                if (request.Id == Guid.Empty)
                {
                    return BadRequest();
                }

                var result = await _studenteService.UpdateStudenteAsync(request);

                if (result is null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // elimina studente
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest();
                }

                bool result = await _studenteService.DeleteStudenteAsync(id);

                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}