using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademicoPUC.Classes
{
    internal class Aluno : IFileContent
    {
        public int Id { get; private set; }
        public string Nome  { get; private set; } = string.Empty;
        public string Senha { get; private set; } = string.Empty;

        public Aluno(int id, string nome, string senha)
        {
            Id = id;
            Nome = nome;
            Senha = senha;
        }

        public Aluno() { }

        public static Aluno GetByData(string data)
        {
            Aluno novo_obj = new Aluno();

            string[] attrs = data.Split(';');

            foreach (string attr in attrs)
            {
                string[] line = attr.Split('=');

                PropertyInfo? propriedade = novo_obj.GetType().GetProperty(line[0]);

                if (propriedade == null) { continue; }

                if (propriedade.PropertyType == typeof(string))
                {
                    propriedade.SetValue(novo_obj, line[1]);
                }
                else if (propriedade.PropertyType == typeof(int))
                {
                    propriedade.SetValue(novo_obj, int.Parse(line[1]));
                }

            }

            return novo_obj;
        }

        void IFileContent.FileToObject(string file_line)
        {
            
        }

        string IFileContent.ObjectToFile()
        {
            return $"Id={this.Id};" +
                   $"Nome={this.Nome};" +
                   $"Senha={this.Senha}";
        }
    }

    internal class NoAluno
    {
        public Aluno Dado { get; set; }
        public NoAluno Esquerda { get; set; }
        public NoAluno Direita { get; set; }

        public NoAluno(Aluno aluno)
        {
            Dado = aluno;
            Esquerda = null;
            Direita = null;
        }
    }

    internal class ArvoreAluno
    {
        private NoAluno raiz;

        public ArvoreAluno()
        {
            raiz = null;
        }

        public void Inserir(Aluno aluno)
        {
            raiz = InserirRecursivo(raiz, aluno);
        }

        private NoAluno InserirRecursivo(NoAluno no, Aluno aluno)
        {
            if (no == null)
            {
                return new NoAluno(aluno);
            }

            if (aluno.Id < no.Dado.Id)
            {
                no.Esquerda = InserirRecursivo(no.Esquerda, aluno);
            }
            else if (aluno.Id > no.Dado.Id)
            {
                no.Direita = InserirRecursivo(no.Direita, aluno);
            }

            return no;
        }

        public void EmOrdem()
        {
            EmOrdemRecursivo(raiz);
        }

        private void EmOrdemRecursivo(NoAluno no)
        {
            if (no != null)
            {
                EmOrdemRecursivo(no.Esquerda);
                Console.WriteLine($"ID: {no.Dado.Id}, Nome: {no.Dado.Nome}");
                EmOrdemRecursivo(no.Direita);
            }
        }
    }
}
