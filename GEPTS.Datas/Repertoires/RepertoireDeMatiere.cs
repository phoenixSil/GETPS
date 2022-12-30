using GEPTS.Datas.Context;
using GEPTS.Features.Contrats.Repertoire;
using GETPS.Domain.Modeles;
using Microsoft.EntityFrameworkCore;
using MsCommun.Repertoires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPTS.Datas.Repertoires
{
    public class RepertoireDeMatiere : RepertoireGenerique<Matiere>, IRepertoireDeMatiere
    {
        private readonly GetpsDbContext _context;
        public RepertoireDeMatiere(GetpsDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
