
using ClienteApi.Data;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace ClienteApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConexaoController : ControllerBase
    {
        private readonly ConexaoBanco _conexaoBanco;

        public ConexaoController(ConexaoBanco conexaoBanco)
        {
            _conexaoBanco = conexaoBanco;
        }

        [HttpGet("testar")]
        public async Task<IActionResult> TestarConexao()
        {
            try
            {
                await using var conexao = _conexaoBanco.CriarConexao();

                await conexao.OpenAsync();

                await using var comando = new NpgsqlCommand("SELECT 1", conexao);

                var resultado = await comando.ExecuteScalarAsync();

                return Ok(new
                {
                    mensagem = "Conexão com PostgreSQL realizada com sucesso!",
                    resultado = resultado
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    mensagem = "Erro ao conectar com PostgreSQL.",
                    erro = ex.Message
                });
            }
        }
    }
}
