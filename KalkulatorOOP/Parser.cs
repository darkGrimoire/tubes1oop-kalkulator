using System;
using System.Collections.Generic;
using System.Text;
using KalkulatorOOP;

// ASUMSI: Unary Expression dibuat di Parser.
public class Parser
{
	List<Expression> parseList = new List<Expression>();
	public Parser(string token)
	{
		int i = 0;
		// Default number = Integer
		bool isNegative = false;
		bool isRoot = false;
		string isTrigonometry = "";
		bool isNum = false;
		bool isUnary = false;
		string debug = "";
		bool hasPassedOperator = false;
		bool hasPassedNum = false;
		StringBuilder buffer = new StringBuilder("");
		while (i < token.Length)
		{
			debug = token[i].ToString();
			// If token is a whitespace, skip it
			if (token[i] == ' ') {/*continue*/}
			// If token is unary expression (-, √), make the empty Unary Expression
			else if ((token[i] == '-' || token[i] == '√') && !hasPassedNum)
			{
				if (hasPassedOperator || i == 0 || isNegative)
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
					hasPassedOperator = false;
				}
				else
				{

				}
			}
			// If token is trigonometry unary expression, make the empty Unary Expression
			else if (token[i] == 's' || token[i] == 'c' || token[i] == 't')
			//else if (token.Substring(i, 3).Equals("sin")
			//	  || token.Substring(i, 3).Equals("cos")
			//	  || token.Substring(i, 3).Equals("tan"))
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
				hasPassedOperator = true;
				hasPassedNum = false;
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
				i--;
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
				i--;
			}
			if (isNum)
			{
				TerminalExpression termExpr = new TerminalExpression(double.Parse(buffer.ToString(), System.Globalization.CultureInfo.InvariantCulture));
				if (isRoot && isNegative)
				{
					UnaryExpression UnExpr = new NegativeExpression(new RootExpression(termExpr)); isUnary = true;
					isRoot = false; isNegative = false;
					this.parseList.Add(UnExpr);
				}
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
				buffer.Clear();
				hasPassedNum = true;
			}
			i++;
		}
		//Solver solve = new Solver(parseList);
	}

	public void Peek()
	{
		foreach (object o in parseList)
		{
			Console.WriteLine(o.GetType().ToString());
		}
	}

	public double Solve()
	{
		Solver solve = new Solver(parseList);
		solve.Solve();
		return solve.getAns();
	}
}
