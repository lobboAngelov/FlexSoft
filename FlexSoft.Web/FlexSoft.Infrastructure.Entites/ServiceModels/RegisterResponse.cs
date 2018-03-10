using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexSoft.Infrastructure.Entites.ServiceModels
{
    public class RegisterResponse
    {
        public bool Sucess { get; set; }
        public RegisterRequest Request { get; set; }
    }
}
