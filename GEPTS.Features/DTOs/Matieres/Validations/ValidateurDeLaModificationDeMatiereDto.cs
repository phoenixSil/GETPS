using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPTS.Features.DTOs.Matieres.Validations
{
    public class ValidateurDeLaModificationDeMatiereDto: AbstractValidator<MatiereAModifierDto>
    {
        public ValidateurDeLaModificationDeMatiereDto()
        {
            RuleFor(mat => mat.Id).NotNull()
               .NotEmpty()
               .WithMessage("Id doit pas etre null");

            Include(new ValidateurDeDtoDeMatiere());
        }
    }
}
