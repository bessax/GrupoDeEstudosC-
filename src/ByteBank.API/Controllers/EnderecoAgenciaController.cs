using ByteBank.API.Request;
using ByteBank.API.Services.Interfaces;
using ByteBank.API.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ByteBank.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class EnderecoAgenciaController : ControllerBase
{
    private readonly IEnderecoAgenciasService service;

    private readonly IValidator<EnderecoAgenciaRequest> validator;

    public EnderecoAgenciaController(IEnderecoAgenciasService _service, IValidator<EnderecoAgenciaRequest> _validator)
    {
        this.service = _service;
        this.validator = _validator;
    }

    // GET: api/EnderecoAgencias
    [HttpGet]
    public async Task<ActionResult<List<EnderecoAgenciaRequest>>> GetEnderecoAgencias()
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
        var validation = await validator.ValidateAsync(enderecoAgencia);

        if (!validation.IsValid)
        {
            return this.BadRequest(validation.ToDictionary());
        }

        if (await this.service.BuscaEnderecoAgenciasAsync() == null)
        {
            return this.Problem("Não existe dados a serem retornados.");
        }

        var enderecoAgenciaCriada = await this.service.CriaEnderecoAgenciaAsync(enderecoAgencia);

        return this.Ok(enderecoAgenciaCriada);
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<ActionResult<EnderecoAgenciaViewModel>> GetEnderecoAgenciaPorId(int id)
    {
        var enderecoAgencia = await service.BuscaEnderecoAgenciaPorIdAsync(id);
        if (enderecoAgencia == null)
        {
            return this.Problem("Não existe dados a serem retornados.");
        }
        return this.Ok(enderecoAgencia);
    }

    [HttpGet("paginado")]
    public async Task<ActionResult<EnderecoAgenciaViewModel>> GetEnderecoAgenciaPaginadosAsync(int pagina = 1, int tamanhoPagina = 10)
    {
        var enderecosAgencia = await service.EnderecoAgenciaPaginadoAsync(pagina,tamanhoPagina);
        if (enderecosAgencia == null)
        {
            return this.Problem("Não existe dados a serem retornados.");
        }
        return this.Ok(enderecosAgencia);
    }
}