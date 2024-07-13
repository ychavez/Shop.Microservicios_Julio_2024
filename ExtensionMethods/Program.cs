namespace ExtensionMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MisFunciones misFunciones = new();
            misFunciones.MyProperty = 21;

            Console.WriteLine("Yael".ToSaludo());
            Console.WriteLine($"Jose {misFunciones.Numero()}");
            Console.WriteLine(misFunciones.ExtenderFuncion());


            var a = "hola".ToSaludo();
        }
    }

   
}
