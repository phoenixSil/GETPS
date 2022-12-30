using MediatR;
using MsCommun.Reponses;
using GETPS.Features.Core.BaseFactoryClass;

namespace GETPS.Features.Core.Commandes.Matieres
{
    public class SupprimerUneMatiereCmd : BaseCommand<ReponseDeRequette>
    {
        public Guid MatiereId { get; set; }
    }
}
