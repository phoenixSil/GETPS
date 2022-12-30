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
    public class LireUneMatiereCmdHdler : BaseCommandHandler<LireDetailDUneMatiereCmd, MatiereDetailDto>
    {
        private readonly ILogger<LireUneMatiereCmdHdler> _logger;

        public LireUneMatiereCmdHdler(ILogger<LireUneMatiereCmdHdler> logger, IMediator mediator, IPointDaccess pointDaccess, IMapper mapper)
            : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public override async Task<MatiereDetailDto> Handle(LireDetailDUneMatiereCmd request, CancellationToken cancellationToken)
        {
            if (request.MatiereId.Equals(Guid.Empty))
                throw new BadRequestException($"Id [{request.MatiereId}] que vous avez entrez est null");

            var result = await _pointDaccess.RepertoireDeMatiere.Lire(request.MatiereId);
            var matiere = _mapper.Map<MatiereDetailDto>(result);

            return matiere;
        }
    }
}
