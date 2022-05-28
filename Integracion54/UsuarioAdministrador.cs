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

		public UsuarioAdministrador(string nombre, List<Alumno> alumno, List<Curso> curso) : base(nombre)
		{
			this._alumno = alumno;
			this._curso = curso;
		}


		public void MenuAdministrador(List<Alumno> alumno, List<Curso> curso)
		{

			Alumno = alumno;
			Curso = curso;

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
						LeerAgenda();
						break;
					case 5:
						break;
					case 6:
						break;
					case 7:
						break;
					case 8:
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

		Dictionary<int, Alumno> personaAgenda = new Dictionary<int, Alumno>();

		Dictionary<int, Curso> cursoDiccionario = new Dictionary<int, Curso>();

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
					personaAgenda.Add(registro, p);
					VerPersona();
					VerPersonaDiccionario();
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
					cursoDiccionario.Add(registro, p);
					VerCurso();
					VerCursoDiccionario();
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


			string opcion;

			Console.Clear();
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
						AlumnoCurso pa = new AlumnoCurso(registroAlumno, registroCurso);

						Curso pe = new Curso();
						pe.AddAlumnoCurso(pa);

						Console.WriteLine("\n Curso con Código *" + registroAlumno + " y nombre *" + registroCurso + "* agregado exitósamente");
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

		public void AddPersona(Alumno alumno)
		{
			this._alumno.Add(alumno);
		}

		public void AddCurso(Curso curso)
		{
			this._curso.Add(curso);
		}

		
		public void RemoverPersona(int pos)
		{
			this._alumno.RemoveAt(pos);
		}

		protected override void DarBajaPersona()
		{
			int dni;
			string confirmacion;

			VerPersona();
			dni = Validador.PedirIntMenu("\n Ingrese el DNI de la Persona a agregar. El valor debe ser entre ", 0, 99999999);


			if (BuscarPersonaDni(dni) != -1)
			{

				VerPersona();

				confirmacion = ValidarSioNoPersonaCreada("\n\n Está seguro que desea eliminar esta Persona?", dni);

				if (confirmacion == "SI")
				{
					personaAgenda.Remove(dni);
					RemoverPersona(BuscarPersonaDni(dni));
					VerPersona();

					VerPersonaDiccionario();
					Console.WriteLine("\n Persona eliminada exitósamente");
					Validador.VolverMenu();
				}
				else
				{
					VerPersona();
					Console.WriteLine("\n Como puede apreciar la Persona no ha sido eliminada");
					Validador.VolverMenu();
				}

			}
			else
			{
				Console.Clear();
				VerPersona();
				Console.WriteLine("\n No existe una Persona con este Dni *" + dni + "*. " +
								  "\n\n Vuelva a intentarlo ingresando el valor de uno de los DNI que ve en la lista " +
								  "la siguiente vez");
				Validador.VolverMenu();
			}

		}

		protected override void GrabarPersonaAgenda()
		{
			using (var archivoAgenda = new FileStream("archivoAgenda.txt", FileMode.Create))
			{
				using (var archivoEscrituraAgenda = new StreamWriter(archivoAgenda))
				{
					foreach (var persona in personaAgenda.Values)
					{

						var linea = "\n Registro del Alumnoa: " + persona.Registro +
									"\n Nombre de la Persona: " + persona.Nombre +
									"\n Apellido de la Persona: " + persona.Apellido;
						archivoEscrituraAgenda.WriteLine(linea);

					}

				}
			}
			VerPersona();
			Console.WriteLine("Se ha grabado los datos de las personas en la Agenda correctamente");
			Validador.VolverMenu();

		}

		protected override void LeerAgenda()
		{
			Console.Clear();
			Console.WriteLine("\n Personas en la agenda: ");
			using (var archivoAgenda = new FileStream("archivoAgenda.txt", FileMode.Open))
			{
				using (var archivoLecturaAgenda = new StreamReader(archivoAgenda))
				{
					foreach (var persona in personaAgenda.Values)
					{


						Console.WriteLine(archivoLecturaAgenda.ReadToEnd());


					}

				}
			}
			Validador.VolverMenu();

		}

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

		public void VerPersona()
		{
			Console.Clear();
			Console.WriteLine("\n Personas en Agenda");
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
			Console.WriteLine(" #\t.\t\tCódigo.\t\tCurso.");
			for (int i = 0; i < Curso.Count; i++)
			{
				Console.Write(" " + (i + 1));
				Console.Write("\t");
				Console.Write(Curso[i].CodigoCurso);
				Console.Write("\t\t");
				Console.Write(Curso[i].NombreCurso);
				Console.Write("\t\t");
				

				Console.Write("\n");
			}

		}

		public void VerPersonaDiccionario()
		{
			Console.WriteLine("\n Personas en el Diccionario");
			for (int i = 0; i < personaAgenda.Count; i++)
			{
				KeyValuePair<int, Alumno> persona = personaAgenda.ElementAt(i);

				Console.WriteLine("\n Dni: " + persona.Key);
				Alumno personaValor = persona.Value;

				Console.WriteLine(" Nombre Persona: " + personaValor.Registro);
				Console.WriteLine(" Apellido Persona: " + personaValor.Nombre);
				Console.WriteLine(" Telefono Persona: " + personaValor.Apellido);
				

			}


		}

		public void VerCursoDiccionario()
		{
			Console.WriteLine("\n Curso en el Diccionario");
			for (int i = 0; i < cursoDiccionario.Count; i++)
			{
				KeyValuePair<int, Curso> curso = cursoDiccionario.ElementAt(i);

				Console.WriteLine("\n Código del Curso: " + curso.Key);
				Curso cursoValor = curso.Value;

				Console.WriteLine(" Nombre del Curso: " + cursoValor.NombreCurso);
				
			}


		}





	}
}
