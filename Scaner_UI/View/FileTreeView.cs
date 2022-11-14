using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;
using Scaner_UI.Services;
using ScanerLibrary;

namespace Scaner_UI;

public class FileTreeModel : INotifyPropertyChanged
{
    public ObservableCollection<MemoryObjectModel> FileDataModels { get; set; }


    public event PropertyChangedEventHandler PropertyChanged;

    private static Button _startBtn;
    private static Button _cancelBtn;


    private IDialogService _dialogService;
    private IConvertService _convertService;

    private RelayCommand _startCommand;
    private RelayCommand _cancelCommand;

    public static void SetButtons(Button startBtn, Button cancelBtn)
    {
        _startBtn = startBtn;
        _cancelBtn = cancelBtn;
    }


    public FileTreeModel(IDialogService dialogService, IConvertService convertService)
    {
        _dialogService = dialogService;
        _convertService = convertService;

        FileDataModels = new ObservableCollection<MemoryObjectModel>();
    }

    public RelayCommand StartCommand
    {
        get
        {
            return _startCommand =
                (_startCommand = new RelayCommand(async obj =>
                {
                    if (_dialogService.OpenDirectoryDialog() == true)
                    {
                        _startBtn.IsEnabled = false;
                        _startBtn.Background = Brushes.Red;

                        _cancelBtn.IsEnabled = true;
                        _cancelBtn.Background = Brushes.Green;

                        var rootFileTree =
                            _convertService.ConvertToModel(await DirectoryScanner.StartScan(_dialogService.DirectoryPath));
                       
                        FileDataModels.Clear();
                        FileDataModels.Add(rootFileTree);
                    }

                    SwitchMode();
                }));
        }
    }


    public void SwitchMode()
    {
        _startBtn.IsEnabled = true;
        _startBtn.Background = Brushes.Green;

        _cancelBtn.IsEnabled = false;
        _cancelBtn.Background = Brushes.Red;
    }

    public RelayCommand CancelCommand
    {
        get
        {
            return _cancelCommand =
                (_cancelCommand = new RelayCommand(async obj =>
                {
                    DirectoryScanner.StopScan();
                    _cancelBtn.IsEnabled = false;
                    _cancelBtn.Background = Brushes.Red;
                }));
        }
    }

    public void NotifyPropertyChanged(string propName)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
    }
}