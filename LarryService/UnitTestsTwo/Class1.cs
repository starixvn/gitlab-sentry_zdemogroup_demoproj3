using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestsTwo
{
    public class Class1
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(0, Subtract(2, 2));
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(0, Subtract(1, 2));
        }

        int Subtract(int x, int y)
        {
            return x - y;
        }
    }
}
