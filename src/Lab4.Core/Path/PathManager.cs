namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Path;

public sealed class PathManager
{
    public PathVO? ConnectionPath { get; private set; }

    public PathVO? CurrentLocalPath { get; private set; }

    public bool IsConnected => ConnectionPath is not null;

    public void SetConnectionPath(PathVO connectionPath)
    {
        ConnectionPath = connectionPath;
        CurrentLocalPath = connectionPath;
    }

    public void ClearPaths()
    {
        ConnectionPath = null;
        CurrentLocalPath = null;
    }

    public void SetCurrentLocalPath(PathVO path)
    {
        CurrentLocalPath = path;
    }

    public PathVO ResolvePath(PathVO userPath)
    {
        if (userPath.IsAbsolute)
        {
            return userPath;
        }

        if (CurrentLocalPath is null)
            throw new InvalidOperationException("Not connected.");

        string combined = System.IO.Path.Combine(CurrentLocalPath.Value, userPath.Value);
        string normalized = System.IO.Path.GetFullPath(combined);
        return new PathVO(normalized);
    }

    public bool IsWithinConnection(PathVO targetPath)
    {
        if (ConnectionPath is null)
            return false;

        string connFull = System.IO.Path.GetFullPath(ConnectionPath.Value).TrimEnd(System.IO.Path.DirectorySeparatorChar);
        string targFull = System.IO.Path.GetFullPath(targetPath.Value).TrimEnd(System.IO.Path.DirectorySeparatorChar);

        return targFull == connFull || targFull.StartsWith(connFull + System.IO.Path.DirectorySeparatorChar);
    }
}
