using Flunt.Notifications;
using Flunt.Validations;
using TodoApp.Domain.Commands;
using TodoApp.Domain.Commands.Contracts;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Handlers.Contracts;
using TodoApp.Domain.Repositories;

namespace TodoApp.Domain.Handlers;
public class ToDoHandler :
    Notifiable,
    IHandler<CreateToDoCommand>,
    IHandler<UpdateToDoCommand>
{
    IToDoRepository _repo;

    public ToDoHandler(IToDoRepository repository)
    {
        _repo = repository;
    }
    public ICommandResult Handle(CreateToDoCommand command)
    {
        command.Validate();
        if (command.Invalid)
            return GetInvalidCommandReturn(command);
        var toDo = new TodoItem(command.Title!, command.Date, command.User!);
        _repo.Create(toDo);
        return new GenericCommandResult(true, "To do Task  successfully saved", toDo);
    }
    public ICommandResult Handle(UpdateToDoCommand command)
    {
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Ops, it seems that your task is not ok", command.Notifications);
        var toDo = _repo.GetById(command.Id);
        toDo.UpdateTitle(command.Title!);
        _repo.Update(toDo);
        return new GenericCommandResult(true, "To do Task  successfully updated", toDo);
    }
    public ICommandResult Handle(MarkToDoAsDoneCommand command)
    {
        command.Validate();
        if (command.Invalid)
            return GetInvalidCommandReturn(command);
        TodoItem toDo = _repo.GetById(command.Id);
        toDo.SetAsCompleted();
        _repo.Update(toDo);
        return new GenericCommandResult(true, "To do Task  successfully marked as done", toDo);
    }
    public ICommandResult Handle(MarkToDoAsUndoneCommand command)
    {
        command.Validate();
        if (command.Invalid)
            return GetInvalidCommandReturn(command);
        TodoItem toDo = _repo.GetById(command.Id);
        toDo.SetAsNotCompleted();
        _repo.Update(toDo);
        return new GenericCommandResult(true, "To do Task  successfully marked as undone", toDo);
    }
    private ICommandResult GetInvalidCommandReturn(ICommand command)
    {
        return new GenericCommandResult(false, "Ops, it seems that your task is not ok", command.Notifications);
    }
}