using MediatR;
using MsCommun.Reponses;
using GETPS.Features.Core.BaseFactoryClass;
using GEPTS.Features.DTOs.Programmations;

namespace GETPS.Features.Core.Commandes.Programmations
{
    public class AjouterUneProgrammationCmd : BaseCommand<ReponseDeRequette>
    {
        public ProgrammationACreerDto ProgrammationAAjouterDto { get; set; }
    }
}
