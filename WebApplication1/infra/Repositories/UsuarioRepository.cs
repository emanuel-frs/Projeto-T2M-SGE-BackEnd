using Dapper;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.ConexaoDB;
using System.Threading.Tasks;

namespace Infrastructore.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PostgresDbConnection _postgresDbConnection;

        public UsuarioRepository(PostgresDbConnection postgresDbConnection)
        {
            _postgresDbConnection = postgresDbConnection;
        }

        public async Task<int> AddUsuarioAsync(Usuario usuario)
        {
            try
            {
                using (var dbConnection = _postgresDbConnection.CreateConnection())
                {
                    var sqlQuery = "INSERT INTO Usuario (nome, email, senha) VALUES (@Nome, @Email, @Senha) RETURNING usuarioId";
                    return await dbConnection.ExecuteScalarAsync<int>(sqlQuery, usuario);
                }
            }
            catch (Exception error)
            {
                throw new ApplicationException("Um erro aconteceu durante a query SQL: " + error);
            }
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            try
            {
                using (var dbConnection = _postgresDbConnection.CreateConnection())
                {
                    var sqlQuery = "SELECT * FROM Usuario WHERE UsuarioId = @Id";
                    return await dbConnection.QueryFirstOrDefaultAsync<Usuario>(sqlQuery, new { Id = id });
                }
            }
            catch (Exception error)
            {
                throw new ApplicationException("Um erro aconteceu durante a query SQL: " + error);
            }
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuarioAsync()
        {
            try
            {
                using (var dbConnection = _postgresDbConnection.CreateConnection())
                {
                    var sqlQuery = "SELECT * FROM Usuario";
                    return await dbConnection.QueryAsync<Usuario>(sqlQuery);
                }
            }
            catch (Exception error)
            {
                throw new ApplicationException("Um erro aconteceu durante a query SQL: " + error);
            }
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            try
            {
                using (var dbConnection = _postgresDbConnection.CreateConnection())
                {
                    var sqlQuery = "UPDATE Usuario SET nome = @Nome, email = @Email, senha = @Senha WHERE usuarioId = @UsuarioId";
                    await dbConnection.ExecuteAsync(sqlQuery, usuario);
                }
            }
            catch (Exception error)
            {
                throw new ApplicationException("Um erro aconteceu durante a query SQL: " + error);
            }
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            try
            {
                using (var dbConnection = _postgresDbConnection.CreateConnection())
                {
                    var sqlQuery = "DELETE FROM Usuario WHERE UsuarioId = @Id";
                    await dbConnection.ExecuteAsync(sqlQuery, new { Id = id });
                }
            }
            catch (Exception error)
            {
                throw new ApplicationException("Um erro aconteceu durante a query SQL: " + error);
            }
        }

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            try
            {
                using (var dbConnection = _postgresDbConnection.CreateConnection())
                {
                    var sqlQuery = "SELECT * FROM Usuario WHERE email = @Email";
                    return await dbConnection.QueryFirstOrDefaultAsync<Usuario>(sqlQuery, new { Email = email });
                }
            }
            catch (Exception error)
            {
                throw new ApplicationException("Um erro aconteceu durante a query SQL: " + error);
            }
        }
    }
}
