using System;
using DI;
using Dtos;
using Entitys;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace TecnhicalChallenge.console
{
    public static class Program
    {
        private static IDivisorService _divisorService;

        public static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            var serviceProvider = NativeInjectorBootstrapper.GetProvider(serviceCollection);

            _divisorService = serviceProvider.GetService<IDivisorService>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opçao:");
                Console.WriteLine("1 - Calcular todos os divisores que compõem um número");
                Console.WriteLine("2 - Calcular todos os divisores primos que compõem um número");
                Console.WriteLine("3 - Sair");
                Console.Write("\nDigite a opção desejada: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine($"\nVocê selecionou 'Calcular todos os divisores que compõem um número'");
                        CalcDivisor(false);
                        break;
                    case "2":
                        Console.WriteLine($"\nVocê selecionou 'Calcular divisores primos que compoem um número'.");
                        CalcDivisor(true);
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }


        private static string GetUserEntry()
        {
            Console.Write("\nDigite o número para  realizar o calculo: ");
            return Console.ReadLine();
        }

        private static void PrintResult(string mensagem)
        {
            Console.WriteLine($"\n{mensagem}");
            Console.WriteLine("\nPressione uma tecla para voltar ao Menu. . .");
            Console.ReadLine();
        }

        private static void CalcDivisor(bool prime)
        {
            try
            {
                var userEntry = GetUserEntry();
                if (!int.TryParse(userEntry, out int number) || number <= 0)
                { 
                    PrintResult($"O valor digitado não é válido. Valor digitado: {number}");
                    return;
                }
                              
                DivisorEntity divisor = new DivisorEntity
                {
                    Number = number,
                    Prime = prime,
                };

                DivisorDto result = _divisorService.CalcDivisor(divisor);
                if (result.Ok)
                {
                    string separator = "-";
                    PrintResult($"O Resultado obtido foi: {string.Join(separator, result.Divisors)}");
                }
                else
                {
                    PrintResult($"{result.Error}");
                }
            }
            catch (Exception ex)
            {
                PrintResult($"Ocorreu um erro: {ex.Message}");                
            }
        }    
    }
}
