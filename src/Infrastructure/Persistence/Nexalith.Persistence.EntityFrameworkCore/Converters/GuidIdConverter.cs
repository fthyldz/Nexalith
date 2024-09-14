using Mapster;

namespace Nexalith.Persistence.EntityFrameworkCore.Converters;

public class GuidIdConverter<TStronglyTypedId>()
    : ValueConverter<TStronglyTypedId, Guid>(id => id.Value,
        id => new BaseStronglyTypedId<Guid>(id).Adapt<TStronglyTypedId>())
    where TStronglyTypedId : BaseStronglyTypedId<Guid>;