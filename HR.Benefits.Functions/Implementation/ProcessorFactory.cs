using HR.Benefits.Functions.Interfaces;

namespace HR.Benefits.Functions.Implementation
{
    public class ProcessorFactory : IProcessorFactory
    {
        public IProcessorHelper GetProcessorHelper(string key)
        {
            throw new System.NotImplementedException();
        }
    }
}
