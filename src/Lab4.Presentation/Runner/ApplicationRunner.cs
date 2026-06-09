using Itmo.ObjectOrientedProgramming.Lab4.Core.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.State;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ParserCommand;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Runner;

public sealed class ApplicationRunner
{
    private readonly ICommandParserService _parser;

    public ApplicationRunner(ICommandParserService parser)
    {
        _parser = parser;
    }

    public void Run()
    {
        while (true)
        {
            string? input = Console.ReadLine();
            if (input is null || input == "exit")
                break;

            try
            {
                ICommand command = _parser.Parse(input);
                CommandResult result = command.Execute();

                if (result.IsFailure)
                    Console.WriteLine("Command failed");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
