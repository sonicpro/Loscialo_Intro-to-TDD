using Loscialo_Intro_to_TDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Loscialo_Intro_to_TDDTest
{
    [TestClass]
    public class BooleanExpressionTests
    {
        private IBooleanExpression trueExpression1;
        private IBooleanExpression trueExpression2;
        private IBooleanExpression falseExpression1;
        private IBooleanExpression falseExpression2;

        [TestInitialize]
        public void Setup()
        {
            trueExpression1 = new BooleanExpression<int>
            {
                Source = 1,
                Target = 2,
                Operator = Operator.LessThan
            };

            trueExpression2 = new BooleanExpression<double>
            {
                Source = 1.701,
                Target = 1.138,
                Operator = Operator.GreaterThan
            };

            falseExpression1 = new BooleanExpression<int>
            {
                Source = 1,
                Target = 2,
                Operator = Operator.GreaterThan
            };

            falseExpression2 = new BooleanExpression<double>
            {
                Source = 1.701,
                Target = 1.138,
                Operator = Operator.LessThan
            };
        }

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

        [TestMethod]
        public void DoubleIsLessThanBiggerDouble()
        {
            var be = new BooleanExpression<double>
            {
                Source = 1.701,
                Target = 2.240,
                Operator = Operator.LessThan
            };

            Assert.IsTrue(be.Evaluate());
        }

        [TestMethod]
        public void DoubleIsGreaterThanSmallerDouble()
        {
            var be = new BooleanExpression<double>
            {
                Source = 2.240,
                Target = 1.701,
                Operator = Operator.GreaterThan
            };

            Assert.IsTrue(be.Evaluate());
        }

        [TestMethod]
        public void TrueAndTrueIsTrue()
        {
            var grouping = new ExpressionGroup
            {
                Source = trueExpression1,
                Target = trueExpression2,
                Operator = Operator.And
            };

            Assert.IsTrue(trueExpression1.Evaluate());
            Assert.IsTrue(trueExpression2.Evaluate());
            Assert.IsTrue(grouping.Evaluate());
        }

        [TestMethod]
        public void TrueAndFalseIsFalse()
        {
            var grouping = new ExpressionGroup
            {
                Source = trueExpression1,
                Target = falseExpression1,
                Operator = Operator.And
            };

            Assert.IsTrue(trueExpression1.Evaluate());
            Assert.IsFalse(falseExpression1.Evaluate());
            Assert.IsFalse(grouping.Evaluate());
        }

        [TestMethod]
        public void FalseAndTrueIsFalse()
        {
            var grouping = new ExpressionGroup
            {
                Source = falseExpression1,
                Target = trueExpression1,
                Operator = Operator.And
            };

            Assert.IsFalse(falseExpression1.Evaluate());
            Assert.IsTrue(trueExpression1.Evaluate());
            Assert.IsFalse(grouping.Evaluate());
        }

        [TestMethod]
        public void FalseAndFalseIsFalse()
        {
            var grouping = new ExpressionGroup
            {
                Source = falseExpression1,
                Target = falseExpression2,
                Operator = Operator.And
            };

            Assert.IsFalse(falseExpression1.Evaluate());
            Assert.IsFalse(falseExpression2.Evaluate());
            Assert.IsFalse(grouping.Evaluate());
        }
    }
}
