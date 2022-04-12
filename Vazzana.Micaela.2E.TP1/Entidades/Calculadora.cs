using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida que el operador recibido sea +,-,*,/
        /// </summary>
        /// <param name="operador">Caracter a validar</param>
        /// <returns>Retorna el operador, si no fuera ninguno de los contemplados retorna +</returns>
        private static char ValidarOperador(char operador)
        {
            switch (operador)
            {
                case '+':
                    return '+';
                case '-':
                    return '-';
                case '*':
                    return '*';
                case '/':
                    return '/';
            }
            return '+';
        }
        /// <summary>
        /// Realiza la operacion matematica elegida de los dos numeros de cada objeto recibido 
        /// </summary>
        /// <param name="numero1">Objeto de tipo Operando</param>
        /// <param name="numero2">Objeto de tipo Operando</param>
        /// <param name="operador">Operador aritmetico elegido</param>
        /// <returns>Retorna la operacion realizada entre los numeros, si no fuera ninguno de los casos contemplados retorna la suma de los numeros</returns>        
        public static double Operar(Operando numero1, Operando numero2, char operador)
        {
            switch (ValidarOperador(operador))
            {
                case '+':
                    return numero1 + numero2;
                case '-':
                    return numero1 - numero2;
                case '*':
                    return numero1 * numero2;
                case '/':
                    return numero1 / numero2;
            }
            return numero1 + numero2;
        }
    }
}
