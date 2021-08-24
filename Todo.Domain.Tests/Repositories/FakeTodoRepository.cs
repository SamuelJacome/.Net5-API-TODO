using System;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void Create(TodoItem todo)
        {

        }

        public TodoItem GetById(Guid id, string refuser)
        {
            return new TodoItem("jfkdjfkdj", DateTime.Now, "Samuel Jacome");
        }

        public void Update(TodoItem todo)
        {

        }
    }
}