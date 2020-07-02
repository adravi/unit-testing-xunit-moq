namespace HR.Benefits.Functions.Interfaces
{
    public interface IProcessorFactory
    {
        IProcessorHelper GetProcessorHelper(string key);
    }
}
