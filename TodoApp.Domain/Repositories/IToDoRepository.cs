using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Repositories;
public interface IToDoRepository
{
    void Create(TodoItem todo);
    void Update(TodoItem todo);
    TodoItem GetById(Guid id);
}