namespace PiedPiper
{
    class Program
    {
        static void Main(string[] args)
        {
//            var pipes = new[] { 7, 3, 3, 3, 2, 2, 2 };
//            BruteForce.RunBruteForce(11, pipes, true);

            var pipes = new[] { 1, 1, 3, 4, 4, 5, 6, 6, 6, 8, 8, 8, 9, 9 };
            BruteForce.RunBruteForce(13, pipes, false);
        }
    }
}
