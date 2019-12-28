namespace Loscialo_Intro_to_TDD
{
    public class BooleanExpression
    {
        public int Source { get; set; }

        public int Target { get; set; }

        public string Operator { get; set; }

        public bool Evaluate()
        {
            if (Operator == "Equals")
            {
                return Source == Target;
            }
            return false;
        }
    }
}
