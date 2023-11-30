using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademicoPUC.Classes
{
    internal interface IFileContent
    {
        string ObjectToFile();
        void FileToObject(string file_line);

    }
}
