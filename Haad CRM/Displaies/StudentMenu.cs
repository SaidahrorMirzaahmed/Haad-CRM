using Haad_CRM.Services;
using Spectre.Console;

namespace Haad_CRM.Displaies;

public class StudentMenu
{
    public readonly StudentService StudentService;
    public async Task Menu()
    {
        Console.Clear();

        AnsiConsole.Write(new Markup("Enter Student [green]email: [/]"));
        string email = Console.ReadLine();

        AnsiConsole.Write(new Markup("Enter Student [green]password: [/]"));
        string password = Console.ReadLine();

        var students = await StudentService.GetAllAsync();
        if(students.FirstOrDefault(student => student.Email == email && student.Password == password)
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
                "Attendance", "Lesson", "News","Settings","Back"
                }));
                switch (choose)
                {
                    case "Attendance":
                        break;
                    case "Lesson":
                        await studentMenu.Menu();
                        break;
                    case "News":
                        break;
                    case "Settings":
                        check = false;
                        break;
                    case "Teacher":
                        break;
                    case "Back":
                        check = false;
                        break;
                }
            }
        }

    }
}
