using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scaner_UI.Services
{
    public interface IDialogService
    {
        public string DirectoryPath { get; set; }
        public bool OpenDirectoryDialog();
    }
}
