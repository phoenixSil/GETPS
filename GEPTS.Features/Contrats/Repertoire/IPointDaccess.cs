using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPTS.Features.Contrats.Repertoire
{
    public interface IPointDaccess
    {
        IRepertoireDeMatiere RepertoireDeMatiere { get; }
        IRepertoireDeProgrammation RepertoireDeProgrammation { get; }
        public Task Enregistrer();
    }
}
