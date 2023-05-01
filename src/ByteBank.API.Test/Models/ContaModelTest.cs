using AutoMapper;
using ByteBank.API.Enums;
using ByteBank.API.Models;
using ByteBank.API.Request;
using ByteBank.API.Request.Validator;
using ByteBank.API.ViewModels;
using ByteBank.API.ViewModels.Automapper.Profiles;
using FluentValidation;

namespace ByteBank.API.Test.Models
{
    public class ContaModelTest
    {
        private readonly IValidator<ContaRequest> _validator;
        private readonly IMapper _mapper;
        public ContaModelTest()
        {
            _validator = new ContaValidator();
            var config = new MapperConfiguration(cfg =>
         {
             cfg.AddProfile<ContaProfile>();
         });

            _mapper = config.CreateMapper();
        }

        [Fact]
        public void TestMap_ContaRequest_para_Conta()
        {
            // Given
            var request = new ContaRequest()
            {
                AgenciaId = 1,
                ChavePix = "123.985.972-86",
                NumeroConta = "4567-7894-3854-7298",
                Saldo = 10,
                Tipo = (TipoConta)0
            };
            // When
            var conta = _mapper.Map<Conta>(request);
            // Then
            Assert.NotNull(conta);
            Assert.Equivalent(request, conta);

        }

        [Fact]
        public void TestMap_Conta_para_ContaCorrenteViewModel()
        {
            // Given
            var conta = new Conta()
            {
                AgenciaId = 1,
                ChavePix = "123.985.972-86",
                NumeroConta = "4567-7894-3854-7298",
                Saldo = 10,
                Tipo = (TipoConta)0
            };

            // When
            var contaViewModel = _mapper.Map<ContaCorrenteViewModel>(conta);

            // Then
            Assert.NotNull(contaViewModel);
            Assert.Equal(conta.AgenciaId, contaViewModel.AgenciaId);
            Assert.Equal(conta.ChavePix, contaViewModel.ChavePix);
            Assert.Equal(conta.NumeroConta, contaViewModel.NumeroConta);
            Assert.Equal(conta.Saldo, contaViewModel.Saldo);
            Assert.Equal(conta.Tipo, contaViewModel.Tipo);
        }

        [Fact]
        public void TestContaValidator_IsSuccess()
        {
            // Given
            var conta = new ContaRequest()
            {
                AgenciaId = 1,
                ChavePix = "123.985.972-86",
                NumeroConta = "4567-7894-3854-7298",
                Saldo = 10,
                Tipo = (TipoConta)0
            };
            // When
            var validation = _validator.Validate(conta);
            // Then
            Assert.NotNull(validation);
            Assert.True(validation.IsValid);
        }

        [Theory]
        [InlineData("11.222.333/4444-55")]
        [InlineData("12.345.678/9000-12")]
        [InlineData("12.345.678/0001-01")]
        [InlineData("(11) 91234-5678")]
        [InlineData("(11)91234-5678")]
        [InlineData("11 91234-5678")]
        [InlineData("1191234-5678")]
        [InlineData("email@email.com")]
        [InlineData("333.333.333-22")]
        public void TestContaValidator_ChavePixFormat_IsSuccess(string chavePix)
        {
            // Given
            var conta = new ContaRequest()
            {
                AgenciaId = 1,
                ChavePix = chavePix,
                NumeroConta = "4567-7894-3854-7298",
                Saldo = 10,
                Tipo = (TipoConta)0
            };
            // When
            var validation = _validator.Validate(conta);
            // Then
            Assert.NotNull(validation);
            Assert.True(validation.IsValid);
        }

        [Theory]
        [InlineData(0, "11.222.333/4444-55", "4567-7894-3854-7298", 10, (TipoConta)1, "O id da agência deve ser maior que zero")]
        [InlineData(1, "11222333/444455", "4567-7894-3854-7298", 10, (TipoConta)1, "Formato de Pix incorreto! CPF: formato 000.000.000-00, CNPJ: formato 11.222.333/4444-55, Email: formato email@email.com, Tel: formato (xx) xxxxx-xxxx")]
        [InlineData(1, "11.222.333/4444-55", "4567789438547298", 10, (TipoConta)1, "O número da conta deve estar no formato 0000-0000-0000-0000")]
        [InlineData(1, "11.222.333/4444-55", "4567-7894-3854-7298", 0, (TipoConta)1, "Obrigatório saldo inicial")]
        [InlineData(1, "11.222.333/4444-55", "4567-7894-3854-7298", 10, (TipoConta)7, "Expecifique: 0 - Conta Corrente, 1 - Conta Poupança")]
        public void TestContaValidator_Fail(int agenciaId, string chavePix, string numeorConta, int saldo, TipoConta tipo, string expectedMessage)
        {
            // Given
            var conta = new ContaRequest()
            {
                AgenciaId = agenciaId,
                ChavePix = chavePix,
                NumeroConta = numeorConta,
                Saldo = saldo,
                Tipo = tipo
            };
            // When
            var validation = _validator.Validate(conta);
            // Then
            Assert.NotNull(validation);
            Assert.False(validation.IsValid);
            Assert.Equal(expectedMessage, validation.Errors.FirstOrDefault()?.ToString());
        }
    }
}