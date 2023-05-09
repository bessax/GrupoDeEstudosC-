namespace ByteBank.UnitTests.Application;

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
        var request = new DeleteAgencia(id);

        var result = _validator.Validate(request);

        result.Should().NotBeNull();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == nameof(DeleteAgencia.Id));
    }

    [Fact]
    public void Validate_ComIdValido_DeveRetornarSucesso()
    {
        var request = new DeleteAgencia(1);

        var result = _validator.Validate(request);

        result.Should().NotBeNull();
        result.IsValid.Should().BeTrue();
    }
}