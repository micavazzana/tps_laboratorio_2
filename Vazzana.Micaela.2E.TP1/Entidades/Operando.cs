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

        private string Numero
        {
            set 
            { 
                this.numero = ValidarOperando(value); 
            }
        }
        public Operando()
        {
            this.numero = 0;
        }
        public Operando(double numero)
        {
            this.Numero = numero.ToString();
        }
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }
        private double ValidarOperando(string strNumero)
        {
            double numeroAuxiliar;
            if(double.TryParse(strNumero, out numeroAuxiliar))
            {
                return numeroAuxiliar;
            }
            return 0;
        }
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
            return "Valor invalido";
        }
        public string DecimalBinario(string strNumero)
        {
            int numero;
            StringBuilder stringAuxiliar = new StringBuilder();
            if(int.TryParse(strNumero, out numero))
            {
                do
                {
                    if (numero % 2 == 0)
                    {
                        stringAuxiliar.Insert(0, "0");
                    }
                    else
                    {
                        stringAuxiliar.Insert(0, "1");
                    }
                    numero = numero / 2;
                } while (numero != 0) ;
                return stringAuxiliar.ToString();
            }
            return "Valor invalido";
        }
        public string DecimalBinario(double numero)
        {
            return DecimalBinario(numero.ToString());
        }
        public static double operator +(Operando numero1, Operando numero2)
        {
            return numero1.numero + numero2.numero;
        }
        public static double operator -(Operando numero1, Operando numero2)
        {
            return numero1.numero - numero2.numero;
        }
        public static double operator *(Operando numero1, Operando numero2)
        {
            return numero1.numero * numero2.numero;
        }
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
