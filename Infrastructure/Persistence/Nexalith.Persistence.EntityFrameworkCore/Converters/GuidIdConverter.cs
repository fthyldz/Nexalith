namespace Nexalith.Persistence.EntityFrameworkCore.Converters;

public class GuidIdConverter()
    : ValueConverter<BaseStronglyTypedId<Guid>, Guid>(id => id.Value,
        id => new BaseStronglyTypedId<Guid>(id));