using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class IdGenerator
    {
        public static string GenerateCacheKeyFromRequest(HttpRequest Request)
        {
            var keyBuilder = new StringBuilder();
            keyBuilder.Append($"{Request.Path}");//save path
            foreach (var (key,value) in Request.Query.OrderBy(x=>x.Key))
            {
                keyBuilder.Append($"{key}-{value}");//saveQuery
            }
            return keyBuilder.ToString();
        }
    }
}
