
using System.Linq.Expressions;
using System.Security.AccessControl;

namespace MathOne
{

    public abstract class Node
    {
        internal Util util = new Util();

        public virtual double Visit()
        {
            return 0.0;
        }
    }

    public class NodeNumber : Node
    {
        public double Value;

        public NodeNumber(double value)
        {
            Value = value;
        }

        public override double Visit()
        {
            return Value;
        }
    }

    public class AddNode : Node
    {
        public Node Left;
        public Node Right;

        public AddNode(Node left, Node right)
        {
            Left = left;
            Right = right;
        }

        public override double Visit()
        {
            return Left.Visit() + Right.Visit();
        }

    }

    public class SubtractNode : Node
    {
        public Node Left;
        public Node Right;

        public SubtractNode(Node left, Node right)
        {
            Left = left;
            Right = right;
        }

        public override double Visit()
        {
            return Left.Visit() - Right.Visit();
        }

    }

    public class MultiplyNode : Node
    {
        public Node Left;
        public Node Right;

        public MultiplyNode(Node left, Node right)
        {
            Left = left;
            Right = right;
        }

        public override double Visit()
        {
            return Left.Visit() * Right.Visit();
        }

    }

    public class DivideNode : Node
    {
        public Node Left;
        public Node Right;

        public DivideNode(Node left, Node right)
        {
            Left = left;
            Right = right;
        }

        public override double Visit()
        {
            return Left.Visit() / Right.Visit();
        }

    }

    public class PowerNode : Node
    {
        public Node Left;
        public Node Right;

        public PowerNode(Node left, Node right)
        {
            Left = left;
            Right = right;
        }

        public override double Visit()
        {
            return Math.Pow(Left.Visit(), Right.Visit());
        }

    }

    public class ReduceNode : Node
    {
        public Node Left;
        public Node Right;

        public ReduceNode(Node left, Node right)
        {
            Left = left;
            Right = right;
        }

        public override double Visit()
        {
            return Left.Visit() % Right.Visit();
        }

    }

    public class PlusNode : Node
    {
        public Node Right;

        public PlusNode(Node right)
        {
            Right = right;
        }

        public override double Visit()
        {
            return Right.Visit();
        }

    }

    public class MinusNode : Node
    {
        public Node Right;

        public MinusNode(Node right)
        {
            Right = right;
        }

        public override double Visit()
        {
            return -Right.Visit();
        }
    }

    public class FuncNode : Node
    {
        public string Name;
        public List<Node> Nodes = new List<Node>();
        public List<double> Args = new List<double>();

        public FuncNode(string name)
        {
            Name = name;
        }

        public override double Visit()
        {
            foreach(var item in Nodes)
            {
                Args.Add(item.Visit());
            }

            return util.FuncEval(Name, Args.ToArray());
        }
    }

}
