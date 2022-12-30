using MediatR;
using MsCommun.Reponses;
using GETPS.Features.Core.BaseFactoryClass;

namespace GETPS.Features.Core.Commandes.Programmations
{
    public class SupprimerUneProgrammationCmd : BaseCommand<ReponseDeRequette>
    {
        public Guid Id { get; set; }
    }
}
