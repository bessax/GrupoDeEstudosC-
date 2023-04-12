using AutoMapper;
using ByteBank.API.Models;
using ByteBank.API.Request;
using ByteBank.API.Request.Validator;
using ByteBank.API.Test.Builder;
using ByteBank.API.ViewModels.Automapper.Profiles;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using Xunit;

namespace ByteBank.API.Test.Models
{
    public class AgenciaModelTest
    {
        private IValidator<AgenciaRequest> _validator;
        private readonly IMapper _mapper;
        public AgenciaModelTest()
        {
           this._validator=new AgenciaValidator();
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AgenciaProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
           
        }

        [Fact]
        public void DeveValidarMapeamentoDeAgenciaParaAgenciaRequest()
        {
            //Arrange      
            var _agencia = new AgenciaModelBuilder().Build();
            var _agenciaRequest = _mapper.Map<AgenciaRequest>(_agencia);

            //Act
            var validation = _validator.Validate(_agenciaRequest);

            //Assert
            Assert.NotNull(validation);
            Assert.True(validation.IsValid);
        }

        [Fact]
        public void NDeveValidarMapeamentoDeAgenciaParaAgenciaRequestQuandoAgenciaInvalida()
        {
            //Arrange      
            var _agencia = new AgenciaModelBuilder().Build();
            _agencia.NumeroAgencia = 0;
            var _agenciaRequest = _mapper.Map<AgenciaRequest>(_agencia);

            //Act
            var validation = _validator.Validate(_agenciaRequest);

            //Assert
            Assert.NotNull(validation);
            Assert.False(validation.IsValid);           
        }
    }
}