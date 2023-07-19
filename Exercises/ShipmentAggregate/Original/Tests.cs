﻿using Shouldly;
using Xunit;

namespace ShipmentAggregate.Original;

public class Tests
{
    private readonly ShipmentAggregate _aggregate;

    public Tests()
    {
        _aggregate = new ShipmentAggregate
        {
            Stops = new List<Stop>
            {
                new()
                {
                    StopId = 1,
                    Sequence = 1,
                    Type = StopType.Pickup
                },
                new()
                {
                    StopId = 2,
                    Sequence = 2,
                    Type = StopType.Delivery
                }
            }
        };
    }

    [Fact]
    public void CompleteShipment()
    {
        _aggregate.Arrive(1);
        _aggregate.Pickup(1);
        _aggregate.Arrive(2);
        _aggregate.Deliver(2);
        _aggregate.IsComplete().ShouldBeTrue();
    }

    [Fact]
    public void CannotPickupWithoutArriving()
    {
        Should.Throw<InvalidOperationException>(() =>
            _aggregate.Pickup(1), "Stop hasn't arrived yet.");
    }

    [Fact]
    public void CannotDeliverWithoutArriving()
    {
        Should.Throw<InvalidOperationException>(() =>
            _aggregate.Deliver(2), "Stop hasn't arrived yet.");
    }

    [Fact]
    public void CannotPickupAtDelivery()
    {
        Should.Throw<InvalidOperationException>(() =>
            _aggregate.Pickup(2), "Stop is not a delivery.");
    }

    [Fact]
    public void CannotDeliverAtPickup()
    {
        Should.Throw<InvalidOperationException>(() =>
            _aggregate.Deliver(1), "Stop is not a pickup.");
    }

    [Fact]
    public void ArriveStopDoesNotExist()
    {
        Should.Throw<InvalidOperationException>(() =>
            _aggregate.Arrive(0), "Stop does not exist.");
    }

    [Fact]
    public void PickupStopDoesNotExist()
    {
        Should.Throw<InvalidOperationException>(() =>
            _aggregate.Pickup(0), "Stop does not exist.");
    }

    [Fact]
    public void DeliverStopDoesNotExist()
    {
        Should.Throw<InvalidOperationException>(() =>
            _aggregate.Deliver(0), "Stop does not exist.");
    }

    [Fact]
    public void ArriveNonDepartedStops()
    {
        _aggregate.Arrive(1);
        Should.Throw<InvalidOperationException>(() =>
            _aggregate.Arrive(2), "Previous stops have not departed.");
    }

    [Fact]
    public void AlreadyArrived()
    {
        _aggregate.Arrive(1);
        Should.Throw<InvalidOperationException>(() =>
            _aggregate.Arrive(1), "Stop has already arrived.");
    }

    [Fact]
    public void AlreadyPickedUp()
    {
        _aggregate.Arrive(1);
        _aggregate.Pickup(1);
        Should.Throw<InvalidOperationException>(() =>
            _aggregate.Pickup(1), "Stop has already departed.");
    }

    [Fact]
    public void AlreadyDelivered()
    {
        _aggregate.Arrive(1);
        _aggregate.Pickup(1);
        _aggregate.Arrive(2);
        _aggregate.Deliver(2);
        Should.Throw<InvalidOperationException>(() =>
            _aggregate.Deliver(2), "Stop has already departed.");
    }
}
