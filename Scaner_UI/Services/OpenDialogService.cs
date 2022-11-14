using Ookii.Dialogs.Wpf;

namespace Scaner_UI.Services;


public class OpenDialogService : IDialogService
{
    public string DirectoryPath { get; set; }

    public bool OpenDirectoryDialog()
    {
        var dialog = new VistaFolderBrowserDialog();

        if (dialog.ShowDialog() == true)
        {
            DirectoryPath = dialog.SelectedPath;
            return true;
        }

        return false;
    }
}