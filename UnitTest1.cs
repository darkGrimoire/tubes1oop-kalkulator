using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorException;

namespace KalkulatorTester
{
    public class ExceptionTest
    {
        public static void Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivisionByZeroException();
            }
        }

        public static void RealRoot(double a)
        {
            if (a < 0)
            {
                throw new NegativeRootException(a);
            }
        }

        public static void StrCmpLength(String a, int maxLength)
        {
            if (a.Length > maxLength)
            {
                throw new TooManyInputsException(a.Length);
            }
        }

    }

    [TestClass]
    public class ExceptionUnitTest
    {
        [TestMethod]
        public void DivisionByZeroTest()
        {
            bool checkFalse = false;
            bool checkTrue = true;
            try
            {
                ExceptionTest.Divide(5, 0);
            }
            catch
            {
                checkFalse = true;
            }
            try
            {
                ExceptionTest.Divide(5, 1);
            }
            catch
            {
                checkTrue = false;
            }
            Assert.AreEqual(true, (checkFalse & checkTrue));
        }

        [TestMethod]
        public void NegativeRealRootTest()
        {
            bool checkFalse = false;
            bool checkTrue = true;
            try
            {
                ExceptionTest.RealRoot(-5);
            }
            catch
            {
                checkFalse = true;
            }
            try
            {
                ExceptionTest.RealRoot(4);
            }
            catch
            {
                checkTrue = false;
            }
            Assert.AreEqual(true, (checkFalse && checkTrue));
        }

        [TestMethod]
        public void TooManyInputTest()
        {
            bool checkLonger = false;
            bool checkEqual = true;
            bool checkShorter = true;

            try
            {
                ExceptionTest.StrCmpLength("qwerty", 5);
            }
            catch
            {
                checkLonger = true;
            }
            try
            {
                ExceptionTest.StrCmpLength("qwert", 5);
            }
            catch
            {
                checkEqual = false;
            }
            try
            {
                ExceptionTest.StrCmpLength("qwer", 5);
            }
            catch
            {
                checkShorter = false;
            }

            Assert.AreEqual(true, checkLonger && checkEqual && checkShorter);
        }
    }
    
    [TestClass]
    public class QueueUnitTest
    {
        [TestMethod]
        public void PushingAValue()
        {
            MCMRQueue<int> queue = new MCMRQueue<int>(5);
            queue.Push(3);
            bool checkElmt = queue.Peek() == 3;
            bool checkNumOfElmt = queue.Count == 1;

            Assert.AreEqual(true, checkElmt && checkNumOfElmt);
        }

        [TestMethod]
        public void PushingMoreThanNValue()
        {
            MCMRQueue<int> queue = new MCMRQueue<int>(3);
            queue.Push(3);
            queue.Push(7);
            queue.Push(2);
            queue.Push(5);
            bool checkElmt = queue.Peek() == 7;
            bool checkNumOfElmt = queue.Count == 3;

            Assert.AreEqual(true, checkElmt && checkNumOfElmt);
        }

        [TestMethod]
        public void PoppingAValue()
        {
            MCMRQueue<int> queue = new MCMRQueue<int>(5);
            queue.Push(3);
            int temp = queue.Pop();
            bool checkElmt = temp == 3;
            bool checkNumOfElmt = queue.Count == 0;

            Assert.AreEqual(true, checkElmt && checkNumOfElmt);
        }

        [TestMethod]
        public void PoppingMoreThanNValue()
        {
            MCMRQueue<int> queue = new MCMRQueue<int>(3);
            queue.Push(3);
            queue.Push(7);
            queue.Push(2);
            bool checkException = false;
            for (int i = 0; i <= 4; i++)
            {
                try
                {
                    queue.Pop();
                }
                catch
                {
                    checkException = true;
                }
            }
            bool checkNumOfElmt = queue.Count == 0;

            Assert.AreEqual(true, checkException && checkNumOfElmt);
        }
    }
    
    [TestClass]
    public class ExpressionUnitTest
    {
        
        [TestMethod]
        public void OperatorTester()
        {
            Operator op1 = new Operator('+');
            Operator op2 = new Operator('-');
            Operator op3 = new Operator('*');
            Operator op4 = new Operator('/');
            Operator op5 = new Operator('^');
            Operator op6 = new Operator('(');
            Operator op7 = new Operator(')');

            bool checkEqual = op1.GetOp() == '+' && op2.GetOp() == '-' && op3.GetOp() == '*' &&
                              op4.GetOp() == '/' && op5.GetOp() == '^' && op6.GetOp() == '(' && op7.GetOp() == ')';

            Assert.AreEqual(true, checkEqual);
        }
        
        [TestMethod]
        public void TerminalTester()
        {
            TerminalExpression term = new TerminalExpression(2.5);

            Assert.AreEqual(2.5, term.Solve(), 0.001);
        }

        [TestMethod]
        public void NegativeExpressionTester()
        {
            NegativeExpression neg = new NegativeExpression(new TerminalExpression(5));
            bool checkNegative = neg.Solve() < 0;

            Assert.AreEqual(true, checkNegative);
        }

        [TestMethod]
        public void AddExpressionTester()
        {
            AddExpression add1 = new AddExpression(new TerminalExpression(3), new TerminalExpression(4));
            AddExpression add2 = new AddExpression(new TerminalExpression(4), new NegativeExpression(new TerminalExpression(4)));
            bool checkPos = Math.Abs(add1.Solve() - 7) < 0.001;
            bool checkNeg = Math.Abs(add2.Solve() - 0) < 0.001;

            Assert.AreEqual(true, checkNeg && checkPos);
        }

        [TestMethod]
        public void SubstractExpressionTester()
        {
            SubstractExpression add1 = new SubstractExpression(new TerminalExpression(4), new TerminalExpression(3));
            SubstractExpression add2 = new SubstractExpression(new TerminalExpression(4), new TerminalExpression(6));
            bool checkPos = Math.Abs(add1.Solve() - 1) < 0.001;
            bool checkNeg = Math.Abs(add2.Solve() + 2) < 0.001;

            Assert.AreEqual(true, checkNeg && checkPos);
        }

        [TestMethod]
        public void MultiplyExpressionTester()
        {
            MultiplyExpression add1 = new MultiplyExpression(new TerminalExpression(4), new TerminalExpression(3));
            MultiplyExpression add2 = new MultiplyExpression(new TerminalExpression(4), new NegativeExpression(new TerminalExpression(6)));
            bool checkPos = Math.Abs(add1.Solve() - 12) < 0.001;
            bool checkNeg = Math.Abs(add2.Solve() + 24) < 0.001;

            Assert.AreEqual(true, checkNeg && checkPos);
        }

        [TestMethod]
        public void DivisionExpressionTester()
        {
            MultiplyExpression add1 = new MultiplyExpression(new TerminalExpression(4), new TerminalExpression(3));
            MultiplyExpression add2 = new MultiplyExpression(new TerminalExpression(4), new NegativeExpression(new TerminalExpression(6)));
            bool checkPos = Math.Abs(add1.Solve() - 12) < 0.001;
            bool checkNeg = Math.Abs(add2.Solve() + 24) < 0.001;

            Assert.AreEqual(true, checkNeg && checkPos);
        }

        [TestMethod]
        public void RootExpressionTester()
        {
            RootExpression root = new RootExpression(new TerminalExpression(4));

            Assert.AreEqual(2, root.Solve(), 0.001);
        }

        [TestMethod]
        public void AppointmentExpressionTester()
        {
            AppointmentExpression power = new AppointmentExpression(new TerminalExpression(5), new TerminalExpression(2));

            Assert.AreEqual(25, power.Solve(), 0.001);
        }
        
        [TestMethod]
        public void SinExpressionTester()
        {
            SinExpression sin = new SinExpression(new TerminalExpression(Math.PI/2));

            Assert.AreEqual(1, sin.Solve(), 0.001);
        }

        [TestMethod]
        public void CosExpressionTester()
        {
            CosExpression cos = new CosExpression(new TerminalExpression(0));

            Assert.AreEqual(1, cos.Solve(), 0.001);
        }

        [TestMethod]
        public void TanExpressionTester()
        {
            TanExpression tan = new TanExpression(new TerminalExpression(Math.PI / 4));

            Assert.AreEqual(1, tan.Solve(), 0.001);
        }
    }

    [TestClass]
    public class ParserUnitTest
    {
        [TestMethod]
        public void ParserTest()
        {
            Parser parser = new Parser("?3+2");
        }
    }

    [TestClass]
    public class SolverUnitTest
    {
        [TestMethod]
        public void solverTest1()
        {
            Parser parser = new Parser("3+2");
            double ans = parser.Solve();

            Assert.AreEqual(5, ans, 0.0001);
        }

        [TestMethod]
        public void solverTest2()
        {
            Parser parser = new Parser("-3-2");
            double ans = parser.Solve();

            Assert.AreEqual(-5, ans, 0.0001);
        }

        [TestMethod]
        public void solverTest3()
        {
            Parser parser = new Parser("3--4");
            double ans = parser.Solve();

            Assert.AreEqual(7, ans, 0.0001);
        }

        [TestMethod]
        public void solverTest4()
        {
            Parser parser = new Parser("3+-4");
            double ans = parser.Solve();

            Assert.AreEqual(-1, ans, 0.0001);
        }

        [TestMethod]
        public void solverTest5()
        {
            Parser parser = new Parser("√4+2");
            double ans = parser.Solve();

            Assert.AreEqual(4, ans, 0.0001);
        }

        [TestMethod]
        public void solverTest6()
        {
            Parser parser = new Parser("(3+2)");
            double ans = parser.Solve();

            Assert.AreEqual(5, ans, 0.0001);
        }

        [TestMethod]
        public void solverTest7()
        {
            Parser parser = new Parser("√4+(3-2)*-2");
            double ans = parser.Solve();

            Assert.AreEqual(0, ans, 0.0001);
        }
    }
    
}
