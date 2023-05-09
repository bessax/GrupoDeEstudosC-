namespace ByteBank.UnitTests.Domain;

public class AgenciaTest
{
    [Fact]
    public void ConstrutorAgencia_ComArgumentosValidos_DeveCriarInstancia()
    {
        // Arrange
        var nome = "Agência 1";
        var endereco = new Endereco(
            "Rua 1",
            "12345-123",
            123,
            "Sala 1");

        // Act
        var agencia = new Agencia(nome, endereco);

        // Assert
        agencia.Should().NotBeNull();
        agencia.Nome.Should().Be(nome);
        agencia.Endereco.Should().Be(endereco);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void ConstrutorAgencia_ComNomeInvalido_DeveLancarArgumentException(string nome)
    {
        // Arrange
        var endereco = new Endereco(
            "Rua 1",
            "12345-123",
            123,
            "Sala 1");

        // Act
        var act = () => new Agencia(nome, endereco);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void UpdateNome_ComArgumentosValidos_DeveAtualizarNome()
    {
        // Arrange
        var nome = "Agência 1";
        var agencia = new Agencia(nome,
            new Endereco(
                "Rua 1",
                "12345-123",
                123,
                "Sala 1"));
        var novoNome = "Agência 2";

        // Act
        agencia.UpdateNome(novoNome);

        // Assert
        agencia.Nome.Should().Be(novoNome);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void UpdateNome_ComNomeInvalido_DeveLancarArgumentException(string nome)
    {
        // Arrange
        var agencia = new Agencia("Agência 1",
            new Endereco(
                "Rua 1",
                "12345-123",
                123,
                "Sala 1"));

        // Act
        var act = () => agencia.UpdateNome(nome);

        // Assert
        act.Should().Throw<ArgumentException>();
    }
}