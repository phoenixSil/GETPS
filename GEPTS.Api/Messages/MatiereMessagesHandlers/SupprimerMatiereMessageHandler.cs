using GEPTS.Features.Contrats.Services;
using GEPTS.Features.DTOs.Matieres;
using MassTransit;
using MsCommun.Messages.Matieres;
using MsCommun.Messages.Utils;

namespace GEPTS.Api.Messages.MatiereMessagesHandlers
{
    public class SupprimerMatiereMessageHandler : IConsumer<MatiereASupprimerMessage>
    {
        private readonly IServiceDeMatiere _service;
        private readonly ILogger<AjouterMatiereMessageHandler> _logger;

        public SupprimerMatiereMessageHandler(ILogger<AjouterMatiereMessageHandler> logger, IServiceDeMatiere service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<MatiereASupprimerMessage> context)
        {
            _logger.LogInformation("On vas entamer la suppresion dun Matiere A Partir du message recu du Bus ");

            var matiereMessage = context.Message;
            if (matiereMessage.Service == DesignationService.SERVICE_GEENS)
            {
                if (matiereMessage.Type == TypeMessage.SUPPRESSION)
                {
                    MatiereDto matiere = await _service.LireMatiereParNumeroExterne(matiereMessage.Id);

                    if (matiere is not null)
                    {
                        await _service.SupprimerUneMatiere(matiere.Id).ConfigureAwait(false);
                        _logger.LogInformation("BUS => GdC: Le matiere a Ete bien supprimer  !!");
                    }
                    else
                    {
                        _logger.LogWarning("BUS => GdC: Lmatiere nexiste pas  !!");
                    }

                }
            }
        }
    }
}
