using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicSchool.Application.Commands.TeacherCommand;
using MusicSchool.Application.DTOs;
using MusicSchool.Application.Queries.TeacherQueries;

namespace MusicSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TeachersController(IMediator mediator) => _mediator = mediator;

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var data = await _mediator.Send(new GetAllTeacherQuery());
                return Ok(ApiResponse<List<TeacherDto>>.Ok(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<List<TeacherDto>>.Fail(400, $"Error found: {ex.Message}"));
            }

        }

        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var data = await _mediator.Send(new GetByIdTeacherQuery(id));
                return Ok(ApiResponse<TeacherDto>.Ok(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<TeacherDto>.Fail(400, $"Error found: {ex.Message}"));
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] TeacherCreateComand cmd)
        {
            try
            {
                var result = await _mediator.Send(cmd);
                return Ok(ApiResponse<object>.Ok(new { Message = "Se insertó correctamente" }));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<List<TeacherDto>>.Fail(400, $"Error found: {ex.Message}"));
            }
        }

        [HttpPost("Update")]
        public async Task<ActionResult> Update([FromBody] TeacherUpdateComand cmd)
        {
            try
            {
                var result = await _mediator.Send(cmd);
                return Ok(ApiResponse<object>.Ok(new { Message = "Se actualizo correctamente" }));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<List<TeacherDto>>.Fail(400, $"Error found: {ex.Message}"));
            }
        }

        [HttpPost("Delete")]
        public async Task<ActionResult> Delete([FromBody] TeacherDeleteCommand cmd)
        {
            try
            {
                var result = await _mediator.Send(cmd);
                return Ok(ApiResponse<object>.Ok(new { Message = "Se elimino correctamente" }));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<List<TeacherDto>>.Fail(400, $"Error found: {ex.Message}"));
            }
        }
    }
}
