using AutoMapper;
using GEPTS.Features.DTOs.Matieres;
using GEPTS.Features.DTOs.Programmations;
using GETPS.Domain.Modeles;
using MsCommun.Messages.Matieres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace GEPTS.Features.MappingProfile
{
    public class MappingProfile: Profile
    {

        public MappingProfile()
        {
            CreateMap<Matiere, MatiereDto>().ReverseMap();
            CreateMap<Matiere, MatiereACreerDto>().ReverseMap();
            CreateMap<Matiere, MatiereDetailDto>().ReverseMap();
            CreateMap<Matiere, MatiereAModifierDto>().ReverseMap();
            CreateMap<MatiereACreerDto, MatiereACreerMessage>().ReverseMap();
            CreateMap<MatiereAModifierDto, MatiereAModifierMessage>().ReverseMap();

            CreateMap<Programmation, ProgrammationDto>().ReverseMap();
            CreateMap<Programmation, ProgrammationACreerDto>().ReverseMap();
            CreateMap<Programmation, ProgrammationDetailDto>().ReverseMap();
            CreateMap<Programmation, ProgrammationAModifierDto>().ReverseMap();
        }
    }
}
