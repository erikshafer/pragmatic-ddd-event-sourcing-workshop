namespace SlimDownYourAggregates.Slimmed.Entities;

public class Chapter
{
    public Chapter(ChapterTitle title, ChapterContent content)
    {
        Title = title;
        Content = content;
    }

    public ChapterTitle Title { get; }
    public ChapterContent Content { get; }
}
