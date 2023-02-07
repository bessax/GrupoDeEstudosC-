using ByteBank.API.Interface;
using ByteBank.API.Models;
using ByteBank.API.Services;

using Microsoft.AspNetCore.Mvc;

namespace ByteBank.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EnderecoAgenciaController : ControllerBase
{
    private readonly IEnderecoAgenciaRepository repository;

    public EnderecoAgenciaController(IEnderecoAgenciaRepository _repository)
    {
        this.repository = _repository;
    }

    // GET: api/Agencias
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EnderecoAgencia>>> GetEnrecoAgencias()
    {
        var enderecoAgencia = await this.repository.BuscaTodosAsync();

        if (enderecoAgencia == null)
        {
            return this.NotFound();
        }

        return enderecoAgencia;
    }

}
