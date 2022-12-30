using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GETPS.Domain.Modeles
{
    public class Programmation: BaseEntite
    {
        public DateTime DateDeDebut { get; set; }
        public DateTime DateDeFin { get; set; }
        public int Duree { get; set; }
        public string Observation { get; set; }
        public bool CourTermine { get; set; }
        public Guid MatiereId { get; set; }
        public Matiere Matiere { get; set; }
    }
}
