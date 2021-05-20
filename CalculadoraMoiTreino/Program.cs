using System;

namespace CalculadoraMoiTreino
{
    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op)
                            
        {
            double result = double.NaN; /* O valor padrão é "não um número",
                                           que usamos se uma operação,
                                           como divisão, pode resultar em erro.*/

            // Use uma instrução switch para fazer as contas.
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    // Peça ao usuário para inserir um divisor diferente de zero.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                // Retorne o texto para uma entrada de opção incorreta.
                default:
                    break;
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // Exibe o título como o aplicativo de calculadora do console C #.
            Console.WriteLine("Calculadora em C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                // Peça ao usuário para digitar o primeiro número.
                Console.Write("Digite um número e pressione Enter: ");
                
                //Declare variáveis e defina como vazio.
                string numInput1 = Console.ReadLine();

                double cleanNum1;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("Esta não é uma entrada válida. Insira um valor inteiro: ");
                    numInput1 = Console.ReadLine();
                }

                // Peça ao usuário para digitar o segundo número.
                Console.Write("Digite outro número e pressione Enter: ");
                string numInput2 = Console.ReadLine();

                double cleanNum2;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("Esta não é uma entrada válida. Insira um valor inteiro: ");
                    numInput2 = Console.ReadLine();
                }

                // Peça ao usuário para escolher uma operação.
                Console.WriteLine("Qual operação você deseja realizar? ");
                Console.WriteLine("\ta - Adição");
                Console.WriteLine("\ts - Subtração");
                Console.WriteLine("\tm - Multiplicação");
                Console.WriteLine("\td - Divisão");
                Console.Write("Escolha uma opção? ");

                string op = Console.ReadLine();

                try
                {
                    double result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("Esta operação resultará em um erro matemático.\n");
                    }
                    else Console.WriteLine("Seu resultado é: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocorreu de exceção ao tentar fazer as contas.\n - Detalhes: " + e.Message);
                }
                Console.WriteLine("------------------------\n");

                // Aguarde a resposta do usuário antes de fechar.
                Console.Write("Pressione 'n' e Enter para fechar o aplicativo ou qualquer outra tecla e Enter para continuar: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
            }
            return;
        }
    }
}