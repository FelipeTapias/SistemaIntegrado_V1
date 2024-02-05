using SistemaIntegrado.Domain.Entities;
using System.Data.SqlClient;

namespace SistemaIntegrado.Adapter.SQL.UsuarioDB
{
    public class UsuarioDB: BaseDeDatos
    {
        public UsuarioDB(string server, string baseDedatos) : base(server, baseDedatos)
        {

        }

        public List<UsuarioEntity> GetAllUsers()
        {
            Connect();
            List<UsuarioEntity> usuarioEntities = new List<UsuarioEntity>();
            string query = "SELECT id, primerNombre, segundoNombre, primerApellido, segundoApellido, celular, correo, tipoDocumento, documento, estado FROM Usuarios";
            SqlCommand sqlCommand = new(query, _sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                int id = sqlDataReader.GetInt32(0);
                string primerNombre = sqlDataReader.GetString(1);
                string segundoNombre = sqlDataReader.GetString(2);
                string primerApellido = sqlDataReader.GetString(3);
                string segundoApellido = sqlDataReader.GetString(4);
                string celular = sqlDataReader.GetString(5);
                string correo = sqlDataReader.GetString(6);
                int tipoDocumento = sqlDataReader.GetInt32(7);
                string documento = sqlDataReader.GetString(8);
                int estado = sqlDataReader.GetInt32(9);

                usuarioEntities.Add(new UsuarioEntity(id, primerNombre, segundoNombre, primerApellido, segundoApellido, celular, correo, tipoDocumento, documento, estado));
            }

            Close();

            return usuarioEntities;

        }

        public UsuarioEntity GetOneUser(int userId)
        {
            Connect();

            UsuarioEntity usuarioEntity = null;

            string query = "SELECT id, primerNombre, segundoNombre, primerApellido, segundoApellido, celular, correo, tipoDocumento, documento, estado FROM Usuarios " +
                "WHERE id = @Id";

            SqlCommand sqlCommand = new(query, _sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", userId);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();


            if(sqlDataReader.Read())
            {
                string primerNombre = sqlDataReader.GetString(1);
                string segundoNombre = sqlDataReader.GetString(2);
                string primerApellido = sqlDataReader.GetString(3);
                string segundoApellido = sqlDataReader.GetString(4);
                string celular = sqlDataReader.GetString(5);
                string correo = sqlDataReader.GetString(6);
                int tipoDocumento = sqlDataReader.GetInt32(7);
                string documento = sqlDataReader.GetString(8);
                int estado = sqlDataReader.GetInt32(9);

                usuarioEntity = new UsuarioEntity(userId, primerNombre, segundoNombre, primerApellido, segundoApellido, celular, correo, tipoDocumento, documento, estado);
            }

            Close();

            return usuarioEntity;

        }

        public void InsertOneUser(UsuarioEntity usuarioEntity)
        {
            Connect();
            string query = "INSERT INTO Usuarios(primerNombre, segundoNombre, primerApellido, segundoApellido, celular, correo, tipoDocumento, documento, estado) " +
                "VALUES(@primerNombre, @segundoNombre, @primerApellido, @segundoApellido, @celular, @correo, @tipoDocumento, @documento, @estado)";

            SqlCommand sqlCommand = new(query, _sqlConnection);
            sqlCommand.Parameters.AddWithValue("@primerNombre", usuarioEntity.PrimerNombre);
            sqlCommand.Parameters.AddWithValue("@segundoNombre", usuarioEntity.SegundoNombre);
            sqlCommand.Parameters.AddWithValue("@primerApellido", usuarioEntity.PrimerApellido);
            sqlCommand.Parameters.AddWithValue("@segundoApellido", usuarioEntity.SegundoApellido);
            sqlCommand.Parameters.AddWithValue("@celular", usuarioEntity.Celular);
            sqlCommand.Parameters.AddWithValue("@correo", usuarioEntity.Correo);
            sqlCommand.Parameters.AddWithValue("@tipoDocumento", usuarioEntity.TipoDocumento);
            sqlCommand.Parameters.AddWithValue("@documento", usuarioEntity.Documento);
            sqlCommand.Parameters.AddWithValue("@estado", usuarioEntity.Estado);

            sqlCommand.ExecuteNonQuery();

            Close();
        }

        public void UpdateOneUser(UsuarioEntity usuarioEntity)
        {
            Connect();

            string query = "UPDATE Usuarios SET primerNombre=@primerNombre, celular=@celular " + 
                "WHERE id = @id";
            SqlCommand sqlCommand = new(query, _sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", usuarioEntity.Id);
            sqlCommand.Parameters.AddWithValue("@primerNombre", usuarioEntity.PrimerNombre);
            sqlCommand.Parameters.AddWithValue("@celular", usuarioEntity.Celular);

            sqlCommand.ExecuteNonQuery();

            Close();

        }

        public void DeleteOneUser(int userId)
        {
            Connect();

            string query = "DELETE FROM Usuarios WHERE id = @id";

            SqlCommand sqlCommand = new(query, _sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", userId);

            sqlCommand.ExecuteNonQuery();

            Close();
        }
    }
}
