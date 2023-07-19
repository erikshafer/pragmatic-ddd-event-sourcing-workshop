using SlimDownYourAggregates.Original.Entities;

namespace SlimDownYourAggregates.Original.Services;

public interface IPublishingHouse
{
    bool IsGenreLimitReached(Genre genre);
}

