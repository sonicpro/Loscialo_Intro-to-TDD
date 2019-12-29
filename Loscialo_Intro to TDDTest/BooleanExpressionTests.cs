using Loscialo_Intro_to_TDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Loscialo_Intro_to_TDDTest
{
    [TestClass]
    public class BooleanExpressionTests
    {
        [TestMethod]
        public void OneEqualsOne()
        {
            var be = new BooleanExpression<int>
            {
                Source = 1,
                Target = 1,
                Operator = Operator.Equals
            };

            Assert.IsTrue(be.Evaluate());
        }

        [TestMethod]
        public void OneDoesNotEqualTwo()
        {
            var be = new BooleanExpression<int>
            {
                Source = 1,
                Target = 2,
                Operator = Operator.Equals
            };

            Assert.IsFalse(be.Evaluate());
        }

        [TestMethod]
        public void OneIsNotLessThanOne()
        {
            var be = new BooleanExpression<int>
            {
                Source = 1,
                Target = 1,
                Operator = Operator.LessThan
            };

            Assert.IsFalse(be.Evaluate());
        }

        [TestMethod]
        public void OneIsLessThanTwo()
        {
            var be = new BooleanExpression<int>
            {
                Source = 1,
                Target = 2,
                Operator = Operator.LessThan
            };

            Assert.IsTrue(be.Evaluate());
        }

        [TestMethod]
        public void TwoIsNotLessThanOne()
        {
            var be = new BooleanExpression<int>
            {
                Source = 2,
                Target = 1,
                Operator = Operator.LessThan
            };

            Assert.IsFalse(be.Evaluate());
        }

        [TestMethod]
        public void OneIsNotGreaterThanOne()
        {
            var be = new BooleanExpression<int>
            {
                Source = 1,
                Target = 1,
                Operator = Operator.GreaterThan
            };

            Assert.IsFalse(be.Evaluate());
        }

        [TestMethod]
        public void TwoIsGreaterThanOne()
        {
            var be = new BooleanExpression<int>
            {
                Source = 2,
                Target = 1,
                Operator = Operator.GreaterThan
            };

            Assert.IsTrue(be.Evaluate());
        }

        [TestMethod]
        public void OneIsNotGreaterThanTwo()
        {
            var be = new BooleanExpression<int>
            {
                Source = 1,
                Target = 2,
                Operator = Operator.GreaterThan
            };

            Assert.IsFalse(be.Evaluate());
        }

        [TestMethod]
        public void DoubleEqualsSameValue()
        {
            var be = new BooleanExpression<double>
            {
                Source = 1.701,
                Target = 1.701,
                Operator = Operator.Equals
            };

            Assert.IsTrue(be.Evaluate());
        }
    }
}
