using GEPTS.Features.DTOs.Matieres;
using GEPTS.Features.DTOs.Programmations;
using GETPS.Domain.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPTS.Features.DTOs.Programmations
{
    public class ProgrammationDetailDto: BaseDomainDto, IProgrammationDto
    {
        public DateTime DateDeDebut { get; set; }
        public DateTime DateDeFin { get; set; }
        public int Duree { get; set; }
        public string Observation { get; set; }
        public bool CourTermine { get; set; }
        public Guid MatiereId { get; set; }
        public MatiereDto Matiere { get; set; }
    }
}
