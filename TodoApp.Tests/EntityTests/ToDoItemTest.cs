using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoApp.Domain.Entities;

namespace TodoApp.Tests.EntityTests;
[TestClass]
public class ToDoItemTests
{
    private readonly TodoItem _toDo = new TodoItem("New To Do", System.DateTime.Now, "newUser");
    [TestMethod]
    public void Dado_um_novo_ToDo_o_mesmo_nao_pode_estar_concluido()
    {
        Assert.AreEqual(_toDo.Done, false);
    }
}