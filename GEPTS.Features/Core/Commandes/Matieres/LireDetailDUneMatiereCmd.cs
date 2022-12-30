using MediatR;
using GEPTS.Features.DTOs.Matieres;

namespace GETPS.Features.Core.Commandes.Matieres
{
    public class LireDetailDUneMatiereCmd : IRequest<MatiereDetailDto>
    {
        public Guid Id { get; set; }
    }
}
