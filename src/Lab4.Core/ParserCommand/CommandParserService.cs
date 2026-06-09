using Itmo.ObjectOrientedProgramming.Lab4.Core.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ParserCommand;

public sealed class CommandParserService : ICommandParserService
{
    private readonly CommandParserLinkBase _head;

    public CommandParserService(IFileSystem fileSystem)
    {
        var connect = new ConnectCommandParserLink(fileSystem);
        var disconnect = new DisconnectCommandParserLink(fileSystem);
        var treeGoto = new TreeGotoCommandParserLink(fileSystem);
        var treeList = new TreeListCommandParserLink(fileSystem);
        var fileShow = new FileShowCommandParserLink(fileSystem);
        var fileCopy = new FileCopyCommandParserLink(fileSystem);
        var fileMove = new FileMoveCommandParserLink(fileSystem);
        var fileDelete = new FileDeleteCommandParserLink(fileSystem);
        var fileRename = new FileRenameCommandParserLink(fileSystem);

        connect.SetNext(disconnect);
        disconnect.SetNext(treeGoto);
        treeGoto.SetNext(treeList);
        treeList.SetNext(fileShow);
        fileShow.SetNext(fileCopy);
        fileCopy.SetNext(fileMove);
        fileMove.SetNext(fileDelete);
        fileDelete.SetNext(fileRename);

        _head = connect;
    }

    public ICommand Parse(string input)
    {
        ICommand? command = _head.Handle(input);
        if (command is null)
            throw new ArgumentException("Unknown command");

        return command;
    }
}
