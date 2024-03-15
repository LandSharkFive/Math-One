using System.Text;

namespace MathOne
{
    public class Util
    {
        private static Random rnd = new Random();

        private int Index = 0;
        private List<Token> Tokens = new List<Token>();
        private List<string> OpList;
        private Token Current;

        public Util()
        {
            OpList = GetOpList();
        }

        public double Eval(string a)
        {
            if (String.IsNullOrEmpty(a))
            {
                return 0;
            }

            var list = GetTokenList(a);
            var node = Parse(list);
            if (node == null)
            {
                return 0;

            }
            return node.Visit();
        }

        public List<string> Tokenize(string a)
        {
            var strDelimit = "()+-*/%^,@";
            var delimiters = strDelimit.ToCharArray();
            var buffer = string.Empty;
            var result = new List<string>();
            string b = RemoveWhiteSpace(a).ToUpper();

            foreach (var ch in b)
            {
                if (delimiters.Contains(ch))
                {
                    if (buffer.Length > 0)
                    {
                        result.Add(buffer);
                    }
                    result.Add(ch.ToString());
                    buffer = string.Empty;
                }
                else
                {
                    buffer += ch;
                }
            }

            if (buffer.Length > 0)
            {
                result.Add(buffer);
            }

            return result;
        }


        public bool IsNumber(string a)
        {
            if (Double.TryParse(a, out double b))
            {
                return true;
            }

            return false;
        }

        public double GetNumber(string a)
        {
            if (Double.TryParse(a, out double b))
            {
                return b;
            }

            return 0.0;
        }


        public bool IsOperator(string op)
        {
            return OpList.Contains(op);
        }

        // Get Operator List

        List<string> GetOpList()
        {
            List<string> list = new List<string>();

            string str = "A ACOS ASIN ATAN ALG ALN CB CDF COS CL CR DEG EN F";
            list.AddRange(str.Split(" ").ToList());

            str = "FAC FL GAU GCF I LCM LG LN MIN MAX NCR ND NPR P2 PD PHI PI R RAD RAN";
            list.AddRange(str.Split(" ").ToList());

            str = "RD RND RT S SIN SQ SR STU TAN TAU X2 X3";
            list.AddRange(str.Split(" ").ToList());

            return list;
        }

        public string RemoveWhiteSpace(string str)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var ch in str)
            {
                if (!char.IsWhiteSpace(ch))
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString();
        }

        public double FuncEval(string name, double[] arg)
        {
            double result = 0;
            double x, y;

            switch (name)
            {
                case "A":
                    result = Math.Abs(arg[0]);
                    break;
                case "ACOS":
                    result = Math.Acos(arg[0]);
                    break;
                case "ASIN":
                    result = Math.Asin(arg[0]);
                    break;
                case "ATAN":
                    result = Math.Atan(arg[0]);
                    break;
                case "ALG":
                    result = Math.Pow(10, arg[0]);
                    break;
                case "ALN":
                    result = Math.Exp(arg[0]);
                    break;
                case "CB":
                    x = arg[0];
                    result = x * x * x;
                    break;
                case "CDF":
                    result = CumDensity(arg[0]);
                    break;
                case "COS":
                    result = Math.Cos(arg[0]);
                    break;
                case "CL":
                    result = Math.Ceiling(arg[0]);
                    break;
                case "CR":
                    result = Math.Cbrt(arg[0]);
                    break;
                case "DEG":
                    result = Degrees(arg[0]);
                    break;
                case "EN":
                    result = Math.E;
                    break;
                case "F":
                    x = arg[0];
                    result = x - Math.Truncate(x);
                    break;
                case "FAC":
                    result = Factorial(arg[0]);
                    break;
                case "FL":
                    result = Math.Floor(arg[0]);
                    break;
                case "GAU":
                    result = Gauss(arg[0]);
                    break;
                case "GCF":
                    result = GCF(arg[0], arg[1]);
                    break;
                case "I":
                    result = Math.Truncate(arg[0]);
                    break;
                case "LCM":
                    result = LCM(arg[0], arg[1]);
                    break;
                case "LG":
                    result = Math.Log10(arg[0]);
                    break;
                case "LN":
                    result = Math.Log(arg[0]);
                    break;
                case "MAX":
                    result = Math.Max(arg[0], arg[1]);
                    break;
                case "MIN":
                    result = Math.Min(arg[0], arg[1]);
                    break;
                case "NCR":
                    result = Combinations(arg[0], arg[1]); ;
                    break;
                case "ND":
                    result = Normal(arg[0], arg[1], arg[2]);
                    break;
                case "NPR":
                    result = Permutations(arg[0], arg[1]);
                    break;
                case "P2":
                    result = Math.Pow(2, arg[0]);
                    break;
                case "PD":
                    result = PrimeDivisor(arg[0]);
                    break;
                case "PHI":
                    result = Phi(arg[0]);
                    break;
                case "PI":
                    result = Math.PI;
                    break;
                case "R":
                    result = Reciprocal(arg[0]);
                    break;
                case "RAD":
                    result = Radians(arg[0]);
                    break;
                case "RAN":
                    result = rnd.Next();
                    break;
                case "RD":
                    result = Math.Round(arg[0]);
                    break;
                case "RND":
                    result = rnd.NextDouble();
                    break;
                case "RT":
                    result = Root(arg[0], arg[1]);
                    break;
                case "S":
                    x = arg[0];
                    result = -x;
                    break;
                case "SIN":
                    result = Math.Sin(arg[0]);
                    break;
                case "SQ":
                    x = arg[0];
                    result = x * x;
                    break;
                case "SR":
                    result = Math.Sqrt(arg[0]);
                    break;
                case "STU":
                    result = Student(arg[0], arg[1]);
                    break;
                case "TAN":
                    result = Math.Tan(arg[0]);
                    break;
                case "TAU":
                    result = Math.Tau;
                    break;
                case "X2":
                    x = arg[0];
                    result = x * x;
                    break;
                case "X3":
                    x = arg[0];
                    result = x * x * x;
                    break;
                default:
                    throw new Exception("Unknown function: " + name);
            }

            return result;
        }


