using System;
using System.Runtime.CompilerServices;

public class Usuario : IComparable
{
    public string nome { get; set; }
    public int matricula { get; set; }

    public int CompareTo(object obj)
    {
        if (obj is Usuario)
        {
            return this.matricula.CompareTo((obj as Usuario).matricula);
        }
        throw new ArgumentException("Object is not a Usuario");
    }
}


class MainClass
{
    const int TAM = 16;

    public static int[] populaLista(int[] mylist)
    {
        for (int i = 0; i < TAM; i++)
        {
            mylist[i] = new Random().Next(TAM);
        }

        return mylist;
    }


    public static int[] ordenaLista(int[] mylist)
    {

        Array.Sort(mylist);

        return mylist;
    }


    public static void exibeLista(int[] mylist)
    {
        Console.WriteLine("Minha Lista: ");
        foreach (int i in mylist)
        {
            Console.WriteLine(i);
        }
    }




    public static void pesquisaBinaria(int[] mylist)
    {
        Console.Write("Digite um numero: ");
        int num = Int32.Parse(Console.ReadLine());

        int esq = 0, dir = TAM - 1, meio, cont = 0;

        while (esq <= dir)
        {
            meio = (esq + dir) / 2;
            cont++;
            if (num == mylist[meio])
            {
                Console.WriteLine("Foram necessários {0} saltos", cont);
                esq = TAM;
            }
            else if (num > mylist[meio])
            {
                esq = meio + 1;
            }
            else
            {
                dir = meio - 1;
            }
        }


        Console.WriteLine("Foram necessários {0} saltos", cont);
    }




    public static int fatorial(int n)
    {
        int result;
        if (n == 1)
        {
            result = 1;
        }
        else
        {
            result = n * fatorial(n - 1);
        }
        return result;
    }


    public static int pesquisaBinariaRec(int[] mylist, int num, int esq, int dir)
    {
        if (esq > dir)
        {
            return -1;
        }
        else
        {
            int meio = (dir + esq) / 2;
            if (num == meio)
            {
                return meio;
            }
            else if (num < mylist[meio])
            {
                return pesquisaBinariaRec(mylist, num, esq, meio - 1);
            }
            else
            {
                return pesquisaBinariaRec(mylist, num, meio + 1, dir);
            }
        }
    }

    public static void ordenaListaArraySort()
    {
        Usuario[] usuarios = {
            new Usuario {nome = "Souza", matricula = 12},
            new Usuario {nome = "Diego", matricula = 34},
            new Usuario {nome = "Pereira", matricula = 65},
            new Usuario {nome = "Nascimento", matricula = 7},
            new Usuario {nome = "Allan", matricula = 12},
            };

        Array.Sort(usuarios);

        foreach (Usuario i in usuarios)
        {
            Console.WriteLine("Nome: {0} - Matricula {1}", i.nome, i.matricula);
        }

    }


    public static void ordenaListaSelecao(int[] mylist)
    {
        int cont = 0;
        for (int i = 0; i < (TAM - 1); i++)
        {
            int menor = i;
            for (int j = (i + 1); j < TAM; j++)
            {
                cont++;
                if (mylist[menor] > mylist[j])
                {
                    menor = j;
                }
            }
            swap(mylist, menor, i);
            
        }
        Console.WriteLine("{0} saltos", cont);
    }

    public static void swap(int[] mylist, int menor, int i)
    {
        int temp;

        temp = mylist[menor];
        mylist[menor] = mylist[i];
        mylist[i] = temp;
    }

    public static void  ordenaListaInsercao(int[] mylist){
        int cont = 0;
        for(int i = 1; i < mylist.Length; i++){            
            int temp = mylist[i];
            int j = i - 1;
            while(j >= 0 && mylist[j] > temp){
                mylist[temp] = mylist[j];
                cont++;
                j--;
            }
            mylist[i] = temp;
        }
        Console.WriteLine("Foram feitas {0} comparacoes", cont);
    }


    public static void ordenaListaQuickSort(int[] mylist, int esq, int dir){
        exibeLista(mylist);

        int i = esq, j = dir, pivo = mylist[(esq + dir) / 2];

        while( i <= j) {
            while(mylist[i] < pivo)
                i++;
            while(mylist[j] > pivo)
                j--;
            if(i <=j){
                swap(mylist, i, j);
                i++;
                j--;
            }
        }
        if (esq < j){
            ordenaListaQuickSort(mylist, esq, j);
        }
        if (i < dir){
            ordenaListaQuickSort(mylist, i, dir);
        }


    }



    public static void Main(string[] args)
    {


        int[] mylist = new int[TAM];

        // //popula lista
        mylist = populaLista(mylist);

        // //ordena lista
        // mylist = ordenaLista(mylist);


        //exibe lista
        //exibeLista(mylist);


        //pesquisa binaria
        //pesquisaBinaria(mylist);

        //algoritimo recurso fatorial
        // Console.WriteLine(fatorial(3));




        //pesquisa binaria recursiva
        // Console.Write("Digite um numero: ");
        // int num = Int32.Parse(Console.ReadLine());
        // Console.WriteLine(pesquisaBinariaRec(mylist, num, 0, mylist.Length - 1));


        //Ordena Lista Arrays.Sort
        // ordenaListaArraySort();

        //exibeLista(mylist);

        Console.WriteLine("Lista Ordenada: ");

        //Ordena Lista Seleção
        // ordenaListaSelecao(mylist);

        // exibeLista(mylist);

        // ordenaListaInsercao(mylist);

        ordenaListaQuickSort(mylist, 0 , mylist.Length - 1);

    }
}