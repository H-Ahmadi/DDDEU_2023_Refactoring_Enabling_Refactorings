using WorldCup.Services;
using WorldCup.View;

namespace WorldCup;

public static class Program
{
    public static void Main(string[] args)
    {
        GroupViewService.DrawGroup(1);

        Console.ReadLine();
    }
}