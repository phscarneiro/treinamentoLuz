using CRUD.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CRUD.ViewModel
{   
    
    public class MainWindowVM : Notifica
    {
        public ObservableCollection<Curso> Cursos { get; private set; }
        public ICommand NovoComando { get; private set; }
        public ICommand EditarComando { get; private set; }
        public ICommand DeletarComando { get; private set; }

        private Curso _cursoSelecionado;

        public MainWindowVM()
        {
            Cursos = new ObservableCollection<Model.Curso>();
            Cursos.Add(new Model.Curso()
            {
                Id = 1,
                Nome = "Pedro",
                Autor = "Carneiro",
                DataInicio = new DateTime(1900, 1, 1),
                Nivel = Model.Nivel.Intermediario,
                Area = Model.Area.TI,
                Local = "linkedin",
                Duracao = "120h"
            });

            CursoSelecionado = Cursos.FirstOrDefault();

            NovoComando = new RelayCommand(Novo, PodeNovo);
            EditarComando = new RelayCommand(Editar, PodeEditar);
            DeletarComando = new RelayCommand(Deletar, PodeDeletar);

        }

        // funcoes parametro do relaycomand
        private bool PodeDeletar(object parametro)
        {
            MainWindowVM vm = parametro as MainWindowVM;
            return vm != null && CursoSelecionado != null;
        }

        private void Deletar(object parametro)
        {
       
            Cursos.Remove(CursoSelecionado);
            CursoSelecionado = Cursos.FirstOrDefault();
        }

        private bool PodeEditar(object parametro)
        {
            MainWindowVM viewModel = parametro as MainWindowVM;
            return viewModel != null && viewModel.CursoSelecionado != null;
        }

        private void Editar(object parametro)
        {
        
            Curso cloneCurso = (Curso)CursoSelecionado.Clone();
            Window fw = new CursoJanela();
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

         private bool PodeNovo(object parametro)
        {
            return parametro is MainWindowVM;
        }
        //()=>{};
        // por isso no relaycommand atraves de arrow function  e private deixa aberto
        // sempre declarar explicitamente o tipo da variavel
        // diferença composiçao e henrança
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
        //fim funcoes parametro

        public Curso CursoSelecionado
        {
            get { return _cursoSelecionado; }
            set { SetField(ref _cursoSelecionado, value);}
        }
     
    }
}
