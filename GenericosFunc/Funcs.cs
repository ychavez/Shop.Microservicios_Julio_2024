namespace GenericosFunc
{
    internal class Funcs
    {
        public static int CalculadoraDeEdad(int anio)
        {
            return DateTime.Today.Year - anio;
        }


        public static void Run()
        {
            var result = IsPalindrome("AnitaLavaLaTina", (x,y) => x.ToLower() == x.ToLower().Reverse());
            var result2 = IsPalindrome("Anita Lava La Tina", palindrome);

            List<string> lista = new();
            
        }

        //genera una funcion
        //que reciba un string y regrese un boleano si es un palindromo
        //sin usar reverse
       static bool palindrome(string palabra, string palabra2)
        {
            var palabraMinuscula = palabra.ToLower();
            var palabraSinEspacios = palabraMinuscula.Replace(" ", "");
            var palabraInvertida = "";
            for (int i = palabraSinEspacios.Length - 1; i >= 0; i--)
            {
                palabraInvertida += palabraSinEspacios[i];
            }
            return palabraSinEspacios == palabraInvertida;

        }


        //anita lava la tina Ok
        // anitalavalatina OK
        // AniTaLAvALaTina Ok
        // An i T aL A1 v A L aT in a Ok
        public static bool IsPalindrome(string palabra, Func<string,string,bool> func)
        {
            return func(palabra,"Hola");
        }
    }
}
