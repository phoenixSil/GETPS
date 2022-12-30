using GEPTS.Features.DTOs.Matieres;
using MsCommun.Reponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPTS.Features.Contrats.Services
{
    public interface IServiceDeMatiere
    {
        public Task<List<MatiereDto>> LireToutesLesMatieres();
        public Task<ReponseDeRequette> AjouterUneMatiere(MatiereACreerDto filiereAAjouter);
        public Task<ReponseDeRequette> SupprimerUneMatiere(Guid MatiereId);
        public Task<MatiereDetailDto> LireDetailDuneMatiere(Guid id);
        public Task<ReponseDeRequette> ModifierUneMatiere(Guid filiereId, MatiereAModifierDto filiereAModifierDto);
        public Task<MatiereDto> LireMatiereParNumeroExterne(Guid numeroExterne);
    }
}
