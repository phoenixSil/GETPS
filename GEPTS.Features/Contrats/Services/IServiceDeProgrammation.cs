using GEPTS.Features.DTOs.Programmations;
using MsCommun.Reponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPTS.Features.Contrats.Services
{
    public interface IServiceDeProgrammation
    {
        public Task<List<ProgrammationDto>> LireToutesLesProgrammations();
        public Task<ReponseDeRequette> AjouterUneProgrammation(ProgrammationACreerDto filiereAAjouter);
        public Task<ReponseDeRequette> SupprimerUneProgrammation(Guid ProgrammationId);
        public Task<ProgrammationDetailDto> LireDetailDuneProgrammation(Guid id);
        public Task<ReponseDeRequette> ModifierUneProgrammation(Guid filiereId, ProgrammationAModifierDto filiereAModifierDto);
    }
}
