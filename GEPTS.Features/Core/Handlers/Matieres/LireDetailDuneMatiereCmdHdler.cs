using AutoMapper;
using MsCommun.Exceptions;
using MsCommun.Reponses;
using MediatR;
using GETPS.Features.Core.Commandes.Matieres;
using Microsoft.Extensions.Logging;
using GETPS.Features.Core.BaseFactoryClass;
using GEPTS.Features.DTOs.Matieres;
using GEPTS.Features.Contrats.Repertoire;

namespace GETPS.Features.Core.Handlers.Matieres
{
    public class LireDetailDuneMatiereCmdHdler : BaseCommandHandler<LireDetailDUneMatiereCmd, MatiereDetailDto>
    {
        private readonly ILogger<LireDetailDuneMatiereCmdHdler> _logger;

        public LireDetailDuneMatiereCmdHdler(ILogger<LireDetailDuneMatiereCmdHdler> logger, IMediator mediator, IPointDaccess pointDaccess, IMapper mapper)
            : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public override async Task<MatiereDetailDto> Handle(LireDetailDUneMatiereCmd request, CancellationToken cancellationToken)
        {
            _logger.LogError($"Lecture du detail dun Niveau ");
            if (request.MatiereId.HasValue)
            {
                var niveau = await _pointDaccess.RepertoireDeMatiere.Lire(request.MatiereId.Value);
                var NiveauDetail = _mapper.Map<MatiereDetailDto>(niveau);
                return NiveauDetail;
            }
            else if (request.NumeroExterne.HasValue)
            {
                var niveau = await _pointDaccess.RepertoireDeMatiere.LireParNumeroExterne(request.NumeroExterne.Value);
                var NiveauDetail = _mapper.Map<MatiereDetailDto>(niveau);
                return NiveauDetail;
            }
            else
            {
                _logger.LogError($"Une erreur Inconnue est survenue {request.MatiereId} et NumeroExterne {request.NumeroExterne}");
                throw new BadRequestException($"Une erreur Inconnue est survenue {request.MatiereId} et NumeroExterne {request.NumeroExterne}");
            }
        }
    }
}
