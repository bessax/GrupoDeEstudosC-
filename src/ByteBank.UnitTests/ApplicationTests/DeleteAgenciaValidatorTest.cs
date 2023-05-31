namespace ByteBank.UnitTests.ApplicationTests;

public class DeleteAgenciaValidatorTest
{
    private readonly IValidator<DeleteAgencia> _validator;

    public DeleteAgenciaValidatorTest()
    {
        _validator = new DeleteAgenciaValidator();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Validate_ComIdInvalido_DeveRetornarFalha(int id)
    {
        // Arrange
        var request = new DeleteAgencia(id);

        // Act
        var result = _validator.Validate(request);

        // Assert
        result.Should().NotBeNull();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == nameof(DeleteAgencia.Id));
    }

    [Fact]
    public void Validate_ComIdValido_DeveRetornarSucesso()
    {
        // Arrange
        var request = new DeleteAgencia(1);

        // Act
        var result = _validator.Validate(request);

        // Assert
        result.Should().NotBeNull();
        result.IsValid.Should().BeTrue();
    }
}