using System.Data;
using System.Data.SqlClient;
using BikeShop.Data.Interfaces;
using Dapper;
using Microsoft.Extensions.Logging;

namespace BikeShop.Data;
public abstract class RepositoryBase
{
    private readonly IConnectionInfo _settings;
    private readonly ILogger _logger;

    protected RepositoryBase(IConnectionInfo settings, ILogger logger)
    {
        _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        _logger = logger;
    }

    protected async Task<IEnumerable<U>> QueryDataAsync<T, U>(string query, T parameters)
    {
        try
        {
            using var connection = new SqlConnection(_settings.ConnectionString);
            await connection.OpenAsync();
            return await connection.QueryAsync<U>(query, parameters, commandType: CommandType.Text);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.Message);
            throw new DataException("An error occured while querying the database.");
        }
        
    }

    protected async Task SaveDataAsync<T>(string sqlCommand, T parameters)
    {
        try
        {
            using var connection = new SqlConnection(_settings.ConnectionString);
            await connection.OpenAsync();
            await connection.ExecuteAsync(sqlCommand, parameters, commandType: CommandType.Text);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.Message);
            throw new DataException("An error occured while saving to the database.");
        }
    }
}

