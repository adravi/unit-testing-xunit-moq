using HR.Benefits.Functions.Implementation;
using HR.Benefits.Functions.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace HR.Benefits.Functions.Tests
{
    [Trait("ProcessorFunction", "ProcessorFunction Unit Tests")]
    public class ProcessorFunctionShould
    {        
        private readonly Mock<IProcessorFactory> _processorFactory;
        private readonly Mock<ILogger> _logger;

        public ProcessorFunctionShould()
        {
            _processorFactory = new Mock<IProcessorFactory>();
            _logger = new Mock<ILogger>();
        }

        [Fact]
        public void ThrowArgumentNullException_IfInjectedDependenciesAreNull()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => new ProcessorFunction(null));
        }
        
        [Fact]
        public void CallProcessorHelperProcess()
        {
            // Arrange            
            var processorHelper = new Mock<AlphaProcessorHelper>();
            processorHelper.Setup(m => m.Process()).Verifiable();
            _processorFactory.Setup(m => m.GetProcessorHelper("alpha")).Returns(processorHelper.Object);

            var processorFunction = new ProcessorFunction(_processorFactory.Object);

            // Act
            processorFunction.Run(null, _logger.Object);

            // Assert
            processorHelper.Verify(m => m.Process(), Times.Once);
        }
    }
}
