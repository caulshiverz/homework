namespace Store;

public abstract class Product : ICounteable
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public abstract string Unit { get; set; }

    public Product(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }

    public int CountAmount()
    {
        return Quantity;
    }
}

public interface ICounteable
{
    int CountAmount();
}

public class Beverage : Product, ICounteable
{
    public Beverage(string name, int quantity) : base(name, quantity) { }
    public override string Unit { get; set; } = "bottles";
}

public class Vegetables : Product, ICounteable
{
    public Vegetables(string name, int quantity) : base(name, quantity) { }
    public override string Unit { get; set; } = "kg";
}

public class Milk : Product, ICounteable
{
    public Milk(string name, int quantity) : base(name, quantity) { }
    public override string Unit { get; set; } = "litres";
}

public class Meat : Product, ICounteable
{
    public Meat(string name, int quantity) : base(name, quantity) { }
    public override string Unit { get; set; } = "kg";
}

public class Fish : Product, ICounteable
{
    public Fish(string name, int quantity) : base(name, quantity) { }
    public override string Unit { get; set; } = "kg";
}