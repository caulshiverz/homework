namespace StudentManagementSystem;

public static class Program
{
    
    public static void Main()
    {
        var schoolClasses = new List<SchoolClass>();
        var users = new List<User>();
        
        var manageSchool = new LoginMenu(users, schoolClasses);
        manageSchool.ShowMenu();
    }
}

