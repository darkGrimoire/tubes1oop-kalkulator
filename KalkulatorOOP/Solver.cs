﻿using System;
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
            this.List_Expr = Term_Expr;
            this.Operator_Stack = new Stack<Expression>();
            this.Value_Stack = new Stack<Expression>();
            this.Ans = 0.0;
        }

        public double Solve()
        {
            // 1. iterate terminal expression list above
            foreach (var iExpr in this.List_Expr)
            {
                // if token is Left Parenthesis
                if (isLeftBracketExpr(iExpr))
                {
                    this.Operator_Stack.Push(iExpr);
                }
                // if token is Right Parenthesis
                else if (isRightBracketExpr(iExpr))
                {
                    while (this.Operator_Stack.Count != 0
                        && !(isLeftBracketExpr(this.Operator_Stack.Peek())))
                    {
                        // Apply Operation
                        PopPopApplyPush();
                    }
                    // pop opening brace ("("). 
                    if (this.Operator_Stack.Count != 0) /*if Not Empty*/
                    {
                        this.Operator_Stack.Pop();
                    }
                }

                // if token is an operator
                else if (isOperator(iExpr)) // Selain Open Brackets ("(") dan Close Brackets (")")
                {
                    while (this.Operator_Stack.Count != 0
                        && precedence(this.Operator_Stack.Peek()) >= precedence(iExpr))
                    {
                        // Apply Operation
                        PopPopApplyPush();
                    }

                    // Push current token to 'Operator_Stack'. 
                    this.Operator_Stack.Push(iExpr);
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
                // Apply Operation
                PopPopApplyPush();
            }

            // 3. return the final value in value stack
            this.Ans = this.Value_Stack.Peek().Solve(); //NOTE:GetValuenya
            return this.Ans;
        }

        void PopPopApplyPush()
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

        // Validate is a token an operator symbol
        public bool isOperator(object Expr)
        {
            if (Expr.GetType().ToString().Equals("Operator"))
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
            if (Expr.Solve() == '+' || Expr.Solve() == '-')
            {
                return 1;
            }
            else if (Expr.Solve() == '*' || Expr.Solve() == '/')
            {
                return 2;
            }
            else if (Expr.Solve() == '^' || Expr.Solve() == '√'
                  || Expr.Solve().Equals("sin") || Expr.Solve().Equals("cos") || Expr.Solve().Equals("tan"))
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }

        public bool isBinaryOperator(Expression Expr)
        {
            return (Expr.GetType().ToString().Equals("BinaryExpression")
                 || Expr.GetType().ToString().Equals("AddExpression")
                 || Expr.GetType().ToString().Equals("SubstractExpression")
                 || Expr.GetType().ToString().Equals("MultiplyExpression")
                 || Expr.GetType().ToString().Equals("DivisionExpression")
                 || Expr.GetType().ToString().Equals("AppointmentExpression"));
        }
        public bool isUnaryOperator(Expression Expr)
        {
            return (Expr.GetType().ToString().Equals("UnaryExpression")
                 || Expr.GetType().ToString().Equals("TanExpression")
                 || Expr.GetType().ToString().Equals("SinExpression")
                 || Expr.GetType().ToString().Equals("CosExpression")
                 || Expr.GetType().ToString().Equals("NegativeExpression")
                 || Expr.GetType().ToString().Equals("RootExpression"));
        }
        public bool isLeftBracketExpr(Expression Expr)
        {
            return (Expr.GetType().ToString().Equals("RootExpression") && Expr.Solve() == '(');
        }
        public bool isRightBracketExpr(Expression Expr)
        {
            return (Expr.GetType().ToString().Equals("RootExpression") && Expr.Solve() == ')');
        }

        // Function to perform arithmetic operations. 
        public Expression applyOp(Expression val1, Expression op, Expression val2)
        {
            if (op.Solve() == '+')
            {
                BinaryExpression Add = new AddExpression(val1, val2);
                return Add;
            }
            else if (op.Solve() == '-')
            {
                BinaryExpression Substract = new SubstractExpression(val1, val2);
                return Substract;
            }
            else if (op.Solve() == '*')
            {
                BinaryExpression Multiply = new MultiplyExpression(val1, val2);
                return Multiply;
            }
            else if (op.Solve() == '/')
            {
                BinaryExpression Division = new DivisionExpression(val1, val2);
                return Division;
            }
            else if (op.Solve() == '^')
            {
                BinaryExpression Appointment = new AppointmentExpression(val1, val2);
                return Appointment;
            }
        }

        public Expression applyOp(Expression op, Expression val)
        {
            if (op.Solve() == '√')
            {
                UnaryExpression Root = new RootExpression(val);
                return Root;
            }
            else if (op.Solve().Equals("sin"))
            {
                UnaryExpression Sin = new SinExpression(val);
                return Sin;
            }
            else if (op.Solve().Equals("cos"))
            {
                UnaryExpression Cos = new CosExpression(val);
                return Cos;
            }
            else if (op.Solve().Equals("tan"))
            {
                UnaryExpression Tan = new TanExpression(val);
                return Tan;
            }
        }

        public double getAns()
        {
            return this.Ans;
        }
    }
}