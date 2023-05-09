namespace ByteBank.UnitTests.Application;

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
        var request = new GetAgencias();

        var result = _validator.Validate(request);

        result.Should().NotBeNull();
        result.IsValid.Should().BeTrue();
    }
}