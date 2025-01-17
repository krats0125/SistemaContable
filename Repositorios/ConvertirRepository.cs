using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaContable.Repositorios
{
    public class ConvertirRepository
    {
        private static readonly string[] Unidades = { "", "", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "diez", "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve" };
        private static readonly string[] Decenas = { "", "", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };
        private static readonly string[] Centenas = { "", "cien", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos" };

        public static string ConvertirNumeroALetras(decimal numero)
        {
            if (numero == 0)
                return "cero";

            if (numero < 0)
                return "menos " + ConvertirNumeroALetras(Math.Abs(numero));

            string letras = "";

            int millones = (int)(numero / 1000000);
            numero %= 1000000;
            if (millones > 0)
                letras += ConvertirCentenas(millones) + " millón" + (millones > 1 ? "es " : " ");

            int miles = (int)(numero / 1000);
            numero %= 1000;
            if (miles > 0)
                letras += ConvertirCentenas(miles) + " mil ";

            int unidades = (int)numero;
            if (unidades > 0)
                letras += ConvertirCentenas(unidades);

            return letras.Trim() + " pesos";
        }

        private static string ConvertirCentenas(int numero)
        {
            if (numero == 0)
                return "";

            if (numero < 20)
                return Unidades[numero];

            if (numero < 100)
                return Decenas[numero / 10] + (numero % 10 > 0 ? " y " + Unidades[numero % 10] : "");

            if (numero < 1000)
                return Centenas[numero / 100] + (numero % 100 > 0 ? " " + ConvertirCentenas(numero % 100) : "");

            return "";
        }

    }
}
