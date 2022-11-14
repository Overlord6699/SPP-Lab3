
using ScanerLibrary.Entity;
using System;

namespace Scaner_UI.Services;

public class ConvertService : IConvertService
{
    public MemoryObjectModel ConvertToModel(MemoryObject fileData)
    {
        string emoji = "• ";

        if (fileData.Type == MemoryObjectType.Directory)
            emoji += "📁";
        else
            emoji += "📄";

        MemoryObjectModel memoryObjectModel =
            new MemoryObjectModel(fileData.Type, fileData.Name, fileData.Percentage, fileData.Size, emoji);

        foreach (var child in fileData.Children)
            memoryObjectModel.Children.Add(ConvertToModel(child));

        return memoryObjectModel;
    }
}