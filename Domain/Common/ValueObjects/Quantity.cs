namespace Domain.ValueObjects;

public class Quantity : ValueObject<Quantity>
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
}