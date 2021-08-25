using System;
using System.Linq.Expressions;
using Todo.Domain.Entities;

namespace Todo.Domain.Queries
{
    public static class TodoQueries
    {
        public static Expression<Func<TodoItem, bool>> GetAll(string user)
        {
            return x => x.RefUser == user;
        }

        public static Expression<Func<TodoItem, bool>> GetAllDone(string user)
        {
            return x => x.RefUser == user && x.Done;
        }

        public static Expression<Func<TodoItem, bool>> GetAllUnDone(string user)
        {
            return x => x.RefUser == user && x.Done == false;
        }

        public static Expression<Func<TodoItem, bool>> GetByPeriod(string user, DateTime date, bool done)
        {
            return x =>
                x.RefUser == user &&
                x.Done == done &&
                x.Date.Date == date.Date;
        }
    }
}