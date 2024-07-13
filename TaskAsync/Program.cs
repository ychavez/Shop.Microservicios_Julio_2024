using System.Diagnostics;

namespace TaskAsync
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
           await BreakFast.ServirMilCafesAsync();
            stopWatch.Stop();
            Console.WriteLine($"async: Pasaron {stopWatch.ElapsedMilliseconds} milisegundos");


            //stopWatch = new Stopwatch();
            //stopWatch.Start();
            //BreakFast.Run();
            //stopWatch.Stop();
            //Console.WriteLine($"normal: Pasaron {stopWatch.ElapsedMilliseconds} milisegundos");
        }
    }

}
