namespace ByteBank.UnitTests.Application;

public class GetAgenciasByPageValidatorTest
{
    private readonly IValidator<GetAgenciasByPage> _validator;

    public GetAgenciasByPageValidatorTest()
    {
        _validator = new GetAgenciasByPageValidator();
    }

    [Fact]
    public void Validate_DeveRetornarSucesso()
    {
        var request = new GetAgenciasByPage(1, 10);

        var result = _validator.Validate(request);

        result.Should().NotBeNull();
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void Validate_QuandoNumeroDaPaginaForZero_DeveRetornarErro()
    {
        var request = new GetAgenciasByPage(0, 10);

        var result = _validator.Validate(request);

        result.Should().NotBeNull();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeNull();
        result.Errors.Should().HaveCount(1);
    }

    [Fact]
    public void Validate_QuandoNumeroDaPaginaForMenorQueZero_DeveRetornarErro()
    {
        var request = new GetAgenciasByPage(-1, 10);

        var result = _validator.Validate(request);

        result.Should().NotBeNull();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeNull();
        result.Errors.Should().HaveCount(1);
    }

    [Fact]
    public void Validate_QuandoQuantidadeDeItensPorPaginaForZero_DeveRetornarErro()
    {
        var request = new GetAgenciasByPage(1, 0);

        var result = _validator.Validate(request);

        result.Should().NotBeNull();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeNull();
        result.Errors.Should().HaveCount(1);
    }

    [Fact]
    public void Validate_QuandoQuantidadeDeItensPorPaginaForMenorQueZero_DeveRetornarErro()
    {
        var request = new GetAgenciasByPage(1, -1);

        var result = _validator.Validate(request);

        result.Should().NotBeNull();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeNull();
        result.Errors.Should().HaveCount(1);
    }
}