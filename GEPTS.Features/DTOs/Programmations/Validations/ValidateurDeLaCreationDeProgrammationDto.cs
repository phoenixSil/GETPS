using FluentValidation;
using GEPTS.Features.Contrats.Repertoire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPTS.Features.DTOs.Programmations.Validations
{
    public class ValidateurDeLaCreationDeProgrammationDto: AbstractValidator<ProgrammationACreerDto>
    {
        public readonly IPointDaccess _pointDaccess;
        public ValidateurDeLaCreationDeProgrammationDto(IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            Include(new ValidateurDeDtoDeProgrammation(_pointDaccess));
        }
    }
}
