using SlimDownYourAggregates.Original.Core;
using SlimDownYourAggregates.Original.Entities;

namespace SlimDownYourAggregates.Original.Events;

public record BookPublishedEvent(BookId BookId, Isbn ISBN, Title Title, Author Author): IDomainEvent;
