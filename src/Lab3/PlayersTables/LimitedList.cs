namespace Itmo.ObjectOrientedProgramming.Lab3.PlayersTables;

public class LimitedList<T>
{
    private readonly List<T> innerList = new List<T>();
    private readonly int maxSize;

    public LimitedList(int maxSize)
    {
        if (maxSize <= 0)
        {
            throw new ArgumentException("The maximum size must be greater than zero.", nameof(maxSize));
        }

        this.maxSize = maxSize;
    }

    public int Count => innerList.Count;

    public void Add(T item)
    {
        if (innerList.Count >= maxSize)
        {
            throw new InvalidOperationException($"Item cannot be added: the limit of {maxSize} items has been exceeded.");
        }

        innerList.Add(item);
    }

    public void Remove(T item)
    {
        innerList.Remove(item);
    }

    public bool Contains(T item)
    {
        return innerList.Contains(item);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return innerList.GetEnumerator();
    }
}