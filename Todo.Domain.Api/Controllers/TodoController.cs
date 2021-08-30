using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.cs;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll([FromServices] ITodoRepository repository)
        {
            return repository.GetAll("samuelvictor");
        }

        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone([FromServices] ITodoRepository repository)
        {
            return repository.GetAllDone("samuelvictor");
        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUnDone([FromServices] ITodoRepository repository)
        {
            return repository.GetAllUnDone("samuelvictor");
        }

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForToday(
            [FromServices] ITodoRepository repository
        )
        {
            return repository.GetByPeriod("samuelvictor", DateTime.Now.Date, true);
        }

        [Route("undone/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUnDoneForToday(
            [FromServices] ITodoRepository repository
        )
        {
            return repository.GetByPeriod("samuelvictor", DateTime.Now.Date, false);
        }

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForTomorrow(
            [FromServices] ITodoRepository repository
        )
        {
            return repository.GetByPeriod("samuelvictor", DateTime.Now.Date.AddDays(1), true);
        }

        [Route("undone/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUnDoneForTomorrow(
            [FromServices] ITodoRepository repository
        )
        {
            return repository.GetByPeriod("samuelvictor", DateTime.Now.Date.AddDays(1), false);
        }

        [Route("")]
        [HttpPost]
        public GerenicCommandResult Create(
            [FromBody] CreateTodoCommand command,
            [FromServices] TodoHandler handler)
        {
            command.RefUser = "samuelvictor";
            return (GerenicCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GerenicCommandResult Update(
            [FromBody] CreateTodoCommand command,
            [FromServices] TodoHandler handler)
        {
            command.RefUser = "samuelvictor";
            return (GerenicCommandResult)handler.Handle(command);
        }

        [Route("mark-as-done")]
        [HttpPut]
        public GerenicCommandResult MarkAsDone(
            [FromBody] CreateTodoCommand command,
            [FromServices] TodoHandler handler)
        {
            command.RefUser = "samuelvictor";
            return (GerenicCommandResult)handler.Handle(command);
        }


        [Route("mark-as-undone")]
        [HttpPut]
        public GerenicCommandResult MarkAsUnDone(
            [FromBody] CreateTodoCommand command,
            [FromServices] TodoHandler handler)
        {
            command.RefUser = "samuelvictor";
            return (GerenicCommandResult)handler.Handle(command);
        }
    }
}