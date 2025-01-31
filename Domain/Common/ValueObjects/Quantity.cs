using Domain.ValueObjects;

namespace Domain.Common.ValueObjects;

public class Quantity : ValueObject<Quantity>, IComparable<Quantity>
{
    private Quantity()
    {
    }

    private Quantity(int value)
    {
        if (value < 0)
            throw new ArgumentException("Quantity cannot be negative", nameof(value));

        Value = value;
    }

    public int Value { get; init; }

    public static Quantity Create(int value) => new Quantity(value);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public int CompareTo(Quantity? other)
    {
        if (other is null)
            throw new ArgumentNullException(nameof(other));
        
        return Value.CompareTo(other.Value);
    }
}