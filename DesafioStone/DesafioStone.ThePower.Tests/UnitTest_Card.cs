using DesafioStone.Application.Contracts;
using DesafioStone.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.ThePower.Tests
{
    /// <summary>
    /// Teste de unidade para entidade Card
    /// </summary>
    [TestClass]
    public class UnitTest_Card
    {
        private Mock<IAppServiceCard> _mockRepository;

        private Card CreateCard()
        {
            Card c = new Card()
            {
                IdCard = 1,
                CardholderName = "Willian Assis",
                CardNumber = "123456987456321458",
                ExpirationDate = DateTime.Parse("15/12/2016"),
                CardBrand = "Visa",
                Password = "12345",
                Type = "Chip",
                IdClient = 1,
                Status = 1
            };
            return c;
        }

        /// <summary>
        /// Verifica se está retornando um cartão referente ao id solicitado
        /// </summary>
        [TestMethod]
        public void TestCardGetValue()
        {
            Card c = CreateCard();

            _mockRepository = new Mock<IAppServiceCard>();

            _mockRepository.Setup(s => s.ObterPorId(It.IsAny<int>())).Returns(c);

            //Act.
            var card = _mockRepository.Object.ObterPorId(1);

            //Assert.
            Assert.IsNotNull(card, "Sem cartão.");
            Assert.AreEqual(c, card);
        }

        /// <summary>
        /// Verifica se está retornando todos os cartões cadastrados
        /// </summary>
        [TestMethod]
        public void TestCardGetValues()
        {            
            List<Card> lista = new List<Card>();
            Card c = CreateCard();

            lista.Add(c);

            _mockRepository = new Mock<IAppServiceCard>();

            _mockRepository.Setup(s => s.ListarTodos()).Returns(lista);

            //Act.
            var myList = _mockRepository.Object.ListarTodos();

            //Assert.
            Assert.IsNotNull(myList, "Lista Vazia.");
            Assert.AreEqual(1, myList.Count);
        }

        /// <summary>
        /// Verifica se está inserindo um cartão
        /// </summary>
        [TestMethod]
        public void TestCardPost()
        {
            Card c = CreateCard();

            _mockRepository = new Mock<IAppServiceCard>();

            _mockRepository.Setup(s => s.Cadastrar(It.IsAny<Card>()));

            //Act.
            _mockRepository.Object.Cadastrar(c);

        }

        /// <summary>
        /// Teste de inserção de um cartão com parâmetros inválidos
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestCardGetInvalidValue()
        {            
            Card c = new Card()
            {
                IdCard = 1,
                CardholderName = "Willian Assis",
                CardNumber = "12345698",
                ExpirationDate = DateTime.Parse("15/12/2016"),
                CardBrand = "Visa",
                Password = "12345",
                Type = "Chip",
                IdClient = 1,
                Status = 1
            };

            _mockRepository = new Mock<IAppServiceCard>();

            _mockRepository.Setup(s => s.Cadastrar(It.IsAny<Card>())).Throws<Exception>();

            //Act.
            _mockRepository.Object.Cadastrar(c);          
            _mockRepository.Verify(m => m.Cadastrar(It.IsAny<Card>()));           
        }       
    }
}
