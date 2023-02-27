using AutoMapper;
using ByteBank.API.Models;
using ByteBank.API.Repository.Interface;
using ByteBank.API.Request.Validator;
using ByteBank.API.Services.Handlers;
using ByteBank.API.ViewModels;
using FizzWare.NBuilder;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.API.Test.Services
{
    public class AgenciasServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task BuscaAgenciasAsyncTeste()
        {
            //Arrenge
            var repositoryMock = new Mock<IAgenciaRepository>();
            var mapperMock = new Mock<IMapper>();
            var validation = new AgenciaValidator();
            var agencia = Builder<Agencia>.CreateListOfSize(10)
                .All().With(x => x.Endereco = Builder<EnderecoAgencia>.CreateNew().Build())
                .Build().ToList();

            var agenciaViewModel = Builder<AgenciaViewModel>.CreateListOfSize(10)
                .All().With(x => x.Endereco = Builder<EnderecoAgencia>.CreateNew().Build())
                .Build().ToList();

            repositoryMock.Setup(x => x.BuscaTodosAsync()).ReturnsAsync(agencia);
            mapperMock.Setup(x => x.Map<List<AgenciaViewModel>>(agencia)).Returns(agenciaViewModel);

            var service = new AgenciasService(repositoryMock.Object, mapperMock.Object, validation);

            //Act
            var result = await service.BuscaAgenciasAsync();
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
