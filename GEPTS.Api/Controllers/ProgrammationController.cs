using GEPTS.Features.Contrats.Services;
using GEPTS.Features.DTOs.Programmations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MsCommun.Reponses;

namespace GEPTS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammationController : ControllerBase
    {
        private readonly IServiceDeProgrammation _service;
        private readonly ILogger<ProgrammationController> _logger;
        public ProgrammationController(IServiceDeProgrammation service, ILogger<ProgrammationController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ReponseDeRequette>> AjouterUneProgrammation(ProgrammationACreerDto programmationACreer)
        {
            _logger.LogInformation($"Controller :: {nameof(AjouterUneProgrammation)} ");
            var result = await _service.AjouterUneProgrammation(programmationACreer);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<ProgrammationDto>>> LireToutesLesProgrammations()
        {
            _logger.LogInformation($"Controller :: {nameof(LireToutesLesProgrammations)} ");
            var listeDeProgrammation = await _service.LireToutesLesProgrammations();
            if (listeDeProgrammation.Count == 0)
                return NoContent();
            return Ok(listeDeProgrammation);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProgrammationDetailDto>> LireInfoDuneProgrammation(Guid id)
        {
            _logger.LogInformation($"Controller :: {nameof(LireInfoDuneProgrammation)} ");
            var programmationDetail = await _service.LireDetailDuneProgrammation(id);

            if (programmationDetail == null)
                return NotFound();
            return Ok(programmationDetail);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> ModifierUneProgrammation(Guid id, ProgrammationAModifierDto programmationAModifierDto)
        {
            _logger.LogInformation($"Controller :: {nameof(ModifierUneProgrammation)} ");
            var resultat = await _service.ModifierUneProgrammation(id, programmationAModifierDto);
            return StatusCode(resultat.StatusCode, resultat);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> SupprimerUneProgrammation(Guid id)
        {
            _logger.LogInformation($"Controller :: {nameof(SupprimerUneProgrammation)} ");
            var resultat = await _service.SupprimerUneProgrammation(id);
            return StatusCode(resultat.StatusCode, resultat);
        }
    }
}
