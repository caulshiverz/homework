namespace StudentManagementSystem;

public class StudentsMenu
{
    private List<SchoolClass> _classes;

    public StudentsMenu(List<SchoolClass> classes)
    {
        _classes = classes;
    }

    public void ManageStudents()
    {
        var exit = false;
        while (!exit)
        {
            Console.WriteLine("Manage Students");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Remove Student");
            Console.WriteLine("3. Back to Main Menu");
            Console.Write("Enter your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    RemoveStudent();
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
    
    public void AddStudent()
    {
        Console.Write("Enter student name: ");
        var name = Console.ReadLine();
        Console.Write("Enter student age: ");
        // var studentAge = 0;
        var age = 0;
        if (int.TryParse(Console.ReadLine(), out var studentAge))
        {
            age = studentAge;
        }
        else
        {
            Console.WriteLine("Invalid age format.");
            return;
        }
        Console.Write("Enter student class: ");
        var studentClass = Console.ReadLine();

        var schoolClass = _classes.Find(c => c.Name == studentClass);
        if (schoolClass != null)
        {
            schoolClass.Students.Add(new Student(name, age, studentClass));
            Console.WriteLine("Student added successfully.");
        }
        else
        {
            Console.WriteLine("Class not found.");
        }
    }

    public void RemoveStudent()
    {
        Console.Write("Enter student name to remove: ");
        var name = Console.ReadLine();
        var found = false;

        foreach (var schoolClass in _classes)
        {
            var student = schoolClass.Students.Find(s => s.Name == name);
            if (student != null)
            {
                schoolClass.Students.Remove(student);
                Console.WriteLine("Student removed successfully.");
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Student not found.");
        }
    }
}
