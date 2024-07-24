namespace StudentManagementSystem;

public class MainMenu
{
    private List<SchoolClass> _classes;
    private ClassesMenu _classesMenu;
    private StudentsMenu _studentsMenu;
    private MarksMenu _marksMenu;
    private ViewInformationMenu _viewInformationMenu;

    public MainMenu(List<SchoolClass> classes)
    {
        _classes = classes;
        _classesMenu = new ClassesMenu(_classes);
        _studentsMenu = new StudentsMenu(_classes);
        _marksMenu = new MarksMenu(_classes);
        _viewInformationMenu = new ViewInformationMenu(_classes);
    }

    public void ShowMainMenu()
    {
        var exit = false;
        while (!exit)
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Manage Classes");
            Console.WriteLine("2. Manage Students");
            Console.WriteLine("3. Manage Marks");
            Console.WriteLine("4. View Information");
            Console.WriteLine("5. Log Out");
            Console.Write("Enter your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _classesMenu.ShowManageClassesMenu();
                    break;
                case "2":
                    _studentsMenu.ManageStudents();
                    break;
                case "3":
                    _marksMenu.ManageMarks();
                    break;
                case "4":
                    _viewInformationMenu.ViewInformation();
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
}
