using System;
using Xunit;

namespace Facemask.Test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(50)]
        [InlineData(16)]
        [InlineData(8)]
        [InlineData(6)]
        [InlineData(10)]
        [InlineData(12)]
        [InlineData(32)]
        [InlineData(18)]
        public void Test1(int num)
        {
            bool isEven = true;
            isEven = true ? num % 2 == 0 : false;

            Assert.True(isEven);
        }
    }
}
