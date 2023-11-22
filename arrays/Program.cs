using System.Security.Cryptography;
using System;


public class Ponto {
    public int x {get; set;}
    public int y {get; set;}
}



class MainClass {

    const int TAM = 100;
    
    public static void Main(string[] args) {
    
        Ponto[] pontos = new Ponto[TAM];
        
        for(int i = 0; i < TAM; i++){
        Ponto pt = new Ponto {x = new Random().Next(100, 300), y = new Random().Next(500,800)};
        pontos[i] = pt;
        }
              

        
        Console.WriteLine(Array.Find(pontos, p => p.x * p.y > 100500));

        Ponto[] result =  Array.FindAll(pontos, p => p.x * p.y > 200500);

        foreach (Ponto p in result)
        {
            Console.WriteLine("Meus pontos: {0}, {1}",p.x, p.y);
        }
        

    }
}