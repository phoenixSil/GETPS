using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPTS.Features.DTOs.Matieres
{
    public class MatiereDto
    {
        public string CodeMatiere { get; set; }
        public string Designation { get; set; }
        public string DesignationNiveau { get; set; }
        public string DesignationCycle { get; set; }
        public string NomEnseignant { get; set; }
        public string PrenomEnseignant { get; set; }
    }
}
