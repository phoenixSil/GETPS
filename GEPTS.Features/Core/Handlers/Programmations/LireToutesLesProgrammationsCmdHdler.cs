using AutoMapper;
using MsCommun.Reponses;
using MediatR;
using GETPS.Features.Core.Commandes.Programmations;
using Microsoft.Extensions.Logging;
using GETPS.Features.Core.BaseFactoryClass;
using GEPTS.Features.Contrats.Repertoire;
using GEPTS.Features.DTOs.Programmations;

namespace GETPS.Features.Core.Handlers.Programmations
{
    public class LireToutesLesProgrammationsCmdHdler : BaseCommandHandler<LireToutesLesProgrammationsCmd, List<ProgrammationDto>>
    {

        private readonly ILogger<LireToutesLesProgrammationsCmdHdler> _logger;

        public LireToutesLesProgrammationsCmdHdler(ILogger<LireToutesLesProgrammationsCmdHdler> logger, IMediator mediator, IPointDaccess pointDaccess, IMapper mapper)
            : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }


        public override async Task<List<ProgrammationDto>> Handle(LireToutesLesProgrammationsCmd request, CancellationToken cancellationToken)
        {
            var result = await _pointDaccess.RepertoireDeProgrammation.Lire();
            var list = _mapper.Map<List<ProgrammationDto>>(result);

            return _mapper.Map<List<ProgrammationDto>>(list);
        }
    }
}
