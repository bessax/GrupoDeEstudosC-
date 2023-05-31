namespace ByteBank.UnitTests.ApplicationTests;

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
        // Arrange
        var request = new GetAgenciasByPage(1, 10);

        // Act
        var result = _validator.Validate(request);

        // Assert
        result.Should().NotBeNull();
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void Validate_QuandoNumeroDaPaginaForZero_DeveRetornarErro()
    {
        // Arrange
        var request = new GetAgenciasByPage(0, 10);

        // Act
        var result = _validator.Validate(request);

        // Assert
        result.Should().NotBeNull();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeNull();
        result.Errors.Should().HaveCount(1);
    }

    [Fact]
    public void Validate_QuandoNumeroDaPaginaForMenorQueZero_DeveRetornarErro()
    {
        // Arrange
        var request = new GetAgenciasByPage(-1, 10);

        // Act
        var result = _validator.Validate(request);

        // Assert
        result.Should().NotBeNull();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeNull();
        result.Errors.Should().HaveCount(1);
    }

    [Fact]
    public void Validate_QuandoQuantidadeDeItensPorPaginaForZero_DeveRetornarErro()
    {
        // Arrange
        var request = new GetAgenciasByPage(1, 0);

        // Act
        var result = _validator.Validate(request);

        // Assert
        result.Should().NotBeNull();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeNull();
        result.Errors.Should().HaveCount(1);
    }

    [Fact]
    public void Validate_QuandoQuantidadeDeItensPorPaginaForMenorQueZero_DeveRetornarErro()
    {
        // Arrange
        var request = new GetAgenciasByPage(1, -1);

        // Act
        var result = _validator.Validate(request);

        // Assert
        result.Should().NotBeNull();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeNull();
        result.Errors.Should().HaveCount(1);
    }
}