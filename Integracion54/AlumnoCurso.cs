using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integracion54
{
    public class AlumnoCurso
    {
        protected int _contadorAlumnoCurso;
        private int _codigoCursoPivot;
        private int _codigoAlumnoPivot;
        private string _alumnoNombrePivot;
        private string _apellidoNombrePivot;
        private string _cursoNombrePivot;

        public int CodigoCursoPivot
        {
            get { return this._codigoCursoPivot; }
            set { this._codigoCursoPivot = value; }
        }

        public int CodigoAlumnoPivot
        {
            get { return this._codigoAlumnoPivot; }
            set { this._codigoAlumnoPivot = value; }
        }

        public string AlumnoNombrePivot
        {
            get { return this._alumnoNombrePivot; }
            set { this._alumnoNombrePivot = value; }
        }
        public string ApellidoNombrePivot
        {
            get { return this._apellidoNombrePivot; }
            set { this._apellidoNombrePivot = value; }
        }

        public string CursoNombrePivot
        {
            get { return this._cursoNombrePivot; }
            set { this._cursoNombrePivot = value; }
        }

        public static int contadorAlumnoCursoOrden = 1;

        public AlumnoCurso(int codigoCurso, int codigoAlumno, string nombreAlumno, string apellidoAlumno, string nombreCurso)
        {
            this._codigoCursoPivot = codigoCurso;
            this._codigoAlumnoPivot = codigoAlumno;
            this._alumnoNombrePivot = nombreAlumno;
            this._apellidoNombrePivot = apellidoAlumno;
            this._cursoNombrePivot = nombreCurso;

            this._contadorAlumnoCurso = contadorAlumnoCursoOrden;
            contadorAlumnoCursoOrden++;
        }

       

    }

    
}
