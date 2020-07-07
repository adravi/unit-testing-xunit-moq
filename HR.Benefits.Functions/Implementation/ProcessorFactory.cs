using HR.Benefits.Functions.Interfaces;
using System;

namespace HR.Benefits.Functions.Implementation
{
    public class ProcessorFactory : IProcessorFactory
    {
        public IProcessorHelper GetProcessorHelper(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException(nameof(key), "Key can't be null, empty or whitespace.");

            return key switch
            {
                "alpha" => new AlphaProcessorHelper(),
                "beta" => new BetaProcessorHelper(),
                
                _ => throw new ArgumentOutOfRangeException("Key is not recognized."),
            };
        }
    }
}
