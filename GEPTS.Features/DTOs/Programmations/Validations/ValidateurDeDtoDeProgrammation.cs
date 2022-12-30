using FluentValidation;
using GEPTS.Features.Contrats.Repertoire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPTS.Features.DTOs.Programmations.Validations
{
    public class ValidateurDeDtoDeProgrammation : AbstractValidator<IProgrammationDto>
    {
        public readonly IPointDaccess _pointDaccess;
        public ValidateurDeDtoDeProgrammation(IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;

            RuleFor(p => p.MatiereId)
            .NotEmpty()
            .MustAsync(async (id, token) =>
            {
                var matiereliereExists = await _pointDaccess.RepertoireDeMatiere.Exists(id);
                return matiereliereExists;
            })
            .WithMessage($" la Matiere vise nexiste pas dans la base de donnees  ");
        }
    }
}
