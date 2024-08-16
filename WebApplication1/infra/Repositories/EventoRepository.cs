using Domain.Entities;
using Infrastructure.ConexaoDB;
using Dapper;
using Domain.Repositories;

namespace Infrastructore.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly PostgresDbConnection _postgresDbConnection;

        public EventoRepository(PostgresDbConnection postgresDbConnection)
        {
            _postgresDbConnection = postgresDbConnection;
        }

        //LEMBRE DE MUDAR O CÓDIGO PARA FUNCIONAR
        //Create
        public async Task<int> AddEventoAsync(Evento evento)
        {
            try
            {
                using (var dbConnection = _postgresDbConnection.CreateConnection())
                {
                    var sqlQuery = @"
                        INSERT INTO Evento (nome, data, descricao, capacidade, enderecoId)
                        VALUES (@Nome, @Data, @Descricao, @Capacidade, @EnderecoId)
                        RETURNING eventoId";

                    evento.EventoId = await dbConnection.ExecuteScalarAsync<int>(sqlQuery, evento);
                    return evento.EventoId;
                }
            }
            catch (Exception error)
            {
                throw new ApplicationException("Um erro aconteceu durante a query SQL: " + error);
            }
        }

        //GetById
        public async Task<Evento> GetEventoByIdAsync(int id)
        {
            try
            {
                using (var dbConnection = _postgresDbConnection.CreateConnection())
                {
                    var sqlQuery = "SELECT * FROM Evento WHERE EventoId = @Id";
                    return await dbConnection.QueryFirstOrDefaultAsync<Evento>(sqlQuery, new { Id = id });
                }
            }
            catch (Exception error)
            {
                throw new ApplicationException("Um erro aconteceu durante a query SQL: " + error);
            }
        }

        //GetAll
        public async Task<IEnumerable<Evento>> GetAllEventoAsync()
        {
            try
            {
                using (var dbConnection = _postgresDbConnection.CreateConnection())
                {
                    var sqlQuery = "SELECT * FROM Evento";
                    return await dbConnection.QueryAsync<Evento>(sqlQuery);
                }
            }
            catch (Exception error)
            {
                throw new ApplicationException("Um erro aconteceu durante a query SQL: " + error);
            }
        }

        //LEMBRE DE MUDAR O CÓDIGO PARA FUNCIONAR
        //Update
        public async Task UpdateEventoAsync(Evento evento)
        {
            try
            {
                using (var dbConnection = _postgresDbConnection.CreateConnection())
                {
                    var sqlQuery = "UPDATE Evento SET nome = @Nome, data = @Data, descricao = @Descricao, capacidade = @Capacidade, enderecoId =  @EnderecoId  WHERE eventoId = @EventoId";
                    await dbConnection.ExecuteAsync(sqlQuery, evento);
                }
            }
            catch (Exception error)
            {
                throw new ApplicationException("Um erro aconteceu durante a query SQL: " + error);
            }
        }

        //Delete
        public async Task DeleteEventoAsync(int id)
        {
            try
            {
                using (var dbConnection = _postgresDbConnection.CreateConnection())
                {
                    var sqlQuery = "DELETE FROM Evento WHERE EventoId = @Id";
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
