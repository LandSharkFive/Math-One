using MathOne;

namespace TestOne
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestNumber1()
        {
            Util util = new Util();
            string input = "123, 123.45, .001";
            var list = util.GetTokenList(input);
            Assert.AreEqual(5, list.Count);
            Assert.AreEqual(123, list[0].Value);
            Assert.AreEqual(123.45, list[2].Value);
            Assert.AreEqual(0.001, list[4].Value);
            Assert.AreEqual(TokenType.Comma, list[1].Type);
        }

        [TestMethod]
        public void TestToken1()
        {
            Util util = new Util();
            string input = "1 + 2 * 3";
            var list = util.GetTokenList(input);
            Assert.AreEqual(5, list.Count);
            Assert.AreEqual(1, list[0].Value);
            Assert.AreEqual(TokenType.Plus, list[1].Type);  
            Assert.AreEqual(2, list[2].Value);
            Assert.AreEqual(TokenType.Multiply, list[3].Type);
            Assert.AreEqual(3, list[4].Value);
        }

        [TestMethod]
        public void TestEval1()
        {
            Util util = new Util();
            string input = "1 + 2 * 3";
            double result = util.Eval(input);
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void TestEval2()
        {
            Util util = new Util();
            string input = "2 * 3 + 1";
            double result = util.Eval(input);
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void TestEval3()
        {
            Util util = new Util();
            string input = "1 + (2 * 3)";
            double result = util.Eval(input);
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void TestEval4()
        {
            Util util = new Util();
            string input = "1 + (2 * 3) / 4";
            double result = util.Eval(input);
            Assert.AreEqual(2.5, result);
        }

        [TestMethod]
        public void TestEval5()
        {
            Util util = new Util();
            string input = "41 + (22 * 33) / 44";
            double result = util.Eval(input);
            Assert.AreEqual(57.5, result);
        }

        [TestMethod]
        public void TestEval6()
        {
            Util util = new Util();
            string input = "-5 - 5";
            double result = util.Eval(input);
            Assert.AreEqual(-10, result);
        }

        [TestMethod]
        public void TestEval7()
        {
            Util util = new Util();
            string input = "-5 + 5";
            double result = util.Eval(input);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestEval8()
        {
            Util util = new Util();
            string input = "1 * 2 * 3 * 4 * 5";
            double result = util.Eval(input);
            Assert.AreEqual(120, result);
        }

        [TestMethod]
        public void TestParen1()
        {
            Util util = new Util();
            string input = "(1 * 2) + (3 * 4) + 5";
            double result = util.Eval(input);
            Assert.AreEqual(19, result);
        }

        [TestMethod]
        public void TestParen2()
        {
            Util util = new Util();
            string input = "(1 + 2) * (3 + 4) * 5";
            double result = util.Eval(input);
            Assert.AreEqual(105, result);
        }

        [TestMethod]
        public void TestParen3()
        {
            Util util = new Util();
            string input = "(1 + 2) / (3 + 4) * 5";
            double result = util.Eval(input);
            Assert.AreEqual(2.142857, result, 1e-4);
        }

        [TestMethod]
        public void TestUnary1()
        {
            Util util = new Util();
            string input = "-(1 + 2) / (3 + 4) * 5";
            double result = util.Eval(input);
            Assert.AreEqual(-2.142857, result, 1e-4);
        }

        [TestMethod]
        public void TestUnary2()
        {
            Util util = new Util();
            string input = "(1 + 2) / (3 + 4) - 5";
            double result = util.Eval(input);
            Assert.AreEqual(-4.571428, result, 1e-4);
        }

        [TestMethod]
        public void TestNull1()
        {
            Util util = new Util();
            string input = "";
            double result = util.Eval(input);
            Assert.AreEqual(0, result);
        }

    }
}