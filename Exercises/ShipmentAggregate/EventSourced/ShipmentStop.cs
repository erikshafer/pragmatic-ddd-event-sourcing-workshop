namespace ShipmentAggregate.EventSourced;

public record ShipmentStop(int StopId, StopType StopType, int Sequence);
