
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System;
using System.Net.NetworkInformation;


public class Ponto
{
    public int x { get; set; }
    public int y { get; set; }
}

public class Planeta
{
    public string nome { get; set; }
}









class MainClass
{

    const int TAM = 100;
    const int TAM_v = 20000000;



    public static void ContaVetor(int[] list, int num)
    {
        int cont = 0;
        for (int i = 0; i < TAM_v; i++)
        {
            if (list[i] == num)
            {

                i = TAM_v;
                Console.WriteLine(">>>PESQUISA SEQUENCIAL<<<");
                Console.WriteLine("Encontrado com {0} saltos", cont);
                Console.WriteLine();
            }
            cont++;

        }

    }

    public static void ContaVetorBinario(int[] list, int num)
    {
        int cont = 0;
        int dir = list.Length, esq = 0, meio;
        while (esq <= dir)
        {
            meio = (esq + dir) / 2;
            cont++;
            if (num == list[meio])
            {
                Console.WriteLine(">>>PESQUISA BINARIA<<<");
                Console.WriteLine("Encontrado com {0} saltos", cont);
                esq = list.Length;
            }
            else if (num > list[meio])
            {
                esq = meio + 1;
            }
            else
            {
                dir = meio - 1;
            }
        }

    }

    public static void Main(string[] args)
    {

        Ponto[] pontos = new Ponto[TAM];

        for (int i = 0; i < TAM; i++)
        {
            Ponto pt = new Ponto { x = new Random().Next(100, 300), y = new Random().Next(500, 800) };
            pontos[i] = pt;
        };


        Planeta[] planetas = {
            new Planeta {nome = "Terra"},
            new Planeta {nome = "Marte"},
            new Planeta {nome = "Venus"},
            new Planeta {nome = "Mercurio"},
            new Planeta {nome = "Saturno"},
            new Planeta {nome = "Jupiter"},
            new Planeta {nome = "Urano"},
            new Planeta {nome = "Netuno"}
        };



        // Console.WriteLine(Array.Find(pontos, p => p.x * p.y > 100500));

        Ponto[] result = Array.FindAll(pontos, p => p.x * p.y > 200500);

        foreach (Ponto p in result)
        {
            // Console.WriteLine("Meus pontos: {0}, {1}",p.x, p.y);
        }


        // Console.WriteLine("Existe planeta com 'M'? - R: {0}", Array.Exists(planetas, p => p.nome.StartsWith("M")));


        Planeta[] planetas_result = Array.FindAll(planetas, p => p.nome.StartsWith("M"));

        // Console.WriteLine("Quais os planetas com 'M'?");
        // Console.Write("Resposta: ");

        foreach (Planeta p in planetas_result)
        {
            //Console.Write("{0}, ", p.nome);
        }





        Console.WriteLine("Digite um numero: ");
        int num = Int32.Parse(Console.ReadLine());

        int[] vetor = new int[TAM_v];

        for (int i = 0; i < TAM_v; i++)
        {
            vetor[i] = new Random().Next(1, 5000);
        }

        ContaVetor(vetor, num);
        Array.Sort(vetor);

        
        ContaVetorBinario(vetor, num);

        Console.WriteLine("<<<BINARY SEARCH NATIVO>>>");
        Console.WriteLine(Array.BinarySearch(vetor, num));




    }
}