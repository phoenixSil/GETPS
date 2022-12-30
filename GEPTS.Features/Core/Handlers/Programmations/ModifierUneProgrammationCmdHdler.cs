using AutoMapper;
using MsCommun.Reponses;
using MediatR;
using GETPS.Features.Core.Commandes.Programmations;
using GETPS.Features.Core.BaseFactoryClass;
using Microsoft.Extensions.Logging;
using System.Net;
using Newtonsoft.Json;
using MassTransit;
using MsCommun.Messages.Utils;
using GEPTS.Features.DTOs.Programmations.Validations;
using GEPTS.Features.DTOs.Programmations;
using GEPTS.Features.Contrats.Repertoire;

namespace GETPS.Features.Core.Handlers.Programmations
{
    public class ModifierUneProgrammationCmdHdler : BaseCommandHandler<ModifierUneProgrammationCmd, ReponseDeRequette>
    {
        private readonly ILogger<ModifierUneProgrammationCmdHdler> _logger;

        public ModifierUneProgrammationCmdHdler(ILogger<ModifierUneProgrammationCmdHdler> logger , IPointDaccess pointDaccess, IMediator mediator, IMapper mapper)
             : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }
        public override async Task<ReponseDeRequette> Handle(ModifierUneProgrammationCmd request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"On vas essayer de Modifier une Programmation . Donness {JsonConvert.SerializeObject(request.ProgrammationAModifierDto)}");
            var reponse = new ReponseDeRequette();
            var programmation = await _pointDaccess.RepertoireDeProgrammation.Lire(request.ProgrammationId);

            if (programmation is null)
            {
                reponse.Success = false;
                reponse.Message = "La programmation specifier est introuvable ";
                reponse.Id = request.ProgrammationId;
                reponse.StatusCode = (int)HttpStatusCode.NotFound;
                _logger.LogWarning($"la programmation nexsite pas Id : [{request.ProgrammationId}]");
            }
            else
            {
                var validateur = new ValidateurDeLaModificationDeProgrammationDto(_pointDaccess);
                var resultatValidation = await validateur.ValidateAsync(request.ProgrammationAModifierDto, cancellationToken);

                if (resultatValidation.IsValid is false)
                {
                    reponse.Success = false;
                    reponse.Message = "Les Donnees de la programmation ne sont pas valides  ";
                    reponse.Id = request.ProgrammationId;
                    reponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    _logger.LogError($"Les Donnees de la programmation ne sont pas valides : {JsonConvert.SerializeObject(request.ProgrammationAModifierDto)}");

                }
                else
                {
                    _mapper.Map(request.ProgrammationAModifierDto, programmation);

                    await _pointDaccess.RepertoireDeProgrammation.Modifier(programmation);
                    await _pointDaccess.Enregistrer();

                    reponse.Success = true;
                    reponse.Message = "Modification Reussit";
                    reponse.Id = programmation.Id;
                    reponse.StatusCode = (int)HttpStatusCode.OK;
                    _logger.LogInformation($"Modification de la Programmation Reussit ID: [{request.ProgrammationId}]");

                }
            }
            return reponse;
        }
    }
}
