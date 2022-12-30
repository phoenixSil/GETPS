using GEPTS.Features.DTOs.Programmations;
using GETPS.Features.Core.BaseFactoryClass;
using MediatR;

namespace GETPS.Features.Core.Commandes.Programmations
{
    public class LireDetailDUneProgrammationCmd : BaseCommand<ProgrammationDetailDto>
    {
        public Guid Id { get; set; }
    }
}