        private double Reciprocal(double a)
        {
            if (a == 0)
            {
                throw new ArgumentException("Divide by zero");
            }
            return 1 / a;
        }

        private double Root(double a, double b)
        {
            if (b == 0)
            {
                throw new Exception("Divide by zero");
            }
            return Math.Pow(a, 1 / b);
        }

        private static double Radians(double degrees)
        {
            return Math.PI * degrees / 180.0;
        }

        private static double Degrees(double radians)
        {
            return 180.0 * radians / Math.PI;
        }

        // Clamp.
        // Return Int32.
        private static int Clamp(double x)
        {
            if (Int32.MinValue < x && x < Int32.MaxValue)
            {
                return Convert.ToInt32(x);
            }

            return 0;
        }

        public double Factorial(double value)
        {
            return FactorialInner(Clamp(value));
        }

        public double FactorialInner(int value)
        {
            if (value <= 1)
            {
                return 1.0;
            }
            if (value > 170)
            {
                return 0.0;
            }

            double result = 1.0;
            for (int i = 1; i <= value; i++)
            {
                result *= i;
            }

            return result;
        }

        private static int GCF(double a, double b)
        {
            return GCFInner(Clamp(a), Clamp(b));
        }

        private static int LCM(double a, double b)
        {
            return LCMInner(Clamp(a), Clamp(b));
        }


