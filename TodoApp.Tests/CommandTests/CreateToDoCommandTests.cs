using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoApp.Domain.Commands;

namespace TodoApp.Tests.CommandTests;

[TestClass]
public class CreteToDoCommandTests
{
    private readonly CreateToDoCommand _invalidCommand = new CreateToDoCommand("", System.DateTime.Now, "");
    private readonly CreateToDoCommand _validCommand = new CreateToDoCommand("Valida To Do Command", System.DateTime.Now, "validUserName");

    public CreteToDoCommandTests()
    {
        _invalidCommand.Validate();
        _validCommand.Validate();
    }
    [TestMethod]
    public void Dado_um_commando_invalido()
    {
        Assert.AreEqual(_invalidCommand.Valid, false);
    }
    [TestMethod]
    public void Dado_um_commando_valido()
    {
        Assert.AreEqual(_validCommand.Valid, true);
    }
}