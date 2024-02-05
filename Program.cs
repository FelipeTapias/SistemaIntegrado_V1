using SistemaIntegrado.Adapter.SQL.UsuarioDB;
using SistemaIntegrado.Commons.Exceptions;
using SistemaIntegrado.Domain.Entities;
using System.Data.SqlClient;

namespace SistemaIntegrado
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                UsuarioDB usuarioDB = new UsuarioDB("SISTE875", "SistemaIntegrado");

                bool again = true;
                int op = 0;

                do
                {
                    
                    ShowMenu();
                    Console.WriteLine("Elige una opción: ");
                    op = int.Parse(Console.ReadLine());

                    switch(op)
                    {
                        case 1:
                            GetAllUsers(usuarioDB);
                            break;
                        case 2:
                            InsertOneUser(usuarioDB);
                            break;
                        case 3:
                            UpdateOneUser(usuarioDB);
                            break;
                        case 4:
                            DeleteUser(usuarioDB);
                            break;
                        case 5:
                            again = false;
                            break;
                    }

                } while (again);

            } catch(SqlException ex)
            {
                Console.WriteLine("Fallo en la conexión \n{0}", ex.Message);
            }
        }

        public static void ShowMenu()
        {
            Console.WriteLine("\n-------Menu-------");
            Console.WriteLine("1. Mostrar");
            Console.WriteLine("2. Agregar");
            Console.WriteLine("3. Editar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("5. Salir");
        }

        public static void GetAllUsers(UsuarioDB usuarioDB)
        {
            Console.Clear();
            Console.WriteLine("Sistema Integrado");
            List<UsuarioEntity> usuarioEntities = usuarioDB.GetAllUsers();

            foreach (UsuarioEntity usuarioEntity in usuarioEntities)
                Console.WriteLine($"Id: {usuarioEntity.Id} - PrimerNombre: {usuarioEntity.PrimerNombre} - Celular: {usuarioEntity.Celular}");
        }

        public static void InsertOneUser(UsuarioDB usuarioDB)
        {
            Console.Clear();
            Console.WriteLine("Agregar nuevo usuario");

            Console.WriteLine("Ingresa primer nombre");
            string primerNombre = Console.ReadLine();

            Console.WriteLine("Ingresa segundo nombre");
            string segundoNombre = Console.ReadLine();

            Console.WriteLine("Ingresa primer apellido");
            string primerApellido = Console.ReadLine();

            Console.WriteLine("Ingresa primer nombre");
            string segundoApellido = Console.ReadLine();

            Console.WriteLine("Ingresa celular");
            string celular = Console.ReadLine();

            Console.WriteLine("Ingresa correo");
            string correo = Console.ReadLine();

            Console.WriteLine("Ingresa tipo documento");
            int tipoDocumento = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa documento");
            string documento = Console.ReadLine();

            // Estado inicial del cliente
            int estado = 1;

            usuarioDB.InsertOneUser(new UsuarioEntity(primerNombre, segundoNombre, primerApellido, segundoApellido, celular, correo, tipoDocumento, documento, estado));
        }

        public static void UpdateOneUser(UsuarioDB usuarioDB)
        {
            try
            {
                Console.Clear();
                GetAllUsers(usuarioDB);

                Console.WriteLine("Inserta el ID del usuario a editar: ");
                int id = int.Parse(Console.ReadLine());

                UsuarioEntity usuarioEntity = usuarioDB.GetOneUser(id);

                if (usuarioEntity == null)
                    throw new UserExceptions();

                Console.WriteLine("Usuario a editar:");
                Console.WriteLine($"PrimerNombre: {usuarioEntity.PrimerNombre} - Celular: {usuarioEntity.Celular}");

                Console.WriteLine("Ingresa nuevos datos: ");

                Console.WriteLine("Ingresa el nuevo primer nombre: ");
                string primerNombre = Console.ReadLine();

                Console.WriteLine("Ingresa el nuevo celular: ");
                string celular = Console.ReadLine();

                usuarioEntity.PrimerNombre = primerNombre;
                usuarioEntity.Celular = celular;

                usuarioDB.UpdateOneUser(usuarioEntity);

                Console.WriteLine("¡Usuario actualizado con éxito!");

            } catch (UserExceptions e) {
                Console.WriteLine(e.Message);
            }
        }

        public static void DeleteUser(UsuarioDB usuarioDB)
        {
            try
            {
                Console.Clear();
                GetAllUsers(usuarioDB);

                Console.WriteLine("Inserta el ID del usuario a eliminar");
                int id = int.Parse(Console.ReadLine());

                UsuarioEntity usuarioEntity = usuarioDB.GetOneUser(id);

                if (usuarioEntity == null)
                    throw new UserExceptions();

                Console.WriteLine("Usuario a eliminar:");
                Console.WriteLine($"PrimerNombre: {usuarioEntity.PrimerNombre} - Celular: {usuarioEntity.Celular}");

                int accept = 0;
                Console.WriteLine("¿Estás seguro de eliminar el usuario? Sí = 1 , No = 0");
                accept = int.Parse(Console.ReadLine());

                if(accept == 1)
                {
                    usuarioDB.DeleteOneUser(id);
                    Console.WriteLine("¡Usuario eliminado correctamente!");
                }
            }
            catch (UserExceptions e) {
                Console.WriteLine(e.Message);
            }

        }
    }
}