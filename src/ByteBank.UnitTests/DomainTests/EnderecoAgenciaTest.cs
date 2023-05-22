namespace ByteBank.UnitTests.DomainTests;

public class EnderecoAgenciaTest
{
    [Fact]
    public void ConstrutorEndereco_ComArgumentosValidos_DeveCriarInstancia()
    {
        // Arrange
        var logradouro = "Rua 1";
        var cep = "12345-123";
        var numero = 123;
        var complemento = "Sala 1";

        // Act
        var endereco = new Endereco(
            logradouro,
            cep,
            numero,
            complemento);

        // Assert
        endereco.Should().NotBeNull();
        endereco.Logradouro.Should().Be(logradouro);
        endereco.Cep.Should().Be(cep);
        endereco.Numero.Should().Be(numero);
        endereco.Complemento.Should().Be(complemento);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void ConstrutorEndereco_ComLogradouroInvalido_DeveLancarArgumentException(string logradouro)
    {
        // Arrange
        var cep = "12345-123";
        var numero = 123;
        var complemento = "Sala 1";

        // Act
        var act = () => new Endereco(
            logradouro,
            cep,
            numero,
            complemento);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void ConstrutorEndereco_ComCepInvalido_DeveLancarArgumentException(string cep)
    {
        // Arrange
        var logradouro = "Rua 1";
        var numero = 123;
        var complemento = "Sala 1";

        // Act
        var act = () => new Endereco(
            logradouro,
            cep,
            numero,
            complemento);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void ConstrutorEndereco_ComNumeroInvalido_DeveLancarArgumentOutOfRangeException(int numero)
    {
        // Arrange
        var logradouro = "Rua 1";
        var cep = "12345-123";
        var complemento = "Sala 1";

        // Act
        var act = () => new Endereco(
            logradouro,
            cep,
            numero,
            complemento);

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void ConstrutorEndereco_ComComplementoNulo_DeveCriarInstancia()
    {
        // Arrange
        var logradouro = "Rua 1";
        var cep = "12345-123";
        var numero = 123;
        string? complemento = null;

        // Act
        var endereco = new Endereco(
            logradouro,
            cep,
            numero,
            complemento);

        // Assert
        endereco.Should().NotBeNull();
        endereco.Logradouro.Should().Be(logradouro);
        endereco.Cep.Should().Be(cep);
        endereco.Numero.Should().Be(numero);
        endereco.Complemento.Should().Be(complemento);
    }

    [Fact]
    public void ConstrutorEndereco_ComComplementoVazio_DeveCriarInstancia()
    {
        // Arrange
        var logradouro = "Rua 1";
        var cep = "12345-123";
        var numero = 123;
        var complemento = string.Empty;

        // Act
        var endereco = new Endereco(
            logradouro,
            cep,
            numero,
            complemento);

        // Assert
        endereco.Should().NotBeNull();
        endereco.Logradouro.Should().Be(logradouro);
        endereco.Cep.Should().Be(cep);
        endereco.Numero.Should().Be(numero);
        endereco.Complemento.Should().Be(complemento);
    }

    [Fact]
    public void ConstrutorEndereco_ComComplementoEmBranco_DeveCriarInstancia()
    {
        // Arrange
        var logradouro = "Rua 1";
        var cep = "12345-123";
        var numero = 123;
        var complemento = " ";

        // Act
        var endereco = new Endereco(
            logradouro,
            cep,
            numero,
            complemento);

        // Assert
        endereco.Should().NotBeNull();
        endereco.Logradouro.Should().Be(logradouro);
        endereco.Cep.Should().Be(cep);
        endereco.Numero.Should().Be(numero);
        endereco.Complemento.Should().Be(complemento);
    }

    [Fact]
    public void UpdateLogradouro_ComArgumentosValidos_DeveAtualizarLogradouro()
    {
        // Arrange
        var logradouro = "Rua 1";
        var endereco = new Endereco(
            logradouro,
            "12345-123",
            123,
            "Sala 1");
        var novoLogradouro = "Rua 2";

        // Act
        endereco.UpdateLogradouro(novoLogradouro);

        // Assert
        endereco.Logradouro.Should().Be(novoLogradouro);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void UpdateLogradouro_ComLogradouroInvalido_DeveLancarArgumentException(string logradouro)
    {
        // Arrange
        var endereco = new Endereco(
            "Rua 1",
            "12345-123",
            123,
            "Sala 1");

        // Act
        var act = () => endereco.UpdateLogradouro(logradouro);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void UpdateCep_ComArgumentosValidos_DeveAtualizarCep()
    {
        // Arrange
        var cep = "12345-123";
        var endereco = new Endereco(
            "Rua 1",
            cep,
            123,
            "Sala 1");
        var novoCep = "54321-321";

        // Act
        endereco.UpdateCep(novoCep);

        // Assert
        endereco.Cep.Should().Be(novoCep);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void UpdateCep_ComCepInvalido_DeveLancarArgumentException(string cep)
    {
        // Arrange
        var endereco = new Endereco(
            "Rua 1",
            "12345-123",
            123,
            "Sala 1");

        // Act
        var act = () => endereco.UpdateCep(cep);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void UpdateNumero_ComArgumentosValidos_DeveAtualizarNumero()
    {
        // Arrange
        var numero = 123;
        var endereco = new Endereco(
            "Rua 1",
            "12345-123",
            numero,
            "Sala 1");
        var novoNumero = 321;

        // Act
        endereco.UpdateNumero(novoNumero);

        // Assert
        endereco.Numero.Should().Be(novoNumero);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void UpdateNumero_ComNumeroInvalido_DeveLancarArgumentOutOfRangeException(int numero)
    {
        // Arrange
        var endereco = new Endereco(
            "Rua 1",
            "12345-123",
            123,
            "Sala 1");

        // Act
        var act = () => endereco.UpdateNumero(numero);

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void UpdateComplemento_ComArgumentosNaoNulos_DeveAtualizarComplemento()
    {
        // Arrange
        var complemento = "Sala 1";
        var endereco = new Endereco(
            "Rua 1",
            "12345-123",
            123,
            complemento);
        var novoComplemento = "Sala 2";

        // Act
        endereco.UpdateComplemento(novoComplemento);

        // Assert
        endereco.Complemento.Should().Be(novoComplemento);
    }

    [Fact]
    public void UpdateComplemento_ComComplementoNulo_DeveAtualizarComplemento()
    {
        // Arrange
        var complemento = "Sala 1";
        var endereco = new Endereco(
            "Rua 1",
            "12345-123",
            123,
            complemento);
        string? novoComplemento = null;

        // Act
        endereco.UpdateComplemento(novoComplemento);

        // Assert
        endereco.Complemento.Should().Be(novoComplemento);
    }

    [Fact]
    public void UpdateComplemento_ComComplementoVazio_DeveAtualizarComplemento()
    {
        // Arrange
        var complemento = "Sala 1";
        var endereco = new Endereco(
            "Rua 1",
            "12345-123",
            123,
            complemento);
        var novoComplemento = string.Empty;

        // Act
        endereco.UpdateComplemento(novoComplemento);

        // Assert
        endereco.Complemento.Should().Be(novoComplemento);
    }

    [Fact]
    public void UpdateComplemento_ComComplementoEmBranco_DeveAtualizarComplemento()
    {
        // Arrange
        var complemento = "Sala 1";
        var endereco = new Endereco(
            "Rua 1",
            "12345-123",
            123,
            complemento);
        var novoComplemento = " ";

        // Act
        endereco.UpdateComplemento(novoComplemento);

        // Assert
        endereco.Complemento.Should().Be(novoComplemento);
    }
}