using System;

namespace MenorDistanciaArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = { -1, 5, 11, 20, 35, 50, 65, 70, 85, 100 };
            int[] array2 = { 26, 6, 14, 29, 37, 41, 55, 75, 80, 90 };

            int menorDistancia = EncontrarMenorDistancia(array1, array2, out int num1, out int num2);

            Console.WriteLine($"A menor distância é {menorDistancia}! Entre os números: {num1} do array 1 e {num2} do array 2.");
        }

        static int EncontrarMenorDistancia(int[] array1, int[] array2, out int num1, out int num2)
        {
            int menorDistancia = int.MaxValue;
            num1 = 0;
            num2 = 0;

            for (int i = 0; i < array1.Length; i++)
            {
                for (int j = 0; j < array2.Length; j++)
                {
                    int distancia = Math.Abs(array1[i] - array2[j]);

                    if (distancia < menorDistancia)
                    {
                        menorDistancia = distancia;
                        num1 = array1[i];
                        num2 = array2[j];
                    }
                }
            }

            return menorDistancia;
        }
    }
}
