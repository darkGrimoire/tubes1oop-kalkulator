using System;
using System.Collections.Generic;
using System.Text;
using KalkulatorOOP;

// ASUMSI: Unary Expression dibuat di Parser.
public class Parser
{
	List<Expression> parseList;
	public Parser(string token)
	{
		int i = 0;
		// Default number = Integer
		bool isNegative = false;
		bool isRoot = false;
		string isTrigonometry = "";
		bool isNum = false;
		bool isUnary = false;
		StringBuilder buffer = new StringBuilder("");
		while (i < token.Length)
		{
			// If token is a whitespace, skip it
			if (token[i] == ' ') {/*continue*/}
			// If token is unary expression (-, √), make the empty Unary Expression
			else if (token[i] == '-' || token[i] == '√')
			{
				if (token[i] == '-')
				{
					//UnaryExpression unaryOp = new NegativeExpression();
					isNegative = true;
				}
				else
				{
					//UnaryExpression unaryOp = new RootExpression();
					isRoot = true;
				}
			}
			// If token is trigonometry unary expression, make the empty Unary Expression
			else if (token.Substring(i, 3).Equals("sin")
				  || token.Substring(i, 3).Equals("cos")
				  || token.Substring(i, 3).Equals("tan"))
			{
				//UnaryExpression unaryOp = new TrigonometryExpression(token.Substring(i, 3));
				isTrigonometry = token.Substring(i, 3);
				i += 3;
			}
			// If token is an operator, push it to parseList
			else if (token[i] == '(' || token[i] == ')' || token[i] == '^'
		  || token[i] == '+' || token[i] == '-' || token[i] == '*' || token[i] == '/')
			{
				Operator op = new Operator(token[i]);
				parseList.Add(op);
			}
			// If token is a number, parse it
			else if (token[i] >= '0' && token[i] <= '9')
			{
				isNum = true;
				while (i < token.Length && ((token[i] >= '0' && token[i] <= '9')  || token[i] ==  '.'))
				{
					buffer.Append(token[i]);
					i++;
				}
			}
			// If token is a .number, parse it too
			else if (token[i] == '.')
			{
				isNum = true;
				buffer.Append("0.");
				i++;
				while (i < token.Length && token[i] >= '0' && token[i] <= '9')
				{
					buffer.Append(token[i]);
					i++;
				}
			}
			if (isNum)
			{
				TerminalExpression termExpr = new TerminalExpression(double.Parse(buffer.ToString(), System.Globalization.CultureInfo.InvariantCulture));
				if (isRoot)
				{
					UnaryExpression UnExpr = new RootExpression(termExpr); isUnary = true;
					this.parseList.Add(UnExpr);
				}
				if (isTrigonometry.Equals("sin"))
				{
					UnaryExpression UnExpr = new SinExpression(termExpr); isUnary = true;
					this.parseList.Add(UnExpr);
				}
				if (isTrigonometry.Equals("cos"))
				{
					UnaryExpression UnExpr = new CosExpression(termExpr); isUnary = true;
					this.parseList.Add(UnExpr);
				}
				if (isTrigonometry.Equals("tan"))
				{
					UnaryExpression UnExpr = new TanExpression(termExpr); isUnary = true;
					this.parseList.Add(UnExpr);
				}
				if (isNegative)
				{
					UnaryExpression UnExpr = new NegativeExpression(termExpr); isUnary = true;
					this.parseList.Add(UnExpr);
				}
				if (!isUnary)
				{
					this.parseList.Add(termExpr);
				}
				isRoot = false;
				isTrigonometry = "";
				isNegative = false;
				isNum = false;
				isUnary = false;
			}
			i++;
		}
	}
}
