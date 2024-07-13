namespace ExtensionMethods
{
    public static class StringExtensions
    {
        /// <summary>
        /// Este metodo le agrega un saludo a la persona que queiras
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public static string ToSaludo(this string nombre)
            => $"Hola {nombre} Esto es un saludo!";


        public static string ExtenderFuncion(this MisFunciones misFunciones)
          => $"Esto es una extension {misFunciones.MyProperty}";

    }
}
