using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoApp.Domain.Commands;

namespace TodoApp.Tests;

[TestClass]
public class CreteToDoCommandTests
{
    private readonly CreateToDoCommand _invalidCommand = new CreateToDoCommand("", System.DateTime.Now, "");
    private readonly CreateToDoCommand _validCommand = new CreateToDoCommand("", System.DateTime.Now, "");

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