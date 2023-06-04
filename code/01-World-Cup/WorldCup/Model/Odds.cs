namespace WorldCup.Model;

public abstract class Odds
{

}

public class HomeDrawAwayOdds : Odds //1x2 Odds
{
    public double Home { get; set; }
    public double Draw { get; set; }
    public double Away { get; set; }
}

public class DoubleChanceOdds : Odds
{
    public double HomeOrDraw { get; set; }
    public double AwayOrDraw { get; set; }

}