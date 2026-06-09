using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ParserCommand;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Runner;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class Program
{
    public static void Main()
    {
        IFileSystem fs = new LocalFileSystem();
        ICommandParserService parser = new CommandParserService(fs);
        var runner = new ApplicationRunner(parser);

        runner.Run();
    }
}
