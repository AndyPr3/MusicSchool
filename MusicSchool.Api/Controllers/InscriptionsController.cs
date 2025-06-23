using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicSchool.Application.Commands.InscriptionCommand;
using MusicSchool.Application.DTOs;
using MusicSchool.Application.Queries.InscriptionQueries;

namespace MusicSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscriptionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public InscriptionsController(IMediator mediator) => _mediator = mediator;

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var data = await _mediator.Send(new GetAllInscriptionQuery());
                return Ok(ApiResponse<List<InscriptionDto>>.Ok(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<List<InscriptionDto>>.Fail(400, $"Error found: {ex.Message}"));
            }

        }

        [HttpGet("GetAllByTeacher")]
        public async Task<ActionResult> GetAllByTeacher(int teacherId)
        {
            try
            {
                var data = await _mediator.Send(new GetAllByTeacherQuery(teacherId));
                return Ok(ApiResponse<List<StudentWithSchoolDto>>.Ok(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<List<StudentWithSchoolDto>>.Fail(400, $"Error found: {ex.Message}"));
            }

        }

        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var data = await _mediator.Send(new GetByIdInscriptionQuery(id));
                return Ok(ApiResponse<InscriptionDto>.Ok(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<InscriptionDto>.Fail(400, $"Error found: {ex.Message}"));
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] InscriptionCreateComand cmd)
        {
            try
            {
                var result = await _mediator.Send(cmd);
                return Ok(ApiResponse<object>.Ok(new { Message = "Se insertó correctamente" }));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<List<InscriptionDto>>.Fail(400, $"Error found: {ex.Message}"));
            }
        }

        [HttpPost("Delete")]
        public async Task<ActionResult> Delete([FromBody] InscriptionDeleteCommand cmd)
        {
            try
            {
                var result = await _mediator.Send(cmd);
                return Ok(ApiResponse<object>.Ok(new { Message = "Se elimino correctamente" }));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<List<InscriptionDto>>.Fail(400, $"Error found: {ex.Message}"));
            }
        }
    }
}
