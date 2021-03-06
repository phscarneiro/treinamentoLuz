using CRUD.Conexoes;
using CRUD.Model;
using Npgsql;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace CRUD.ViewModel
{

    public class CursoPaginaVM : Notifica
    {
        public ObservableCollection<Curso> Cursos { get; private set; }
        public ICommand NovoComando { get; private set; }
        public ICommand EditarComando { get; private set; }
        public ICommand DeletarComando { get; private set; }

        private Curso _cursoSelecionado;

        public CursoPaginaVM()
        {

            postgreSql.testeconexao();
            Cursos = new ObservableCollection<Curso>();
            CursoSelecionado = Cursos.FirstOrDefault();
            NovoComando = new RelayCommand(Novo, acessoNovo);
            EditarComando = new RelayCommand(Editar, Acesso);
            DeletarComando = new RelayCommand(Deletar, Acesso);

            Cursos.Add(new Curso()
            {
                Id = 0,
                Nome = "Pedro",
                Autor = "Carneiro",
                DataInicio = new DateTime(1900, 1, 1),
                Nivel = Nivel.Intermediario,
                Area = Area.TI,
                Local = "linkedin",
                Duracao = "120"
            });
        }

        private bool Acesso(object parametro)
        {
            return  CursoSelecionado != null;
        }
        private void Deletar(object parametro)
        {
            Cursos.Remove(CursoSelecionado);
            CursoSelecionado = Cursos.FirstOrDefault();
        }

        private void Editar(object parametro)
        {
        
            Curso cloneCurso = (Curso)CursoSelecionado.Clone();
            CursoJanela fw = new CursoJanela();
            fw.DataContext = cloneCurso;
            fw.ShowDialog();

            if (fw.DialogResult.HasValue && fw.DialogResult.Value)
            {
                CursoSelecionado.Nome = cloneCurso.Nome;
                CursoSelecionado.Autor = cloneCurso.Autor;
                CursoSelecionado.DataInicio = cloneCurso.DataInicio;
                CursoSelecionado.Nivel = cloneCurso.Nivel;
                CursoSelecionado.Area = cloneCurso.Area;
                CursoSelecionado.Duracao = cloneCurso.Duracao;
                CursoSelecionado.Local = cloneCurso.Local;
            }
        }

         private bool acessoNovo(object parametro)
        {
            return parametro is CursoPaginaVM;
        }

        private void Novo(object parametro)
        {

            Curso curso = new Curso();
            int maxId = 0;
            if (Cursos.Any())
            {
                maxId = Cursos.Max(f => f.Id);
            }
            curso.Id = maxId + 1;
            
            CursoJanela fw = new CursoJanela();
            fw.DataContext = curso;
            fw.ShowDialog();

            if (fw.DialogResult.HasValue && fw.DialogResult.Value)
            {
                Cursos.Add(curso);
                CursoSelecionado = curso;
            }
        }

        public Curso CursoSelecionado
        {
            get { return _cursoSelecionado; }
            set { SetField(ref _cursoSelecionado, value);}
        }

    }
}
