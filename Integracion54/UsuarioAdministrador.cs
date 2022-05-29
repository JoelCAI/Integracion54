using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Integracion54
{
	public class UsuarioAdministrador : Usuario
	{
		protected List<Alumno> _alumno;
		protected List<Curso> _curso;
		protected List<AlumnoCurso> _alumnoCurso;

		public List<Alumno> Alumno
		{
			get { return this._alumno; }
			set { this._alumno = value; }
		}

		public List<Curso> Curso
		{
			get { return this._curso; }
			set { this._curso = value; }
		}
		public List<AlumnoCurso> AlumnoCurso
		{
			get { return this._alumnoCurso; }
			set { this._alumnoCurso = value; }
		}

		public UsuarioAdministrador(string nombre, List<Alumno> alumno, List<Curso> curso, List<AlumnoCurso> alumnoCurso) : base(nombre)
		{
			this._alumno = alumno;
			this._curso = curso;
			this._alumnoCurso = alumnoCurso;
		}


		public void MenuAdministrador(List<Alumno> alumno, List<Curso> curso, List<AlumnoCurso> alumnoCurso)
		{

			Alumno = alumno;
			Curso = curso;
			AlumnoCurso = alumnoCurso;

			int opcion;
			do
			{

				Console.Clear();
				Console.WriteLine(" Bienvenido Usuario: *" + Nombre + "* ");
				opcion = Validador.PedirIntMenu("\n Menú de la Facultad: " +
									   "\n [1] Dar de alta un alumno (Número de registro y nombre completo)." +
									   "\n [2] Dar de alta un curso (se ingresa el código del curso)" +
									   "\n [3] Asignar un alumno a un curso." +
									   "\n [4] Desasignar un alumno de un curso" +
									   "\n [5] Ver la lista de alumnos asignados a un curso." +
									   "\n [6] Ver los cursos a los que está asignado un alumno" +
									   "\n [7] Ver la cantidad de alumnos en cada curso" +
									   "\n [8] Ver la cantidad de cursos de cada Alumno" +
									   "\n [9] Salir del Sistema.", 1, 9);

				switch (opcion)
				{
					case 1:
						DarAltaPersona();
						break;
					case 2:
						DarAltaCurso();
						break;
					case 3:
						AsignarCursoAlumno();
						break;
					case 4:
						DarBajaCursoAlumno();
						break;
					case 5:
						VerAlumnoCurso();
						break;
					case 6:
						VerCursoAsignadoAlumno();
						break;
					case 7:
						VerCantidadAlumnosCurso();
						break;
					case 8:
						VerCantidadCursosPorAlumno();
						break;
				}
			} while (opcion != 5);
		}

		public int BuscarPersonaDni(int dni)
		{
			for (int i = 0; i < this._alumno.Count; i++)
			{
				if (this._alumno[i].Registro == dni)
				{
					return i;
				}
			}
			/* si no encuentro el producto retorno una posición invalida */
			return -1;
		}

		public int BuscarCurso(int codigoCurso)
		{
			for (int i = 0; i < this._curso.Count; i++)
			{
				if (this._curso[i].CodigoCurso == codigoCurso)
				{
					return i;
				}
			}
			/* si no encuentro el producto retorno una posición invalida */
			return -1;
		}

		public int BuscarAlumnoCurso(int codigoCurso)
		{
			for (int i = 0; i < this._alumnoCurso.Count; i++)
			{
				if (this._alumnoCurso[i].CodigoAlumnoPivot == codigoCurso)
				{
					return i;
				}
			}
			/* si no encuentro el producto retorno una posición invalida */
			return -1;
		}

		public int BuscarAlumnoCursoCantidad(int codigoCurso)
		{
			for (int i = 0; i < this._alumnoCurso.Count; i++)
			{
				if (this._alumnoCurso[i].CodigoCursoPivot == codigoCurso)
				{
					return i;
				}
			}
			/* si no encuentro el producto retorno una posición invalida */
			return -1;
		}


		public void AddPersona(Alumno alumno)
		{
			this._alumno.Add(alumno);
		}

		public void AddCurso(Curso curso)
		{
			this._curso.Add(curso);
		}

		public void AddAlumnoCurso(AlumnoCurso alumnoCurso)
		{
			this._alumnoCurso.Add(alumnoCurso);
		}

		public void RemoverAlumnoCurso(int pos)
		{
			this._alumnoCurso.RemoveAt(pos);
		}

		public void VerPersona()
		{
			Console.Clear();
			Console.WriteLine("\n Alumnos Registrados");
			Console.WriteLine(" #\tRegistro.\t\tNombre.\t\tApellido.");
			for (int i = 0; i < Alumno.Count; i++)
			{
				Console.Write(" " + (i + 1));
				Console.Write("\t");
				Console.Write(Alumno[i].Registro);
				Console.Write("\t\t");
				Console.Write(Alumno[i].Nombre);
				Console.Write("\t\t");
				Console.Write(Alumno[i].Apellido);
				Console.Write("\t\t");

				Console.Write("\n");
			}

		}

		public void VerCurso()
		{
			Console.Clear();
			Console.WriteLine("\n Lista de Cursos");
			Console.WriteLine(" #.\t\tCódigo de Curso.\t\tNombre del Curso.");
			for (int i = 0; i < Curso.Count; i++)
			{
				Console.Write(" " + (i + 1));
				Console.Write("\t\t");
				Console.Write(Curso[i].CodigoCurso);
				Console.Write("\t\t\t");
				Console.Write(Curso[i].NombreCurso);
				Console.Write("\n");
			}

		}

		public void VerAlumnoCurso()
		{
			Console.Clear();
			Console.WriteLine("\n Lista de Alumnos en Cursos");
			Console.WriteLine(" #.\t\tCódigo de Alumno.\t\tCódigo del Curso.");
			for (int i = 0; i < AlumnoCurso.Count; i++)
			{
				Console.Write(" " + (i + 1));
				Console.Write("\t\t");
				Console.Write(AlumnoCurso[i].CodigoCursoPivot);
				Console.Write("\t");
				Console.Write(AlumnoCurso[i].CodigoAlumnoPivot);
				Console.Write("\t");
				Console.Write(AlumnoCurso[i].AlumnoNombrePivot);
				Console.Write("\t");
				Console.Write(AlumnoCurso[i].ApellidoNombrePivot);
				Console.Write("\t");
				Console.Write(AlumnoCurso[i].CursoNombrePivot);

				Console.Write("\n");
			}

		}



		public void Prueba(int registroAlumno, int registroCurso)
		{

			Console.Write("\n Nombre de Alumno Inscrito : " + Alumno[BuscarPersonaDni(registroAlumno)].Nombre +
						  " " + Alumno[BuscarPersonaDni(registroAlumno)].Apellido);
			Console.WriteLine("\n Nombre de Curso Inscrito: " + Curso[BuscarCurso(registroCurso)].NombreCurso);

		}


		protected override void DarAltaPersona()
		{
			int registro;

			string nombre;
			string apellido;
			
			string opcion;

			Console.Clear();
			registro = Validador.PedirIntMenu("\n Ingrese el Registro del Alumno a agregar. El valor debe ser entre ", 0, 999999);
			if (BuscarPersonaDni(registro) == -1)
			{
				VerPersona();
				Console.WriteLine("\n ¡En hora buena! Puede utilizar este Registro para crear un Alumno en la Aplicación");
				nombre = ValidarStringNoVacioNombre("\n Ingrese el nombre del Alumno");
				apellido = ValidarStringNoVacioNombre("\n Ingrese el apellido del Alumno");

				opcion = ValidarSioNoPersonaNoCreada("\n Está seguro que desea crear esta Persona? ", registro, nombre, apellido);

				if (opcion == "SI")
				{
					Alumno p = new Alumno(registro, nombre, apellido);
					AddPersona(p);
					
					VerPersona();
					
					Console.WriteLine("\n Alumno con Registro *" + registro + " y nombre *" + nombre + "* agregado exitósamente");
					Validador.VolverMenu();
				}
				else
				{
					VerPersona();
					Console.WriteLine("\n Como puede verificar no se creo ningún Alumno");
					Validador.VolverMenu();

				}

			}
			else
			{
				VerPersona();
				Console.WriteLine("\n Usted digitó el numero de Registro *" + registro + "*");
				Console.WriteLine("\n Ya existe un Alumno con ese Registro");
				Console.WriteLine("\n Será direccionado nuevamente al Menú para que lo realice con un Registro que no exista aún");
				Validador.VolverMenu();

			}

		}

		protected override void DarAltaCurso()
		{
			int registro;

			string nombreCurso;
			

			string opcion;

			Console.Clear();
			registro = Validador.PedirIntMenu("\n Ingrese el código del Curso a Registrar. El valor debe ser entre ", 0, 9999);
			if (BuscarCurso(registro) == -1)
			{
				VerCurso();
				Console.WriteLine("\n ¡En hora buena! Puede utilizar este Código para crear un Curso en la Aplicación");
				nombreCurso = ValidarStringNoVacioCurso("\n Ingrese el nombre del Curso");
				

				opcion = ValidarSioNoCursoNoCreado("\n Está seguro que desea crear este Curso? ", registro, nombreCurso);

				if (opcion == "SI")
				{
					Curso p = new Curso(registro, nombreCurso);
					AddCurso(p);
					
					VerCurso();
					
					Console.WriteLine("\n Curso con Código *" + registro + " y nombre *" + nombreCurso + "* agregado exitósamente");
					Validador.VolverMenu();
				}
				else
				{
					VerCurso();
					Console.WriteLine("\n Como puede verificar no se creo ningún Curso");
					Validador.VolverMenu();

				}

			}
			else
			{
				VerPersona();
				Console.WriteLine("\n Usted digitó el numero de Registro *" + registro + "*");
				Console.WriteLine("\n Ya existe un Alumno con ese Registro");
				Console.WriteLine("\n Será direccionado nuevamente al Menú para que lo realice con un Registro que no exista aún");
				Validador.VolverMenu();

			}

		}
		protected override void AsignarCursoAlumno()
		{
			int registroAlumno;
			int registroCurso;

			string nombreAlumnoCurso;
			string apellidoAlumnoCurso;
			string nombreCursoAlumnoCurso;

			string opcion;

			Console.Clear();
			VerPersona();
			registroAlumno = Validador.PedirIntMenu("\n Ingrese el código del Alumno a Registrar. El valor debe ser entre ", 0, 999999);
			if (BuscarPersonaDni(registroAlumno) != -1)
			{
				
				VerCurso();
				registroCurso = Validador.PedirIntMenu("\n Ingrese el código del Curso para Registrar al Alumno. El valor debe ser entre ", 0, 9999);

				if (BuscarCurso(registroCurso) != -1)
				{
					opcion = ValidarSioNoAsigNoCreado("\n Está seguro que desea crear este Alumno?", registroAlumno, registroCurso);

					if (opcion == "SI")
					{
						nombreAlumnoCurso = Alumno[BuscarPersonaDni(registroAlumno)].Nombre;
						apellidoAlumnoCurso = Alumno[BuscarPersonaDni(registroAlumno)].Apellido;
						nombreCursoAlumnoCurso = Curso[BuscarCurso(registroCurso)].NombreCurso;

						AlumnoCurso pa = new AlumnoCurso(registroCurso, registroAlumno,nombreAlumnoCurso,
							                             apellidoAlumnoCurso,nombreCursoAlumnoCurso);

						AddAlumnoCurso(pa);

						VerAlumnoCurso();
						Prueba(registroAlumno,registroCurso);
						Console.WriteLine("\n Curso con Código *" + registroAlumno + " y Registro de Alumno *" + registroCurso + "* agregado exitósamente");
						Validador.VolverMenu();
					}
					else
					{
						VerPersona();
						Console.WriteLine("\n Como puede verificar no se creo ningún Curso");
						Validador.VolverMenu();

					}
				}
				else
				{
					VerCurso();
					Console.WriteLine("\n Usted digitó el código de Curso *" + registroCurso + "*");
					Console.WriteLine("\n No existe un Curso con ese código");
					Console.WriteLine("\n Será direccionado nuevamente al Menú para que lo realice con un Registro existente");
					Validador.VolverMenu();

				}




			}
			else
			{
				VerPersona();
				Console.WriteLine("\n Usted digitó el numero de Registro *" + registroAlumno + "*");
				Console.WriteLine("\n No existe un Alumno con ese Registro");
				Console.WriteLine("\n Será direccionado nuevamente al Menú para que lo realice con un Registro existente");
				Validador.VolverMenu();

			}

		}


		protected override void DarBajaCursoAlumno()
		{
			int registroAlumno;
			string confirmacion;

			VerPersona();
			registroAlumno = Validador.PedirIntMenu("\n Ingrese el Registro del Alumno. El valor debe ser entre ", 0, 99999999);


			if (BuscarAlumnoCurso(registroAlumno) != -1)
			{

				VerAlumnoCurso();

				confirmacion = ValidarSioNoPersonaCreada("\n\n Está seguro que desea designar el curso al Alumno?",registroAlumno);

				if (confirmacion == "SI")
				{
					RemoverAlumnoCurso(BuscarAlumnoCurso(registroAlumno));
										
					VerAlumnoCurso();
					
					Console.WriteLine("\n Curso del Alumno Desasignado");
					Validador.VolverMenu();
				}
				else
				{
					VerAlumnoCurso();
					Console.WriteLine("\n Como puede apreciar la Persona no ha sido eliminada");
					Validador.VolverMenu();
				}

			}
			else
			{
				Console.Clear();
				VerPersona();
				Console.WriteLine("\n No existe una Persona con este Dni *" +registroAlumno + "*. " +
								  "\n\n Vuelva a intentarlo ingresando el valor de uno de los DNI que ve en la lista " +
								  "la siguiente vez");
				Validador.VolverMenu();
			}

		}

		public void VerCursoAsignadoAlumno()
        {
			int registroAlumno;
			

			VerPersona();
			registroAlumno = Validador.PedirIntMenu("\n Ingrese el Registro del Alumno. El valor debe ser entre ", 0, 99999999);

			Console.Clear();
			if (BuscarAlumnoCurso(registroAlumno) != -1)
			{
				Console.WriteLine("\n Alumno con registro *" + registroAlumno + "*. Inscrito en:");
				for (int i = 0; i < this._alumnoCurso.Count; i++)
				{
					if (this._alumnoCurso[i].CodigoAlumnoPivot == registroAlumno)
					{
						Console.WriteLine("\n Curso: " + AlumnoCurso[i].CursoNombrePivot);
					}
				}
						
				Validador.VolverMenu();

			}
			else
			{
				Console.Clear();
				VerPersona();
				Console.WriteLine("\n No existe un Alumno con este Registro *" + registroAlumno + "*. " +
								  "\n\n Vuelva a intentarlo ingresando el valor de un registro que vea en la lista");
				Validador.VolverMenu();
			}

		}

		public void VerCantidadAlumnosCurso()
		{
			int registroCurso;
			int contador = 0;

			VerCurso();
			registroCurso = Validador.PedirIntMenu("\n Ingrese el Registro del Curso. El valor debe ser entre ", 0, 99999999);

			Console.Clear();
			if (BuscarAlumnoCursoCantidad(registroCurso) != -1)
			{
				Console.WriteLine("\n Curso con Código *" + registroCurso + "*. tiene:");
				for (int i = 0; i < this._alumnoCurso.Count; i++)
				{

					if (this._alumnoCurso[i].CodigoCursoPivot == registroCurso)
					{
						
						contador++;
					}

				}
				Console.WriteLine("\n " + contador +" Alumnos. " );

				Validador.VolverMenu();

			}
			else
			{
				Console.Clear();
				VerCurso();
				Console.WriteLine("\n No existe un Curso con este Registro *" + registroCurso + "*. " +
								  "\n\n Vuelva a intentarlo ingresando el valor de un registro que vea en la lista");
				Validador.VolverMenu();
			}

		}

		public void VerCantidadCursosPorAlumno()
		{
			int registroAlumno;
			int contador = 0;

			VerCurso();
			registroAlumno = Validador.PedirIntMenu("\n Ingrese el Registro del Alumno. El valor debe ser entre ", 0, 99999999);

			Console.Clear();
			if (BuscarAlumnoCurso(registroAlumno) != -1)
			{
				Console.WriteLine("\n Alumno con Registro *" + registroAlumno + "*. tiene:");
				for (int i = 0; i < this._alumnoCurso.Count; i++)
				{

					if (this._alumnoCurso[i].CodigoAlumnoPivot == registroAlumno)
					{

						contador++;
					}

				}
				Console.WriteLine("\n " + contador + " cursos. ");

				Validador.VolverMenu();

			}
			else
			{
				Console.Clear();
				VerCurso();
				Console.WriteLine("\n No existe un Alumno con este Registro *" + registroAlumno + "*. " +
								  "\n\n Vuelva a intentarlo ingresando el valor de un registro que vea en la lista");
				Validador.VolverMenu();
			}

		}


		/* Validadores de Clase */
		protected string ValidarSioNoPersonaCreada(string mensaje, int dni)
		{

			string opcion;
			bool valido = false;
			string mensajeValidador = "\n Si esta seguro de ello escriba *" + "si" + "* sin los asteriscos" +
									  "\n De lo contrario escriba " + "*" + "no" + "* sin los asteriscos";
			string mensajeError = "\n Por favor ingrese el valor solicitado y que no sea vacio. ";

			do
			{
				VerPersona();
				if (BuscarPersonaDni(dni) != -1)
				{
					Console.WriteLine("\n Dni de la Persona : " + Alumno[BuscarPersonaDni(dni)].Registro +
									  "\n Nombre de la Persona : " + Alumno[BuscarPersonaDni(dni)].Nombre +
									  "\n Apellido de la Persona : " + Alumno[BuscarPersonaDni(dni)].Apellido);
				}
				Console.WriteLine(mensaje);
				Console.WriteLine(mensajeError);
				Console.WriteLine(mensajeValidador);
				opcion = Console.ReadLine().ToUpper();
				string opcionC = "SI";
				string opcionD = "NO";

				if (opcion == "" || (opcion != opcionC) & (opcion != opcionD))
				{
					Console.WriteLine("\n");

				}
				else
				{
					valido = true;
				}

			} while (!valido);

			return opcion;
		}

		protected string ValidarSioNoPersonaNoCreada(string mensaje, int registro, string nombre, string apellido)
		{

			string opcion;
			bool valido = false;
			string mensajeValidador = "\n Si esta seguro de ello escriba *" + "si" + "* sin los asteriscos" +
									  "\n De lo contrario escriba " + "*" + "no" + "* sin los asteriscos";
			string mensajeError = "\n Por favor ingrese el valor solicitado y que no sea vacio. ";

			do
			{
				VerPersona();

				Console.WriteLine("\n Registro del Alumno a Crear: " + registro +
								  "\n Nombre de la Persona a Crear: " + nombre +
								  "\n Apellido de la Persona a Crear: " + apellido);

				Console.WriteLine(mensaje);
				Console.WriteLine(mensajeError);
				Console.WriteLine(mensajeValidador);
				opcion = Console.ReadLine().ToUpper();
				string opcionC = "SI";
				string opcionD = "NO";

				if (opcion == "" || (opcion != opcionC) & (opcion != opcionD))
				{
					continue;

				}
				else
				{
					valido = true;
				}

			} while (!valido);

			return opcion;
		}

		protected string ValidarSioNoAsigNoCreado(string mensaje, int registro, int nombreCurso)
		{

			string opcion;
			bool valido = false;
			string mensajeValidador = "\n Si esta seguro de ello escriba *" + "si" + "* sin los asteriscos" +
									  "\n De lo contrario escriba " + "*" + "no" + "* sin los asteriscos";
			string mensajeError = "\n Por favor ingrese el valor solicitado y que no sea vacio. ";

			do
			{
				VerPersona();

				Console.WriteLine("\n Código del Curso a Crear: " + registro +
								  "\n Nombre del Curso a Crear: " + nombreCurso);

				Console.WriteLine(mensaje);
				Console.WriteLine(mensajeError);
				Console.WriteLine(mensajeValidador);
				opcion = Console.ReadLine().ToUpper();
				string opcionC = "SI";
				string opcionD = "NO";

				if (opcion == "" || (opcion != opcionC) & (opcion != opcionD))
				{
					continue;

				}
				else
				{
					valido = true;
				}

			} while (!valido);

			return opcion;
		}

		protected string ValidarSioNoCursoNoCreado(string mensaje, int registro, string nombreCurso)
		{

			string opcion;
			bool valido = false;
			string mensajeValidador = "\n Si esta seguro de ello escriba *" + "si" + "* sin los asteriscos" +
									  "\n De lo contrario escriba " + "*" + "no" + "* sin los asteriscos";
			string mensajeError = "\n Por favor ingrese el valor solicitado y que no sea vacio. ";

			do
			{
				VerPersona();

				Console.WriteLine("\n Código del Curso a Crear: " + registro +
								  "\n Nombre del Curso a Crear: " + nombreCurso);

				Console.WriteLine(mensaje);
				Console.WriteLine(mensajeError);
				Console.WriteLine(mensajeValidador);
				opcion = Console.ReadLine().ToUpper();
				string opcionC = "SI";
				string opcionD = "NO";

				if (opcion == "" || (opcion != opcionC) & (opcion != opcionD))
				{
					continue;

				}
				else
				{
					valido = true;
				}

			} while (!valido);

			return opcion;
		}


		protected string ValidarStringNoVacioNombre(string mensaje)
		{

			string opcion;
			bool valido = false;
			string mensajeValidador = "\n Por favor ingrese el valor solicitado y que no sea vacio.";


			do
			{
				VerPersona();
				Console.WriteLine(mensaje);
				Console.WriteLine(mensajeValidador);

				opcion = Console.ReadLine().ToUpper();

				if (opcion == "")
				{

					Console.Clear();
					Console.WriteLine("\n");
					Console.WriteLine(mensajeValidador);

				}
				else
				{
					valido = true;
				}

			} while (!valido);

			return opcion;
		}

		protected string ValidarStringNoVacioCurso(string mensaje)
		{

			string opcion;
			bool valido = false;
			string mensajeValidador = "\n Por favor ingrese el valor solicitado y que no sea vacio.";


			do
			{
				VerCurso();
				Console.WriteLine(mensaje);
				Console.WriteLine(mensajeValidador);

				opcion = Console.ReadLine().ToUpper();

				if (opcion == "")
				{

					Console.Clear();
					Console.WriteLine("\n");
					Console.WriteLine(mensajeValidador);

				}
				else
				{
					valido = true;
				}

			} while (!valido);

			return opcion;
		}

		
		

		





	}
}
