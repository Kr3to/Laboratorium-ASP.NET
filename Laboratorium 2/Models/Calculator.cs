namespace Laboratorium_2.Models
{
    public class Calculator
    {
        public double? A { get; set; }
        public double? B { get; set; }
        public Operators? Op { get; set; }

        public bool IsValid()
        {
            return A != null && B != null && Op != null;
        }

        public double Calculate()
        {
            switch (Op)
            {
                case Operators.ADD:
                    return (double)(A + B);
                case Operators.SUB:
                    return (double)(A - B);
                case Operators.MUL:
                    return (double)(A * B);
                case Operators.DIV:
                    return (double)(A / B);
                default: return double.NaN;
            }
        }

        public string Sign()
        {
            switch (Op)
            {
                case Operators.ADD:
                    return "+";
                case Operators.SUB:
                    return "-";
                case Operators.MUL:
                    return "*";
                case Operators.DIV:
                    return "/";
                default: return "";
            }
        }
    }
}
