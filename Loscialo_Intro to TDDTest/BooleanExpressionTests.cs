using Loscialo_Intro_to_TDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Loscialo_Intro_to_TDDTest
{
    [TestClass]
    public class BooleanExpressionTests
    {
        private IBooleanExpression trueExpression1;
        private IBooleanExpression trueExpression2;
        private IBooleanExpression trueExpression3;
        private IBooleanExpression falseExpression1;
        private IBooleanExpression falseExpression2;
        private IBooleanExpression falseExpression3;

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

            trueExpression3 = new BooleanExpression<int>
            {
                Source = 1,
                Target = 1,
                Operator = Operator.Equals
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

            falseExpression3 = new BooleanExpression<int>
            {
                Source = 1,
                Target = 2,
                Operator = Operator.Equals
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
                Operator = LogicOperator.And
            };

            grouping.AddClause(trueExpression1);
            grouping.AddClause(trueExpression2);

            Assert.IsTrue(trueExpression1.Evaluate());
            Assert.IsTrue(trueExpression2.Evaluate());
            Assert.IsTrue(grouping.Evaluate());
        }

        [TestMethod]
        public void TrueAndFalseIsFalse()
        {
            var grouping = new ExpressionGroup
            {
                Operator = LogicOperator.And
            };

            grouping.AddClause(trueExpression1);
            grouping.AddClause(falseExpression1);

            Assert.IsTrue(trueExpression1.Evaluate());
            Assert.IsFalse(falseExpression1.Evaluate());
            Assert.IsFalse(grouping.Evaluate());
        }

        [TestMethod]
        public void FalseAndTrueIsFalse()
        {
            var grouping = new ExpressionGroup
            {
                Operator = LogicOperator.And
            };

            grouping.AddClause(falseExpression1);
            grouping.AddClause(trueExpression1);

            Assert.IsFalse(falseExpression1.Evaluate());
            Assert.IsTrue(trueExpression1.Evaluate());
            Assert.IsFalse(grouping.Evaluate());
        }

        [TestMethod]
        public void FalseAndFalseIsFalse()
        {
            var grouping = new ExpressionGroup
            {
                Operator = LogicOperator.And
            };

            grouping.AddClause(falseExpression1);
            grouping.AddClause(falseExpression2);

            Assert.IsFalse(falseExpression1.Evaluate());
            Assert.IsFalse(falseExpression2.Evaluate());
            Assert.IsFalse(grouping.Evaluate());
        }

        [TestMethod]
        public void TrueOrTrueIsTrue()
        {
            var grouping = new ExpressionGroup
            {
                Operator = LogicOperator.Or
            };

            grouping.AddClause(trueExpression1);
            grouping.AddClause(trueExpression2);

            Assert.IsTrue(trueExpression1.Evaluate());
            Assert.IsTrue(trueExpression2.Evaluate());
            Assert.IsTrue(grouping.Evaluate());
        }

        [TestMethod]
        public void TrueOrFalseIsTrue()
        {
            var grouping = new ExpressionGroup
            {
                Operator = LogicOperator.Or
            };

            grouping.AddClause(trueExpression1);
            grouping.AddClause(falseExpression1);

            Assert.IsTrue(trueExpression1.Evaluate());
            Assert.IsFalse(falseExpression1.Evaluate());
            Assert.IsTrue(grouping.Evaluate());
        }

        [TestMethod]
        public void FalseOrTrueIsTrue()
        {
            var grouping = new ExpressionGroup
            {
                Operator = LogicOperator.Or
            };

            grouping.AddClause(falseExpression1);
            grouping.AddClause(trueExpression1);

            Assert.IsFalse(falseExpression1.Evaluate());
            Assert.IsTrue(trueExpression1.Evaluate());
            Assert.IsTrue(grouping.Evaluate());
        }

        [TestMethod]
        public void FalseOrFalseIsFalse()
        {
            var grouping = new ExpressionGroup
            {
                Operator = LogicOperator.Or
            };

            grouping.AddClause(falseExpression1);
            grouping.AddClause(falseExpression2);

            Assert.IsFalse(falseExpression1.Evaluate());
            Assert.IsFalse(falseExpression2.Evaluate());
            Assert.IsFalse(grouping.Evaluate());
        }

        [TestMethod]
        public void TrueAndTrueAndTrueIsTrue()
        {
            var grouping = new ExpressionGroup
            {
                Operator = LogicOperator.And
            };

            grouping.AddClause(trueExpression1);
            grouping.AddClause(trueExpression2);
            grouping.AddClause(trueExpression3);

            Assert.IsTrue(trueExpression1.Evaluate());
            Assert.IsTrue(trueExpression2.Evaluate());
            Assert.IsTrue(trueExpression3.Evaluate());
            Assert.IsTrue(grouping.Evaluate());
        }

        [TestMethod]
        public void TrueAndTrueAndFalseIsFalse()
        {
            var grouping = new ExpressionGroup
            {
                Operator = LogicOperator.And
            };

            grouping.AddClause(trueExpression1);
            grouping.AddClause(trueExpression2);
            grouping.AddClause(falseExpression1);

            Assert.IsTrue(trueExpression1.Evaluate());
            Assert.IsTrue(trueExpression2.Evaluate());
            Assert.IsFalse(falseExpression1.Evaluate());
            Assert.IsFalse(grouping.Evaluate());
        }

        [TestMethod]
        public void FalseAndFalseAndFalseIsFalse()
        {
            var grouping = new ExpressionGroup
            {
                Operator = LogicOperator.And
            };

            grouping.AddClause(falseExpression1);
            grouping.AddClause(falseExpression2);
            grouping.AddClause(falseExpression3);

            Assert.IsFalse(falseExpression1.Evaluate());
            Assert.IsFalse(falseExpression2.Evaluate());
            Assert.IsFalse(falseExpression3.Evaluate());
            Assert.IsFalse(grouping.Evaluate());
        }

        [TestMethod]
        public void TrueOrTrueOrTrueIsTrue()
        {
            var grouping = new ExpressionGroup
            {
                Operator = LogicOperator.Or
            };

            grouping.AddClause(trueExpression1);
            grouping.AddClause(trueExpression2);
            grouping.AddClause(trueExpression3);

            Assert.IsTrue(trueExpression1.Evaluate());
            Assert.IsTrue(trueExpression2.Evaluate());
            Assert.IsTrue(trueExpression3.Evaluate());
            Assert.IsTrue(grouping.Evaluate());
        }

        [TestMethod]
        public void FalseOrFalseOrTrueIsTrue()
        {
            var grouping = new ExpressionGroup
            {
                Operator = LogicOperator.Or
            };

            grouping.AddClause(falseExpression1);
            grouping.AddClause(falseExpression2);
            grouping.AddClause(trueExpression1);

            Assert.IsFalse(falseExpression1.Evaluate());
            Assert.IsFalse(falseExpression2.Evaluate());
            Assert.IsTrue(trueExpression1.Evaluate());
            Assert.IsTrue(grouping.Evaluate());
        }

        [TestMethod]
        public void TruthfulCompoundStatementEvaluatesToTrue()
        {
            // Represents something like (A < B) OR (C > D) where either A < B or C > D or both of the statements are truthful.
            var subGroup = new ExpressionGroup()
            {
                Operator = LogicOperator.Or
            };

            subGroup.AddClause(trueExpression1);
            subGroup.AddClause(falseExpression1);

            // Represents something like (<subGroup>) AND (y = z) where both <subGroup> and (y = z) evaluate to true.
            var compound = new ExpressionGroup()
            {
                Operator = LogicOperator.And
            };

            compound.AddClause(subGroup);
            compound.AddClause(trueExpression2);

            Assert.IsTrue(trueExpression1.Evaluate());
            Assert.IsFalse(falseExpression1.Evaluate());
            Assert.IsTrue(subGroup.Evaluate());
            Assert.IsTrue(trueExpression2.Evaluate());

            Assert.IsTrue(compound.Evaluate());
        }

        [TestMethod]
        public void FalseCompoundStatementEvaluatesToFalse()
        {
            // Represents something like (A < B) OR (C > D) where both A < B and C > D evaluate to false.
            var subGroup = new ExpressionGroup()
            {
                Operator = LogicOperator.Or
            };

            subGroup.AddClause(falseExpression2);
            subGroup.AddClause(falseExpression1);

            // Represents something like (<subGroup>) AND (y = z) where <subGroup> evaluates to false and (y = z) evaluates to true.
            var compound = new ExpressionGroup()
            {
                Operator = LogicOperator.And
            };

            compound.AddClause(subGroup);
            compound.AddClause(trueExpression2);

            Assert.IsFalse(falseExpression2.Evaluate());
            Assert.IsFalse(falseExpression1.Evaluate());
            Assert.IsFalse(subGroup.Evaluate());
            Assert.IsTrue(trueExpression2.Evaluate());

            Assert.IsFalse(compound.Evaluate());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "BooleanExpression must throw if it does not contain any clauses.")]
        public void BooleanExpressionMustTrowIfThereAreNoClausesToEvaluate()
        {
            var booleanLogicStatement = new ExpressionGroup()
            {
                Operator = LogicOperator.And
            };
            booleanLogicStatement.Evaluate();
        }
    }
}
