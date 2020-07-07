using Microsoft.Azure.WebJobs;
using HR.Benefits.Functions.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace HR.Benefits.Functions
{
    public class ProcessorFunction
    {
        private readonly IProcessorFactory _processorFactory;

        public ProcessorFunction(IProcessorFactory processorFactory)
        {
            _processorFactory = processorFactory ?? throw new ArgumentNullException(nameof(processorFactory));
        }

        [FunctionName(nameof(ProcessorFunction))]
        public void Run([TimerTrigger("0 */5 * * * *", RunOnStartup = true)]TimerInfo myTimer, ILogger logger)
        {
            logger.LogInformation($"{nameof(ProcessorFunction)} is executed!");
            
            var processorHelper = _processorFactory.GetProcessorHelper("alpha");
            
            processorHelper.Process();
        }
    }
}
