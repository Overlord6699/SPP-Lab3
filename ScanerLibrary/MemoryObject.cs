using System.Collections.Concurrent;

namespace ScanerLibrary.Entity;

public enum MemoryObjectType
{
    File,
    Directory
}

public class MemoryObject
{
    public MemoryObjectType Type { get; set; }
    public string Name { get; set; }
    public double Size { get; set; }
    public ConcurrentBag<MemoryObject> Children { get; set; }
    public double Percentage { get; set; }
   

    public MemoryObject(MemoryObjectType type, string name)
    {
        Type = type;
        Name = name;
    }

    public MemoryObject(MemoryObjectType type, string name, double size) : this(type, name)
    {
        Size = size;
        Children = new ConcurrentBag<MemoryObject>();
    }
}