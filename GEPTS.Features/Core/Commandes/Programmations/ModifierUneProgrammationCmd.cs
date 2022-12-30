using MediatR;
using MsCommun.Reponses;
using GETPS.Features.Core.BaseFactoryClass;
using GEPTS.Features.DTOs.Programmations;

namespace GETPS.Features.Core.Commandes.Programmations
{
    public class ModifierUneProgrammationCmd : BaseCommand<ReponseDeRequette>
    {
        public Guid ProgrammationId { get; set; }
        public ProgrammationAModifierDto ProgrammationAModifierDto { get; set; }
    }
}
