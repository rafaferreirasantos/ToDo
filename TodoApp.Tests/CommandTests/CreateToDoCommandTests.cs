using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoApp.Domain.Commands;

namespace TodoApp.Tests;

[TestClass]
public class CreteToDoCommandTests
{
    [TestMethod]
    public void Dado_um_commando_invalido()
    {
        var command = new CreateToDoCommand("", System.DateTime.Now, "");
        command.Validate();
        Assert.AreEqual(command.Valid, false);
    }
    [TestMethod]
    public void Dado_um_commando_valido()
    {
        var command = new CreateToDoCommand("Comprar projétil 9mm jaquetado", System.DateTime.Now, "osmarditto@isaclube.com");
        command.Validate();
        Assert.AreEqual(command.Valid, true);
    }
}