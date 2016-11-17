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
    /// Teste de unidade para entidade Transaction
    /// </summary>
    [TestClass]
    public class UnitTest_Transaction
    {
        private Mock<IAppServiceTransaction> _mockRepository;

        private Transaction CreateTransaction()
        {
            Transaction t = new Transaction()
            {
                IdTransaction = 1,
                Amount = 1000,
                Type = "Crédito",
                Number = 3,
                IdClient = 1,
                IdCard = 1
            };
            return t;
        }


        /// <summary>
        /// Verifica se está retornando uma transação referente ao id solicitado
        /// </summary>
        [TestMethod]
        public void TestTransactionGetValue()
        {
            Transaction t = CreateTransaction();

            _mockRepository = new Mock<IAppServiceTransaction>();

            _mockRepository.Setup(s => s.ObterPorId(It.IsAny<int>())).Returns(t);

            //Act.
            var transaction = _mockRepository.Object.ObterPorId(1);

            //Assert.
            Assert.IsNotNull(transaction, "Sem transação.");
            Assert.AreEqual(t, transaction);
        }

        /// <summary>
        /// Verifica se está retornando todas as transações cadastradas
        /// </summary>
        [TestMethod]
        public void TestTransactionGetValues()
        {          
            List<Transaction> lista = new List<Transaction>();
            Transaction t = CreateTransaction();

            lista.Add(t);

            _mockRepository = new Mock<IAppServiceTransaction>();

            _mockRepository.Setup(s => s.ListarTodos()).Returns(lista);

            //Act.
            var myList = _mockRepository.Object.ListarTodos();

            //Assert.
            Assert.IsNotNull(myList, "Lista Vazia.");
            Assert.AreEqual(1, myList.Count);
        }

        /// <summary>
        /// Verifica se está inserindo uma transação
        /// </summary>
        [TestMethod]
        public void TestTransactionPost()
        {
            Transaction t = CreateTransaction();

            _mockRepository = new Mock<IAppServiceTransaction>();

            _mockRepository.Setup(s => s.Cadastrar(It.IsAny<Transaction>()));

            //Act.
            _mockRepository.Object.Cadastrar(t);

        }

        /// <summary>
        /// Teste de inserção de uma transação com parâmetros inválidos
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestTransactionGetInvalidValue()
        {
            Transaction t = new Transaction()
            {
                IdTransaction = 1,
                Amount = 0,
                Type = "Crédito",
                Number = 3,
                IdClient = 1,
                IdCard = 1
            };

            _mockRepository = new Mock<IAppServiceTransaction>();

            _mockRepository.Setup(s => s.Cadastrar(It.IsAny<Transaction>())).Throws<Exception>();

            //Act.
            _mockRepository.Object.Cadastrar(t);
            _mockRepository.Verify(m => m.Cadastrar(It.IsAny<Transaction>()));
        }
    }
}
