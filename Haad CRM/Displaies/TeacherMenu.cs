using Haad_CRM.Services;
using Spectre.Console;

namespace Haad_CRM.Displaies;

public class TeacherMenu
{
    public async Task Menu()
    {
        Console.Clear();

        AnsiConsole.Write(new Markup("Enter Teacher [green]email: [/]"));
        string email = Console.ReadLine();

        AnsiConsole.Write(new Markup("Enter Teacher [green]password: [/]"));
        string password = Console.ReadLine();

        var teachers = await TeacherService.GetAllAsync();
        var teacher = teachers.FirstOrDefault(t => t.Email == email && t.Password == password);
        if (teacher is not null)
        {
            bool check = true;
            while (check)
            {
                AnsiConsole.Write(
                new FigletText("Teacher Menu")
                    .LeftJustified()
                    .Color(Color.Gold1));
                var choose = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                .AddChoices(new[] {
                "", "", "","","","","Back"
                }));
                switch (choose)
                {
                   
                }
            }
        }

    }
}
}
