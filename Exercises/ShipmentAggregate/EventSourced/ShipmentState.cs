namespace ShipmentAggregate.EventSourced;

public class ShipmentState
{
    public List<StopState> Stops { get; set; } = default!;
    public StopState CurrentStopState { get; set; } = default!;
}

public class StopState
{
    public StopState(int stopId, StopType type, StopStatus status)
    {
        StopId = stopId;
        Type = type;
        Status = status;
    }

    public int StopId { get; set; }
    public StopType Type { get; set; }
    public StopStatus Status { get; set; }
}
