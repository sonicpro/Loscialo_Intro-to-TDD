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
            var be = new BooleanExpression();
            be.Source = 1;
            be.Target = 1;
            be.Operator = "Equals";

            Assert.IsTrue(be.Evaluate());
        }

        [TestMethod]
        public void OneDoesNotEqualTwo()
        {
            var be = new BooleanExpression();
            be.Source = 1;
            be.Target = 2;
            be.Operator = "Equals";

            Assert.IsFalse(be.Evaluate());
        }

        [TestMethod]
        public void OneIsNotLessThanOne()
        {
            var be = new BooleanExpression();
            be.Source = 1;
            be.Target = 1;
            be.Operator = "Less Than";

            Assert.IsFalse(be.Evaluate());
        }
    }
}
