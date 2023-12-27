using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.BehavioursPipe
{
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;
        private readonly Stopwatch _timer;
        private readonly IHostingEnvironment _env;

        public PerformanceBehaviour(ILogger<TRequest> logger, IHostingEnvironment env)
        {
            _logger = logger;
            _timer = new Stopwatch();
            _env = env;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Performance (3. for Command) (4. for Query)");
            _timer.Start();
            var response = await next();
            _timer.Stop();
            var elapsedMilliseconds = _timer.ElapsedMilliseconds;
            if (elapsedMilliseconds <= 500) return response;
            var requestName = typeof(TRequest).Name;
            //var userId=_currentUserService

            CreateLog(request, elapsedMilliseconds, requestName);

            return response;
        }

        private void CreateLog(TRequest request, long elapsedMilliseconds, string requestName)
        {
            string wwwPath = _env.WebRootPath + "\\Logs\\";
            string FileUrl = _env.WebRootPath + "\\Logs\\Logs.txt";
            FileStream fileStream = new FileStream(FileUrl, FileMode.Open);
            string line;
            using (StreamReader reader = new StreamReader(fileStream))
            {
                line = reader.ReadToEnd();
            }

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(wwwPath, "Logs.txt")))
            {
                outputFile.WriteLine(line + "\n" + (
           "CleanArchitecture Log Running Request:{Name}({ElapsedMiliseconds} miliseconds) {@UserId} {@Time}\n",
            requestName, elapsedMilliseconds, request, DateTime.Now) + "\n".ToString());
            }
        }
    }
}
