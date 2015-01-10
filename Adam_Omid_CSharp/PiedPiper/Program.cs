using System;

namespace PiedPiper
{
    class Program
    {
        static void Main(string[] args)
        {
             var pipes = new[] { 7, 3, 3, 3, 2, 2, 2 };
            var result = BruteForce.Execute2(11, pipes);
            Console.WriteLine(result);

//            var pipes = new[] { 2, 2, 3, 4, 4, 5 };
//            BruteForce.Execute(11, pipes, true);

//A Best Solution for pipes 1,1,3,4,4,5,6,6,6,8,8,8,9,9 and bin size 13
//Number of bin solution counts: (0-0)(1-0)(2-0)(3-0)(4-0)(5-0)(6-0)(7-210,445,064)(8-92,202,748)(9-54,588)(10-0)(11-0)(12-0)(13-0)
//Number of bins: 7
//1,1,3,6 - (2)
//4,8 - (1)
//4,8 - (1)
//5,8 - (0)
//6,6 - (1)
//9 - (4)
//9 - (4)
//Solutions tried: 302,702,400, Duration 936.9149753s:
//            var pipes = new[] { 1, 1, 3, 4, 4, 5, 6, 6, 6, 8, 8, 8, 9, 9 };
//            BruteForce.Execute(13, pipes, false);

//A Best Solution:
//Number of bins: 3
//2,2,2,3,3,3,6
//4,4,4,5,5
//5,5,6,6
//Solutions tried: 672672000, Duration 1374.9416846s:
//Press any key to continue . . .
//            var pipes = new[] { 2,2,2,3,3,3,4,4,4,5,5,5,5,6,6,6 };
//            BruteForce.Execute(22, pipes, false);
        }
    }
}
