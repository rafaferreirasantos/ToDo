using Flunt.Notifications;
using Flunt.Validations;
using TodoApp.Domain.Commands.Contracts;

namespace TodoApp.Domain.Commands;
public class MarkToDoAsUndoneCommand : Notifiable, ICommand
{
    public Guid Id { get; set; }
    public string? User { get; set; }

    public MarkToDoAsUndoneCommand(Guid id, string? user)
    {
        Id = id;
        User = user;
    }

    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .HasMinLen(User, 6, "User", "Please inform a valid user")
                .HasLen(Id.ToString(), 36, "Id", "Please inform a valida Id")
        );
    }
}