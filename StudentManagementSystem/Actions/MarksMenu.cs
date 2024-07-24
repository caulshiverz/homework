namespace StudentManagementSystem;

public class MarksMenu
{
    private List<SchoolClass> _classes;

    public MarksMenu(List<SchoolClass> classes)
    {
        _classes = classes;
    }

    public void ManageMarks()
    {
        Console.Write("Enter student name to manage marks: ");
        var name = Console.ReadLine();
        var student = FindStudent(name);
        if (student != null)
        {
            var exit = false;
            while (!exit)
            {
                Console.WriteLine("Manage Marks");
                Console.WriteLine("1. Add/Update Marks");
                Console.WriteLine("2. Remove Marks");
                Console.WriteLine("3. Back to Main Menu");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddUpdateMarks(student);
                        break;
                    case "2":
                        RemoveMarks(student);
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
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    public void AddUpdateMarks(Student student)
    {
        Console.Write("Enter subject (Math, English, Biology, Geography): ");
        string subject = Console.ReadLine();
        Console.Write("Enter mark: ");
        var mark = 0;
        if (int.TryParse(Console.ReadLine(), out var studentMark))
        {
            mark = studentMark;
        }
        else
        {
            Console.WriteLine("Invalid mark format.");
            return;
        }
        student.Marks[subject] = mark;
        Console.WriteLine("Mark added/updated successfully.");
    }

    public Student FindStudent(string name)
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

    public void RemoveMarks(Student student)
    {
        Console.Write("Enter subject (Math, English, Biology, Geography) to remove mark: ");
        string subject = Console.ReadLine();
        if (student.Marks.ContainsKey(subject))
        {
            student.Marks.Remove(subject);
            Console.WriteLine("Mark removed successfully.");
        }
        else
        {
            Console.WriteLine("Subject not found.");
        }
    }
}
