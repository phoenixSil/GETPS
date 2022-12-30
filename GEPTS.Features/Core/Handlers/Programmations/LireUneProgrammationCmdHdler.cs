using AutoMapper;
using MsCommun.Exceptions;
using MsCommun.Reponses;
using MediatR;
using GETPS.Features.Core.Commandes.Programmations;
using Microsoft.Extensions.Logging;
using GETPS.Features.Core.BaseFactoryClass;
using GEPTS.Features.DTOs.Programmations;
using GEPTS.Features.Contrats.Repertoire;

namespace GETPS.Features.Core.Handlers.Programmations
{
    public class LireUneProgrammationCmdHdler : BaseCommandHandler<LireDetailDUneProgrammationCmd, ProgrammationDetailDto>
    {
        private readonly ILogger<LireUneProgrammationCmdHdler> _logger;

        public LireUneProgrammationCmdHdler(ILogger<LireUneProgrammationCmdHdler> logger, IMediator mediator, IPointDaccess pointDaccess, IMapper mapper)
            : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public override async Task<ProgrammationDetailDto> Handle(LireDetailDUneProgrammationCmd request, CancellationToken cancellationToken)
        {
            if (request.ProgrammationId.Equals(Guid.Empty))
                throw new BadRequestException($"Id [{request.ProgrammationId}] que vous avez entrez est null");

            var result = await _pointDaccess.RepertoireDeProgrammation.Lire(request.ProgrammationId);
            var programmation = _mapper.Map<ProgrammationDetailDto>(result);

            return programmation;
        }
    }
}
