using GEPTS.Features.Contrats.Services;
using GEPTS.Features.DTOs.Matieres;
using GEPTS.Features.DTOs.Programmations;
using GETPS.Domain.Modeles;
using GETPS.Features.Core.Commandes.Matieres;
using GETPS.Features.Core.Commandes.Programmations;
using MediatR;
using MsCommun.Reponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPTS.Application.Services
{
    public class ServiceDeProgrammation : IServiceDeProgrammation
    {
        private readonly IMediator _mediator;

        public ServiceDeProgrammation(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ReponseDeRequette> AjouterUneProgrammation(ProgrammationACreerDto programmationAAjouter)
        {
            var response = await _mediator.Send(new AjouterUneProgrammationCmd { ProgrammationAAjouterDto = programmationAAjouter });
            return response;
        }

        public async Task<ProgrammationDetailDto> LireDetailDuneProgrammation(Guid id)
        {
            var response = await _mediator.Send(new LireDetailDUneProgrammationCmd { ProgrammationId = id });
            return response;
        }

        public async Task<List<ProgrammationDto>> LireToutesLesProgrammations()
        {
            var response = await _mediator.Send(new LireToutesLesProgrammationsCmd { });
            return response;
        }

        public async Task<ReponseDeRequette> ModifierUneProgrammation(Guid id, ProgrammationAModifierDto matiereDto)
        {
            var response = await _mediator.Send(new ModifierUneProgrammationCmd { ProgrammationId = id, ProgrammationAModifierDto = matiereDto });
            return response;
        }

        public async Task<ReponseDeRequette> SupprimerUneProgrammation(Guid ProgrammationId)
        {
            var response = await _mediator.Send(new SupprimerUneProgrammationCmd { ProgrammationId = ProgrammationId });
            return response;
        }
    }
}
