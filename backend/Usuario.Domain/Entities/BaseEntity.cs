using System;

namespace Usuario.Domain.Entities
{
    public abstract class BaseEntity<TKey> : IEntity<TKey>
       where TKey : IComparable, IComparable<TKey>, IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }

    public interface IEntity<TKey>
      where TKey : IComparable, IComparable<TKey>, IEquatable<TKey>
    {
        TKey Id { get; }
    }
}
