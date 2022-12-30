
using MsCommun.Reponses;
using GETPS.Features.Core.BaseFactoryClass;
using GEPTS.Features.DTOs.Matieres;

namespace GETPS.Features.Core.Commandes.Matieres
{
    public class ModifierUneMatiereCmd : BaseCommand 
    {
        public Guid MatiereId { get; set; }
        public MatiereAModifierDto MatiereAModifierDto { get; set; }
    }
}
