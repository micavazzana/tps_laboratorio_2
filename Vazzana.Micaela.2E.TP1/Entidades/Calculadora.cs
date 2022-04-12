using System;

namespace Entidades
{
    public static class Calculadora
    {
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
