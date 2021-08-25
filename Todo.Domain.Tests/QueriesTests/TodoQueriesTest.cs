using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.cs;
using Todo.Domain.Queries;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.QueriesTests
{
    [TestClass]
    public class TodoQueriesTest
    {
        private List<TodoItem> _items;
        public TodoQueriesTest()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", DateTime.Now, "samuel"));
            _items.Add(new TodoItem("Tarefa 2", DateTime.Now, "samuel"));
            _items.Add(new TodoItem("Tarefa 3", DateTime.Now, "Fernando"));
            _items.Add(new TodoItem("Tarefa 4", DateTime.Now, "samuel"));
            _items.Add(new TodoItem("Tarefa 5", DateTime.Now, "samuel"));
        }
        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuario_samuel()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("samuel"));
            Assert.AreEqual(result.Count(), 4);
        }
    }
}
