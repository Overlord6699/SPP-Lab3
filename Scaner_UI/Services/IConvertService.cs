using ScanerLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scaner_UI.Services
{
    public interface IConvertService
    {
        public MemoryObjectModel ConvertToModel(MemoryObject fileData);
    }
}
