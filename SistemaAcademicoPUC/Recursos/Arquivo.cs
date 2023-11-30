using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademicoPUC.Recursos
{
    internal class FileManager
    {
        public const string Aluno = "Aluno";

        private string _file_path = System.String.Empty;
        private string _last_obj = System.String.Empty;
        public readonly string root = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
        public FileManager(string object_name = "") {

            if (string.IsNullOrEmpty(object_name)) { return; }

            this.SetFilePath(object_name);
        }

        private void SetFilePath(string object_name)
        {
            switch(object_name)
            {
                case FileManager.Aluno:
                    
                    _file_path = root + "/Interno/Alunos.txt";
                    break;

                default:
                    _file_path = System.String.Empty;
                    _last_obj = "invalid";
                    break;
            }

            this._last_obj = (this._last_obj == "invalid") ? System.String.Empty : object_name;

        }

        public void Save(string content, string object_type = "")
        {
            if (object_type != "" && object_type != _last_obj)
            {
                SetFilePath(object_type);   
            }

            if (_file_path == System.String.Empty) { return; }

            using (StreamWriter file_writer = new StreamWriter(_file_path))
            {
                file_writer.WriteLine(content);
            }
        }

        public string[] ReadAllLinesFrom(string object_type)
        {
            if (object_type != _last_obj)
            {
                SetFilePath(object_type);
            }

            return File.ReadAllLines(this._file_path);
        }
    }
}
