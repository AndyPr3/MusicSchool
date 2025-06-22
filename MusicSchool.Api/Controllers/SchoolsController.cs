using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicSchool.Application.Commands.SchoolCommand;
using MusicSchool.Application.DTOs;
using MusicSchool.Application.Queries.SchoolQueries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SchoolsController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var data = await _mediator.Send(new GetAllSchoolQuery());
                return Ok(ApiResponse<List<SchoolDto>>.Ok(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<List<SchoolDto>>.Fail(400, $"Error found: {ex.Message}"));
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var data = await _mediator.Send(new GetByIdSchoolQuery(id));
                return Ok(ApiResponse<SchoolDto>.Ok(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<SchoolDto>.Fail(400, $"Error found: {ex.Message}"));
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SchoolCreateComand cmd)
        {
            try
            {
                var id = await _mediator.Send(cmd);
                return Ok(ApiResponse<object>.Ok(new { Message = "Se insertó correctamente" }));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<List<SchoolDto>>.Fail(400, $"Error found: {ex.Message}"));
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
