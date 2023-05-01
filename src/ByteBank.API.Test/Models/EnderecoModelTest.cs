using AutoMapper;
using ByteBank.API.Models;
using ByteBank.API.Request;
using ByteBank.API.Request.Validator;
using ByteBank.API.ViewModels;
using ByteBank.API.ViewModels.Automapper.Profiles;
using FluentValidation;

namespace ByteBank.API.Test.Models
{
    public class EnderecoModelTest
    {
        private readonly IMapper _mapper;
        private readonly IValidator<EnderecoRequest> _validator;
        public EnderecoModelTest()
        {
            _validator = new EnderecoValidator();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EnderecoProfile>();
            });

            _mapper = config.CreateMapper();
        }

        [Fact]
        public void TestMap_EnderecoRequest_para_EnderecoCliente()
        {
            // Given
            var request = new EnderecoRequest()
            {
                Logradouro = "Rua Tamanduá",
                Numero = 852,
                Complemento = "apto 86",
                Cep = "45687-636",
            };

            // When
            var enderecoCliente = _mapper.Map<EnderecoCliente>(request);

            // Then
            Assert.NotNull(enderecoCliente);
            Assert.Equivalent(request, enderecoCliente);
        }

        [Fact]
        public void TestMap_EnderecoAgenciaRequest_para_EnderecoAgencia()
        {
            // Given
            var request = new EnderecoAgenciaRequest()
            {
                Logradouro = "Rua Tamanduá",
                Numero = 852,
                Complemento = "Bloco 1",
                Cep = "45687-636",
            };

            // When
            var enderecoCliente = _mapper.Map<EnderecoAgencia>(request);

            // Then
            Assert.NotNull(enderecoCliente);
            Assert.Equivalent(request, enderecoCliente);
        }

        [Fact]
        public void TestMap_EnderecoAgencia_para_EnderecoAgenciaViewModel()
        {
            // Given
            var enderecoAgencia = new EnderecoAgencia()
            {
                Id = 3,
                Logradouro = "Rua Tamanduá",
                Numero = 852,
                Complemento = "Bloco 1",
                Cep = "45687-636",
                CriadoEm = DateTime.UtcNow,
                AtualizadoEm = DateTime.UtcNow,
                ExcluidoEm = null
            };

            // When
            var enderecoAgenciaViewModel = _mapper.Map<EnderecoAgenciaViewModel>(enderecoAgencia);

            // Then
            Assert.NotNull(enderecoAgenciaViewModel);
            Assert.Equal(enderecoAgencia.Id, enderecoAgenciaViewModel.Id);
            Assert.Equal(enderecoAgencia.Logradouro, enderecoAgenciaViewModel.Logradouro);
            Assert.Equal(enderecoAgencia.Numero, enderecoAgenciaViewModel.Numero);
            Assert.Equal(enderecoAgencia.Complemento, enderecoAgenciaViewModel.Complemento);
            Assert.Equal(enderecoAgencia.Cep, enderecoAgenciaViewModel.Cep);
            Assert.Equal(enderecoAgencia.CriadoEm.Date, enderecoAgenciaViewModel.CriadoEm.Date);
            Assert.Equal(enderecoAgencia.AtualizadoEm.Date, enderecoAgenciaViewModel.AtualizadoEm.Date);
        }

        [Fact]
        public void TestValidation_EnderecoRequest_IsSuccess()
        {
            // Given
            var request = new EnderecoRequest()
            {
                Logradouro = "Rua Tamanduá",
                Numero = 852,
                Complemento = "apto 86",
                Cep = "45687-636",
            };

            // When
            var validation = _validator.Validate(request);

            // Then
            Assert.NotNull(validation);
            Assert.True(validation.IsValid);
        }

        [Theory]
        [InlineData("", 852, "apto 86", "45687-636", "O campo logradouro é obrigatório")]
        [InlineData("Rua 8", 852, "apto 86", "45687-636", "Mínimo de 10 caracteres, Máximo de 20 caracteres")]
        [InlineData("Rua Isabel Cristina Leopoldina Augusta Micaela Gabriela Rafaela Gonzaga de Bourbon e Bragança", 852, "apto 86", "45687-636", "Mínimo de 10 caracteres, Máximo de 20 caracteres")]
        [InlineData("Rua Tamanduá", 852, "apto 86", "45687-63", "O CEP deve estar no formato 00000 - 000")]
        [InlineData("Rua Tamanduá", 852, "apto 86", "45687632", "O CEP deve estar no formato 00000 - 000")]
        [InlineData("Rua Tamanduá", -852, "apto 86", "45687-632", "O número não deve ser negativo")]
        [InlineData("Rua Santa Cruz", 852, "a6", "45687-636", "Mínimo de 5 caracteres, Máximo de 20 caracteres")]
        public void TestValidation_EnderecoResquest_Fail(string logradouro, int numero, string complemento, string cep, string expected)
        {
            // Given
            var request = new EnderecoRequest()
            {
                Logradouro = logradouro,
                Numero = numero,
                Complemento = complemento,
                Cep = cep,
            };

            // When
            var validation = _validator.Validate(request);

            //Then
            Assert.NotNull(validation);
            Assert.True(!validation.IsValid);
            Assert.Equal(expected, validation.Errors.FirstOrDefault()?.ToString());
        }
    }
}