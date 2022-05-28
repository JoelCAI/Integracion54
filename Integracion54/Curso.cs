using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integracion54
{
    public class Curso
    {
        private int _codigoCurso;
        private string _nombreCurso;
        private List<AlumnoCurso> _alumnoCursoItem;
      
        public int CodigoCurso
        {
            get { return this._codigoCurso; }
            set { this._codigoCurso = value; }
        }

        public string NombreCurso
        {
            get { return this._nombreCurso; }
            set { this._nombreCurso = value; }
        }

        public List<AlumnoCurso> AlumnoCursoItem
        {
            get { return this._alumnoCursoItem; }
         
        }

        public Curso()
        {
            this._alumnoCursoItem = new List<AlumnoCurso>();
        }

        public void AddAlumnoCurso(AlumnoCurso alumnoCursoItem)
        {
            this._alumnoCursoItem.Add(alumnoCursoItem); 
            
        }

        public void RemoveAlumnoCurso(AlumnoCurso alumnoCursoItem)
        {
            this._alumnoCursoItem.Remove(alumnoCursoItem);

        }


        public Curso(int codigoCurso, string nombreCurso)
        {
            this._codigoCurso = codigoCurso;
            this._nombreCurso = nombreCurso;
        }
    }
}
