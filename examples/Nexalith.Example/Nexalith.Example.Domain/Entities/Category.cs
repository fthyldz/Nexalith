using Nexalith.Domain.Primitives;
using Nexalith.Example.Domain.ValueObjects;

namespace Nexalith.Example.Domain.Entities;

public class Category : BaseEntity<CategoryId>
{
    protected Category()
    {
    }

    public Category(CategoryId id, string name)
    {
        Id = id;
        Name = name;
    }

    public string Name { get; private set; } = default!;

    public void Update(string name)
    {
        Name = name;
    }
}