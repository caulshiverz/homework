namespace Store;

public class Stock
{
    public List<Product> products = new List<Product>();

    public void PrintAll()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("The store is empty.");
            return;
        }

        Console.WriteLine("List of all products:");
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Name} - {product.Quantity} {product.Unit}");
        }
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
        Console.WriteLine($"{product.Name} has been addded to the stock.");
    }

    public void RemoveProduct(string productName)
    {
        for (int i = products.Count - 1; i >= 0; i--)
        {
            if (productName != null && products[i].Name == productName)
            {

                products.RemoveAt(i);
                Console.WriteLine($"{productName} has been removed from the stock.");
            }
            else
            {
                Console.WriteLine($"{productName} not found.");
            }
        }
    }
}