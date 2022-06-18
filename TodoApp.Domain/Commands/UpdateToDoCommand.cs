using Flunt.Notifications;
using Flunt.Validations;
using TodoApp.Domain.Commands.Contracts;

namespace TodoApp.Domain.Commands;
public class UpdateToDoCommand : Notifiable, ICommand
{
    public Guid Id { get; set; }
    public string? User { get; set; }
    public string? Title { get; set; }

    public UpdateToDoCommand(Guid id, string? user, string? title)
    {
        Id = id;
        User = user;
        Title = title;
    }

    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .HasMinLen(Title, 4, "Title", "Pleas inform a title with at least 4 characters")
                .HasMinLen(User, 6, "User", "Please inform a valid user")
        );
    }
}