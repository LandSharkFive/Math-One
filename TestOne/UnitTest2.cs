
using MathOne;

namespace TestOne
{
    public class UnitTest2
    {

        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestZero1()
            {
                Util util = new Util();
                string input = "0";
                var result = util.Eval(input);
                Assert.AreEqual(0, result);
            }

            [TestMethod]
            public void TestTwo1()
            {
                Util util = new Util();
                string input = "2";
                var result = util.Eval(input);
                Assert.AreEqual(2, result);
            }

            [TestMethod]
            public void TestNegTwo1()
            {
                Util util = new Util();
                string input = "-2";
                var result = util.Eval(input);
                Assert.AreEqual(-2, result);
            }

            [TestMethod]
            public void TestMod2()
            {
                Util util = new Util();
                string input = "20 % 5";
                var result = util.Eval(input);
                Assert.AreEqual(0, result);
            }

            [TestMethod]
            public void TestMod3()
            {
                Util util = new Util();
                string input = "21 % 5";
                var result = util.Eval(input);
                Assert.AreEqual(1, result);
            }

            [TestMethod]
            public void TestMod4()
            {
                Util util = new Util();
                string input = "22 % 4";
                var result = util.Eval(input);
                Assert.AreEqual(2, result);
            }

            [TestMethod]
            public void TestMod5()
            {
                Util util = new Util();
                string input = "1 + 22 % 4";
                var result = util.Eval(input);
                Assert.AreEqual(3, result);
            }

            [TestMethod]
            public void TestMod6()
            {
                Util util = new Util();
                string input = "(1 + 22) % 4";
                var result = util.Eval(input);
                Assert.AreEqual(3, result);
            }

            [TestMethod]
            public void TestExp1()
            {
                Util util = new Util();
                string input = "2 ^ 2";
                var result = util.Eval(input);
                Assert.AreEqual(4, result);
            }

            [TestMethod]
            public void TestExp2()
            {
                Util util = new Util();
                string input = "2 ^ 3";
                var result = util.Eval(input);
                Assert.AreEqual(8, result);
            }

            [TestMethod]
            public void TestExp3()
            {
                Util util = new Util();
                string input = "2 ^ 4";
                var result = util.Eval(input);
                Assert.AreEqual(16, result);
            }

            [TestMethod]
            public void TestExp4()
            {
                Util util = new Util();
                string input = "10 ^ 10";
                var result = util.Eval(input);
                Assert.AreEqual(1e10, result);
            }

            [TestMethod]
            public void TestExp5()
            {
                Util util = new Util();
                string input = "(2 + 3) ^ 3";
                var result = util.Eval(input);
                Assert.AreEqual(125, result);
            }

            [TestMethod]
            public void TestExp6()
            {
                Util util = new Util();
                string input = "(2 + 3) ^ (3 + 2)";
                var result = util.Eval(input);
                Assert.AreEqual(3125, result);
            }

            [TestMethod]
            public void TestExp7()
            {
                Util util = new Util();
                string input = "-(2 + 3) ^ (3 + 2)";
                var result = util.Eval(input);
                Assert.AreEqual(-3125, result);
            }

            [TestMethod]
            public void TestExp8()
            {
                Util util = new Util();
                string input = "(2 + 3) ^ -(3 + 2)";
                var result = util.Eval(input);
                Assert.AreEqual(0.00032, result);
            }

            [TestMethod]
            public void TestPred1()
            {
                Util util = new Util();
                string input = "1 + 2 * 3 % 4 * 5 / 6 + 2";
                var result = util.Eval(input);
                Assert.AreEqual(8, result);
            }

            [TestMethod]
            public void TestPred2()
            {
                Util util = new Util();
                string input = "1 + 2 % 3 / 4 * 5 + 2";
                var result = util.Eval(input);
                Assert.AreEqual(5.5, result);
            }

            [TestMethod]
            public void TestPred3()
            {
                Util util = new Util();
                string input = "(1 + 2) % 3 / (4 * 5) + 2";
                var result = util.Eval(input);
                Assert.AreEqual(2, result);
            }
        }
    }
}
