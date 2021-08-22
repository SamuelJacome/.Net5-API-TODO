using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class CreateTodoCommand : Notifiable, ICommand
    {
        public CreateTodoCommand() { }
        public CreateTodoCommand(string title, string refUser, DateTime date)
        {
            Title = title;
            RefUser = refUser;
            Date = date;
        }
        public string Title { get; set; }
        public string RefUser { get; set; }
        public DateTime Date { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Title, 3, "Title", "Por favor, descreva melhor esta tarefa!")
                    .HasMinLen(RefUser, 6, "User", "Usuário inválido!")
            );
        }
    }
}