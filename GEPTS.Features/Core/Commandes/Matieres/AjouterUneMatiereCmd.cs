using MsCommun.Reponses;
using GETPS.Features.Core.BaseFactoryClass;
using GEPTS.Features.DTOs.Matieres;

namespace GETPS.Features.Core.Commandes.Matieres
{
    public class AjouterUneMatiereCmd : BaseCommand
    {
        public MatiereACreerDto MatiereAAjouterDto { get; set; }
    }
}
