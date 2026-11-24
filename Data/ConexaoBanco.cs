
using Npgsql;

namespace ClienteApi.Data
{
    public class ConexaoBanco
    {
        private readonly string _connectionString;

        public ConexaoBanco(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "String de conexão não encontrada.");
        }

        public NpgsqlConnection CriarConexao()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}
