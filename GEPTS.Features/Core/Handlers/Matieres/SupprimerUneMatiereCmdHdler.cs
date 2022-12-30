using MsCommun.Exceptions;
using MsCommun.Reponses;
using MediatR;
using GETPS.Features.Core.BaseFactoryClass;
using GETPS.Features.Core.Commandes.Matieres;
using AutoMapper;
using Microsoft.Extensions.Logging;
using GETPS.Domain.Modeles;
using System.Net;
using MassTransit;
using MsCommun.Messages.Matieres;
using MsCommun.Messages.Utils;
using GEPTS.Features.Contrats.Repertoire;

namespace GETPS.Features.Core.Handlers.Matieres
{
    public class SupprimerUneMatiereCmdHdler : BaseCommandHandler<SupprimerUneMatiereCmd, ReponseDeRequette>
    {
        private readonly ILogger<SupprimerUneMatiereCmdHdler> _logger;

        public SupprimerUneMatiereCmdHdler(ILogger<SupprimerUneMatiereCmdHdler> logger, IPointDaccess pointDaccess, IMediator mediator, IMapper mapper)
             : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }
        public override async Task<ReponseDeRequette> Handle(SupprimerUneMatiereCmd request, CancellationToken cancellationToken)
        {
            var reponse = new ReponseDeRequette();

            if (request.MatiereId == Guid.Empty)
                throw new BadRequestException($"Id [{request.MatiereId}] que vous avez entrez est null");

            var matiere = await _pointDaccess.RepertoireDeMatiere.Lire(request.MatiereId);

            if (matiere is not null)
            {
                await _pointDaccess.RepertoireDeMatiere.Supprimer(matiere);
                await _pointDaccess.Enregistrer();

                reponse.Success = true;
                reponse.Message = "Suppression Reussit ";
                reponse.Id = request.MatiereId;
                reponse.StatusCode = (int)HttpStatusCode.OK;
            }
            else
            {
                reponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                throw new NotFoundException(nameof(Matiere), request.MatiereId);
            }
            return reponse;
        }
    }
}
