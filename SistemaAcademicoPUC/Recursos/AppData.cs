using SistemaAcademicoPUC.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademicoPUC.Recursos
{
    internal class AppData
    {
        public ArvoreAluno Alunos;
        public AppData() {
            this.Initialize();
            this.FetchAllData();
        }

        private void Initialize()
        {
            Alunos = new ArvoreAluno();
        }

        private void FetchAllData()
        {

            this.FetchAllAlunos();

        }

        private void FetchAllAlunos()
        {
            FileManager FM = new FileManager(FileManager.Aluno);

            string[] dadosAlunos = FM.ReadAllLinesFrom(FileManager.Aluno);

            foreach (var dado in dadosAlunos)
            {
                Aluno obj_aluno = Aluno.GetByData(dado);
                this.Alunos.Inserir(obj_aluno);
            }

            this.Alunos.EmOrdem();
        }
    }
}
