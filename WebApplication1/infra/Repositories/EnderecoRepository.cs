using Dapper;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.ConexaoDB;

namespace Infrastructore.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly PostgresDbConnection _postgresDbConnection;

        public EnderecoRepository(PostgresDbConnection postgresDbConnection)
        {
            _postgresDbConnection = postgresDbConnection;
        }

        //LEMBRE DE MUDAR O CÓDIGO PARA FUNCIONAR
        //Create
        public async Task<int> AddEnderecoAsync(Endereco endereco)
        {
            try
            {
                using (var dbConnection = _postgresDbConnection.CreateConnection())
                {
                    var sqlQuery = "INSERT INTO Endereco (rua, numero, complemento, bairro, cidade, estado, cep) VALUES (@Rua, @Numero, @Complemento, @Bairro, @Cidade, @Estado, @CEP) returning enderecoId";
                    return await dbConnection.ExecuteScalarAsync<int>(sqlQuery, endereco);
                }
            }
            catch (Exception error)
            {
                throw new ApplicationException("Um erro aconteceu durante a query SQL: " + error);
            }
        }

        //GetById
        public async Task<Endereco> GetEnderecoByIdAsync(int id)
        {
            try
            {
                using (var dbConnection = _postgresDbConnection.CreateConnection())
                {
                    var sqlQuery = "SELECT * FROM Endereco WHERE EnderecoId = @Id";
                    return await dbConnection.QueryFirstOrDefaultAsync<Endereco>(sqlQuery, new { Id = id });
                }
            }
            catch (Exception error)
            {
                throw new ApplicationException("Um erro aconteceu durante a query SQL: " + error);
            }
        }

        //GetAll
        public async Task<IEnumerable<Endereco>> GetAllEnderecoAsync()
        {
            try
            {
                using (var dbConnection = _postgresDbConnection.CreateConnection())
                {
                    var sqlQuery = "SELECT * FROM Endereco";
                    return await dbConnection.QueryAsync<Endereco>(sqlQuery);
                }
            }
            catch (Exception error)
            {
                throw new ApplicationException("Um erro aconteceu durante a query SQL: " + error);
            }
        }

        //LEMBRE DE MUDAR O CÓDIGO PARA FUNCIONAR
        //Update
        public async Task UpdateEnderecoAsync(Endereco endereco)
        {
            try
            {
                using (var dbConnection = _postgresDbConnection.CreateConnection())
                {
                    var sqlQuery = "UPDATE Endereco SET rua = @Rua, numero = @Numero, complemento = @Complemento, bairro = @Bairro, cidade = @Cidade, estado = @Estado, cep = @Cep WHERE enderecoId = @EnderecoId";
                    await dbConnection.ExecuteAsync(sqlQuery, endereco);
                }
            }
            catch (Exception error)
            {
                throw new ApplicationException("Um erro aconteceu durante a query SQL: " + error);
            }
        }

        //Delete
        public async Task DeleteEnderecoAsync(int id)
        {
            try
            {
                using (var dbConnection = _postgresDbConnection.CreateConnection())
                {
                    var sqlQuery = "DELETE FROM Endereco WHERE EnderecoId = @Id";
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
