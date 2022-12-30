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
    public class RepertoireDeProgrammation : RepertoireGenerique<Programmation>, IRepertoireDeProgrammation
    {
        private readonly GetpsDbContext _context;
        public RepertoireDeProgrammation(GetpsDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
