using Flunt.Validations;
using Flunt.Notifications;
using TodoApp.Domain.Commands.Contracts;

namespace TodoApp.Domain.Commands;
public class CreateToDoCommand : Notifiable, ICommand
{
    public string? Title { get; set; }
    public DateTime Date { get; set; }
    public string? User { get; set; }

    public CreateToDoCommand() { }
    public CreateToDoCommand(string title, DateTime date, string user)
    {
        Title = title;
        Date = date;
        User = user;
    }

    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .HasMinLen(Title, 3, "Title", "Please inform a valid title")
                .HasMinLen(User, 6, "User", "Please inform a valid user")
        );
    }
}