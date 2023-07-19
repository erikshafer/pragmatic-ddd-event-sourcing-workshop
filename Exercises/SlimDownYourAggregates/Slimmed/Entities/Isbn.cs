namespace SlimDownYourAggregates.Slimmed.Entities;

public class Isbn
{
    public Isbn(string number)
    {
        Number = number;
    }

    public string Number { get; }
}
