using Logic;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        private static bool doubleArrayEquals(double[,] arr, double[,] other)
        {
            if (arr.GetLength(0) != other.GetLength(0) ||
                arr.GetLength(1) != other.GetLength(1))
                return false;
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    if (arr[i, j].CompareTo(other[i, j]) != 0)
                        return false;
            return true;
        }



        [Test]
        public void TestSeriesSum()
        {
            double x = 0;
            double res = SeriesCalc.SeriesSum(x);
            double expectedRes = SeriesCalc.FormularCheck(x);
            Assert.That(expectedRes.Equals(res));
        }

        [Test]
        public void TestSeriesSum2()
        {
            double x = -5;
            double res = Math.Round(SeriesCalc.SeriesSum(x), 3);
            double expectedRes = Math.Round(SeriesCalc.FormularCheck(x), 3);
            Assert.That(expectedRes.Equals(res));
        }

        [Test]
        public void TestSeriesSum3()
        {
            double x = 5;
            double res = Math.Round(SeriesCalc.SeriesSum(x), 3);
            double expectedRes = Math.Round(SeriesCalc.FormularCheck(x), 3);
            Assert.That(expectedRes.Equals(res));
        }

        [Test]
        public void TestMakeArrayÑ()
        {
            double[,] Matrix1 = { { 11, 10, 9 }, { 8, 7, 6 }, { 5, 4, 3 } };
            double[] Matrix2 = { 0.005, 0.016, 0.039 };
            double[] res = Arrays.MakeArrayC(Matrix2, Matrix1);
            double[] expectedRes = { 0.566, 0.386, 0.206 };
            Assert.That(expectedRes.SequenceEqual(res));
        }

        [Test]
        public void TestShellSort()
        {
            double[,] Matrix1 = { { 1, 10 }, { 2, 200 }, { 3, 30 } };
            double[,] Matrix2 = { { 1, 10 }, { 3, 30 }, { 2, 200 } };
            double[,] Matrix = Arrays.ShellSort(Matrix1);
            Assert.That(doubleArrayEquals(Matrix, Matrix2));
        }

        [Test]
        public void TestControlArray()
        {
            double x = 0;
            double res = SeriesCalc.FormularCheck(x);
            double expectedRes = 0;
            Assert.That(expectedRes.Equals(res));
        }

        [Test]
        public void TestControlArray2()
        {
            double x = 1;
            double res = Math.Round(SeriesCalc.FormularCheck(x), 9);
            double expectedRes = 0.301168679;
            Assert.That(expectedRes.Equals(res));
        }

        [Test]
        public void TestControlArray3()
        {
            double x = 2;
            double res = Math.Round(SeriesCalc.FormularCheck(x), 9);
            double expectedRes = 1.857771988;
            Assert.That(expectedRes.Equals(res));
        }
    }
}