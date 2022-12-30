using MediatR;
using GEPTS.Features.DTOs.Matieres;
using GETPS.Features.Core.BaseFactoryClass;

namespace GETPS.Features.Core.Commandes.Matieres
{
    public class LireDetailDUneMatiereCmd : BaseCommand<MatiereDetailDto>
    {
        public Guid MatiereId { get; set; }
    }
}
