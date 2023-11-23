namespace EncriptarMensajes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Que cadena quieres encriptar?");
            string cadena = Console.ReadLine();

            Console.WriteLine();

            string cadEncriptada = EncriptarCadena(cadena);

            // string cadEncriptada = EncriptarMensaje(cadena);


            Console.WriteLine($"Cadena encriptada: {cadEncriptada}");

            string cadenaDesencriptada = DesencriptarCadena(cadEncriptada);
            Console.WriteLine();
            Console.WriteLine($"Cadena desencriptada: {cadenaDesencriptada}");
        }

        //static string EncriptarMensaje(string cadena)
        //{
        //    string cadenaEncriptada = "";
        //    for (int i = 0; i < cadena.Length; i++)
        //    {
        //        char letra = cadena[i]; //h
        //        int letraASCII = (int)letra; //104 int
        //        string numString = letraASCII.ToString(); // convertir 104 a string para poder tomar el 1 y ultimo valor

        //        string num1 = numString[0].ToString(); // primer numero 1
        //        string num2 = numString[numString.Length - 1].ToString(); // ultimo numero 4

        //        string concat = (num1 + num2); // concatenar el primer y ultimo numero (14)

        //        int firstLetter = int.Parse(numString) + int.Parse(num2); // sacar la primera letra para la encript sumando el numero base 104 + el segundo numero (4) --> 108
        //        int endLetter = int.Parse(numString) - int.Parse(num1); // sacar la segunda letra para la encript restando el numero base 104 - el primer numero (1) --> 103

        //        char firstChar = (char)firstLetter; // sacar letra del 108 --> l
        //        char endChar = (char)endLetter; // sacar letra del 103 --> g

        //        string firstCad = firstChar.ToString() + concat + endChar; // concatenar todo --> l 14 g


        //        cadenaEncriptada += firstCad; // ir concatenando todas las letras encriptadas --> l14g
        //    }
        //    return cadenaEncriptada;
        //}


        static string EncriptarCadena(string cadena)
        {
            string cadEncriptada = "";

            for (int i = 0; i < cadena.Length; i++)
            {
                char letra = cadena[i];
                int letraASCII = ObtenerCodigoAscii(letra);
                string numString = ObtenerNumString(letraASCII);

                string concat = ConcatenarNumeros(numString);

                int firstLetter = CalcularPrimeraLetra(letraASCII, numString);
                int endLetter = CalcularSegundaLetra(letraASCII, numString);

                char firstChar = ObtenerCaracter(firstLetter);
                char endChar = ObtenerCaracter(endLetter);

                string firstCad = ConcatenarLetras(firstChar, concat, endChar);

                cadEncriptada += firstCad;
            }

            return cadEncriptada;
        }

        static int ObtenerCodigoAscii(char letra)
        {
            return (int)letra;
        }

        static string ObtenerNumString(int codigoAscii)
        {
            return codigoAscii.ToString();
        }

        static string ConcatenarNumeros(string numString)
        {
            return numString[0].ToString() + numString[numString.Length - 1].ToString();
        }

        static int CalcularPrimeraLetra(int codigoAscii, string numString)
        {
            return codigoAscii + int.Parse(numString[numString.Length - 1].ToString());
        }

        static int CalcularSegundaLetra(int codigoAscii, string numString)
        {
            return codigoAscii - int.Parse(numString[0].ToString());
        }

        static char ObtenerCaracter(int numero)
        {
            return (char)numero;
        }

        static string ConcatenarLetras(char firstChar, string concat, char endChar)
        {
            return firstChar.ToString() + concat + endChar.ToString();
        }

        // ----------------------- DESENCRIPTAR ---------------------------------------------------------------------------------------
        static string DesencriptarCadena(string cadenaEncriptada)
        {
            string cadenaDesencriptada = "";

            for (int i = 0; i < cadenaEncriptada.Length; i += 4)
            {
                char firstChar = cadenaEncriptada[i];
                string concat = cadenaEncriptada.Substring(i + 1, 2);
                char endChar = cadenaEncriptada[i + 3];

                int firstLetter = (int)firstChar;
                int endLetter = (int)endChar;

                int codigoAscii = (firstLetter - int.Parse(concat[1].ToString()));
                char letraOriginal = (char)codigoAscii;

                cadenaDesencriptada += letraOriginal;
            }

            return cadenaDesencriptada;
        }
    }
}