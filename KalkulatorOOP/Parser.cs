using System;
using System.Collections.Generic;
using System.Text;

// ASUMSI: Unary Expression dibuat di Parser.
public class Parser
{
	List<Expression> parseList;
	public Parser(string token)
	{
		int i = 0;
		// Default number = Integer
		bool hasPoint = false;
		StringBuilder buffer = new StringBuilder("");
		while (i < token.Length)
		{
			// If token is a whitespace, skip it
			if (token[i] == ' ') ;
			// If token is unary expression (-, √), make the empty Unary Expression
			else if (token[i] == '-' || token[i] == '√')
			{
				if (token[i] == '-')
				{
					UnaryExpression unaryOp = new NegativeExpression();
				}
				else
				{
					UnaryExpression unaryOp = new RootExpression();
				}
			}
			// If token is trigonometry unary expression, make the empty Unary Expression
			else if (token.Substring(i,3).Equals("sin") 
				  || token.Substring(i, 3).Equals("cos")
				  || token.Substring(i, 3).Equals("tan"))
			{
				UnaryExpression unaryOp = new TrigonometryExpression(token.Substring(i, 3));
			}
			// If token is an operator, push it to parseList
			// TODO: make this into static Operator.isOperator(token[i])
					else if (token[i] == '(' || token[i] == ')' || token[i] == '^'
				  || token[i] == '+' || token[i] == '-' || token[i] == '*' || token[i] == '/')
			{
				TerminalExpression op = new Operator(token[i]);
				parseList.Add(op);
			}

			// If token is a .number, make it as double
			else if (token[i] == '.')
			{
				i++;
				while (i < token.Length && token[i] >= '0' && token[i] <= '9')
				{
					buffer
					i++;
				}
			}
		}
	}
}
