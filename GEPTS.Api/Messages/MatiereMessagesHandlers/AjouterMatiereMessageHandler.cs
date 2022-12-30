using AutoMapper;
using GEPTS.Features.Contrats.Services;
using GEPTS.Features.DTOs.Matieres;
using MassTransit;
using MsCommun.Messages.Matieres;
using MsCommun.Messages.Utils;

namespace GEPTS.Api.Messages.MatiereMessagesHandlers
{
    public class AjouterMatiereMessageHandler : IConsumer<MatiereACreerMessage>
    {
        private readonly IServiceDeMatiere _service;
        private readonly IMapper _mapper;
        private readonly ILogger<AjouterMatiereMessageHandler> _logger;

        public AjouterMatiereMessageHandler(ILogger<AjouterMatiereMessageHandler> logger, IServiceDeMatiere service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<MatiereACreerMessage> context)
        {
            var matiereMessage = context.Message;
            if (matiereMessage.Service == DesignationService.SERVICE_GDC)
            {
                if (matiereMessage.Type == TypeMessage.CREATION)
                {
                    _logger.LogInformation("On a recu un message dajout de Matiere dans le Bus, on vas le traiter Dans Gdc !!");
                    var dto = _mapper.Map<MatiereACreerDto>(matiereMessage);
                    await _service.AjouterUneMatiere(dto).ConfigureAwait(false);

                    _logger.LogInformation("BUS => GdC: Le matiere a Ete bien Ajouter  !!");
                }
            }
        }
    }
}
