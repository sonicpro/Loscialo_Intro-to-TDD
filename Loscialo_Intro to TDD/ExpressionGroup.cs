namespace Loscialo_Intro_to_TDD
{
    public class ExpressionGroup
    {
        public IBooleanExpression Source { get; set; }

        public IBooleanExpression Target { get; set; }

        public Operator Operator { get; set; }

        public bool Evaluate()
        {
            return Source.Evaluate() && Target.Evaluate();
        }
    }
}
