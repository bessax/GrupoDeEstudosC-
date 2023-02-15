using ByteBank.API.Request;
using ByteBank.API.Services.Interfaces;
using ByteBank.API.Validator;
using ByteBank.API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ByteBank.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EnderecoAgenciaController : ControllerBase
{
    private readonly IEnderecoAgenciasService service;
    private readonly EnderecoAgenciaValidator validador;

    public EnderecoAgenciaController(IEnderecoAgenciasService _service)
    {
        this.service = _service;
        this.validador = new EnderecoAgenciaValidator();
    }

    // GET: api/EnderecoAgencias
    [HttpGet]
    public async Task<ActionResult<List<EnderecoAgenciaRequest>>> GetEnrecoAgencias()
    {
        var enderecoAgencia = await this.service.BuscaEnderecoAgenciasAsync();

        if (enderecoAgencia == null)
        {
            return this.NotFound("Não há dados a serem exibidos.");
        }

        return this.Ok(enderecoAgencia);
    }

    // POST: api/EnderecoAgencias
    [HttpPost]
    public async Task<ActionResult<EnderecoAgenciaViewModel>> PostEnderecoAgencia(EnderecoAgenciaRequest enderecoAgencia)
    {
        if (await this.service.BuscaEnderecoAgenciasAsync() == null)
        {
            return this.Problem("Não existe dados a serem retornados.");
        }
        
        var enderecoAgenciaCriada = await this.service.CriaEnderecoAgenciaAsync(enderecoAgencia);

        return this.Ok(enderecoAgenciaCriada);
    }
}