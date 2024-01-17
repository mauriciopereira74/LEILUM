using Microsoft.AspNetCore.Mvc;

namespace leilum.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        [HttpPost("upload")]
        public IActionResult Upload(IFormFile file)
        {
            try
            {
                if (file != null && file.Length > 0)
                {
                    // Defina o caminho da pasta onde deseja salvar o arquivo
                    string pastaDestino = "";
                
                    // Combine o caminho com o nome do arquivo
                    string caminhoCompleto = Path.Combine(pastaDestino, file.FileName);

                    // Salve o arquivo no disco
                    using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok("Arquivo enviado com sucesso!");
                }
                else
                {
                    return BadRequest("Nenhum arquivo enviado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
    