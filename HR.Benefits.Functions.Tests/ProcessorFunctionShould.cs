using HR.Benefits.Functions.Interfaces;
using Moq;
using System;
using Xunit;

namespace HR.Benefits.Functions.Tests
{
    [Trait("ProcessorFunction", "ProcessorFunction Unit Tests")]
    public class ProcessorFunctionShould
    {        
        private readonly Mock<IProcessorFactory> _processorFactory;

        public ProcessorFunctionShould()
        {
            _processorFactory = new Mock<IProcessorFactory>();
        }

        [Fact]
        public void ThrowArgumentNullException_IfInjectedDependenciesAreNull()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => new ProcessorFunction(null));
        }
    }
}
