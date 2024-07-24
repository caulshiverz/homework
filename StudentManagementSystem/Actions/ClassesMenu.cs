namespace StudentManagementSystem;

public class ClassesMenu
{
    private List<SchoolClass> _classes;

    public ClassesMenu(List<SchoolClass> classes)
    {
        _classes = classes;
    }

    public void ShowManageClassesMenu()
    {
        var exit = false;
        while (!exit)
        {
            Console.WriteLine("Manage Classes");
            Console.WriteLine("1. Add Class");
            Console.WriteLine("2. Remove Class");
            Console.WriteLine("3. View Classes");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Enter your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddClass();
                    break;
                case "2":
                    RemoveClass();
                    break;
                case "3":
                    ViewClasses();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void AddClass()
    {
        Console.Write("Enter class name: ");
        var className = Console.ReadLine();
        _classes.Add(new SchoolClass(className));
        Console.WriteLine("Class added successfully.");
    }

    public void RemoveClass()
    {
        Console.Write("Enter class name to remove: ");
        var className = Console.ReadLine();
        var schoolClass = _classes.Find(c => c.Name == className);
        if (schoolClass != null)
        {
            _classes.Remove(schoolClass);
            Console.WriteLine("Class removed successfully.");
        }
        else
        {
            Console.WriteLine("Class not found.");
        }
    }

    public void ViewClasses()
    {
        foreach (var schoolClass in _classes)
        {
            schoolClass.PrintStudents();
        }
    }
}
