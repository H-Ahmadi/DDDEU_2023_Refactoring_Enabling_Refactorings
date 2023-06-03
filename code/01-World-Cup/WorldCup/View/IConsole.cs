namespace WorldCup.View;

public interface IConsole
{
    void WriteLine(string message);
    void WriteLine(string format, params object[] parameters);
}

public class SystemConsole : IConsole
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
    public void WriteLine(string format, params object[] parameters)
    {
        Console.WriteLine(format, parameters);
    }
}

