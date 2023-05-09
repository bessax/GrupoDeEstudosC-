namespace ByteBank.UnitTests.Application;

public class CreateAgenciaValidatorTest
{
    private readonly IValidator<CreateAgencia> _validator;

    public CreateAgenciaValidatorTest()
    {
        _validator = new CreateAgenciaValidator();
    }

    [Fact]
    public void Validate_ComTodosOsCamposValidos_DeveRetornarSucesso()
    {
        var request = new CreateAgencia(
            "Agencia 1",
            "Rua 1",
            "12345678",
            123,
            "Complemento 1");

        var result = _validator.Validate(request);

        result.Should().NotBeNull();
        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Validate_ComNomeInvalido_DeveRetornarFalha(string nome)
    {
        var request = new CreateAgencia(
            nome,
            "Rua 1",
            "12345678",
            123,
            "Complemento 1");

        var result = _validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == nameof(CreateAgencia.Nome));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Validate_ComLogradouroInvalido_DeveRetornarFalha(string logradouro)
    {
        var request = new CreateAgencia(
            "Agencia 1",
            logradouro,
            "12345678",
            123,
            "Complemento 1");

        var result = _validator.Validate(request);

        result.Should().NotBeNull();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == nameof(CreateAgencia.Logradouro));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Validate_ComCepInvalido_DeveRetornarFalha(string cep)
    {
        var request = new CreateAgencia(
            "Agencia 1",
            "Rua 1",
            cep,
            123,
            "Complemento 1");

        var result = _validator.Validate(request);

        result.Should().NotBeNull();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == nameof(CreateAgencia.Cep));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Validate_ComNumeroInvalido_DeveRetornarFalha(int numero)
    {
        var request = new CreateAgencia(
            "Agencia 1",
            "Rua 1",
            "12345678",
            numero,
            "Complemento 1");

        var result = _validator.Validate(request);

        result.Should().NotBeNull();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == nameof(CreateAgencia.Numero));
    }

    [Fact]
    public void Validate_ComComplementoNulo_DeveRetornarSucesso()
    {
        var request = new CreateAgencia(
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
    public void Validate_ComTodosOsCamposInvalidos_DeveRetornarFalha()
    {
        var request = new CreateAgencia(
            "",
            "",
            "",
            0,
            "");

        var result = _validator.Validate(request);

        result.Should().NotBeNull();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == nameof(CreateAgencia.Nome));
        result.Errors.Should().Contain(e => e.PropertyName == nameof(CreateAgencia.Logradouro));
        result.Errors.Should().Contain(e => e.PropertyName == nameof(CreateAgencia.Cep));
        result.Errors.Should().Contain(e => e.PropertyName == nameof(CreateAgencia.Numero));
    }
}