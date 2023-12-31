using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers
{
    public abstract class ReequestParametersBasic:PaginationParametersDto
    {
        private string _Search { get; set; }
        public string search { get => _Search; set =>_Search=value?.ToLower(); }
        public TypeSort TypeSort { get; set; } = TypeSort.Desc;
        public int Sort { get; set; } = 1;
    }

    public enum TypeSort
    {
        Desc=1,
        Asc
    }
}
