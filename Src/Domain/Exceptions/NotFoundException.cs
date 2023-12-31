using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(List<string> messages) : base(messages)
        {
        }
        public NotFoundException(string message) : base(message)
        {
        }
        public NotFoundException() : base("Not Found Anything !...")
        {
            
        }
    }
}
