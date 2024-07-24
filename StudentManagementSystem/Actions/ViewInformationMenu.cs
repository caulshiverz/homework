namespace StudentManagementSystem;

public class ViewInformationMenu
{
    private readonly List<SchoolClass> _classes;

    public ViewInformationMenu(List<SchoolClass> classes)
    {
        _classes = classes;
    }

    public void ViewInformation()
    {
        var exit = false;
        while (!exit)
        {
            Console.WriteLine("1. View Student Details");
            Console.WriteLine("2. View Class Details");
            Console.WriteLine("3. Back to Main Menu");
            Console.Write("Enter your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewStudentDetails();
                    break;
                case "2":
                    ViewClassDetails();
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

    public void ViewStudentDetails()
    {
        Console.Write("Enter student name to view details: ");
        string name = Console.ReadLine();
        var student = FindStudent(name);
        if (student != null)
        {
            student.DisplayDetails();
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    public void ViewClassDetails()
    {
        Console.Write("Enter class name to view details: ");
        string className = Console.ReadLine();
        var schoolClass = _classes.Find(c => c.Name == className);
        if (schoolClass != null)
        {
            schoolClass.PrintStudents();
        }
        else
        {
            Console.WriteLine("Class not found.");
        }
    }

    private Student FindStudent(string name)
    {
        foreach (var schoolClass in _classes)
        {
            var student = schoolClass.Students.Find(s => s.Name == name);
            if (student != null)
            {
                return student;
            }
        }

        return null;
    }

}
