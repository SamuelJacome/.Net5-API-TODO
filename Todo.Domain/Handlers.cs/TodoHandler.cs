using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.cs.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers.cs
{
    public class TodoHandler :
        Notifiable,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>

    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateTodoCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GerenicCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            var todo = new TodoItem(command.Title, command.Date, command.RefUser);
            //Save
            _repository.Create(todo);

            return new GerenicCommandResult(true, "Tarefa salva", todo);
        }
        public ICommandResult Handle(UpdateTodoCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GerenicCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            var todo = _repository.GetById(command.Id, command.RefUser);
            //Save
            todo.UpdateTitle(todo.Title);
            _repository.Update(todo);

            return new GerenicCommandResult(true, "Tarefa salva", todo);
        }
    }
}