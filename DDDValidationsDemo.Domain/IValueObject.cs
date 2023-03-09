namespace DDDValidationsDemo.Domain
{
    public interface IValueObject<T> where T : IValueObject<T>
    {
        public bool IsEquivalentTo(T other);
    }
}