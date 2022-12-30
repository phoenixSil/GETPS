using MsCommun.Exceptions;
using MsCommun.Reponses;
using MediatR;
using GETPS.Features.Core.BaseFactoryClass;
using GETPS.Features.Core.Commandes.Programmations;
using AutoMapper;
using Microsoft.Extensions.Logging;
using GETPS.Domain.Modeles;
using System.Net;
using MassTransit;
using MsCommun.Messages.Utils;
using GEPTS.Features.Contrats.Repertoire;

namespace GETPS.Features.Core.Handlers.Programmations
{
    public class SupprimerUneProgrammationCmdHdler : BaseCommandHandler<SupprimerUneProgrammationCmd, ReponseDeRequette>
    {
        private readonly ILogger<SupprimerUneProgrammationCmdHdler> _logger;

        public SupprimerUneProgrammationCmdHdler(ILogger<SupprimerUneProgrammationCmdHdler> logger, IPointDaccess pointDaccess, IMediator mediator, IMapper mapper)
             : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }
        public override async Task<ReponseDeRequette> Handle(SupprimerUneProgrammationCmd request, CancellationToken cancellationToken)
        {
            var reponse = new ReponseDeRequette();

            if (request.ProgrammationId == Guid.Empty)
                throw new BadRequestException($"Id [{request.ProgrammationId}] que vous avez entrez est null");

            var programmation = await _pointDaccess.RepertoireDeProgrammation.Lire(request.ProgrammationId);

            if (programmation is not null)
            {
                await _pointDaccess.RepertoireDeProgrammation.Supprimer(programmation);
                await _pointDaccess.Enregistrer();

                reponse.Success = true;
                reponse.Message = "Suppression Reussit ";
                reponse.Id = request.ProgrammationId;
                reponse.StatusCode = (int)HttpStatusCode.OK;
            }
            else
            {
                reponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                throw new NotFoundException(nameof(Programmation), request.ProgrammationId);
            }
            return reponse;
        }
    }
}
