using Nexalith.Domain.Primitives;

namespace Nexalith.Example.Domain.ValueObjects;

public record CategoryId(Guid Value) : BaseStronglyTypedId<Guid>(Value);