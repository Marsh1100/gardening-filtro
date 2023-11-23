using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class RequestController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RequestController( IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<RequestDto>>> Get()
    {
        var results = await _unitOfWork.Requests.GetAllAsync();
        return _mapper.Map<List<RequestDto>>(results);
    }

    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RequestDto>> Post([FromBody] RequestDto dto)
    {
        var result = _mapper.Map<Request>(dto);
        this._unitOfWork.Requests.Add(result);
        await _unitOfWork.SaveAsync();


        if(result == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new{id=result.Id}, result);
    }


    [HttpPut()]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<RequestDto>> put(RequestDto dto)
    {
        if(dto == null){ return NotFound(); }
        var result = this._mapper.Map<Request>(dto);
        this._unitOfWork.Requests.Update(result);
        Console.WriteLine(await this._unitOfWork.SaveAsync());
        return Ok(result);
    }


    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.Requests.GetByIdAsync(id);
        if(result == null){return NotFound();}
        this._unitOfWork.Requests.Remove(result);
        await this._unitOfWork.SaveAsync();
        return NoContent();
    }

    //6.¿Cuántos pedidos hay en cada estado? Ordena el resultado de forma descendente por el número de pedidos.

    [HttpGet("quantityOfRequestDesc")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> GetQuantityOfRequestDesc()
    {
        var results = await _unitOfWork.Requests.GetQuantityOfRequestDesc();
        return Ok(results);
    }

}