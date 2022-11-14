using System;
using System.Collections.ObjectModel;
using ScanerLibrary.Entity;

namespace Scaner_UI;

public class MemoryObjectModel
{
    public MemoryObjectType Type { get; set; }
    public string Name { get; set; }
    public double Size { get; set; }
    public string Emoji { get; set; }
    public double Percentage { get; set; }
    public ObservableCollection<MemoryObjectModel> Children { get; set; }
    public MemoryObjectModel(MemoryObjectType type, string name, double percent, double size, string emoji)
    {
        Type = type;
        Name = name;
        Percentage = percent;
        Emoji = emoji;
        Size = size;
        Children = new ObservableCollection<MemoryObjectModel>();
    }
}