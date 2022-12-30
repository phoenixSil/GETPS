using FluentValidation;
using GEPTS.Features.Contrats.Repertoire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPTS.Features.DTOs.Programmations.Validations
{
    public class ValidateurDeLaModificationDeProgrammationDto: AbstractValidator<ProgrammationAModifierDto>
    {
        public readonly IPointDaccess _pointDaccess;
        public ValidateurDeLaModificationDeProgrammationDto(IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;

            RuleFor(mat => mat.Id).NotNull()
               .NotEmpty()
               .WithMessage("Id doit pas etre null");

            Include(new ValidateurDeDtoDeProgrammation(_pointDaccess));
        }
    }
}
