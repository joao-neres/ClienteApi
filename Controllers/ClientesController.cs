using ClienteApi.Data;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace ClienteApi.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly ConexaoBanco _conexaoBanco;

        public ClientesController(ConexaoBanco conexaoBanco)
        {
            _conexaoBanco = conexaoBanco;
        }
        [HttpGet]
public async Task<IActionResult> ListarCLientes()
 {
    try
    {
        await using var conexao = _conexaoBanco.CriarConexao();

        await conexao.OpenAsync();

        string sql = "SELECT * FROM cliente ORDER BY id_cliente";

        await using var comando = new NpgsqlCommand(sql, conexao);

        await using var leitor = await comando.ExecuteReaderAsync();

        var clientes = new List<object>();
        
        while (await leitor.ReadAsync())
        {
            clientes.Add(new
            {
                id_Cliente = leitor.GetInt32(0),
                nome = leitor.GetString(1),
                cpf = leitor.GetString(2),
                email = leitor.GetString(3),
                telefone = leitor.GetString(4),
                data_nascimento = leitor.GetDateTime(5),
                ativo = leitor.GetBoolean(6)
            });
        }

        return Ok(clientes);
    }
    catch (Exception ex)
    {
        return StatusCode(500, new
        {
            mensagem = "Erro ao listar clientes.",
            erro = ex.Message
        });
    }
 }
    }
}