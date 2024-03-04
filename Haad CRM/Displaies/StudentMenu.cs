using Haad_CRM.Services;
using Spectre.Console;

namespace Haad_CRM.Displaies;

public class StudentMenu
{
    public readonly NewMenu NewMenu;
    public readonly StudentMenu studentMenu;
    public readonly StudentService StudentService;
    public readonly AttendanceMenu AttendanceMenu;
    public async Task Menu()
    {
        Console.Clear();

        AnsiConsole.Write(new Markup("Enter Student [green]email: [/]"));
        string email = Console.ReadLine();

        AnsiConsole.Write(new Markup("Enter Student [green]password: [/]"));
        string password = Console.ReadLine();

        var students = await StudentService.GetAllAsync();
        var student = students.FirstOrDefault(student => student.Email == email && student.Password == password);
        if(student is not null)
        {
            bool check = true;
            while (check)
            {
                AnsiConsole.Write(
                new FigletText("Student Menu")
                    .LeftJustified()
                    .Color(Color.Gold1));
                var choose = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                .AddChoices(new[] {
                "Attendance", "Lesson", "News","TimeTable","Rating","Settings","Back"
                }));
                switch (choose)
                {
                    case "Attendance":
                        await AttendanceMenu.Menu(student.Id);
                        break;
                    case "Lesson":
                        await studentMenu.Menu(student.Id);
                        break;
                    case "News":
                        await NewMenu.Menu(student.Id);
                        break;
                    case "TimeTable":
                        break;
                    case "Rating":
                        break;
                    case "Settings":
                        break;
                    case "Back":
                        check = false;
                        break;
                }
            }
        }

    }
}
