using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Math;
using System.Threading.Tasks;
using CalculatorException;

//namespace KalkulatorOOP
//{   
    abstract public class Expression
    {

        public Expression()
        {

        }
        abstract public double Solve();
    }
    public class Operator : Expression
    {
        protected char x;
        public Operator(char x)
        {
            this.x = x;
        }

        public override double Solve()
        {
            throw new NotImplementedException();
        }
        public char GetOp()
        {
            return this.x;
        }

    }
    public class TerminalExpression : Expression
    {
        protected double x;
    
        public TerminalExpression(double x)
            {
                this.x = x;
            }  
        public override double Solve()
            {
                return this.x;
            }
    }
    abstract public class UnaryExpression : Expression
    {
        protected Expression x;

        public UnaryExpression(Expression x)
        {
            this.x = x;
        }
        //abstract public double Solve();
    }

    abstract public class BinaryExpression : Expression
    {
        protected Expression x;
        protected Expression y;

        public BinaryExpression(Expression x, Expression y)
        {
            this.x = x;
            this.y = y;
        }
        //virtual double Solve();
    }

    public class NegativeExpression : UnaryExpression
    {
        public NegativeExpression(Expression a) : base(a)
        {
            
        }
        public override double Solve()
        {
            return (x.Solve() * -1);
        }
    }

    public class AddExpression : BinaryExpression
    {
        public AddExpression(Expression a, Expression b) : base(a,b)
        {

        }
        public override double Solve()
        {
            return (x.Solve() + y.Solve());
        }
    }

    public class SubstractExpression : BinaryExpression
    {
        public SubstractExpression(Expression a, Expression b) : base(a,b)
        {

        }
        public override double Solve()
        {
            return (x.Solve() - y.Solve());
        }
    }

    public class MultiplyExpression : BinaryExpression
    {
        public MultiplyExpression(Expression a, Expression b) : base(a,b)
        {

        }
        public override double Solve()
        {
            return (x.Solve() * y.Solve());
        }
    }

    public class DivisionExpression : BinaryExpression
    {
        public DivisionExpression(Expression a, Expression b) : base(a,b)
        {

        }
        public override double Solve()
        {
            return (x.Solve() / y.Solve());
        }
    }

    public class RootExpression : UnaryExpression
    {
        public RootExpression(Expression a) : base(a)
        {

        }
        public override double Solve()
        {
            return Math.Sqrt(x.Solve());
        }

    }

    public class AppointmentExpression : BinaryExpression
    {
        public AppointmentExpression(Expression a, Expression b) : base(a,b)
        {

        }
        public override double Solve()
        {
            return Math.Pow(x.Solve(), y.Solve());
        }

    }

    public class SinExpression : UnaryExpression
    {
        public SinExpression(Expression a) : base(a)
        {

        }
        public override double Solve()
        {
            return (Math.Sin(x.Solve()));
        }
    }

    public class CosExpression : UnaryExpression
    {
        public CosExpression(Expression a) : base(a)
        {

        }
        public override double Solve()
        {
            return (Math.Cos(x.Solve()));
        }
    }

    public class TanExpression : UnaryExpression
    {
        public TanExpression(Expression a) : base(a)
        {

        }
        public override double Solve()
        {
            return (Math.Tan(x.Solve()));
        }
    }
//}
