using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integracion54
{
    public class AlumnoCurso
    {
        private int _codigoCursoPivot;
        private int _codigoAlumnoPivot;

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

        public AlumnoCurso(int codigoCurso, int codigoAlumno)
        {
            this._codigoCursoPivot = codigoCurso;
            this._codigoAlumnoPivot = codigoCurso;
        }

    }

    
}
