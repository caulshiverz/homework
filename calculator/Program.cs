string reply;

do
{
    int result;
    double divisionResult;
    
    Console.WriteLine("Enter the first number:");
    string firstInput = Console.ReadLine();
    int firstNumber = Convert.ToInt32(firstInput);

    Console.WriteLine("Enter an operation to perform (addition, subtraction, multiplication, division):");
    string operation = Console.ReadLine().ToLower();

    Console.WriteLine("Enter the second number:");
    string secondInput = Console.ReadLine();
    int secondNumber = Convert.ToInt32(secondInput);

    switch (operation)
    {
        case "addition":
        result = firstNumber + secondNumber;
        Console.WriteLine($"Result: {result}");
        break;

        case "subtraction":
        result = firstNumber - secondNumber;
        Console.WriteLine($"Result: {result}");
        break;

        case "multiplication":
        result = firstNumber * secondNumber;
        Console.WriteLine($"Result: {result}");
        break;

        case "division":
        if (secondNumber != 0)
        {
            divisionResult = (double)firstNumber / (double)secondNumber;
            Console.WriteLine($"Result: {divisionResult}");
        }
        else
        {
            Console.WriteLine("Error! You cannot divide by zero.");
        }
        break;

        default:
        Console.WriteLine("Error! Invalid operation.");
        break;
    }

    Console.WriteLine("Do you want to continue? (y/n)");
    reply = Console.ReadLine().ToLower();
}
while (reply == "y");