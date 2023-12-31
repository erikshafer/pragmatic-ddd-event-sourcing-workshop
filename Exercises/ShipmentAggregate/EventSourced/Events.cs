﻿namespace ShipmentAggregate.EventSourced;

public interface IEvent { }

public record Dispatched(int ShipmentId, IEnumerable<ShipmentStop> Stops, DateTime Start) : IEvent;

public record Arrived(int StopId, DateTime Arrival) : IEvent;

public record PickedUp(int StopId, DateTime Loaded) : IEvent;

public record Delivered(int StopId, DateTime Delivery) : IEvent;
