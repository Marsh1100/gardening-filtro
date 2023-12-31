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
public class ClientController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClientController( IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<ClientDto>>> Get()
    {
        var results = await _unitOfWork.Clients.GetAllAsync();
        return _mapper.Map<List<ClientDto>>(results);
    }

    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClientDto>> Post([FromBody] ClientDto dto)
    {
        var result = _mapper.Map<Client>(dto);
        this._unitOfWork.Clients.Add(result);
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

    public async Task<ActionResult<ClientDto>> put(ClientDto dto)
    {
        if(dto == null){ return NotFound(); }
        var result = this._mapper.Map<Client>(dto);
        this._unitOfWork.Clients.Update(result);
        Console.WriteLine(await this._unitOfWork.SaveAsync());
        return Ok(result);
    }


    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.Clients.GetByIdAsync(id);
        if(result == null){return NotFound();}
        this._unitOfWork.Clients.Remove(result);
        await this._unitOfWork.SaveAsync();
        return NoContent();
    }

    //3.Devuelve el nombre de los clientes que han hecho pagos y el nombre de sus representantes junto con la ciudad de la oficina a la que pertenece el representante.
    [HttpGet("clientsWithPaymentsAndSeller")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> GetClientsWithPaymentsAndSeller()
    {
        var results = await _unitOfWork.Clients.GetClientsWithPaymentsAndSeller();
        return Ok(results);
    }

    //8.Devuelve un listado que muestre solamente los clientes que no han realizado ningún pago.
     [HttpGet("clientsWithoutPayments")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClientDto>>> GetClientsWithoutPayments()
    {
        var results = await _unitOfWork.Clients.GetClientsWithoutPayments();
        return _mapper.Map<List<ClientDto>>(results);
    }

    //9.Devuelve el listado de clientes donde aparezca el nombre del cliente, el nombre y primer apellido de su representante de ventas y la ciudad donde está su oficina.
    [HttpGet("clientsWithSellerAndOffice")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClientDto>>> GetClientsWithSellerAndOffice()
    {
        var results = await _unitOfWork.Clients.GetClientsWithSellerAndOffice();
        return Ok(results);
    }


    //10.Devuelve el nombre del cliente, el nombre y primer apellido de su representante de ventas y el número de teléfono de la oficina del representante de ventas, de aquellos clientes que no hayan realizado ningún pago.
    [HttpGet("clientsWithoutPaymentsWithSellerAndOffice")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClientDto>>> GetClientsWithoutPaymentsWithSellerAndOffice()
    {
        var results = await _unitOfWork.Clients.GetClientsWithoutPaymentsWithSellerAndOffice();
        return Ok(results);
    }

}