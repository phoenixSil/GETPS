using AutoMapper;
using GETPS.Features.Core.BaseFactoryClass;
using MsCommun.Reponses;
using MediatR;
using GETPS.Features.Core.Commandes.Programmations;
using Microsoft.Extensions.Logging;
using GETPS.Domain.Modeles;
using System.Net;
using Newtonsoft.Json;
using MassTransit;
using GEPTS.Features.DTOs.Programmations.Validations;
using GEPTS.Features.Contrats.Repertoire;

namespace GETPS.Features.Core.Handlers.Programmations
{
    public class AjouterUneProgrammationCmdHdler : BaseCommandHandler<AjouterUneProgrammationCmd, ReponseDeRequette>
    {
       
        private readonly ILogger<AjouterUneProgrammationCmdHdler> _logger;

        public AjouterUneProgrammationCmdHdler(ILogger<AjouterUneProgrammationCmdHdler> logger, IPointDaccess pointDaccess, IMapper mapper, IMediator mediator)
             : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }
        public override async Task<ReponseDeRequette> Handle(AjouterUneProgrammationCmd request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle : On Vas Essayer d'ajoutter Une nouvelle programmation dans la Base de donnees  ");
            var reponse = new ReponseDeRequette();
            var validateur = new ValidateurDeLaCreationDeProgrammationDto(_pointDaccess);
            var resultatValidation = await validateur.ValidateAsync(request.ProgrammationAAjouterDto, cancellationToken);

            if (resultatValidation.IsValid is false)
            {
                _logger.LogWarning($" Handle: les donnees entrer ne sont pas valides . la requettes n'aboutirra pas {JsonConvert.SerializeObject(request.ProgrammationAAjouterDto)}");
                reponse.Success = false;
                reponse.Message = "Echec de Lajout dune Programmation a la programmation donc l'Id est notee dans le champs d'Id";
                reponse.Errors = resultatValidation.Errors.Select(q => q.ErrorMessage).ToList();
                reponse.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                var programmationACreer = _mapper.Map<Programmation>(request.ProgrammationAAjouterDto);
                var result = await _pointDaccess.RepertoireDeProgrammation.Ajoutter(programmationACreer);

                if (result is null)
                {
                    _logger.LogError($" Handle: Une Erreur Inconnu est Survenu:  la requettes n'a pas aboutti {JsonConvert.SerializeObject(request.ProgrammationAAjouterDto)}");
                    reponse.Success = false;
                    reponse.Message = "Echec de Lajout dune Programmation na pas marche ";
                    reponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                }
                else
                {
                    _logger.LogInformation(" Handle: LAjout de programmation a reussit !!! ");
                    reponse.Success = true;
                    reponse.Message = "Ajout de Programmation Reussit";
                    reponse.Id = result.Id;
                    reponse.StatusCode = (int)HttpStatusCode.Created;

                }
            }

            return reponse;
        }
    }
}
