namespace ByteBank.UnitTests.Application;

public class UpdateAgenciaValidatorTest
{
    private readonly IValidator<UpdateAgencia> _validator;

    public UpdateAgenciaValidatorTest()
    {
        _validator = new UpdateAgenciaValidator();
    }

    [Fact]
    public void Validate_DeveRetornarSucesso()
    {
        var request = new UpdateAgencia(
            1,
            "Agencia 1",
            "Rua 1",
            "12345678",
            123,
            "Complemento 1");

        var result = _validator.Validate(request);

        result.Should().NotBeNull();
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void Validate_ComNomeNulo_DeveRetornarFalha()
    {
        var request = new UpdateAgencia(
            1,
            null!,
            "Rua 1",
            "12345678",
            123,
            "Complemento 1");

        var result = _validator.Validate(request);

        result.Should().NotBeNull();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == nameof(request.Nome));
    }

    [Fact]
    public void Validate_ComNomeVazio_DeveRetornarFalha()
    {
        var request = new UpdateAgencia(
            1,
            string.Empty,
            "Rua 1",
            "12345678",
            123,
            "Complemento 1");

        var result = _validator.Validate(request);

        result.Should().NotBeNull();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == nameof(request.Nome));
    }

    [Fact]
    public void Validate_ComLogradouroNulo_DeveRetornarFalha()
    {
        var request = new UpdateAgencia(
            1,
            "Agencia 1",
            null!,
            "12345678",
            123,
            "Complemento 1");

        var result = _validator.Validate(request);

        result.Should().NotBeNull();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == nameof(request.Logradouro));
    }

    [Fact]
    public void Validate_ComLogradouroVazio_DeveRetornarFalha()
    {
        var request = new UpdateAgencia(
            1,
            "Agencia 1",
            string.Empty,
            "12345678",
            123,
            "Complemento 1");

        var result = _validator.Validate(request);

        result.Should().NotBeNull();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == nameof(request.Logradouro));
    }

    [Fact]
    public void Validate_ComCepNulo_DeveRetornarFalha()
    {
        var request = new UpdateAgencia(
            1,
            "Agencia 1",
            "Rua 1",
            null!,
            123,
            "Complemento 1");

        var result = _validator.Validate(request);

        result.Should().NotBeNull();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == nameof(request.Cep));
    }

    [Fact]
    public void Validate_ComCepVazio_DeveRetornarFalha()
    {
        var request = new UpdateAgencia(
            1,
            "Agencia 1",
            "Rua 1",
            string.Empty,
            123,
            "Complemento 1");

        var result = _validator.Validate(request);

        result.Should().NotBeNull();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == nameof(request.Cep));
    }

    [Fact]
    public void Validate_ComNumeroZero_DeveRetornarFalha()
    {
        var request = new UpdateAgencia(
            1,
            "Agencia 1",
            "Rua 1",
            "12345678",
            0,
            "Complemento 1");

        var result = _validator.Validate(request);

        result.Should().NotBeNull();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == nameof(request.Numero));
    }

    [Fact]
    public void Validate_ComNumeroNegativo_DeveRetornarFalha()
    {
        var request = new UpdateAgencia(
            1,
            "Agencia 1",
            "Rua 1",
            "12345678",
            -1,
            "Complemento 1");

        var result = _validator.Validate(request);

        result.Should().NotBeNull();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == nameof(request.Numero));
    }

    [Fact]
    public void Validate_ComComplementoNulo_DeveRetornarSucesso()
    {
        var request = new UpdateAgencia(
            1,
            "Agencia 1",
            "Rua 1",
            "12345678",
            123,
            null);

        var result = _validator.Validate(request);

        result.Should().NotBeNull();
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void Validate_ComComplementoVazio_DeveRetornarSucesso()
    {
        var request = new UpdateAgencia(
            1,
            "Agencia 1",
            "Rua 1",
            "12345678",
            123,
            string.Empty);

        var result = _validator.Validate(request);

        result.Should().NotBeNull();
        result.IsValid.Should().BeTrue();
    }
}