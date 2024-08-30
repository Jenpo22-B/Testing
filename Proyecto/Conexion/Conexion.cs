using Dapper;
using Microsoft.Data.SqlClient;
using Proyecto.Models;

namespace Proyecto.Conexion
{
    public interface IConexion
    {
        Task InsertPaciente(Formulario paciente);
        Task<IEnumerable<Formulario>> ObtenerPacientePorApellido(string apellido);
        Task<IEnumerable<Formulario>> ObtenerPacientePorRut(string rut);
    }

    public class Conexion : IConexion
    {
        private readonly string connectionString;

        public Conexion(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<IEnumerable<Formulario>> ObtenerPacientePorRut(string rut)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Formulario>(@"Select Rut,Nombre,Apellido,Direccion,Ciudad,Telefono,Email,FechaNacimiento,EstadoCivil,Comentario from Pacientes where Rut=@rut", new { rut });
        }
        public async Task<IEnumerable<Formulario>> ObtenerPacientePorApellido(string apellido)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Formulario>(@"Select Rut,Nombre,Apellido,Direccion,Ciudad,Telefono,Email,FechaNacimiento,EstadoCivil,Comentario from Pacientes where Apellido like '%" + apellido + "%'");
        }
        public async Task InsertPaciente(Formulario paciente)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(@"Insert into Pacientes (Rut,Nombre,Apellido,Direccion,Ciudad,Telefono,Email,FechaNacimiento,EstadoCivil,Comentario) values (@Rut,@Nombre,@Apellido,@Direccion,@Ciudad,@Telefono,@Email,@FechaNacimiento,@EstadoCivil,@Comentario)", paciente);
        }
    }
}
