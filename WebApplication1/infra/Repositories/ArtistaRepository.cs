using Dapper;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.ConexaoDB;

namespace Infrastructore.Repositories
{
    public class ArtistaRepository : IArtistaRepository
    {
        private readonly PostgresDbConnection _postgresDbConnection;

        public ArtistaRepository(PostgresDbConnection postgresDbConnection)
        {
            _postgresDbConnection = postgresDbConnection;
        }

        //LEMBRE DE MUDAR O CÓDIGO PARA FUNCIONAR
        //Create
        public async Task<int> AddArtistaAsync(Artista artista)
        {
            try
            {
                using (var dbConnection = _postgresDbConnection.CreateConnection())
                {
                    var sqlQuery = "INSERT INTO Artista (nome, email) VALUES (@Nome, @Email)";
                    return await dbConnection.ExecuteScalarAsync<int>(sqlQuery, artista);
                }
            }
            catch (Exception error)
            {
                throw new ApplicationException("Um erro aconteceu durante a query SQL: " + error);
            }
        }

        //GetById
        public async Task<Artista> GetArtistaByIdAsync(int id)
        {
            try
            {
                using (var dbConnection = _postgresDbConnection.CreateConnection())
                {
                    var sqlQuery = "SELECT * FROM Artista WHERE ArtistaId = @Id";
                    return await dbConnection.QueryFirstOrDefaultAsync<Artista>(sqlQuery, new { Id = id });
                }
            }
            catch (Exception error)
            {
                throw new ApplicationException("Um erro aconteceu durante a query SQL: " + error);
            }
        }

        //GetAll
        public async Task<IEnumerable<Artista>> GetAllArtistaAsync()
        {
            try
            {
                using (var dbConnection = _postgresDbConnection.CreateConnection())
                {
                    var sqlQuery = "SELECT * FROM Artista";
                    return await dbConnection.QueryAsync<Artista>(sqlQuery);
                }
            }
            catch (Exception error)
            {
                throw new ApplicationException("Um erro aconteceu durante a query SQL: " + error);
            }
        }

        //LEMBRE DE MUDAR O CÓDIGO PARA FUNCIONAR
        //Update
        public async Task UpdateArtistaAsync(Artista artista)
        {
            try
            {
                using (var dbConnection = _postgresDbConnection.CreateConnection())
                {
                    var sqlQuery = "UPDATE Artista SET nome = @Nome, email = @Email WHERE artistaId = @ArtistaId";
                    await dbConnection.ExecuteAsync(sqlQuery, artista);
                }
            }
            catch (Exception error)
            {
                throw new ApplicationException("Um erro aconteceu durante a query SQL: " + error);
            }
        }

        //Delete
        public async Task DeleteArtistaAsync(int id)
        {
            try
            {
                using (var dbConnection = _postgresDbConnection.CreateConnection())
                {
                    var sqlQuery = "DELETE FROM Artista WHERE ArtistaId = @Id";
                    await dbConnection.ExecuteAsync(sqlQuery, new { Id = id });
                }
            }
            catch (Exception error)
            {
                throw new ApplicationException("Um erro aconteceu durante a query SQL: " + error);
            }
        }
    }
}
