using System;
using System.Globalization;
using System.IO;
using System.Threading.Channels;

using Humanizer;

Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
//try
//{
ConsoleKeyInfo cki;
var menu = new List<string[]>();
var comanda = new List<string[]>();
var comandaTexto = new List<string>();

do
{

   
    // Ruta del archivo
    string filePath = "c:/ITCafe/menu_Itstep_cafeteria-2.txt";

    // Lee todas las líneas del archivo y las carga en un array de strings
    string[] lines = File.ReadAllLines(filePath);

    // Imprime el contenido del array
    /* foreach (string line in lines)
     {
         Console.WriteLine(line);
     } */
    int counter = 1;
    foreach (string line in lines)
    {
        string[] item = line.Split(',');
        menu.Add(item);
    }


    Console.WriteLine(String.Format("| {0,-3} {1,-22} {2,-60} {3,-5} |", "", "", "Menu", ""));
    Console.WriteLine("-----------------------------------------------------------------------------------------");
    foreach (string[] product in menu)
    {
        Console.WriteLine(String.Format("| {0,-5} | {1,-22} | {2,-60} | {3,-5} |", counter, $"{product[0]}", product[1], product[2]));
        counter++;
    }

 
    bool pedidoFinalizado = false;
    while (!pedidoFinalizado) { 
        Console.WriteLine("Eliga el item que desee agregar");
        int tempItem = int.Parse(Console.ReadLine()!);

        Console.WriteLine($"Usted eligio {menu[tempItem - 1][0]}\n");

        Console.WriteLine("Eliga la cantidad a desear");
        int tempQuant = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < tempQuant; i++)
        {
            comanda.Add(menu[tempItem - 1]);
            
        }
        comandaTexto.Add($"Se ordeno {tempQuant} {menu[tempItem - 1][0]} | Son ${tempQuant * int.Parse(menu[tempItem - 1][2].Substring(2))}");

        Console.WriteLine("Desea agregar otra cosa? Presione cualquier tecla para continuar");
        Console.WriteLine("Si no desea agregar mas, presione N");

        string eleccion = Console.ReadLine()!;
       

        if (eleccion.ToLower() == "n")
        {
            pedidoFinalizado = true;

        } 

       
    }

    int total = 0;

    Console.Clear();

    foreach (string[] elemento in comanda)
    {
        total += int.Parse(elemento[2].Substring(2));
    }

    foreach(string text in comandaTexto)
    {
        Console.WriteLine(text);
    }

    Console.WriteLine($"\nEl total a pagar es {total.ToWords()} pesos");
    Console.WriteLine($"\n${total} m.n.");

    Console.WriteLine("\nPresione cualquier tecla si desea continuar");
    Console.WriteLine("Presione ESC si desea salir...");

    cki = Console.ReadKey();
    Console.Clear();
} while (cki.Key != ConsoleKey.Escape);



/*}
catch (Exception e)
{
    Console.WriteLine("Ocurrió un error: " + e.Message);
} */



