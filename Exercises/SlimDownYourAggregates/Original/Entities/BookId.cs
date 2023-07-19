namespace SlimDownYourAggregates.Original.Entities;

public class BookId
{
    public BookId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }
}
