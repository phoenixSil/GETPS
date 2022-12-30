using GETPS.Features.Core.BaseFactoryClass.Enums;
using MediatR;
using MsCommun.Reponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GETPS.Features.Core.BaseFactoryClass
{
    public abstract class BaseCommand<k> : IRequest<k>
    {
        public TypeDeRequette Operation { get; set; }
    }
}
