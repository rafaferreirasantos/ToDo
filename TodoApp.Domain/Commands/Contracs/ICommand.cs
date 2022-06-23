using Flunt.Validations;
using Flunt.Notifications;

namespace TodoApp.Domain.Commands.Contracts;
public interface ICommand : IValidatable
{
    IReadOnlyCollection<Notification> Notifications { get; }
}