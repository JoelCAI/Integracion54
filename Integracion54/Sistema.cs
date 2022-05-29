using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integracion54
{
	public class Sistema
	{
		private List<UsuarioAdministrador> _usuarioAdministrador;
		private List<Alumno> _alumno;
		private List<Curso> _curso;
		private List<AlumnoCurso> _alumnoCurso;
		public Sistema()
		{
			this._usuarioAdministrador = new List<UsuarioAdministrador>();
			this._alumno = new List<Alumno>();
			this._curso = new List<Curso>();
			this._alumnoCurso = new List<AlumnoCurso>();
		}

		public int BuscarUsuarioAdministradorNombre(string nombre)
		{
			for (int i = 0; i < this._usuarioAdministrador.Count; i++)
			{
				if (this._usuarioAdministrador[i].Nombre == nombre)
				{
					return i;
				}
			}
			return -1;
		}


		public void MenuPrincipal()
		{
			Console.Clear();
			int opcion;
			string nombre;
			int posUsuarioA;
			UsuarioAdministrador uA;


			do
			{
				Console.Clear();
				opcion = Validador.PedirIntMenu("\n Menú Principal" +
									   "\n [1] Ingresar a la Aplicación." +
									   "\n [2] Salir.", 1, 2);
				switch (opcion)
				{
					/* Aqui vamos a validar que el usuario exista */
					case 1:
						Console.Clear();

						nombre = Validador.ValidarStringNoVacioUsuarioClave("\n\n Ingrese su Nombre ");
						uA = new UsuarioAdministrador(nombre, this._alumno, this._curso, this._alumnoCurso);
						_usuarioAdministrador.Add(uA);
						posUsuarioA = BuscarUsuarioAdministradorNombre(nombre);

						/* Si esto se cumple puedo crear un Usuario */
						if (posUsuarioA != -1)
						{

							_usuarioAdministrador[posUsuarioA].MenuAdministrador(this._alumno, this._curso, this._alumnoCurso);
							this._alumno = _usuarioAdministrador[posUsuarioA].Alumno;
							this._curso = _usuarioAdministrador[posUsuarioA].Curso;
							this._alumnoCurso = _usuarioAdministrador[posUsuarioA].AlumnoCurso;
							Validador.VolverMenu();
						}
						break;
					case 2:
						break;
				}

			} while (opcion != 2);

		}


		public void Iniciar()
		{
			MenuPrincipal();
		}

	}
}
