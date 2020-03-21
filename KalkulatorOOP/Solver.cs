using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using CalculatorException;
using KalkulatorOOP;

namespace Solver
{
    class Solver
    {
        /*Kamus Data*/
        protected List<Expression> List_Expr { get; set; }
        protected Stack<Expression> Operator_Stack { get; set; }
        protected Stack<Expression> Value_Stack { get; set; }
        protected double Ans { get; set; }

        /*Konstruktor*/
        public Solver(List<Expression> Term_Expr)
        {
            // Perform a Shallow Copy of existing "Term_Expr" List
            this.List_Expr = new List<Expression>(Term_Expr);
            this.Operator_Stack = new Stack<Expression>();
            this.Value_Stack = new Stack<Expression>();
            this.Ans = 0.0;
        }

        public double Solve()
        {
            // 1. iterate terminal expression list above
            foreach (var iExpr in this.List_Expr)
            {
                // if token is an operator
                if (isOperator(iExpr))
                {
                    while (this.Operator_Stack.Count != 0
                        && precedence(this.Operator_Stack.Peek()) >= precedence(iExpr))
                    {
                        if (isBinaryOperator(this.Value_Stack.Peek()))
                        {
                            Expression Expr2 = this.Value_Stack.Peek();
                            this.Value_Stack.Pop();

                            Expression Expr1 = this.Value_Stack.Peek();
                            this.Value_Stack.Pop();

                            Expression op = this.Operator_Stack.Peek();
                            this.Operator_Stack.Pop();

                            this.Value_Stack.Push(applyOp(Expr1, op, Expr2));
                        }
                        else if (isUnaryOperator(this.Value_Stack.Peek()))
                        {
                            Expression Expr1 = this.Value_Stack.Peek();
                            this.Value_Stack.Pop();

                            Expression op = this.Operator_Stack.Peek();
                            this.Operator_Stack.Pop();

                            this.Value_Stack.Push(applyOp(op, Expr1));
                        }
                    }

                    // Push current token to 'Operator_Stack'. 
                    this.Operator_Stack.Push(iExpr);
                }
                // if token is Left Parenthesis
                else if (isLeftBracketExpr(iExpr))
                {
                    this.Operator_Stack.Push(iExpr);
                }
                // if token is Right Parenthesis
                else if (isRightBracketExpr(iExpr))
                {
                    while (this.Operator_Stack.Count != 0
                        && !(isLeftBracketExpr(this.Operator_Stack.Peek())))
                    {
                        if (isBinaryOperator(this.Value_Stack.Peek()))
                        {
                            Expression Expr2 = this.Value_Stack.Peek();
                            this.Value_Stack.Pop();

                            Expression Expr1 = this.Value_Stack.Peek();
                            this.Value_Stack.Pop();

                            Expression op = this.Operator_Stack.Peek();
                            this.Operator_Stack.Pop();

                            this.Value_Stack.Push(applyOp(Expr1, op, Expr2));
                        }
                        else if (isUnaryOperator(this.Value_Stack.Peek()))
                        {
                            Expression Expr1 = this.Value_Stack.Peek();
                            this.Value_Stack.Pop();

                            Expression op = this.Operator_Stack.Peek();
                            this.Operator_Stack.Pop();

                            this.Value_Stack.Push(applyOp(op, Expr1));
                        }
                    }
                    // pop opening brace ("("). 
                    if (this.Operator_Stack.Count != 0) /*if Not Empty*/
                    {
                        this.Operator_Stack.Pop();
                    }
                }
                // if token is a value
                else /*token == value (number)*/
                {
                    this.Value_Stack.Push(iExpr); //NOTE : Masih memungkinkan "bocor"
                }
            }

            // 2. Operate both operator stack and value stack till operator stack empty
            while (this.Operator_Stack.Count != 0
                && !(isLeftBracketExpr(this.Operator_Stack.Peek())))
            {
                if (isBinaryOperator(this.Value_Stack.Peek()))
                {
                    Expression Expr2 = this.Value_Stack.Peek();
                    this.Value_Stack.Pop();

                    Expression Expr1 = this.Value_Stack.Peek();
                    this.Value_Stack.Pop();

                    Expression op = this.Operator_Stack.Peek();
                    this.Operator_Stack.Pop();

                    this.Value_Stack.Push(applyOp(Expr1, op, Expr2));
                }
                else if (isUnaryOperator(this.Value_Stack.Peek()))
                {
                    Expression Expr1 = this.Value_Stack.Peek();
                    this.Value_Stack.Pop();

                    Expression op = this.Operator_Stack.Peek();
                    this.Operator_Stack.Pop();

                    this.Value_Stack.Push(applyOp(op, Expr1));
                }
            }

            // 3. return the final value in value stack
            this.Ans = this.Value_Stack.Peek().solve(); //NOTE:GetValuenya
            return this.Ans;
        }

        // Validate is a token an operator symbol
        public bool isOperator(Expression Expr)
        {
            if (Expr.solve() == "+" // NOTE : GetValuenya
             || Expr.solve() == "-"
             || Expr.solve() == ":"
             || Expr.solve() == "*"
             || Expr.solve() == "√"
             || Expr.solve() == "Sin"
             || Expr.solve() == "Cos"
             || Expr.solve() == "Tan")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Function to find precedence of operators. 
        public int precedence(Expression Expr)
        {
            if (op == '+' || op == '-')
                return 1;
            if (op == '*' || op == '/')
                return 2;
            return 0;
        }

        public bool isBinaryOperator(Expression Expr)
        {
            return Expr.GetType().ToString().Equals("BinaryExpression");
        }
        public bool isUnaryOperator(Expression Expr)
        {
            return Expr.GetType().ToString().Equals("UnaryExpression");
        }
        public bool isLeftBracketExpr(Expression Expr)
        {
            return;
        }
        public bool isRightBracketExpr(Expression Expr)
        {
            return;
        }

        // Function to perform arithmetic operations. 
        public Expression applyOp(Expression val1, Expression op, Expression val2)
        {
            switch (op)
            {
                case "+": return a + b;// NOTE : GetValuenya
                case "-": return a - b;// NOTE : GetValuenya
                case "*": return a * b;// NOTE : GetValuenya
                case ":": return a / b;// NOTE : GetValuenya
            }
        }

        public Expression applyOp(Expression op, Expression val2)
        {
            switch (op)
            {
                case "√": return Math.Sqrt(a); // NOTE : GetValuenya
                case "Cos": return Math.Sin(a); // NOTE : GetValuenya
                case "Sin": return Math.Cos(a); // NOTE : GetValuenya
                case "Tan": return Math.Tan(a); // NOTE : GetValuenya
            }
        }

        public double getAns()
        {
            return this.Ans;
        }

        static public void Main(String[] args)
        {
            List A = new List { 3, "+", 10 };
            Solver Anzayyy = new Solver(A);
            double Answer;

            Answer = Anzayyy.Solve();
            Console.Out.Println(Anzayyy.getAns());
        }
    }
}