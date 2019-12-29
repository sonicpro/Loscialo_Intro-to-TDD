using System.Collections.Generic;

namespace Loscialo_Intro_to_TDD
{
    public class BooleanExpression<T>
    {
        public T Source { get; set; }

        public T Target { get; set; }

        public Operator Operator { get; set; }

        public bool Evaluate()
        {
            var comparisonResult = Comparer<T>.Default.Compare(Source, Target);

            switch(Operator)
            {
                case Operator.Equals:
                   return comparisonResult == 0;
                case Operator.LessThan:
                    return comparisonResult < 0;
                case Operator.GreaterThan:
                    return comparisonResult > 0;
                default:
                    return false;
            }
        }
    }
}
