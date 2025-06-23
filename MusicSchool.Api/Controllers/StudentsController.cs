using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicSchool.Application.Commands.StudentCommand;
using MusicSchool.Application.DTOs;
using MusicSchool.Application.Queries.StudentQueries;

namespace MusicSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentsController(IMediator mediator) => _mediator = mediator;

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var data = await _mediator.Send(new GetAllStudentQuery());
                return Ok(ApiResponse<List<StudentDto>>.Ok(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<List<StudentDto>>.Fail(400, $"Error found: {ex.Message}"));
            }

        }

        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var data = await _mediator.Send(new GetByIdStudentQuery(id));
                return Ok(ApiResponse<StudentDto>.Ok(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<StudentDto>.Fail(400, $"Error found: {ex.Message}"));
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] StudentCreateComand cmd)
        {
            try
            {
                var result = await _mediator.Send(cmd);
                return Ok(ApiResponse<object>.Ok(new { Message = "Se insertó correctamente" }));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<List<StudentDto>>.Fail(400, $"Error found: {ex.Message}"));
            }
        }

        [HttpPost("Update")]
        public async Task<ActionResult> Update([FromBody] StudentUpdateComand cmd)
        {
            try
            {
                var result = await _mediator.Send(cmd);
                return Ok(ApiResponse<object>.Ok(new { Message = "Se actualizo correctamente" }));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<List<StudentDto>>.Fail(400, $"Error found: {ex.Message}"));
            }
        }

        [HttpPost("Delete")]
        public async Task<ActionResult> Delete([FromBody] StudentDeleteCommand cmd)
        {
            try
            {
                var result = await _mediator.Send(cmd);
                return Ok(ApiResponse<object>.Ok(new { Message = "Se elimino correctamente" }));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<List<StudentDto>>.Fail(400, $"Error found: {ex.Message}"));
            }
        }
    }
}
