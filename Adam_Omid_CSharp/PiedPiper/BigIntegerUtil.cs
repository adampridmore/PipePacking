using System.Numerics;

namespace PiedPiper
{
    public static class BigIntegerUtil
    {
        public static BigInteger Factorial(this BigInteger number)
        {
            var cumulator = new BigInteger(1);
            for (var i = 1; i <= number; i++)
            {
                cumulator *= i;
            }

            return cumulator;
        }
    }
}
