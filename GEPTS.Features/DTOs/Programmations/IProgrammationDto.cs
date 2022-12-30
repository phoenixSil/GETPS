using GEPTS.Features.DTOs.Matieres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPTS.Features.DTOs.Programmations
{
    public interface IProgrammationDto
    {
        public DateTime DateDeDebut { get; set; }
        public DateTime DateDeFin { get; set; }
        public int Duree { get; set; }
        public bool CourTermine { get; set; }
        public Guid MatiereId { get; set; }
    }
}
