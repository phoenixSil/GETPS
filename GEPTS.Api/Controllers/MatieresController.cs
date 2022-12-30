using GEPTS.Features.Contrats.Services;
using GEPTS.Features.DTOs.Matieres;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MsCommun.Reponses;

namespace GEPTS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatieresController : ControllerBase
    {
        private readonly IServiceDeMatiere _service;
        private readonly ILogger<MatieresController> _logger;
        public MatieresController(IServiceDeMatiere service, ILogger<MatieresController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ReponseDeRequette>> AjouterUneMatiere(MatiereACreerDto matiereACreer)
        {
            _logger.LogInformation($"Controller :: {nameof(AjouterUneMatiere)} ");
            var result = await _service.AjouterUneMatiere(matiereACreer);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<MatiereDto>>> LireToutesLesMatieres()
        {
            _logger.LogInformation($"Controller :: {nameof(LireToutesLesMatieres)} ");
            var listeDeMatiere = await _service.LireToutesLesMatieres();
            if (listeDeMatiere.Count == 0)
                return NoContent();
            return Ok(listeDeMatiere);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MatiereDetailDto>> LireInfoDuneMatiere(Guid id)
        {
            _logger.LogInformation($"Controller :: {nameof(LireInfoDuneMatiere)} ");
            var matiereDetail = await _service.LireDetailDuneMatiere(id);

            if (matiereDetail == null)
                return NotFound();
            return Ok(matiereDetail);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> ModifierUneMatiere(Guid id, MatiereAModifierDto matiereAModifierDto)
        {
            _logger.LogInformation($"Controller :: {nameof(ModifierUneMatiere)} ");
            var resultat = await _service.ModifierUneMatiere(id, matiereAModifierDto);
            return StatusCode(resultat.StatusCode, resultat);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> SupprimerUneMatiere(Guid id)
        {
            _logger.LogInformation($"Controller :: {nameof(SupprimerUneMatiere)} ");
            var resultat = await _service.SupprimerUneMatiere(id);
            return StatusCode(resultat.StatusCode, resultat);
        }
    }
}
