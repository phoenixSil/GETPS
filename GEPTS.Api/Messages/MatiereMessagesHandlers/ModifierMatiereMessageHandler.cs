using AutoMapper;
using GEPTS.Features.Contrats.Services;
using GEPTS.Features.DTOs.Matieres;
using MassTransit;
using MsCommun.Messages.Matieres;
using MsCommun.Messages.Utils;

namespace GEPTS.Api.Messages.MatiereMessagesHandlers
{
    public class ModifierMatiereMessageHandler : IConsumer<MatiereAModifierMessage>
    {
        private readonly IServiceDeMatiere _service;
        private readonly IMapper _mapper;
        private readonly ILogger<AjouterMatiereMessageHandler> _logger;

        public ModifierMatiereMessageHandler(ILogger<AjouterMatiereMessageHandler> logger, IServiceDeMatiere service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<MatiereAModifierMessage> context)
        {
            var matiereMessage = context.Message;

            if (matiereMessage.Service == DesignationService.SERVICE_GEENS)
            {
                if (matiereMessage.Type == TypeMessage.MODIFICATION)
                {
                    _logger.LogInformation("On a recu un message de modification de Matiere dans le Bus, on vas le traiter Dans Gdc !!");
                    MatiereDto matiere = await _service.LireMatiereParNumeroExterne(matiereMessage.NumeroExterne);
                    var dto = _mapper.Map<MatiereAModifierDto>(matiereMessage);
                    await _service.ModifierUneMatiere(matiere.Id, dto).ConfigureAwait(false);
                    _logger.LogInformation("BUS => GdC: Le matiere a Ete bien Ajouter  !!");

                }
            }
        }
    }
}
