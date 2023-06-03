using WorldCup.View;

namespace WorldCup;

public static class Program
{
    public static void Main(string[] args)
    {
        var view = new GroupViewService();
        view.ShowGroup(1);

        Console.ReadLine();
    }
}