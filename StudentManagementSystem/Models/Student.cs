namespace StudentManagementSystem;

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Class { get; set; }
    public Dictionary<string, int> Marks { get; set; }

    public Student(string name, int age, string studentClass)
    {
        Name = name;
        Age = age;
        Class = studentClass;
        Marks = new Dictionary<string, int>();
    }

    public double GetAverageMark()
    {
        if (Marks.Count == 0) return 0;
        double sum = 0;
        foreach (var mark in Marks.Values)
        {
            sum += mark;
        }

        return sum / Marks.Count;
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Class: {Class}, Average Mark: {GetAverageMark():F2}");
    }
}
