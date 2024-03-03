using Haad_CRM.Services;
using Spectre.Console;

namespace Haad_CRM.Displaies;
public class MainMenu
{
    public readonly NewService newService;
    public readonly BallService ballService;
    public readonly GroupService groupService;
    public readonly LessonService lessonService;
    public readonly CourseService courseService;
    public readonly TeacherService teacherService;
    public readonly StudentService studentService;
    public readonly AttendanceService attendanceService;
    public readonly AdminService adminService;

    public readonly NewMenu newMenu;
    public readonly BallMenu ballMenu;
    public readonly GroupMenu groupMenu;
    public readonly LessonMenu lessonMenu;
    public readonly CourseMenu courseMenu;
    public readonly StudentMenu studentMenu;
    public readonly TeacherMenu teacherMenu;
    public readonly AttendanceMenu attendanceMenu;
    public readonly AdminMenu adminMenu;

    public MainMenu()
    {
        studentService = new StudentService();
        teacherService = new TeacherService();
        attendanceService = new AttendanceService();
        ballService = new BallService();
        lessonService = new LessonService();
        newService = new NewService();
        groupService = new GroupService();
        courseService = new CourseService();
        adminService = new AdminService();

        studentMenu = new StudentMenu();
        teacherMenu = new TeacherMenu();
        attendanceMenu = new AttendanceMenu();
        ballMenu = new BallMenu();
        lessonMenu = new LessonMenu();
        newMenu = new NewMenu();
        groupMenu = new GroupMenu();
        courseMenu = new CourseMenu();
        adminMenu = new AdminMenu();
    }
    public async Task Menu()
    {
        bool check = true;
        while (check)
        {
            AnsiConsole.Write(
                new FigletText("Main Menu")
                    .LeftJustified()
                    .Color(Color.Gold1));
            var choose= AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
            .AddChoices(new[] {
                "Admin", "Student", "Teacher",
            }));
            switch (choose)
            {
                case "Admin":
                    await adminMenu.Menu();
                    break;
                case "Student":
                    await studentMenu.Menu();
                    break;
                case "Teacher":
                    await teacherMenu.Menu();   
                    break;
            }
        }
    }
}
