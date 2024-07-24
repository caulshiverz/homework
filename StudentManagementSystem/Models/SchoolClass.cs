namespace StudentManagementSystem;

public class SchoolClass
{
    public string Name { get; }
    public List<Student> Students = new();
    public int AverageMarks { get; }

    public SchoolClass(string name)
    {
        Name = name;
    }

    public void PrintStudents()
    {
        foreach (var student in Students)
        {
            Console.WriteLine($"{student.Class}: {student.Name} ({student.Age}) marks: {student.GetAverageMark():F2}");
        }
    }
}
