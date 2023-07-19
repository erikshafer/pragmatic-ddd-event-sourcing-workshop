using SlimDownYourAggregates.Original.Core;
using SlimDownYourAggregates.Original.Entities;

namespace SlimDownYourAggregates.Original.Events;

public record BookMovedToEditingEvent(BookId BookId): IDomainEvent;
