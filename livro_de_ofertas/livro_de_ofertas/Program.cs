using System;
using System.Globalization;

public class Program
{
    public static void Main()
    {
        int numNotificacoes = int.Parse(Console.ReadLine());
        Livro[] livroDeOfertas = new Livro[0];

        for (int i = 0; i < numNotificacoes; i++)
        {
            string[] notificacao = Console.ReadLine().Split(',');
            int posicao = int.Parse(notificacao[0]);
            int acao = int.Parse(notificacao[1]);
            double valor = double.Parse(notificacao[2]);
            int quantidade = int.Parse(notificacao[3]);

            livroDeOfertas = ProcessarNotificacao(livroDeOfertas, posicao, acao, valor, quantidade);
        }

        ImprimirLivroDeOfertas(livroDeOfertas);
    }

    static Livro[] ProcessarNotificacao(Livro[] livroDeOfertas, int posicao, int acao, double valor, int quantidade)
    {
        if (acao == 0)
        {
            return InserirOferta(livroDeOfertas, posicao, valor, quantidade);
        }
        else if (acao == 1)
        {
            return ModificarOferta(livroDeOfertas, posicao, valor, quantidade);
        }
        else if (acao == 2)
        {
            return RemoverOferta(livroDeOfertas, posicao);
        }
        else
        {
            Console.WriteLine("Ação inválida.");
            return livroDeOfertas;
        }

    }

    static Livro[] InserirOferta(Livro[] livroDeOfertas, int posicao, double valor, int quantidade)
    {
        if (posicao != 1 && posicao == livroDeOfertas[livroDeOfertas.Length - 1].Posicao)
        {
            ModificarOferta(livroDeOfertas, posicao, valor, quantidade);
            return livroDeOfertas;
        }

        Livro novaOferta = new Livro(posicao, valor, quantidade);

        Array.Resize(ref livroDeOfertas, livroDeOfertas.Length + 1);
        livroDeOfertas[livroDeOfertas.Length - 1] = novaOferta;

        return livroDeOfertas;
    }

    static Livro[] ModificarOferta(Livro[] livroDeOfertas, int posicao, double valor, int quantidade)
    {
        int index = Array.FindIndex(livroDeOfertas, oferta => oferta.Posicao == posicao);

        if (index != -1)
        {
            if (valor != 0)
                livroDeOfertas[index].Valor = valor;
            if (quantidade != 0)
                livroDeOfertas[index].Quantidade = quantidade;
        }

        return livroDeOfertas;
    }

    static Livro[] RemoverOferta(Livro[] livroDeOfertas, int posicao)
    {
        if (posicao != 1 && posicao > livroDeOfertas[livroDeOfertas.Length - 1].Posicao) 
        {
            return livroDeOfertas;
        }

        Livro[] novoVetor = new Livro[livroDeOfertas.Length - 1];

        if (posicao == 1) 
        {
            for (int i = 1; i <= livroDeOfertas.Length - 1; i++)
            {
                Livro novaOferta = new Livro(i, livroDeOfertas[i].Valor, livroDeOfertas[i].Quantidade);
                novoVetor[i - 1] = novaOferta;
            }
        }
        else 
        {
            for (int i = 0; i <= posicao - 2; i++)
            {
                Livro novaOferta = new Livro(i, livroDeOfertas[i].Valor, livroDeOfertas[i].Quantidade);
                novoVetor[i] = novaOferta;
            }
            for (int i = posicao; i < posicao; i++)
            {
                Livro novaOferta = new Livro(i, livroDeOfertas[i].Valor, livroDeOfertas[i].Quantidade);
                novoVetor[i] = novaOferta;
            }
        }

        livroDeOfertas = novoVetor;

        return livroDeOfertas;
    }


    static void ImprimirLivroDeOfertas(Livro[] livroDeOfertas)
    {
        Console.WriteLine();

        for (int i = 0; i <= livroDeOfertas.Length - 1; i++)
        {
            if (i < livroDeOfertas.Length - 1)
            {
                Console.WriteLine($"{livroDeOfertas[i].Posicao},{livroDeOfertas[i].Valor},{livroDeOfertas[i].Quantidade}");
            }
            else
            {
                Console.Write($"{livroDeOfertas[i].Posicao},{livroDeOfertas[i].Valor},{livroDeOfertas[i].Quantidade}\\\n");
            }
        }


    }
}

class Livro
{
    public int Posicao { get; set; }
    public double Valor { get; set; }
    public int Quantidade { get; set; }

    public Livro(int posicao, double valor, int quantidade)
    {
        Posicao = posicao;
        Valor = valor;
        Quantidade = quantidade;
    }
}