using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexSoft.Infrastructure.Entites
{
    public class ArduinoDevice
    {
        [Key]
        public int ArduinoDeviceId { get; set; }
    }
}
