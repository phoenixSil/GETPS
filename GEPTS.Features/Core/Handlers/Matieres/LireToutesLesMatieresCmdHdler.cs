using AutoMapper;
using MsCommun.Reponses;
using MediatR;
using GETPS.Features.Core.Commandes.Matieres;
using Microsoft.Extensions.Logging;
using GETPS.Features.Core.BaseFactoryClass;
using GEPTS.Features.Contrats.Repertoire;
using GEPTS.Features.DTOs.Matieres;

namespace GETPS.Features.Core.Handlers.Matieres
{
    public class LireToutesLesMatieresCmdHdler : BaseCommandHandler<LireToutesLesMatieresCmd, List<MatiereDto>>
    {

        private readonly ILogger<LireToutesLesMatieresCmdHdler> _logger;

        public LireToutesLesMatieresCmdHdler(ILogger<LireToutesLesMatieresCmdHdler> logger, IMediator mediator, IPointDaccess pointDaccess, IMapper mapper)
            : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }


        public override async Task<List<MatiereDto>> Handle(LireToutesLesMatieresCmd request, CancellationToken cancellationToken)
        {
            var result = await _pointDaccess.RepertoireDeMatiere.Lire();
            var list = _mapper.Map<List<MatiereDto>>(result);

            return _mapper.Map<List<MatiereDto>>(list);
        }
    }
}
