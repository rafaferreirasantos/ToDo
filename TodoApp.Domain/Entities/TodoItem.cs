namespace TodoApp.Domain.Entities;
public class TodoItem : Entity
{
    public string Title { get; private set; }
    public bool Done { get; private set; }
    public DateTime Date { get; private set; }
    public string User { get; private set; }

    public TodoItem(string title, DateTime date, string user)
    {
        Title = title;
        Done = false;
        Date = date;
        User = user;
    }
    public void SetAsCompleted() { Done = true; }
    public void SetAsNotCompleted() { Done = false; }
    public void UpdateTitle(string title) { Title = title; }
}