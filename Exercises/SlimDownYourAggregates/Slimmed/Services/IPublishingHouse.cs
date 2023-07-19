using SlimDownYourAggregates.Slimmed.Entities;

namespace SlimDownYourAggregates.Slimmed.Services;

public interface IPublishingHouse
{
    bool IsGenreLimitReached(Genre genre);
}

