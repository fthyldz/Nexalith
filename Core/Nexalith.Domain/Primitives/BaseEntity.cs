namespace Nexalith.Domain.Primitives;

public abstract class BaseEntity<TEntityId> : BaseEntity
{
    public TEntityId Id { get; protected set; } = default!;
}

public abstract class BaseEntity
{
}