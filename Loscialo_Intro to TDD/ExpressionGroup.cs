using System;
using System.Collections.Generic;
using System.Linq;

namespace Loscialo_Intro_to_TDD
{
    public class ExpressionGroup: IBooleanExpression
    {
        private readonly List<IBooleanExpression> clauses = new List<IBooleanExpression>();

        public LogicOperator Operator { get; set; }

        public void AddClause(IBooleanExpression clause)
        {
            clauses.Add(clause);
        }

        public bool Evaluate()
        {
            if (clauses.Count == 0)
            {
                throw new InvalidOperationException("Boolean expression must contain at least one clause");
            }
            switch (Operator)
            {
                case LogicOperator.And:
                    return clauses.Aggregate(true, (result, current) => result && current.Evaluate());
                case LogicOperator.Or:
                    return clauses.Aggregate(false, (result, current) => result || current.Evaluate());
                default:
                    return false;
            }

        }
    }
}
