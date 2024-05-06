using ApiWebDB.BaseDados.Models;
using ApiWebDB.Services;
using ApiWebDB.Services.DTOs;
using ApiWebDB.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiWebDB.Controllers
{
    /// <summary>
    /// Controlador para gerenciar clientes.
    /// Este controlador é responsável por todas as operações CRUD relacionadas aos clientes.
    /// </summary>
    
    [Route("api/[controller]")]
    [ApiController]
    public class EndercoController : ControllerBase
    {
        public readonly EnderecoService _service;
        private readonly ILogger _logger;
        public EndercoController(EnderecoService service, ILogger<EndercoController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Insere um novo cliente na base de dados.
        /// Este método recebe um DTO de cliente e o insere na base de dados.
        /// Retorna 200 se bem-sucedido, 422 para entidade inválida e 400 para requisição inválida.
        /// </summary>
        /// <param name="cliente">O DTO do cliente a ser inserido. Este deve conter todas as informações necessárias do cliente.</param>
        /// <returns>O cliente inserido, incluindo o ID gerado. Se bem-sucedido, retorna o cliente recém-criado com seu ID.</returns>

        [HttpPost()]
        public ActionResult<TbEndereco> Insert(EnderecoDTO ender)
        {
            try
            {
                var entity = _service.Insert(ender);
                return Ok(entity);
            }
            catch (InvalidEntityException E)
            {
                return new ObjectResult(new { error = E.Message })
                {
                    StatusCode = 422
                };
            }
            catch (BadRequestException E)
            {
                return new ObjectResult(new { error = E.Message })
                {
                    StatusCode = 400
                };
            }
            catch (System.Exception E)
            {
                _logger.LogError(E.Message);
                return BadRequest(E.Message);
            }
        }
        /// <summary>
        /// Atualiza os dados do Endereço de acordo com seu Id
        /// </summary>
        /// <returns>Retorna os dados do endereço atualizado</returns>
        /// <response code="200">Retorna o Json com os dados do novo endereço</response>
        /// <response code="400">Os dados enviados não são válidos</response>
        /// <response code="404">Registro não encontrado para a atualização</response>
        /// <response code="422">Campos obrigatórios não enviados para a atualização</response>
        /// <response code="500">Erro interno de servidor</response>
        [HttpPut("{id}")]
        public ActionResult<TbEndereco> Update(int id, EnderecoDTO dto)
        {
            try
            {
                var entity = _service.Update(dto, id);
                return Ok(entity);
            }
            catch (InvalidEntityException E)
            {
                return new ObjectResult(new { error = E.Message })
                {
                    StatusCode = 422
                };
            }
            catch (BadRequestException E)
            {
                return new ObjectResult(new { error = E.Message })
                {
                    StatusCode = 400
                };
            }
            catch (NotFoundException E)
            {
                return NotFound(E.Message);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Faz a Exclusão de um Endereço de acordo com seu ID
        /// </summary>
        /// <returns>Retorna o Endereço Deletado</returns>
        /// <response code="204">Retorna o Endereço Deletado</response>
        /// <response code="404">Endereço não encontrado</response>
        /// <response code="500">Erro interno de servidor</response>
        [HttpDelete("{id}")]
        public ActionResult<TbEndereco> Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return NoContent();
            }
            catch (NotFoundException E)
            {
                return NotFound(E.Message);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);
                return new ObjectResult(new { error = e.Message })
                {
                    StatusCode = 500
                };
            }
        }
        /// <summary>
        /// Obtém todos os clientes da base de dados.
        /// Este método retorna todos os clientes da base de dados.
        /// Retorna 200 se bem-sucedido, 404 se nenhum cliente for encontrado e 500 para erro interno do servidor.
        /// </summary>
        /// <returns>Uma lista de todos os clientes, incluindo todos os seus campos. Se bem-sucedido, retorna uma lista de todos os clientes.</returns>

        [HttpGet("{id}")]
        public ActionResult<TbEndereco> GetEnder(int id)
        {
            try
            {
                var entity = _service.GetEnder(id);
                return Ok(entity);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);
                return new ObjectResult(new { error = e.Message })
                {
                    StatusCode = 500
                };
            }
        }
    }
}