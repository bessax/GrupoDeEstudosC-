using AutoMapper;
using ByteBank.API.Enums;
using ByteBank.API.Models;
using ByteBank.API.Request;
using ByteBank.API.Request.Validator;
using ByteBank.API.Test.Builder;
using ByteBank.API.ViewModels;
using ByteBank.API.ViewModels.Automapper.Profiles;
using FluentValidation;

namespace ByteBank.API.Test.Models
{
    public class ClienteModelTest
    {
        private IValidator<ClienteRequest> _validator;
        private IMapper _mapper;

        public ClienteModelTest()
        {
            _validator = new ClienteValidator();
            var config = new MapperConfiguration(cfg =>
               {
                   cfg.AddProfile<ClienteProfile>();
               });

            _mapper = config.CreateMapper();
        }

        [Fact]
        public void TestMapperConfiguration()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ClienteProfile>();
            });

            // Act & Assert
            mapperConfig.AssertConfigurationIsValid();
        }

        [Fact]
        public void TestMap_ClienteRequest_para_Cliente()
        {
            // Given
            var clienteRequest = new ClienteModelBuilder().BuildClienteRequest();

            // When
            var cliente = _mapper.Map<Cliente>(clienteRequest);

            // Then
            Assert.NotNull(cliente);
            Assert.Equivalent(clienteRequest, cliente);
            Assert.Equal(DateTime.UtcNow.Date, cliente.CriadoEm.Date);
            Assert.Equal(DateTime.UtcNow.Date, cliente.AtualizadoEm.Date);
            Assert.Null(cliente.ExcluidoEm);
        }

        [Fact]
        public void TestMap_Cliente_para_ClienteViewModel()
        {
            // Given
            var cliente = new ClienteModelBuilder().Build();

            // When
            var clienteViewModel = _mapper.Map<ClienteViewModel>(cliente);

            // Then
            Assert.NotNull(clienteViewModel);
            Assert.Equal(cliente.Id, clienteViewModel.Id);
            Assert.Equal(cliente.Cpf, clienteViewModel.Cpf);
            Assert.Equal(cliente.Nome, clienteViewModel.Nome);
            Assert.Equal(cliente.Tipo, clienteViewModel.Tipo);
            Assert.Equal(cliente.Contas, clienteViewModel.Contas);
            Assert.Equal(cliente.Endereco, clienteViewModel.Endereco);
            Assert.Equal(cliente.CriadoEm, clienteViewModel.CriadoEm);
            Assert.Equal(cliente.AtualizadoEm, clienteViewModel.AtualizadoEm);
        }

        [Fact]
        public void TestValidation_ClienteRequest_IsSuccess()
        {
            // Given
            var request1 = new ClienteModelBuilder().BuildClienteRequest();
            var request2 = new ClienteModelBuilder().BuildClienteRequest();
            var request3 = new ClienteModelBuilder().BuildClienteRequest();
            var request4 = new ClienteModelBuilder().BuildClienteRequest();

            // When
            List<FluentValidation.Results.ValidationResult?> validations = new(){
                _validator.Validate(request1),
                _validator.Validate(request2),
                _validator.Validate(request3),
                _validator.Validate(request4)
            };

            // Then
            foreach (var validation in validations)
            {
                Assert.NotNull(validation);
                Assert.True(validation.IsValid);
            }
        }

        [Theory]
        [InlineData("", "123.654.897-44", 0, "Nome é obrigatório")]
        [InlineData("João", "123.654.897-44", 10, "Expecifique - PessoaFísica = 0, Cnpj = 1")]
        [InlineData("João Maria José Francisco Xavier de Paula Luís António Domingos Rafael de Bragança",
        "123.654.897-44", 0, "Mínimo de 3 caracteres, máximo de 30 caracteres")]
        [InlineData("John", "12365489744", 0, "Informe o CPF no formato 000.000.000-00")]
        [InlineData("John", "123-654-897-44", 0, "Informe o CPF no formato 000.000.000-00")]
        [InlineData("John", "123.654.897.44", 0, "Informe o CPF no formato 000.000.000-00")]
        public void TestValidation_ClienteRequest_IsFail(string nome, string cpf, int tipo, string exception)
        {
            // Given
            var request = new ClienteRequest
            {
                Nome = nome,
                Cpf = cpf,
                Tipo = (TipoCliente)tipo,
                Endereco = new EnderecoModelBuilder().BuildEnderecoRequest(),
                Contas = new ContaRequest[]
                    {
                        new ContaModelBuilder().BuildContaRequest()
                    }
            };

            // When
            var validation = _validator.Validate(request);
            // Then
            Assert.NotNull(validation);
            Assert.False(validation.IsValid);
            Assert.Equal(exception, validation.Errors.FirstOrDefault()?.ToString());
        }

    }
}