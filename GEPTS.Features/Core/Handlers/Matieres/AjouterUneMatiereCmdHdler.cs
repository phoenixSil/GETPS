using AutoMapper;
using GETPS.Features.Core.BaseFactoryClass;
using MsCommun.Reponses;
using MediatR;
using GETPS.Features.Core.Commandes.Matieres;
using Microsoft.Extensions.Logging;
using GETPS.Domain.Modeles;
using System.Net;
using Newtonsoft.Json;
using MassTransit;
using GEPTS.Features.DTOs.Matieres.Validations;
using GEPTS.Features.Contrats.Repertoire;

namespace GETPS.Features.Core.Handlers.Matieres
{
    public class AjouterUneMatiereCmdHdler : BaseCommandHandler<AjouterUneMatiereCmd, ReponseDeRequette>
    {
       
        private readonly ILogger<AjouterUneMatiereCmdHdler> _logger;

        public AjouterUneMatiereCmdHdler(ILogger<AjouterUneMatiereCmdHdler> logger, IPointDaccess pointDaccess, IMapper mapper, IMediator mediator)
             : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }
        public override async Task<ReponseDeRequette> Handle(AjouterUneMatiereCmd request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle : On Vas Essayer d'ajoutter Une nouvelle matiere dans la Base de donnees  ");
            var reponse = new ReponseDeRequette();
            var validateur = new ValidateurDeLaCreationDeMatiereDto();
            var resultatValidation = await validateur.ValidateAsync(request.MatiereAAjouterDto, cancellationToken);

            if (resultatValidation.IsValid is false)
            {
                _logger.LogWarning($" Handle: les donnees entrer ne sont pas valides . la requettes n'aboutirra pas {JsonConvert.SerializeObject(request.MatiereAAjouterDto)}");
                reponse.Success = false;
                reponse.Message = "Echec de Lajout dune Matiere a la matiere donc l'Id est notee dans le champs d'Id";
                reponse.Errors = resultatValidation.Errors.Select(q => q.ErrorMessage).ToList();
                reponse.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                var matiereACreer = _mapper.Map<Matiere>(request.MatiereAAjouterDto);
                var result = await _pointDaccess.RepertoireDeMatiere.Ajoutter(matiereACreer);

                if (result is null)
                {
                    _logger.LogError($" Handle: Une Erreur Inconnu est Survenu:  la requettes n'a pas aboutti {JsonConvert.SerializeObject(request.MatiereAAjouterDto)}");
                    reponse.Success = false;
                    reponse.Message = "Echec de Lajout dune Matiere na pas marche ";
                    reponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                }
                else
                {
                    _logger.LogInformation(" Handle: LAjout de matiere a reussit !!! ");
                    reponse.Success = true;
                    reponse.Message = "Ajout de Matiere Reussit";
                    reponse.Id = result.Id;
                    reponse.StatusCode = (int)HttpStatusCode.Created;

                }
            }

            return reponse;
        }
    }
}
