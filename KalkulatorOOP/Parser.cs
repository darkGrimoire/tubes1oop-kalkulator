using System;
using System.Collections.Generic;
using System.Text;
using KalkulatorOOP;
using CalculatorException;

// ASUMSI: Unary Expression dibuat di Parser.
public class Parser
{
	List<Expression> parseList = new List<Expression>();
	public Parser(string token)
	{
		int i = 0;
		// Default number = Integer
		Stack<int> unaryStack = new Stack<int>(); // 1 negatif, 2 root, 3 sin, 4 cos, 5 tan
		bool isNegative = false;
		bool firstNum = true;
		//bool isRoot = false;
		string isTrigonometry = "";
		bool isNum = false;
		bool isUnary = false;
		string debug = "";
		bool hasPassedOperator = false;
		bool hasPassedNum = false;
		StringBuilder buffer = new StringBuilder("");
		unaryStack.Push(0);
		while (i < token.Length)
		{
			debug = token[i].ToString();
			// If token is a whitespace, skip it
			if (token[i] == ' ') {/*continue*/}
			// If token is unary expression (-, √), make the empty Unary Expression
			else if ((token[i] == '-' || token[i] == '√') && !hasPassedNum)
			{
				if (hasPassedOperator || firstNum)
				{
					if (token[i] == '-')
					{
						//UnaryExpression unaryOp = new NegativeExpression();
						if (unaryStack.Peek() == 1)
						{
							throw new Exception();
						}
						else if (unaryStack.Peek() == 2)
						{
							throw new NegativeRootException();
						}
						else
						{
							unaryStack.Push(1);
							isUnary = true;
						}
					}
					else
					{
						//UnaryExpression unaryOp = new RootExpression();
						//isRoot = true;
						unaryStack.Push(2);
						isUnary = true;
					}
					//hasPassedOperator = false;
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
				isUnary = true;
				if (isTrigonometry.Equals("sin"))
				{
					unaryStack.Push(3);
				}
				if (isTrigonometry.Equals("cos"))
				{
					unaryStack.Push(4);
				}
				if (isTrigonometry.Equals("tan"))
				{
					unaryStack.Push(5);
				}
				i += 2;
			}
			// If token is an operator, push it to parseList
			else if (token[i] == '(' || token[i] == ')' || token[i] == '^'
		  || token[i] == '+' || token[i] == '-' || token[i] == '*' || token[i] == '/')
			{
				if (firstNum) { firstNum = false; }
				Operator op = new Operator(token[i]);
				parseList.Add(op);
				hasPassedOperator = true;
				hasPassedNum = false;
			}
			// If token is a number, parse it
			else if (token[i] >= '0' && token[i] <= '9')
			{
				isNum = true;
				while (i < token.Length && ((token[i] >= '0' && token[i] <= '9') || token[i] == '.'))
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
				if (isUnary)
				{
					UnaryExpression x, y;
					int unaryCode;
					unaryCode = unaryStack.Pop();
					if (unaryCode == 1) 
					{
						x = new NegativeExpression(termExpr);
						while (unaryStack.Count > 1)
						{
							unaryCode = unaryStack.Pop();
							if (unaryCode == 1)
							{
								x = new NegativeExpression(x);
							}
							else if (unaryCode == 2)
							{
								x = new RootExpression(x);
							}
							else if (unaryCode == 3)
							{
								x = new SinExpression(x);
							}
							else if (unaryCode == 4)
							{
								x = new CosExpression(x);
							}
							else if (unaryCode == 5)
							{
								x = new TanExpression(x);
							}
						}
						this.parseList.Add(x);
					}
					else if (unaryCode == 2)
					{
						x = new RootExpression(termExpr);
						while (unaryStack.Count > 1)
						{
							unaryCode = unaryStack.Pop();
							if (unaryCode == 1)
							{
								x = new NegativeExpression(x);
							}
							else if (unaryCode == 2)
							{
								x = new RootExpression(x);
							}
							else if (unaryCode == 3)
							{
								x = new SinExpression(x);
							}
							else if (unaryCode == 4)
							{
								x = new CosExpression(x);
							}
							else if (unaryCode == 5)
							{
								x = new TanExpression(x);
							}
						}
						this.parseList.Add(x);
					}
					else if (unaryCode == 3)
					{
						x = new SinExpression(termExpr);
						while (unaryStack.Count > 1)
						{
							unaryCode = unaryStack.Pop();
							if (unaryCode == 1)
							{
								x = new NegativeExpression(x);
							}
							else if (unaryCode == 2)
							{
								x = new RootExpression(x);
							}
							else if (unaryCode == 3)
							{
								x = new SinExpression(x);
							}
							else if (unaryCode == 4)
							{
								x = new CosExpression(x);
							}
							else if (unaryCode == 5)
							{
								x = new TanExpression(x);
							}
						}
						this.parseList.Add(x);
					}
					else if (unaryCode == 4)
					{
						x = new CosExpression(termExpr);
						while (unaryStack.Count > 1)
						{
							unaryCode = unaryStack.Pop();
							if (unaryCode == 1)
							{
								x = new NegativeExpression(x);
							}
							else if (unaryCode == 2)
							{
								x = new RootExpression(x);
							}
							else if (unaryCode == 3)
							{
								x = new SinExpression(x);
							}
							else if (unaryCode == 4)
							{
								x = new CosExpression(x);
							}
							else if (unaryCode == 5)
							{
								x = new TanExpression(x);
							}
						}
						this.parseList.Add(x);
					}
					else if (unaryCode == 5)
					{
						x = new TanExpression(termExpr);
						while (unaryStack.Count > 1)
						{
							unaryCode = unaryStack.Pop();
							if (unaryCode == 1)
							{
								x = new NegativeExpression(x);
							}
							else if (unaryCode == 2)
							{
								x = new RootExpression(x);
							}
							else if (unaryCode == 3)
							{
								x = new SinExpression(x);
							}
							else if (unaryCode == 4)
							{
								x = new CosExpression(x);
							}
							else if (unaryCode == 5)
							{
								x = new TanExpression(x);
							}
						}
						this.parseList.Add(x);
					}
				}
				if (!isUnary)
				{
					this.parseList.Add(termExpr);
				}
				//isRoot = false;
				firstNum = false;
				isTrigonometry = "";
				isNegative = false;
				isNum = false;
				isUnary = false;
				buffer.Clear();
				hasPassedNum = true;
				hasPassedOperator = false;
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
