using System.Runtime.InteropServices;

namespace ShareKarnel
{
    public class Entity<TId> : IEquatable<Entity<TId>>
    {

        protected Entity(TId id)
        {
            if (!IsValid(id))
            {
                 throw new ArgumentException("Identifier is not a supported format");
            }
            Id = id;
        }

        public TId Id{ get; }

        // override Equals methods 
        public override bool Equals(object? obj)
        {
            return Equals(obj as Entity<TId>);
        }
        // override Equals methods 
        public bool Equals(Entity<TId>? other)
        {
            return Id.GetHashCode() == other.Id.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        // == equal opertor  check
        public static  bool operator ==(Entity<TId> lhs,  Entity<TId> rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Entity<TId> lhs, Entity<TId> rhs)
        {
            return !(lhs == rhs);
        }

        private bool IsValid(TId id)
        {
            return id is int || id is long || id is Guid;
        }
    }
}