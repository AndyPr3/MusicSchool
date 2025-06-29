﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicSchool.Application.Commands.SchoolCommand;
using MusicSchool.Application.DTOs;
using MusicSchool.Application.Queries.SchoolQueries;

namespace MusicSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SchoolsController(IMediator mediator) => _mediator = mediator;

        [HttpGet("GetAll")]
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

        [HttpGet("GetById")]
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

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] SchoolCreateComand cmd)
        {
            try
            {
                var result = await _mediator.Send(cmd);
                return Ok(ApiResponse<object>.Ok(new { Message = "Se insertó correctamente" }));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<List<SchoolDto>>.Fail(400, $"Error found: {ex.Message}"));
            }
        }

        [HttpPost("Update")]
        public async Task<ActionResult> Update([FromBody] SchoolUpdateComand cmd)
        {
            try
            {
                var result = await _mediator.Send(cmd);
                return Ok(ApiResponse<object>.Ok(new { Message = "Se actualizo correctamente" }));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<List<SchoolDto>>.Fail(400, $"Error found: {ex.Message}"));
            }
        }

        [HttpPost("Delete")]
        public async Task<ActionResult> Delete([FromBody] SchoolDeleteCommand cmd)
        {
            try
            {
                var result = await _mediator.Send(cmd);
                return Ok(ApiResponse<object>.Ok(new { Message = "Se elimino correctamente" }));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<List<SchoolDto>>.Fail(400, $"Error found: {ex.Message}"));
            }
        }
    }
}
