namespace GenericosFunc
{
    public class Genericos
    {

        public static void Run()
        {

            var a = SaludarSerVivo(new Mascota()
            {
                Nombre = "Firulais",
                Apellido = "Chavez"
            });

            var b = SaludarSerVivo(new Ingeniero()
            {
                Nombre = "Yael",
                Apellido = "Chavez", 
                DNI = 123456
            });
           
            
        }

        public static string Funcion<T>()
        {
            T variable;
            return "Hola mundo";
        }


        public static string SaludarSerVivo<T>(T serVivo) where T : ISerVivo
        {
            return $"Hola {serVivo.Nombre} {serVivo.Apellido}";
        }

        public class Persona : ISerVivo
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public int DNI { get; set; }
        }

        public class Ingeniero : Persona
        {
            public int Proyectos { get; set; }
        }

        public class Mascota : ISerVivo
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Raza { get; set; }
        }

        public interface ISerVivo
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
        }

    }
}
