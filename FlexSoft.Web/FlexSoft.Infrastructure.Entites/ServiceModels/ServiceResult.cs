using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexSoft.Infrastructure.Entites.ServiceModels
{
    public class ServiceResult
    {
        public ServiceResult()
        {
            Errors = new List<string>();
        }
        public IList<string> Errors { get; }
        public bool Fail => Errors.Any();
    }
}
