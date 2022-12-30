using AutoMapper;
using MsCommun.Reponses;
using MediatR;
using GETPS.Features.Core.Commandes.Matieres;
using GETPS.Features.Core.BaseFactoryClass;
using Microsoft.Extensions.Logging;
using System.Net;
using Newtonsoft.Json;
using MassTransit;
using MsCommun.Messages.Matieres;
using MsCommun.Messages.Utils;
using GEPTS.Features.DTOs.Matieres.Validations;
using GEPTS.Features.DTOs.Matieres;
using GEPTS.Features.Contrats.Repertoire;

namespace GETPS.Features.Core.Handlers.Matieres
{
    public class ModifierUneMatiereCmdHdler : BaseCommandHandler<ModifierUneMatiereCmd, ReponseDeRequette>
    {
        private readonly ILogger<ModifierUneMatiereCmdHdler> _logger;

        public ModifierUneMatiereCmdHdler(ILogger<ModifierUneMatiereCmdHdler> logger , IPointDaccess pointDaccess, IMediator mediator, IMapper mapper)
             : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }
        public override async Task<ReponseDeRequette> Handle(ModifierUneMatiereCmd request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"On vas essayer de Modifier une Matiere . Donness {JsonConvert.SerializeObject(request.MatiereAModifierDto)}");
            var reponse = new ReponseDeRequette();
            var matiere = await _pointDaccess.RepertoireDeMatiere.Lire(request.MatiereId);

            if (matiere is null)
            {
                reponse.Success = false;
                reponse.Message = "La matiere specifier est introuvable ";
                reponse.Id = request.MatiereId;
                reponse.StatusCode = (int)HttpStatusCode.NotFound;
                _logger.LogWarning($"la matiere nexsite pas Id : [{request.MatiereId}]");
            }
            else
            {
                var validateur = new ValidateurDeLaModificationDeMatiereDto();
                var resultatValidation = await validateur.ValidateAsync(request.MatiereAModifierDto, cancellationToken);

                if (resultatValidation.IsValid is false)
                {
                    reponse.Success = false;
                    reponse.Message = "Les Donnees de la matiere ne sont pas valides  ";
                    reponse.Id = request.MatiereId;
                    reponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    _logger.LogError($"Les Donnees de la matiere ne sont pas valides : {JsonConvert.SerializeObject(request.MatiereAModifierDto)}");

                }
                else
                {
                    _mapper.Map(request.MatiereAModifierDto, matiere);

                    await _pointDaccess.RepertoireDeMatiere.Modifier(matiere);
                    await _pointDaccess.Enregistrer();

                    reponse.Success = true;
                    reponse.Message = "Modification Reussit";
                    reponse.Id = matiere.Id;
                    reponse.StatusCode = (int)HttpStatusCode.OK;
                    _logger.LogInformation($"Modification de la Matiere Reussit ID: [{request.MatiereId}]");

                }
            }
            return reponse;
        }
    }
}
