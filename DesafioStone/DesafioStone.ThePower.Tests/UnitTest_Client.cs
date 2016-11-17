using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DesafioStone.Entities;
using System.Collections.Generic;
using DesafioStone.Application.Contracts;

namespace DesafioStone.ThePower.Tests
{
    /// <summary>
    /// Teste de unidade para entidade Client
    /// </summary>
    [TestClass]
    public class UnitTest_Client
    {
        private Mock<IAppServiceClient> _mockRepository;
      
        private Client CreateClient()
        {
            Client c = new Client()
            {
                IdClient = 1,
                Name = "Willian",
                Limit = 1500
            };
            return c;
        }

        /// <summary>
        /// Verifica se está retornando um cliente referente ao id solicitado
        /// </summary>
        [TestMethod]
        public void TestClientGetValue()
        {
            Client c = CreateClient();

            _mockRepository = new Mock<IAppServiceClient>();
            _mockRepository.Setup(s => s.ObterPorId(It.IsAny<int>())).Returns(c);

            //Act.
            var client = _mockRepository.Object.ObterPorId(1);

            //Assert.
            Assert.IsNotNull(client, "Sem cliente.");
            Assert.AreEqual(c, client);
        }

        /// <summary>
        /// Verifica se está retornando todos os clientes cadastrados
        /// </summary>
        [TestMethod]
        public void TestClientGetValues()
        {          
            List<Client> lista = new List<Client>();
            Client c = CreateClient();
            lista.Add(c);

            _mockRepository = new Mock<IAppServiceClient>();
          
            _mockRepository.Setup(s => s.ListarTodos()).Returns(lista);
           
            //Act.
            var myList = _mockRepository.Object.ListarTodos();

            //Assert.
            Assert.IsNotNull(myList, "Lista Vazia.");
            Assert.AreEqual(1, myList.Count);
        }

        /// <summary>
        /// Verifica se está inserindo um cliente
        /// </summary>
        [TestMethod]
        public void TestClientPost()
        {
            Client c = CreateClient();

            _mockRepository = new Mock<IAppServiceClient>();

            _mockRepository.Setup(s => s.Cadastrar(It.IsAny<Client>()));

            //Act.
            _mockRepository.Object.Cadastrar(c);
           
        }
    }
}
