using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integracion54
{
	public class Alumno
	{
		protected int _registroAlumno;
		private int _registro;
		private string _nombre;
		private string _apellido;
		

		/* Un descriptor de acceso que no tiene set solo puede escribirse una vez por el contructor 
		   Ejemplo
		   public Persona (int dni)
			{
				Dni = dni
			}
		 */
		public int Registro
		{
			get { return this._registro; }
			set { this._registro = value; }
		}
		public string Nombre
		{
			get { return this._nombre; }
			set { this._nombre = value; }
		}

		public string Apellido
		{
			get { return this._apellido; }
			set { this._apellido = value; }
		}
		

		public static int registroAlumnoOrden = 1;

		
		public Alumno(int registro, string nombre, string apellido)
		{
			this._registro = registro;
			this._nombre = nombre;
			this._apellido = apellido;
			
			this._registroAlumno = registroAlumnoOrden;
			registroAlumnoOrden++;
		}
	}
}