        // GCF - Greatest Common Factor.
        private static int GCFInner(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        // LCM - Least Common Multiple.
        private static int LCMInner(int a, int b)
        {
            return (a / GCF(a, b)) * b;
        }

        private int PrimeDivisor(double a)
        {
            return PrimeDivisorInner(Clamp(a));
        }

        // Prime Divisor Inner.
        // If prime, return 0.
        private int PrimeDivisorInner(int n)
        {
            // By definition, zero and one are not prime numbers.
            if (n < 2)
            {
                return 0;
            }

            int max = (int)Math.Sqrt(n);
            for (int i = 2; i <= max; i++)
            {
                if (n % i == 0)
                {
                    return i;
                }
            }

            return 0;
        }


        private double Combinations(double n, double r)
        {
            return CombinationInner(Clamp(n), Clamp(r));
        }

        /// <summary>
        /// Combinations
        /// </summary>
        /// <param name="n">total</param>
        /// <param name="r">selected</param>
        /// <returns></returns>
        private double CombinationInner(int n, int r)
        {
            if (n < 1 || r < 1 || n > 170 || r > 170 || n < r)
            {
                return 0;
            }

            return Factorial(n) / (Factorial(r) * Factorial(n - r));
        }

        private double Permutations(double n, double r)
        {
            return PermutationInner(Clamp(n), Clamp(r));
        }

        /// <summary>
        /// Permutations
        /// </summary>
        /// <param name="n">total</param>
        /// <param name="r">selected</param>
        /// <returns></returns>
        private double PermutationInner(int n, int r)
        {
            if (n < 1 || r < 1 || n > 170 || r > 170 || n < r)
            {
                return 0;
            }

            return Factorial(n) / Factorial(n - r);
        }

        /// <summary>
        /// CDF - Cumulative Density Function for the Standard Normal Distribution.
        /// </summary>
        /// <param name="z">z-score</param>
        /// <returns>cumulative probability density</returns>
        // Output is always between zero and one.  Z-Score is generally between -4.0 and 4.0.
        // When z is above 4.0, cdf is one. When z is below -4.0, cdf is zero.  
        public static double CumDensity(double z)
        {
            double p = 0.3275911;
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;

            int sign = 1;
            if (z < 0.0)
            {
                sign = -1;
            }

            double x = Math.Abs(z) / Math.Sqrt(2.0);
            double t = 1.0 / (1.0 + p * x);
            double erf = 1.0 - (((((a5 * t + a4) * t) + a3)
              * t + a2) * t + a1) * t * Math.Exp(-x * x);
            return 0.5 * (1.0 + sign * erf);
        } // CumDensity()


        /// <summary>
        /// Student's T-Distribution
        /// </summary>
        /// <param name="t">t-score</param>
        /// <param name="df">degrees of freedom</param>
        /// <returns>2-tail probability</returns>

        private static double Student(double t, double df)
        {
            // For large int df or double df.

            // Adapted from ACM algorithm 395
            // Returns 2-tail probability.
            // For 1-tail probability, divide by two.

            double n = df; // to sync with ACM parameter name
            double a, b, y;

            t = t * t;
            y = t / n;
            b = y + 1.0;
            if (y > 1.0E-6)
            {
                y = Math.Log(b);
            }
            a = n - 0.5;
            b = 48.0 * a * a;
            y = a * y;

            y = (((((-0.4 * y - 3.3) * y - 24.0) * y - 85.5) /
              (0.8 * y * y + 100.0 + b) +
                y + 3.0) / b + 1.0) * Math.Sqrt(y);

            return 2.0 * Gauss(-y);
        } // Student

        /// <summary>
        /// Gaussian Probability Density Function
        /// </summary>
        /// <param name="z">z-score</param>
        /// <returns>probability density</returns>
        public static double Gauss(double z)
        {
            // input = z-value (-inf to +inf)
            // output = p under Normal curve from -inf to z
            // e.g., if z = 0.0, function returns 0.5000
            // ACM Algorithm #209
            double y; // 209 scratch variable
            double p; // result. called 'z' in 209
            double w; // 209 scratch variable

            if (z == 0.0)
            {
                p = 0.0;
            }
            else
            {
                y = Math.Abs(z) / 2;
                if (y >= 3.0)
                {
                    p = 1.0;
                }
                else if (y < 1.0)
                {
                    w = y * y;
                    p = ((((((((0.000124818987 * w
                      - 0.001075204047) * w + 0.005198775019) * w
                      - 0.019198292004) * w + 0.059054035642) * w
                      - 0.151968751364) * w + 0.319152932694) * w
                      - 0.531923007300) * w + 0.797884560593) * y * 2.0;
                }
                else
                {
                    y = y - 2.0;
                    p = (((((((((((((-0.000045255659 * y
                      + 0.000152529290) * y - 0.000019538132) * y
                      - 0.000676904986) * y + 0.001390604284) * y
                      - 0.000794620820) * y - 0.002034254874) * y
                      + 0.006549791214) * y - 0.010557625006) * y
                      + 0.011630447319) * y - 0.009279453341) * y
                      + 0.005353579108) * y - 0.002141268741) * y
                      + 0.000535310849) * y + 0.999936657524;
                }
            }

            if (z > 0.0)
            {
                return (p + 1.0) / 2;
            }
            else
            {
                return (1.0 - p) / 2;
            }
        } // Gauss()

        // Phi is the Cumulative Probability Density Function for a random variable.
        // John D. Cook
        public static double Phi(double x)
        {
            const double a1 = 0.254829592;
            const double a2 = -0.284496736;
            const double a3 = 1.421413741;
            const double a4 = -1.453152027;
            const double a5 = 1.061405429;
            const double p = 0.3275911;

            // Save the sign of x
            int sign = 1;
            if (x < 0)
            {
                sign = -1;
            }

            x = Math.Abs(x) / Math.Sqrt(2.0);

            // A&S formula 7.1.26
            double t = 1.0 / (1.0 + 0.3275911 * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);
            return 0.5 * (1.0 + sign * y);
        }


        /// <summary>
        /// Normal Distribution (pdf)
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="mean">mean</param>
        /// <param name="std">standard deviation</param>
        /// <returns>probability</returns>
        private static double Normal(double x, double mean, double std)
        {
            double tmp = 1 / ((Math.Sqrt(2 * Math.PI) * std));
            return tmp * Math.Exp(-0.5 * Math.Pow((x - mean) / std, 2));
        }

        public List<Token> GetTokenList(string str)
        {
            List<Token> tokens = new List<Token>();

            var list = Tokenize(str);
            foreach (var item in list)
            {
                tokens.Add(GetToken(item));
            }

            return tokens;
        }

        public Token GetToken(string str)
        {
            if (IsNumber(str))
            {
                double value = GetNumber(str);
                return new Token(TokenType.Number, value);
            }
            else if (IsOperator(str))
            {
                return new Token(TokenType.Function, 0, str);
            }
            else if (str == "+")
                return new Token(TokenType.Plus);
            else if (str == "-")
                return new Token(TokenType.Minus);
            else if (str == "*")
                return new Token(TokenType.Multiply);
            else if (str == "/")
                return new Token(TokenType.Divide);
            else if (str == "(")
                return new Token(TokenType.LParen);
            else if (str == ")")
                return new Token(TokenType.RParen);
            else if (str == "^")
                return new Token(TokenType.Power);
            else if (str == "%")
                return new Token(TokenType.Modulo);
            else if (str == "@")
                return new Token(TokenType.Negate);
            else if (str == ",")
                return new Token(TokenType.Comma);

            throw new Exception("Token not found: " + str);
        }

        public Node Parse(List<Token> list)
        {
            Index = 0;
            Tokens = list;
            GetNext();

            if (Current.Type == TokenType.None)
            {
                return null;
            }

            var result = Expression();

            if (Current.Type != TokenType.None)
            {
                throw new Exception("Syntax error");
            }

            return result;
        }

        void GetNext()
        {
            if (Index < Tokens.Count)
            {
                Current = Tokens[Index];
                ++Index;
                return;
            }
            else
            {
                Current = new Token(TokenType.None);
            }
        }

        Node Expression()
        {
            var result = Term();
            while (Current.Type != TokenType.None && (Current.Type == TokenType.Plus || Current.Type == TokenType.Minus))
            {
                if (Current.Type == TokenType.Plus)
                {
                    GetNext();
                    result = new AddNode(result, Term());
                }
                if (Current.Type == TokenType.Minus)
                {
                    GetNext();
                    result = new SubtractNode(result, Term());
                }
            }

            return result;
        }

        Node Term()
        {
            var result = Power();
            while (Current.Type != TokenType.None && (Current.Type == TokenType.Multiply || Current.Type == TokenType.Divide))
            {
                if (Current.Type == TokenType.Multiply)
                {
                    GetNext();
                    result = new MultiplyNode(result, Power());
                }
                if (Current.Type == TokenType.Divide)
                {
                    GetNext();
                    result = new DivideNode(result, Power());
                }
            }

            return result;
        }

        Node Power()
        {
            var result = Factor();
            while (Current.Type != TokenType.None && (Current.Type == TokenType.Power || Current.Type == TokenType.Modulo))
            {
                if (Current.Type == TokenType.Power)
                {
                    GetNext();
                    result = new PowerNode(result, Factor());
                }
                if (Current.Type == TokenType.Modulo)
                {
                    GetNext();
                    result = new ReduceNode(result, Factor());
                }
            }

            return result;
        }

        Node Factor()
        {
            var myToken = Current;

            if (Current.Type == TokenType.LParen)
            {
                GetNext();
                var result = Expression();
                if (Current.Type != TokenType.RParen)
                {
                    throw new Exception("Syntax error");
                }

                GetNext();
                return result;
            }
            else if (Current.Type == TokenType.Number)
            {
                GetNext();
                return new NodeNumber(myToken.Value);
            }
            else if (Current.Type == TokenType.Plus)
            {
                GetNext();
                return new PlusNode(Factor());
            }
            else if (Current.Type == TokenType.Minus)
            {
                GetNext();
                return new MinusNode(Factor());
            }
            else if (Current.Type == TokenType.Negate)
            {
                GetNext();
                return new MinusNode(Factor());
            }
            else if (Current.Type == TokenType.Function)
            {
                return Function(Current.Name);
            }

            throw new Exception("Syntax error");
        }

        Node Function(string name)
        {
            var result = new FuncNode(name);
            GetNext();
            if (Current.Type == TokenType.LParen)
            {
                GetNext();
            }
            ArgList(result);
            if (Current.Type == TokenType.RParen)
            {
                GetNext();
            }

            return result;
        }

        void ArgList(FuncNode node)
        {
            while (Current.Type != TokenType.RParen)
            {
                node.Nodes.Add(Expression());
                while (Current.Type == TokenType.Comma)
                {
                    GetNext();
                }
            }
        }

    }
}
