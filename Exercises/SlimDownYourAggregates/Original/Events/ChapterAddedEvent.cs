using SlimDownYourAggregates.Original.Core;
using SlimDownYourAggregates.Original.Entities;

namespace SlimDownYourAggregates.Original.Events;

public record ChapterAddedEvent(BookId BookId, Chapter Chapter): IDomainEvent;
