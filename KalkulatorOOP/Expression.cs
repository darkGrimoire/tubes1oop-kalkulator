using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Math;
using System.Threading.Tasks;
using CalculatorException;

namespace KalkulatorOOP
{
    public class Expression
    {

        public Expression()
        {

        }
        virtual double solve();
    }

    public class TerminalExpression : Expression
    {
        protected double x;
    
        public TerminalExpression(double x)
            {
                this.x = x;
            }
            public double solve()
            {
                return this.x;
            }
    }
    public class UnaryExpression : Expression
    {
        protected Expression* x;

        public UnaryExpression(Expression* x)
        {
            this.x = x;
        }
        virtual double solve();
    }

    public class BinaryExpression : Expression
    {
        protected Expression* x;
        protected Expression* y;

        public BinaryExpression(Expression* x, Expression* y)
        {
            this.x = x;
            this.y = y;
        }
        virtual double solve();
    }

    public class NegativeExpression : UnaryExpression
    {
        public NegativeExpression(Expression* a)
        {

        }
        public double solve()
        {
            return (x.solve() * -1);
        }
    }

    public class AddExpression : BinaryExpression
    {
        public AddExpression(Expression* a, Expression* b)
        {

        }
        public double solve()
        {
            return (x.solve() + y.solve());
        }
    }

    public class SubstractExpression : BinaryExpression
    {
        public SubstractExpression(Expression* a, Expression* b)
        {

        }
        public double solve()
        {
            return (x.solve() - y.solve());
        }
    }

    public class MultiplyExpression : BinaryExpression
    {
        public MultiplyExpression(Expression* a, Expression* b)
        {

        }
        public double solve()
        {
            return (x.solve * y.solve);
        }
    }

    public class DivisionExpression : BinaryExpression
    {
        public DivisionExpression(Expression* a, Expression* b)
        {

        }
        public double solve()
        {
            return (x.solve() / y.solve());
        }
    }

    public class RootExpression : UnaryExpression
    {
        public RootExpression(Expression* a)
        {

        }
        public double solve()
        {
            return Math.Sqrt(x.solve());
        }

    }

    public class AppointmentExpression : BinaryExpression
    {
        public AppointmentExpression(Expression* a, Expression* b)
        {

        }
        public double solve()
        {
            return Math.Pow(x.solve(), y.solve());
        }

    }

    public class SinExpression : UnaryExpression
    {
        public SinExpression(Expression* a)
        {

        }
        public double solve()
        {
            return (Math.Sin(x.solve()));
        }
    }

    public class CosExpression : UnaryExpression
    {
        public CosExpression(Expression* a)
        {

        }
        public double solve()
        {
            return (Math.Cos(x.solve()));
        }
    }

    public class TanExpression : UnaryExpression
    {
        public TanExpression(Expression* a)
        {

        }
        public double solve()
        {
            return (Math.Tan(x.solve()));
        }
    }
}
