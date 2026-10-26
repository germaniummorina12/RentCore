namespace RentCore.Domain.Abstractions;

public abstract class BaseEntity<TId>
{
    public TId Id { get; protected set; } = default!;

    private readonly List<object> _domainEvents = new();
    public IReadOnlyCollection<object> DomainEvents => _domainEvents.AsReadOnly();

    protected void Raise(object domainEvent) => _domainEvents.Add(domainEvent);
    public void ClearDomainEvents() => _domainEvents.Clear();
}