using WorldCup.View;

namespace WorldCup;

public static class Program
{
    public static void Main(string[] args)
    {
        //Showing a Group Stage
        var view = new GroupViewService();
        view.ShowGroup(1);



        Console.ReadLine();
    }
}