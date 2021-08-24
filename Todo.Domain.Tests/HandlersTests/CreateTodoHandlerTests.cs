
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Handlers.cs;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlersTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        private readonly CreateTodoCommand _commandInvalid = new CreateTodoCommand("", "", DateTime.Now);
        private readonly CreateTodoCommand _commandValid = new CreateTodoCommand("Tarefa 1", "Samuel Jácome", DateTime.Now);
        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());
        private GerenicCommandResult _result = new GerenicCommandResult();

        [TestMethod]
        public void Dado_um_comando_invalido_deve_interromper_a_execução()
        {
            _result = (GerenicCommandResult)_handler.Handle(_commandInvalid);
            Assert.AreEqual(_result.Sucess, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido_deve_criar_a_tarefa()
        {
            _result = (GerenicCommandResult)_handler.Handle(_commandValid);
            Assert.AreEqual(_result.Sucess, true);
        }
    }
}
