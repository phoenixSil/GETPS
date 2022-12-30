using GEPTS.Features.Contrats.Services;
using GEPTS.Features.DTOs.Matieres;
using GETPS.Domain.Modeles;
using GETPS.Features.Core.Commandes.Matieres;
using MediatR;
using MsCommun.Reponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPTS.Application.Services
{
    public class ServiceDeMatiere : IServiceDeMatiere
    {
        private readonly IMediator _mediator;
        public ServiceDeMatiere(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<ReponseDeRequette> AjouterUneMatiere(MatiereACreerDto matiereDto)
        {
            var response = await _mediator.Send(new AjouterUneMatiereCmd { MatiereAAjouterDto = matiereDto });
            return response;
        }

        public async Task<MatiereDetailDto> LireDetailDuneMatiere(Guid matiereId)
        {
            var response = await _mediator.Send(new LireDetailDUneMatiereCmd { MatiereId = matiereId });
            return response;
        }

        public async Task<List<MatiereDto>> LireToutesLesMatieres()
        {
            var response = await _mediator.Send(new LireToutesLesMatieresCmd { });
            return response;
        }

        public async Task<ReponseDeRequette> ModifierUneMatiere(Guid matiereId, MatiereAModifierDto matiereDto)
        {
            var response = await _mediator.Send(new ModifierUneMatiereCmd { MatiereId = matiereId, MatiereAModifierDto = matiereDto });
            return response;
        }

        public async Task<ReponseDeRequette> SupprimerUneMatiere(Guid matiereId)
        {
            var response = await _mediator.Send(new SupprimerUneMatiereCmd { MatiereId = matiereId });
            return response;
        }
    }
}
