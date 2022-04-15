using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        /// <summary>
        /// Setea el numero validandolo previamente
        /// </summary>
        private string Numero
        {
            set 
            { 
                this.numero = ValidarOperando(value); 
            }
        }
        /// <summary>
        /// Constructor por defecto, setea el valor 0
        /// </summary>
        public Operando() : this(0)
        {
        }
        /// <summary>
        /// Constructor que setea el valor enviado
        /// </summary>
        /// <param name="numero">Valor a ser asignado</param>
        public Operando(double numero) 
        {
            this.numero = numero;
        }
        /// <summary>
        /// Constructor que setea el valor enviado
        /// </summary>
        /// <param name="strNumero">Valor a ser asignado</param>
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }
        /// <summary>
        /// Valida que la cadena enviada sea numerica
        /// </summary>
        /// <param name="strNumero">Cadena a validar</param>
        /// <returns>Si fue numerico retorna el numero, caso contrario retorna 0</returns>
        private double ValidarOperando(string strNumero)
        {
            double numeroAuxiliar;
            if(double.TryParse(strNumero, out numeroAuxiliar))
            {
                return numeroAuxiliar;
            }
            return 0;
        }
        /// <summary>
        /// Valida que la cadena contenga solo 0 y 1 para saber si es binario
        /// </summary>
        /// <param name="binario">Cadena a validar</param>
        /// <returns>True si es binario, caso contrario false</returns>
        private bool EsBinario(string binario)
        {
            bool retorno = false;
            foreach (char caracter in binario)
            {
                if(caracter == '0' || caracter == '1')
                {
                    retorno = true;
                }
                else
                {
                    return false;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Realiza la conversion de un numero binario a uno decimal
        /// </summary>
        /// <param name="strBinario">Cadena que contiene el numero binario</param>
        /// <returns>El numero convertido, si no es binario devuelve "valor invalido"</returns>
        public string BinarioDecimal(string strBinario)
        {
            int numero = 0;
            int largoCadena = strBinario.Length-1;
            if (EsBinario(strBinario))
            {
                foreach (char caracter in strBinario)
                {
                    if(caracter == '1')
                    {
                        numero += (int)Math.Pow(2, largoCadena);
                    }//Si en cambio es 0 no hago nada porque acumularia 0
                    largoCadena--;
                }
                return numero.ToString();
            }
            return "Valor inválido";
        }
        /// <summary>
        /// Realiza la conversion de un numero decimal a uno binario
        /// </summary>
        /// <param name="strNumero">Cadena que contiene el numero decimal</param>
        /// <returns>Cadena con el numero convertido, o "valor invalido" si no pudo convertirlo</returns>
        public string DecimalBinario(string strNumero)
        { 
            double numero;
            bool resultadoConversion = double.TryParse(strNumero, out numero);
            int numeroEntero = (int)numero;
            StringBuilder stringAuxiliar = new StringBuilder();
            if (resultadoConversion)
            {
                do
                {
                    if (numeroEntero % 2 == 0)
                    {
                        stringAuxiliar.Insert(0, "0");
                    }
                    else
                    {
                        stringAuxiliar.Insert(0, "1");
                    }
                    numeroEntero = numeroEntero / 2;
                } while (numeroEntero != 0) ;
                return stringAuxiliar.ToString();
            }
            return "Valor inválido";
        }/// <summary>
         /// Realiza la conversion de un numero decimal a uno binario
         /// </summary>
         /// <param name="numero">valor numerico que contiene el numero decimal</param>
         /// <returns>Cadena con el numero convertido, o "valor invalido" si no pudo convertirlo</returns>
        public string DecimalBinario(double numero)
        {
            return DecimalBinario(numero.ToString());
        }
        /// <summary>
        /// Sobrecarga del operador +. Suma el atributo numero de cada Objeto recibido
        /// </summary>
        /// <param name="numero1">Objeto de tipo Operando</param>
        /// <param name="numero2">Objeto de tipo Operando</param>
        /// <returns>La suma de los numeros</returns>
        public static double operator +(Operando numero1, Operando numero2)
        {
            return numero1.numero + numero2.numero;
        }
        /// <summary>
        /// Sobrecarga del operador -. Resta el atributo numero de cada Objeto recibido
        /// </summary>
        /// <param name="numero1">Objeto de tipo Operando</param>
        /// <param name="numero2">Objeto de tipo Operando</param>
        /// <returns>La resta de los numeros</returns>
        public static double operator -(Operando numero1, Operando numero2)
        {
            return numero1.numero - numero2.numero;
        }
        /// <summary>
        /// Sobrecarga del operador *. Multiplica el atributo numero de cada Objeto recibido
        /// </summary>
        /// <param name="numero1">Objeto de tipo Operando</param>
        /// <param name="numero2">Objeto de tipo Operando</param>
        /// <returns>La multiplicación de los numeros</returns>
        public static double operator *(Operando numero1, Operando numero2)
        {
            return numero1.numero * numero2.numero;
        }
        /// <summary>
        /// Sobrecarga del operador /. Divide el atributo numero de cada Objeto recibido
        /// </summary>
        /// <param name="numero1">Objeto de tipo Operando</param>
        /// <param name="numero2">Objeto de tipo Operando</param>
        /// <returns>Si el numero del segundo objeto es distinto a 0 devuelve la division de los numeros, caso contrario devuelve el valor minimo de un Double</returns>
        public static double operator /(Operando numero1, Operando numero2)
        {
            if(numero2.numero != 0)
            {
                return numero1.numero / numero2.numero;
            }
            return double.MinValue;
        }
    }
}
