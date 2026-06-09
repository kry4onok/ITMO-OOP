namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters.Writers;

public class FileMessageWriter : IMessageWriter
{
    private readonly string _filePath;

    public FileMessageWriter(string filePath)
    {
        _filePath = filePath;
    }

    public void Write(string formattedMessage)
    {
        File.AppendAllText(_filePath, formattedMessage);
    }
}