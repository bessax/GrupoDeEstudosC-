using System.Reflection;

namespace ByteBank.Domain.SeedWork;

public abstract class Enumeration : IComparable
{
    public Enumeration(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; }
    public string Name { get; }

    public override string ToString() => Name;

    public static IEnumerable<T> GetAll<T>()
        where T : Enumeration
    {
        return typeof(T).GetFields(
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.DeclaredOnly)
            .Select(f => f.GetValue(null))
            .Cast<T>();
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Enumeration otherValue)
        {
            return false;
        }

        var typeMatches = GetType().Equals(obj.GetType());
        var valueMatches = Id.Equals(otherValue.Id);

        return typeMatches && valueMatches;
    }

    public override int GetHashCode() => Id.GetHashCode();

    public int CompareTo(object? other)
    {
        if (other is null)
        {
            return 1;
        }

        return Id.CompareTo(((Enumeration)other).Id);
    }
}