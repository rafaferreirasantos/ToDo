using Flunt.Notifications;

namespace TodoApp.Domain.Entities;
public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; }

    protected Entity()
        => Id = Guid.NewGuid();

    public bool Equals(Entity? other) => other is not null && Id.Equals(other?.Id);
}