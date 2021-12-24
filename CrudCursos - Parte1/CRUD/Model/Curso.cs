using CRUD.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Model
{
   
   
    public class Curso : Notifica, ICloneable
    {
        private int _id;
        private string _nome;
        private string _autor;
        private DateTime _dataInicio;
        private Nivel _nivel;
        private Area _area;
        private string _local;
        private string _duracao;

        public Curso()
        {

        }

        public int Id
        {
            get { return _id; }
            set { SetField(ref _id, value); }
        }
        
        public string Nome
        {
            get { return _nome; }
            set { SetField(ref _nome, value); }
        }

    
        public string Autor
        {
            get { return _autor; }
            set { SetField(ref _autor, value); }
        }

        public DateTime DataInicio
        {
            get { return _dataInicio; }
            set { SetField(ref _dataInicio, value); }
        }


        public Nivel Nivel
        {
            get { return _nivel; }
            set { SetField(ref _nivel, value); }
        }


        public Area Area
        {
            get { return _area; }
            set { SetField(ref _area, value); }
        }

        public string Local
        {
            get { return _local; }
            set { SetField(ref _local, value); }
        }

     
        public string Duracao
        {
            get { return _duracao; }
            set { SetField(ref _duracao, value); }
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
