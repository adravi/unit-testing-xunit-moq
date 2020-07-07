using HR.Benefits.Functions.Implementation;
using System;
using Xunit;

namespace HR.Benefits.Functions.Tests.Implementation
{
    [Trait("ProcessorFactory", "ProcessorFactory Unit Tests")]
    public class ProcessorFactoryShould
    {
        private readonly ProcessorFactory _processorFactory;

        public ProcessorFactoryShould()
        {
            _processorFactory = new ProcessorFactory();
        }

        [Fact]
        public void ThrowArgumentNullException_IfKeyIsInvalid()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => _processorFactory.GetProcessorHelper(null));
            Assert.Throws<ArgumentException>(() => _processorFactory.GetProcessorHelper(string.Empty));
            Assert.Throws<ArgumentException>(() => _processorFactory.GetProcessorHelper(" "));
        }

        [Fact]
        public void ThrowOutOfRangeException_IfKeyIsNotRecognized()
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _processorFactory.GetProcessorHelper("gamma"));
        }

        [Fact]
        public void GetRightProcessorHelper_BasedOnTheInput()
        {
            // Act
            var alphaProcessorHelper = _processorFactory.GetProcessorHelper("alpha");
            var betaProcessorHelper = _processorFactory.GetProcessorHelper("beta");

            // Assert
            Assert.IsNotType<BetaProcessorHelper>(alphaProcessorHelper);
            Assert.IsNotType<AlphaProcessorHelper>(betaProcessorHelper);
        }

        [Fact]
        public void GetAlphaProcessorHelper_IfKeyIsAlpha()
        {
            // Act
            var processorHelper = _processorFactory.GetProcessorHelper("alpha");

            // Assert
            Assert.IsType<AlphaProcessorHelper>(processorHelper);
        }        

        [Fact]
        public void GetAlphaProcessorHelper_IfKeyIsBeta()
        {
            // Act
            var processorHelper = _processorFactory.GetProcessorHelper("beta");

            // Assert
            Assert.IsType<BetaProcessorHelper>(processorHelper);
        }        
    }
}
