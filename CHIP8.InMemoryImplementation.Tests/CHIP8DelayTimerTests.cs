using System;
using Xunit;

namespace CHIP8.InMemoryImplementation.Tests
{
    public class CHIP8DelayTimerTests
    {
        [Fact]
        public void SetTimer_ShouldSetValueCorrectly()
        {
            CHIP8DelayTimer timer = new CHIP8DelayTimer();
            Byte valueBefore = timer.GetValue();
            Byte expectedValue = 1;

            timer.SetTimer(expectedValue);
            Byte valueAfter = timer.GetValue();

            Assert.NotEqual(valueBefore, valueAfter);
            Assert.True(valueAfter == expectedValue, 
                $"{nameof(valueAfter)} was expected to be {expectedValue}; but its value is {valueAfter}.");
        }

        [Fact]
        public void CreatingNewTimer_ShouldSetValueToZero()
        {
            CHIP8DelayTimer timer = new CHIP8DelayTimer();
            Byte expectedValue = 0;

            Byte actualValue = timer.GetValue();

            Assert.True(expectedValue == actualValue,
                $"{nameof(actualValue)} was expected to be {expectedValue}; but its value is {actualValue}.");
        }

        [Fact]
        public void DecrementTimer_ShouldNotDecrementValue_WhenValueIsAlreadyZero()
        {
            CHIP8DelayTimer timer = new CHIP8DelayTimer();
            timer.SetTimer(0);
            Byte expectedValue = 0;

            timer.DecrementTimer();
            Byte actualValue = timer.GetValue();

            Assert.True(expectedValue == actualValue,
                $"{nameof(actualValue)} was expected to be {expectedValue}; but its value is {actualValue}.");
        }
    
        [Fact]
        public void DecrementTimer_ShouldDecrementValue_WhenValueIsNotZero()
        {
            CHIP8DelayTimer timer = new CHIP8DelayTimer();
            timer.SetTimer(12);
            Byte expectedValue = 11;

            timer.DecrementTimer();
            Byte actualValue = timer.GetValue();

            Assert.True(expectedValue == actualValue,
                $"{nameof(actualValue)} was expected to be {expectedValue}; but its value is {actualValue}.");
        }
    
        [Fact]
        public void GetValue_ShouldReturnCorrectValue()
        {
            CHIP8DelayTimer timer = new CHIP8DelayTimer();
            Byte firstExpectedValue = 0;
            Byte secondExpectedValue = 34;            
            
            Byte firstActualValue = timer.GetValue();
            timer.SetTimer(34);
            Byte secondActualValue = timer.GetValue();

            Assert.True(firstExpectedValue == firstActualValue,
                $"{nameof(firstActualValue)} was expected to be {firstExpectedValue}; but it value is {firstActualValue}.");
            Assert.True(secondExpectedValue == secondActualValue,
                $"{nameof(secondActualValue)} was expected to be {secondActualValue}; but it value is {secondActualValue}.");
        }
    }
}
