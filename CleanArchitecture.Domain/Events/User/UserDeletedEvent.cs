using System;
using CleanArchitecture.Domain.DomainEvents;

namespace CleanArchitecture.Domain.Events.User;

public sealed class UserDeletedEvent : DomainEvent
{
    public UserDeletedEvent(Guid userId) : base(userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; }
}