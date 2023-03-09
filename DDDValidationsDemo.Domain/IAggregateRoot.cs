namespace DDDValidationsDemo.Domain
{
    public interface IAggregateRoot : IEntity
    {
        byte[] ResourceVersion { get; }
    }
}