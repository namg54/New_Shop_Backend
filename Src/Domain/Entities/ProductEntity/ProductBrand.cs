using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ProductEntity
{
    public class ProductBrand : BaseAuditableEntity, ICommands
    {
        public string Title { get; set; }


        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDelete { get; set; } = false;
        public string Summary { get; set; }
    }
}
