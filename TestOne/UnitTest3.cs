using MathOne;

namespace TestOne
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestRoot1()
        {
            Util util = new Util();
            string input = "RT(5, 2)";
            var result = util.Eval(input);
            Assert.AreEqual(2.23606797, result, 1e-5);
        }

        [TestMethod]
        public void TestRoot2()
        {
            Util util = new Util();
            string input = "RT(25, 2)";
            var result = util.Eval(input);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TestRoot3()
        {
            Util util = new Util();
            string input = "RT(6, 3)";
            var result = util.Eval(input);
            Assert.AreEqual(1.817120592, result, 1e-5);
        }

        [TestMethod]
        public void TestCube1()
        {
            Util util = new Util();
            string input = "CB(1.817120592)";
            var result = util.Eval(input);
            Assert.AreEqual(6, result, 1e-5);
        }

        [TestMethod]
        public void TestRoot4()
        {
            Util util = new Util();
            string input = "RT(S(S(6)), 2)";
            var result = util.Eval(input);
            Assert.AreEqual(2.44948974, result, 1e-5);
        }

        [TestMethod]
        public void TestTrig1()
        {
            Util util = new Util();
            string input = "SIN(0.37)";
            var result = util.Eval(input);
            Assert.AreEqual(0.361615, result, 1e-5);
        }

        [TestMethod]
        public void TestTrig2()
        {
            Util util = new Util();
            string input = "SQ(33939)";
            var result = util.Eval(input);
            Assert.AreEqual(1151855721, result);
        }

        [TestMethod]
        public void TestTrig3()
        {
            Util util = new Util();
            string input = "SR(1151855721)";
            var result = util.Eval(input);
            Assert.AreEqual(33939, result);
        }

        [TestMethod]
        public void TestTrig4()
        {
            Util util = new Util();
            string input = "ATAN(TAN(0.3))";
            var result = util.Eval(input);
            Assert.AreEqual(0.3, result);
        }

        [TestMethod]
        public void TestTau1()
        {
            Util util = new Util();
            string input = "TAU()";
            var result = util.Eval(input);
            Assert.AreEqual(6.28318530, result, 1e-6);
        }

        [TestMethod]
        public void TestTau2()
        {
            Util util = new Util();
            string input = "TAU() / 6";
            var result = util.Eval(input);
            Assert.AreEqual(1.047197551, result, 1e-6);
        }

        [TestMethod]
        public void TestMod1()
        {
            Util util = new Util();
            string input = "63 % 2";
            var result = util.Eval(input);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestMod2()
        {
            Util util = new Util();
            string input = "233242 % 5";
            var result = util.Eval(input);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestMod3()
        {
            Util util = new Util();
            string input = "233242 % (1 + 2 + 2)";
            var result = util.Eval(input);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestTrig6()
        {
            Util util = new Util();
            string input = "COS(RAD(33))";
            var result = util.Eval(input);
            Assert.AreEqual(0.838670567, result, 1e-6);
        }

        [TestMethod]
        public void TestTrig7()
        {
            Util util = new Util();
            string input = "ACOS(COS(0.5))";
            var result = util.Eval(input);
            Assert.AreEqual(0.499999999, result, 1e-6);
        }

        [TestMethod]
        public void TestTrig8()
        {
            Util util = new Util();
            string input = "ACOS(COS(0.5) + SIN(0.1))";
            var result = util.Eval(input);
            Assert.AreEqual(0.21292977, result, 1e-6);
        }

        [TestMethod]
        public void TestTrig9()
        {
            Util util = new Util();
            string input = "SQ(COS(0.1)) + SQ(SIN(0.3))";
            var result = util.Eval(input);
            Assert.AreEqual(1.077365481, result, 1e-6);
        }

        [TestMethod]
        public void TestAdv1()
        {
            Util util = new Util();
            string input = "SR(SQ(COS(0.1)) + SQ(SIN(0.3)))";
            var result = util.Eval(input);
            Assert.AreEqual(1.03796272, result, 1e-6);
        }
    }
}
