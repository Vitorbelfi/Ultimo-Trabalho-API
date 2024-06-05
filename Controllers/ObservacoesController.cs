using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservacoesController : ControllerBase
    {
        private readonly IObservacoesRepositorio _observacoesRepositorio;

        public ObservacoesController(IObservacoesRepositorio observacoesRepositorio)
        {
            _observacoesRepositorio = observacoesRepositorio;
        }

        [HttpGet("GetAllObservacoes")]
        public async Task<ActionResult<List<ObservacoesModel>>> GetAllObservacoes()
        {
            List<ObservacoesModel> animais = await _observacoesRepositorio.GetAll();
            return Ok(animais);
        }

        [HttpGet("GetObservacaoId/{id}")]
        public async Task<ActionResult<ObservacoesModel>> GetObservacaoId(int id)
        {
            ObservacoesModel observacao = await _observacoesRepositorio.GetById(id);
            return Ok(observacao);
        }

        [HttpPost("CreateObservacao")]
        public async Task<ActionResult<ObservacoesModel>> InsertObservacao([FromBody] ObservacoesModel observacaoModel)
        {
            ObservacoesModel observacao = await _observacoesRepositorio.InsertObservacoes(observacaoModel);
            return Ok(observacao);
        }
        [HttpPut("UpdateObservacao/{id:int}")]
        public async Task<ActionResult<ObservacoesModel>> UpdateObservacao(int id, [FromBody] ObservacoesModel observacaoModel)
        {
            observacaoModel.ObservacaoId = id;
            ObservacoesModel observacao = await _observacoesRepositorio.UpdateObservacoes(observacaoModel, id);
            return Ok(observacao);
        }
        [HttpDelete("Deleteobservacao/{id:int}")]
        public async Task<ActionResult<ObservacoesModel>> DeleteObservacao(int id)
        {
            bool deleted = await _observacoesRepositorio.DeleteObservacao(id);
            return Ok(deleted);
        }

    }
}
