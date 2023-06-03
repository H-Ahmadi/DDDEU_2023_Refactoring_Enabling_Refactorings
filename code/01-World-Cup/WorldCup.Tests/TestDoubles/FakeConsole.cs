using System.Text;
using WorldCup.View;

namespace WorldCup.Tests.TestDoubles;

public class FakeConsole : IConsole
{
    private readonly StringBuilder _consoleOutput = new();
    public void WriteLine(string message)
    {
        _consoleOutput.AppendLine(message);
    }
    public void WriteLine(string format, params object[] parameters)
    {
        _consoleOutput.AppendFormat(format, parameters).AppendLine();
    }

    public string GetOutput()=> _consoleOutput.ToString();
}
