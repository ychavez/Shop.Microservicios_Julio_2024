namespace TaskAsync
{
    public class BreakFast
    {

        public static void Run()
        {
            PrdenderCafetera();
            CalentarSarten();
            FreirHuevito();
            FreirTocino();
            TostarPan();
            PonerMermelada();
            Servir();
        }


        public static async Task RunAsync()
        {
            var cafeteraTask = PrdenderCafeteraAsync();
            await CalentarSartenAsnc();

            var huevitoTask = FreirHuevitoAsync();
            var tocinoTask = FreirTocinoAsync();

            await TostarPanAsync();
            var mermelada = PonerMermeladaAsync();



            await cafeteraTask;
            await huevitoTask;
            await tocinoTask;
            await mermelada;
            await ServirAsync();
        }


        public static void ServirMilCafes()
        {
            Parallel.For(0, 1000, new ParallelOptions { MaxDegreeOfParallelism = 12 }
            , async (x, y) =>
            {
                await ServirMilCafesAsync();
            });


        }


        public static async Task ServirMilCafesAsync()
        {
            var semaphore = new SemaphoreSlim(10);

            var clientes = Enumerable.Range(0, 1000);

            List<Task> breakfasts = new List<Task>();


            breakfasts = clientes.Select(async b =>
            {
                await semaphore.WaitAsync();
                try
                {
                    await CafeeAsync();
                }
                finally
                {
                    semaphore.Release();
                }
            }).ToList();
 
          await  Task.WhenAll(breakfasts);

        }

        private static async Task CafeeAsync() 
        {
            await PrdenderCafeteraAsync();
            await ServirAsync();
        }


        private static void CalentarSarten()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Sarten caliente");
        }

        private static void PrdenderCafetera()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Cafe listo");
        }

        private static void FreirHuevito()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Huevito Listo");
        }

        private static void FreirTocino()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Tocino Listo");
        }

        private static void TostarPan()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Pan Listo");
        }

        public static void PonerMermelada()
        {

            Thread.Sleep(1000);
            Console.WriteLine("Pan con mermelada Listo");
        }

        private static void Servir()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Servido");
        }




        private static async Task CalentarSartenAsnc()
        {
            await Task.Delay(1000);
            Console.WriteLine("Sarten caliente");
        }

        private static async Task PrdenderCafeteraAsync()
        {
            await Task.Delay(1000);
            Console.WriteLine("Cafe listo");
        }

        private static async Task FreirHuevitoAsync()
        {
            await Task.Delay(1000);
            Console.WriteLine("Huevito Listo");
        }

        private static async Task FreirTocinoAsync()
        {
            await Task.Delay(1000);
            Console.WriteLine("Tocino Listo");
        }

        private static async Task TostarPanAsync()
        {
            await Task.Delay(1000);
            Console.WriteLine("Pan Listo");
        }

        public static async Task PonerMermeladaAsync()
        {

            await Task.Delay(1000);
            Console.WriteLine("Pan con mermelada Listo");
        }

        private static async Task ServirAsync()
        {
            await Task.Delay(1000);
            Console.WriteLine("Servido");
        }


    }
}
