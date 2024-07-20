var userCredentialsAndBalance = new Dictionary<string, (string password, decimal balance)>();

while (true)
{
    Console.WriteLine("Welcome! Please select an option below (1, 2, 3). Note that you need to sign in order to be able to log in.");
    Console.WriteLine("1. Log-in.");
    Console.WriteLine("2. Sign-in.");
    Console.WriteLine("3. Leave.");

    var startSelection = Console.ReadLine();

    switch (startSelection)
    {
        case "1":
            Console.WriteLine("Please enter your credentials.");
            Console.WriteLine("Username:");
            var usernameLogin = Console.ReadLine();
            Console.WriteLine("Password:");
            var passwordLogin = Console.ReadLine();
            if (!(userCredentialsAndBalance.ContainsKey(usernameLogin) && userCredentialsAndBalance[usernameLogin].password == passwordLogin))
            {
                Console.WriteLine("Error! Wrong credentials.");
            }
            else
            {
                var secondaryMenu = true;
                while (secondaryMenu)
                {
                    Console.WriteLine("Select an operation to perform (1, 2, 3, 4).");
                    Console.WriteLine("1. Check Balance.");
                    Console.WriteLine("2. Deposit.");
                    Console.WriteLine("3. Withdraw.");
                    Console.WriteLine("4. Log out.");

                    var loginSelection = Console.ReadLine();

                    switch (loginSelection)
                    {
                        case "1":
                            Console.WriteLine($"Your current balance is: {userCredentialsAndBalance[usernameLogin].balance}");
                            break;

                        case "2":
                            Console.WriteLine("Enter an amount you want to deposit:");
                            var depositAmount = Convert.ToDecimal(Console.ReadLine());
                            userCredentialsAndBalance[usernameLogin] = (userCredentialsAndBalance[usernameLogin].password, userCredentialsAndBalance[usernameLogin].balance + depositAmount);
                            Console.WriteLine($"Operation successful! Your new balance is: {userCredentialsAndBalance[usernameLogin].balance}");
                            break;

                        case "3":
                            if (userCredentialsAndBalance[usernameLogin].balance <= 0)
                            {
                                Console.WriteLine("Error! You have insufficient funds.");
                            }
                            else
                            {
                                Console.WriteLine("Enter an amount to withdraw:");
                                var withdrawalAmount = Convert.ToDecimal(Console.ReadLine());
                                if (withdrawalAmount > userCredentialsAndBalance[usernameLogin].balance)
                                {
                                    Console.WriteLine("Error! You have insufficient funds.");
                                }
                                else
                                {
                                    userCredentialsAndBalance[usernameLogin] = (userCredentialsAndBalance[usernameLogin].password, userCredentialsAndBalance[usernameLogin].balance - withdrawalAmount);
                                    Console.WriteLine($"Operation successful! Your remaining balance is: {userCredentialsAndBalance[usernameLogin].balance}");
                                }
                            }
                            break;

                        case "4":
                            Console.WriteLine("Good luck!");
                            secondaryMenu = false;
                            break;

                        default:
                            Console.WriteLine("Invalid selection. Please try again.");
                            break;
                    }
                }
            }
            break;

        case "2":
            Console.WriteLine("Please enter your credentials.");
            Console.WriteLine("Username:");
            var usernameSignin = Console.ReadLine();

            if (userCredentialsAndBalance.ContainsKey(usernameSignin))
            {
                Console.WriteLine("Error! This username already exists.");
            }
            else
            {
                Console.WriteLine("Password:");
                var passwordSignin = Console.ReadLine();
                userCredentialsAndBalance.Add(usernameSignin, (passwordSignin, 0));
                Console.WriteLine("Account created successfully!");
            }
            break;

        case "3":
            Console.WriteLine("Good luck!");
            return;

        default:
            Console.WriteLine("Invalid selection. Please try again.");
            break;
    }
}