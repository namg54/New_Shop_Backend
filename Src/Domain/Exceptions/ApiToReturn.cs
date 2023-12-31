using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ApiToReturn
    {
        public ApiToReturn()
        {

        }
        public ApiToReturn(string message)
        {
            Message = message;
            Messages.Add(message);
        }
        public ApiToReturn(int statusCode, string message)
        {
            Message = message;
            StatsCode = statusCode;
            Messages.Add(message);

        }
        public ApiToReturn(int statusCode, List<string> messages)
        {
            Messages = messages;
            StatsCode = statusCode;
        }
        public ApiToReturn(int statusCode, string message, string detail)
        {
            Message = message;
            StatsCode = statusCode;
            Detail = detail;
            Messages.Add(message);


        }
        public ApiToReturn(int statusCode, List<string> messages, string detail)
        {
            StatsCode = statusCode;
            Messages = messages;
            Detail = detail;

        }
        public ApiToReturn(int statusCode, string message, List<string> messages, string detail)
        {
            StatsCode = statusCode;
            Messages = messages;
            Detail = detail;
            Message = message;


        }
        public string Message { get; set; }
        public int StatsCode { get; set; }
        public string Detail { get; set; }
        public List<string> Messages { get; set; } = new();
    }
}
