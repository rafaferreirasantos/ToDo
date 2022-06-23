using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoApp.Domain.Commands;
using TodoApp.Domain.Handlers;
using TodoApp.Tests.Repositories;

namespace TodoApp.Tests.HandlerTests;
[TestClass]
public class CreateTodoHandlerTests
{
    private readonly CreateToDoCommand _invalidCommand = new CreateToDoCommand("", System.DateTime.Now, "");
    private readonly CreateToDoCommand _validCommand = new CreateToDoCommand("Valida To Do Command", System.DateTime.Now, "validUserName");
    private readonly ToDoHandler _handler = new ToDoHandler(new FakeRepository());
    [TestMethod]
    public void Dado_um_commando_invalido_deve_interromper_a_execucao()
    {
        var result = (GenericCommandResult)_handler.Handle(_invalidCommand);
        Assert.AreEqual(result.Success, false);
    }
    [TestMethod]
    public void Dado_um_commando_valido_deve_concluir_a_execucao()
    {
        var result = (GenericCommandResult)_handler.Handle(_validCommand);
        Assert.AreEqual(result.Success, true);
    }
}