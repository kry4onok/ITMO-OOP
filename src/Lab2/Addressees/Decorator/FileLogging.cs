using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees.Decorator;

public class FileLogging : ILogging
{
    private readonly string _logDirectory;

    private readonly string _logFilePath;

    public FileLogging(string logDirectory)
    {
        _logDirectory = logDirectory;

        if (!Directory.Exists(_logDirectory))
        {
            Directory.CreateDirectory(_logDirectory);
        }

        _logFilePath = Path.Combine(_logDirectory, "log.txt");
    }

    public void Log(IMessage message)
    {
        string logEntry = $"[{DateTime.Now:yyyy:MM:dd HH:mm:ss} {message}{Environment.NewLine}]";

        File.AppendAllText(_logFilePath, logEntry);
    }
}