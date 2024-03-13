
namespace MathOne
{
    public enum TokenType
    {
        None = 0,
        Number = 1,
        Function = 2,
        Plus = 3,
        Minus = 4,
        Multiply = 5,
        Divide = 6,
        LParen = 7,
        RParen = 8,
        Power = 9,
        Modulo = 10,
        Negate = 11,
        Comma = 13
    }

    public class Token
    {
        public TokenType Type;
        public double Value = 0.0;
        public string Name = "";

        public Token(TokenType type)
        {
            this.Type = type;
        }

        public Token(TokenType type, double value)
        {
            this.Type = type;
            this.Value = value;
        }

        public Token(TokenType type, double value, string name)
        {
            this.Type = type;
            this.Value = value;
            this.Name = name;
        }

        public override string ToString()
        {
            return Type + ":" + Value;
        }

    }
}
