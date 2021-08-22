
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Handlers.cs;

namespace Todo.Domain.Tests.HandlersTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        private readonly CreateTodoCommand _invalido = new CreateTodoCommand("", "", DateTime.Now);
        private readonly TodoHandler _vazio = new TodoHandler(null);

        [TestMethod]
        public void Dado_um_comando_invalido_deve_interromper_a_execução()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Dado_um_comando_valido_deve_criar_a_tarefa()
        {
            Assert.Fail();
        }
    }
}
