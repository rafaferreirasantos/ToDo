using System;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Repositories;

namespace TodoApp.Tests.Repositories;
public class FakeRepository : IToDoRepository
{
    public void Create(TodoItem todo)
    {

    }

    public TodoItem GetById(Guid id)
    {
        return new TodoItem("Fake To Do Item", DateTime.Now, "FakeUser");
    }

    public void Update(TodoItem todo)
    {

    }
}