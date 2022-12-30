using GEPTS.Datas.Context;
using GEPTS.Features.Contrats.Repertoire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPTS.Datas.Repertoires
{
    public class PointDaccess: IPointDaccess
    {
        private readonly GetpsDbContext _context;
        private IRepertoireDeMatiere _repertoireDeMatiere;
        private IRepertoireDeProgrammation _repertoireDeProgrammation;
        public PointDaccess(GetpsDbContext context)
        {
            _context = context;
        }

        public async Task Enregistrer()
        {
            await _context.SaveChangesAsync();
        }

        public IRepertoireDeMatiere RepertoireDeMatiere => _repertoireDeMatiere ??= new RepertoireDeMatiere(_context);
        public IRepertoireDeProgrammation RepertoireDeProgrammation => _repertoireDeProgrammation ??= new RepertoireDeProgrammation(_context);
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
