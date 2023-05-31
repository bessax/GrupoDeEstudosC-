namespace ByteBank.UnitTests.ApplicationTests;

public class GetAllAgenciasValidatorTest
{
    private readonly IValidator<GetAgencias> _validator;

    public GetAllAgenciasValidatorTest()
    {
        _validator = new GetAgenciasValidator();
    }

    [Fact]
    public void Validate_DeveRetornarSucesso()
    {
        // Arrange
        var request = new GetAgencias();

        // Act
        var result = _validator.Validate(request);

        // Assert
        result.Should().NotBeNull();
        result.IsValid.Should().BeTrue();
    }
}