using MathOne;

namespace TestOne
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void TestCdf1()
        {
            double x = Util.CumDensity(-3);
            double y = Util.Phi(-3);
            double z = Util.Gauss(-3);
            Assert.AreEqual(0.00134989803163, x, 1e-6);
            Assert.AreEqual(0.00134989803163, y, 1e-6);
            Assert.AreEqual(0.00134989803163, z, 1e-8);
        }

        [TestMethod]
        public void TestCdf2()
        {
            double x = Util.CumDensity(-1);
            double y = Util.Phi(-1);
            double z = Util.Gauss(-1);
            Assert.AreEqual(0.158655253931, x, 1e-6);
            Assert.AreEqual(0.158655253931, y, 1e-6);
            Assert.AreEqual(0.158655253931, z, 1e-8);
        }

        [TestMethod]
        public void TestCdf3()
        {
            double x = Util.CumDensity(0);
            double y = Util.Phi(0);
            double z = Util.Gauss(0);
            Assert.AreEqual(0.5, x, 1e-6);
            Assert.AreEqual(0.5, y, 1e-6);
            Assert.AreEqual(0.5, z, 1e-8);
        }


        [TestMethod]
        public void TestCdf4()
        {
            double x = Util.CumDensity(0.5);
            double y = Util.Phi(0.5);
            double z = Util.Gauss(0.5);
            Assert.AreEqual(0.691462461274, x, 1e-6);
            Assert.AreEqual(0.691462461274, y, 1e-6);
            Assert.AreEqual(0.691462461274, z, 1e-8);
        }

        [TestMethod]
        public void TestCdf5()
        {
            double x = Util.CumDensity(2.1);
            double y = Util.Phi(2.1);
            double z = Util.Gauss(2.1);
            Assert.AreEqual(0.982135579437, x, 1e-6);
            Assert.AreEqual(0.982135579437, y, 1e-6);
            Assert.AreEqual(0.982135579437, z, 1e-8);
        }

    }
}
