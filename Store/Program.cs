using Store;

var users = new List<User>();
var store = new Stock();
ShowMenu();

void ShowMenu()
{
    var exit = false;
    while (!exit)
    {
        Console.WriteLine("Welcome to the Store!");
        Console.WriteLine("1. Sign-In.");
        Console.WriteLine("2. Log-In.");
        Console.WriteLine("3. Exit.");
        Console.Write("Enter your choice: ");
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                SignIn();
                break;
            case "2":
                LogIn();
                break;
            case "3":
                exit = true;
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
}

void SignIn()
{
    Console.Write("Enter username: ");
    var username = Console.ReadLine();
    Console.Write("Enter password: ");
    var password = Console.ReadLine();

    if (users.Exists(u => u.Username == username))
    {
        Console.WriteLine("Username already exists. Please try logging in.");
    }
    else
    {
        users.Add(new User(username, password));
        Console.WriteLine("User registered successfully.");
    }
}

void LogIn()
{
    Console.Write("Enter username: ");
    var username = Console.ReadLine();
    Console.Write("Enter password: ");
    var password = Console.ReadLine();

    var user = users.Find(u => u.Username == username && u.Password == password);
    if (user != null)
    {
        Console.WriteLine("Login successful!");
        ShowMainMenu();
    }
    else
    {
        Console.WriteLine("Invalid credentials. Please try again.");
    }
}

void ShowMainMenu()
{
    var exit = false;
    while (!exit)
    {
        Console.WriteLine("Main Menu");
        Console.WriteLine("1. Add Product.");
        Console.WriteLine("2. Remove Product.");
        Console.WriteLine("3. View All Products.");
        Console.WriteLine("4. View Product by Type.");
        Console.WriteLine("5. Log Out");
        Console.Write("Enter your choice: ");
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Enter product type (Beverage, Vegetables, Milk, Meat, Fish): ");
                string productType = Console.ReadLine().ToLower();
                Console.Write("Enter product name: ");
                string productName = Console.ReadLine();
                Console.Write("Enter product quantity: ");
                int productQuantity = int.Parse(Console.ReadLine());
                Product product = null;
                switch (productType)
                {
                    case "beverage":
                        product = new Beverage(productName, productQuantity);
                        break;
                    case "vegetables":
                        product = new Vegetables(productName, productQuantity);
                        break;
                    case "milk":
                        product = new Milk(productName, productQuantity);
                        break;
                    case "meat":
                        product = new Meat(productName, productQuantity);
                        break;
                    case "fish":
                        product = new Fish(productName, productQuantity);
                        break;
                    default:
                        Console.WriteLine("Invalid product type.");
                        break;
                }
                store.AddProduct(product);
                break;
            case "2":
                Console.WriteLine("Enter a product to remove: ");
                string productToRemove = Console.ReadLine();
                store.RemoveProduct(productToRemove);
                break;
            case "3":
                store.PrintAll();
                break;
            case "4":
                Console.WriteLine("Enter a product type to view (Beverage, Vegetables, Milk, Meat, Fish): ");
                var productToView = Console.ReadLine().ToLower();
                foreach (var producttoview in store.products)
                {
                    if (producttoview.Quantity > 0)
                    {
                        switch (productToView)
                        {
                            case "beverage":
                                if (producttoview is Beverage)
                                {
                                    Console.WriteLine($"{producttoview.Name} - {producttoview.Quantity} {producttoview.Unit}");
                                }
                                break;
                            case "vegetables":
                                if (producttoview is Vegetables)
                                {
                                    Console.WriteLine($"{producttoview.Name} - {producttoview.Quantity} {producttoview.Unit}");
                                }
                                break;
                            case "milk":
                                if (producttoview is Milk)
                                {
                                    Console.WriteLine($"{producttoview.Name} - {producttoview.Quantity} {producttoview.Unit}");
                                }
                                break;
                            case "meat":
                                if (producttoview is Meat)
                                {
                                    Console.WriteLine($"{producttoview.Name} - {producttoview.Quantity} {producttoview.Unit}");
                                }
                                break;
                            case "Fish":
                                if (producttoview is Fish)
                                {
                                    Console.WriteLine($"{producttoview.Name} - {producttoview.Quantity} {producttoview.Unit}");
                                }
                                break;

                            default:
                                Console.WriteLine("Invalid product type.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{producttoview.Name} is out of stock.");
                    }
                }
                break;

            case "5":
                exit = true;
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
}