using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Integral.Tests
{
    [TestClass]
    public class MyIntegralTests
    {
        [TestMethod]
        public void Answer_x_power_2_Simpson()
        {
            //arrange
            double a = 0, b = 1000, n = 1000, answer = 333333333.333333333;
            Integrlar_score TestScore = new Integrlar_score(a,b,n);
            //act
            double score = TestScore.Score(1, true);
            //assert
            Assert.AreEqual(answer, score);
        }

        [TestMethod]
        public void Answer_x_power_2_Rect()
        {
            //arrange
            double a = 0, b = 1000, n = 1000, answer = 333333250;
            Integrlar_score TestScore = new Integrlar_score(a, b, n);
            //act
            double score = TestScore.Score(0, true);
            //assert
            Assert.AreEqual(answer, score);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Count_lower_0()
        {
            double a = 0, b = 1000, n = -1000;
            Integrlar_score TestScore = new Integrlar_score(a, b, n);
            double score = TestScore.Score(0, true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Lower_more_than_upper()
        {
            double a = 1000, b = 0, n = 1000;
            Integrlar_score TestScore = new Integrlar_score(a, b, n);
            double score = TestScore.Score(0, true);
        }
    }
}
