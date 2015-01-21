using System;

namespace PiedPiper
{
    class Program
    {
        static void Main(string[] args)
        {
            // Should write a nice command line interface / parser. But I haven't yet...


            
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
            var pipes = new[] { 1, 1, 3, 4, 4, 5, 6, 6, 6, 8, 8, 8, 9, 9 };
            var result = BruteForce.Execute(13, pipes);
            Console.WriteLine(result);
        }
    }
}
