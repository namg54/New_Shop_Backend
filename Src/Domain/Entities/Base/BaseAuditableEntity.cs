using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base
{
    public class BaseAuditableEntity:BaseEntity
    {
        public DateTime Created { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public DateTime? LastModified { get; set;}
        public int? LastModifiedBy { get; set;}
            
    }
}
