using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Common
{
    public class CommandDto
    {
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Summary { get; set; }
    }
}
