using AutoMapper;
using ByteBank.API.Models;
using ByteBank.API.Repository.Interface;
using ByteBank.API.Request.Validator;
using ByteBank.API.Services.Handlers;
using ByteBank.API.ViewModels;
using FizzWare.NBuilder;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.API.Test.Services
{
    public class ClienteServiceTests
    {
        [Fact]
        public async Task BuscaClientesAsyncTest()
        {
            //Arrange
            var repository = new Mock<IClienteRepository>();
            var mapper = new Mock<IMapper>();
            var validation = new ClienteValidator();

            var clientes = Builder<Cliente>.CreateListOfSize(20)
                .All().Build().ToList();

            var clientesViewModel = Builder<ClienteViewModel>.CreateListOfSize(20)
                .All().Build().ToList();

            repository.Setup(x => x.BuscaTodosAsync()).ReturnsAsync(clientes);
            mapper.Setup(x=>x.Map<List<ClienteViewModel>>(clientes)).Returns(clientesViewModel);

            var service = new ClienteService(mapper.Object,repository.Object,validation);

            //Act
            var result = await service.BuscaClientePorIdAsync(1);

            //Assert
            Assert.NotNull(result);
        }
    }
}
