using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PjInmobiliaria.Application.Dto_s.Request;
using PjInmobiliaria.Application.Interfaces;
using PjInmobiliaria.Utilities.Statics;

namespace PjInmobiliaria.Test.Cliente
{
    [TestClass]
    public class ClienteApplicationTest
    {
        private static WebApplicationFactory<Program>? webApplicationFactory = null;
        private static IServiceScopeFactory ? scopeFactory = null;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            webApplicationFactory = new CustomWebApplicationFactory();
            scopeFactory = webApplicationFactory.Services.GetService<IServiceScopeFactory>();
        }

        [TestMethod]
        public async Task RegistrarCliente_WhenSendingNullValuesOrEmpty_ValidationErrors()
        {
            using var scope = scopeFactory?.CreateScope();
            var context = scope?.ServiceProvider.GetService<IClienteApplication>();

            //arrange
            var nombre = "";
            var expected = ReplyMessage.MESSAGE_VALIDATION;
            //act
            var result = await context!.RegistrarCliente(new ClienteDtoRequest()
            {
                NombreCliente = nombre,
                CodigoP = null,
                Direccion = null,
                Estado = 1,
                Fono = null,
                Region = null,
                Rut = null
            });
            var current = result.Message;
            //assert
            Assert.AreEqual(expected, current);
        }
        [TestMethod]
        public async Task RegistrarCliente_WhenSendingCorrectValues_ValidationSuccess()
        {
            using var scope = scopeFactory?.CreateScope();
            var context = scope?.ServiceProvider.GetService<IClienteApplication>();

            //arrange
            var nombre = "prueba nombre";
            var expected = ReplyMessage.MESSAGE_SAVE;
            //act
            var result = await context!.RegistrarCliente(new ClienteDtoRequest()
            {
                NombreCliente = nombre,
                CodigoP = 1,
                Direccion = "prueba direccion",
                Estado = 1,
                Fono = 123456789,
                Region = "prueba region",
                Rut = "1234567"
            });
            var current = result.Message;
            //assert
            Assert.AreEqual(expected, current);
        }
    }
}
